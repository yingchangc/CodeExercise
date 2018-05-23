using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class SearchInRotatedSortedArray
    {
        /// <summary>
        /// 33. Search in Rotated Sorted Array
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/description/
        /// Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
        /// (i.e., [0,1,2,4,5,6,7]
        ///         might become[4, 5, 6, 7, 0, 1, 2]).
        /// 
        /// You are given a target value to search.If found in the array return its index, otherwise return -1.
        /// 
        /// You may assume no duplicate exists in the array.
        /// 
        /// Your algorithm's runtime complexity must be in the order of O(log n).
        /// 
        /// Example 1:
        /// 
        /// Input: nums = [4, 5, 6, 7, 0, 1, 2], target = 0
        /// Output: 4
        /// Example 2:
        /// 
        /// Input: nums = [4, 5, 6, 7, 0, 1, 2], target = 3
        /// Output: -1
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length ==0)
            {
                return -1;
            }

            if (nums.Length == 1)
            {
                return nums[0] == target ? 0 : -1;
            }

            int len = nums.Length;
            int left = 0;
            int right = len - 1;
            while(left +1 < right)
            {
                int mid = left + (right - left)/2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                // ascendint region
                if (nums[mid] < nums[right])
                {
                    if (nums[mid] <= target && target <= nums[right])
                    {
                        left = mid;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                else
                {
                     //3 4 [5] 6 1
                     if (nums[left] <= target && target <= nums[mid])
                    {
                        right = mid;
                    }
                     else
                    {
                        left = mid;
                    }
                }

            }


            if (nums[left] == target)
            {
                return left;
            }
            else if (nums[right] == target)
            {
                return right;
            }
            return -1;

        }
    }
}
