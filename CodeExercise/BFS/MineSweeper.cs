using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class MineSweeper
    {
        /// <summary>
        /// 529. Minesweeper
        /// https://leetcode.com/problems/minesweeper/
        /// You are given a 2D char matrix representing the game board. 'M' represents an unrevealed mine, 'E' represents an unrevealed empty square, 'B' represents a revealed blank square that has no adjacent (above, below, left, right, and all 4 diagonals) mines, digit ('1' to '8') represents how many mines are adjacent to this revealed square, and finally 'X' represents a revealed mine.
        /// 
        /// Now given the next click position(row and column indices) among all the unrevealed squares('M' or 'E'), return the board after revealing this position according to the following rules:
        /// 
        /// If a mine('M') is revealed, then the game is over - change it to 'X'.
        /// If an empty square('E') with no adjacent mines is revealed, then change it to revealed blank('B') and all of its adjacent unrevealed squares should be revealed recursively.
        /// If an empty square('E') with at least one adjacent mine is revealed, then change it to a digit('1' to '8') representing the number of adjacent mines.
        /// Return the board when no more squares will be revealed.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="click"></param>
        /// <returns></returns>
        public char[,] UpdateBoard(char[,] board, int[] click)
        {
            int y = click[0];
            int x = click[1];

            if (board[y, x] == 'M')
            {
                board[y, x] = 'X';
            }
            else
            {
                if (!HandleEmptySurroundingWithM(board, y, x))
                {
                    HandleEmptyPropagate(board, y, x);
                }
            }

            return board;
        }

        private bool HandleEmptySurroundingWithM(char[,] board, int y, int x)
        {
            int lenY = board.GetLength(0);
            int lenX = board.GetLength(1);

            var deltas = new List<Loc>()
        {
            new Loc(-1,-1),
            new Loc( 0,-1),
            new Loc( 1,-1),
            new Loc(-1,0),
            new Loc( 1,0),
            new Loc(-1,1),
            new Loc( 0,1),
            new Loc( 1,1),
        };

            int count = 0;

            foreach (var delta in deltas)
            {
                int ny = y + delta.y;
                int nx = x + delta.x;

                if (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && board[ny, nx] == 'M')
                {
                    count++;
                }
            }

            if (count > 0)
            {
                board[y, x] = (char)count.ToString().ToCharArray()[0];
                return true;
            }

            return false;
        }

        private void HandleEmptyPropagate(char[,] board, int y, int x)
        {
            int lenY = board.GetLength(0);
            int lenX = board.GetLength(1);
            bool[,] visited = new bool[lenY, lenX];
            Queue<Loc> que = new Queue<Loc>();
            que.Enqueue(new Loc(y, x));
            visited[y, x] = true;

            var deltas = new List<Loc>()
        {
            new Loc(-1,-1),
            new Loc(-1,0),
            new Loc(-1,1),
            new Loc(0,-1),
            new Loc(0,1),
            new Loc(1,-1),
            new Loc(1,0),
            new Loc(1,1)
        };

            while (que.Count > 0)
            {
                var curr = que.Dequeue();

                if (!HandleEmptySurroundingWithM(board, curr.y, curr.x))
                {
                    board[curr.y, curr.x] = 'B';

                    foreach (var delta in deltas)
                    {
                        int ny = curr.y + delta.y;
                        int nx = curr.x + delta.x;

                        if (nx >= 0 && nx < lenX && ny >= 0 && ny < lenY && !visited[ny, nx] && board[ny, nx] == 'E')
                        {
                            que.Enqueue(new Loc(ny, nx));
                            visited[ny, nx] = true;
                        }
                    }
                }



            }
        }


        public class Loc
        {
            public int x;
            public int y;
            public Loc(int y, int x)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
