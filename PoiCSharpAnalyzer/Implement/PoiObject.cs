using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PoiLanguage
{
    public enum PoiObjectType
    {
        Null = 0,
        String = 1,
        Pair = 2,
        Array = 3,
        Struct = 4
    }

    public class PoiObject
    {
        public PoiObjectType Type { get; set; }
        public PoiVariableType VariableType { get; set; }
        private object Data;

        public PoiObject()
        {
            Type = PoiObjectType.Null;
            VariableType = PoiVariableType.Undefined;
            Data = new object();
        }

        public PoiObject(PoiObjectType type, object data, PoiVariableType variableType = PoiVariableType.Undefined)
        {
            Type = type;
            VariableType = variableType;
            Data = data;
        }

        public override string ToString()
        {
            if (Type == PoiObjectType.String)
                return Data as string;
            if (Type == PoiObjectType.Pair)
            {
                List<PoiObject> list = this.ToPair();
                return list.ToString();
            }
            if (Type == PoiObjectType.Array)
            {
                List<string> list = this.ToArray();
                return list.ToString();
            }
            if(Type == PoiObjectType.Struct)
            {
                List<KeyValuePair<string, string>> rec = this.ToStruct();
                return rec.ToString();
            }
            throw new PoiObjectException("Can't convert to a String");
        }

        public List<PoiObject> ToPair()
        {
            if (Type != PoiObjectType.Pair)
                throw new PoiObjectException("Not a Pair");
            try
            {
                return Data as List<PoiObject>;
            }
            catch(Exception)
            {
                throw new PoiObjectException("Not a valid Pair");
            }
        }

        public List<string> ToArray()
        {
            if (Type != PoiObjectType.Array)
                throw new PoiObjectException("Not an Array");
            try
            {
                return Data as List<string>;
            }
            catch(Exception)
            {
                throw new PoiObjectException("Not a valid Array");
            }
        }

        public List<KeyValuePair<string, string>> ToStruct()
        {
            if (Type != PoiObjectType.Struct)
                throw new PoiObjectException("Not a struct");
            try
            {
                return Data as List<KeyValuePair<string, string>>;
            }
            catch(Exception)
            {
                throw new PoiObjectException("Not a valid struct");
            }
        }

        public static PoiObject operator +(PoiObject a, PoiObject b)
        {
            if (a.Type == b.Type)
            {
                if (a.Type == PoiObjectType.String)
                    return new PoiObject(PoiObjectType.String, a.ToString() + b.ToString());
                if(a.Type == PoiObjectType.Struct)
                {
                    List<KeyValuePair<string, string>> rec = a.ToStruct();
                    foreach (KeyValuePair<string, string> pair in b.ToStruct())
                        rec.Add(pair);
                    return new PoiObject(PoiObjectType.Struct, rec);
                }
            }
            throw new PoiObjectException("Method not supported");
        }
    }

    public class PoiObjectException : Exception
    {
        public PoiObjectException() : base() { }
        public PoiObjectException(string msg) : base(msg) { }
        public PoiObjectException(string msg, Exception inner) : base(msg, inner) { }
    }

    public class PoiAnalyzeException : Exception
    {
        public PoiAnalyzeException() : base() { }
        public PoiAnalyzeException(string msg) : base(msg) { }
        public PoiAnalyzeException(string msg, Exception inner) : base(msg, inner) { }
    }
}
