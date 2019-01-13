using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    /// <summary>
    /// 713. Subarray Product Less Than K
    /// https://leetcode.com/problems/subarray-product-less-than-k/
    /// Your are given an array of positive integers nums.
    /// 
    /// Count and print the number of(contiguous) subarrays where the product of all the elements in the subarray is less than k.
    /// 
    /// Example 1:
    /// Input: nums = [10, 5, 2, 6], k = 100
    /// Output: 8
    /// Explanation: The 8 subarrays that have product less than 100 are: [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6].
    /// Note that[10, 5, 2] is not included as the product of 100 is not strictly less than k.
    /// </summary>
    class SubarrayProductLessThanK
    {
        List<List<int>> collection;
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {

            if (k <= 1)   // [1 1 1]   1
            {
                return 0;
            }

            int len = nums.Length;

            int prod = 1;
            int count = 0;
            int left = 0;
            for (int j = 0; j < len; j++)
            {
                prod *= nums[j];

                while (prod >= k)   
                {
                    prod /= nums[left++];
                }

                int toAdd = (j - left + 1);          // 10 5 2  if k=101     10*5*2 or 5*2  or 2   
                // Console.WriteLine(toAdd);
                count += toAdd;

            }

            return count;
        }
    }
}
