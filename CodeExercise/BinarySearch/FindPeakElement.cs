using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class FindPeakElement
    {
        /// <summary>
        /// 162
        /// Find Peak Element
        /// https://leetcode.com/problems/find-peak-element/description/
        /// A peak element is an element that is greater than its neighbors.
        /// Given an input array where num[i] ≠ num[i + 1], find a peak element and return its index.
        /// 
        /// The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
        /// 
        /// You may imagine that num[-1] = num[n] = -∞.
        /// 
        /// 
        /// For example, in array[1, 2, 3, 1], 3 is a peak element and your function should return the index number 2.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElementSolver(int[] nums)
        {
            int N = nums.GetLength(0);
            int left = 0;
            int right = N - 1;

            while(left+1 < right)
            {
                //at least 3 elemt
                int mid = (left + right) / 2;
                if (nums[mid] <= nums[mid + 1])
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            if (nums[left] <= nums[right])
            {
                return right;
            }
            return left;

            //int N = nums.GetLength(0);

            //int left = 0;
            //int right = N - 1;

            //while(left<right)
            //{
            //    int mid = (left + right) / 2;

            //    if (nums[mid] <= nums[mid+1])
            //    {
            //        left = mid + 1;
            //    }
            //    else
            //    {
            //        right = mid;
            //    }
            //}

            //return left;
        }

        /// <summary>
        /// There is an integer matrix which has the following features:
        /// The numbers in adjacent positions are different.
        /// The matrix has n rows and m columns.
        // For all i<m, A[0][i] < A[1][i] && A[n - 2][i]> A[n - 1][i].
        // For all j<n, A[j][0] < A[j][1] && A[j][m - 2]> A[j][m - 1].
        /// We define a position P is a peek if:
        /// 
        /// 
        /// A[j][i] > A[j + 1][i] && A[j][i] > A[j - 1][i] && A[j][i] > A[j][i + 1] && A[j][i] > A[j][i - 1]
        /// Find a peak element in this matrix.Return the index of the peak.
        /// 
        /// return {row, column}
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public List<int> findPeakII(int[,] matrix)
        {
            int Y = matrix.GetLength(0);
            int X = matrix.GetLength(1);

            int yStart = 0;
            int yEnd = Y - 1;

            // prevent case when only 1 row case
            int midX = FindPeakInRow(matrix, yStart);

            while(yStart < yEnd)
            {
                int midY = yStart + (yEnd - yStart) / 2;

                midX = FindPeakInRow(matrix, midY);

                if (matrix[midY, midX] < matrix[midY+1, midX])
                {
                    yStart = midY + 1;
                }
                else
                {
                    yEnd = midY;
                }
            }

            midX = FindPeakInRow(matrix, yStart);
            return new List<int>() { yStart, midX };
        }

        private int FindPeakInRow(int[,] matrix, int y)
        {
            //int col = 0;
            //for (int i = 0; i < A.GetLength(1); i++)
            //{
            //    if (A[row,i] > A[row,col])
            //    {
            //        col = i;
            //    }
            //}
            //return col;

            int N = matrix.GetLength(1);

            int left = 0;
            int right = N - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (matrix[y, mid] < matrix[y, mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
    }
}
