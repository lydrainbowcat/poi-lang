using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerCederberg.Grammatica.Runtime;

namespace PoiLanguage
{
    public class PoiInfo
    {
        public static void AddValuePos(Node node, object o, int pos = 0)
        {
            for (int i = node.Values.Count; i <= pos; i++) node.AddValue(new object());
            node.Values[pos] = o;
        }
    }
}
