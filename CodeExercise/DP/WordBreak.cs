using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class WordBreak
    {
        /// <summary>
        /// Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words. You may assume the dictionary does not contain duplicate words. 
        ///         For example, given
        /// s = "leetcode",
        /// dict = ["leet", "code"]. 
        /// Return true because "leetcode" can be segmented as "leet code". 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool CheckWordBreak(string s, IList<string> wordDict)
        {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();    // [string, isWord?]
            return WordBreakHelper(s, wordDict, visited);
        }

        private bool WordBreakHelper(string s, IList<string> wordDict, Dictionary<string, bool> visited)
        {
            // stop condition

            // no need ,since empty string will not contain in worddict and no lenght
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
            Dictionary<string, List<string>> visited = new Dictionary<string, List<string>>();
            var res = CheckWordBreakv2Helper(s, wordDict, visited);  
            return res.ToArray();
        }


        // note the return is the current level of s result, use visited to mem current s results
        // no need to check empty str case, it will become emty currentAns and memorized
        private List<string> CheckWordBreakv2Helper(string s, IList<string> wordDict, Dictionary<string, List<string>> visited)
        {
            if (visited.ContainsKey(s))
            {
                return visited[s];
            }

            List<string> currentAns = new List<string>();

            if (wordDict.Contains(s))
            {
                currentAns.Add(s);

                // update results list and keep going    ext "cannot" is a word, but can keep search "can" "not"
            }

            for (int i = 0; i < s.Length; i++)
            {
                string left = s.Substring(0, i);
                string right = s.Substring(i);

                if (wordDict.Contains(left))
                {

                    var resultsFromRight = CheckWordBreakv2Helper(right, wordDict, visited);
                    
                    foreach(string resultFromRight in resultsFromRight)
                    {
                        currentAns.Add(left + " " + resultFromRight);
                    }
                }
            }

            // update visited,  the currentAns can be null   ex due to s==empty string
            visited[s] = currentAns;

            return currentAns;
        }
    }
}
