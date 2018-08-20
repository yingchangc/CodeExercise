using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class TopKLargestNumbers
    {
        // for minheap
        class AscendingComarer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }

        }

        /// <summary>
        /// https://www.lintcode.com/problem/top-k-largest-numbers/description
        /// 544. Top k Largest Numbers
        /// Given an integer array, find the top k largest numbers in it.
        /// 
        /// Example
        /// Given[3, 10, 1000, -99, 4, 100] and k = 3.
        ///     Return[1000, 100, 10].
        ///     
        /// 
        /// Sol
        /// (1) sort all array  nlogn
        /// (2) use minheap and pop min if size > k so that in the end, we can get the largest k   nlogk
        /// (3) selection sort  n+(klogk)   selection + sort answer
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] topkPQ(int[] nums, int k)
        {
            // use SortedList to mimic pq
            SortedList<int, int> minheap = new SortedList<int, int>(new AscendingComarer());

            for (int i = 0; i < nums.Length; i ++)
            {
                minheap.Add(nums[i], 1);

                if (i >=k)
                {
                    minheap.RemoveAt(0);
                }
            }

            int[] ans = new int[k];
            int idx = k-1;
            foreach(int n in minheap.Keys)
            {
                ans[idx--] = n;
            }

            return ans;
        }

        public int[] topKQSort(int[] nums, int kth)
        {
            selectionSort(nums, 0, nums.Length - 1, kth - 1);

            int[] ans = new int[kth];
            for (int i = 0; i < kth;  i++)
            {
                ans[i] = nums[i];
            }

            Array.Sort(ans, new Comparison<int>(
                            (i1, i2) => i2.CompareTo(i1)
                    ));
            return ans;
        }

        private void selectionSort(int[] nums, int start , int last, int k)
        {
            if (start >= last)
            {
                return;
            }

            int left = start;
            int right = last; 
            int pivot = nums[(left + right) / 2];

            // sort from big to small
            while (left <= right)
            {
                while(left<=right && nums[left] > pivot)
                {
                    left++;
                }

                while (left <= right && nums[right] < pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    int temp = nums[left];
                    nums[left++] = nums[right];
                    nums[right--] = temp;
                }
            }

            if (start <=k && k <=right)
            {
                selectionSort(nums, start, right, k);
            }
            else if (left <= k && k <= last)
            {
                selectionSort(nums, left, last, k);
            }
        }
    }
}
