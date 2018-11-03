using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    /// <summary>
    /// 1479. Can Reach The Endpoint
    /// Given a map size of m* n, 1 means space, 0 means obstacle, 9 means the endpoint.You start at(0,0) and return whether you can reach the endpoint.
    /// 
    /// Example
    /// Input:[[1,1,1], [1,1,1], [1,1,9]]
    /// Output:true
    /// </summary>
    class CanReachTheEndpoint
    {
        class Point
        {
            public int x;
            public int y;
            public Point(int y, int x)
            {
                this.x = x;
                this.y = y;
            }
        }

        public bool CanReachEndpoint(int[,] map)
        {
            if (map == null)
            {
                return false;
            }
            int lenY = map.GetLength(0);
            int lenX = map.GetLength(1);
            
            if(lenX * lenY == 0)
            {
                return false;
            }

            if (map[0,0] == 9)
            {
                return true;
            }

            if (map[0,0] == 0)  // obstacle
            {
                return false;
            }

           
            Queue<Point> que = new Queue<Point>();
            bool[,] visited = new bool[lenY, lenX];
            visited[0, 0] = true;
            que.Enqueue(new Point(0, 0)); //y,x

            int step = 0;

            int[] deltasX = { -1, 0, 1, 0 };
            int[] deltasY = { 0, -1, 0, 1 };


            while(que.Count > 0)
            {
                int levelSize = que.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    Point p = que.Dequeue();
                    
                    for(int k = 0; k <4; k++)
                    {
                        int newX = p.x + deltasX[k];
                        int newY = p.y + deltasY[k];

                        if (newX >=0 && newX < lenX && newY >=0 && newY <lenY && !visited[newY, newX]
                            && map[newY,newX]!=0)
                        {
                            if(map[newY,newX] == 9)
                            {
                                step++;
                                return true;
                            }

                            visited[newY, newX] = true;
                            que.Enqueue(new Point(newY, newX));
                        }
                    }
                }

                step++;
            }

            return false;
        }
    }
}
