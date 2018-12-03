using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class LongestSubstringAtMostKDistinctChar
    {
        /// <summary>
        /// leetcode 340
        /// https://www.lintcode.com/problem/longest-substring-with-at-most-k-distinct-characters/description
        /// https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/
        /// Given a string s, find the length of the longest substring T that contains at most k distinct characters.
        /// 
        /// Example
        ///        For example, Given s = "eceba", k = 3,
        /// 
        ///        T is "eceb" which its length is 4. 
        /// http://www.lintcode.com/en/problem/longest-substring-with-at-most-k-distinct-characters/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstringKDistinct(String s, int k)
        {
            Dictionary<char, int> lookup = new Dictionary<char, int>();

            int j = 0;
            int maxLen = 0;

            string ans = "";

            for (int i = 0; i < s.Length; i++)
            {
                while (j < s.Length && lookup.Keys.Count <= k)
                {
                    char c = s[j];
                    if (!lookup.ContainsKey(c))
                    {
                        lookup.Add(c, 0);
                    }
                    lookup[c]++;

                    if (lookup.Keys.Count <= k && maxLen < (j - i + 1))
                    {
                        maxLen = j - i + 1;
                        ans = s.Substring(i, maxLen);
                    }
                    j++;
                }

                // ready to move i
                lookup[s[i]]--;

                if (lookup[s[i]] == 0)
                {
                    lookup.Remove(s[i]);
                }

            }

            return maxLen;
        }
    }
}
