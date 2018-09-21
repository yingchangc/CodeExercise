using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class WordPattern
    {

        Dictionary<char, string> lookup;
        HashSet<string> used;
        /// <summary>
        /// 291. Word Pattern II
        /// https://leetcode.com/problems/word-pattern-ii/description/
        /// 
        /// Given a pattern and a string str, find if str follows the same pattern.
        /// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty substring in str.
        /// 
        /// Example 1:
        /// 
        /// Input: pattern = "abab", str = "redblueredblue"
        /// Output: true
        /// Example 2:
        /// 
        /// Input: pattern = pattern = "aaaa", str = "asdasdasdasd"
        /// Output: true
        /// Example 3:
        /// 
        /// Input: pattern = "aabb", str = "xyzabcxzyabc"
        /// Output: false
        /// Notes:
        /// You may assume both pattern and str contains only lowercase letters.
        /// 这里遵循的意思是一个完整的匹配，在一个字母的模式和一个非空的单词str之间有一个双向连接的模式对应。
        /// (如果a对应s，then b cannot match s。例如，给定的模式= "ab"， str = "ss"，返回false）。

        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool WordPatternMatchPractice(string pattern, string str)
        {
            return DFSHelperPractice(pattern, 0, str, new Dictionary<char, string>(), new HashSet<string>());
        }

        private bool DFSHelperPractice(string pattern, int pidx, string str, Dictionary<char, string> lookup, HashSet<string> uniqueSet)
        {
            if (string.IsNullOrEmpty(str) && pidx >= pattern.Length)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(str) && pidx < pattern.Length)
            {
                return false;
            }
            else if (pidx >= pattern.Length)
            {
                return false;
            }

            char c = pattern[pidx];

            if (!lookup.ContainsKey(c))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string curr = str.Substring(0, i - 0 + 1);

                    if (uniqueSet.Contains(curr))
                    {
                        continue;
                    }

                    lookup.Add(c, curr);
                    uniqueSet.Add(curr);

                    string nxt = str.Substring(i + 1);
                    if (DFSHelperPractice(pattern, pidx+1, nxt, lookup, uniqueSet))
                    {
                        return true;
                    }

                    uniqueSet.Remove(curr);
                    lookup.Remove(c);
                }
            }
            else
            {
                string matchStr = lookup[c];
                if (CanMatchPrefix(str, matchStr))
                {
                    string nxt = str.Substring(matchStr.Length);
                    return DFSHelperPractice(pattern, pidx + 1, nxt, lookup, uniqueSet);
                }
                return false;

            }

            return false;

        }

        private bool CanMatchPrefix(string str, string prefix)
        {
            if (prefix.Length > str.Length)
            {
                return false;
            }

            for (int i = 0; i < prefix.Length; i++)
            {
                if (str[i] != prefix[i])
                {
                    return false;
                }
            }

            return true;
        }

        
    }
}
