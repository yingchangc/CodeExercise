using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class BasicCalculator
    {
        /// <summary>
        /// 224. Basic Calculator
        /// https://leetcode.com/problems/basic-calculator/submissions/
        /// Implement a basic calculator to evaluate a simple expression string.
        /// 
        /// The expression string may contain open(and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces.
        /// 
        ///       Example 1:
        /// 
        /// Input: "1 + 1"
        /// Output: 2
        /// Example 2:
        /// 
        /// Input: " 2-1 + 2 "
        /// Output: 3
        /// Example 3:
        /// 
        /// Input: "(1+(4+5+2)-3)+(6+8)"
        /// Output: 23
        /// 
        /// sol:
        /// use preSign
        ///     res 
        ///     and num
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            int sign = 1;
            int num = 0;
            int res = 0;
            var stk = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    num = num * 10 + s[i] - '0';
                }
                else if (s[i] == '+')
                {
                    res += (sign) * num;
                    sign = 1;
                    num = 0;
                }
                else if (s[i] == '-')
                {
                    res += (sign) * num;
                    sign = -1;
                    num = 0;
                }
                else if (s[i] == '(')
                {
                    stk.Push(res);
                    stk.Push(sign);
                    res = 0;
                    sign = 1;
                }
                else if (s[i] == ')')
                {
                    res += (sign) * num;
                    sign = 1;
                    num = 0;

                    var preSign = stk.Pop();
                    var preRes = stk.Pop();

                    res = preRes + res * preSign;
                }
            }


            // last number
            res += (sign) * num;
            return res;

        }


        /// <summary>
        /// 227. Basic Calculator II
        /// https://leetcode.com/problems/basic-calculator-ii/
        /// Implement a basic calculator to evaluate a simple expression string.
        /// 
        /// The expression string contains only non-negative integers, +, -, *, / operators and empty spaces.The integer division should truncate toward zero.
        /// 
        /// 
        /// Example 1:
        /// 
        /// 
        /// Input: "3+2*2"
        /// Output: 7
        /// 
        /// sol: 
        /// use preSign
        /// and num = 0;
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate2(string s)
        {
            char preSign = '+';
            int num = 0;

            var stk = new Stack<int>();

            int len = s.Length;

            for (int i = 0; i < len; i++)
            {
                char c = s[i];
                if (Char.IsDigit(c))
                {
                    num = num * 10 + c - '0';
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    if (preSign == '+')
                    {
                        stk.Push(num);
                    }
                    else if (preSign == '-')
                    {
                        stk.Push(-1 * num);
                    }
                    else if (preSign == '*')
                    {
                        var v1 = stk.Pop();
                        var nV = v1 * num;
                        stk.Push(nV);
                    }
                    else
                    {
                        var v1 = stk.Pop();
                        var nV = v1 / num;
                        stk.Push(nV);
                    }

                    num = 0;
                    preSign = c;
                }
            }

            // handle last number
            if (preSign == '+')
            {
                stk.Push(num);
            }
            else if (preSign == '-')
            {
                stk.Push(-1 * num);
            }
            else if (preSign == '*')
            {
                var v1 = stk.Pop();
                var nV = v1 * num;
                stk.Push(nV);
            }
            else
            {
                var v1 = stk.Pop();
                var nV = v1 / num;
                stk.Push(nV);
            }


            int ans = 0;
            while (stk.Count > 0)
            {
                ans += stk.Pop();
            }

            return ans;

        }
    }
}
