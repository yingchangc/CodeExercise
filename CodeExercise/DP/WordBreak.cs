using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class WordBreak
    {
        private Dictionary<int, bool> visited;
        /// <summary>
        /// 139
        /// Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words. You may assume the dictionary does not contain duplicate words. 
        ///         For example, given
        /// s = "leetcode",
        /// dict = ["leet", "code"]. 
        /// Return true because "leetcode" can be segmented as "leet code". 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak_leetcode(string s, IList<string> wordDict)
        {
            var lookup = new HashSet<string>();
            var memo = new HashSet<int>();

            foreach (var w in wordDict)
            {
                lookup.Add(w);
            }

            return DFSHelper(s, 0, lookup, memo);
        }

        private bool DFSHelper(string s, int idx, HashSet<string> wordDict, HashSet<int> memo)
        {
            if (idx >= s.Length)
            {
                return true;
            }

            if (memo.Contains(idx))
            {
                return false;
            }

            for (int i = idx; i < s.Length; i++)
            {
                string prefix = s.Substring(idx, i - idx + 1);
                if (wordDict.Contains(prefix))
                {
                    if (DFSHelper(s, i + 1, wordDict, memo))
                    {
                        return true;
                    }
                }
            }

            memo.Add(idx);

            return false;
        }

        public bool CheckWordBreakPractice(string s, IList<string> wordDict)
        {
            return DFSHelper(s, 0, wordDict, new bool[s.Length]);
        }

        public bool DFSHelper(string s, int index, IList<string> wordDict, bool[] visited)
        {
            if (index >= s.Length)
            {
                return true;
            }

            if (visited[index])
            {
                return false;
            }

            visited[index] = true;

            for (int i = index; i < s.Length; i++)
            {
                var subStr = s.Substring(index, i - index + 1);
                if (wordDict.Contains(subStr) && DFSHelper(s, i+1, wordDict, visited))
                {
                    return true;
                }
            }
     

            return false;
        }

        public bool CheckWordBreak(string s, IList<string> wordDict)
        {
            visited = new Dictionary<int, bool>();    // [index, isWord?]
            return DFSHelper1(s, wordDict, 0);
        }

        private bool DFSHelper1(string s, IList<string> wordDict, int index)
        {
            if (index >= s.Length)
            {
                return true;
            }
            if (visited.ContainsKey(index))
            {
                return false;
            }

            bool canFind = false;
            for (int i = index; i < s.Length; i++)
            {
                string prefix = s.Substring(index, i-index+1);

                if (wordDict.Contains(prefix))
                {
                    canFind = DFSHelper1(s, wordDict, i + 1);

                    if (canFind)
                    {
                        canFind = true;
                        break;
                    }
                }
            }

            visited.Add(index, canFind);

            return canFind;

        }

        private bool WordBreakHelper(string s, IList<string> wordDict, Dictionary<string, bool> visited)
        {
            // stop condition

            // no need ,since empty string will not contain in worddict and no length
            //if (string.IsNullOrEmpty(s))
            //{
            //    return false;
            //}

            if (visited.ContainsKey(s))
            {
                return visited[s];
            }

            if (wordDict.Contains(s))
            {
                visited[s] = true;
                return true;
            }

            // break left and right, check dic[left]  if Y, check right recursive
            for (int i = 0; i < s.Length; i++)
            {
                string left = s.Substring(0, i);
                string right = s.Substring(i);   // test.Substring(test.Length);  // Note will be empty string

                if (!wordDict.Contains(left))
                {
                    continue;
                }
                else
                {
                    bool rightIsWord = WordBreakHelper(right, wordDict, visited);

                    if (rightIsWord)
                    {
                        visited[s] = true;
                        return true;
                    }
                }
            }

            // conclude that this s is cannot break into word
            visited[s] = false;

            return false;
        }


        /// <summary>
        /// 140
        /// Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, add spaces in s to construct a sentence where each word is a valid dictionary word. You may assume the dictionary does not contain duplicate words. 
        ///         Return all such possible sentences.
        ///         For example, given
        /// s = "catsanddog",
        /// dict = ["cat", "cats", "and", "sand", "dog"]. 
        /// A solution is ["cats and dog", "cat sand dog"].
        /// 
        /// 
        /// http://zxi.mytechroad.com/blog/leetcode/leetcode-140-word-break-ii/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public IList<string> CheckWordBreakv2(string s, IList<string> wordDict)
        {

            var memo = new Dictionary<int, List<string>>();
            var wd = new HashSet<string>();
            foreach (var w in wordDict)
            {
                wd.Add(w);
            }

            return DFSHelper(s, 0, wd, memo);

        }

        private List<string> DFSHelper(string s, int idx, HashSet<string> wordDict, Dictionary<int, List<string>> memo)
        {
            var collect = new List<string>();
            if (idx >= s.Length)
            {
                collect.Add("");
                return collect;
            }

            if (memo.ContainsKey(idx))
            {
                return memo[idx];
            }

            List<string> collection = new List<string>();
            for (int i = idx; i < s.Length; i++)
            {
                string prefix = s.Substring(idx, i - idx + 1);

                if (wordDict.Contains(prefix))
                {
                    var suffixCollection = DFSHelper(s, i + 1, wordDict, memo);

                    // child collection must have item inorder to enter loop
                    foreach (var suffix in suffixCollection)
                    {
                        if (suffix == "")
                        {
                            collection.Add(prefix);
                        }
                        else
                        {
                            collection.Add(prefix + " " + suffix);
                        }
                    }
                }
            }

            memo.Add(idx, collection);

            return collection;
        }
    }
}
