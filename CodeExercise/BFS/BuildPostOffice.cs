using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class BuildPostOffice
    {
        class Location
        {
            public int i;
            public int j;
            public Location(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }

        /// <summary>
        /// 573. Build Post Office II
        /// https://www.lintcode.com/problem/build-post-office-ii/description
        /// Given a 2D grid, each cell is either a wall 2, an house 1 or empty 0 (the number zero, one, two), find a place to build a post office so that the 
        /// sum of the distance from the post office to all the houses is smallest.
        /// 
        /// Return the smallest sum of distance.Return -1 if it is not possible.
        /// 
        /// 
        /// Example
        /// Given a grid:
        /// 
        /// 0 1 0 0 0
        /// 1 0 0 2 1
        /// 0 1 0 0 0
        /// return 8, You can build at (1,1). (Placing a post office at(1,1), the distance that post office to all the house sum is smallest.)
        /// 
        /// Sol:
        /// BFS in each 0 location and compute the sum, find the min sum, Note: look for 4 directions
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestDistance(int[,] grid)
        {
            if (grid == null || grid.GetLength(0) == 0 || grid.GetLength(1) == 0)
            {
                return -1;
            }

            int distance = int.MaxValue;

            int numHouse = GetMaxHouse(grid);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] == 0)  // place a post office here
                    {
                        var temp = BFS(grid, i, j, numHouse);
                        distance = Math.Min(temp, distance);
                    }
                }
            }

            return distance != int.MaxValue ? distance : -1;
        }

        private int GetMaxHouse(int[,] grid)
        {
            int count = 0;

            for (int i = 0; i <grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int BFS(int[,] grid, int i, int j, int numHouse)
        {
            int totalI = grid.GetLength(0);
            int totalJ = grid.GetLength(1);
            List<Location> deltas = new List<Location>() {  new Location(0,1),
                                                            new Location(0,-1),
                                                            new Location(1,0),
                                                            new Location(-1,0)};
            bool[,] visited = new bool[totalI, totalJ];
            int sum = 0;

            Queue<Location> queue = new Queue<Location>();
            queue.Enqueue(new Location(i, j));
            visited[i, j] = true;
            int step = 0;

            while(queue.Count > 0)
            {
                int levelSize = queue.Count();

                for (int k = 0; k < levelSize; k++)
                {
                    Location curr = queue.Dequeue();  // should be 0   empty
                    foreach (var delta in deltas)
                    {
                        int nI = curr.i + delta.i;
                        int nJ = curr.j + delta.j;

                        if (nI < totalI && nI >= 0 && nJ < totalJ && nJ >= 0 && !visited[nI, nJ])  // yic  visited  is needed
                        {
                            if (grid[nI, nJ] == 0)    // empty, can walk to next position
                            {
                                queue.Enqueue(new Location(nI, nJ));
                            }
                            else if (grid[nI, nJ] == 1)  // house
                            {
                                sum += (step + 1);
                                numHouse--;
                            }
                            visited[nI, nJ] = true;
                        }  
                    }
                }
                step++;
            }

            // if cannot reach house
            return numHouse == 0 ? sum : int.MaxValue;

        }
    }
}
