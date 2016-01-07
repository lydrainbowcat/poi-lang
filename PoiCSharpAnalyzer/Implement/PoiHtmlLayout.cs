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
        Dynamic = 15,

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
            { "Table", PoiLayoutType.Table },
            { "Input", PoiLayoutType.Input },
            { "Form", PoiLayoutType.Form },
            { "Image", PoiLayoutType.Image },
            { "Script", PoiLayoutType.Script },
            { "Single", PoiLayoutType.Single },
            { "Part", PoiLayoutType.Part },
            { "Button", PoiLayoutType.Button },
            { "Textarea", PoiLayoutType.Textarea },
            { "Dynamic", PoiLayoutType.Dynamic }
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
                    case "class":
                        if (!property.ContainsKey("class")) property["class"] = " ";
                        if (value.StartsWith("+"))
                        {
                            value = value.Substring(1);
                            if (!property["class"].Contains(" " + value + " "))
                                property["class"] += value + " ";
                        }
                        else if (value.StartsWith("-"))
                        {
                            value = value.Substring(1);
                            property["class"].Replace(" " + value + " ", " ");
                        }
                        else property["class"] = " " + value + " ";
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
                            case "style":
                                if (!property.ContainsKey("page_style")) property["page_style"] = "";
                                property["page_style"] += string.Format("<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\">\r\n", value);
                                break;
                            case "script":
                                if (!property.ContainsKey("page_script")) property["page_script"] = "";
                                property["page_script"] += string.Format("<script src=\"{0}\"></script>\r\n", value);
                                break;
                            case "tip":
                                if (!property.ContainsKey("page_tips")) property["page_tips"] = "";
                                property["page_tips"] += value + "\r\n";
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

        // 处理某种操作
        public PoiObject Solve(string operation, Node dataNode)
        {
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
                case "gcss":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("for (var __i in {1}){{\r\n$(\"[name = '{0}']\").css(__i, {1}[__i])\r\n}}", name, data[0]));
                case "cssdel":
                case "gcssdel":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[name = '{0}']\").css({1},\"\")", name, data[0]));
                case "cssadd":
                case "gcssadd":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[name = '{0}']\").css({1},{2})", name, data[0], data[1]));
                case "lcss":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("for (var __i in {1}){{\r\n" +
                                         "$(\"[title = '{0}']\").css(__i, {1}[__i])" + "\r\n}}", MakeJSValue(name), data[0]));
                case "lcssdel":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[title = '{0}']\").css({1},\"\")", MakeJSValue(name), data[0]));
                case "lcssadd":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[title = '{0}']\").css({1},{2})", MakeJSValue(name), data[0], data[1]));
                case "classadd":
                case "gclassadd":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[name = '{0}']\").addClass({1})", name, data[0]));
                case "classdel":
                case "gclassdel":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[name = '{0}']\").removeClass({1})", name, data[0]));
                case "classtoggle":
                case "gclasstoggle":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[name = '{0}']\").toggleClass({1})", name, data[0]));
                case "lclassadd":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[title = '{0}']\").addClass({1})", MakeJSValue(name), data[0]));
                case "lclassdel":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[title = '{0}']\").removeClass({1})", MakeJSValue(name), data[0]));
                case "lclasstoggle":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[title = '{0}']\").toggleClass({1})", MakeJSValue(name), data[0]));
                case "bind":
                case "gbind":
                    string value;
                    data = ParseStatic(dataNode);
                    value = "$(\"[name = '" + name + "']\").bind(" + data[0] + ", {";
                    if (data.Count > 2) value += "__key1:" + data[2];
                    for (int i = 3; i < data.Count; i++) value += ", __key" + (i - 1) + ":" + data[i];
                    value += "} , function(__args){" + data[1] + ".execute(";
                    if (data.Count > 2) value += "__args.data.__key1";
                    for (int i = 3; i < data.Count; i++) value += ", __args.data.__key" + (i - 1);
                    value += ")})";
                    return new PoiObject(PoiObjectType.String, value);
                case "lbind":
                    data = ParseStatic(dataNode);
                    value = "$(\"[title = '" + MakeJSValue(name) + "']\").bind(" + data[0] + ", {";
                    if (data.Count > 2) value += "__key1:" + data[2];
                    for (int i = 3; i < data.Count; i++) value += ", __key" + (i - 1) + ":" + data[i];
                    value += "} , function(__args){" + data[1] + ".execute(";
                    if (data.Count > 2) value += "__args.data.__key1";
                    for (int i = 3; i < data.Count; i++) value += ", __args.data.__key" + (i - 1);
                    value += ")})";
                    return new PoiObject(PoiObjectType.String, value);
                case "erase":
                case "gerase":
                    data = ParseStatic(dataNode);
                    value = "$(\"[name = '" + name + "']\").unbind(" + data[0] + ");\r\n";
                    return new PoiObject(PoiObjectType.String, value);
                case "lerase":
                    data = ParseStatic(dataNode);
                    value = "$(\"[title = '" + MakeJSValue(name) + "']\").unbind(" + data[0] + ");\r\n";
                    return new PoiObject(PoiObjectType.String, value);
                case "click":
                case "gclick":
                    data = ParseStatic(dataNode);
                    value = "$(\"[name = '" + name + "']\").unbind('click');\r\n" +
                        "$(\"[name = '" + name + "']\").click(function(){" + data[0] + ".execute(";
                    if (data.Count > 1) value += data[1];
                    for (int i = 2; i < data.Count; i++) value += "," + data[i];
                    value += ")})";
                    value = "{" + value + "}";
                    return new PoiObject(PoiObjectType.String, value);
                case "dblclick":
                case "gdblclick":
                    data = ParseStatic(dataNode);
                    value = "$(\"[name = '" + name + "']\").unbind('dblclick');\r\n" +
                        "$(\"[name = '" + name + "']\").dblclick(function(){" + data[0] + ".execute(";
                    if (data.Count > 1) value += data[1];
                    for (int i = 2; i < data.Count; i++) value += "," + data[i];
                    value += ")})";
                    value = "{" + value + "}";
                    return new PoiObject(PoiObjectType.String, value);
                case "focus":
                case "gfocus":
                    data = ParseStatic(dataNode);
                    value = "$(\"[name = '" + name + "']\").unbind('focus');\r\n" +
                        "$(\"[name = '" + name + "']\").focus(function(){" + data[0] + ".execute(";
                    if (data.Count > 1) value += data[1];
                    for (int i = 2; i < data.Count; i++) value += "," + data[i];
                    value += ")})";
                    value = "{" + value + "}";
                    return new PoiObject(PoiObjectType.String, value);
                case "mouseover":
                case "gmouseover":
                case "gmo":
                    data = ParseStatic(dataNode);
                    value = "$(\"[name = '" + name + "']\").unbind('mouseover');\r\n" +
                        "$(\"[name = '" + name + "']\").mouseover(function(){" + data[0] + ".execute(";
                    if (data.Count > 1) value += data[1];
                    for (int i = 2; i < data.Count; i++) value += "," + data[i];
                    value += ")})";
                    value = "{" + value + "}";
                    return new PoiObject(PoiObjectType.String, value);
                case "lclick":
                    data = ParseStatic(dataNode);
                    value = "$(\"[title = '" + MakeJSValue(name) + "']\").unbind('click');\r\n" +
                        "$(\"[title = '" + MakeJSValue(name) + "']\").click(function(){" + data[0] + ".execute(";
                    if (data.Count > 1) value += data[1];
                    for (int i = 2; i < data.Count; i++) value += "," + data[i];
                    value += ")})";
                    value = "{" + value + "}";
                    return new PoiObject(PoiObjectType.String, value);
                case "ldblclick":
                    data = ParseStatic(dataNode);
                    value = "$(\"[title = '" + MakeJSValue(name) + "']\").unbind('dblclick');\r\n" +
                        "$(\"[title = '" + MakeJSValue(name) + "']\").dblclick(function(){" + data[0] + ".execute(";
                    if (data.Count > 1) value += data[1];
                    for (int i = 2; i < data.Count; i++) value += "," + data[i];
                    value += ")})";
                    value = "{" + value + "}";
                    return new PoiObject(PoiObjectType.String, value);
                case "lfocus":
                    data = ParseStatic(dataNode);
                    value = "$(\"[title = '" + MakeJSValue(name) + "']\").unbind('focus');\r\n" +
                        "$(\"[title = '" + MakeJSValue(name) + "']\").focus(function(){" + data[0] + ".execute(";
                    if (data.Count > 1) value += data[1];
                    for (int i = 2; i < data.Count; i++) value += "," + data[i];
                    value += ")})";
                    value = "{" + value + "}";
                    return new PoiObject(PoiObjectType.String, value);
                case "lmouseover":
                case "lmo":
                    data = ParseStatic(dataNode);
                    value = "$(\"[title = '" + MakeJSValue(name) + "']\").unbind('mouseover');\r\n" +
                        "$(\"[title = '" + MakeJSValue(name) + "']\").mouseover(function(){" + data[0] + ".execute(";
                    if (data.Count > 1) value += data[1];
                    for (int i = 2; i < data.Count; i++) value += "," + data[i];
                    value += ")})";
                    value = "{" + value + "}";
                    return new PoiObject(PoiObjectType.String, value);
                case "append":
                case "gappend":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, this.AppendGlobal(data));
                case "show":
                case "gshow":
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[name = '{0}']\").show()", name));
                case "hide":
                case "ghide":
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[name = '{0}']\").hide()", name));
                case "clear":
                case "gclear":
                    data = dataNode.GetName() == "SYMBOL_RIGHT_PAREN" ? null : ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, this.ClearGlobal(data));
                case "lappend":
                    data = ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, this.AppendLocal(data));
                case "lshow":
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[title = '{0}']\").show()", MakeJSValue(name)));
                case "lhide":
                    return new PoiObject(PoiObjectType.String, string.Format("$(\"[title = '{0}']\").hide()", MakeJSValue(name)));
                case "lclear":
                    data = dataNode.GetName() == "SYMBOL_RIGHT_PAREN" ? null : ParseStatic(dataNode);
                    return new PoiObject(PoiObjectType.String, this.ClearLocal(data));
                case "text":
                case "gtext":
                case "ltext":
                    return new PoiObject(PoiObjectType.String, this.OprText(ParseStatic(dataNode), operation));
                case "url":
                case "gurl":
                case "lurl":
                    return new PoiObject(PoiObjectType.String, this.OprUrl(ParseStatic(dataNode), operation));
                case "perm":
                case "gperm":
                case "lperm":
                    return new PoiObject(PoiObjectType.String, this.UpdatePerm(ParseStatic(dataNode), operation));

                default:
                    return new PoiObject(PoiObjectType.String, "static");
            }
        }

        // 生成一个元素的HTML代码
        private void Generate(bool dynamic = false)
        {
            string prefix = "", suffix = "", title = "";
            htmlcode = "";
            if (dynamic) title = string.Format("' + ({0}) + '", name);
            switch (type)
            {
                case PoiLayoutType.Page:
                    prefix = "<!DOCTYPE html>\r\n<html>\r\n";
                    if (property.ContainsKey("page_head"))
                        prefix += "<head>\r\n" + property["page_head"] + "\r\n";
                    else
                        prefix += "<head>\r\n";
                    prefix += "<script src=\"js/jquery-2.1.4.min.js\"></script>\r\n";
                    prefix += "<script src=\"js/poi~.js\"></script>\r\n";
                    prefix += "<!-- This page was generated by poi~ languange. -->\r\n";
                    if (property.ContainsKey("page_title")) prefix += "<title>" + property["page_title"] + "</title>\r\n";
                    if (property.ContainsKey("page_style")) prefix += property["page_style"];
                    if (property.ContainsKey("page_script")) prefix += property["page_script"];
                    if (property.ContainsKey("page_tips")) prefix += property["page_tips"];
                    prefix += string.Format("</head>\r\n<body name=\"{0}\" title=\"{2}\" class=\"{1}\">\r\n", name, GetProperty("class", name), title);
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
                    if (!Directory.Exists("views/js"))
                        Directory.CreateDirectory("views/js");
                    File.Copy("jquery-2.1.4.min.js", "views/js/jquery-2.1.4.min.js", true);
                    break;

                case PoiLayoutType.Grid:
                    foreach (PoiHtmlElement element in content)
                    {
                        string pos_size = MakeStyleAbso(100.0 / cntcol * element.rect.X, 100.0 / cntrow * element.rect.Y, 100.0 / cntcol * element.rect.Width, 100.0 / cntrow * element.rect.Height, "%");
                        element.layout.Generate();
                        htmlcode += string.Format("<div style=\"{0}\">{1}</div>", pos_size, element.layout.htmlcode);
                    }
                    htmlcode = string.Format("<div name=\"{2}\" title=\"{4}\" class=\"{3}\" style=\"{0}\">{1}</div>",
                        MakeStyleAbso(0, 0, 100, 100, "%"), htmlcode, name, GetProperty("class"), title);
                    break;

                case PoiLayoutType.Panel:
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += element.layout.htmlcode;
                    }
                    htmlcode = string.Format("<div name=\"{2}\" title=\"{4}\" class=\"{3}\" style=\"{0}\">{1}</div>",
                        MakeStyleFlow(), htmlcode, name, GetProperty("class"), title);
                    break;

                case PoiLayoutType.Group:
                    prefix = "<table width=\"100%\"><colgroup>";
                    for (int i = 0; i < cntcol; i++)
                        prefix += string.Format("<col width=\"{0}%\"></col>", 100.0 / cntcol);
                    prefix += "</colgroup><tr>";
                    suffix = "</tr></table>";
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
                            htmlcode += string.Format("<td name=\"{0}_{1}\" title=\"{2}_{3}\"></td>", name, i, title, i);
                            i++; continue;
                        }
                        htmlcode += string.Format("<td colspan=\"{0}\" name=\"{2}_{3}\" title=\"{4}_{5}\">{1}</td>", ele_list[i].rect.Width, ele_list[i].layout.htmlcode, name, i, title, i);
                        i += ele_list[i].rect.Width;
                    }
                    htmlcode = prefix + htmlcode + suffix;
                    htmlcode = string.Format("<div name=\"{2}\" title=\"{4}\" class=\"{3}\" style=\"{0}\">{1}</div>",
                        MakeStyleFlow(), htmlcode, name, GetProperty("class"), title);
                    break;

                case PoiLayoutType.Text: // format=("/biu-+_^><@...")
                    string textf = GetProperty("text_format"), textv = GetProperty("text_value");
                    if (textf.Length > 0 && textf[0] == '/') // hint
                        htmlcode = "<!--" + textv + "-->";
                    else
                    {
                        if (!property.ContainsKey("text_encode") || property["text_encode"] != "false")
                            textv = WebUtility.HtmlEncode(textv);
                        textv = string.Format("<span title=\"text\">{0}</span>", textv);
                        int pos = textf.IndexOf('@');
                        if (pos >= 0 && pos < textf.Length) // href
                        {
                            prefix += string.Format("<a title=\"href\" href=\"{0}\">", textf.Substring(pos + 1));
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
                        htmlcode = string.Format("<span name=\"{1}\" title=\"{3}\" class=\"{2}\">{0}</span>", htmlcode, name, GetProperty("class"), title);
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
                    prefix = string.Format("<table name=\"{0}\" title=\"{2}\" class=\"{1}\">", name, GetProperty("class"), title);
                    suffix = "</table>";
                    string thead = string.Format("<thead {0}><tr>", GetProperty("headpos"));
                    for (int i = 1; i <= cntcol;)
                    {
                        if (table[0, i] == null)
                        {
                            thead += string.Format("<th name=\"{0}_{1}_{2}\" title=\"{3}_{1}_{2}\"></th>", name, 0, i, title);
                            i++; continue;
                        }
                        thead += string.Format("<th colspan=\"{0}\" name=\"{2}_{3}_{4}\" title=\"{5}_{3}_{4}\">{1}</th>", table[0, i].rect.Width, table[0, i].layout.htmlcode, name, 0, i, title);
                        i += table[0, i].rect.Width;
                    }
                    thead += "</tr></thead>";
                    string tbody = string.Format("<tbody {0}>", GetProperty("bodypos"));
                    for (int i = 1; i <= cntrow; i++)
                    {
                        tbody += "<tr>";
                        for (int j = 1; j <= cntcol; j++)
                        {
                            if (occupy[i, j]) continue;
                            if (table[i, j] == null)
                            {
                                tbody += string.Format("<td name=\"{0}_{1}_{2}\" title=\"{3}_{1}_{2}\"></td>", name, i, j, title);
                                continue;
                            }
                            tbody += string.Format("<td rowspan=\"{0}\" colspan=\"{1}\" name=\"{3}_{4}_{5}\" title=\"{6}_{4}_{5}\">{2}</td>", table[i, j].rect.Height, table[i, j].rect.Width, table[i, j].layout.htmlcode, name, i, j, title);
                            for (int x = 0; x < table[i, j].rect.Height; x++)
                                for (int y = 0; y < table[i, j].rect.Width; y++)
                                    occupy[i + x, j + y] = true;
                        }
                        tbody += "</tr>";
                    }
                    tbody += "</tbody>";
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
                    htmlcode = string.Format("<input name=\"{0}\" title=\"{4}\" value=\"{1}\" class=\"{2}\" {3} />",
                        name, GetProperty("text"), GetProperty("class"), input, title);
                    break;

                case PoiLayoutType.Form:
                    string param = string.Format("action=\"{0}\" ", GetProperty("action"));
                    if (property.ContainsKey("method")) param += string.Format("method=\"{1}\" ", GetProperty("method"));
                    if (property.ContainsKey("enctype")) param += string.Format("enctype=\"{1}\" ", GetProperty("enctype"));
                    if (property.ContainsKey("target")) param += string.Format("target=\"{1}\" ", GetProperty("target"));
                    prefix = string.Format("<form name=\"{1}\" title=\"{2}\" class=\"{3}\" {0}>", param, name, title, GetProperty("class"));
                    suffix = "</form>";
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += element.layout.htmlcode;
                    }
                    htmlcode = prefix + htmlcode + suffix;
                    break;

                case PoiLayoutType.Image:
                    htmlcode = string.Format("<img src=\"{0}\" alt=\"{1}\" name=\"{2}\" title=\"{4}\" class=\"{3}\" />",
                        GetProperty("url"), GetProperty("text"), name, GetProperty("class"), title);
                    break;

                case PoiLayoutType.Part:
                    htmlcode = string.Format("<span title=\"text\">{0}</span>", GetProperty("text"));
                    foreach (PoiHtmlElement element in content)
                    {
                        element.layout.Generate();
                        htmlcode += element.layout.htmlcode;
                    }
                    htmlcode = string.Format("<{0} name=\"{2}\" title=\"{4}\" class=\"{3}\">{1}</{0}>",
                        GetProperty("type"), htmlcode, name, GetProperty("class"), title);
                    break;

                case PoiLayoutType.Single:
                    htmlcode = string.Format("<{0} name=\"{1}\" title=\"{3}\" class=\"{2}\" />",
                        GetProperty("type"), name, GetProperty("class"), title);
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
                    htmlcode = string.Format("<span title=\"text\">{0}</span>", GetProperty("text"));
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
                    htmlcode = string.Format("<button name=\"{1}\" title=\"{4}\" class=\"{2}\" {3}>{0}</button>",
                    htmlcode, name, GetProperty("class"), btn, title);
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
                    htmlcode = string.Format("<textarea name=\"{1}\" title=\"{3}\" class=\"{2}\" {3}>{0}</textarea>",
                    htmlcode, name, GetProperty("class"), area, title);
                    break;
                default:
                    break;
            }
        }

        // 静态添加子元素
        private void Add(List<string> data)
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

        // 动态添加全局子元素（根据name）
        private string AppendGlobal(List<string> data)
        {
            if (!Map.ContainsKey(data[0]))
                throw new PoiAnalyzeException("Struct.add: adding not existing element " + data[0]);
            PoiHtmlLayout child = Map[data[0]];
            int x, y, w, h;
            child.Generate(true);
            switch (this.type)
            {
                case PoiLayoutType.Page:
                    if (child.type != PoiLayoutType.Panel && child.type != PoiLayoutType.Grid)
                        throw new PoiAnalyzeException("Warning: Page只能包含Panel或Grid");
                    return string.Format("$(\"[name = '{0}']\").append('{1}')", name, child.htmlcode);

                case PoiLayoutType.Grid:
                    try
                    {
                        x = Convert.ToInt32(data[1]);
                        y = Convert.ToInt32(data[2]);
                        w = Convert.ToInt32(data[3]);
                        h = Convert.ToInt32(data[4]);
                    }
                    catch
                    {
                        throw new PoiAnalyzeException("Warning: " + name + "对象append方法参数不合法");
                    }
                    string pos_size = MakeStyleAbso(100.0 / cntcol * x, 100.0 / cntrow * y, 100.0 / cntcol * w, 100.0 / cntrow * h, "%");
                    return string.Format("$(\"[name = '{2}']\").append('<div style=\"{0}\">{1}</div>')", pos_size, child.htmlcode, name);

                case PoiLayoutType.Panel:
                    if (Convert.ToInt32(child.type) < Convert.ToInt32(PoiLayoutType.Panel))
                        throw new PoiAnalyzeException("Warning: Panel只能包含Panel, Group或HTML DOM类元素");
                    return string.Format("$(\"[name = '{0}']\").append('{1}')", name, child.htmlcode);

                case PoiLayoutType.Group:
                    if (child.type != PoiLayoutType.Panel)
                        throw new PoiAnalyzeException("Warning: Group只能包含Panel");
                    x = Convert.ToInt32(data[1]);
                    return string.Format("$(\"[name = '{0}_{1}']\").append('{2}')", name, x, child.htmlcode);

                case PoiLayoutType.Text:
                case PoiLayoutType.Form:
                case PoiLayoutType.Part:
                case PoiLayoutType.Script:
                case PoiLayoutType.Button:
                case PoiLayoutType.Textarea:
                    if (Convert.ToInt32(child.type) < Convert.ToInt32(PoiLayoutType.Panel))
                        throw new PoiAnalyzeException("Warning: " + type + "只能包含HTML DOM类元素");
                    return string.Format("$(\"[name = '{0}']\").append('{1}')", name, child.htmlcode);

                case PoiLayoutType.Table:
                    if (Convert.ToInt32(child.type) < Convert.ToInt32(PoiLayoutType.Panel))
                        throw new PoiAnalyzeException("Warning: " + type + "只能包含HTML DOM类元素");
                    x = Convert.ToInt32(data[1]);
                    y = Convert.ToInt32(data[2]);
                    return string.Format("$(\"[name = '{0}_{1}_{2}']\").append('{3}')", name, x, y, child.htmlcode);

                default:
                    throw new PoiAnalyzeException("Warning: Struct in type " + this.type + " doesn't have Append method.");
            }
        }

        // 动态添加局部子元素（根据title）
        private string AppendLocal(List<string> data)
        {
            if (!Map.ContainsKey(data[0]))
                throw new PoiAnalyzeException("Struct.add: adding not existing element " + data[0]);
            PoiHtmlLayout child = Map[data[0]];
            child.Generate(true);
            switch (this.type)
            {
                case PoiLayoutType.Page:
                    if (child.type != PoiLayoutType.Panel && child.type != PoiLayoutType.Grid)
                        throw new PoiAnalyzeException("Warning: Page只能包含Panel或Grid");
                    return string.Format("$(\"[title = '{0}']\").append('{1}')", MakeJSValue(name), child.htmlcode);

                case PoiLayoutType.Grid:
                    string pos_x = string.Format("100.0/{0}*({1})", cntcol, data[1]);
                    string pos_y = string.Format("100.0/{0}*({1})", cntrow, data[2]);
                    string pos_w = string.Format("100.0/{0}*({1})", cntcol, data[3]);
                    string pos_h = string.Format("100.0/{0}*({1})", cntrow, data[4]);
                    string pos_size = string.Format("position:absolute; left:\"+{0}+\"%; top:\"+{1}+\"%; width:\"+{2}+\"%; height:\"+{3}+\"%", pos_x, pos_y, pos_w, pos_h);
                    return string.Format("$(\"[title = '{2}']\").append('<div style=\"{0}\">{1}</div>')", pos_size, child.htmlcode, MakeJSValue(name));

                case PoiLayoutType.Panel:
                    if (Convert.ToInt32(child.type) < Convert.ToInt32(PoiLayoutType.Panel))
                        throw new PoiAnalyzeException("Warning: Panel只能包含Panel, Group或HTML DOM类元素");
                    return string.Format("$(\"[title = '{0}']\").append('{1}')", MakeJSValue(name), child.htmlcode);

                case PoiLayoutType.Group:
                    if (child.type != PoiLayoutType.Panel)
                        throw new PoiAnalyzeException("Warning: Group只能包含Panel");
                    return string.Format("$(\"[title = '{0}_{1}']\").append('{2}')", MakeJSValue(name), MakeJSValue(data[1]), child.htmlcode);

                case PoiLayoutType.Text:
                case PoiLayoutType.Form:
                case PoiLayoutType.Part:
                case PoiLayoutType.Script:
                case PoiLayoutType.Button:
                case PoiLayoutType.Textarea:
                    if (Convert.ToInt32(child.type) < Convert.ToInt32(PoiLayoutType.Panel))
                        throw new PoiAnalyzeException("Warning: " + type + "只能包含HTML DOM类元素");
                    return string.Format("$(\"[title = '{0}']\").append('{1}')", MakeJSValue(name), child.htmlcode);

                case PoiLayoutType.Table:
                    if (Convert.ToInt32(child.type) < Convert.ToInt32(PoiLayoutType.Panel))
                        throw new PoiAnalyzeException("Warning: " + type + "只能包含HTML DOM类元素");
                    return string.Format("$(\"[title = '{0}_{1}_{2}']\").append('{3}')", MakeJSValue(name), MakeJSValue(data[1]), MakeJSValue(data[2]), child.htmlcode);

                default:
                    throw new PoiAnalyzeException("Warning: Struct in type " + this.type + " doesn't have Append method.");
            }
        }

        // 动态清空全局子元素（根据name）
        private string ClearGlobal(List<string> data)
        {
            switch (this.type)
            {
                case PoiLayoutType.Group:
                    return string.Format("$(\"[name = '{0}_{1}']\").html('')", name, data[0]);
                case PoiLayoutType.Table:
                    return string.Format("$(\"[name = '{0}_{1}_{2}']\").html('')", name, data[0], data[1]);
                default:
                    return string.Format("$(\"[name = '{0}']\").html('')", name);
            }
        }

        // 动态清空局部子元素（根据title）
        private string ClearLocal(List<string> data)
        {
            switch (this.type)
            {
                case PoiLayoutType.Group:
                    return string.Format("$(\"[title = '{0}_{1}']\").html('')", MakeJSValue(name), MakeJSValue(data[0]));
                case PoiLayoutType.Table:
                    return string.Format("$(\"[title = '{0}_{1}_{2}']\").html('')", MakeJSValue(name), MakeJSValue(data[0]), MakeJSValue(data[1]));
                default:
                    return string.Format("$(\"[title = '{0}']\").html('')", MakeJSValue(name));
            }
        }

        // 动态查询或修改元素包含的文本
        private string OprText(List<string> data, string op)
        {
            string selector = GetSelector(op), text = GetOprData(data);
            switch (this.type)
            {
                case PoiLayoutType.Input:
                    return string.Format("$(\"{0}\").val({1})", selector, text);
                case PoiLayoutType.Text:
                case PoiLayoutType.Part:
                case PoiLayoutType.Button:
                    return string.Format("$(\"{0} [title='text']\").text({1})", selector, text);
                case PoiLayoutType.Textarea:
                    return string.Format("$(\"{0}\").text({1})", selector, text);
                default:
                    throw new PoiAnalyzeException("Warning: " + type + "类型不支持" + op + "方法");
            }
        }

        // 动态查询或修改Text的href, Image的src
        private string OprUrl(List<string> data, string op)
        {
            string attr;
            if (type == PoiLayoutType.Image) attr = "src";
            else if (type == PoiLayoutType.Text) attr = "href";
            else throw new PoiAnalyzeException("Warning: 只有Image和Text类型支持" + op + "方法");
            string selector = GetSelector(op), url = GetOprData(data);
            if (data.Count > 0) url = "," + url;
            return string.Format("$(\"{0}\").attr(\"{1}\"{2})", selector, attr, url);
        }

        // 动态更新Input, Button, Textarea的permission
        private string UpdatePerm(List<string> data, string op)
        {
            if (type != PoiLayoutType.Input && type != PoiLayoutType.Button && type != PoiLayoutType.Textarea)
                throw new PoiAnalyzeException("Warning: 只有Input,Button和Textarea类型支持" + op + "方法");
            string selector = GetSelector(op), perm = data.Count > 0 ? data[0] : "";
            string result = "";
            result += perm.Contains('x') ? string.Format("$(\"{0}\").attr('disabled','disabled')", selector) : string.Format("$(\"{0}\").removeAttr('disabled')", selector);
            result += perm.Contains('r') ? string.Format("$(\"{0}\").attr('readonly','readonly')", selector) : string.Format("$(\"{0}\").removeAttr('readonly')", selector);
            result += perm.Contains('q') ? string.Format("$(\"{0}\").attr('required',true)", selector) : string.Format("$(\"{0}\").removeAttr('required')", selector);
            result += perm.Contains('a') ? string.Format("$(\"{0}\").attr('autofocus',true)", selector) : string.Format("$(\"{0}\").removeAttr('autofocus')", selector);
            result += perm.Contains('c') ? string.Format("$(\"{0}\").attr('checked','checked')", selector) : string.Format("$(\"{0}\").removeAttr('checked')", selector);
            return result;
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

        private string MakeJSValue(string str)
        {
            return string.Format("\" + ({0}) + \"", str);
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

        private string GetSelector(string op)
        {
            string selector;
            if (op.StartsWith("g")) selector = string.Format("[name = '{0}']", name);
            else selector = string.Format("[title = '{0}']", MakeJSValue(name));
            return selector;
        }

        private string GetOprData(List<string> data)
        {
            return data.Count > 0 ? data[0] : "\"\"";
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
