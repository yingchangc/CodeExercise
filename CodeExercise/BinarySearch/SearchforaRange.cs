using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class SearchforaRange
    {
        /// <summary>
        /// 34 search for a range
        /// https://leetcode.com/problems/search-for-a-range/description/
        /// Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.

        /// Your algorithm's runtime complexity must be in the order of O(log n).
        /// 
        /// If the target is not found in the array, return [-1, -1].
        /// 
        /// Example 1:
        /// 
        /// Input: nums = [5,7,7,8,8,10], target = 8
        /// Output: [3,4]
        ///         Example 2:
        /// 
        /// Input: nums = [5,7,7,8,8,10], target = 6
        /// Output: [-1,-1]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int[] res = new int[2] { -1, -1 };
            if (nums.Length ==0 )   // yic  check,  single elemnt can handle in the following code
            {
                return res;
            }

           
            res[0] = searchLeftMost(nums, target);
            res[1] = searchRightMost(nums, target);

            return res;
             
        }

        private int searchRightMost(int[] nums, int target)
        {
            int right = nums.Length-1;
            int left = 0;

            while ((left + 1) < right)
            {
                int mid = left + (right - left) / 2;

                // 5 [5] 5         
                if (nums[mid] == target || nums[mid] < target)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            // just like consider 2 item case
            if (nums[right] == target)
            {
                // 5 5   target = 5
                return right;
            }
            else if (nums[left] == target)
            {
                // 5 6  target = 5
                return left;
            }

            return -1;
        }

        private int searchLeftMost(int[] nums, int target)
        {
            int right = nums.Length-1;
            int left = 0;

            while((left+1) < right)
            {
                int mid = left + (right - left) / 2;

                // 5 [5] 5         
                if (nums[mid] == target  || nums[mid] > target)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }

            // just like consider 2 item case
            
            if (nums[left] == target)
            {
                // 5 5   target = 5
                return left;
            }
            else if (nums[right] == target)
            {
                // 0 5  target = 5
                return right;
            }

            return -1;
        }
    }
}
