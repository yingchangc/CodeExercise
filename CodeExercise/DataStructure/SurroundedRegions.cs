using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 130. Surrounded Regions
    /// https://leetcode.com/problems/surrounded-regions/description/
    /// Given a 2D board containing 'X' and 'O' (the letter O), capture all regions surrounded by 'X'.
    ///
    ///A region is captured by flipping all 'O's into 'X's in that surrounded region.
    ///
    ///Example:
    ///
    ///X X X X
    ///X O O X
    ///X X O X
    ///X O X X
    ///After running your function, the board should be:
    ///
    ///X X X X
    ///X X X X
    ///X X X X
    ///X O X X
    ///Explanation:
    ///
    ///Surrounded regions shouldn’t be on the border, which means that any 'O' on the border of the board are not flipped to 'X'. Any 'O' that is not on the border and it is not connected to an 'O' on the border will be flipped to 'X'. Two cells are connected if they are adjacent cells connected horizontally or vertically.
    ///
    /// Sol:
    /// Do reverse way, check only surrounding and find all the connected 'o' mark as fix 'F' and don't change later, after done, change rest not touched 'O' to 'x'
    /// </summary>
    class SurroundedRegions
    {

        class Location
        {
            public int x;
            public int y;

            public Location(int y, int x)
            {
                this.x = x;
                this.y = y;
            }
        }

        static List<Location> deltas = new List<Location>() { new Location(1, 0), new Location(-1, 0), new Location(0, 1), new Location(0,-1)};

        public void Solve(char[,] board)
        {
            int LenY = board.GetLength(0);
            int LenX = board.GetLength(1);

            for (int i = 0; i < LenX; i++)
            {
                bfs(board, 0,      i, LenY, LenX);
                bfs(board, LenY-1, i, LenY, LenX);
            }

            for (int j = 0; j < LenY; j++)
            {
                bfs(board, j, 0,      LenY, LenX);
                bfs(board, j, LenX-1, LenY, LenX);
            }

            print(board, LenY, LenX);
        }

        private void print(char[,] board, int LenY, int LenX)
        {
            for (int j = 0; j < LenY; j++)
            {
                for (int i = 0; i < LenX; i++)
                {
                    if (board[j,i] == 'O')
                    {
                        board[j, i] = 'X';
                    }
                    else if (board[j,i] == 'F')
                    {
                        board[j, i] = 'O';
                    }

                    Console.Write(board[j, i] + " ");
                }
                Console.WriteLine();
            }
        }

        private void bfs(char[,] board, int j, int i, int LenY, int LenX)
        {
            if (board[j,i] != 'O')
            {
                return;
            }

            Queue<Location> queue = new Queue<Location>();
            queue.Enqueue(new Location(j, i));

            while(queue.Count > 0)
            {
                var loc = queue.Dequeue();
                board[loc.y, loc.x] = 'F';

                foreach (var delta in deltas)
                {
                    int newX = loc.x + delta.x;
                    int newY = loc.y + delta.y;

                    if (newX >=0 && newX < LenX && newY >=0 && newY <LenY && board[newY,newX] == 'O')
                    {
                        queue.Enqueue(new Location(newY, newX));
                    }
                }
            }
        }
    }
}
