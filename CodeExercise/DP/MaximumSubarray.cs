using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class MaximumSubarray
    {
        public int MinSubarray(int[] nums)
        {

            int ans = Int32.MaxValue;
            int sum = 0;
            int preMax = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                ans = Math.Min(ans, sum-preMax);

                preMax = Math.Max(preMax, sum);
            }

            // compare with jiuzhang
            int size = nums.Length;
            int[] copy = new int[size];
            /*Get negative copy*/
            for (int i = 0; i < size; i++)
            {
                copy[i] = -1 * nums[i];
            }


            int max = Int32.MinValue;
            int minSum = 0;

            int ans2 = Int32.MaxValue;
            for (int i = 0; i < size; i++)
            {
                sum += copy[i];
                max = Math.Max(max, sum - minSum);
                minSum = Math.Min(sum, minSum);
                int left_min = -1 * max;

                ans2 = Math.Min(ans2, left_min);
            }

            // ans2 == ans;
            return ans;
        }

        /// <summary>
        /// 620. Maximum Subarray IV
        /// https://www.lintcode.com/problem/maximum-subarray-iv/description
        /// Given an integer arrays, find a contiguous subarray which has the largest sum, note length should be greater or equal to given length k.
        /// Return the largest sum, return 0 if there are fewer than k elements in the array.
        /// 
        /// Example
        /// Given the array[-2, 2, -3, 4, -1, 2, 1, -5, 3] and k = 5, the contiguous subarray[2, -3, 4, -1, 2, 1] has the largest sum = 5.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSubarray4(int[] nums, int k)
        {
            int len = nums.Length;

            if (len < k)
            {
                return 0;
            }

            int preKminV = 0;
            int sum = 0;
            Queue<int> que = new Queue<int>();
            int ans = Int32.MinValue;
            for (int i = 0; i <len; i++)
            {
                sum += nums[i];

                que.Enqueue(sum);

                if (que.Count == k)
                {
                    ans = Math.Max(sum - preKminV, ans); ;     // (1) compute with pre k Min
                    preKminV = Math.Min(preKminV, que.Dequeue());   // (2) update pre k min
                }  
            }

            return ans;
        }


        /// <summary>
        /// 53. Maximum Subarray
        /// https://leetcode.com/problems/maximum-subarray/description/
        /// Find the contiguous subarray within an array (containing at least one number) which has the largest sum. 
        ///        For example, given the array[-2, 1, -3, 4, -1, 2, 1, -5, 4],
        ///        the contiguous subarray[4, -1, 2, 1] has the largest sum = 6.
        ///          click to show more practice.
        ///          More practice: 
        /// If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
        ///
        /// sol:
        /// just like fib    f(i) = max(num[i], nums[i]+f(i-1))
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArrayPractice(int[] nums)
        {
            int currSum = 0;

            int ans = Int32.MinValue;
            int preAccuMin = 0;

            foreach(var num in nums)
            {
                currSum += num;

                int localMax =  currSum - preAccuMin;

                // yic don't forget
                ans = Math.Max(localMax, ans);


                preAccuMin = Math.Min(currSum, preAccuMin);

            }
            return ans;
        }


        public int MaxSubArraySolver(int[] nums)
        {
            int N = nums.GetLength(0);
            int[] F = new int[N + 1];

            F[0] = 0;
            int ans = Int32.MinValue;
            for (int i = 1; i <= N; i ++)
            {
                F[i] = Math.Max(F[i - 1] + nums[i - 1], nums[i-1]);
                ans = Math.Max(ans, F[i]);
            }

            return ans;




            //int len = nums.Length;
            //int pre = 0;

            //int maxV = Int32.MinValue;
            //for(int i = 0; i < len; i++)
            //{
            //    int curr = Math.Max(pre + nums[i], nums[i]);
            //    maxV = Math.Max(curr, maxV);
            //    pre = curr;
            //}

            //return maxV;
        }

        
    }
}
