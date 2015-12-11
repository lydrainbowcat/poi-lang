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
            if (type != PoiLayoutType.Page) return;

        }

        // 静态添加子元素
        public void Add(PoiHtmlElement element)
        {
            content.Add(element);
        }

        // 处理某种操作
        public PoiObject Solve(string operation, Node dataNode)
        {
            switch(operation) // 静态操作按照C#规则翻译，data应该为Literal构成的Pair；动态操作翻译为JS，直接生成操作data的代码。
            {
                case "add":
                    List<string> data = ParseStatic(dataNode);
                    // ...
                    break;
                default:
                    break;
            }
            return new PoiObject(PoiObjectType.String, "");
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
