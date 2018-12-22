using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class IslandPerimeter
    {
        /// <summary>
        /// 463. Island Perimeter
        /// https://leetcode.com/problems/island-perimeter/
        /// You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water.
        /// 
        /// Grid cells are connected horizontally/vertically(not diagonally). The grid is completely surrounded by water, and there is exactly one island(i.e., one or more connected land cells).
        /// 
        /// The island doesn't have "lakes" (water inside that isn't connected to the water around the island). One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.
        /// 
        /// 
        /// 
        /// 
        /// Example:
        /// 
        /// Input:
        /// [[0,1,0,0],
        ///  [1,1,1,0],
        ///  [0,1,0,0],
        ///  [1,1,0,0]]
        /// 
        /// Output: 16
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int IslandPerimeterSolver(int[,] grid)
        {

            int ans = 0;

            int lenY = grid.GetLength(0);
            int lenX = grid.GetLength(1);

            bool[,] visited = new bool[lenY, lenX];

            for (int y = 0; y < lenY; y++)
            {
                for (int x = 0; x < lenX; x++)
                {
                    if (grid[y, x] == 1 && !visited[y, x])
                    {
                        ans = Math.Max(ans, BFSHelper(grid, y, x, visited));
                    }

                }
            }

            return ans;

        }

        private int BFSHelper(int[,] grid, int y, int x, bool[,] visited)
        {
            Queue<Loc> que = new Queue<Loc>();
            que.Enqueue(new Loc(y, x));
            visited[y, x] = true;

            int lenY = grid.GetLength(0);
            int lenX = grid.GetLength(1);

            var deltas = new List<Loc>()
        {
             new Loc(-1,0),
             new Loc(1,0),
             new Loc(0,1),
             new Loc(0,-1)
        };

            int TotalEdges = 0;

            while (que.Count > 0)
            {
                var curr = que.Dequeue();

                int edgeCount = 4;
                foreach (var delta in deltas)
                {
                    var nx = curr.x + delta.x;
                    var ny = curr.y + delta.y;

                    if (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && !visited[ny, nx] && grid[ny, nx] == 1)
                    {
                        que.Enqueue(new Loc(ny, nx));
                        visited[ny, nx] = true;
                        edgeCount--;
                    }
                    else if (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && visited[ny, nx])
                    {
                        edgeCount--;
                    }
                }
                TotalEdges += edgeCount;

            }

            return TotalEdges;

        }

        public class Loc
        {
            public int x;
            public int y;
            public Loc(int y, int x)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
