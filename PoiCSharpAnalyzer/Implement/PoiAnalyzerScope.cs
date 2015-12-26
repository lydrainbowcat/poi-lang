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
        private const String DEFAULT_SCOPE_PREFIX = "__poi_analyzer_scope_";

        private static int scopeNumber = 0;
        private String scopeName;

        private Dictionary<String, PoiVariableType> variables = new Dictionary<string,PoiVariableType>();

        public PoiAnalyzerScope(String name = null)
        {
            if (name == null)
            {
                name = DEFAULT_SCOPE_PREFIX + (scopeNumber++).ToString();
            }
            scopeName = name;
        }

        public String GetScopeName()
        {
            return scopeName;
        }

        public PoiVariableType GetVariableType(String name)
        {
            if (variables.ContainsKey(name))
            {
                return variables[name];
            }
            return PoiVariableType.Undefined;
        }

        public void AddVariable(String name, PoiVariableType type)
        {
            if (variables.ContainsKey(name))
            {
                // throw "Variable redefinition" exception
                return;
            }
            variables.Add(name, type);
        }
    }

    class PoiAnalyzerScopeStack
    {
        private List<PoiAnalyzerScope> scopeList = new List<PoiAnalyzerScope>();
        private List<KeyValuePair<String, PoiVariableType>> variablesList = new List<KeyValuePair<string, PoiVariableType>>();

        public PoiAnalyzerScopeStack()
        {
            Clear();
        }

        public void Clear()
        {
            scopeList.Clear();
            scopeList.Add(new PoiAnalyzerScope("__global"));
        }

        public void EnterScope(String name = null)
        {
            scopeList.Add(new PoiAnalyzerScope(name));
        }

        public void LeaveScope()
        {
            scopeList.RemoveAt(scopeList.Count - 1);
        }

        public void DefiniteVariable(String name, PoiVariableType type)
        {
            scopeList.ElementAt(scopeList.Count - 1).AddVariable(name, type);
            variablesList.Add(new KeyValuePair<String, PoiVariableType>(name, type));
        }

        public PoiVariableType GetVariableType(String name)
        {
            for (int i = scopeList.Count - 1; i >= 0; i--)
            {
                PoiVariableType type = scopeList[i].GetVariableType(name);
                if (type != PoiVariableType.Undefined)
                {
                    return type;
                }
            }
            return PoiVariableType.Undefined;
        }

        public List<KeyValuePair<String, PoiVariableType>> GetVariableTypeInformation()
        {
            return variablesList;
        }
    }
}
