using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class FloodFill
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
        /// 733. Flood Fill
        /// https://leetcode.com/problems/flood-fill/description/
        /// An image is represented by a 2-D array of integers, each integer representing the pixel value of the image (from 0 to 65535).
        /// 
        /// Given a coordinate(sr, sc) representing the starting pixel(row and column) of the flood fill, and a pixel value newColor, "flood fill" the image.
        /// 
        /// To perform a "flood fill", consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color as the starting pixel), and so on.Replace the color of all of the aforementioned pixels with the newColor.
        /// 
        /// At the end, return the modified image.
        /// 
        /// Example 1:
        /// Input: 
        /// image = [[1, 1, 1], [1,1,0], [1,0,1]]
        /// sr = 1, sc = 1, newColor = 2
        /// Output: [[2,2,2],[2,2,0],[2,0,1]]
        /// Explanation: 
        /// From the center of the image(with position (sr, sc) = (1, 1)), all pixels connected
        /// by a path of the same color as the starting pixel are colored with the new color.
        /// Note the bottom corner is not colored 2, because it is not 4-directionally connected
        /// to the starting pixel.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="newColor"></param>
        /// <returns></returns>
        public int[,] FloodFillSolver(int[,] image, int sr, int sc, int newColor)
        {
            int lenY = image.GetLength(0);
            int lenX = image.GetLength(1);

            bool[,] visited = new bool[lenY, lenX];
            List<Point> deltas = new List<Point>()
        {
            new Point(0,-1),
            new Point(0,1),
            new Point(-1,0),
            new Point(1,0)
        };

            Queue<Point> que = new Queue<Point>();
            que.Enqueue(new Point(sc, sr));
            visited[sr, sc] = true;

            var originColor = image[sr, sc];

            while (que.Count > 0)
            {
                var curr = que.Dequeue();
                image[curr.y, curr.x] = newColor;   // modify color

                foreach (var delta in deltas)
                {
                    int nx = curr.x + delta.x;
                    int ny = curr.y + delta.y;

                    if (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && image[ny, nx] == originColor && !visited[ny, nx])
                    {
                        que.Enqueue(new Point(nx, ny));
                        visited[ny, nx] = true;
                    }
                }

            }

            return image;
        }
    }
}
