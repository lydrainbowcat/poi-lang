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
        LogicalOr,
    }

    public class PoiType
    {
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

        private static Dictionary<PoiOperationType, Dictionary<List<PoiVariableType>, PoiVariableType>> operationVariableMap = new Dictionary<PoiOperationType, Dictionary<List<PoiVariableType>, PoiVariableType>>
        {
            { PoiOperationType.UnaryAdd,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8 }, PoiVariableType.Integer8 },
                    { new List<PoiVariableType> { PoiVariableType.Integer16 }, PoiVariableType.Integer16 },
                    { new List<PoiVariableType> { PoiVariableType.Integer32 }, PoiVariableType.Integer32 },
                    { new List<PoiVariableType> { PoiVariableType.Integer64 }, PoiVariableType.Integer64 },
                }
            },
            { PoiOperationType.AddSubAdd,
                new Dictionary<List<PoiVariableType>, PoiVariableType>
                {
                    { new List<PoiVariableType> { PoiVariableType.Integer8, PoiVariableType.Integer8 }, PoiVariableType.Integer8 }
                }
            }
        };

        public static PoiVariableType GetArithmeticExpressionType(PoiExpressionType expr, String op, List<PoiVariableType> variables)
        {
            try
            {
                PoiOperationType operation = expressionOperationMap[expr][op];

                Dictionary<List<PoiVariableType>, PoiVariableType> availableOperations = operationVariableMap[operation];
                foreach (var item in availableOperations)
                {
                    if (item.Key.SequenceEqual(variables))
                    {
                        return item.Value;
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                return PoiVariableType.Undefined;
            }

            return PoiVariableType.Undefined;
        }
    };
}
