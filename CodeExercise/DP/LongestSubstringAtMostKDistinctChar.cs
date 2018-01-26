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
            Dictionary<char, int> memo = new Dictionary<char, int>();

            int j = 0;
            int currLen = 0;
            int maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                while (j < s.Length && (memo.Keys.Count < k || (memo.Keys.Count==k && memo.ContainsKey(s[j]))))    // < count < k or count ==k  but old key
                {
                    currLen++;

                    if (!memo.ContainsKey(s[j]))
                    {
                        memo.Add(s[j], 0);
                    }
                    memo[s[j++]]++;
                }

                maxLen = Math.Max(maxLen, currLen);

                // now ready to move i
                memo[s[i]]--;
                if (memo[s[i]] == 0)
                {
                    memo.Remove(s[i]);
                }
                currLen--;
            }

            return maxLen;
        }
    }
}
