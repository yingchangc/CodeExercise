using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    public class PalindromePermutation
    {
        /// <summary>
        /// palindrome permutation leetcode 267
        /// determine a string if its permutation can form palindrome
        /// 
        /// code  => false
        /// 
        /// carerac => true    (c a r e r a c)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CanPalidromePermute(string str)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var ch in str)
            {
                if (dic.ContainsKey(ch))
                {
                    // flip value
                    int val;
                    dic.TryGetValue(ch, out val);
                    if (val == 1)
                    {
                        val = 0;
                    }
                    else
                    {
                        val = 1;
                    }
                    dic[ch] = val;
                }
                else
                {
                    dic.Add(ch, 1);
                }
            }

            int sum = 0;

            foreach(var item in dic)
            {
                sum += (item.Value);
            }

            return sum <= 1 ? true : false;
        }
    }
}
