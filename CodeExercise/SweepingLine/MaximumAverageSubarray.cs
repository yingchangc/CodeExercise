using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SweepingLine
{
    class MaximumAverageSubarray
    {
        /// <summary>
        /// 644. Maximum Average Subarray II
        /// Given an array consisting of n integers, find the contiguous subarray whose length is greater than or equal to k that has the maximum average value. And you need to output the maximum average value.
        /// Example 1:
        /// Input: [1,12,-5,-6,50,3], k = 4
        /// Output: 12.75
        /// Explanation:
        /// when length is 5, maximum average value is 10.8,
        /// when length is 6, maximum average value is 9.16667.
        /// Thus return 12.75.
        /// Note:
        /// Elements of the given array will be in range[-10, 000, 10, 000].
        /// The answer with the calculation error less than 10-5 will be accepted.
        /// 
        /// sol: 
        ///              [1, 2, 3, 4 ]  k = 3       ans should be (2,3,4)/3=3
        /// AssuSum      [1, 3, 6, 10] 
        /// 
        /// sum diff[[0] -2,-3,-3,-2]   add 0 padding
        /// 
        /// guess avg = 2
        ///          pre_min locate in index i,   note should not use Accum sum min, use sum diff because the longer, the min it can be. 
        ///          Sometimes it is not wise to choose longer range because when avg is big, the longer, the more minus
        ///         (sumdiff[j] - sumdiff[i])   >= 0   means avg can be bigger 
        ///         
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double FindMaxAverage2(int[] nums, int k)
        {
            double right = getMaxVal(nums);
            double left = getMinVal(nums);
            double precision = 0.00001;

            while ((right-left) > precision)
            {
                double avg = left + (right - left) / 2;

                if (checkCanBigger(nums, k, avg))
                {
                    left = avg;
                }
                else
                {
                    right = avg;
                }
            }

            return left;
        }

        // sumArr  is len of nums +1
        private bool checkCanBigger(int[] nums, int k, double avg)
        {
            int N = nums.GetLength(0);   // 0~N   (N+1) with padding

            double[] sumArr = new double[N + 1];

            double preSumMin = sumArr[0];
            int preMinIdx = 0;

            // start from kth
            for (int i = 1; i <= N; i++)
            {
                sumArr[i] = nums[i-1] - avg + sumArr[i - 1];
                if (i < k)
                {
                    continue;
                }
                double maxIncreaseInRegion = (sumArr[i] - preSumMin);
                if (maxIncreaseInRegion >= 0)
                {
                    return true;
                }

                // the range can be getting bigger than k if preMin is far away
                // before mvoe to next i,now update preSumMin for next one.
                if (preSumMin > sumArr[(i - k) + 1])
                {
                    preMinIdx = (i - k) + 1;
                    preSumMin = sumArr[(i - k) + 1];
                }
                
            }

            return false;
        }

        

        private int getMaxVal(int[] nums)
        {
            int N = nums.GetLength(0);
            int max = Int32.MinValue;
            for (int i = 0; i < N; i++)
            {
                max = Math.Max(nums[i], max);
            }

            return max;
        }

        private int getMinVal(int[] nums)
        {
            int N = nums.GetLength(0);
            int min = Int32.MaxValue;
            for (int i = 0; i < N; i++)
            {
                min = Math.Min(nums[i], min);
            }

            return min;
        }

        /// <summary>
        /// 643. Maximum Average Subarray I
        /// https://leetcode.com/problems/maximum-average-subarray-i/description/
        /// 
        /// Given an array consisting of n integers, find the contiguous subarray of given length k that has the maximum average value. And you need to output the maximum average value.

        /// Example 1:
        /// Input: [1,12,-5,-6,50,3], k = 4
        /// Output: 12.75
        /// Explanation: Maximum average is (12-5-6+50)/4 = 51/4 = 12.75
        /// Note:
        /// Elements of the given array will be in the range[-10, 000, 10, 000].
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double FindMaxAveragePractice(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            double ans = Int32.MinValue;    // yic
            double sum = 0;
            double preKMin = 0;
            Queue<double> que = new Queue<double>();

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                que.Enqueue(sum);

                if(que.Count == k)
                {
                    ans = Math.Max((sum - preKMin)/ k, ans);
                    preKMin = que.Dequeue();
                }
            }
            

            return ans;
        }
        public double FindMaxAverage(int[] nums, int k)
        {
            double sum = 0;

            for (int i = 0; i < k; i++)
            {
                sum += nums[i];
            }

            double ans = sum/k;

            for (int i= k; i < nums.GetLength(0); i++)
            {
                sum -= nums[i - k];
                sum += nums[i];

                ans = Math.Max(ans, sum/k);
            }

            return ans;
        }
    }
}
