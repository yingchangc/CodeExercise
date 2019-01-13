using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class SubstringWithConcatenationAllWords
    {
        /// <summary>
        /// 30. Substring with Concatenation of All Words
        /// https://leetcode.com/problems/substring-with-concatenation-of-all-words/
        /// You are given a string, s, and a list of words, words, that are all of the same length. Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.
        /// 
        /// Example 1:
        /// 
        /// Input:
        ///   s = "barfoothefoobarman",
        ///   words = ["foo","bar"]
        ///         Output: [0,9]
        ///         Explanation: Substrings starting at index 0 and 9 are "barfoor" and "foobar" respectively.
        ///         The output order does not matter, returning[9, 0] is fine too.
        ///         
        /// 
        /// sol:
        /// 
        /// walk through each i loc in s.
        /// 
        /// for each pattern length string, check every word length   baabab -> "ba", "ab" "ab"    and see if exist in dictionary
        /// use another map  as seen to count freq,
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring(string s, string[] words)
        {
            if (words.Length == 0)
            {
                return new List<int>();
            }

            int wLen = words[0].Length;

            var lookup = new Dictionary<string, int>();  // may have multiple
            foreach (var w in words)
            {
                if (!lookup.ContainsKey(w))
                {
                    lookup.Add(w, 0);
                }
                lookup[w]++;
            }

            List<int> ans = new List<int>();
            for (int i = 0; i <= (s.Length - wLen * words.Length); i++)
            {
                if (CanMatch(s, i, lookup, wLen, words.Length))
                {
                    ans.Add(i);
                }
            }

            return ans;
        }

        private bool CanMatch(string s, int idx, Dictionary<string, int> lookup, int wLen, int wCount)
        {
            var record = new Dictionary<string, int>();

            for (int i = idx; i < idx + wLen * wCount; i += wLen)
            {
                string sub = s.Substring(i, wLen);
                if (lookup.ContainsKey(sub))
                {
                    if (!record.ContainsKey(sub))
                    {
                        record.Add(sub, 0);
                    }
                    record[sub]++;

                    if (record[sub] > lookup[sub])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;

        }
    }
}
