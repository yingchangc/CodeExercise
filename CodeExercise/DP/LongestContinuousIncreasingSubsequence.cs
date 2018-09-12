using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    /// <summary>
    /// 674
    /// https://leetcode.com/problems/longest-continuous-increasing-subsequence/description/
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
            if (nums ==null || nums.Length == 0)
            {
                return 0;
            }

            int[] lenCount = new int[nums.Length];

            lenCount[0] = 1;
            int pre = nums[0];
            int maxLen = 1;

            for(int i = 1; i <nums.Length; i++)
            {
                if (nums[i] > pre)
                {
                    lenCount[i] = lenCount[i - 1] + 1;
                    maxLen = Math.Max(lenCount[i], maxLen);
                }
                else
                {
                    lenCount[i] = 1;
                }

                pre = nums[i];
            }

            return maxLen;
        } 
    }

    class LongestIncreasingContinuousSubsequence2
    {
        /// <summary>
        /// Lint 398
        /// http://www.lintcode.com/en/problem/longest-increasing-continuous-subsequence-ii/
        /// 
        /// Give you an integer matrix (with row size n, column size m)，find the longest increasing continuous subsequence in this matrix. 
        /// (The definition of the longest increasing continuous subsequence here can start at any row or column and go up/down/right/left any direction).
        /// 
        ///                {
        ///                  {1, 5,  3 },
        ///                  {4, 10, 9 },
        ///                  {2, 8,  7 }
        ///                };
        /// 
        /// sol:
        /// 
        /// get F[j,i] as bigger from all corner and mark as visited
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int LongestIncreasingContinuousSubsequenceIIPractice_slow(int[,] A)
        {
            if (A == null)
            {
                return 0;
            }

            int height = A.GetLength(0);
            int width = A.GetLength(1);
            bool[,] visited = new bool[height, width];

            int ans = 0;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i<width; i++)
                {
                    visited[j, i] = true;
                    int temp = DFS(A, j, i, visited, width, height);
                    ans = Math.Max(ans, temp);
                    visited[j, i] = false;
                }
            }

            return ans;
        }

        private int DFS(int[,] A, int j, int i, bool[,] visited, int width, int height)
        {       
            int[] deltaX = { -1, 0, 1, 0 };
            int[] deltaY = { 0, -1, 0, 1 };

            int childDepth = 0;
            for (int k = 0; k <4; k++)
            {
                int newY = j + deltaY[k];
                int newX = i + deltaX[k];

                if (newY>=0 && newY <height && newX>=0 && newX < width && visited[newY, newX] ==false && A[j,i] <A[newY, newX])
                {
                    visited[newY, newX] = true;
                    int temp = DFS(A, newY, newX, visited, width, height);
                    childDepth = Math.Max(childDepth, temp);
                    visited[newY, newX] = false;
                }
            }
            return 1 + childDepth;
        }


        public int LongestIncreasingContinuousSubsequenceIISolver(int[,] A)
        {
            if (A == null)
            {
                return 0;
            }

            int M = A.GetLength(0);
            int N = A.GetLength(1);

            int[,] F = new int[M, N];
            bool[,] visited = new bool[M, N];

            int ans = 0;
            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i <N; i++)
                {
                    int len = LongestIncreasingContinuousSubsequenceIIHelper(A, F, visited, j, i, M, N);
                    ans = Math.Max(ans, len);
                }
            }

            return ans;
        }

        private int LongestIncreasingContinuousSubsequenceIIHelper(int[,] A, int[,] F, bool[,] visited, int j, int i, int M, int N)
        {
            if (visited[j,i] == true)
            {
                return F[j, i];
            }

            // will not have loop be cause recursive only happen when neighber is smaller, wont come back to curr (j,i)
            // 

            int[] deltaXs = { -1, 1, 0, 0 };
            int[] deltaYs = {  0, 0, 1,-1 };

            F[j, i] = 1;  // init len is itself


            for (int k = 0; k <4; k++)
            {
                int nx = i + deltaXs[k];
                int ny = j + deltaYs[k];
                if (nx >= 0 && nx < N && ny >= 0 && ny < M && A[j, i] > A[ny, nx])
                {
                    int preLen = LongestIncreasingContinuousSubsequenceIIHelper(A, F, visited, ny, nx, M, N);
                    F[j, i] = Math.Max(F[j, i], (preLen + 1));
                }
            }

            visited[j, i] = true;   // mark when done

            return F[j, i];
            
        }
    }

    class LongestConsecutiveSequence
    {
        /// <summary>
        /// 128
        /// https://leetcode.com/problems/longest-consecutive-sequence/description/
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
        /// 
        /// Time complexity : O(n)
        ///
        ///Although the time complexity appears to be quadratic due to the while loop nested within the for loop, closer inspection reveals it to be linear.Because the while loop is reached only when currentNum marks the beginning of a sequence(i.e.currentNum-1 is not present in nums), the while loop can only run for nn iterations throughout the entire runtime of the algorithm.This means that despite looking like O(n \cdot n)O(n⋅n) complexity, the nested loops actually run in O(n + n) = O(n)O(n+n)=O(n) time.All other computations occur in constant time, so the overall runtime is linear.
        ///
        ///Space complexity : O(n)
        ///
        ///In order to set up O(1)containment lookups, we allocate linear space for a hash table to store the O(n)O(n) numbers in nums.Other than that, the space complexity is identical to that of the brute force solution.
        ///

        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutiveSolver(int[] nums)
        {
            if (nums==null || nums.Length == 0)
            {
                return 0;
            }

            HashSet<int> lookup = new HashSet<int>();
            foreach(int n in nums)
            {
                lookup.Add(n);
            }

            int maxLen = 1;

            foreach(int n in nums)
            {
                int currCount = 1;
                int temp = n;
                // lookfor Smallest in consecutive
                // only move on when smallest,   so only iterate once O(n)  in the end,
                if (!lookup.Contains(n-1))
                {
                    while(lookup.Contains(temp+1))
                    {
                        currCount++;
                        temp++;
                        maxLen = Math.Max(maxLen, currCount);
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
        ///Your algorithm should run in O(n^2) complexity.
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
            if (nums ==null || nums.Length ==0)
            {
                return 0;
            }

            int[] F = new int[nums.Length];
            for (int i = 0; i <nums.Length; i++)
            {
                F[i] = 1;
            }

            int ans = 1;

            for (int i =0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        F[i] = Math.Max(F[i], F[j] + 1);
                        ans = Math.Max(F[i], ans);
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
        ///     len   [ 1 2 3 3 4 4 5 2]
        ///     count [ 1 1 1 1 2 1 3 1]   //  note  max len = 5, count = 2+1 =3
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
                        {   // 1 2 5     [6]
                            // 1 2 4     [6]   both 4 and 5 contrubute to maxLen for 6. need to combine
                            // some other pre position can also add up to the same count
                            numMaxCount[j] += numMaxCount[i];   // yic  check  [1 2 3 4 5 4 7] case  the max count = 3
                        }

                        longest = Math.Max(longest, lenghts[j]);
                    }
                }
            }

            int ans = 0;
            // compute the final maxlen combine  6 5 3    => 1+1+1
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
