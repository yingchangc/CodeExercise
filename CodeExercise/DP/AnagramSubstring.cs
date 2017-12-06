using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    /// <summary>
    /// https://www.youtube.com/watch?v=lFG63nc9zrQ
    /// https://leetcode.com/problems/find-all-anagrams-in-a-string/discuss/  
    /// 
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
            List<int> results = new List<int>();
            Dictionary<char, int> lookupCounts = new Dictionary<char, int>();
            int count = p.Length;

            updateDictionary(lookupCounts, p);

            int start = 0;
            int end = 0;

            while (end < s.Length)
            {       
                if (lookupCounts.ContainsKey(s[end]))
                {
                    lookupCounts[s[end]]--;

                    // make sure no over substract
                    if (lookupCounts[s[end]] >= 0)
                    {
                        count--;
                    }

                    // find a result (compare p.length)?
                    if ((end - start + 1) == p.Length && count == 0)
                    {
                        results.Add(start);
                    }
                }

                // should we also move start or just end only?
                if ((end - start + 1) == p.Length)
                {
                    // ready to move "start" forward, but let's take start count back if necessary
                    if (lookupCounts.ContainsKey(s[start]))
                    {
                        lookupCounts[s[start]]++;

                        // not over substract  aaaabc    p:abc     a(0)
                        if (lookupCounts[s[start]] > 0)  /// > 0 becasue it means we have take the value back
                        {
                            count++;
                        }  
                    }
                    start++;
                }

                // always move end
                end++;
                
            }

            return results.ToArray();
        }

        private static void updateDictionary(Dictionary<char, int> lookup, string p)
        {
            foreach (char c in p)
            {
                if (lookup.ContainsKey(c))
                {
                    lookup[c]++;
                }
                else
                {
                    lookup.Add(c, 1);
                }
            }
        }
    }
}
