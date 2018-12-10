using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    //934. Shortest Bridge
    /// <summary>
    /// https://leetcode.com/problems/shortest-bridge/
    /// In a given 2D binary array A, there are two islands.  (An island is a 4-directionally connected group of 1s not connected to any other 1s.)
    /// Now, we may change 0s to 1s so as to connect the two islands together to form 1 island.
    /// 
    /// Return the smallest number of 0s that must be flipped.  (It is guaranteed that the answer is at least 1.)
    /// 
    /// 
    /// 
    /// Example 1:
    /// 
    /// Input: [[0,1],[1,0]]
    /// Output: 1
    /// Example 2:
    /// 
    /// Input: [[0,1,0],[0,0,0],[0,0,1]]
    /// Output: 2
    /// </summary>
    class ShortestBridge
    {
        public int ShortestBridgeSolver(int[][] A)
        {
            int lenY = A.GetLength(0);
            int lenX = A[0].GetLength(0);

            bool[][] visited = new bool[lenY][];
            for (int i = 0; i < lenY; i++)
            {
                visited[i] = new bool[lenX];
            }
            Queue<Loc> islandQueue = new Queue<Loc>();

            bool findfirstIsland = false;

            for (int y = 0; y < lenY; y++)
            {
                if (findfirstIsland)
                {
                    break;
                }
                for (int x = 0; x < lenX; x++)
                {
                    if (BFS_Find1stIsland(A, x, y, visited, islandQueue))
                    {
                        findfirstIsland = true;
                        break;
                    }
                }
            }

            Console.WriteLine("find 1st island :{0}, 1st island size{1}", findfirstIsland, islandQueue.Count);

            int distance = BFS_FindDistanceTo2ndIsland(A, visited, islandQueue);

            return distance;
        }

        private int BFS_FindDistanceTo2ndIsland(int[][] A, bool[][] visited, Queue<Loc> islandQueue)
        {
            int steps = 0;
            int lenY = A.GetLength(0);
            int lenX = A[0].GetLength(0);

            var deltas = new List<Loc>()
        {
            new Loc(-1,0),
            new Loc(1,0),
            new Loc(0,1),
            new Loc(0,-1)
        };

            while (islandQueue.Count > 0)
            {
                int levelCount = islandQueue.Count;

                // first, pop all island 1 from que and search surrounding
                for (int i = 0; i < levelCount; i++)
                {
                    var curr = islandQueue.Dequeue();

                    foreach (var delta in deltas)
                    {
                        int nx = curr.x + delta.x;
                        int ny = curr.y + delta.y;

                        // reach island#2
                        if (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && !visited[ny][nx] && A[ny][nx] == 1)
                        {
                            return steps;   // no need to +1 =, just need gap
                        }

                        while (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && !visited[ny][nx] && A[ny][nx] == 0)
                        {
                            visited[ny][nx] = true;
                            islandQueue.Enqueue(new Loc(nx, ny));
                        }
                    }
                }
                steps++;
            }

            // error case
            return int.MaxValue;
        }

        private bool BFS_Find1stIsland(int[][] A, int x, int y, bool[][] visited, Queue<Loc> islandQueue)
        {
            if (A[y][x] == 0)
            {
                return false;
            }

            int lenY = A.GetLength(0);
            int lenX = A[0].GetLength(0);
            Queue<Loc> que = new Queue<Loc>();
            que.Enqueue(new Loc(x, y));
            visited[y][x] = true;
            islandQueue.Enqueue(new Loc(x, y));

            var deltas = new List<Loc>()
        {
            new Loc(-1,0),
            new Loc(1,0),
            new Loc(0,1),
            new Loc(0,-1)
        };

            while (que.Count > 0)
            {
                int levelCount = que.Count;

                for (int i = 0; i < levelCount; i++)
                {
                    var curr = que.Dequeue();

                    foreach (var delta in deltas)
                    {
                        int nx = curr.x + delta.x;
                        int ny = curr.y + delta.y;

                        while (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && !visited[ny][nx] && A[ny][nx] == 1)
                        {
                            que.Enqueue(new Loc(nx, ny));
                            visited[ny][nx] = true;
                            islandQueue.Enqueue(new Loc(nx, ny));
                        }
                    }
                }
            }

            return true;
        }

        public class Loc
        {
            public int x;
            public int y;

            public Loc(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
