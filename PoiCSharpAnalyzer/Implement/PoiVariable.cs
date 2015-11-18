using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PoiLanguage
{
    enum PoiVariableAccesser
    {
        Get = 0,
        Set = 1
    }
    class PoiVariable
    {
        public String Identifier {get; set;}
        public PoiAnalyzerScope Scope {get; set;}

        public PoiVariable()
        {
            Identifier = "";
        }

        public PoiVariable(String identifier, PoiAnalyzerScope scope)
        {
            Identifier = identifier;
            Scope = scope;
        }
    }
}
