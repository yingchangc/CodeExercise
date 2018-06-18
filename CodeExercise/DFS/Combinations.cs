using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class Combinations
    {
        private int max = 0;
        private int setSize = 0;
        /// <summary>
        /// 77. Combinations
        /// https://leetcode.com/problems/combinations/description/
        /// Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.
        ///Example:
        ///
        ///Input: n = 4, k = 2
        ///Output:
        ///[
        ///  [2,4],
        ///  [3,4],
        ///  [2,3],
        ///  [1,2],
        ///  [1,3],
        ///  [1,4],
        ///]
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            max = n;
            setSize = k;

            List<List<int>> ans = new List<List<int>>();
            List<int> currPath = new List<int>();

            DFSHelper(ans, currPath, 1);

            return ans.ToArray();
        }

        private void DFSHelper(List<List<int>> ans, List<int> currPath, int idx)
        {
            if (idx > max)
            {
                return;
            }

            for (int i = idx; i <= max; i++)
            {
                currPath.Add(i);   // add

                if (currPath.Count == setSize)
                {
                    List<int> copy = new List<int>(currPath);
                    ans.Add(copy);
                }
                else
                {
                    DFSHelper(ans, currPath, i + 1);
                }

                currPath.RemoveAt(currPath.Count - 1);   //remove
            }
        }
    }
}
