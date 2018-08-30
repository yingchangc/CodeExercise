using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MaximumSubmatrix
    {
        /// <summary>
        /// 944. Maximum Submatrix
        /// Given an n x n matrix of positive and negative integers, find the submatrix with the largest possible sum.
        /// 
        /// Example
        /// Given matrix =
        /// [
        ///     [1, 3, -1],
        ///     [2,3,-2],
        ///     [-1,-2,-3]
        /// ]
        /// return 9.
        /// Explanation:
        /// the submatrix with the largest possible sum is:
        /// [
        /// [1,2],
        /// [2,3]
        /// ]
        /// 
        /// 
        /// Sol:
        /// 枚举子矩阵的上下边界 up & down, 然后将这之间的数压缩为一个一维数组（降维攻击），剩下的任务就是一维数组如何求 Maximum Subarray 了。
        /// 
        /// set (up - down) range,  make it from 2d to 1d sum
        /// then find max subarry sum
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaxSubmatrixSolver(int[,] matrix)
        {
            if (matrix == null)
            {
                return 0;
            }

            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            if (M == 0 || N == 0)
            {
                return 0;
            }

            int maxV = Int32.MinValue;

            for (int up = 0; up < M; up++)
            {
                for (int dwn = up; dwn <M; dwn++)
                {
                    int[] arr = CompressTo1D(matrix, up, dwn, N);

                    int currMax = FindMaxSubarray(arr);
                    maxV = Math.Max(currMax, maxV);
                }
            }

            return maxV;
        }

        private int[] CompressTo1D(int[,] matrix, int up, int dwn, int len)
        {
            int[] arr = new int[len]; 

            for (int i = 0; i <len; i++)
            {
                for (int j = up; j <=dwn; j++)
                {
                    arr[i] += matrix[j, i];
                }
            }

            return arr;
        }

        private int FindMaxSubarray(int[] arr)
        {
            // same as
            /*
             *  int min = 0, max = Integer.MIN_VALUE, sum = 0;
    
                for (int i = 0; i < m; i++) {
                  sum += arr[i];
                  max = Math.max(max, sum - min);
                  min = Math.min(min, sum);
                }
    
                return max;
             */


            int len = arr.Length;
            int pre = arr[0];
            int maxV = pre;
            for (int i = 1; i < len; i++)
            {
                pre = Math.Max(arr[i], arr[i] + pre);
                maxV = Math.Max(maxV, pre);
            }

            return maxV;
        }


        public int MaxSubmatrixSolver_slow(int[,] matrix)
        {
            if (matrix == null)
            {
                return 0;
            }

            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            if (M == 0 || N ==0)
            {
                return 0;
            }

            int[,] memo = new int[M + 1, N + 1];

            PreCompuateMatrix(matrix, memo);

            int maxV = Int32.MinValue;

            for (int j =0; j <M; j++)
            {
                for (int i=0; i <N;i++)
                {
                    for (int k = j+1; k <= M; k++)
                    {
                        for (int p = i+1; p<=N; p++)
                        {
                            int subSum = memo[k, p] - memo[j, p] - memo[k, i] + memo[j, i];
                            maxV = Math.Max(subSum, maxV);
                        }
                    }
                    
                }
            }

            return maxV;
        }

        private void PreCompuateMatrix(int[,] matrix, int[,] memo)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            for (int j= 1; j <=M; j++)
            {
                for (int i = 1; i<=N;i++)
                {
                    // memo is size (M+1)*(N+1)
                    //           left + top - topleft + slef
                    memo[j, i] = memo[j - 1, i] + memo[j, i - 1] - memo[j - 1, i - 1] + matrix[j - 1, i - 1]; 
                }
            }
        }
    }
}
