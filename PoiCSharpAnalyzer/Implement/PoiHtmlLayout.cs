using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using PerCederberg.Grammatica.Runtime;
using System.IO;

namespace PoiLanguage
{
    public enum PoiLayoutType
    {
        Undefined = 0,
        Page = 1,
        Grid = 2,
        Panel = 3,
        Group = 4,
        table = 5
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
        
        // 构造函数
        public PoiHtmlLayout(string name, string type, List<KeyValuePair<string, string>> rec)
        {
            this.name = name;
            CreateLayout(type);
            foreach(KeyValuePair<string,string> pair in rec)
            {
                switch(pair.Key)
                {
                    case "cntrow":
                        cntrow = Convert.ToInt32(pair.Value);
                        break;
                    case "cntcol":
                        cntcol = Convert.ToInt32(pair.Value);
                        break;
                    case "id":
                        property["id"] = pair.Value;
                        break;
                    case "title":
                        property["title"] = pair.Value;
                        break;
                    case "head":
                        property["head"] = pair.Value;
                        break;
                    default:
                        throw new PoiAnalyzeException("Struct not supported: " + pair.Key);
                }
            }
        }

        // 根据"as"后的类型填充layout实例
        private void CreateLayout(string type)
        {
            switch(type)
            {
                case "Page":
                    this.type = PoiLayoutType.Page;
                    break;
                case "Grid":
                    this.type = PoiLayoutType.Grid;
                    break;
                case "Panel":
                    this.type = PoiLayoutType.Panel;
                    break;
                case "Group":
                    this.type = PoiLayoutType.Group;
                    break;
                default:
                    CopyFrom(Map[type]);
                    break;
            }
        }

        private void CopyFrom(PoiHtmlLayout previous)
        {
            this.name = previous.name;
            this.type = previous.type;
            this.property = new Dictionary<string, string>(previous.property);
            this.content = new List<PoiHtmlElement>(previous.content);
        }

        // 生成并保存该页
        public void Generate()
        {
            string prefix, suffix;
            htmlcode = "";
            switch (type)
            {
                case PoiLayoutType.Page:
                    prefix = "<!DOCTYPE html>\r\n<html>\r\n";
                    if (property.ContainsKey("head"))
                        prefix += "<head>\r\n" + property["head"] + "\r\n";
                    else
                        prefix += "<head>\r\n";
                    if (property.ContainsKey("title")) prefix += "<title>" + property["title"] + "</title>\r\n";
                    prefix += "</head>\r\n<body>\r\n";
                    suffix = "</body>\r\n</html>\r\n";
                    if (content.Count > 0)
                    {
                        if (content[0].layout.type == PoiLayoutType.Grid)
                        {
                            content[0].layout.Generate();
                            htmlcode = string.Format("<div style=\"{0}\">\r\n{1}</div>\r\n",
                                MakeStyleAbso(0, 0, 100, 100, "%"), content[0].layout.htmlcode);
                        }
                        else
                        {
                            foreach (PoiHtmlElement element in content)
                            {
                                element.layout.Generate();
                                htmlcode += string.Format("<div style=\"{0}\">\r\n{1}</div>\r\n", MakeStyleFlow(), element.layout.htmlcode);
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
                    foreach(PoiHtmlElement element in content)
                    {
                        string pos_size = MakeStyleAbso(100.0 / cntcol * element.rect.X, 100.0 / cntrow * element.rect.Y, 100.0 / cntcol * element.rect.Width, 100.0 / cntrow * element.rect.Height, "%");
                        element.layout.Generate();
                        htmlcode += string.Format("<div style=\"{0}\">\r\n{1}</div>\r\n", pos_size, element.layout.htmlcode);
                    }
                    break;
                case PoiLayoutType.Panel:
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += string.Format("<div style=\"{0}\">\r\n{1}</div>\r\n", MakeStyleFlow(), element.layout.htmlcode);
                    }
                    break;
                case PoiLayoutType.Group:
                    prefix = "<table style=\"width:100%\">\r\n<tr>\r\n";
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
