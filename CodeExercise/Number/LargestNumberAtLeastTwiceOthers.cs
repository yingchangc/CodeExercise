using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class LargestNumberAtLeastTwiceOthers
    {
        /// <summary>
        /// 747
        /// In a given integer array nums, there is always exactly one largest element. 
        ///        Find whether the largest element in the array is at least twice as much as every other number in the array.
        ///        If it is, return the index of the largest element, otherwise return -1. 
        ///Example 1:
        ///Input: nums = [3, 6, 1, 0]
        ///        Output: 1
        ///Explanation: 6 is the largest integer, and for every other number in the array x,
        ///        6 is more than twice as big as x.The index of value 6 is 1, so we return 1.
        ///
        ///
        ///        Example 2:
        ///Input: nums = [1, 2, 3, 4]
        ///        Output: -1
        ///Explanation: 4 isn't at least as big as twice the value of 3, so we return -1.
        ///
        ///
        ///        Note:
        ///nums will have a length in the range [1, 50].
        ///Every nums[i] will be an integer in the range [0, 99].
        ///
        /// Sol: actually just find max >= twice the second max
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DominantIndex(int[] nums)
        {
            int len = nums.Length;
            if (len ==0)
            {
                return -1;
            }
            int secondMax = -1;   // since num 0~99
            int currMax = nums[0];
            int currMaxIndex = 0;

            for (int i = 1; i < len; i++)
            {
                if (nums[i] > currMax)     // greater than max
                {
                    secondMax = currMax;
                    currMax = nums[i];
                    currMaxIndex = i;  
                }
                else if (nums[i] >= secondMax)   // greater than second max, yic easy to make mistake
                {
                    secondMax = nums[i];
                } 
            }

            return (currMax >= 2*secondMax) ? currMaxIndex : -1;
        }
    }
}
