using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using PerCederberg.Grammatica.Runtime;

namespace PoiLanguage
{
    public enum PoiLayoutType
    {
        Undefined = 0,
        Page = 1,
        Grid = 2,
        Panel = 3,
        Group = 4
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
            CreateLayout(this, type);
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

        // 复制构造函数
        private PoiHtmlLayout(PoiHtmlLayout previous)
        {
            name = previous.name;
            type = previous.type;
            property = new Dictionary<string, string>(previous.property);
            content = new List<PoiHtmlElement>(previous.content);
        }

        // 根据"as"后的类型填充layout实例
        private void CreateLayout(PoiHtmlLayout rec, string type)
        {
            switch(type)
            {
                case "Page":
                    rec.type = PoiLayoutType.Page;
                    break;
                case "Grid":
                    rec.type = PoiLayoutType.Grid;
                    break;
                case "Panel":
                    rec.type = PoiLayoutType.Panel;
                    break;
                case "Group":
                    rec.type = PoiLayoutType.Group;
                    break;
                default:
                    rec = new PoiHtmlLayout(Map[type]);
                    break;
            }
        }

        // 生成并保存该页
        public void Generate()
        {
            string prefix, suffix;
            switch(type)
            {
                case PoiLayoutType.Page:
                    prefix = "<!DOCTYPE html>\r\n<html>";
                    if (property.ContainsKey("head")) prefix += "<head>\r\n" + property["head"] + "\r\n";
                    if (property.ContainsKey("title")) prefix += "<title>" + property["title"] + "</title>\r\n";
                    prefix += "</head>\r\n<body>\r\n";
                    foreach(PoiHtmlElement element in content)
                    {
                        // TO DO
                    }
                    suffix = "</body>\r\n</html>";
                    htmlcode = prefix + htmlcode + suffix;
                    // TO DO: IO
                    break;
                case PoiLayoutType.Grid:
                    break;
                case PoiLayoutType.Panel:
                    break;
                case PoiLayoutType.Group:
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
                    element = new PoiHtmlElement(child);
                    break;
                case PoiLayoutType.Grid:
                    if (child.type != PoiLayoutType.Panel)
                        throw new PoiAnalyzeException("Warning: Grid只能包含Panel");
                    x = Convert.ToInt32(data[1]);
                    y = Convert.ToInt32(data[2]);
                    w = Convert.ToInt32(data[3]);
                    h = Convert.ToInt32(data[4]);
                    if (x < 1 || y < 1 || w < 1 || h < 1 || x + w > cntrow || y + h > cntcol)
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
                    y = Convert.ToInt32(data[1]);
                    h = Convert.ToInt32(data[2]);
                    if (y < 1 || h < 1 || y + h > cntcol)
                        throw new PoiAnalyzeException("Warning: 元素占据Group的区域不合法");
                    element = new PoiHtmlElement(child, 0, y, 0, h);
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
                    return new PoiObject(PoiObjectType.String, "");
                case "generate":
                    if (this.type != PoiLayoutType.Page)
                        throw new PoiAnalyzeException("Warning: 只有Page才支持generate方法");
                    this.Generate();
                    return new PoiObject(PoiObjectType.String, "");
                default:
                    return new PoiObject(PoiObjectType.String, "");
            }
        }

        // 按照静态操作规则解析参数
        private List<string> ParseStatic(Node dataNode)
        {
            Node pairNode = dataNode.GetChildAt(0).GetChildAt(0);
            if (pairNode.GetName() != "PairExpression")
                throw new PoiAnalyzeException("Static struct operation only support Pair arguments consist of Literals");
            List<PoiObject> rawData = (pairNode.GetValue(0) as PoiObject).ToPair();
            List<string> data = new List<string>();
            for (int i = 0; i < rawData.Count;i++)
            {
                data.Add(rawData[i].ToString());
            }
            return data;
        }
    }

    class PoiHtmlElement
    {
        PoiHtmlLayout layout;
        Rectangle rect;

        public PoiHtmlElement(PoiHtmlLayout layout, int x = 0, int y = 0, int w = 0, int h = 0)
        {
            this.layout = layout;
            rect = new Rectangle(x, y, w, h);
        }
    }
}
