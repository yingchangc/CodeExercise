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
        public static IList<int> FindAnagramsPractice(string s, string p)
        {
            List<int> res = new List<int>();

            if (s == null || p == null || s.Length == 0 || s.Length < p.Length)
            {
                return res;
            }

            Dictionary<char, int> lookup = new Dictionary<char, int>();

            for (int i = 0; i < p.Length; i++)
            {
                if (!lookup.ContainsKey(p[i]))
                {
                    lookup.Add(p[i], 0);
                }
                lookup[p[i]]++;
            }

            int totalCount = p.Length;

            int j = 0;
            for(int i = 0; i < s.Length; i++)
            {
                while (j < s.Length && (j-i+1) <= p.Length)
                {
                    if (lookup.ContainsKey(s[j]))
                    {
                        if (lookup[s[j]] > 0)
                        {
                            totalCount--;
                        }

                        lookup[s[j]]--;
                    }

                    j++;
                }

                if (totalCount == 0)
                {
                    res.Add(i);
                }

                // ready to move i
                if (lookup.ContainsKey(s[i]))
                {
                    lookup[s[i]]++;

                    if (lookup[s[i]] > 0)
                    {
                        totalCount++;
                    }
                }
            }

            return res;

        }
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
                // [1]perform substract part  
                if (lookupCounts.ContainsKey(s[end]))
                {
                    lookupCounts[s[end]]--;

                    // make sure no over substract
                    if (lookupCounts[s[end]] >= 0)
                    {
                        count--;
                    }

                    // find a result (compare p.length)?  no need to check length
                    if (count == 0)
                    {
                        results.Add(start);
                    }
                }

                // [2]perform move.
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
