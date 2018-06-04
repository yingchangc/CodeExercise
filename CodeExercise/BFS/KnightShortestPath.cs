using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    public class Point
    {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }
    }

    class KnightShortestPath
    {
        /// <summary>
        /// lint 611 Knight Shortest Path
        /// https://www.lintcode.com/problem/knight-shortest-path/description
        /// Given a knight in a chessboard (a binary matrix with 0 as empty and 1 as barrier) with a source position, find the shortest path to a destination position, return the length of the route.
        /// Return -1 if knight can not reached.
        /// 
        /// If the knight is at (x, y), he can get to the following positions in one step:
        /// (x + 1, y + 2)
        /// (x + 1, y - 2)
        /// (x - 1, y + 2)
        /// (x - 1, y - 2)
        /// (x + 2, y + 1)
        /// (x + 2, y - 1)
        /// (x - 2, y + 1)
        /// (x - 2, y - 1)
        
        /// Example
        /// [[0, 0, 0],
        ///  [0,0,0],
        ///  [0,0,0]]
        /// source = [2, 0]
        /// destination = [2, 2] return 2
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public int ShortestPath(bool[,] grid, Point source, Point destination)
        {
            Queue<Point> queue = new Queue<Point>();
            int xLen = grid.GetLength(0);
            int yLen = grid.GetLength(1);

            bool[,] visited = new bool[xLen, yLen];

            queue.Enqueue(source);
            visited[source.x, source.y] = true;

            int steps = 0;
     
            List<Point> deltas = new List<Point>() {
                                                    new Point(1, 2),
                                                    new Point(1, -2),
                                                    new Point(-1, 2),
                                                    new Point(-1, -2),
                                                    new Point(2,1),
                                                    new Point(2,-1),
                                                    new Point(-2,1),
                                                    new Point(-2,-1),
                                                  };

            while(queue.Count > 0)
            {
                int levelSize = queue.Count;

                for (int i = 0; i <levelSize; i++)
                {
                    var curr = queue.Dequeue();

                    if (curr.x == destination.x && curr.y == destination.y)
                    {
                        return steps;    // yic check  source == destination
                    }

                    // look for 8 surrandings 
                    foreach (var deltaP in deltas)
                    {
                        var newPoint = new Point(curr.x + deltaP.x, curr.y + deltaP.y);

                        if (newPoint.x >= 0 && newPoint.x < xLen && newPoint.y >= 0 && newPoint.y < yLen
                            && grid[newPoint.x, newPoint.y] == false   // no block
                            && visited[newPoint.x, newPoint.y] == false)
                        {
                            visited[newPoint.x, newPoint.y] = true;
                            queue.Enqueue(newPoint);
                        }
                    }

                }

                steps++;  // yic 
            }
           
            return 0;
        }
    }
}
