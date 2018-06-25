using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class StringPermutation
    {
        /// <summary>
        /// 10. String Permutation II
        /// https://www.lintcode.com/problem/string-permutation-ii/description
        /// Given a string, find all permutations of it without duplicates.
        /// 
        /// Example
        /// Given "abb", return ["abb", "bab", "bba"].
        /// 
        /// Given "aabb", return ["aabb", "abab", "baba", "bbaa", "abba", "baab"].
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<String> stringPermutation2(String str)
        {
            List<string> ans = new List<string>();
            DFSHelper(str, new StringBuilder(), ans, new bool[str.Length]);

            return ans;
        }

        private void DFSHelper(string str, StringBuilder sb, List<string> ans, bool[] visited)
        {
            if (sb.Length == str.Length)
            {
                ans.Add(sb.ToString());
                return;
            }

            // to prevent duplicate
            HashSet<char> currVisited = new HashSet<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (visited[i] || currVisited.Contains(str[i]))
                {
                    continue;
                }

                currVisited.Add(str[i]);

                visited[i]= true;
                sb.Append(str[i]);

                DFSHelper(str, sb, ans, visited);

                sb.Remove(sb.Length - 1, 1);
                visited[i] = false;
            }
        }
    }
}
