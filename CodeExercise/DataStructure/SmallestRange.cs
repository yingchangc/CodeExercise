using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class SmallestRange
    {
        /// <summary>
        /// 908. Smallest Range I
        /// https://leetcode.com/problems/smallest-range-i/
        /// Given an array A of integers, for each integer A[i] we may choose any x with -K <= x <= K, and add x to A[i].
        /// 
        /// After this process, we have some array B.
        /// 
        /// Return the smallest possible difference between the maximum value of B and the minimum value of B.
        /// 
        /// 
        /// 
        /// Example 1:
        /// 
        /// 
        ///         Input: A = [1], K = 0
        ///         Output: 0
        /// Explanation: B = [1]
        ///         Example 2:
        /// 
        /// 
        ///         Input: A = [0, 10], K = 2
        ///         Output: 6
        /// Explanation: B = [2, 8]
        ///         Example 3:
        /// 
        /// 
        ///         Input: A = [1, 3, 6], K = 3
        ///         Output: 0
        /// Explanation: B = [3, 3, 3] or B = [4, 4, 4]
        /// </summary>
        /// <param name="A"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int SmallestRangeI(int[] A, int K)
        {
            if (A == null || A.Length <= 1)
            {
                return 0;
            }

            int len = A.Length;

            int maxV = int.MinValue;
            int minV = int.MaxValue;

            for (int i = 0; i < len; i++)
            {
                maxV = Math.Max(maxV, A[i]);
                minV = Math.Min(minV, A[i]);
            }


            int diff = maxV - minV;

            // 10,  k = 2
            if (diff > 2 * K)
            {
                return diff - 2 * K;
            }

            // 5,  k = 3    can choose  +3, -2
            return 0;
        }
    }
}
