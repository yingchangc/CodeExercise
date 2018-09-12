using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class BonbEnemy
    {
        /// <summary>
        /// 361
        /// https://leetcode.com/problems/bomb-enemy/description/
        /// 
        /// iven a 2D grid, each cell is either a wall 'W', an enemy 'E' or empty '0' (the number zero), return the maximum enemies you can kill using one bomb.
        /// The bomb kills all the enemies in the same row and column from the planted point until it hits the wall since the wall is too strong to be destroyed.
        /// Note that you can only put the bomb at an empty cell.
        /// 
        /// Example:
        /// For the given grid
        /// 
        /// 0 E 0 0
        /// E 0 W E
        /// 0 E 0 0
        /// 
        /// return 3. (Placing a bomb at (1,1) kills 3 enemies)
        /// 
        /// Note that you can only put the bomb at an empty cell.
        /// 
        /// sol: 
        /// 
        /// use 4 memo matrix to accum 4 directions   so , at(i,j)  just lookup the 4 matrix as O(1) time
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxKilledEnemies(char[,] grid)
        {
            int M = grid.GetLength(0);
            int N = grid.GetLength(1);

            if (M == 0 || N ==0)
            {
                return 0;
            }

            int[,] UP = new int[M, N];
            int[,] DOWN = new int[M, N];
            int[,] RIGHT = new int[M, N];
            int[,] LEFT = new int[M, N];
            ComputeRightMemo(grid, RIGHT);
            ComputeUpMemo(grid, UP);
            ComputeLeftMemo(grid, LEFT);
            ComputeDownMemo(grid, DOWN);

            int ans = 0;

            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i <N; i++)
                {
                    if (grid[j,i] == '0')
                    {
                        int kill = LEFT[j, i] + RIGHT[j, i] + UP[j, i] + DOWN[j, i];
                        ans = Math.Max(ans, kill);
                    }        
                }
            }

            return ans;
        }

        private void ComputeRightMemo(char[,] grid, int[,] RIGHT)
        {
            int M = grid.GetLength(0);
            int N = grid.GetLength(1);
            for (int j = 0; j < M; j++)
            {
                for (int i= N-1; i>=0; i--)
                {
                    if (grid[j, i] == 'W')
                    {
                        RIGHT[j, i] = 0;
                    }
                    else
                    {
                        RIGHT[j, i] = grid[j, i] == 'E' ? 1 : 0;

                        if ((i + 1) < N)
                        {
                            RIGHT[j, i] += RIGHT[j, i + 1];
                        }
                    }

                }
            }
        }

        private void ComputeLeftMemo(char[,] grid, int[,] LEFT)
        {
            int M = grid.GetLength(0);
            int N = grid.GetLength(1);
            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if (grid[j, i] == 'W')
                    {
                        LEFT[j, i] = 0;
                    }
                    else
                    {
                        LEFT[j, i] = grid[j, i] == 'E' ? 1 : 0;

                        if ((i - 1) >= 0)
                        {
                            LEFT[j, i] += LEFT[j, i - 1];
                        }
                    }

                }
            }
        }

        private void ComputeDownMemo(char[,] grid, int[,] Down)
        {
            int M = grid.GetLength(0);
            int N = grid.GetLength(1);
            for (int j = M-1; j >=0; j--)
            {
                for (int i = 0; i < N; i++)
                {
                    if (grid[j, i] == 'W')
                    {
                        Down[j, i] = 0;
                    }
                    else
                    {
                        Down[j, i] = grid[j, i] == 'E' ? 1 : 0;

                        if ((j + 1) < M)
                        {
                            Down[j, i] += Down[j + 1, i];
                        }
                    }

                }
            }
        }

        private void ComputeUpMemo(char[,] grid, int[,] UP)
        {
            int M = grid.GetLength(0);
            int N = grid.GetLength(1);
            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if (grid[j, i] == 'W')
                    {
                        UP[j, i] = 0;
                    }
                    else
                    {
                        UP[j, i] = grid[j, i] == 'E' ? 1 : 0;

                        if ((j - 1) >= 0)
                        {
                            UP[j, i] += UP[j - 1, i];
                        }
                    }

                }
            }
        }
    }
}
