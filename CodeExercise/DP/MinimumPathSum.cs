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
