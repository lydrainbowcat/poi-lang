using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PerCederberg.Grammatica.Runtime;

namespace PoiLanguage
{
    class PoiArithmeticAnalyzer : PoiAnalyzer
    {
        public override Node ExitAdd(Token node)
        {
            node.AddValue(node.GetImage());
            return node;
        }
        public override Node ExitSub(Token node)
        {
            node.AddValue(node.GetImage());
            return node;
        }
        public override Node ExitMul(Token node)
        {
            node.AddValue(node.GetImage());
            return node;
        }
        public override Node ExitDiv(Token node)
        {
            node.AddValue(node.GetImage());
            return node;
        }
        public override Node ExitLeftParen(Token node)
        {
            node.AddValue(node.GetImage());
            return node;
        }
        public override Node ExitRightParen(Token node)
        {
            node.AddValue(node.GetImage());
            return node;
        }

        public override Node ExitNumber(Token node) 
        {
            node.AddValue(int.Parse(node.GetImage()));
            return node;
        }

        public override Node ExitExpression(Production node) 
        {
            ArrayList  values = GetChildValues(node);
            int        value1;
            int        value2;
            String     op;
            int        result;
        
            if (values.Count == 1)
            {
                result = (int)values[0];
            } 
            else 
            {
                value1 = (int)values[0];
                value2 = (int)values[2];
                op = (String)values[1];
                result = Operate(op, value1, value2);
            }
            node.AddValue((int)result);
            return node;
        }

        public override Node ExitExpressionTail(Production node) 
        {
            node.AddValues(GetChildValues(node));
            return node;
        }

        public override Node ExitTerm(Production node) 
        {
            ArrayList  values = GetChildValues(node);
            int        value1;
            int        value2;
            String     op;
            int        result;
        
            if (values.Count == 1) 
            {
                result = (int)values[0];
            } 
            else 
            {
                value1 = (int)values[0];
                value2 = (int)values[2];
                op = (String)values[1];
                result = Operate(op, value1, value2);
            }
            node.AddValue((int)result);
            return node;
        }

        public override Node ExitTermTail(Production node) 
        {
            node.AddValues(GetChildValues(node));
            return node;
        }

        public override Node ExitFactor(Production node) 
        {
            int  result;
        
            if (node.GetChildCount() == 1) 
            {
                result = GetIntValue(GetChildAt(node, 0), 0);
            } 
            else 
            {
                result = GetIntValue(GetChildAt(node, 1), 0);
            }
            node.AddValue((int)result);
            return node;
        }

        public override Node ExitAtom(Production node) 
        {
            node.AddValues(GetChildValues(node));
            return node;
        }

        private int Operate(String op, int value1, int value2)
        {
            switch (op)
            {
                case "+":
                    return value1 + value2;
                case "-":
                    return value1 - value2;
                case "*":
                    return value1 * value2;
                case "/":
                    return value1 / value2;
                default:
                    break;
            }

            return 0;
        }
    }
}
