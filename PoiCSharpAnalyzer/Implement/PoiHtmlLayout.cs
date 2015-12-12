using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using PerCederberg.Grammatica.Runtime;
using System.IO;
using System.Net;

namespace PoiLanguage
{
    public enum PoiLayoutType
    {
        Undefined = 0,
        Page = 1,
        Grid = 2,
        Panel = 3,
        Group = 4,
        Text = 5, // format=("/biu-+_^><@..."): with hint, a, b, i, u, del, ins, sub, sup, big, small
        Table = 6, // with tbody, thead, tfoot, tr, td, th, caption 
        Input = 7,
        Form = 8,
        Part = 9, // with div, span, p, pre, label
        Break = 10, // with br, hr
        Button = 11,
        H = 12, // h1 ~ h6,
        Image = 13, // img
        List = 14, // with li, ol, ul
        Script = 15,
        Textarea = 16,

        #region NOT_SUPPORTED_YET
        audio = 100,
        canvas = 101,
        code = 102,
        embed = 103,
        fieldset = 104,
        frame = 105, // frameset, frame
        iframe = 106,
        legend = 107, // with fieldset
        map = 108, //with canvas
        menu = 109,
        objects = 110,
        output = 111,
        time = 112,
        datalist = 113,
        select = 114,
        var = 115,
        video = 116,
        wbr = 117
        #endregion
    }

    class PoiHtmlLayout
    {
        string name;
        PoiLayoutType type;
        int cntrow = 0, cntcol = 0;
        private Dictionary<string, string> property = new Dictionary<string, string>();
        private List<PoiHtmlElement> content = new List<PoiHtmlElement>();
        private string htmlcode;

        public static Dictionary<string, PoiHtmlLayout> Map = new Dictionary<string, PoiHtmlLayout>();
        public static Dictionary<string, PoiLayoutType> TypeMap = new Dictionary<string, PoiLayoutType>
        {
            { "Page", PoiLayoutType.Page },
            { "Grid", PoiLayoutType.Grid },
            { "Panel", PoiLayoutType.Panel },
            { "Group", PoiLayoutType.Group },
            { "Text", PoiLayoutType.Text }
        };
        private static Dictionary<string, string> TextFormatMap = new Dictionary<string, string>
        { {"b","b"}, {"i","i"}, {"u","u"}, {"-","del"}, {"+","ins"}, {"_","sub"}, {"^","sup"}, {">","big"}, {"<","small"} };
        private static Random rand = new Random();
        
        // 构造函数
        public PoiHtmlLayout(string name, string type, List<KeyValuePair<string, string>> rec)
        {
            this.name = name;

            // 根据"as"后的类型填充type
            if (TypeMap.ContainsKey(type))
                this.type = TypeMap[type];
            else
            {
                PoiHtmlLayout previous = Map[type];
                this.name = previous.name;
                this.type = previous.type;
                this.property = new Dictionary<string, string>(previous.property);
                this.content = new List<PoiHtmlElement>(previous.content);
            }

            foreach(KeyValuePair<string,string> pair in rec)
            {
                string value = pair.Value;
                if (pair.Value[0] == '"')
                    value = pair.Value.Substring(1, pair.Value.Length - 2);
                switch(pair.Key) // 公有属性
                {
                    case "cntrow":
                        cntrow = Convert.ToInt32(value);
                        break;
                    case "cntcol":
                        cntcol = Convert.ToInt32(value);
                        break;
                    case "id":
                        property["id"] = value;
                        break;
                }
                switch(this.type)
                {
                    case PoiLayoutType.Page:
                        switch(pair.Key)
                        {
                            case "title":
                                property["page_title"] = value;
                                break;
                            case "head":
                                property["page_head"] = value;
                                break;
                        }
                        break;
                    case PoiLayoutType.Text:
                        switch(pair.Key)
                        {
                            case "format":
                                property["text_format"] = value;
                                break;
                            case "value":
                                property["text_value"] = value;
                                break;
                            case "encode":
                                property["text_encode"] = value;
                                break;
                        }
                        break;
                }
            }
        }

