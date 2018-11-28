using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class DecodeString
    {
        /// <summary>
        /// 394. Decode String
        /// https://leetcode.com/problems/decode-string/description/
        /// 
        /// iven an encoded string, return it's decoded string.
        /// 
        /// The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times.Note that k is guaranteed to be a positive integer.
        /// 
        /// You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.
        /// 
        /// Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k.For example, there won't be input like 3a or 2[4].
        /// 
        /// Examples:
        /// 
        /// s = "3[a]2[bc]", return "aaabcbc".
        /// s = "3[a2[c]]", return "accaccacc".
        /// s = "2[abc]3[cd]ef", return "abcabccdcdcdef".
        /// 
        /// 
        /// sol:
        /// 
        /// use stack  to blindly push "a2" from  "a2[c]"   once hit '['   push all to stack
        /// hit ']' curr is c,  pop operator "a2"  out and get digit 2  and prefix a,  then repeat 2 times to get cc, then append prefix a
        //  and then get acc.   if later hit 3 [   push "acc3"   as operator
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecodeStringSolver(string s)
        {
            Stack<string> stk = new Stack<string>();

            string curr = "";
            foreach (char c in s)
            {
                if (c == '[')
                {
                    stk.Push(curr);  // 3
                    curr = "";  // reset
                }
                else if (c == ']')
                {
                    var op = stk.Pop();

                    // parse digit
                    int len = op.Length;

                    int num = 0;
                    int factor = 1;
                    int i = len - 1;
                    while (i >= 0)
                    {
                        int n;
                        if (int.TryParse(op[i].ToString(), out n))
                        {
                            num += (factor * n);
                            factor *= 10;
                        }
                        else
                        {
                            break;
                        }

                        i--;
                    }

                    // 3[c]
                    string prefix = op.Substring(0, i + 1);

                    string repeat = "";

                    for (int k = 0; k < num; k++)
                    {
                        repeat += curr;
                    }

                    curr = prefix + repeat;

                }
                else
                {
                    curr += c;
                }
            }

            return curr;

        }
    }
}
