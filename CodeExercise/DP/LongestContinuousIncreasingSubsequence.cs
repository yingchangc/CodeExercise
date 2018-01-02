using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    /// <summary>
    /// 674
    /// Given an unsorted array of integers, find the length of longest continuous increasing subsequence (subarray). 
    /// Example 1:
    /// Input: [1,3,5,4,7]
    /// Output: 3
    /// Explanation: The longest continuous increasing subsequence is [1,3,5], its length is 3. 
    /// Even though[1, 3, 5, 7] is also an increasing subsequence, it's not a continuous one where 5 and 7 are separated by 4. 
    /// 
    /// Example 2:
    /// Input: [2,2,2,2,2]
    ///     Output: 1
    /// Explanation: The longest continuous increasing subsequence is [2], its length is 1. 
    /// </summary>
    class LongestContinuousIncreasingSubsequence
    {
        public int FindLengthOfLCIS(int[] nums)
        {
            int len = nums.Length;
            if (len == 0)
            {
                return 0;
            }

            int maxLen = 1;
            int currLen = 1;
            int pre = nums[0];

            for (int i =1; i<nums.Length; i++)
            {
                if(pre < nums[i])
                {
                    currLen++;
                    maxLen = Math.Max(maxLen, currLen);     
                }
                else
                {
                    // reset 
                    currLen = 1;
                }

                // update pre
                pre = nums[i];
            }

            return maxLen;

        }
    }

    class LongestIncreasingSubsequence
    {
        /// <summary>
        /// 673
        /// https://leetcode.com/problems/number-of-longest-increasing-subsequence/solution/
        /// https://www.youtube.com/watch?v=CE2b_-XfVDk
        /// 
        /// Given an unsorted array of integers, find the number of longest increasing subsequence. 
        ///         Example 1:
        /// Input: [1,3,5,4,7]
        ///         Output: 2
        /// Explanation: The two longest increasing subsequence are[1, 3, 4, 7] and[1, 3, 5, 7].
        /// 
        ///         Example 2:
        /// Input: [2,2,2,2,2]
        ///         Output: 5
        /// Explanation: The length of longest continuous increasing subsequence is 1, and there are 5 subsequences' length is 1, so output 5.
        /// </summary>
        /// 
        /// Note: LIS [7 1 2 4 5 3]
        /// 
        /// 
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindNumberOfLIS(int[] nums)
        {
            int len = nums.Length;
            int[] res = new int[len];
            int[] numMaxCount = new int[len];

            // set default ans to 1 for each position
            for(int i = 0; i < len; i++)
            {
                res[i] = 1;
                numMaxCount[i] = 1;
            }

            // cache the longest to find the number of longest
            int longest = 1;

            for (int j = 0; j < len; j++)
            {
                for (int i = 0; i<j; i++)
                {
                    if (nums[i] < nums[j])
                    {
                        //goal : res[j] = Math.Max(res[j], res[i] + 1);

                        if (res[j] < (res[i] + 1))
                        {
                            // reset max for the position j
                            res[j] = res[i] + 1;
                            numMaxCount[j] = numMaxCount[i];
                        }
                        else if (res[j] == (res[i] + 1))
                        {
                            // some other pre position can also add up to the same count
                            numMaxCount[j] += numMaxCount[i];   // yic  check  [1 2 3 4 5 4 7] case  the max count = 3
                        }

                        longest = Math.Max(longest, res[j]);
                    }
                }
            }

            int ans = 0;

            for (int k = 0; k < len; k++)
            {
                if (res[k] == longest)
                {
                    ans += numMaxCount[k];
                }
            }

            return ans;

        }
    }
}
