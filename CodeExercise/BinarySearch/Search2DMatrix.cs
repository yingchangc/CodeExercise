using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class Search2DMatrix
    {
        /// <summary>
        /// 38. Search a 2D Matrix II
        /// https://leetcode.com/problems/search-a-2d-matrix-ii/description/
        /// Write an efficient algorithm that searches for a value in an m x n matrix, return the occurrence of it.
        /// 
        /// This matrix has the following properties:
        /// 
        /// 
        /// Integers in each row are sorted from left to right.
        /// Integers in each column are sorted from up to bottom.
        /// No duplicate integers in each row or column.
        /// Example
        ///         Consider the following matrix:
        /// 
        /// 
        ///         [
        ///           [1, 3, 5, 7],
        ///           [2, 4, 7, 8],
        ///           [3, 5, 9, 10]
        /// ]
        /// Given target = 3, return 2.
        /// 
        /// Challenge
        /// O(m+n) time and O(1) extra space
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix2(int[,] matrix, int target)
        {

        }


        /// <summary>
        /// 28. Search a 2D Matrix
        /// https://www.lintcode.com/problem/search-a-2d-matrix/description
        /// Write an efficient algorithm that searches for a value in an m x n matrix.
        /// 
        /// This matrix has the following properties:
        /// 
        /// Integers in each row are sorted from left to right.
        /// The first integer of each row is greater than the last integer of the previous row.
        /// Example
        /// Consider the following matrix:
        /// 
        /// [
        ///     [1, 3, 5, 7],
        ///     [10, 11, 16, 20],
        ///     [23, 30, 34, 50]
        /// ]
        /// Given target = 3, return true.
        /// 
        /// Challenge
        /// O(log(n) + log(m)) time
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.GetLength(0)==0 || matrix.GetLength(1) == 0)
            {
                return false;
            }

            int targetRow = FindRow(matrix, target);

            int cols = matrix.GetLength(1);

            int left = 0;
            int right = cols - 1;

            while(left +1 < right)
            {
                int mid = left + (right - left) / 2;
                if (matrix[targetRow,mid] < target)
                {
                    left = mid;
                }
                else if (matrix[targetRow, mid] > target)
                {
                    right = mid;
                }
                else
                {
                    return true;
                } 
            }

            return (matrix[targetRow, left] == target || matrix[targetRow, right] == target);

        }

        private int FindRow(int[,] matrix, int target)
        {
            int rows = matrix.GetLength(0);

            int up = 0;
            int down = rows - 1;

            while(up+1 < down)
            {
                int mid = up + (down - up) / 2;
                
                if (matrix[mid,0] < target)
                {
                    up = mid;
                }
                else if (matrix[mid,0] > target)
                {
                    down = mid;
                }
                else
                {
                    return mid;
                }
            }

            if (matrix[down,0] <= target)
            {
                return down;
            }
            return up;
        }
    }



}
