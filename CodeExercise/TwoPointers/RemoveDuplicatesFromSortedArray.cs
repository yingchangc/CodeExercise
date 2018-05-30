using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class RemoveDuplicatesFromSortedArray
    {
        /// <summary>
        /// 26. Remove Duplicates from Sorted Array
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
        /// Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
        /// Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
        /// 
        /// Example 1:
        /// 
        /// Given nums = [1, 1, 2],
        /// 
        ///         Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.
        /// 
        ///         It doesn't matter what you leave beyond the returned length.
        /// 
        /// Example 2:
        /// 
        ///         Given nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4],
        /// 
        ///         Your function should return length = 5, with the first five elements of nums being modified to 0, 1, 2, 3, and 4 respectively.
        /// 
        ///         It doesn't matter what values are set beyond the returned length.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int index = 1;

            int pre = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != pre)
                {
                    pre = nums[i];
                    swap(nums, i, index++);
                }
                else
                {
                    pre = nums[i];
                }
                
            }

            return index;  // as length
        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
