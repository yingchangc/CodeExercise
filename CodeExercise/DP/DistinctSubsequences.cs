using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class DistinctSubsequences
    {
        /// <summary>
        /// Given a string S and a string T, count the number of distinct subsequences of S which equals T.
        /// A subsequence of a string is a new string which is formed from the original string by deleting some(can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).
        /// 
        /// Here is an example:
        /// S = "rabbbit", T = "rabbit"
        /// 
        /// Return 3.
        /// 
        /// Sol:
        /// 
        /// F[i,j]   start from A[i] and B[j] number of choices
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int NumDistinct(string s, string t)
        {
            int M = s.Length;
            int N = t.Length;

            if (N == 0)
            {
                return 0;
            }

            bool[,] visited = new bool[M, N];
            int[,] F = new int[M, N];

            int ans = NumDistinckHelper(s, t, visited, F, 0, 0, M, N);

            return ans;
        }

        private int NumDistinckHelper(string s, string t, bool[,] visited, int[,] F, int i, int j, int M, int N)
        {
            if(i >=M && j < N)
            {
                // cannot find char to compare in A, B not finish
                return 0;
            }
            else if (j >= N)
            {
                // exceed B, match happen
                return 1;
            }

            if (visited[i,j])
            {
                return F[i, j];
            }

            int count = 0;

            for (int k = i; k < M; k++)
            {
                if (s[k] == t[j])
                {
                    count += NumDistinckHelper(s, t, visited, F, k + 1, j + 1, M,N);
                }
            }

            F[i, j] = count;

            visited[i, j] = true;

            return F[i, j];
        }
    }
}
