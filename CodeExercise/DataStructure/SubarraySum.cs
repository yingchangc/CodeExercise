using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class SubarraySum
    {
        /// <summary>
        /// 138
        /// subarray sum
        /// http://www.lintcode.com/en/problem/subarray-sum/
        /// Given an integer array, find a subarray where the sum of numbers is zero. Your code should return the index of the first number and the index of the last number.
        /// 
        /// Example,
        /// Given[-3, 1, 2, -3, 4 -4], return [0, 2]
        /// or[1, 3] or [1,5] or [4,5].
        /// 
        /// sol.
        ///      [ -3,  1, 2, -3, 4 -4]
        /// sum [0 -3, -2, 0, -3, 1 -3]   when number Repeat, means the sum of the subarr is 0
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public List<int> SubarraySumSolver(int[] nums)
        {
            int N = nums.Length;

            int sum = 0;
           

            List<int> ans = new List<int>();
            Dictionary<int, int> lookup = new Dictionary<int, int>();

            lookup.Add(0, -1);

            for (int i = 0; i < N; i++)
            {
                sum += nums[i];
                if (!lookup.ContainsKey(sum))
                {
                    lookup.Add(sum, i);
                }
                else
                {
                    ans.Add(lookup[sum]+1);     // yic lookup[sum[i]] + 1 ~  i    because i will add back to value of earlier loc
                    ans.Add(i);

                    //break;
                }
            }

            return ans;

        }

        //325
        // https://leetcode.com/problems/maximum-size-subarray-sum-equals-k/description/
        // Maximum Size Subarray Sum Equals k
        //Given an array nums and a target value k, find the maximum length of a subarray that sums to k. If there isn't one, return 0 instead.
        //
        //Note:
        //The sum of the entire nums array is guaranteed to fit within the 32-bit signed integer range.
        //
        //Example 1:
        //Given nums = [1, -1, 5, -2, 3], k = 3,
        //return 4. (because the subarray[1, -1, 5, -2] sums to 3 and is the longest)
        //
        //Example 2:
        //Given nums = [-2, -1, 2, 1], k = 1,
        //return 2. (because the subarray[-1, 2] sums to 1 and is the longest)
        /// <summary>
        /// 
        /// sol
        /// nums =   [1, -1, 5, -2, 3], k = 3,
        /// sum = [0, 1,  0, 5,  3, 6]
        /// 
        /// for each sum  check if sum-k exist?
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSubArrayLen(int[] nums, int k)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();   // sum, first happen loc (since we want the longest)
            int sum = 0;
            lookup[0] = -1;

            int maxLen = 0;

            for (int i= 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (lookup.ContainsKey(sum-k))
                {   // use current sum   check if sum-k  exist earlier, and take its location
                    maxLen = Math.Max(maxLen, i - lookup[sum-k]);
                }

                // if exist earlier, don't store, since we want to find max len;
                if (!lookup.ContainsKey(sum))
                {
                    lookup.Add(sum, i);
                }
            }

            return maxLen;
        }

        /// <summary>
        /// 404. Subarray Sum II 
        /// http://www.lintcode.com/en/problem/subarray-sum-ii/
        /// Given an integer array, find a subarray where the sum of numbers is in a given interval. Your code should return the number of possible answers. 
        /// (The element in the array should be positive)
        /// 
        /// ex:
        /// Given [1,2,3,4] and interval (ie subarray sum) = 1~3, return 4. The possible answers are:
        /// 
        /// [0, 0] ie 1
        /// [0, 1]    1+2
        /// [1, 1]    2
        /// [2, 2]    3
        /// 
        /// 
        ///        [1, 2, 3,  4]
        /// sum    [1, 3, 6, 10] 
        /// 
        /// 
        /// sol:
        /// note  the value is postive, so is an increasing array
        //  leftEnd <= (sum - value)  <= RightEnd
        //  value <= sum-leftEnd        sum-RightEnd <= value
        //   use binary search to find the upper index , lower index, and collect the count 
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int subarraySumII(int[] A, int start, int end)
        {
            int len = A.Length;
            int[] sum = new int[len];
            int pre = 0;
            for (int i = 0; i < len; i++)
            {
                sum[i] = pre + A[i];
                pre = sum[i];
            }

            int ans = 0;
            for (int i = 0; i < len; i++)
            {
                if (sum[i] <=end && sum[i] >= start)
                {
                    ans++;
                }

                int vlower = sum[i] - end;
                int vupper = sum[i] - start;


                int indexLower = FindIndex(sum, vlower, len);
                int indexUpper = FindIndex(sum, vupper+1, len);
                var temp = (indexUpper - indexLower);
                ans += temp;
            }

            return ans;
        }


        private int FindIndex(int[] A, int value, int len)
        {
            int l = 0, r = len - 1, ans = 0;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (value <= A[mid])
                {
                    ans = mid;
                    r = mid - 1;
                }
                else
                    l = mid + 1;
            }
            return ans;
        }

        /// <summary>
        /// 560
        /// https://leetcode.com/problems/subarray-sum-equals-k/description/
        /// 
        /// Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.
        /// Example 1:
        /// Input:nums = [1,1,1], k = 2
        /// Output: 2
        /// Note:
        /// The length of the array is in range[1, 20, 000].
        /// The range of numbers in the array is [-1000, 1000]
        ///  and the range of the integer k is [-1e7, 1e7].
        ///  
        /// sol  simliar to sum k = 0 case but this time find total count
        /// 
        ///        1-1 1 1 -1
        ///       / / / /
        ///  sum 0 1 0 1   0
        ///      a    a              
        ///        b     b
        ///      c    c''    c
        /// ans [0 1]   [1 ,2]  -->  2
        ///   
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySumK(int[] nums, int k)
        {
            int N = nums.Length;
            int sum = 0;
            Dictionary<int, int> lookup = new Dictionary<int, int>();   // {sum, count}

            int ans = 0;

            lookup.Add(0, 1);

            for (int i = 0; i <N; i++)
            {
                sum += nums[i];

                // yic must compute ans first
                // ex   sum    0    1  0  -1  0
                //      count  [1]  1   -------------->   match 0,  ans += 1  and then ++0's count
                //             1    1  [2] 1   ------->   match 0,   ans += 2  because we can have 2 choice for the 3rd 0 
                //                             
                if (lookup.ContainsKey(sum - k))
                {
                    ans += lookup[sum - k];
                }

                // add sum count
                if (!lookup.ContainsKey(sum))
                {
                    lookup.Add(sum, 1);
                }
                else
                {
                    lookup[sum]++;
                } 
            }

            return ans;
        }
    }
}
