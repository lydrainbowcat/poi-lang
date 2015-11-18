using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PoiLanguage
{
    class PoiAnalyzerScope
    {
        private String scopeIdentifier;

        public PoiAnalyzerScope(String identifier)
        {
            scopeIdentifier = identifier;
        }

        public String GetScope()
        {
            return scopeIdentifier;
        }
    }
}
