using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BitManipulation
{
    class Number1Bits
    {
        /// <summary>
        /// 191. Number of 1 Bits
        /// Write a function that takes an unsigned integer and return the number of '1' bits it has (also known as the Hamming weight).
        /// 
        /// 
        /// 
        /// Example 1:
        /// 
        /// Input: 00000000000000000000000000001011
        /// Output: 3
        /// Explanation: The input binary string 00000000000000000000000000001011 has a total of three '1' bits.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int count = 0;

            while (n > 0)
            {
                var c = n & 1;
                if (c != 0)
                {
                    count++;
                }
                n = n >> 1;
            }

            return count;
        }
    }
}
