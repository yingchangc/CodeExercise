using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class GenerateParentheses
    {
        private int total = 0;
        /// <summary>
        /// 22. Generate Parentheses
        /// https://leetcode.com/problems/generate-parentheses/description/
        /// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        /// For example, given n = 3, a solution set is:
        /// 
        /// [
        ///   "((()))",
        ///   "(()())",
        ///   "(())()",
        ///   "()(())",
        ///   "()()()"
        /// ]
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesisSolver(int n)
        {
            total = n;
            List<string> ans = new List<string>();
            DFSHelper(0, 0, "", ans);

            return ans.ToArray();
        }

        private void DFSHelper(int left, int right, string currPath, List<string> ans)
        {
            if (left == total && right == total)
            {
                ans.Add(currPath);
                return;
            }

            // left must >= right
            if (left == right)
            {
                DFSHelper(left + 1, right, (currPath + "("), ans);
            }
            else
            {
                if (left < total)
                {
                    DFSHelper(left + 1, right, (currPath + "("), ans);
                }

                DFSHelper(left, right + 1, currPath + ")", ans);
            }
        }
    }
}
