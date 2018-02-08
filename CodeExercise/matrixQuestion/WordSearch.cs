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
                    if (exitHelper(board, word, 0, i, j, visited, m, n))

                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool exitHelper(char[,] board, string word, int index, int i, int j, bool[,] visited, int M, int N)
        {
            if (index == word.Length)
            {
                return true;
            }

            if (i < 0 || i >= M)
            {
                return false;
            }

            if (j < 0 || j >= N)
            {
                return false;
            }

            if (visited[i, j])
            {
                return false;
            }

            if (word[index] != board[i, j])
            {
                return false;
            }

            visited[i, j] = true;

            if (exitHelper(board, word, index + 1, i - 1, j, visited, M, N) || exitHelper(board, word, index + 1, i + 1, j, visited, M, N)
               || exitHelper(board, word, index + 1, i, j - 1, visited, M, N) || exitHelper(board, word, index + 1, i, j + 1, visited, M, N))
            {
                return true;
            }

            visited[i, j] = false;

            return false;
        }

    }

    class WordSearch2
    {
        /// <summary>
        /// Given a 2D board and a list of words from the dictionary, find all words in the board.
        ///        Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.The same letter cell may not be used more than once in a word.
        ///
        ///       For example,
        ///       Given words = ["oath", "pea", "eat", "rain"] and board =
        ///
        ///       [   
        ///         ['o','a','a','n'],
        ///         ['e','t','a','e'],
        ///         ['i','h','k','r'],
        ///         ['i','f','l','v']
        ///       ]
        ///Return["eat", "oath"].
        ///Note:
        ///You may assume that all inputs are consist of lowercase letters a-z.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        //public IList<string> FindWords(char[,] board, string[] words)
        //{

        //}
    }
}
