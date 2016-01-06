using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PerCederberg.Grammatica.Runtime;

namespace PoiLanguage
{
    public enum PoiVariableType
    {
        Undefined = 0,
        Integer8,
        Integer16,
        Integer32,
        Integer64,
        UInteger8,
        UInteger16,
        UInteger32,
        UInteger64,
        Single,
        Double,
        Extended,
        Boolean,
        Character,
        String,
        Array,
        Map,
        Event,
        Function,
        Pair,
        Struct
    }

    public enum PoiExpressionType
    {
        Undefined = 0,
        UnaryExpression,
        MulDivModExpression,
        AddSubExpression,
        ShiftExpression,
        RelationalExpression,
        EqualityExpression,
        BitAndExpression,
        BitXorExpression,
        BitOrExpression,
        LogicalAndExpression,
        LogicalOrExpression,
        ConditionExpression,
        ArithmeticExpression
    }

    public enum PoiOperationType
    {
        Undefined = 0,
        UnaryAdd,
        UnarySub,
        UnaryLogicNot,
        UnaryBitNot,
        UnaryInc,
        UnaryDec,
        MulDivModMul,
        MulDivModDiv,
        MulDivModMod,
        AddSubAdd,
        AddSubSub,
        ShiftShiftLeft,
        ShiftShiftRight,
        RelationalLess,
        RelationalGreater,
        RelationalLessEqual,
        RelationalGreaterEqual,
        EqualityUnequal,
        EqualityEqual,
        BitAnd,
        BitXor,
        BitOr,
        LogicalAnd,
        LogicalOr
    }

    public class PoiType
    {
        private PoiVariableType basicType;
        private object additionalInfo;

        public PoiType(PoiVariableType variableType, object additional = null)
        {
            basicType = variableType;
            additionalInfo = additional;
        }

        public PoiVariableType GetBasicType()
        {
            return basicType;
        }

        public PoiType GetArrayType()
        {
            if (basicType != PoiVariableType.Array || additionalInfo == null)
            {
                return new PoiType(PoiVariableType.Undefined);
            }
            return ((KeyValuePair<PoiType, List<int>>)additionalInfo).Key;
        }

        public List<int> GetArraySizes()
        {
            if (basicType != PoiVariableType.Array || additionalInfo == null)
            {
                return new List<int>();
            }
            return ((KeyValuePair<PoiType, List<int>>)additionalInfo).Value;
        }

        public List<PoiType> GetFunctionParameters()
        {
            if (basicType != PoiVariableType.Function || additionalInfo == null)
            {
                return new List<PoiType>();
            }
            return (List<PoiType>)additionalInfo;
        }

        public List<PoiType> GetEventParameters()
        {
            if (basicType != PoiVariableType.Event || additionalInfo == null)
            {
                return new List<PoiType>();
            }
            return (List<PoiType>)additionalInfo;
        }

        public static bool operator ==(PoiType variable, PoiVariableType type)
        {
            return variable.basicType == type;
        }

        public static bool operator !=(PoiType variable, PoiVariableType type)
        {
            return variable.basicType != type;
        }

        public override string ToString()
        {
            string typeString = basicType.ToString();
            switch (basicType)
            {
                case PoiVariableType.Array:
                    typeString += "[" + GetArrayType().ToString() + "," + string.Join(",", GetArraySizes()) + "]";
                    break;
                case PoiVariableType.Function:
                    break;
                case PoiVariableType.Event:
                    break;
                default:
                    break;
            }
            return typeString;
        }
    }

    public class PoiTypeChecker
    {
        private static Dictionary<String, PoiVariableType> stringVariableTypeMap = new Dictionary<string, PoiVariableType>
        {
            { "int8", PoiVariableType.Integer8 },
            { "byte", PoiVariableType.Integer8 },
            { "int16", PoiVariableType.Integer16 },
            { "short", PoiVariableType.Integer16 },
            { "int32", PoiVariableType.Integer32 },
            { "int", PoiVariableType.Integer32 },
            { "int64", PoiVariableType.Integer64 },
            { "long", PoiVariableType.Integer64 },
            { "uint8", PoiVariableType.UInteger8 },
            { "ubyte", PoiVariableType.UInteger8 },
            { "uint16", PoiVariableType.UInteger16 },
            { "ushort", PoiVariableType.UInteger16 },
            { "uint32", PoiVariableType.UInteger32 },
            { "uint", PoiVariableType.UInteger32 },
            { "uint64", PoiVariableType.UInteger64 },
            { "ulong", PoiVariableType.UInteger64 },
            { "single", PoiVariableType.Single },
            { "float", PoiVariableType.Single },
            { "double", PoiVariableType.Double },
            { "extended", PoiVariableType.Extended },
            { "boolean", PoiVariableType.Boolean },
            { "bool", PoiVariableType.Boolean },
            { "function", PoiVariableType.Function },
            { "char", PoiVariableType.Character },
            { "string", PoiVariableType.String },
            { "array", PoiVariableType.Array },
            { "map", PoiVariableType.Map },
            { "event", PoiVariableType.Event }
        };

