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
        Pair = 2
    }

    public class PoiObject
    {
        public PoiObjectType Type { get; set; }
        private object Data;

        public PoiObject()
        {
            Type = PoiObjectType.Null;
            Data = new object();
        }

        public PoiObject(PoiObjectType type, object data)
        {
            Type = type;
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
                throw new PoiObjectException("Not a Valid Pair");
            }
        }

        public static PoiObject operator +(PoiObject a, PoiObject b)
        {
            if (a.Type == b.Type)
            {
                if (a.Type == PoiObjectType.String)
                    return new PoiObject(PoiObjectType.String, a.ToString() + b.ToString());
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
