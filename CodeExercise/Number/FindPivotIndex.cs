using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class FindPivotIndex
    {
        /// <summary>
        /// 724
        /// Given an array of integers nums, write a method that returns the "pivot" index of this array. 
        ///         We define the pivot index as the index where the sum of the numbers to the left of the index is equal to the sum of the numbers to the right of the index.
        ///         If no such index exists, we should return -1. If there are multiple pivot indexes, you should return the left-most pivot index.
        ///         Example 1:
        /// Input: 
        /// nums = [1, 7, 3, 6, 5, 6]
        ///         Output: 3
        /// Explanation: 
        /// The sum of the numbers to the left of index 3 (nums[3] = 6) is equal to the sum of numbers to the right of index 3.
        /// Also, 3 is the first index where this occurs.
        /// 
        /// Example 2:
        /// Input: 
        /// nums = [1, 2, 3]
        ///         Output: -1
        /// Explanation: 
        /// There is no index that satisfies the conditions in the problem statement.
        /// 
        /// 
        /// Sol:
        /// 
        /// O(n)
        /// 
        /// use sumLeft initial to 0  and sumRight initial to all
        /// increase sumLeft  and decrease sumRight
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndexHelper(int[] nums)
        {
            int len = nums.Length;

            if (len <=2)
            {
                return -1;
            }

            int sumL = 0;
            int sumR = nums.Sum();    // deliberate keep sumL|sumLeft no pivot at the time

            for (int pivotIndex = 0; pivotIndex < len; pivotIndex++)    // pivot from index 1 to len-2   [0 1 2 3]
            {
                // choose pivot
                sumR -= nums[pivotIndex];
                if (sumL == sumR)   //  sumL [] sumR
                {
                    return pivotIndex;
                }

                sumL += nums[pivotIndex];    // move left forward  and now there is not gap between L and R again.
            }

            return -1;
        }
    }
}
