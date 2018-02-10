using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class CountingBits
    {
        /// <summary>
        /// 338
        /// Counting Bits
        /// https://leetcode.com/problems/counting-bits/description/
        /// 
        /// Given a non negative integer number num. For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary representation and return them as an array.
        ///        Example:
        ///For num = 5 you should return [0,1,1,2,1,2].
        ///
        /// Sol
        /// 
        ///   0   000
        ///   1   001
        ///   2   010          f[i]  = f[i/2]   + i%2   // f[i/2]  has been computed before  ; just need to know current i last bit
        ///   3   011
        ///   4   100
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int[] CountBitsSolver(int num)
        {
            int[] ans = new int[num + 1];
            ans[0] = 0;

            for (int i = 0; i <= num; i++)
            {
                int half = i >> 1;
                ans[i] = ans[half] + (i & 1);
            }

            return ans;
        }
    }
}
