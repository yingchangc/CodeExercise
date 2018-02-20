using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class TrapRainWater
    {
        /// <summary>
        /// 42
        /// https://leetcode.com/problems/trapping-rain-water/description/
        /// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water 
        /// it is able to trap after raining.
        /// 
        /// Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int TrapRainWaterSolution(int[] height)
        {
            int N = height.GetLength(0);

            if (N == 0)
            {
                return 0;
            }

            int i = 0;
            int j = N - 1;

            int area = 0;

            while (i != j)
            {
                int left = height[i];
                int right = height[j];

                if (left <= right)
                {
                    while(left > height[++i])     //yic only left to prevent all height equal and i, j corss case
                    {                        // when choose left, means if we later encounter a new higher, it can be either  <j  or just j.  will not have cross case
                        area += (left - height[i]);
                    }
                }
                else
                {
                    while (height[--j] < right)
                    {
                        area += (right - height[j]);
                    }
                }
            }

            return area; 
        }
    }
}
