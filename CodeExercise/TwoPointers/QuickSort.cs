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
            if (A == null || A.Length == 0)
            {
                return;
            }
            int[] temp = new int[A.Length];
            MergeSort(A, 0, A.Length - 1, temp);
            //qSort(A, 0, A.Length - 1);
        }


        private void MergeSort(int[] A, int start, int end, int[] temp)
        {
            if (start >=end)
            {
                return;
            }

            MergeSort(A, start, (start + end) / 2, temp);
            MergeSort(A, (start + end) / 2 + 1, end, temp);
            Merge(A, start, end, temp);
        }

        private void Merge(int[] A, int start, int end, int[] temp)
        {
            int left1 = start;
            int right1 = (start + end) / 2;
            int left2 = (start + end) / 2 +1;
            int right2 = end;

            int tempIdx = start;

            while(left1 <= right1 && left2 <=right2)
            {
                if (A[left1] <= A[left2])
                {
                    temp[tempIdx++] = A[left1++];
                }
                else
                {
                    temp[tempIdx++] = A[left2++];
                }
            }

            while(left1 <= right1)
            {
                temp[tempIdx++] = A[left1++];
            }
            while (left2 <= right2)
            {
                temp[tempIdx++] = A[left2++];
            }

            for (int i = start; i <=end; i++)
            {
                A[i] = temp[i];
            }
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
