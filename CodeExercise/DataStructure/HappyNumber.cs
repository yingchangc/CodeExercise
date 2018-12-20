using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class HappyNumber
    {
        /// <summary>
        /// 202. Happy Number
        /// https://leetcode.com/problems/happy-number/
        /// Write an algorithm to determine if a number is "happy".
        /// 
        /// A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
        /// 
        /// Example: 
        /// 
        /// 
        /// Input: 19
        /// Output: true
        /// Explanation: 
        /// 12 + 92 = 82
        /// 82 + 22 = 68
        /// 62 + 82 = 100
        /// 12 + 02 + 02 = 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsHappy(int n)
        {

            HashSet<int> seen = new HashSet<int>();
            seen.Add(n);

            while (n != 1)
            {
                n = Helper(n);

                if (seen.Contains(n))
                {
                    return false;
                }
                seen.Add(n);
            }

            return true;

        }

        private int Helper(int n)
        {
            int num = 0;
            while (n != 0)
            {
                int res = n % 10;
                num += res * res;
                n /= 10;
            }

            return num;
        }
    }
}
