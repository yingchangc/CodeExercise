using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class QuickSort
    {
        /// <summary>
        /// 464. Sort Integers II
        /// https://www.lintcode.com/problem/sort-integers-ii/description
        /// Given an integer array, sort it in ascending order. Use quick sort, merge sort, heap sort or any O(nlogn) algorithm.
        ///Example
        ///Given[3, 2, 1, 4, 5], return [1, 2, 3, 4, 5].
        /// </summary>
        /// <param name="A"></param>
        public void sortIntegers2(int[] A)
        {
            qSort(A, 0, A.Length - 1);
        }

        private void qSort(int[] nums, int start, int end)
        {

            if (nums == null || nums.Length ==0  || start >= end)
            {
                return;
            }

            int left = start;
            int right = end;

            int pivot = nums[left + (right - left) / 2];

            while (left <= right)
            {
                while(left <= right && nums[left] < pivot)
                {
                    left++;
                }

                while (left <= right && nums[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    swap(nums, left++, right--);
                }
            }

            qSort(nums, start, right);
            qSort(nums, left, end);
        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
