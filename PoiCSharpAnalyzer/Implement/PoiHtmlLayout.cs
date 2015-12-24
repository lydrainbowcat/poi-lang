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
        Input = 7, // permission=("rxqac@..."), range=("min~max|step")
        Form = 8,
        Image = 9, // img
        Script = 10,
        Single = 11, // <* />, with br, hr
        Part = 12, // <*>...</*>, with div, span, p, pre, label, h1~h6, li, ol, ul
        Button = 13,
        Textarea = 14, // permission=("rxqa@...")

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
            { "Text", PoiLayoutType.Text },
            { "Script", PoiLayoutType.Script },
            { "Single", PoiLayoutType.Single },
            { "Part", PoiLayoutType.Part },
            { "Button", PoiLayoutType.Button },
            { "Textarea", PoiLayoutType.Textarea }
        };
        private static Dictionary<string, string> TextFormatMap = new Dictionary<string, string>
        { {"b","b"}, {"i","i"}, {"u","u"}, {"-","del"}, {"+","ins"}, {"_","sub"}, {"^","sup"}, {">","big"}, {"<","small"} };
        private static Dictionary<string, string> PermMap = new Dictionary<string, string>
        { {"x","disabled=\"disabled\" "}, {"r","readonly=\"readonly\" "}, {"q","required "}, {"a","autofocus "}, {"c","checked=\"checked\" "} };
        private static Dictionary<string, string> TablePosMap = new Dictionary<string, string>
        { {".","center"}, {"<","left"}, {">","right"}, {"^","top"}, {"v","bottom"} };
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
                    case "text":
                    case "type":
                        property[pair.Key] = value;
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
                        switch (pair.Key)
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
                    case PoiLayoutType.Table:
                        switch (pair.Key)
                        {
                            case "headpos": 
                            case "bodypos":
                                property[pair.Key] = string.Format("align=\"{0}\" valign=\"{1}\" ", TablePosMap[value[0].ToString()], TablePosMap[value[1].ToString()]);
                                break;
                        }
                        break;
                    case PoiLayoutType.Input:
                        if (!property.ContainsKey("permission")) property["permission"] = "";
                        switch (pair.Key)
                        {
                            case "pattern":
                            case "permission":
                            case "placeholder":
                                property[pair.Key] = value;
                                break;
                            case "range": // min~max|step
                                int pos_wave = value.IndexOf('~'), pos_step = value.IndexOf('|');
                                if (pos_step < 0) pos_step = value.Length;
                                if (pos_wave > 0) property["input_min"] = value.Substring(0, pos_wave);
                                if (pos_step - pos_wave > 1) property["input_max"] = value.Substring(pos_wave + 1, pos_step - pos_wave - 1);
                                if (pos_wave + 1 < value.Length) property["input_step"] = value.Substring(pos_step + 1);
                                break;
                        }
                        break;
                    case PoiLayoutType.Form:
                        switch(pair.Key)
                        {
                            case "action":
                            case "method":
                            case "enctype":
                            case "target":
                                property[pair.Key] = value;
                                break;
                        }
                        break;
                    case PoiLayoutType.Image:
                        switch(pair.Key)
                        {
                            case "url":
                                property["img_url"] = value;
                                break;
                        }
                        break;
                    case PoiLayoutType.Button:
                        if (!property.ContainsKey("permission")) property["permission"] = "tre";
                        switch (pair.Key)
                        {
                            case "permission": 
                            case "value":
                                property[pair.Key] = value;
                                break;
                        }
                        break;
                    case PoiLayoutType.Textarea:
                        if (!property.ContainsKey("permission")) property["permission"] = "";
                        switch (pair.Key)
                        {
                            case "permission":
                            case "placeholder":
                                property[pair.Key] = value;
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
                    foreach (PoiHtmlElement element in content)
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
                    string textf = GetProperty("text_format"), textv = GetProperty("text_value");
                    if (textf.Length > 0 && textf[0] == '/') // hint
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

                case PoiLayoutType.Table:
                    if (cntrow < 1 || cntcol < 1)
                        throw new PoiAnalyzeException("Warning: cntrow and cntcol of Table shoule be positive integer");
                    PoiHtmlElement[,] table = new PoiHtmlElement[cntrow + 1, cntcol + 1];
                    bool[,] occupy = new bool[cntrow + 1, cntcol + 1];
                    foreach(PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        table[element.rect.X, element.rect.Y] = element;
                    }
                    prefix = string.Format("<table name=\"{0}\" id=\"{1}\">\r\n", name, GetProperty("id"));
                    suffix = "</table>";
                    string thead = string.Format("<thead {0}>\r\n<tr>\r\n", GetProperty("headpos"));
                    for (int i = 1; i <= cntcol;)
                    {
                        if (table[0, i] == null)
                        {
                            thead += "<th></th>\r\n";
                            i++; continue;
                        }
                        thead += string.Format("<th colspan=\"{0}\">{1}</th>\r\n", table[0, i].rect.Width, table[0, i].layout.htmlcode);
                        i += table[0, i].rect.Width;
                    }
                    thead += "</tr></thead>\r\n";
                    string tbody = string.Format("<tbody {0}>\r\n", GetProperty("bodypos"));
                    for (int i = 1; i <= cntrow; i++)
                    {
                        tbody += "<tr>\r\n";
                        for (int j = 1; j <= cntcol; j++)
                        {
                            if (occupy[i, j]) continue;
                            if (table[i, j] == null)
                            {
                                tbody += "<td></td>\r\n";
                                continue;
                            }
                            tbody += string.Format("<td rowspan=\"{0}\" colspan=\"{1}\">{2}</td\r\n>", table[i, j].rect.Height, table[i, j].rect.Width, table[i, j].layout.htmlcode);
                            for (int x = 0; x < table[i, j].rect.Height; x++)
                                for (int y = 0; y < table[i, j].rect.Width; y++)
                                    occupy[i + x, j + y] = true;
                        }
                        tbody += "</tr>\r\n";
                    }
                    tbody += "</tbody>\r\n";
                    htmlcode = prefix + thead + tbody + suffix;
                    break;

                case PoiLayoutType.Input:
                    string input = string.Format("placeholder=\"{0}\" ", GetProperty("placeholder"));
                    string input_perm = GetProperty("permission");
                    int pos_form = input_perm.IndexOf('@');
                    if (pos_form >= 0 && pos_form < input_perm.Length) // form
                    {
                        input += string.Format("form=\"{0}\" ", input_perm.Substring(pos_form + 1));
                        input_perm = input_perm.Substring(0, pos_form);
                    }
                    for (int i = 0; i < input_perm.Length; i++)
                    {
                        if (!PermMap.ContainsKey(input_perm[i].ToString())) continue;
                        input += PermMap[input_perm[i].ToString()];
                    }
                    string input_min = GetProperty("input_min"), input_max = GetProperty("input_max"), input_step = GetProperty("input_step");
                    if (input_min != "") input += string.Format("min=\"{0}\" ", input_min);
                    if (input_max != "") input += string.Format("max=\"{0}\" ", input_max);
                    if (input_step != "") input += string.Format("step=\"{0}\" ", input_step);
                    htmlcode = string.Format("<input name=\"{0}\" value=\"{1}\" id=\"{2}\" {3} />",
                        name, GetProperty("text"), GetProperty("id"), input);
                    break;

                case PoiLayoutType.Form:
                    string param = string.Format("action=\"{0}\" ", GetProperty("action"));
                    if (property.ContainsKey("method")) param += string.Format("method=\"{1}\" ", GetProperty("method"));
                    if (property.ContainsKey("enctype")) param += string.Format("enctype=\"{1}\" ", GetProperty("enctype"));
                    if (property.ContainsKey("target")) param += string.Format("target=\"{1}\" ", GetProperty("target"));
                    prefix = string.Format("<form {0}>", param);
                    suffix = "</form>";
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += element.layout.htmlcode;
                    }
                    htmlcode = prefix + htmlcode + suffix;
                    break;

                case PoiLayoutType.Image:
                    htmlcode = string.Format("<img src=\"{0}\" alt=\"{1}\" name=\"{2}\" id=\"{3}\" />\r\n",
                        GetProperty("url"), GetProperty("text"), name, GetProperty("id"));
                    break;

                case PoiLayoutType.Part:
                    htmlcode = GetProperty("text");
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += element.layout.htmlcode;
                    }
                    htmlcode = string.Format("<{0} name=\"{2}\" id=\"{3}\">\r\n{1}</{0}>\r\n",
                        GetProperty("type"), htmlcode, name, GetProperty("id"));
                    break;

                case PoiLayoutType.Single:
                    htmlcode = string.Format("<{0} name=\"{1}\" id=\"{2}\" />\r\n",
                        GetProperty("type"), name, GetProperty("id"));
                    break;

                case PoiLayoutType.Script:
                    htmlcode = GetProperty("text");
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += element.layout.htmlcode;
                    }
                    htmlcode = "<script>" + htmlcode + "</script>";
                    break;

                case PoiLayoutType.Button:
                    htmlcode = GetProperty("text");
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += element.layout.htmlcode;
                    }
                    string btn = string.Format("value=\"{0}\" ", GetProperty("value"));
                    string btn_perm = GetProperty("permission");
                    int btn_form = btn_perm.IndexOf('@');
                    if (btn_form >= 0 && btn_form < btn_perm.Length) // form
                    {
                        btn += string.Format("form=\"{0}\" ", btn_perm.Substring(btn_form + 1));
                        btn_perm = btn_perm.Substring(0, btn_form);
                    }
                    for (int i = 0; i < btn_perm.Length; i++)
                    {
                        if (!PermMap.ContainsKey(btn_perm[i].ToString())) continue;
                        btn += PermMap[btn_perm[i].ToString()];
                    }
                    if (property.ContainsKey("type"))
                        btn += string.Format("type=\"{0}\" ", GetProperty("type"));
                    htmlcode = string.Format("<button name=\"{1}\" id=\"{2}\" {3}>\r\n{0}</button>\r\n",
                    htmlcode, name, GetProperty("id"), btn);
                    break;

                case PoiLayoutType.Textarea:
                    htmlcode = GetProperty("text");
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += element.layout.htmlcode;
                    }
                    string area = string.Format("placeholder=\"{0}\" ", GetProperty("placeholder"));
                    string area_perm = GetProperty("permission");
                    pos_form = area_perm.IndexOf('@');
                    if (pos_form >= 0 && pos_form < area_perm.Length) // form
                    {
                        area += string.Format("form=\"{0}\"", area_perm.Substring(pos_form + 1));
                        area_perm = area_perm.Substring(0, pos_form);
                    }
                    for(int i=0;i<area_perm.Length;i++)
                    {
                        if (!PermMap.ContainsKey(area_perm[i].ToString())) continue;
                        area += PermMap[area_perm[i].ToString()];
                    }
                    htmlcode = string.Format("<textarea name=\"{1}\" id=\"{2}\" {3}>\r\n{0}</textarea>\r\n",
                    htmlcode, name, GetProperty("id"), area);
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
                        throw new PoiAnalyzeException("Warning: Panel只能包含Panel, Group或HTML DOM类元素");
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
                case PoiLayoutType.Table:
                    if (Convert.ToInt32(child.type) < Convert.ToInt32(PoiLayoutType.Panel))
                        throw new PoiAnalyzeException("Warning: " + type + "只能包含HTML DOM类元素");
                    while (data.Count < 4) data.Add("1");
                    x = Convert.ToInt32(data[1]);
                    y = Convert.ToInt32(data[2]);
                    h = Convert.ToInt32(data[3]);
                    w = Convert.ToInt32(data[4]);
                    if (x < 0 || h < 1 || y < 1 || w < 1 || x + h > cntrow || y + w > cntcol)
                        throw new PoiAnalyzeException("Warning: 元素占据Table的区域不合法");
                    element = new PoiHtmlElement(child, x, y, w, h);
                    break;
                case PoiLayoutType.Form:
                case PoiLayoutType.Part:
                case PoiLayoutType.Script:
                case PoiLayoutType.Button:
                case PoiLayoutType.Textarea:
                    if (Convert.ToInt32(child.type) < Convert.ToInt32(PoiLayoutType.Panel))
                        throw new PoiAnalyzeException("Warning: " + type + "只能包含HTML DOM类元素");
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
            List<string> array = new List<string>();
            switch (operation) // 静态操作按照C#规则翻译，data应该为Literal构成的Pair；动态操作翻译为JS，直接生成操作data的代码。
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
                case "css":
                    array.Add("css");
                    array.Add(dataNode.GetValue(0).ToString());
                    return new PoiObject(PoiObjectType.Array, array);
                case "cssdel":
                    array.Add("cssdel");
                    array.Add(dataNode.GetValue(0).ToString());
                    return new PoiObject(PoiObjectType.Array, array);
                case "cssadd":
                    array.Add("cssadd");
                    data = ParseStatic(dataNode);
                    array.Add(data[0]);
                    array.Add(data[1]);
                    return new PoiObject(PoiObjectType.Array, array);
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
