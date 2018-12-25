using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class WiggleSort
    {
        /// <summary>
        /// 280. Wiggle Sort
        /// https://leetcode.com/problems/wiggle-sort/
        // Given an unsorted array nums, reorder it in-place such that nums[0] <= nums[1] >= nums[2] <= nums[3]....
        /// 
        /// Example:
        /// 
        /// Input: nums = [3,5,2,1,6,4]
        ///         Output: One possible answer is [3,5,1,6,2,4]
        /// </summary>
        /// <param name="nums"></param>
        public void WiggleSort_ON(int[] nums)
        {
            
            for (int i=0; i <nums.Length; i++)
            {
                if (i % 2 != 0)
                {
                    // 1 3 5 index should big,  swap with prev won't affect pre- case (even case),because we swap a even smaller one 
                    if (nums[i] < nums[i - 1])
                    {
                        swap(nums, i, i - 1);
                    }  
                }
                else
                {
                    if (i > 0)
                    {
                        //  2 4 6 should small, swap with pre  won;t affect pre case (odd case), because we swap a bigger one
                        if (nums[i] > nums[i-1])
                        {
                            swap(nums, i, i - 1);
                        }
                    }
                }
            }
        }
        ///
        public void WiggleSort_NlogN(int[] nums)
        {
            qsort(nums, 0, nums.Length - 1);   // 1 2 3 4 5 6

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }

            for (int i = 2; i < nums.Length; i += 2)
            {
                swap(nums, i - 1, i);
            }


        }



        private void qsort(int[] nums, int l, int r)
        {
            if (l >= r)
            {
                return;
            }
            int left = l;
            int right = r;

            int pivot = nums[left + (right - left) / 2];  // must use valu cannot use index

            while (left <= right)
            {
                while (left <= right && nums[left] < pivot)
                {
                    left++;
                }
                while (left <= right && pivot < nums[right])
                {
                    right--;
                }

                if (left <= right)
                {
                    swap(nums, left, right);
                    left++;
                    right--;
                }
            }

            qsort(nums, l, right);
            qsort(nums, left, r);

        }

        private void swap(int[] nums, int left, int right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }
    }
}