        // 生成并保存该页
        public void Generate()
        {
            string prefix = "", suffix = "";
            htmlcode = "";
            switch (type)
            {
                case PoiLayoutType.Page:
                    prefix = "<!DOCTYPE html>\r\n<html>\r\n";
                    if (property.ContainsKey("page_head"))
                        prefix += "<head>\r\n" + property["page_head"] + "\r\n";
                    else
                        prefix += "<head>\r\n";
                    if (property.ContainsKey("page_title")) prefix += "<title>" + property["page_title"] + "</title>\r\n";
                    prefix += string.Format("</head>\r\n<body name=\"{0}\" id=\"{1}\">\r\n", name, GetProperty("id", name));
                    suffix = "</body>\r\n</html>\r\n";
                    if (content.Count > 0)
                    {
                        if (content[0].layout.type == PoiLayoutType.Grid)
                        {
                            content[0].layout.Generate();
                            htmlcode = content[0].layout.htmlcode;
                        }
                        else
                        {
                            foreach (PoiHtmlElement element in content)
                            {
                                element.layout.Generate();
                                htmlcode += element.layout.htmlcode;
                            }
                        }
                    }
                    htmlcode = prefix + htmlcode + suffix;
                    if (!Directory.Exists("views"))
                        Directory.CreateDirectory("views");
                    StreamWriter writer = new StreamWriter(string.Format("views/{0}.html", name));
                    writer.Write(htmlcode);
                    writer.Close();
                    break;
                case PoiLayoutType.Grid:
                    foreach (PoiHtmlElement element in content)
                    {
                        string pos_size = MakeStyleAbso(100.0 / cntcol * element.rect.X, 100.0 / cntrow * element.rect.Y, 100.0 / cntcol * element.rect.Width, 100.0 / cntrow * element.rect.Height, "%");
                        element.layout.Generate();
                        htmlcode += string.Format("<div style=\"{0}\">\r\n{1}</div>\r\n", pos_size, element.layout.htmlcode);
                    }
                    htmlcode = string.Format("<div name=\"{2}\" id=\"{3}\" style=\"{0}\">\r\n{1}</div>\r\n",
                        MakeStyleAbso(0, 0, 100, 100, "%"), htmlcode, name, GetProperty("id"));
                    break;
                case PoiLayoutType.Panel:
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += element.layout.htmlcode;
                    }
                    htmlcode = string.Format("<div name=\"{2}\" id=\"{3}\" style=\"{0}\">\r\n{1}</div>\r\n", 
                        MakeStyleFlow(), htmlcode, name, GetProperty("id"));
                    break;
                case PoiLayoutType.Group:
                    prefix = "<table width=\"100%\">\r\n<colgroup>";
                    for (int i = 0; i < cntcol; i++)
                        prefix += string.Format("<col width=\"{0}%\"></col>", 100.0 / cntcol);
                    prefix += "</colgroup>\r\n<tr>\r\n";
                    suffix = "</tr>\r\n</table>\r\n";
                    PoiHtmlElement[] ele_list = new PoiHtmlElement[cntcol];
                    foreach(PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        ele_list[element.rect.X] = element;
                    }
                    for (int i = 0; i < cntcol;)
                    {
                        if (ele_list[i] == null)
                        {
                            htmlcode += "<td></td>\r\n";
                            i++; continue;
                        }
                        htmlcode += string.Format("<td colspan=\"{0}\">\r\n{1}</td>\r\n", ele_list[i].rect.Width, ele_list[i].layout.htmlcode);
                        i += ele_list[i].rect.Width;
                    }
                    htmlcode = prefix + htmlcode + suffix;
                    htmlcode = string.Format("<div name=\"{2}\" id=\"{3}\" style=\"{0}\">\r\n{1}</div>\r\n", 
                        MakeStyleFlow(), htmlcode, name, GetProperty("id"));
                    break;
                case PoiLayoutType.Text: // format=("/biu-+_^><@...")
                    string textf = property["text_format"], textv = property["text_value"];
                    if (textf[0] == '/') // hint
                        htmlcode = "<!--" + textv + "-->";
                    else
                    {
                        if (!property.ContainsKey("text_encode") || property["text_encode"] != "false")
                            textv = WebUtility.HtmlEncode(textv);
                        int pos = textf.IndexOf('@');
                        if (pos >= 0 && pos < textf.Length) // href
                        {
                            prefix += string.Format("<a href=\"{0}\">", textf.Substring(pos + 1));
                            suffix = string.Format("</a>") + suffix;
                            textf = textf.Substring(0, pos);
                        }
                        for (int i = 0; i < textf.Length; i++) // others
                        {
                            if (!TextFormatMap.ContainsKey(textf[i].ToString())) continue;
                            prefix += string.Format("<{0}>", TextFormatMap[textf[i].ToString()]);
                            suffix = string.Format("</{0}>", TextFormatMap[textf[i].ToString()]) + suffix;
                        }
                        foreach (PoiHtmlElement element in content)
                        {
                            element.layout.Generate();
                            textv += element.layout.htmlcode;
                        }
                        htmlcode = prefix + textv + suffix;
                        htmlcode = string.Format("<span name=\"{1}\" id=\"{2}\">\r\n{0}\r\n</span>\r\n", htmlcode, name, GetProperty("id"));
                    }
                    break;
                default:
                    break;
            }
        }

