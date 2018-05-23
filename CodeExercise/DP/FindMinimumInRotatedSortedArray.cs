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
        /// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
        /// Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
        /// (i.e.,  [0,1,2,4,5,6,7]
        ///         might become[4, 5, 6, 7, 0, 1, 2]).
        /// 
        /// Find the minimum element.
        /// 
        /// 
        /// use binary search
        /// 
        /// You may assume no duplicate exists in the array.
        /// </summary>
        /// 
        ///  use right most [2] as threshold,  if mid is smaller than 2, we are in the ascending region, to find smaller
        ///  set right = mid  keep search smaller
        ///  otherwise, mid is bigger than right most, means we are in the other bigger ascending region, should go right side, 
        ///  so set left =mid
        /// 
        /// O(logN)
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
            else if (nums.Length==1)
            {
                return nums[0];
            }

            int len = nums.Length;
            int left = 0;
            int right = len - 1;

            while((left +1) < right)
            {
                int mid = left + (right - left) / 2;

                // yic  find smallest, check  mid and right
                // mid < right  (ascending),  go left to fiind min
                if (nums[mid] <= nums[right])
                {
                    right = mid;
                }
                else
                {
                    // 3 [4] 5 2
                    left = mid;
                }
            }

            return nums[left] < nums[right] ? nums[left] : nums[right];
        }

        /// find 
        /// len smaller than 3    check directly
        /// 
        /// if sorted then return elem[0]
        /// 
        /// otherwise, try find 7 0 1 case  
        /// keep cut   go right when left sort; otherwise go left
        public int FindMinOld(int[] nums)
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
        /// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/description/
        /// Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

        // (i.e.,  [0,1,2,4,5,6,7]
        //         might become[4, 5, 6, 7, 0, 1, 2]).
        // 
        // Find the minimum element.
        // 
        // The array may contain duplicates.
        // 
        // Example 1:
        // 
        // Input: [1,3,5]
        // Output: 1
        // Example 2:
        // 
        // Input: [2,2,2,0,1]
        // Output: 0
        // Note:
        // 
        // This is a follow up problem to Find Minimum in Rotated Sorted Array.
        // Would allow duplicates affect the run-time complexity? How and why?   
        /// sol the worst become O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMinWithDupInArray(int[] nums)
        {
            //  这道题目在面试中不会让写完整的程序
            //  只需要知道最坏情况下 [1,1,1....,1] 里有一个0
            //  这种情况使得时间复杂度必须是 O(n)
            //  因此写一个for循环就好了。
            //  如果你觉得，不是每个情况都是最坏情况，你想用二分法解决不是最坏情况的情况，那你就写一个二分吧。
            //  反正面试考的不是你在这个题上会不会用二分法。这个题的考点是你想不想得到最坏情况。
            //if (nums == null || nums.Length == 0)
            //{
            //    return -1;
            //}
            //else if (nums.Length == 1)
            //{
            //    return nums[0];
            //}
            //int len = nums.Length;
            //int min = nums[0];
            //for (int i = 1; i < len; i++)
            //{
            //    min = Math.Min(nums[i], min);
            //}

            //return min;

            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
            else if (nums.Length == 1)
            {
                return nums[0];
            }

            int len = nums.Length;
            int left = 0;
            int right = len - 1;

            while ((left + 1) < right)
            {
                int mid = left + (right - left) / 2;

                // mid < right  (ascending),  go left to find min
                if (nums[mid] < nums[right])
                {
                    right = mid;
                }
                else if (nums[mid] == nums[right])
                {
                    // small still kept, can discard right
                    right--;
                }
                else
                {
                    // 3 [4] 5 2
                    left = mid;
                }
            }

            return nums[left] < nums[right] ? nums[left] : nums[right];


        }

        public int FindMinWithDupInArrayBinary(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
            else if (nums.Length == 1)
            {
                return nums[0];
            }

            int len = nums.Length;
            int left = 0;
            int right = len - 1;

            int target = nums[len - 1];
            while (left+1 < right)
            {
                int mid = left + (right - left) / 2;

                // yic in smaller region, should move left in the same region
                if (nums[mid] < target)
                {
                    right = mid;
                }
                else if (nums[mid] == target)
                {
                    right--;
                }
                else
                {
                    // in bigger ascending region, should go to right ascending region
                    left = mid;
                }
            }

            return nums[left] <= nums[right] ? nums[left] : nums[right];
        }

        public int FindMinWithDupInArrayOld(int[] nums)
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
