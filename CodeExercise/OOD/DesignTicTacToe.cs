using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.OOD
{
    /// <summary>
    /// 348. Design Tic-Tac-Toe
    /// https://leetcode.com/problems/design-tic-tac-toe/
    /// Design a Tic-tac-toe game that is played between two players on a n x n grid.
    /// 
    /// You may assume the following rules:
    /// 
    /// A move is guaranteed to be valid and is placed on an empty block.
    /// Once a winning condition is reached, no more moves is allowed.
    /// A player who succeeds in placing n of their marks in a horizontal, vertical, or diagonal row wins the game.
    /// </summary>
    class DesignTicTacToe
    {
        int diag;
        int reDiag;
        int[] rows;    // sum of cols of row i
        int[] cols;    // sum of rows of col i
        bool[,] visited;
        int len;
        /** Initialize your data structure here. */
        public DesignTicTacToe(int n)
        {
            len = n;
            diag = 0;
            reDiag = 0;
            rows = new int[len];
            cols = new int[len];
            visited = new bool[len, len];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            // diag  (0,0)(1,1)(2,2)    x == y
            // reDiag 3x3 -> (0,2) (1,1) (2,0)   x+y ==2   
            //        4x4 ->  (0,3)(1,2) (2,1) (3,0)  x+y == 3
            //        2x2 -> (0,1)  (1,0)   x+y == 1

            if (visited[col, row])
            {
                return 0;
            }

            visited[col, row] = true;

            int val = 0;
            if (player == 1)
            {
                val = 1;
            }
            else
            {
                val = -1;
            }

            rows[row] += val;
            cols[col] += val;

            if (row == col)
            {
                diag += val;
            }
            if ((row + col) == (len - 1))  // ticky part        2x2    
            {
                reDiag += val;
            }
            Console.WriteLine("{0},{1},{2},{3}", rows[row], cols[col], diag, reDiag);
            return ((Math.Abs(rows[row]) == len)
                || (Math.Abs(cols[col]) == len)
                || (Math.Abs(diag) == len)
                || (Math.Abs(reDiag) == len)) ? player : 0;
        }
    }
}
