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
