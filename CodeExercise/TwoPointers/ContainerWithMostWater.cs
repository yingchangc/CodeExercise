using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    
    class ContainerWithMostWater
    {
        ///// <summary>
        /// 11. Container With Most Water
        /// https://leetcode.com/problems/container-with-most-water/description/
        /// Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate(i, ai). n 
        /// vertical lines are drawn such that the two endpoints of line i is at(i, ai) and(i, 0). Find two lines, 
        /// which together with x-axis forms a container, such that the container contains the most water.

        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int right = height.Length - 1;
            int left = 0;

            int maxArea = 0;

            while (left < right)
            {
                int wallHeight = Math.Min(height[left], height[right]);
                maxArea = Math.Max(maxArea, wallHeight * (right - left));

                if (height[left] <= height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;

        }
    }
}
