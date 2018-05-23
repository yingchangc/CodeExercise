using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class MaximumNumberinMountainSequence
    {
        /// <summary>
        /// 585. Maximum Number in Mountain Sequence
        /// https://www.lintcode.com/en/old/problem/maximum-number-in-mountain-sequence/
        /// 
        /// Given a mountain sequence of n integers which increase firstly and then decrease, find the mountain top.
        /// Example
        /// Given nums = [1, 2, 4, 8, 6, 3] return 8
        /// Given nums = [10, 9, 8, 7], return 10
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MountainSequenceSolver(int[] nums)
        {
            int len = nums.Length;

            int left = 0;
            int right = len - 1;

            while((left + 1) < right)
            {
                // must be at least 3 elem to check
                int mid = left + (right - left) / 2;

                if (nums[mid-1] < nums[mid] && nums[mid] > nums[mid+1])     // yic  check mid-1  mid mid+1   not left, right
                {
                    return nums[mid];
                }
                else if (nums[mid-1] <= nums[mid])
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }

            }

            // when out, it must be on the left/right edge
            return Math.Max(nums[left], nums[right]);
        }
    }
}
