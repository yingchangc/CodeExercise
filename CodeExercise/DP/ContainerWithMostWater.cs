using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class ContainerWithMostWater
    {
        /// <summary>
        /// Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water. 
        /// 
        /// Illulstration
        /// https://leetcode.com/problems/container-with-most-water/solution/
        /// 
        /// This is done since a relatively longer line obtained by moving the shorter line's pointer might overcome the reduction in area caused by the width reduction.
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int area = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                int newArea = Math.Min(height[left], height[right]) * (right - left);
                area = Math.Max(area, newArea);

                if (height[left] <= height[right])
                {
                    // If we try to move the pointer at the longer line inwards, we won't gain any increase in area, since it is limited by the shorter line. 
                    left++;   // because left is the bound, move left; move right may not get area increase
                }
                else
                {
                    right--;
                }
            }

            return area;
        }
    }
}
