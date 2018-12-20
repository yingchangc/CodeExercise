using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.matrixQuestion
{
    class ValidSudoku
    {
        /// <summary>
        /// 36. Valid Sudoku
        /// https://leetcode.com/problems/valid-sudoku/
        /// Determine if a 9x9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
        /// 
        /// Each row must contain the digits 1-9 without repetition.
        /// Each column must contain the digits 1-9 without repetition.
        /// Each of the 9 3x3 sub-boxes of the grid must contain the digits 1-9 without repetition
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[,] board)
        {
            int lenY = board.GetLength(0);
            int lenX = board.GetLength(1);

            // row
            for (int y = 0; y < lenY; y++)
            {
                if (!IsValidSection(board, 0, y, 8, y))
                {
                    return false;
                }
            }
            Console.WriteLine("Pass row");
            // col
            for (int x = 0; x < lenX; x++)
            {
                if (!IsValidSection(board, x, 0, x, 8))
                {
                    return false;
                }
            }
            Console.WriteLine("Pass col");


            // square
            for (int y = 0; y <= lenY - 3; y += 3)
            {
                for (int x = 0; x <= lenX - 3; x += 3)
                {
                    if (!IsValidSection(board, x, y, x + 2, y + 2))
                    {
                        return false;
                    }
                }
            }
            Console.WriteLine("Pass Square");

            return true;
        }

        private bool IsValidSection(char[,] board, int x1, int y1, int x2, int y2)
        {
            HashSet<char> seen = new HashSet<char>();
            for (int y = y1; y <= y2; y++)
            {
                for (int x = x1; x <= x2; x++)
                {
                    if (board[y, x] == '.')
                    {
                        continue;
                    }

                    if (seen.Contains(board[y, x]))
                    {
                        return false;
                    }
                    seen.Add(board[y, x]);
                }
            }

            return true;
        }
    }
}
