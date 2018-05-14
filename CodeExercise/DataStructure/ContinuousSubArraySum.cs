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
