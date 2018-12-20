using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.matrixQuestion
{
    class SudokuSolver
    {
        /// <summary>
        /// 37. Sudoku Solver
        /// Write a program to solve a Sudoku puzzle by filling the empty cells.
        /// 
        /// A sudoku solution must satisfy all of the following rules:
        /// 
        /// Each of the digits 1-9 must occur exactly once in each row.
        /// Each of the digits 1-9 must occur exactly once in each column.
        /// Each of the the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
        /// Empty cells are indicated by the character '.'.
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku(char[,] board)
        {

            DFSHelper(board, 0, 0);

        }

        private bool DFSHelper(char[,] board, int x, int y)
        {
            if (x == 9)
            {
                x = 0;
                y++;
            }

            // finish
            if (y == 9)
            {
                return true;
            }

            if (board[y, x] != '.')
            {
                return DFSHelper(board, x + 1, y);
            }

            int sqIdX = (x / 3) * 3;   // yic   easy to get wrong here
            int sqIdY = (y / 3) * 3;

            char[] candidates = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            foreach (var c in candidates)
            {
                board[y, x] = c;

                if (IsValid(board, sqIdX, sqIdY, sqIdX + 2, sqIdY + 2)   // square
                    && IsValid(board, 0, y, 8, y)  // row
                    && IsValid(board, x, 0, x, 8)  // col
                    && DFSHelper(board, x + 1, y))
                {
                    return true;
                }


                board[y, x] = '.';   // not okay  reset,

            }

            return false;
        }



        private bool IsValid(char[,] board, int x1, int y1, int x2, int y2)
        {
            HashSet<char> seen = new HashSet<char>();

            // square
            for (int y = y1; y <= y2; y++)
            {
                for (int x = x1; x <= x2; x++)
                {
                    if (board[y, x] == '.')  // yic don't forget
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
