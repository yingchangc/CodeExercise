using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class MinimumPathSum
    {
        /// <summary>
        /// 64
        /// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
        ///         Note: You can only move either down or right at any point in time.
        ///         Example 1:
        /// [[1,3,1],
        ///  [1,5,1],
        ///  [4,2,1]]
        /// Given the above grid map, return 7. Because the path 1→3→1→1→1 minimizes the sum.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSumSolver(int[,] grid)
        {
            // optimize from MinPathSumSolver_Forward
            int M = grid.GetLength(0);
            int N = grid.GetLength(1);
            int[,] memo = new int[2, N];

            memo[0, 0] = grid[0, 0];
            int j, i;
            for (j = 0; j < M; j++)
            {
                for (i = 0; i < N; i++)
                {
                    if ((i - 1) >= 0 && (j - 1) >= 0)
                    {
                        memo[j%2, i] = grid[j, i] + Math.Min(memo[(j - 1)%2, i], memo[j%2, i - 1]);
                    }
                    else if ((i - 1) >= 0)
                    {
                        memo[j%2, i] = grid[j, i] + memo[j%2, i - 1];
                    }
                    else if ((j - 1) >= 0)
                    {
                        memo[j%2, i] = grid[j, i] + memo[(j - 1)%2, i];
                    }
                    // no else for 0,0 case
                }
            }

            // last for ++j  so need to -1
            return memo[(j-1)%2, N - 1];
        }
        public int MinPathSumSolver_Forward(int[,] grid)
        {
            int M = grid.GetLength(0);
            int N = grid.GetLength(1);
            int[,] memo = new int[M, N];

            memo[0, 0] = grid[0, 0];

            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if ((i-1) >=0 && (j-1) >=0)
                    {
                        memo[j, i] = grid[j,i] + Math.Min(memo[j - 1, i] , memo[j,i - 1]);
                    }
                    else if ((i - 1) >= 0)
                    {
                        memo[j, i] = grid[j, i] + memo[j, i - 1];
                    }
                    else if ((j-1) >= 0)
                    {
                        memo[j, i] = grid[j, i] + memo[j - 1, i];
                    }
                    // no else for 0,0 case
                }
            }

            return memo[M - 1, N - 1];
        }

        public int MinPathSumSolverOld(int[,] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);

            Dictionary<int, int> memo = new Dictionary<int, int>();  //store as 1d array

            return MinPathHelper(grid, 0, 0, m, n, memo);
        }

        private int MinPathHelper(int[,] grid, int currentI, int currentJ, int m, int n, Dictionary<int, int> memo)
        {
            // stop condition
            if (memo.ContainsKey(currentI + currentJ*m))
            {
                return memo[currentI + currentJ * m];
            }

            int currentV = grid[currentI, currentJ];
            if (currentI == (m-1) && currentJ == (n-1))
            {
                memo[currentI + currentJ * m] = currentV;
                return currentV;
            }

            int currentBest = Int32.MaxValue;

            // try right
            if ((currentI + 1) < m)
            {
                currentBest = Math.Min((currentV + MinPathHelper(grid, currentI+1, currentJ, m, n, memo)), currentBest);
            }

            // try down
            if ((currentJ + 1) < n)
            {
                currentBest = Math.Min(currentV + MinPathHelper(grid, currentI, currentJ+1, m, n, memo), currentBest);
            }

            memo[currentI + currentJ * m] = currentBest;
            return currentBest;
        }
    }
}
