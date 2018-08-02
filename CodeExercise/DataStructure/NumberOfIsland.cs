using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class NumberOfIsland
    {
        class Location
        {
            public int x { get; set; }

            public int y { get; set; }

            public Location(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        /// <summary>
        /// 200. Number of Islands
        /// Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed 
        /// by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
        /// 
        ///         Example 1:
        /// 
        /// 11110
        /// 11010
        /// 11000
        /// 00000
        /// Answer: 1
        /// 
        /// Example 2:
        /// 
        /// 11000
        /// 11000
        /// 00100
        /// 00011
        /// 
        /// Sol 1
        /// BFS   O(MN)  because each element only touch once
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslandsBFS(char[,] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);

            bool[,] visited = new bool[m, n];
            int numOFIsland = 0;

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (grid[j, i] == '1' && visited[j, i] == false)
                    {
                        // go to BFS and mark visited
                        BFSHelper(grid, visited, m, n, i, j);
                        numOFIsland++;
                    }
                }
            }

            return numOFIsland;
        }


        private void BFSHelper(char[,] grid, bool[,] visited, int m, int n, int i, int j)
        {
            Queue<Location> stk = new Queue<Location>();
            stk.Enqueue(new Location(i, j));

            visited[j, i] = true;
            // need to look for 4 dirs, because we rely on all must be visited in a BFS helper,  each push can be from all dirs
            List<Location> deltas = new List<Location>() { new Location(1, 0), new Location(-1, 0), new Location(0, 1), new Location(0, -1) };

            while (stk.Count > 0)
            {
                var loc = stk.Dequeue();

                foreach (var delta in deltas)
                {
                    int nx = loc.x + delta.x;
                    int ny = loc.y + delta.y;
                    if ((nx >= 0 && nx < n) && (ny >= 0 && ny < m) && grid[ny, nx] == '1' && visited[ny, nx] == false)  // not yet visited land
                    {
                        visited[ny, nx] = true;
                        stk.Enqueue(new Location(nx, ny));
                    }
                }
            }
        }

        class UnionFind
        {
            int[] ufArray;
            public int Count { get; set; }

            public UnionFind(int totalSize)
            {
                ufArray = new int[totalSize];

                for (int i = 0; i < totalSize; i++)
                {
                    ufArray[i] = i;
                }
            }

            public void Union(int locA, int locB)
            {
                int rootA = Find(locA);
                int rootB = Find(locB);

                if (rootA != rootB)
                {
                    ufArray[rootB] = rootA;

                    this.Count--;
                }
            }

            public int Find(int locA)
            {
                if (locA != ufArray[locA])
                {
                    var topAncestor = Find(ufArray[locA]);    // note to use Find "ufArray[locA]"   and NOT locA
                    ufArray[locA] = topAncestor;    // compress
                }

                return ufArray[locA];
            }
        }

        public int NumIslandsUF(char[,] grid)
        {
            int M = grid.GetLength(0);
            int N = grid.GetLength(1);  // for x
            var unionFind = new UnionFind(M*N);

            // init Count
            unionFind.Count = 0;

            var deltas = new List<Location>() { new Location(1, 0), new Location(-1, 0), new Location(0, 1) , new Location(0, -1) };

            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    // find island
                    if (grid[j, i] == '1')
                    {
                        unionFind.Count++;    // Count-- will happen in Union step when rootA != rootB

                        foreach (var delta in deltas)  // only look for top left that has been visited
                        {
                            int nx = i + delta.x;
                            int ny = j + delta.y;

                            if ((nx >=0 && nx < N) && (ny >=0 && ny <M)  && grid[ny, nx] == '1')  //note nx ny boundry
                            {
                                // since we look for right bootton ahead, count will be minus and add back when we treavse.
                                int locB = j * N + i;   // N is width in x dir
                                int locA = ny * N + nx; // check top or left
                                unionFind.Union(locA, locB);   // inside Count-- only if A B has diff root, Find lookup O(1) , like visited
                            }
                        }

                    }        
                }
            }

            return unionFind.Count;
        }
    }
}