        private static Dictionary<PoiExpressionType, Dictionary<String, PoiOperationType>> expressionOperationMap = new Dictionary<PoiExpressionType, Dictionary<String, PoiOperationType>>
        {
            { PoiExpressionType.UnaryExpression, 
                new Dictionary <String, PoiOperationType> 
                {
                    { "+", PoiOperationType.UnaryAdd },
                    { "-", PoiOperationType.UnarySub },
                    { "!", PoiOperationType.UnaryLogicNot },
                    { "~", PoiOperationType.UnaryBitNot },
                    { "++", PoiOperationType.UnaryInc },
                    { "--", PoiOperationType.UnaryDec }
                }
            },
            { PoiExpressionType.MulDivModExpression, 
                new Dictionary <String, PoiOperationType> 
                {
                    { "*", PoiOperationType.MulDivModMul },
                    { "/", PoiOperationType.MulDivModDiv },
                    { "%", PoiOperationType.MulDivModMod }
                }
            },
            { PoiExpressionType.AddSubExpression,
                new Dictionary <String, PoiOperationType>
                {
                    { "+", PoiOperationType.AddSubAdd },
                    { "-", PoiOperationType.AddSubSub }
                }
            },
            { PoiExpressionType.ShiftExpression,
                new Dictionary <String, PoiOperationType>
                {
                    { "<<", PoiOperationType.ShiftShiftLeft },
                    { ">>", PoiOperationType.ShiftShiftRight }
                }
            },
            { PoiExpressionType.RelationalExpression,
                new Dictionary <String, PoiOperationType>
                {
                    { "<", PoiOperationType.RelationalLess },
                    { ">", PoiOperationType.RelationalGreater },
                    { "<=", PoiOperationType.RelationalLessEqual },
                    { ">=", PoiOperationType.RelationalGreaterEqual }
                }
            },
            { PoiExpressionType.EqualityExpression,
                new Dictionary <String, PoiOperationType>
                {
                    { "==", PoiOperationType.EqualityEqual },
                    { "!=", PoiOperationType.EqualityUnequal }
                }
            },
            { PoiExpressionType.BitAndExpression,
                new Dictionary <String, PoiOperationType>
                {
                    { "&", PoiOperationType.BitAnd }
                }
            },
            { PoiExpressionType.BitXorExpression,
                new Dictionary <String, PoiOperationType>
                {
                    { "^", PoiOperationType.BitXor }
                }
            },
            { PoiExpressionType.BitOrExpression,
                new Dictionary <String, PoiOperationType>
                {
                    { "|", PoiOperationType.BitOr }
                }
            },
            { PoiExpressionType.LogicalAndExpression,
                new Dictionary <String, PoiOperationType>
                {
                    { "&&", PoiOperationType.LogicalAnd }
                }
            },
            { PoiExpressionType.LogicalOrExpression,
                new Dictionary <String, PoiOperationType>
                {
                    { "||", PoiOperationType.LogicalOr }
                }
            },
            { PoiExpressionType.ConditionExpression,
                new Dictionary <String, PoiOperationType>
                {
                }
            },
            { PoiExpressionType.ArithmeticExpression,
                new Dictionary <String, PoiOperationType>
                {
                }
            }
        };

