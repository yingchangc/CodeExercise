using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class RemoveInvalidParentheses
    {
        /// <summary>
        /// 20. Valid Parentheses
        /// https://leetcode.com/problems/valid-parentheses/description/
        /// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        /// 
        /// An input string is valid if:
        /// 
        /// Open brackets must be closed by the same type of brackets.
        /// Open brackets must be closed in the correct order.
        /// Note that an empty string is also considered valid.
        /// 
        /// Example 1:
        /// 
        /// Input: "()"
        /// Output: true
        /// Example 2:
        /// 
        /// Input: "()[]{}"
        /// Output: true
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            Stack<char> stk = new Stack<char>();

            foreach(char c in s)
            {
                switch(c)
                {
                    case '(':
                    case '[':
                    case '{':
                        stk.Push(c);
                        break;
                    case ')':
                    case ']':
                    case '}':
                        if (stk.Count >0)
                        {
                            if (c == ')' && stk.Peek() != '(')
                            {
                                return false;
                            }
                            else if (c == ']' && stk.Peek() != '[')
                            {
                                return false;
                            }
                            else if (c == '}' && stk.Peek() != '{')
                            {
                                return false;
                            }

                            stk.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    
                    default:
                        break;
                }
            }

            if (stk.Count >0)
            {
                return false;
            }

            return true;

        }


        /// <summary>
        /// 301. Remove Invalid Parentheses
        /// https://leetcode.com/problems/remove-invalid-parentheses/description/
        /// Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.
        /// Example
        /// "()())()" -> ["()()()", "(())()"]
        /// "(a)())()" -> ["(a)()()", "(a())()"]
        /// ")(" -> [""]
        /// 
        /// sol:
        /// 
        /// 1. get left and right extra parentheses count need to be removed. be aware of ")("  case
        /// 2. use leftextra and rightextra  and open as stop condition.
        /// 
        /// foreach s
        /// 
        /// if '('    use  then open++
        ///          no use   then  leftExtra--.
        ///          
        /// if ')'   use  then open--
        ///          no use  rightExtra--
        ///          
        /// 
        /// stop when   index >=len  , or leftExtra|rightExtra smaller than 0 (memans over substract)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RemoveInvalidParenthesesHelper(string s)
        {
            HashSet<string> ans = new HashSet<string>();
            StringBuilder sb = new StringBuilder();

            int leftCount;
            int rightCount;

            // yic  left++  and left-- when close it, otherwise right ++
            findLeftRightMinEditCount(s, out leftCount, out rightCount);

            if (leftCount == rightCount && rightCount == 0)
            {
                ans.Add(s);

                return ans.ToArray();
            }

            DFSHelper(s, 0, ans, leftCount, rightCount, sb, 0);
            return ans.ToArray();
        }

        private void findLeftRightMinEditCount(string s, out int left, out int right)
        {
            left = 0;
            right = 0;

            foreach(var c in s)
            {
                if (c == '(')
                {
                    left++;
                }
                else if (c == ')')
                {
                    if (left > 0)  // close it first
                    {
                        left--;
                    }
                    else
                    {
                        right++;
                    }
                }
            }
        }

        private void DFSHelper(string s, int idx, HashSet<string> ans, int leftCount, int rightCount, StringBuilder sb, int openCount)
        {
            if (leftCount < 0 || rightCount < 0 || openCount < 0)   // yic use open to make sure curr loc is okay before move on
            {
                return;
            }
            if (idx >= s.Length)
            {
                if (leftCount == rightCount && rightCount ==0 && openCount==0)
                {
                    ans.Add(sb.ToString());
                }
                return;
            }
            
            if (s[idx] == '(')
            {
                // use it
                sb.Append('(');            // left keep as is
                DFSHelper(s, idx + 1, ans, leftCount, rightCount, sb, openCount + 1);
                sb.Remove(sb.Length-1, 1);
                
                // don't use it
                DFSHelper(s, idx + 1, ans, leftCount-1, rightCount, sb, openCount);
            }
            else if (s[idx] == ')')
            {
                // use it
                sb.Append(')');
                DFSHelper(s, idx + 1, ans, leftCount, rightCount, sb, openCount - 1);
                sb.Remove(sb.Length-1, 1);

                // don't use it
                DFSHelper(s, idx + 1, ans, leftCount, rightCount-1, sb, openCount);
            }
            else
            {
                sb.Append(s[idx]);
                DFSHelper(s, idx + 1, ans, leftCount, rightCount, sb, openCount);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
