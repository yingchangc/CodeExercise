using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class SmallestRectangleEnclosingBlackPixels
    {
        public class LocInfo
        {
            public int x;
            public int y;

            public LocInfo(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

        }


        int maxX;
        int maxY;
        int minX;
        int minY;

        /// <summary>
        /// 302. Smallest Rectangle Enclosing Black Pixels
        /// https://leetcode.com/problems/smallest-rectangle-enclosing-black-pixels/description/
        /// An image is represented by a binary matrix with 0 as a white pixel and 1 as a black pixel. The black pixels are connected, i.e., there is only one black region. Pixels are connected horizontally and vertically. Given the location (x, y) of one of the black pixels, return the area of the smallest (axis-aligned) rectangle that encloses all black pixels.
        /// 
        /// Example:
        /// 
        /// Input:
        /// [
        ///   "0010",
        ///   "0110",
        ///   "0100"
        /// ]
        ///         and x = 0, y = 2
        /// 
        /// Output: 6
        /// 
        /// sol:
        /// use BFS to find the max min corners
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int MinArea(char[,] image, int x, int y)
        {
            // set to curr point
            maxX = x;
            maxY = y;
            minX = x;
            minY = y;

            int lenX = image.GetLength(0);
            int lenY = image.GetLength(1);

            bool[,] visited = new bool[lenX, lenY]; 

            Queue<LocInfo> que = new Queue<LocInfo>();
            que.Enqueue(new LocInfo(x, y));
            visited[x,y] = true;

            List<LocInfo> deltas = new List<LocInfo>() { new LocInfo(-1, 0), new LocInfo(1, 0), new LocInfo(0, -1), new LocInfo(0, 1) };

            while(que.Count > 0)
            {
                var curr = que.Dequeue();
                
                foreach (var delta in deltas)
                {
                    int nx = curr.x + delta.x;
                    int ny = curr.y + delta.y;

                    if (nx >=0 && nx <lenX && ny >=0 && ny <lenY && image[nx,ny] == '1' && !visited[nx,ny])
                    {
                        que.Enqueue(new LocInfo(nx,ny));                              // (0,0)   x 
                        visited[nx, ny] = true;    // yic must be here       for case    (1,0)  (1,1)   queue(1,0)  which enqueue(1,1) and (0,0)  will cause (0,1) into queue twice.  
                        UpdateCorner(nx, ny);
                    }
                }
            }

            return (maxX - minX + 1) * (maxY - minY + 1);
        }

        private void UpdateCorner(int nx, int ny)
        {
            maxX = Math.Max(maxX, nx);
            minX = Math.Min(minX, nx);

            maxY = Math.Max(maxY, ny);
            minY = Math.Min(minY, ny);
        }
    }
}
