using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class LongestSubstringAtLeastKRepeatingCharacters
    {
        /// <summary>
        /// 395. Longest Substring with At Least K Repeating Characters
        /// https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters/
        /// Find the length of the longest substring T of a given string (consists of lowercase letters only) such that every character in T appears no less than k times.
        /// 
        /// Example 1:
        /// 
        /// Input:
        /// s = "aaabb", k = 3
        /// 
        /// Output:
        /// 3
        /// 
        /// The longest substring is "aaa", as 'a' is repeated 3 times.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LongestSubstring(string s, int k)
        {
            int maxLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int mask = 0;

                Dictionary<char, int> lookup = new Dictionary<char, int>();

                for (int j = i; j < s.Length; j++)
                {
                    if (!lookup.ContainsKey(s[j]))
                    {
                        lookup.Add(s[j], 0);
                    }
                    lookup[s[j]]++;


                    mask |= 1 << s[j];

                    if (lookup[s[j]] >= k)
                    {
                        mask &= ~(1 << s[j]);
                    }

                    if (mask == 0)
                    {
                        maxLen = Math.Max(maxLen, j - i + 1);
                    }
                    
                }


            }

            return maxLen;

        }

        private bool Satistifed(Dictionary<char, int> lookup, int k)
        {
            foreach (char c in lookup.Keys)
            {
                if (lookup[c] < k)
                {
                    return false;
                }

            }

            return true;
        }
    }
}
