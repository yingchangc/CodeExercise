using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{

    class RangeSumQuery
    {

        public int[] sumArr;
        /// <summary>
        /// 303. Range Sum Query - Immutable
        /// https://leetcode.com/problems/range-sum-query-immutable/description/
        /// Given an integer array nums, find the sum of the elements between indices i and j(i ≤ j), inclusive.
        /// 
        /// Example
        /// Given nums = [-2, 0, 3, -5, 2, -1]
        /// 
        /// 
        /// sumRange(0, 2) -> 1
        /// sumRange(2, 5) -> -1
        /// sumRange(0, 5) -> -3
        /// 
        /// 
        /// sol:
        /// 
        ///      sum = [0, -2, -2, 1, -4, -2, -3]
        /// </summary>
        /// <param name="nums"></param>
        public RangeSumQuery(int[] nums)
        {
            sumArr = new int[nums.Length+1];

            for (int i = 1; i<= nums.Length; i++)
            {
                sumArr[i] += nums[i - 1] + sumArr[i-1];
            }
        }

        public int SumRange(int i, int j)
        {
            return sumArr[j + 1] - sumArr[i];
        }
    }
}
