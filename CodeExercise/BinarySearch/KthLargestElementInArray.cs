using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class KthLargestElementInArray
    {
        /// <summary>
        /// 215. Kth Largest Element in an Array
        /// https://leetcode.com/problems/kth-largest-element-in-an-array/description/
        /// Find the kth largest element in an unsorted array. Note that it is the 
        /// kth largest element in the sorted order, not the kth distinct element.
        /// 
        /// Example 1:
        /// 
        /// Input: [3,2,1,5,6,4]
        ///         and k = 2
        /// Output: 5
        /// Example 2:
        /// 
        /// Input: [3,2,3,1,2,4,5,5,6]
        ///         and k = 4
        /// Output: 4
        /// Note: 
        /// You may assume k is always valid, 1 ≤ k ≤ array's length.
        /// 
        /// sol
        /// 
        /// take first elemt as pivotV, left ..... right
        /// 
        //  [partition function]
        // if (left < pivotV < right)
        //   swap (arr, left++, right--)
        // else if (left >= pivotV)
        //     left++
        // else 
        //     right--;

        //    swap(Array, pivotIdx, right)

        //  return right   the pivot new final loc.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)  // yic <  because   we start swap from left+1
            {
                int pivotIndex = partition(nums, left, right);
                if (pivotIndex == (k-1))   // kth  means index = k-1
                {
                    return nums[pivotIndex];
                }
                else if (pivotIndex > (k-1))
                {
                    right = pivotIndex-1;  // yic  pivotIndex-1  since pivotIndex is not right
                }
                else
                {
                    left = pivotIndex+1; // yic  pivotIndex+1  since pivotIndex is not right
                }
            }

            // 1 element case has been handled
            // should not hit here
            return nums[left];
        }

        // take 1st elemenmt as pivot, {large values [pivot] small values}
        // return index of the swapped pivot
        private int partition(int[] nums, int left, int right)
        {
            if (left == right)
            {
                return left;
            }
            int pivot = nums[left];
            int pivotIndex = left;
            left++;

            while(left <= right)
            {
                if (nums[left] < pivot && pivot < nums[right])
                {
                    swap(nums, left, right);
                    left++;
                    right--;
                }
                else if (nums[left] >= pivot)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            // eventually, right,left  cross                                      R    L
            swap(nums, pivotIndex, right);     // swap with right  pivot [4] 7  6 5 ,  3 1

            return right;
        }

        private void swap(int[] nums, int left, int right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }

/*
 // kth smallest
 // Note:  the only diff is the partiton funcition


 public int kthSmallest(int k, int[] nums) {
        int left = 0;
            int right = nums.length - 1;

            while (left <= right)  // yic <  because   we start swap from left+1
            {
                int pivotIndex = partition(nums, left, right);
                if (pivotIndex == (k-1))   // kth  means index = k-1
                {
                    return nums[pivotIndex];
                }
                else if (pivotIndex > (k-1))
                {
                    right = pivotIndex-1;  // yic  pivotIndex-1  since pivotIndex is not right
                }
                else
                {
                    left = pivotIndex+1; // yic  pivotIndex+1  since pivotIndex is not right
                }
            }

            // 1 element case has been handled
            // should not hit here
            return nums[left];
    }
    
    private int partition(int[] nums, int left, int right)
        {
            if (left == right)
            {
                return left;
            }
            int pivot = nums[left];
            int pivotIndex = left;
            left++;

            while(left <= right)
            {
                if (nums[left] > pivot && pivot > nums[right])      // reverse the kth lartest 
                {
                    swap(nums, left, right);
                    left++;
                    right--;
                }
                else if (nums[left] <= pivot)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            // eventually, right,left  cross                                   R L
            swap(nums, pivotIndex, right);     // swap with right  pivot [3] 2 1 4 5

            return right;
        }

        private void swap(int[] nums, int left, int right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }
    
     
 */


        /// <summary>
        /// QuickSort
        /// </summary>
        /// <param name="arr"></param>
        public void QuickSort(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            Console.WriteLine("before");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            qsort(arr, left, right);

            Console.WriteLine("\r\n after sort");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

        }

        private void qsort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivotIdx = partitionHelperForQS(arr, left, right);
            qsort(arr, left, pivotIdx - 1);   // yic pivotIdx -1
            qsort(arr, pivotIdx + 1, right);
        }

        private int partitionHelperForQS(int[] arr, int left, int right)
        {
            if (left == right)
            {
                return left;
            }

            int start = left;
            int end = right;

            int pivot = arr[left];
            int pivotIndex = left;
            left++;

            while(left <= right)
            {
                if (arr[left] < pivot && pivot < arr[right])
                {
                    swap(arr, left, right);
                    left++;
                    right--;
                }
                else if (arr[left] >= pivot)
                {
                    left++;   // can go left since is bigger than pivot
                }
                else
                {
                    right--;
                }
            }

            swap(arr, pivotIndex, right);    // right will be pivot new loc
            return right;   //return pivot index
        }
    }
}
