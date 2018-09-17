using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class LongestCommonSubsequence
    {
        /// <summary>
        /// 77. Longest Common Subsequence 
        /// http://www.lintcode.com/en/problem/longest-common-subsequence/
        /// 
        /// Given two strings, find the longest common subsequence (LCS).
        /// Your code should return the length of LCS.
        /// 
        ///  
        ///     nu A B C D
        ///  nu 0  0 0 0 0
        ///   E 0  0 0 0 0 
        ///   A 0  1 1 1 1
        ///   C 0  1 1 2 2
        ///   B 0  1 2 2 2
        ///    
        /// sol: eql, take diagnal +1
        ///     Not eql, take left or top
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int longestCommonSubsequenceSolver(String A, String B)
        {
            int M = A.Length;
            int N = B.Length;

            int[,] F = new int[M + 1, N + 1];

            for (int j = 0; j <= M; j++)
            {
                F[j, 0] = 0;    // no common with null
            }
            for (int i = 0; i <= N; i++)
            {
                F[0, i] = 0;    // no common with null
            }

            for (int j = 1; j <= M; j++)
            {
                for (int i = 1; i <= N; i++)
                {
                    if (A[j-1] == B[i-1])
                    {
                        F[j, i] = F[j - 1, i - 1] + 1;
                    }
                    else
                    {
                        F[j, i] = Math.Max(F[j - 1, i], F[j, i - 1]);
                    }
                }
            }

            return F[M, N];
        }
    }
}
