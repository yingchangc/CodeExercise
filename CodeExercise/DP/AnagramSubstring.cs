using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/submissions/
    /// https://leetcode.com/problems/minimum-window-substring/
    /// https://leetcode.com/problems/minimum-window-subsequence/
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// https://leetcode.com/problems/substring-with-concatenation-of-all-words/
    /// https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/
    /// https://leetcode.com/problems/find-all-anagrams-in-a-string/
    /// https://leetcode.com/problems/fruit-into-baskets/
    /// 
    /// TODO 
    /// gas station
    /// https://www.youtube.com/watch?v=KV2W-NPHPa4
    /// </summary>
    class AnagramSubstring
    {
        // sliding window    rely on end to --, and start to ++
        /// <summary>
        /// 438. Find All Anagrams in a String 
        /// Input:
        /// s: "cbaebabacd" p: "abc"
        /// 
        /// Output:
        /// [0, 6]
        /// 
        ///         Explanation:
        /// The substring with start index = 0 is "cba", which is an anagram of "abc".
        /// The substring with start index = 6 is "bac", which is an anagram of "abc".
        /// 
        /// Example 2: 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static IList<int> FindAnagrams(string s, string p)
        {
            List<int> ans = new List<int>();

            int j = 0;

            var lookup = new Dictionary<char, int>();
            foreach (char c in p)
            {
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, 0);
                }
                lookup[c]++;
            }

            var score = p.Length;

            for (int i = 0; i < s.Length; i++)
            {
                while (j < s.Length && (j - i) < p.Length)
                {
                    if (lookup.ContainsKey(s[j]))
                    {
                        if (lookup[s[j]] > 0)
                        {
                            score--;
                        }

                        lookup[s[j]]--;
                    }

                    j++;

                }

                if ((j - i) == p.Length && score == 0)
                {
                    ans.Add(i);
                }

                // i is about to move
                if (lookup.ContainsKey(s[i]))
                {
                    lookup[s[i]]++;

                    if (lookup[s[i]] > 0)
                    {
                        score++;
                    }
                }
            }

            return ans;
        }

        
    }
}
