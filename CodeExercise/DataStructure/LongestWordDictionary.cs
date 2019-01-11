using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class LongestWordDictionary
    {
        /// <summary>
        /// 720. Longest Word in Dictionary  [review]
        /// https://leetcode.com/problems/longest-word-in-dictionary/description/
        /// Given a list of strings words representing an English Dictionary, find the longest word in words that can be built one character at a time by other words in words. If there is more than one possible answer, return the longest word with the smallest lexicographical order.
        /// 
        /// If there is no answer, return the empty string.
        /// Example 1:
        /// Input: 
        /// words = ["w","wo","wor","worl", "world"]
        ///         Output: "world"
        /// Explanation: 
        /// The word "world" can be built one character at a time by "w", "wo", "wor", and "worl".
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string LongestWord(string[] words)
        {
            HashSet<string> lookup = new HashSet<string>();

            Array.Sort(words, new WordComparer());

            string ans = "";

            foreach (var w in words)
            {
                if (w.Length == 1)
                {
                    lookup.Add(w);

                    if (ans.Length < w.Length)
                    {
                        ans = w;
                    }
                }
                else if (lookup.Contains(w.Substring(0, w.Length - 1)))
                {
                    lookup.Add(w);

                    if (ans.Length < w.Length)
                    {
                        ans = w;
                    }
                }
            }

            return ans;
        }

        public class WordComparer : IComparer<string>
        {
            public int Compare(string s1, string s2)
            {
                if (s1.Length != s2.Length)
                {
                    return s1.Length.CompareTo(s2.Length);
                }
                return s1.CompareTo(s2);
            }
        }
    }
}
