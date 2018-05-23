using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class LastPositionofTarget
    {
        // lint 485
        /// <summary>
        /// https://www.lintcode.com/en/old/problem/last-position-of-target/
        /// 
        /// Find the last position of a target number in a sorted array. Return -1 if target does not exist.
        /// Have you met this question in a real interview?
        /// Example
        /// Given[1, 2, 2, 4, 5, 5].
        /// 
        /// 
        /// For target = 2, return 2.
        ///For target = 5, return 5.
        ///For target = 6, return -1.
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int LastPositionSolver(int[] nums, int target)
        {
            int len = nums.Length;
            if (len <= 1)
            {
                if (len == 1 && nums[0] == target)
                {
                    return 0;
                }
                return -1;
            }


            int left = 0;
            int right = nums.Length-1;

            while ((left +1) < right)
            {
                int mid = left + (right - left) / 2;
                int midV = nums[mid];

                if (midV <= target)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            if (nums[right] == target)
            {
                return right;
            }
            else if (nums[left] == target)
            {
                return left;
            }

            return -1;
        }
    }
}
