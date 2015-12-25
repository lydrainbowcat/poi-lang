using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
        Pair
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

        public static PoiVariableType StringToVariableType(String type)
        {
            if (stringVariableTypeMap.ContainsKey(type))
            {
                return stringVariableTypeMap[type];
            }
            return PoiVariableType.Undefined;
        }

        public static PoiVariableType GetArithmeticExpressionType(PoiExpressionType expr, String op, List<PoiVariableType> variables)
        {
            try
            {
                PoiOperationType operation = expressionOperationMap[expr][op];

                Dictionary<List<PoiVariableType>, PoiVariableType> availableOperations = arithmeticOperationMap[operation];
                // try direct matching
                foreach (var item in availableOperations)
                {
                    if (DirectMatch(variables, item.Key))
                    {
                        return item.Value;
                    }
                }

                // try cast matching
                foreach (var item in availableOperations)
                {
                    if (CastMatch(variables, item.Key))
                    {
                        return item.Value;
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                return PoiVariableType.Undefined;
            }

            //throw new PoiTypeException("Operation not defined: [" + op + "] with parameters [" + variables.ToString() + "]");
            return PoiVariableType.Undefined;
        }

        public static bool CheckAssign(PoiVariableType left, PoiVariableType right)
        {
            return AvailableCast(right, left);
        }

        private static bool DirectMatch(List<PoiVariableType> from, List<PoiVariableType> to)
        {
            return from.SequenceEqual(to);
        }

        private static bool CastMatch(List<PoiVariableType> from, List<PoiVariableType> to)
        {
            if (from.Count != to.Count)
            {
                return false;
            }

            int matchNum = 0;
            for (int i = 0; i < from.Count; i++, matchNum++)
            {
                if (!AvailableCast(from[i], to[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool AvailableCast(PoiVariableType from, PoiVariableType to)
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

            //throw new PoiTypeException("Can not cast from type: [" + from.ToString() + "] to type: [" + to.ToString() + "]");
            return false;
        }
    };

    public class PoiTypeException : PoiAnalyzeException
    {
        public PoiTypeException() : base() { }
        public PoiTypeException(string msg) : base(msg) { }
        public PoiTypeException(string msg, Exception inner) : base(msg, inner) { }
    }
}
