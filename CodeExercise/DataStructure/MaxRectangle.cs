using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MaxRectangle
    {
        /// <summary>
        /// 85
        /// https://leetcode.com/problems/maximal-rectangle/description/
        /// Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
        /// 
        /// For example, given the following matrix:
        /// 1 0 1 0 0
        /// 1 0 1 1 1
        /// 1 1 1 1 1
        /// 1 0 0 1 0
        /// 
        /// Return 6.
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalRectangle(char[,] matrix)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            int[] heights = new int[N];

            int area = 0;

            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if ((matrix[j,i] - '0') > 0)
                    {
                        heights[i] += (matrix[j, i] - '0');    // fill height from previous row
                    }
                    else
                    {
                        heights[i] = 0;     // reuse if current is 0 
                    }
                }

                area = Math.Max(area, ComputeMaxRectInhistogram(heights));
            }

            return area;
        }

        private int ComputeMaxRectInhistogram(int[] heights)
        {
            int N = heights.GetLength(0);
            int area = 0;
            Stack<int> locations = new Stack<int>();

            for (int i = 0; i < N; i++)
            {
                area = Math.Max(area, ComputeMonotomicStackArea(heights, locations, i));
                locations.Push(i);
            }

            area = Math.Max(area, ComputeMonotomicStackArea(heights, locations, N));

            return area;
        }

        private int ComputeMonotomicStackArea(int[] heights, Stack<int> locations, int nextIndex)
        {
            int area = 0;
                                             // finish for loop from caller           // next height is smaller
            while (locations.Count > 0 && (nextIndex == heights.GetLength(0) || heights[locations.Peek()] > heights[nextIndex]))
            {
                int currLoc = locations.Pop();
                int currHeight = heights[currLoc];

                // after pop, curr is the smallest so far from since index 0
                if (locations.Count == 0)
                {
                    area = Math.Max(area, currHeight * nextIndex);    // width = 0 ~ nextIndex-1
                }
                else
                {
                    int preLoc = locations.Peek();
                    int width = nextIndex - preLoc - 1;      // width = preLoc+1 ~ nextIndex-1  Note: cannot use currLoc, because preLoc can be not close to currLoc
                    area = Math.Max(area, currHeight * width);
                }
            }

            return area;
        }
    }
}
