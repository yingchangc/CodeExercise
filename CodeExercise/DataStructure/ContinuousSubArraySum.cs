using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class ContinuousSubArraySum
    {
        /// <summary>
        /// 523. Continuous Subarray Sum
        /// https://leetcode.com/problems/continuous-subarray-sum/description/
        /// iven a list of non-negative numbers and a target integer k, write a function to check if the array has a continuous subarray of size at least 2 that sums up to the multiple of k, that is, sums up to n*k where n is also an integer.
        /// 
        /// Example 1:
        /// Input: [23, 2, 4, 6, 7],  k=6
        /// Output: True
        /// Explanation: Because[2, 4] is a continuous subarray of size 2 and sums up to 6.
        /// 
        /// sol:
        /// 
        ///  use hashmap store % result, if repeat, means we find it
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckSubarraySum_best(int[] nums, int k)
        {
            Dictionary<int, int> lookupResdule = new Dictionary<int, int>();
            lookupResdule.Add(0, -1);

            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (k != 0)
                {
                    sum = sum % k;
                }

                if (lookupResdule.ContainsKey(sum) && (i - lookupResdule[sum]) >= 2)
                {
                    return true;
                }

                if (!lookupResdule.ContainsKey(sum))
                {
                    lookupResdule.Add(sum, i);
                }
            }

            return false;
        }

        public bool CheckSubarraySum(int[] nums, int k)
        {
            int len = nums.Length;

            for (int i = 0; i <len; i++)
            {
                int sum = nums[i];
                for (int j = i+1; j <len; j++)
                {
                    sum += nums[j];

                    if (sum ==0 && k == 0)
                    {
                        return true;
                    }
                    else if (sum != 0 && k ==0)
                    {
                        continue;  // otherwise, will throw exception
                    }
                    else if (sum % k == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// lint 402
        /// https://www.lintcode.com/en/old/problem/continuous-subarray-sum/
        /// Given an integer array, find a continuous subarray where the sum of numbers is the biggest. 
        /// Your code should return the index of the first number and the index of the last number. 
        /// (If their are duplicate answer, return anyone)
        /// 
        /// Give [-3, 1, 3, -3, 4], return [1,4].
        /// 
        // preSum + curr  > curr   keep use left, update right     preSum = preSum + curr
        // preSum + curr <= curr   change left to curr      preSum = curr
        /// 
        /// 
        /// keep track gMax vs preSum
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public List<int> ContinuousSubarraySumSolver(int[] arr)
        {
            if (arr ==null || arr.Length == 0)
            {
                return null;
            }

            int preMin = 0;
            int sum = 0;
            List<int> ans = null;
            int idx1 = -1;
            int idx2 = 0;
            int maxV = Int32.MinValue;

            for(int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                int currMax = sum - preMin;

                if (currMax > maxV)
                {
                    maxV = currMax;

                    // update loc
                    ans = new List<int>() { idx1 + 1, i };
                }

                if (preMin > sum)
                {
                    preMin = sum;
                    idx1 = i;
                }
            }

            return ans;
        }


        public List<int> ContinuousSubarraySumSolver_old(int[] arr)
        {
            if (arr.Length == 0)
            {
                return null;
            }

            // yic  start from index 0 to prevent corner case
            int left = 0;
            int right = 0;
            int gMax = arr[0];
            int preSum = arr[0];
            List<int> ans = new List<int>() { left, right};

            for (int i = 1; i < arr.Length; i++)
            {
                if ((preSum + arr[i]) > arr[i])
                {
                    // keep expanding
                    preSum = preSum + arr[i];
                    right = i;
                }
                else
                {
                    // reset to curr loc
                    preSum = arr[i];
                    left = i;
                    right = i;
                }

                if (gMax < preSum)
                {
                    gMax = preSum;
                    ans.Clear();
                    ans.Add(left);
                    ans.Add(right);
                }
            }

            return ans;
        }
    }
}
