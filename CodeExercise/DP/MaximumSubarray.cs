using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class MaximumSubarray
    {
        /// <summary>
        /// 53. Maximum Subarray
        /// Find the contiguous subarray within an array (containing at least one number) which has the largest sum. 
        ///        For example, given the array[-2, 1, -3, 4, -1, 2, 1, -5, 4],
        ///        the contiguous subarray[4, -1, 2, 1] has the largest sum = 6.
        ///          click to show more practice.
        ///          More practice: 
        /// If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
        ///
        /// sol:
        /// just like fib    f(i) = max(num[i], nums[i]+f(i-1))
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArraySolver(int[] nums)
        {
            int len = nums.Length;
            int pre = 0;

            int maxV = Int32.MinValue;
            for(int i = 0; i < len; i++)
            {
                int curr = Math.Max(pre + nums[i], nums[i]);
                maxV = Math.Max(curr, maxV);
                pre = curr;
            }

            return maxV;
        }

        
    }
}
