using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class RotateImage
    {
        //48. Rotate Image
        /// <summary>
        /// You are given an n x n 2D matrix representing an image.
        ///Rotate the image by 90 degrees(clockwise).
        ///
        ///Note:
        ///You have to rotate the image in-place
        ///
        /// 

        /// clockwise rotate
        /// first reverse left right, then swap the symmetry 
        /// 1 2 3     3 2 1     7 4 1
        /// 4 5 6  => 6 5 4  => 8 5 2
        /// 7 8 9     9 8 7     9 6 3
        /// 
        /// 
        /// 
        /// anticlockwise rotate
        /// first reverse top botton, then swap the symmetry
        /// 1 2 3     7 8 9     3 6 9
        /// 4 5 6  => 4 5 6  => 2 5 8
        /// 7 8 9     1 2 3     1 4 7
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[,] matrix)
        {
            //print(matrix);

            int N = matrix.GetLength(0);   // square
            
            // swap left, right column
            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < N/2; i++)
                {
                    swap(matrix, j, i, j, (N - 1 - i));
                }
            }

            //print(matrix);

            // swap RT to BL diagnoal
            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < (N-j); i++)
                {
                    swap(matrix, j, i, (N-1-i), (N-1-j));
                }
            }

            //print(matrix);
        }

        private void swap(int[,] matrix, int j1, int i1, int j2, int i2)
        {
            int temp = matrix[j1, i1];
            matrix[j1, i1] = matrix[j2, i2];
            matrix[j2, i2] = temp;
        }

        private void print(int[,] matrix)
        {
            Console.WriteLine();
            int N = matrix.GetLength(0);
            for (int j =0; j <N; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    Console.Write(matrix[j, i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
