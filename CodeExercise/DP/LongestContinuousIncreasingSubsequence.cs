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

            int startIndex = 0;

            int ans = 1;

            for (int i = 1; i < len; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    ans = Math.Max(ans, i - startIndex + 1);
                }
                else
                {
                    startIndex = i;
                }
            }

            // if left and right need to be considered
            //startIndex = 0;
            //for (int i = 1; i < len; i++)
            //{
            //    if (nums[i] < nums[i - 1])
            //    {
            //        ans = Math.Max(ans, i - startIndex + 1);
            //    }
            //    else
            //    {
            //        startIndex = i;
            //    }
            //}

            return ans;


        }
    }

    class LongestConsecutiveSequence
    {
        /// <summary>
        /// 128
        /// Given an unsorted array of integers, find the length of the longest consecutive elements sequence. 
        ///        For example,
        ///        Given[100, 4, 200, 1, 3, 2],
        ///        The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4. 
        ///
        /// Your algorithm should run in O(n) complexity.
        /// 
        /// find a random location to start and choose any other location to find consecutuve
        /// 
        /// Use hashSet to memo nums, find a number that has no pre consecutive num to check
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutiveSolver(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            HashSet<int> memo = new HashSet<int>();
            foreach(int num in nums)
            {
                memo.Add(num);
            }


            int maxLen = 0;

            foreach(int num in nums)
            {
                // find start number;  ex 100, 200, 1 in the example
                if (!memo.Contains(num - 1))
                {
                    int currLen = 0;
                    int temp = num;
                    while(memo.Contains(temp))
                    {
                        currLen++;
                        maxLen = Math.Max(currLen, maxLen);
                        temp++;
                    }
                }
            }

            return maxLen;
        }
    }

    class LongestIncreasingSubsequence
    {
        /// <summary>
        /// 300
        /// 
        /// O(n^2 ) https://www.youtube.com/watch?v=CE2b_-XfVDk
        /// O(nlongn)https://www.youtube.com/watch?v=S9oUiVYEq7E
        /// 
        /// Given an unsorted array of integers, find the length of longest increasing subsequence. 
        ///        For example,
        ///        Given[10, 9, 2, 5, 3, 7, 101, 18],
        ///        The longest increasing subsequence is [2, 3, 7, 101], therefore the length is 4. Note that there may be more than one LIS combination, it is only necessary for you to return the length.
        ///Your algorithm should run in O(n2) complexity.
        ///
        /// Sol
        /// F[j] = max (1 self,    f[i]+1 if a[j] > a[i] 
        /// 
        /// 
        ///Follow up: Could you improve it to O(n log n) time complexity?   check the next sol  LengthOfLIS_ONlongN
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            int N = nums.Length;
            if (N==0)
            {
                return 0;
            }

            int[] F = new int[N];     // this question use 0~N-1 
            int ans = 1;              // at least one length

            for (int j = 0; j < N; j++)
            {
                F[j] = 1;   // init

                for (int i = 0; i < j; i++)
                {
                    if (nums[j] > nums[i])
                    {
                        F[j] = Math.Max(F[j], F[i] + 1);

                        ans = Math.Max(F[j], ans);
                    }
                }  
            }

            return ans;
        }

        //Sol
        /// 
        public int LengthOfLIS_ONlongN(int[] nums)
        {
            int N = nums.Length;
            if (N == 0)
            {
                return 0;
            }

            int[] F = new int[N+1];
            F[0] = Int32.MinValue;

            int AnsLast = 0;       

            for (int j = 1; j <= N; j++)
            {
                // inserting new Aj
                int Aj = nums[j - 1];

                int start = 0;
                int last = AnsLast;

                // find the last Fi < Aj   and insert/replace to F i+1 // relplace i +1  because its value is smaller and lengh contributation is the same.
                while (start <= last)
                {
                    int midIdx = start + (last - start) / 2;
                    int midV = F[midIdx];
                    if (Aj <= midV)
                    {
                        last = midIdx - 1;
                    }
                    else
                    {
                        start = midIdx + 1;
                    }

                }
                F[last + 1] = Aj;     

                if ((last+1) > AnsLast)
                {
                    AnsLast = last+1;
                }

            }

            return AnsLast;
        }

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
        /// Note: LIS [ 1 2 4 3 5 4 7 2]
        /// 
        /// len   [ 1 2 3 3 4 4 5 2]
        /// count [ 1 1 1 1 2 1 3 1]   //  note  max len = 5, count = 2+1 =3
        /// 
        /// 
        /// time O(n^2)
        /// space O(n)
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindNumberOfLIS(int[] nums)
        {
            int len = nums.Length;
            int[] lenghts = new int[len];
            int[] numMaxCount = new int[len];

            // set default ans to 1 for each position
            for(int i = 0; i < len; i++)
            {
                lenghts[i] = 1;
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
                        //goal : lenghts[j] = Math.Max(lenghts[j], lenghts[i] + 1);

                        if (lenghts[j] < (lenghts[i] + 1))
                        {
                            // lenghtset max for the position j
                            lenghts[j] = lenghts[i] + 1;
                            numMaxCount[j] = numMaxCount[i];
                        }
                        else if (lenghts[j] == (lenghts[i] + 1))
                        {
                            // some other pre position can also add up to the same count
                            numMaxCount[j] += numMaxCount[i];   // yic  check  [1 2 3 4 5 4 7] case  the max count = 3
                        }

                        longest = Math.Max(longest, lenghts[j]);
                    }
                }
            }

            int ans = 0;

            for (int k = 0; k < len; k++)
            {
                if (lenghts[k] == longest)
                {
                    ans += numMaxCount[k];
                }
            }

            return ans;

        }
    }
}
