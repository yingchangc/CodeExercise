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

        /// <summary>
        /// 81. Search in Rotated Sorted Array II
        /// https://leetcode.com/problems/search-in-rotated-sorted-array-ii/description/
        /// Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
        /// (i.e., [0,0,1,2,2,5,6]
        ///         might become[2, 5, 6, 0, 0, 1, 2]).
        /// 
        /// You are given a target value to search.If found in the array return true, otherwise return false.
        /// 
        /// Example 1:
        /// 
        /// Input: nums = [2, 5, 6, 0, 0, 1, 2], target = 0
        /// Output: true
        /// Example 2:
        /// 
        /// Input: nums = [2, 5, 6, 0, 0, 1, 2], target = 3
        /// Output: false
        /// 
        /// // 这个问题在面试中不会让实现完整程序
        // 只需要举出能够最坏情况的数据是 [1,1,1,1... 1] 里有一个0即可。
        // 在这种情况下是无法使用二分法的，复杂度是O(n)
        // 因此写个for循环最坏也是O(n)，那就写个for循环就好了
        //  如果你觉得，不是每个情况都是最坏情况，你想用二分法解决不是最坏情况的情况，那你就写一个二分吧。
        //  反正面试考的不是你在这个题上会不会用二分法。这个题的考点是你想不想得到最坏情况。
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search2(int[] nums, int target)
        {
            int len = nums.Length;
            for(int i = 0; i < len; i++)
            {
                if (nums[i] == target)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
