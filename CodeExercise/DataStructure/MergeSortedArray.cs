using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MergeSortedArray
    {
        /// <summary>
        /// 88. Merge Sorted Array
        /// https://leetcode.com/problems/merge-sorted-array/description/
        /// Given two sorted integer arrays A and B, merge B into A as one sorted array.
        /// 
        /// Example
        /// A = [1, 2, 3, empty, empty], B = [4, 5]
        /// 
        /// After merge, A will be filled as [1, 2, 3, 4, 5]
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1,int m, int[] nums2, int n)
        {
            //int idx1 = FindEmptySlotIdx(nums1)-1;
            //int idx2 = nums2.Length - 1;

            int idx1 = m - 1;
            int idx2 = n - 1;

            int idx = idx1 + idx2+1;

            while (idx1 >=0 && idx2 >=0)
            {
                if (nums1[idx1] >= nums2[idx2])
                {
                    nums1[idx--] = nums1[idx1--];
                }
                else
                {
                    nums1[idx--] = nums2[idx2--];
                }
            }

            while (idx1 >= 0)
            {
                nums1[idx--] = nums1[idx1--];
            }

            while (idx2 >= 0)
            {
                nums1[idx--] = nums2[idx2--];
            }
        }

        private int FindEmptySlotIdx(int[] nums)
        {

            int pre = nums[0];
            int i = 0;
            for (i = 1; i < nums.Length; i++)
            {
                if (nums[i]>=pre)
                {
                    pre = nums[i];
                }
                else
                {
                    break;

                }
            }

            return i;
        }
    }
}
