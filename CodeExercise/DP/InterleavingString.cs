using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class InterleavingString
    {
        /// <summary>
        /// 97. Interleaving String
        /// https://leetcode.com/problems/interleaving-string/description/
        /// Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.
        /// 
        /// For example,
        /// Given:
        /// s1 = "aabcc",
        /// s2 = "dbbca",
        /// 
        /// When s3 = "aadbbcbcac", return true.
        /// When s3 = "aadbbbaccc", return false.
        /// 
        /// F[i,j] = F[i-1,j] && X[i+j-1] == A[i-1] || F[i,j-1] && X[i+j-1] == B[j-1]
        /// 
        /// 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public bool IsInterleave(string s1, string s2, string s3)
        {
            int M = s1.Length;
            int N = s2.Length;
            int Z = s3.Length;
            if ((M+N) != Z)
            {
                return false;
            }

            bool[,] F = new bool[M + 1, N + 1];

            for (int i =0; i<=M; i++)
            {
                for (int j=0; j <=N; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        F[0, 0] = true;
                    }
                    else if (i == 0)
                    {
                        F[0, j] = F[0, j - 1] && (s3[i + j - 1] == s2[j - 1]);
                    }
                    else if (j == 0)
                    {
                        F[i, 0] = F[i - 1, 0] && (s3[i + j - 1] == s1[i - 1]);
                    }
                    else
                    {
                        F[i, j] = F[i, j - 1] && (s3[i + j - 1] == s2[j - 1]) ||
                                  F[i - 1, j] && (s3[i + j - 1] == s1[i - 1]);
                    }

                }
            }

            return F[M, N];

        }
    }
}
