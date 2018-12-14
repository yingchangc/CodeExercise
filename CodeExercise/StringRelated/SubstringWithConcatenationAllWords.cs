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
            List<int> ans = new List<int>();
            int wordsCount = words.Length;

            // [1] initial condition check
            if (string.IsNullOrEmpty(s) || wordsCount == 0)
            {
                return ans;
            }

            int singleWordLen = words[0].Length;

            int patternLen = singleWordLen * wordsCount;
            if (s.Length < patternLen)
            {
                return ans;
            }

            // [2] word:freq
            Dictionary<string, int> lookup = new Dictionary<string, int>();
            foreach(string w in words)
            {
                if (!lookup.ContainsKey(w))
                {
                    lookup.Add(w, 0);
                }
                lookup[w]++;
            }

            // [3] check scan i 0~ len-patternLen
            for (int i = 0; i <= s.Length - patternLen; i++)
            {
                if (Helper(s.Substring(i, patternLen), lookup, singleWordLen))
                {
                    ans.Add(i);
                }

            }

            return ans;

        }

        private bool Helper(string str, Dictionary<string, int> lookup, int wordLen)
        {
            Dictionary<string, int> seen = new Dictionary<string, int>();

            for (int i=0; i <= str.Length-wordLen; i+=wordLen)
            {
                var currW = str.Substring(i, wordLen);
                if (!lookup.ContainsKey(currW))
                {
                    return false;
                }

                if (!seen.ContainsKey(currW))
                {
                    seen.Add(currW, 0);
                }
                seen[currW]++;               // ba ab ab     ["ab" "ab" "ba"]    

                if (seen[currW] > lookup[currW])    // exceed dictionary count
                {
                    return false;
                }
            }

            return true;
        }
    }
}
