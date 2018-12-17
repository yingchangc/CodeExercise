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

        public int MinPathSum(int[,] grid)
        {
            int lenY = grid.GetLength(0);
            int lenX = grid.GetLength(1);

            int[,] F = new int[lenY, lenX];
            bool[,] visited = new bool[lenY + 1, lenX + 1];

            return DFSHelper_BackTrack(lenX - 1, lenY - 1, grid, F, visited);
        }

        private int DFSHelper_BackTrack(int x, int y, int[,] grid, int[,] F, bool[,] visited)
        {
            if (x == 0 && y == 0)
            {
                return grid[y, x];
            }

            if (x < 0 || y < 0)
            {
                return int.MaxValue;
            }

            if (visited[y, x])
            {
                return F[y, x];
            }

            int pathSumU = DFSHelper_BackTrack(x, y - 1, grid, F, visited);
            int pathSumL = DFSHelper_BackTrack(x - 1, y, grid, F, visited);


            visited[y, x] = true;
            F[y, x] = Math.Min(pathSumU, pathSumL) + grid[y, x];

            return F[y, x];
        }
    }
}
