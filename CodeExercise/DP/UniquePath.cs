using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class UniquePath
    {
        /// <summary>
        /// 62 
        /// Unique Paths
        /// A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        /// The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
        /// How many possible unique paths are there?
        ///
        /// 𝑶(𝒎𝒏) runtime, 𝑶(𝒎𝒏) space
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumofUniquePaths(int m, int n)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();

            //start from end and back track
            return NumofUniquePathsHelper(m-1, n-1, m, n, lookup);
        }

        private int NumofUniquePathsHelper(int indexM, int indexN, int M, int N, Dictionary<int, int> lookup)
        {
            if (indexM == 0 && indexN == 0)
            {
                return 1;
            }

            int key = M * indexN + indexM;
            if (lookup.ContainsKey(key))
            {
                return lookup[key];
            }

            int ways = 0;

            // look for up and right
            if (indexM > 0)
            {
                ways += NumofUniquePathsHelper(indexM - 1, indexN, M, N, lookup);
            }

            if (indexN > 0)
            {
                ways += NumofUniquePathsHelper(indexM, indexN - 1, M, N, lookup);
            }

            lookup[key] = ways;

            return ways;
        }

        /// <summary>
        /// 63
        /// Follow up for "Unique Paths":
        ///         Now consider if some obstacles are added to the grids.How many unique paths would there be?
        ///        An obstacle and empty space is marked as 1 and 0 respectively in the grid.
        ///        For example,
        ///        There is one obstacle in the middle of a 3x3 grid as illustrated below.
        /// [
        ///          [0,0,0],
        ///          [0,1,0],
        ///          [0,0,0]
        /// ]
        /// The total number of unique paths is 2.
        /// 
        /// O(mn) runtime, O(mn) space – Dynamic programming: 
        /// 
        /// Note: YIC need to check if curr indexM indexN is obstacle before check index(0,0) case
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();   //(loc, ways)
            int M = obstacleGrid.GetLength(0);
            int N = obstacleGrid.GetLength(1);

            int ans = UniquePathsWithObstaclesHelper(obstacleGrid, M - 1, N - 1, M, N, memo);

            return ans;
        }

        private int UniquePathsWithObstaclesHelper(int[,] obstacleGrid, int indexM, int indexN, int M, int N, Dictionary<int, int> memo)
        {
            if (indexM < 0 || indexN < 0 || obstacleGrid[indexM, indexN] == 1)    // put in front of indexM = indexN = 0 for case {{1}}
            {
                return 0;
            }

            if (indexM == 0 && indexN == 0)
            {
                return 1;
            }

            int key = M * indexN + indexM;
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            int currWays = UniquePathsWithObstaclesHelper(obstacleGrid, indexM - 1, indexN, M, N, memo)
                          + UniquePathsWithObstaclesHelper(obstacleGrid, indexM, indexN - 1, M, N, memo);

            memo[key] = currWays;

            return currWays;
        }
    }
}
