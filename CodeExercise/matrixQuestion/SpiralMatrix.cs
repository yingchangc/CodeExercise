using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.matrixQuestion
{
    class SpiralMatrix
    {
        /// <summary>
        /// 54. Spiral Matrix
        /// https://leetcode.com/problems/spiral-matrix/
        /// Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.
        /// 
        /// Example 1:
        /// 
        /// Input:
        /// [
        ///  [ 1, 2, 3 ],
        ///  [ 4, 5, 6 ],
        ///  [ 7, 8, 9 ]
        /// ]
        /// Output: [1,2,3,6,9,8,7,4,5]
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> SpiralOrder(int[,] matrix)
        {
            List<int> ans = new List<int>();
            int lenY = matrix.GetLength(0);
            int lenX = matrix.GetLength(1);
            SpiralLayer(matrix, 0, 0, lenY - 1, lenX - 1, ans);

            return ans;
        }

        private void SpiralLayer(int[,] matrix, int top, int left, int bottom, int right, List<int> ans)
        {
            while (left <= right && top <= bottom)
            {
                //1 2 3
                //4 5 6
                //7 8 9

                // top row   1 2 3
                for (int i = left; i <= right; i++)
                {
                    ans.Add(matrix[top, i]);
                }

                // right col   6
                for (int j = top + 1; j < bottom; j++)
                {
                    ans.Add(matrix[j, right]);
                }

                // bottom    7<- 8 <-9
                if (top != bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        ans.Add(matrix[bottom, i]);
                    }
                }

                // left col  4  
                if (left != right)
                {
                    for (int j = bottom - 1; j > top; j--)
                    {
                        ans.Add(matrix[j, left]);
                    }
                }
                left++;
                right--;
                top++;
                bottom--;
            }

        }
    }
}
