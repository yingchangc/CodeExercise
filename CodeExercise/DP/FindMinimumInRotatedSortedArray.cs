using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class FindMinimumInRotatedSortedArray
    {
        /// <summary>
        /// 153
        /// 
        /// 0 1 2 4 5 6 7   -> 6 7 0 1 2 4
        /// </summary>
        /// 
        /// find 
        /// len smaller than 3    check directly
        /// 
        /// if sorted then return elem[0]
        /// 
        /// otherwise, try find 7 0 1 case  
        /// keep cut   go right when left sort; otherwise go left
        /// 
        /// O(logN)
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            return FindMinHelper(nums, 0, nums.Length-1);
        }

        private int FindMinHelper(int[] nums, int start, int last)
        {
            // stop condition, last then 2 elem
            if ((last - start) <=1)
            {
                return Math.Min(nums[start], nums[last]);
            }

            if (nums[start] < nums[last])
            {
                return nums[start];
            }


            // now is  7 ...9 0  ...3 case
            int mid = (start + last) / 2;

            // left sort, go right; this should also handle [7  0]  len ==2 case
            if (nums[start] <= nums[mid])
            {
                return FindMinHelper(nums, mid + 1, last);
            }
            else
            {
                return FindMinHelper(nums, start, mid);
            }
        }

        /// <summary>
        /// 154. Find Minimum in Rotated Sorted Array II
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMinWithDupInArray(int[] nums)
        {
            return FindMin2Helper(nums, 0, nums.Length - 1);
        }

        private int FindMin2Helper(int[] nums, int start , int last)
        {
            if ((last - start) <= 1)
            {
                return Math.Min(nums[start], nums[last]);
            }

            // already sorted,  cannot <=,  for example  10 1 10
            if (nums[start] < nums[last])
            {
                return nums[start];
            }

            int mid = (start + last) / 2;

            // startNum == lastNum
            if (nums[start] == nums[last])
            {
                // hard to tell, just move last to left  find the smaller
                return FindMin2Helper(nums, start, last - 1);
            }
            else if (nums[start] <= nums[mid])    // YIC  <=   for [3,3 1]  also can handle 2 element case where start == mid
            {
                //left sorted, go right
                return FindMin2Helper(nums, mid + 1, last);
            }
            else
            {
                return FindMin2Helper(nums, start, mid);

            }
        }
    }
}
