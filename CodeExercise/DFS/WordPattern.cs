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
        public bool WordPatternMatch(string pattern, string str)
        {
            lookup = new Dictionary<char, string>();   // a -> "red"   b-> "blue"
            used = new HashSet<string>();    // "red"   "blue"
            var ans = DFSHelper(pattern, 0, str, 0);

            return ans;
        }

        private bool isPrefix(string str, string prefix, int start)
        {
            int prefixLen = prefix.Length;

            if (start + prefixLen -1 >= str.Length)
            {
                return false;
            }

            for (int i = 0; i < prefixLen; i++)
            {
                if (prefix[i] != str[start+i])
                {
                    return false;
                }
            }

            return true;
        }

        private bool DFSHelper(string pattern, int pidx, string str, int stridx)
        {
            if (pidx == pattern.Length && stridx ==str.Length)
            {
                return true;
            }
            else if (pidx == pattern.Length || stridx == str.Length)
            {
                // either pattern used up or origin string used up
                return false;
            }

            char c = pattern[pidx];

            if(lookup.ContainsKey(c))
            {
                string substr = lookup[c];

                if (isPrefix(str, substr, stridx))
                {
                    int nextStrIdx = stridx + substr.Length;
                    return DFSHelper(pattern, pidx + 1, str, nextStrIdx);
                }
                return false;
            }
            else
            {
                for (int i = stridx; i < str.Length; i++)
                {
                    string substr = str.Substring(stridx, i - stridx + 1);
                    if (!used.Contains(substr) && isPrefix(str, substr, stridx) )
                    {   // yic before add b->"red"   need to check if the other pattern has use "red" 

                        lookup.Add(c, substr);
                        used.Add(substr);

                        int nextStrIdx = stridx + substr.Length;
                        if (DFSHelper(pattern, pidx + 1, str, nextStrIdx))
                        {
                            return true;
                        }

                        lookup.Remove(c);
                        used.Remove(substr);
                    }
                }
            }

            return false;
            
        }
    }
}
