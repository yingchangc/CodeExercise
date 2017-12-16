using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class ReverseInteger
    {
        /// <summary>
        /// Given a 32-bit signed integer, reverse digits of an integer.
        /// Example 1: 
        /// Input: 123
        /// Output:  321
        /// 
        /// Example 2: 
        /// Input: -123
        /// Output: -321
        /// 
        /// Example 3: 
        /// Input: 120
        /// Output: 21
        /// </summary>
        /// Assume we are dealing with an environment which could only hold integers within the 32-bit signed integer range. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows. 
        /// https://leetcode.com/problems/reverse-integer/discuss/
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            int result = 0;

            bool isNegative = x < 0 ? true : false;

            if (isNegative)
            {
                x *= -1;
            }

            while(x > 0)
            {
                int newResult = result * 10 + x % 10;
                x = x / 10;

                // YIC check overflow important
                if ((newResult / 10) != result)
                {
                    return 0;
                }

                result = newResult;
            }

            return isNegative ? result * -1 : result;

        }
    }
}
