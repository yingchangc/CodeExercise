using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class SortColors
    {
        ///75. Sort Colors
        ///https://leetcode.com/problems/sort-colors/description/
        ///Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white and blue.
        ///Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
        ///
        ///Note: You are not suppose to use the library's sort function for this problem.
        ///
        ///Example:
        ///
        ///Input: [2,0,2,1,1,0]
        ///Output: [0,0,1,1,2,2]
        ///
        /// sol:
        /// (1)A rather straight forward solution is a two-pass algorithm using counting sort.
        /// First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
        /// (2)zero ptr in front, swap happen when [1] 1 [0]   and two ptr in the back
        public void SortColors1(int[] colors)
        {
            int len = colors.Length;
            int zeroIdx = 0;
            int twoIdx = len - 1;
            int i = 0;
            while(i <= twoIdx)    // yic must be <=     for example [1,2,0] -> after first swap [1,0,2]  twoidx = 1, i = 1 as well
            {
                if (colors[i] == 0)
                {
                    // only hit 0 itself or 1 need to swap,
                    swap(colors, i, zeroIdx++);
                    i++;
                }
                else if (colors[i] == 2)
                {
                    swap(colors, i, twoIdx--);  // we don't know what to swap back, so keep the same i
                }
                else
                {
                    // 1 case , keep going
                    i++;
                }
            }
        }

        /// <summary>
        /// 143. Sort Colors II
        /// https://www.lintcode.com/problem/sort-colors-ii/description
        /// Description
        /// Given an array of n objects with k different colors(numbered from 1 to k), sort them so that objects of the same 
        /// color are adjacent, with the colors in the order 1, 2, ... k.
        /// 
        /// Example
        /// Given colors =[3, 2, 2, 1, 4], k = 4, your code should sort colors in-place to[1, 2, 2, 3, 4].
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="k"></param>
        public void SortColors2(int[] colors, int k)
        {
            qkSort(colors, k, 0, colors.Length - 1);
        }

        private void qkSort(int[] colors, int k, int start, int end)
        {
            if (colors == null || start >=end)
            {
                return;
            }

            int left = start;
            int right = end;

            int pivot = colors[(start + (end - start) / 2)];

            while(left <= right)
            {
                while(left <= right && colors[left] < pivot)
                {
                    left++;
                }
                while(left <= right && colors[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    swap(colors, left++, right--);
                }
            }

            qkSort(colors, k, start, right);
            qkSort(colors, k, left, end);
        }

        private void swap(int[] colors, int i, int j)
        {
            int temp = colors[i];
            colors[i] = colors[j];
            colors[j] = temp;
        }
    }
}
