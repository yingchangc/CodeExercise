using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class NQueens
    {
        /// <summary>
        /// 52. N-Queens II
        /// https://leetcode.com/problems/n-queens-ii/description/
        /// Given an integer n, return the number of distinct solutions to the n-queens puzzle.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TotalNQueens(int n)
        {
            int choices = DFSHelper2(n, 0, new List<int>());

            return choices;
        }

        private int DFSHelper2(int n, int currRow, List<int> queenLocs)
        {
            if (currRow == n)
            {
                return 1;
            }

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (!isValid(queenLocs, currRow, i))
                {
                    continue;
                }

                queenLocs.Add(i);

                sum += DFSHelper2(n, currRow + 1, queenLocs);

                queenLocs.RemoveAt(queenLocs.Count - 1);
            }

            return sum;
        }

        /// <summary>
        /// 51. N-Queens
        /// https://leetcode.com/problems/n-queens/description/
        /// The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
        /// Given an integer n, return all distinct solutions to the n-queens puzzle.
        /// Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.
        /// Input: 4
        /// Output: [
        ///          [".Q..",  // Solution 1
        ///           "...Q",
        ///           "Q...",
        ///           "..Q."],
        /// 
        ///  ["..Q.",  // Solution 2
        ///   "Q...",
        ///   "...Q",
        ///   ".Q.."]
        ///  ]
        /// Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<string>> SolveNQueens(int n)
        {
            List<List<string>> ans = new List<List<string>>();
            DFSHelper(n, new List<int>(), 0, ans);

            return ans.ToArray();
        }


        /// NQueen, cannot in the same column and the same diagnal
        /// <summary>
        /// 
        /// 
        /// [diagnal case 1]
        /// (1,2)
        ///     (x,y)
        ///         (3,4)
        /// 
        /// column - row == const
        /// 
        /// [diagnal case 2]
        ///                (1,4)
        ///           (x, y)
        ///      (3,2)
        ///      
        /// column + row = const
        /// 
        /// </summary>
        /// <param name="visited"></param>
        /// <param name="currColumn"></param>
        /// <returns></returns>
        private bool isValid(List<int> queenLocs, int currRow, int currColumn)
        {
            for (int r = 0; r < queenLocs.Count; r++)
            {
                int c = queenLocs[r];

                // the same vertical
                if (c == currColumn)
                {
                    return false;
                }

                // the same diag right
                if ((c-r) == (currColumn-currRow))
                {
                    return false;
                }

                // the same diag left
                if ((c+r) == (currColumn+currRow))
                {
                    return false;
                }
            }

            return true;
        }

        private void DFSHelper(int n, List<int> queenLocs, int currRow, List<List<string>> ans)
        {
            if (currRow == n)
            {
                List<string> res = drawAns(queenLocs, n);
                ans.Add(res);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!isValid(queenLocs, currRow, i))
                {
                    continue;
                }
                queenLocs.Add(i);

                DFSHelper(n, queenLocs, currRow+1, ans);

                queenLocs.RemoveAt(queenLocs.Count - 1);
            }
        }

        private List<string> drawAns(List<int> currLoc, int n)
        {
            List<string> ans = new List<string>();
            
            foreach(int pos in currLoc)
            {
                StringBuilder sb = new StringBuilder();

                // build each row
                for (int i = 0; i <n; i++)
                {
                    if (i == pos)
                    {
                        sb.Append('Q');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                ans.Add(sb.ToString());
            }

            return ans;
        }
    }
}
