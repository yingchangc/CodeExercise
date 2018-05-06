using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class SubmatrixSum
    {
        /// <summary>
        /// lint 405 
        /// https://www.lintcode.com/en/old/problem/submatrix-sum/
        /// Given an integer matrix, find a submatrix where the sum of numbers is zero. Your code should return the coordinate of the left-up and right-down number.
        /// Given matrix
        /// 
        ///ex,
        // [
        //  [1 ,5 ,7],
        //  [3 ,7 ,-8],
        //  [4 ,-8 ,9],
        // ]
        /// return [(1, 1), (2, 2)]
        /// 
        //  because
        // [
        //  [7 ,-8],
        //  [-8 ,9],
        // ]
        /// 
        /// sol:
        /// 
        /// The same trick as SubArraySum that use map to find duplicate value, means the region sum is 0
        /// 
        /// do precompure matrix
        /// use j1 and j2 to fix the y region,     
        /// 
        /// region   i=0~N,     if at i's region sum already exits in map, find it's revious i'
        /// 
        ///    
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[,] SubmatrixSumSolver(int[,] matrix)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            int[,] sumMatrix = new int[M + 1, N + 1];
            preComputeSum(matrix, sumMatrix);

            int[,] result = new int[2, 2];
            result[0, 0] = -1;
            result[0, 1] = -1;
            result[1, 0] = -1;
            result[1, 1] = -1;

            for (int j1 = 0; j1 <=M; j1++)
            {
                for (int j2 = j1+1; j2 <= M; j2++)
                {
                    Dictionary<int, int> lookup = new Dictionary<int, int>();

                    for (int i = 0; i <= N; i++)
                    {
                        int currRegionSum = sumMatrix[j2, i] - sumMatrix[j1,i];

                        if (lookup.ContainsKey(currRegionSum))
                        {
                            // find region has the same value as previous region, current region cause sum = 0
                            var prelocI = lookup[currRegionSum];
                            result[0, 0] = j1 + 1 - 1;  //-1 for acutal matrix loc
                            result[0, 1] = prelocI + 1 -1;  // +1  shift right, -1 for acutal matrix loc
                            result[1, 0] = j2-1;
                            result[1, 1] = i-1;

                            return result;
                        }
                        lookup.Add(currRegionSum, i);
                    }
                }
            }

            return result;
        }

        private void preComputeSum(int[,] matrix, int[,] sumMatrix)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            // place padding
            for (int j = 0; j <=M; j++)
            {
                sumMatrix[j, 0] = 0;
            }

            for (int i = 0; i <= N; i++)
            {
                sumMatrix[0, i] = 0;
            }

            // compute sum from (left + top - top_left) + currLocValue
            for (int j = 1; j <=M; j++)
            {
                for (int i = 1; i <=N; i++)
                {
                    sumMatrix[j, i] = sumMatrix[j - 1, i] + sumMatrix[j, i - 1] - sumMatrix[j - 1, i - 1] + matrix[j - 1, i - 1];
                }
            }
        }
    }

    
}
