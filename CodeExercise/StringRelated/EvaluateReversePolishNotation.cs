using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class EvaluateReversePolishNotation
    {
        /// <summary>
        /// 150. Evaluate Reverse Polish Notation
        /// http://interactivepython.org/runestone/static/pythonds/BasicDS/InfixPrefixandPostfixExpressions.html
        /// https://leetcode.com/problems/evaluate-reverse-polish-notation/
        /// 
        /// convert from "postfix expression"    "2 1 + 3 *"    
        /// 
        ///         to   "infix expression"      "(2+1) * 3"
        /// 
        /// Evaluate the value of an arithmetic expression in Reverse Polish Notation.
        /// 
        /// Valid operators are +, -, *, /. Each operand may be an integer or another expression.
        /// 
        /// Note:
        /// 
        /// Division between two integers should truncate toward zero.
        /// The given RPN expression is always valid. That means the expression would always evaluate to a result and there won't be any divide by zero operation.
        /// Example 1:
        /// 
        /// Input: ["2", "1", "+", "3", "*"]
        /// Output: 9
        /// Explanation: ((2 + 1) * 3) = 9
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public int EvalRPN(string[] tokens)
        {
            int len = tokens.Length;

            Stack<int> stk = new Stack<int>();
            int num;
            for (int i = 0; i < len; i++)
            {

                if (int.TryParse(tokens[i], out num))
                {
                    stk.Push(num);
                }
                else
                {
                    var v2 = stk.Pop();
                    var v1 = stk.Pop();

                    if (tokens[i] == "+")
                    {
                        stk.Push(v1 + v2);
                    }
                    else if (tokens[i] == "-")
                    {
                        stk.Push(v1 - v2);
                    }
                    else if (tokens[i] == "*")
                    {
                        stk.Push(v1 * v2);
                    }
                    else if (tokens[i] == "/")
                    {
                        stk.Push(v1 / v2);
                    }
                    else
                    {
                        Console.WriteLine("missing char");
                    }
                }
            }

            return stk.Pop();
        }
    }
}
