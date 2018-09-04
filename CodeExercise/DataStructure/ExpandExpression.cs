using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class ExpandExpression
    {
        /// <summary>
        /// lint 575
        /// 575. Decode String
        /// http://www.lintcode.com/en/problem/expression-expand/
        /// Given an expression s includes numbers, letters and brackets. Number represents the number of repetitions inside the brackets(can be a string or another expression)．Please expand expression to be a string.
        /// 
        /// s = abc3[a] return abcaaa
        /// s = 3[abc] return abcabcabc
        /// s = 4[ac]dy, return acacacacdy
        /// s = 3[2[ad]3[pf]]xyz, return adadpfpfpfadadpfpfpfadadpfpfpfxyz
        /// 
        /// sol:
        /// 把所有字符一个个放到 stack 里， 如果碰到了 ]，就从 stack 找到对应的字符串和重复次数，decode 之后再放回 stack 里
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ExpressionExpandSolver(string s)
        {
            Stack<char> stk = new Stack<char>();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                char c = s[i];
                if (c == ']')
                {                  
                    //(1) get pattern
                    string pattern = string.Empty;
                    while(stk.Peek() != '[')
                    {
                        pattern = stk.Pop() + pattern;
                    }

                    //(2) pop [
                    stk.Pop();  // pop '['

                    //(3) get repeat num, be careful  3[ab] case, need to check if stk empty; otherwise peek will fail
                    int repeat = 0;
                    int factor = 1;
                    while (stk.Count > 0 && char.IsDigit(stk.Peek()))
                    {
                        repeat = repeat + (stk.Pop() - '0') *factor;
                        factor *= 10;
                    }

                    // (4) put back to stk for outerloop repeat
                    while(repeat > 0)
                    {
                        for (int j = 0; j < pattern.Length; j++)
                        {
                            stk.Push(pattern[j]);
                        }
                        repeat--;
                    }
                }
                else
                {
                    // push everything besides ]
                    stk.Push(c);
                }
            }

            string ans = "";

            while(stk.Count >0)
            {
                ans = stk.Pop() + ans;
            }

            return ans;
        }

        public string ExpressionExpand_old(string s)
        {
            Stack<string> stk = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            int repeacCount = 0;

            foreach(char c in s)
            {
                if (Char.IsDigit(c))
                {
                    repeacCount = 10 * repeacCount + c - '0';
                }
                else if (c == '[')
                {
                    stk.Push(repeacCount.ToString());
                    repeacCount = 0;                       // YIC  reset to 0
                }
                else if (c == ']')          // 5[2[ab4[c]]]
                {
                    string str = stk.Pop();                     // c
                    int repeat = Convert.ToInt32(stk.Pop());    // 4

                    sb.Clear();     // yic reuse sb
                    while(repeat > 0)
                    {
                        sb.Append(str);
                        repeat--;
                    }
                    
                    // append with ab
                    if (stk.Count > 0)
                    {
                        string top = stk.Peek();
                        int dummy;
                        if (Int32.TryParse(top, out dummy) != true)    // apppend with pre str
                        {
                            top += sb.ToString();
                            stk.Pop();    // remove
                            stk.Push(top);
                        }
                        else
                        {
                            stk.Push(sb.ToString());         // pre str is a number. just put directly
                        }          
                    }
                    else
                    {
                        stk.Push(sb.ToString());
                    }
                    
                }
                else
                {
                    if (stk.Count > 0)
                    {
                        string top = stk.Peek();
                        int dummy;
                        if (Int32.TryParse(top, out dummy) != true)    // apppend with pre str
                        {
                            top += c;
                            stk.Pop();    // remove
                            stk.Push(top);
                        }
                        else
                        {
                            stk.Push(c.ToString());         // pre str is a number. just put directly
                        }
                    }
                    else
                    {
                        stk.Push(c.ToString());
                    }  
                }
            }

            return stk.Pop(); 
        }
    }
}
