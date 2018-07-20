using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 308. Range Sum Query 2D - Mutable
    /// https://leetcode.com/problems/range-sum-query-2d-mutable/description/
    /// Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).
    /// 
    /// Example
    /// Given matrix = [
    ///   [3, 0, 1, 4, 2],
    ///   [5, 6, 3, 2, 1],
    ///   [1, 2, 0, 1, 5],
    ///   [4, 1, 0, 1, 7],
    ///   [1, 0, 3, 0, 5]
    /// ]
    /// 
    /// sumRegion(2, 1, 4, 3) -> 8
    /// update(3, 2, 2)
    /// sumRegion(2, 1, 4, 3) -> 10
    /// 
    /// 
    /// Sol: use Binary Index tree.  ref  Jiuzhang talk 9
    /// </summary>
    public class RangeSumQuery2DMutable
    {
        int[,] arr;
        int[,] B;
        int totalRows;
        int totalCols;

        public RangeSumQuery2DMutable(int[,] matrix)
        {
            totalRows = matrix.GetLength(0);
            totalCols = matrix.GetLength(1);

            arr = new int[totalRows, totalCols];
            B = new int[totalRows + 1, totalCols + 1];

            for (int j = 0; j < totalRows; j++)
            {
                for (int i = 0; i < totalCols; i++)
                {
                    Update(j, i, matrix[j, i]);
                }
            }
        }

        // affect righ and bottom
        public void Update(int row, int col, int val)
        {
            int delta = val - arr[row, col];
            arr[row, col] = val;

            for (int j = row+1; j <= totalRows; j+= GetLastBit(j))
            {
                for (int i = col+1; i <= totalCols; i+=GetLastBit(i))
                {
                    B[j, i] += delta;
                }
            }
        }

        private int GetLastBit(int x)
        {
            return x & (-x);
        }

        // look for left and up
        private int GetSum(int row, int col)
        {
            int sum = 0;
            for (int j = row+1; j >0; j-=GetLastBit(j))
            {
                for (int i = col+1; i >0; i-=GetLastBit(i))
                {
                    sum += B[j, i];
                }
            }
            return sum;
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            int UL = GetSum(row1-1, col1-1);
            int UR = GetSum(row1 - 1, col2);
            int BL = GetSum(row2, col1 - 1);
            int BR = GetSum(row2, col2);

            return BR - UR - BL + UL;
        }
    }


    class RangeSumQuery2D
    {
        int[,] preSum;
        int[,] arr;
        int totalRows;
        int totalCols;

        /// <summary>
        /// 304. Range Sum Query 2D - Immutable
        /// Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).
        /// 
        /// Example
        ///         Given matrix =
        /// 
        /// [
        ///   [3, 0, 1, 4, 2],
        ///   [5, 6, 3, 2, 1],
        ///   [1, 2, 0, 1, 5],
        ///   [4, 1, 0, 1, 7],
        ///   [1, 0, 3, 0, 5]
        /// ]
        /// 
        /// sumRegion(2, 1, 4, 3) -> 8
        /// sumRegion(1, 1, 2, 2) -> 11
        /// sumRegion(1, 2, 2, 4) -> 12
        /// </summary>
        /// <param name="matrix"></param>
        public RangeSumQuery2D(int[,] matrix)
        {
            totalRows = matrix.GetLength(0);
            totalCols = matrix.GetLength(1);
            preSum = new int[totalRows + 1, totalCols + 1];
            
            for(int j = 1; j <= totalRows; j++)
            {
                for (int i = 1; i <= totalCols; i++)
                {
                                   // Curr V              left                up                   up left        
                    preSum[j, i] = matrix[j - 1, i - 1] + (preSum[j - 1, i] + preSum[j, i - 1] - preSum[j - 1, i - 1]); 
                }
            }

        }


        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            int totalUL = preSum[row1, col1];
            int totalBR = preSum[row2 + 1, col2 + 1];

            int totalUR = preSum[row1, col2 + 1];
            int totalBL = preSum[row2 + 1, col1];

            return totalBR + totalUL - totalUR - totalBL;
        }

        ///=================================

        // slow but can extend to BinaryIndexTree
        public RangeSumQuery2D(int[,] matrix, bool isSlow)
        {
            totalRows = matrix.GetLength(0);
            totalCols = matrix.GetLength(1);
            preSum = new int[totalRows + 1, totalCols + 1];
            arr = new int[totalRows, totalCols];

            for (int j = 0; j <totalRows; j++)
            {
                for (int i = 0; i < totalCols; i++)
                {
                    update(j, i, matrix[j, i]);
                }
            }

            print();
        }

        private void update(int row, int col, int val)
        {
            int delta = val - arr[row, col];  // for next question, may change at any point
            arr[row, col] = val;

            for (int j = row+1; j <=totalRows; j++)
            {
                for (int i = col+1; i <= totalCols; i++)
                {
                    preSum[j, i] += delta;
                }
            }    
        }

        private void print()
        {
            // arr
            for(int j = 0; j <totalRows; j++)
            {
                for (int i = 0; i<totalCols; i++)
                {
                    Console.Write(arr[j, i] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("=====================");
            // presum
            for (int j = 1; j <= totalRows; j++)
            {
                for (int i = 1; i <= totalCols; i++)
                {
                    Console.Write(preSum[j, i] + " ");
                }

                Console.WriteLine();
            }
        }

       
    }
}
