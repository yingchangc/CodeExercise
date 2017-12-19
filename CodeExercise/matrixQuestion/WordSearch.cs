using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.matrixQuestion
{
    class WordSearch
    {
        /// <summary>
        /// 79
        /// Given a 2D board and a word, find if the word exists in the grid. 
        ///         The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.The same letter cell may not be used more than once.
        ///        For example,
        ///  Given board = 
        /// [
        ///   ['A','B','C','E'],
        ///   ['S','F','C','S'],
        ///   ['A','D','E','E']
        /// ]
        /// word = "ABCCED", -> returns true,
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[,] board, string word)
        {
            int m = board.GetLength(0);
            int n = board.GetLength(1);
            bool[,] visited = new bool[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (existHelper(board, visited,word,0,i,j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool existHelper(char[,] board, bool[,] visited, string word, int index, int currentM, int currentN)
        {
            // stop condition
            if (index == word.Length)
            {
                return true;
            }
            
            // check out of bound
            if (currentM < 0 || currentM >= board.GetLength(0))   // note >=
            {
                return false;
            }
            if (currentN < 0 || currentN >= board.GetLength(1))
            {
                return false;
            }

            // check not visited from parent
            if (visited[currentM, currentN])
            {
                return false;
            }

            // check not the same current char
            if (board[currentM, currentN] != word[index])
            {
                return false;
            }

            // to prevent child visit again only
            visited[currentM, currentN] = true;

            // Up, left, right, down
            if ((existHelper(board, visited, word, index+1, currentM, currentN-1)) ||    // note index+1   not index++
                (existHelper(board, visited, word, index+1, currentM-1, currentN)) ||
                (existHelper(board, visited, word, index+1, currentM+1, currentN)) ||
                (existHelper(board, visited, word, index+1, currentM, currentN+1)))
            {

                // pop the visited at this level.
                //visited[currentM, currentN] = false;
                return true;

            }


            // pop the visited at this level.
            visited[currentM, currentN] = false;
            return false;
        }
    }
}
