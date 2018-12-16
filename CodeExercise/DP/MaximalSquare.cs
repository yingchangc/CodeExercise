using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class MaximalSquare
    {
        /// <summary>
        /// 221. Maximal Square
        /// https://leetcode.com/problems/maximal-square/description/
        /// Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.
        ///
        ///For example, given the following matrix:
        ///
        ///1 0 1 0 0
        ///1 0 1 1 1
        ///1 1 1 1 1
        ///1 0 0 1 0
        ///
        ///Return 4.
        ///
        ///   1 0
        ///   1 1     check left up and diag,  find can be itself because up block the longest length
        /// 
        /// sol 
        /// 
        /// F[j,i]  at positing (i,j) as botton right corner,  what is the max len for square
        /// 
        ///    if matrix[j,i] == 1
        ///         check Left and Diag and UP to see the smallest   F[j,i] = 1+ smallestNum
        ///    else       
        ///         F[j,i] = 0
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalSquareSolver(char[,] matrix)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            int[,] F = new int[M+1, N+1];

            int maxLen = 0;

            for (int j = 1; j <= M; j++)
            {
                for (int i =1; i <= N; i++)
                {
                    if (matrix[j-1,i-1] == '1')
                    {
                        int diag = F[j - 1, i - 1];
                        int up = F[j - 1, i];
                        int left = F[j, i - 1];

                        F[j, i] = Math.Min(diag, Math.Min(up, left)) + 1;

                        maxLen = Math.Max(F[j, i], maxLen);
                    }
                    else
                    {
                        F[j, i] = 0;
                    }
                }
            }

            return maxLen* maxLen;
        }
    }
}
