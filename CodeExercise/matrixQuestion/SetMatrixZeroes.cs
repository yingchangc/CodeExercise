using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.matrixQuestion
{
    class SetMatrixZeroes
    {
        /// <summary>
        /// 73. Set Matrix Zeroes
        /// https://leetcode.com/problems/set-matrix-zeroes/description/
        /// Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in-place.
        /// 
        /// Example 1:
        /// 
        /// Input: 
        /// [
        ///   [1,1,1],
        ///   [1,0,1],
        ///   [1,1,1]
        /// ]
        /// Output: 
        /// [
        ///   [1,0,1],
        ///   [0,0,0],
        ///   [1,0,1]
        /// ]
        /// </summary>
        /// <param name="matrix"></param>
        public void SetZeroes(int[,] matrix)
        {
            int lenY = matrix.GetLength(0);
            int lenX = matrix.GetLength(1);

            bool hasFirstRowZ = false;
            bool hasFirstColZ = false;

            for (int j = 0; j < lenY; j++)
            {
                for (int i = 0; i < lenX; i++)
                {
                    if (matrix[j, i] == 0)
                    {
                        matrix[0, i] = 0;  // flag indicate  all column i should be 0
                        matrix[j, 0] = 0;   // indicates all row j should be 0

                        if (i == 0)
                        {
                            hasFirstColZ = true;
                        }

                        if (j == 0)
                        {
                            hasFirstRowZ = true;
                        }
                    }
                }
            }

            // ignore (0,i) row
            for (int i = 1; i < lenX; i++)
            {
                if (matrix[0, i] == 0)
                {
                    for (int j = 1; j < lenY; j++)
                    {
                        matrix[j, i] = 0;
                    }

                }

            }

            // ignore (j,0) column
            for (int j = 1; j < lenY; j++)
            {
                if (matrix[j, 0] == 0)
                {
                    for (int i = 1; i < lenX; i++)
                    {
                        matrix[j, i] = 0;
                    }
                }
            }


            // handle first col
            if (hasFirstColZ)
            {
                for (int j = 0; j < lenY; j++)
                {
                    matrix[j, 0] = 0;
                }
            }

            if (hasFirstRowZ)
            {
                for (int i = 0; i < lenX; i++)
                {
                    matrix[0, i] = 0;
                }
            }
        }
    }
}
