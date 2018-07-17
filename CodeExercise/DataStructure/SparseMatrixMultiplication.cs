using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class SparseMatrixMultiplication
    {
        /// <summary>
        /// 311. Sparse Matrix Multiplication
        /// https://leetcode.com/problems/sparse-matrix-multiplication/description/
        ///Given two Sparse Matrix A and B, return the result of AB.
        ///
        ///You may assume that A's column number is equal to B's row number.
        ///
        ///Example
        ///A = [
        ///
        ///  [1, 0, 0],
        ///  [-1, 0, 3]
        ///]
        ///
        ///B = [
        ///  [ 7, 0, 0 ],
        ///  [ 0, 0, 0 ],
        ///  [ 0, 0, 1 ]
        ///]
        ///
        /// 2*3 X 3*2 = 2*2
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[,] Multiply(int[,] A, int[,] B)
        {
            if (A == null || B == null)
            {
                return null;
            }

            int rowA = A.GetLength(0);
            int colA = A.GetLength(1);
            int rowB = B.GetLength(0);
            int colB = B.GetLength(1);

            if (colA != rowB)
            {
                return null;
            }

            int[,] ans = new int[rowA, colB];


            /// time out  need to reorder  make A[j, i] in frist 2 for
            //for (int k = 0; k < colB; k++)
            //{
            //    for (int j = 0; j < rowA; j++)
            //    {
            //        for (int i = 0; i < colA; i++)
            //        {
            //            ans[j, k] += A[j, i] * B[i, k];
            //        }
            //    }
            //}

            for (int i = 0; i < colA; i++)
            {
                for (int j = 0; j < rowA; j++)
                {
                    if (A[j, i] != 0)
                    {
                        for (int k = 0; k < colB; k++)
                        {
                            ans[j, k] += A[j, i] * B[i, k];
                        }
                    }

                }
            }

            return ans;       
        }
    }
}