        // 静态添加子元素
        public void Add(List<string> data)
        {
            if (!Map.ContainsKey(data[0]))
                throw new PoiAnalyzeException("Struct.add: adding not existing element " + data[0]);
            PoiHtmlLayout child = Map[data[0]];
            PoiHtmlElement element;
            int x, y, w, h;
            switch (this.type)
            {
                case PoiLayoutType.Page:
                    if (child.type != PoiLayoutType.Panel && child.type != PoiLayoutType.Grid)
                        throw new PoiAnalyzeException("Warning: Page只能包含Panel或Grid");
                    if (child.type == PoiLayoutType.Grid && content.Count > 0)
                        throw new PoiAnalyzeException("Warning: 包含一个Grid的Page不能再容纳其他元素");
                    element = new PoiHtmlElement(child);
                    break;
                case PoiLayoutType.Grid:
                    if (child.type != PoiLayoutType.Panel)
                        throw new PoiAnalyzeException("Warning: Grid只能包含Panel");
                    x = Convert.ToInt32(data[1]);
                    y = Convert.ToInt32(data[2]);
                    w = Convert.ToInt32(data[3]);
                    h = Convert.ToInt32(data[4]);
                    if (x < 0 || y < 0 || w < 1 || h < 1 || x + w > cntcol || y + h > cntrow)
                        throw new PoiAnalyzeException("Warning: 元素占据Grid的区域不合法");
                    element = new PoiHtmlElement(child, x, y, w, h);
                    break;
                case PoiLayoutType.Panel:
                    if (Convert.ToInt32(child.type) < Convert.ToInt32(PoiLayoutType.Panel))
                        throw new PoiAnalyzeException("Warning: Panel只能包含Panel, Group或具体的HTML DOM元素");
                    element = new PoiHtmlElement(child);
                    break;
                case PoiLayoutType.Group:
                    if (child.type != PoiLayoutType.Panel)
                        throw new PoiAnalyzeException("Warning: Group只能包含Panel");
                    x = Convert.ToInt32(data[1]);
                    w = Convert.ToInt32(data[2]);
                    if (x < 0 || w < 1 || x + w > cntcol)
                        throw new PoiAnalyzeException("Warning: 元素占据Group的区域不合法");
                    element = new PoiHtmlElement(child, x, 0, w, 0);
                    break;
                case PoiLayoutType.Text:
                    element = new PoiHtmlElement(child);
                    break;
                default:
                    throw new PoiAnalyzeException("Warning: Struct in type " + this.type + " doesn't have Add method.");
            }
            content.Add(element);
        }

        // 处理某种操作
        public PoiObject Solve(string operation, Node dataNode)
        {
            switch(operation) // 静态操作按照C#规则翻译，data应该为Literal构成的Pair；动态操作翻译为JS，直接生成操作data的代码。
            {
                case "add":
                    List<string> data = ParseStatic(dataNode);
                    this.Add(data);
                    return new PoiObject(PoiObjectType.String, "static add");
                case "generate":
                    if (this.type != PoiLayoutType.Page)
                        throw new PoiAnalyzeException("Warning: 只有Page才支持generate方法");
                    this.Generate();
                    return new PoiObject(PoiObjectType.String, "static generate");
                default:
                    return new PoiObject(PoiObjectType.String, "static");
            }
        }

        // 按照静态操作规则解析参数
        private List<string> ParseStatic(Node dataNode)
        {
            Node pairNode = dataNode.GetChildAt(0).GetChildAt(0);
            List<string> data = new List<string>();
            if (pairNode.GetName() == "PairExpression")
            {
                List<PoiObject> rawData = (pairNode.GetValue(0) as PoiObject).ToPair();
                for (int i = 0; i < rawData.Count; i++)
                {
                    data.Add(rawData[i].ToString());
                }
            }
            else data.Add((pairNode.GetValue(0) as PoiObject).ToString());
            return data;
        }

        private string MakeStyleAbso(double left, double top, double width, double height, string unit)
        {
            return string.Format("position:absolute; left:{0}; top:{1}; width:{2}; height:{3}", left + unit, top + unit, width + unit, height + unit);
        }

        private string MakeStyleFlow(double width = 100, string unit = "%")
        {
            return string.Format("width:{0}", width + unit);
        }

        private string GetProperty(string key, string default_str = "")
        {
            /*if (default_str == "")
            {
                default_str = "_undefined_";
                for (int i = 0; i < 10; i++) default_str += rand.Next(10);
                default_str += "_";
            }*/
            return property.ContainsKey(key) ? property[key] : default_str;
        }
    }

    class PoiHtmlElement
    {
        public PoiHtmlLayout layout;
        public Rectangle rect;

        public PoiHtmlElement(PoiHtmlLayout layout, int x = 0, int y = 0, int w = 0, int h = 0)
        {
            this.layout = layout;
            rect = new Rectangle(x, y, w, h);
        }
    }
}
