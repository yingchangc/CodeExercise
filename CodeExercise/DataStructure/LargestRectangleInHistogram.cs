using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class LargestRectangleInHistogram
    {
        /// <summary>
        /// 84
        /// https://leetcode.com/problems/largest-rectangle-in-histogram/solution/
        /// Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.
        /// 
        /// For example,
        /// Given heights = [2, 1, 5, 6, 2, 3],
        /// return 10.
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleArea(int[] heights)
        {
            Stack<int> locations = new Stack<int>();

            int N = heights.GetLength(0);
            int area = 0;

            for (int i = 0; i < N; i++)
            {
                int currHeight = heights[i];
                area = Math.Max(area, ComputeMonotomicStackSofar(heights, locations, i));
                locations.Push(i);
            }

            // finsih loop, i = N
            area = Math.Max(area, ComputeMonotomicStackSofar(heights, locations, N));

            return area;
        }

        private int ComputeMonotomicStackSofar(int[] heights, Stack<int> locations, int NextSmallerIndex)
        {
            int area = 0;
                                           // yic handle NextSMallest is N case        //  next height is smaller
            while(locations.Count > 0 && (NextSmallerIndex == heights.GetLength(0) || heights[locations.Peek()] > heights[NextSmallerIndex]))
            {
                int currH = heights[locations.Pop()];
                if (locations.Count == 0)
                {
                    area = Math.Max(area, currH * (NextSmallerIndex));   // global smallest so far, widht = [0 ~ NextSmallerIndex-1]
                }
                else
                {                                   // loc.peek is previous index      it can be far away from currnt index
                    int width = (NextSmallerIndex - locations.Peek() - 1);  // width = (preLoc ~ NextSmallerIndex-1]   note  (preloc  ,not [preloc
                    area = Math.Max(area, currH * width);
                }
            }

            return area;
        }

    }
}
