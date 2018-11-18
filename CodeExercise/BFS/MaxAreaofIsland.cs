using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class MaxAreaofIsland
    {
        public class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        /// <summary>
        /// 695. Max Area of Island
        /// https://leetcode.com/problems/max-area-of-island/description/
        /// Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.
        /// 
        /// Find the maximum area of an island in the given 2D array. (If there is no island, the maximum area is 0.)
        /// 
        /// Example 1:
        /// 
        /// [[0,0,1,0,0,0,0,1,0,0,0,0,0],
        ///  [0,0,0,0,0,0,0,1,1,1,0,0,0],
        ///  [0,1,1,0,1,0,0,0,0,0,0,0,0],
        ///  [0,1,0,0,1,1,0,0,1,0,1,0,0],
        ///  [0,1,0,0,1,1,0,0,1,1,1,0,0],
        ///  [0,0,0,0,0,0,0,0,0,0,1,0,0],
        ///  [0,0,0,0,0,0,0,1,1,1,0,0,0],
        ///  [0,0,0,0,0,0,0,1,1,0,0,0,0]]
        /// Given the above grid, return 6. Note the answer is not 11, because the island must be connected 4-directionally.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxAreaOfIslandSolver(int[,] grid)
        {
            int maxSize = 0;

            int lenX = grid.GetLength(1);
            int lenY = grid.GetLength(0);
            bool[,] visited = new bool[lenY, lenX];  // yic  bewahre of order



            for (int j = 0; j < grid.GetLength(0); j++)
            {
                for (int i = 0; i < grid.GetLength(1); i++)
                {
                    if (grid[j, i] == 1 && !visited[j, i])
                    {
                        int islandSize = BFSCountSize(grid, i, j, visited);

                        maxSize = Math.Max(maxSize, islandSize);
                    }
                }
            }

            return maxSize;
        }

        private int BFSCountSize(int[,] grid, int x, int y, bool[,] visited)
        {
            int lenX = grid.GetLength(1);
            int lenY = grid.GetLength(0);
            Queue<Point> que = new Queue<Point>();

            que.Enqueue(new Point(x, y));
            visited[y, x] = true;
            List<Point> deltas = new List<Point>()
        {
            new Point(-1,0),
            new Point(1,0),
            new Point(0,-1),
            new Point(0,1)
        };

            int count = 0;

            while (que.Count > 0)
            {
                var pt = que.Dequeue();
                count++;

                Console.WriteLine("lenX:" + pt.x + " lenY:" + pt.y);

                foreach (var delta in deltas)
                {
                    int nx = pt.x + delta.x;
                    int ny = pt.y + delta.y;

                    if (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && grid[ny, nx] == 1 && !visited[ny, nx])
                    {
                        que.Enqueue(new Point(nx, ny));  // yic beware  nx then ny
                        visited[ny, nx] = true;
                    }
                }
            }

            return count;
        }
    }
}