        private static Dictionary<PoiOperationType, Dictionary<List<PoiVariableType>, PoiVariableType>> arithmeticOperationMap = new Dictionary<PoiOperationType, Dictionary<List<PoiVariableType>, PoiVariableType>>
        {
            { PoiOperationType.UnaryAdd,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended }, PoiVariableType.Extended },
                    { new List<PoiVariableType> { PoiVariableType.Character }, PoiVariableType.Integer8 }
                }
            },
            { PoiOperationType.UnarySub,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended }, PoiVariableType.Extended },
                    { new List<PoiVariableType> { PoiVariableType.Character }, PoiVariableType.Integer8 }
                }
            },
            { PoiOperationType.UnaryLogicNot,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Boolean }, PoiVariableType.Boolean }
                }
            },
            { PoiOperationType.UnaryBitNot,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended }, PoiVariableType.Extended },
                    { new List<PoiVariableType> { PoiVariableType.Character }, PoiVariableType.Integer8 }
                }
            },
            { PoiOperationType.UnaryInc,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended }, PoiVariableType.Extended },
                    { new List<PoiVariableType> { PoiVariableType.Character }, PoiVariableType.Integer8 }
                }
            },
            { PoiOperationType.UnaryDec,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended }, PoiVariableType.Extended },
                    { new List<PoiVariableType> { PoiVariableType.Character }, PoiVariableType.Integer8 }
                }
            },  
            { PoiOperationType.MulDivModMul,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Extended }
                }
            },  
            { PoiOperationType.MulDivModDiv,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Extended }
                }
            },  
            { PoiOperationType.MulDivModMod,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Extended }
                }
            },  
            { PoiOperationType.AddSubAdd,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Extended },
                    { new List<PoiVariableType> { PoiVariableType.String, PoiVariableType.String }, PoiVariableType.String }
                }
            },  
            { PoiOperationType.AddSubSub,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Single },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Double },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Extended }
                }
            },  
            { PoiOperationType.ShiftShiftLeft,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer32 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer32 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer32 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.Integer32 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.Integer32 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.Integer32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.Integer32 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.UInteger32 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.UInteger32 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.UInteger32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.UInteger32 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger32 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger32 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger32 }, PoiVariableType.UInteger64 }
                }
            },  
            { PoiOperationType.ShiftShiftRight,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer32 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer32 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer32 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.Integer32 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.Integer32 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.Integer32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.Integer32 }, PoiVariableType.UInteger64 },
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.UInteger32 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.UInteger32 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.UInteger32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.UInteger32 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger32 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger32 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger32 }, PoiVariableType.UInteger64 }
                }
            },  
            { PoiOperationType.RelationalLess,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Boolean, PoiVariableType.Boolean }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Character, PoiVariableType.Character }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.String, PoiVariableType.String }, PoiVariableType.Boolean }
                }
            },  
            { PoiOperationType.RelationalGreater,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Boolean, PoiVariableType.Boolean }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Character, PoiVariableType.Character }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.String, PoiVariableType.String }, PoiVariableType.Boolean }
                }
            },  
            { PoiOperationType.RelationalLessEqual,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Boolean, PoiVariableType.Boolean }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Character, PoiVariableType.Character }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.String, PoiVariableType.String }, PoiVariableType.Boolean }
                }
            },  
            { PoiOperationType.RelationalGreaterEqual,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Boolean, PoiVariableType.Boolean }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Character, PoiVariableType.Character }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.String, PoiVariableType.String }, PoiVariableType.Boolean }
                }
            },  
            { PoiOperationType.EqualityUnequal,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Boolean, PoiVariableType.Boolean }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Character, PoiVariableType.Character }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.String, PoiVariableType.String }, PoiVariableType.Boolean }
                }
            },  
            { PoiOperationType.EqualityEqual,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Single, PoiVariableType.Single }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Double, PoiVariableType.Double }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Extended, PoiVariableType.Extended }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Boolean, PoiVariableType.Boolean }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.Character, PoiVariableType.Character }, PoiVariableType.Boolean },
                    { new List<PoiVariableType> { PoiVariableType.String, PoiVariableType.String }, PoiVariableType.Boolean }
                }
            },
            { PoiOperationType.BitAnd,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 }
                }
            },
            { PoiOperationType.BitXor,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 }
                }
            },
            { PoiOperationType.BitOr,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16, PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32, PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64, PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger8, PoiVariableType.UInteger8 }, PoiVariableType.UInteger8 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger16, PoiVariableType.UInteger16 }, PoiVariableType.UInteger16 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger32, PoiVariableType.UInteger32 }, PoiVariableType.UInteger32 },
                    { new List<PoiVariableType> { PoiVariableType.UInteger64, PoiVariableType.UInteger64 }, PoiVariableType.UInteger64 }
                }
            },
            { PoiOperationType.LogicalAnd,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Boolean, PoiVariableType.Boolean }, PoiVariableType.Boolean }
                }
            },
            { PoiOperationType.LogicalOr,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Boolean, PoiVariableType.Boolean }, PoiVariableType.Boolean }
                }
            }
        };

        private static Dictionary<PoiVariableType, List<PoiVariableType>> variableCastMap = new Dictionary<PoiVariableType, List<PoiVariableType>>
        {
            { PoiVariableType.Undefined,
                new List<PoiVariableType>
                {
                    PoiVariableType.Undefined
                }
            },
            { PoiVariableType.Integer8, 
                new List<PoiVariableType> 
                {
                    PoiVariableType.Integer8,
                    PoiVariableType.Integer16,
                    PoiVariableType.Integer32,
                    PoiVariableType.Integer64,
                    PoiVariableType.UInteger16,
                    PoiVariableType.UInteger32,
                    PoiVariableType.UInteger64,
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.Integer16,
                new List<PoiVariableType>
                {
                    PoiVariableType.Integer16,
                    PoiVariableType.Integer32,
                    PoiVariableType.Integer64,
                    PoiVariableType.UInteger32,
                    PoiVariableType.UInteger64,
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.Integer32,
                new List<PoiVariableType>
                {
                    PoiVariableType.Integer32,
                    PoiVariableType.Integer64,
                    PoiVariableType.UInteger64,
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.Integer64,
                new List<PoiVariableType>
                {
                    PoiVariableType.Integer64,
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.UInteger8, 
                new List<PoiVariableType> 
                {
                    PoiVariableType.Integer16,
                    PoiVariableType.Integer32,
                    PoiVariableType.Integer64,
                    PoiVariableType.UInteger8,
                    PoiVariableType.UInteger16,
                    PoiVariableType.UInteger32,
                    PoiVariableType.UInteger64,
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.UInteger16,
                new List<PoiVariableType>
                {
                    PoiVariableType.Integer32,
                    PoiVariableType.Integer64,
                    PoiVariableType.UInteger16,
                    PoiVariableType.UInteger32,
                    PoiVariableType.UInteger64,
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.UInteger32,
                new List<PoiVariableType>
                {
                    PoiVariableType.Integer64,
                    PoiVariableType.UInteger32,
                    PoiVariableType.UInteger64,
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.UInteger64,
                new List<PoiVariableType>
                {
                    PoiVariableType.UInteger64,
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.Single,
                new List<PoiVariableType>
                {
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.Double,
                new List<PoiVariableType>
                {
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.Extended,
                new List<PoiVariableType>
                {
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.Boolean,
                new List<PoiVariableType>
                {
                    PoiVariableType.Boolean
                }
            },
            { PoiVariableType.Character,
                new List<PoiVariableType>
                {
                    PoiVariableType.Integer8,
                    PoiVariableType.Integer16,
                    PoiVariableType.Integer32,
                    PoiVariableType.Integer64,
                    PoiVariableType.UInteger8,
                    PoiVariableType.UInteger16,
                    PoiVariableType.UInteger32,
                    PoiVariableType.UInteger64,
                    PoiVariableType.Single,
                    PoiVariableType.Double,
                    PoiVariableType.Extended
                }
            },
            { PoiVariableType.String,
                new List<PoiVariableType>
                {
                    PoiVariableType.String
                }
            },
            { PoiVariableType.Array,
                new List<PoiVariableType>
                {
                    PoiVariableType.Array
                }
            },
            { PoiVariableType.Map,
                new List<PoiVariableType>
                {
                    PoiVariableType.Map
                }
            },
            { PoiVariableType.Event,
                new List<PoiVariableType>
                {
                    PoiVariableType.Event
                }
            },
            { PoiVariableType.Function,
                new List<PoiVariableType>
                {
                    PoiVariableType.Function
                }
            },
            { PoiVariableType.Pair,
                new List<PoiVariableType>
                {
                    PoiVariableType.Pair
                }
            }
        };

        private static Dictionary<PoiVariableType, String> variableDefaultInitializer = new Dictionary<PoiVariableType,string>
        {
            { PoiVariableType.Undefined, "" },
            { PoiVariableType.Integer8, "= 0" },
            { PoiVariableType.Integer16, "= 0" },
            { PoiVariableType.Integer32, "= 0" },
            { PoiVariableType.Integer64, "= 0" },
            { PoiVariableType.UInteger8, "= 0" },
            { PoiVariableType.UInteger16, "= 0" },
            { PoiVariableType.UInteger32, "= 0" },
            { PoiVariableType.UInteger64, "= 0" },
            { PoiVariableType.Single, "= 0.0" },
            { PoiVariableType.Double, "= 0.0" },
            { PoiVariableType.Extended, "= 0.0" },
            { PoiVariableType.Boolean, "= false" },
            { PoiVariableType.Function, "= @[] -> [] {}" },
            { PoiVariableType.Character, "= 'a'" },
            { PoiVariableType.String, "= \"\"" },
            { PoiVariableType.Array, "" },
            { PoiVariableType.Map, "= new Object()" },
            { PoiVariableType.Event, "= new Event()" }
        };

        private static List<string> warnings = new List<string>();

        public static PoiVariableType StringToPoiVariableType(Node node, String type)
        {
            if (stringVariableTypeMap.ContainsKey(type))
            {
                return stringVariableTypeMap[type];
            }
            return PoiVariableType.Undefined;
        }

        public static PoiVariableType GetArithmeticExpressionType(Node node, PoiExpressionType expr, String op, List<PoiType> variablesList)
        {
            List<PoiVariableType> variables;
            try
            {
                PoiOperationType operation = expressionOperationMap[expr][op];
                variables = variablesList.ConvertAll(
                    new Converter<PoiType, PoiVariableType>(delegate(PoiType variable)
                        {
                            return variable.GetBasicType();
                        }));

                Dictionary<List<PoiVariableType>, PoiVariableType> availableOperations = arithmeticOperationMap[operation];
                // try direct matching
                foreach (var item in availableOperations)
                {
                    if (DirectMatch(node, variables, item.Key))
                    {
                        return item.Value;
                    }
                }

                // try cast matching
                foreach (var item in availableOperations)
                {
                    if (CastMatch(node, variables, item.Key))
                    {
                        return item.Value;
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                return PoiVariableType.Undefined;
            }

            AddWarning(node, "Operation not defined: [" + op + "] with parameters [" + string.Join(",", variables) + "]");
            return PoiVariableType.Undefined;
        }

        public static bool CheckAssign(Node node, PoiType left, PoiType right)
        {
            if (!AvailableCastNoWarnings(right.GetBasicType(), left.GetBasicType()))
            {
                AddWarning(node, "Can't assign type: " + left.ToString() + " to type: " + right.ToString());
                return false;
            }
            return true;
        }

        private static bool DirectMatch(Node node, List<PoiVariableType> from, List<PoiVariableType> to)
        {
            return from.SequenceEqual(to);
        }

        private static bool CastMatch(Node node, List<PoiVariableType> from, List<PoiVariableType> to)
        {
            if (from.Count != to.Count)
            {
                return false;
            }

            int matchNum = 0;
            for (int i = 0; i < from.Count; i++, matchNum++)
            {
                if (!AvailableCastNoWarnings(from[i], to[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool AvailableCast(Node node, PoiVariableType from, PoiVariableType to)
        {
            try
            {
                if (variableCastMap[from].Contains(to))
                {
                    return true;
                }
            }
            catch (KeyNotFoundException)
            {
                return false;
            }

            AddWarning(node, "Trying cast from type: [" + from.ToString() + "] to type: [" + to.ToString() + "]");
            return false;
        }

        private static bool AvailableCastNoWarnings(PoiVariableType from, PoiVariableType to)
        {
            try
            {
                if (variableCastMap[from].Contains(to))
                {
                    return true;
                }
            }
            catch (KeyNotFoundException)
            {
                return false;
            }

            return false;
        }

        public static String GetDefaultInitializer(Node node, PoiType type)
        {
            return variableDefaultInitializer[type.GetBasicType()];
        }

        public static void AddWarning(Node node, string warn)
        {
            string warningStr = "WARNING: " +
                (node != null ? "From [Line " + node.GetStartLine() + ", Column " + node.GetStartColumn() + "] to [Line " +
                node.GetEndLine() + ", Column " + node.GetEndColumn() + "]: " : "") +
                warn;
            warnings.Add(warningStr);
        }

        public static void ClearWarnings()
        {
            warnings.Clear();
        }

        public static List<string> GetWarnings()
        {
            return warnings;
        }
    };

    public class PoiTypeException : PoiAnalyzeException
    {
        public PoiTypeException() : base() { }
        public PoiTypeException(string msg) : base(msg) { }
        public PoiTypeException(string msg, Exception inner) : base(msg, inner) { }
    }
}
