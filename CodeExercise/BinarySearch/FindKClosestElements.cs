using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class FindKClosestElements
    {
        //
        /// <summary>
        /// 460. Find K Closest Elements
        /// https://leetcode.com/problems/find-k-closest-elements/description/
        /// Given a sorted array, two integers k and x, find the k closest elements to x in the array. 
        /// The result should also be sorted in ascending order. If there is a tie, the smaller elements are always preferred.

        /// Example 1:
        /// Input: [1,2,3,4,5], k=4, x=3
        /// Output: [1,2,3,4]
        ///         
        /// Example 2:
        /// Input: [1,2,3,4,5], k=4, x=-1
        /// Output: [1,2,3,4]
        ///         Note:
        /// The value k is positive and will always be smaller than the length of the sorted array.
        /// Length of the given array is positive and will not exceed 10^4
        /// Absolute value of elements in the array and x will not exceed 10^4
        /// 
        /// 
        /// Lint 460. Find K Closest Elements
        /// https://www.lintcode.com/problem/find-k-closest-elements/description
        /// Given a target number, a non-negative integer target and an integer array A sorted in ascending order, 
        /// find the k closest numbers to target in A, sorted in ascending order by the difference between the number and target. 
        /// Otherwise, sorted in ascending order by number if the difference is same.
        /// 
        /// Given A = [1, 2, 3], target = 2 and k = 3, return [2, 1, 3].
        /// Given A = [1, 4, 6, 8], target = 3 and k = 3, return [4, 1, 6].
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public List<int> FindClosestElements(int[] arr, int k, int target)
        {
            int idx = FindIndexLEtoTarget(arr, target);

            int left = idx;
            int right = idx + 1;

            List<int> ans = new List<int>();
            while (k>0)
            {
                // both left and right can move.
                if (left >=0 && right < arr.Length)
                {
                    // find who is smaller
                    if (Math.Abs(arr[left]- target) <= Math.Abs(arr[right]-target))
                    {
                        ans.Add(arr[left--]);
                    }
                    else
                    {
                        ans.Add(arr[right++]);
                    }
                }
                else if (left >=0)
                {
                    ans.Add(arr[left--]);
                }
                else
                {
                    ans.Add(arr[right++]);
                }
                k--;
            }

            ans.Sort((x, y) => x.CompareTo(y));
            return ans;
        }

        private int FindIndexLEtoTarget(int[] arr, int target)
        {
            // find the last element smaller than target
            int left = 0;
            int right = arr.Length - 1;
            while(left+1 < right)
            {
                int mid = left + (right - left) / 2;
                if (target <= arr[mid])
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }

            // only 2 item case  [2 3]  target= 4?
            if (arr[right] <= target)
            {
                return right;
            }
            
            return left;
        }
    }
}
