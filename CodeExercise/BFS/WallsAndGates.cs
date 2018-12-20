using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class WallsAndGates
    {
        /// <summary>
        /// 286. Walls and Gates
        /// https://leetcode.com/problems/walls-and-gates/
        /// You are given a m x n 2D grid initialized with these three possible values.
        /// 
        /// -1 - A wall or an obstacle.
        /// 0 - A gate.
        /// INF - Infinity means an empty room.We use the value 231 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than 2147483647.
        /// Fill each empty room with the distance to its nearest gate.If it is impossible to reach a gate, it should be filled with INF.
        /// </summary>
        /// <param name="rooms"></param>
        public void WallsAndGatesSolver(int[,] rooms)
        {

            int lenY = rooms.GetLength(0);
            int lenX = rooms.GetLength(1);

            Queue<Loc> que = new Queue<Loc>();

            HashSet<int> visited = new HashSet<int>();

            // enqueue all gates
            for (int y = 0; y < lenY; y++)
            {
                for (int x = 0; x < lenX; x++)
                {
                    if (rooms[y, x] == 0)
                    {
                        que.Enqueue(new Loc(y, x));
                        visited.Add(x + y * lenX);
                    }
                }
            }

            var deltas = new List<Loc>()
            {
                new Loc(-1,0),
                new Loc(1,0),
                new Loc(0,1),
                new Loc(0,-1)
            };

            int steps = 0;

            while (que.Count > 0)
            {
                int currLevelCount = que.Count;

                for (int i = 0; i < currLevelCount; i++)
                {
                    var curr = que.Dequeue();

                    if (rooms[curr.y, curr.x] > steps)
                    {
                        // better choice
                        rooms[curr.y, curr.x] = steps;
                    }

                    // neighbors
                    foreach (var delta in deltas)
                    {
                        int ny = curr.y + delta.y;
                        int nx = curr.x + delta.x;

                        int pos = nx + ny * lenX;

                        if (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && !visited.Contains(pos) && rooms[ny, nx] > 0)
                        {
                            visited.Add(pos);
                            que.Enqueue(new Loc(ny, nx));
                        }
                    }
                }
                steps++;
            }
        }


        public class Loc
        {
            public int y;
            public int x;

            public Loc(int y, int x)
            {
                this.y = y;
                this.x = x;
            }
        }
    }
}
