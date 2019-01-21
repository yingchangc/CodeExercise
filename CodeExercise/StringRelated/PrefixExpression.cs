using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    // Zillow
    class PrefixExpression
    {
        /// <summary>
        /// http://interactivepython.org/runestone/static/pythonds/BasicDS/InfixPrefixandPostfixExpressions.html
        /// Zillow
        /// 
        /// convert from "prefix expression"     * + A B C    
        /// 
        ///         to   "infix expression"     (A + B) * C
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public string ComputePrfixExpression(string expr)
        {
            Stack<string> stk = new Stack<string>();
            bool hasNum = false;
            foreach(char c in expr)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    if (hasNum)
                    {
                        var v1 = stk.Pop();
                        var op = stk.Pop();
                        stk.Push("(" + v1 + op + c + ")");
                        hasNum = true;
                    }
                    else
                    {
                        stk.Push(c.ToString());
                        hasNum = true;
                    }
                }
                else
                {
                    stk.Push(c.ToString());
                    hasNum = false;
                }
            }

            while(stk.Count > 1)
            {
                var v2 = stk.Pop();
                var v1 = stk.Pop();
                var op = stk.Pop();

                stk.Push("(" + v1 + op + v2 + ")");

            }

            return stk.Pop();
        }
    }
}
