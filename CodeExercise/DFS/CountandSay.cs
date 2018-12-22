using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class CountandSay
    {
        /// <summary>
        /// 38. Count and Say
        /// https://leetcode.com/problems/count-and-say/
        /// The count-and-say sequence is the sequence of integers with the first five terms as following:
        /// 
        /// 1.     1
        /// 2.     11
        /// 3.     21
        /// 4.     1211
        /// 5.     111221
        /// 1 is read off as "one 1" or 11.
        /// 11 is read off as "two 1s" or 21.
        /// 21 is read off as "one 2, then one 1" or 1211.
        /// 
        /// Given an integer n where 1 ≤ n ≤ 30, generate the nth term of the count-and-say sequence.
        /// 
        /// Note: Each term of the sequence of integers will be represented as a string.
        /// 
        /// 
        /// 
        /// 
        /// Example 1:
        /// 
        /// Input: 1
        /// Output: "1"
        /// Example 2:
        /// 
        /// Input: 4
        /// Output: "1211"
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {

            if (n <= 0)
            {
                return "";
            }
            return Helper(n, 1, "1");
        }

        private string Helper(int n, int level, string s)
        {
            if (n == level)
            {
                return s;
            }

            char pre = s[0];
            int count = 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < s.Length; i++)
            {
                if (pre == s[i])
                {
                    count++;
                }
                else
                {
                    sb.Append(count.ToString());
                    sb.Append(pre);
                    pre = s[i];
                    count = 1;
                }
            }

            sb.Append(count.ToString());
            sb.Append(pre);

            return Helper(n, level + 1, sb.ToString());
        }
    }
}
