using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class PartitionLabels
    {
        /// <summary>
        /// 763. Partition Labels
        /// https://leetcode.com/problems/partition-labels/description/
        /// 
        /// A string S of lowercase letters is given. We want to partition this string into as many parts as possible so that each letter appears in at most one part, and return a list of integers representing the size of these parts.
        /// 
        /// Example 1:
        /// Input: S = "ababcbacadefegdehijhklij"
        /// Output: [9,7,8]
        ///         Explanation:
        /// The partition is "ababcbaca", "defegde", "hijhklij".
        /// This is a partition so that each letter appears in at most one part.
        /// A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public IList<int> PartitionLabelSolver(string S)
        {
            Dictionary<char, int> lookup = new Dictionary<char, int>();

            // record the last char loc
            for (int i = 0; i < S.Length; i++)
            {
                char c = S[i];
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, i);
                }
                else
                {
                    lookup[c] = i;
                }
            }

            foreach (char c in lookup.Keys)
            {
                Console.WriteLine("last Loc of " + c + " at " + lookup[c]);
            }

            List<int> ans = new List<int>();

            int preIndex = -1;

            int segMaxLoc = -1;

            for (int i = 0; i < S.Length; i++)
            {
                char c = S[i];
                segMaxLoc = Math.Max(segMaxLoc, lookup[c]);

                if (i == segMaxLoc)
                {
                    ans.Add(i - preIndex);
                    preIndex = i;
                }
            }

            if (ans.Count == 0)
            {
                ans.Add(S.Length);
            }

            return ans;
        }
    }
}
