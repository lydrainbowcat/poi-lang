﻿using System;
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

        private Dictionary<String, PoiType> variables = new Dictionary<string, PoiType>();

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

        public PoiType GetVariableType(String name)
        {
            if (variables.ContainsKey(name))
            {
                return variables[name];
            }
            return new PoiType(PoiVariableType.Undefined);
        }

        public void AddVariable(String name, PoiType type)
        {
            if (variables.ContainsKey(name))
            {
                PoiTypeChecker.AddWarning("Warning: Variable redefinition of variable: " + name + " and type: " + type.ToString());
                return;
            }
            variables.Add(name, type);
        }
    }

    class PoiAnalyzerScopeStack
    {
        private static Dictionary<String, PoiType> reservedVariables = new Dictionary<String, PoiType>()
        {
            { "ajax_request", new PoiType(PoiVariableType.Event) }
        };

        private List<PoiAnalyzerScope> scopeList = new List<PoiAnalyzerScope>();
        private List<KeyValuePair<String, PoiType>> variablesList = new List<KeyValuePair<string, PoiType>>();

        public PoiAnalyzerScopeStack()
        {
            Clear();
        }

        public void Clear()
        {
            scopeList.Clear();
            variablesList.Clear();
            scopeList.Add(new PoiAnalyzerScope("__global"));
            foreach (var item in reservedVariables)
            {
                DefiniteVariable(item.Key, item.Value);
            }
        }

        public void EnterScope(String name = null)
        {
            scopeList.Add(new PoiAnalyzerScope(name));
        }

        public void LeaveScope()
        {
            scopeList.RemoveAt(scopeList.Count - 1);
        }

        public void DefiniteVariable(String name, PoiType type)
        {
            scopeList.ElementAt(scopeList.Count - 1).AddVariable(name, type);
            variablesList.Add(new KeyValuePair<String, PoiType>(name, type));
        }

        public PoiType GetVariableType(String name)
        {
            for (int i = scopeList.Count - 1; i >= 0; i--)
            {
                PoiType type = scopeList[i].GetVariableType(name);
                if (type != PoiVariableType.Undefined)
                {
                    return type;
                }
            }
            return new PoiType(PoiVariableType.Undefined);
        }

        public List<KeyValuePair<String, PoiType>> GetVariableTypeInformation()
        {
            return variablesList;
        }
    }
}
