using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class SubStringRelated
    {
        /// <summary>
        /// 159. Longest Substring with At Most Two Distinct Characters 
        /// https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/submissions/
        /// NOTE: YIC Not run in leetcode
        /// Longest Substring with At Most Two Distinct Characters
        /// https://www.youtube.com/watch?v=CIQzMlDwHnM
        /// 
        /// eceba   
        /// 
        /// the max lengh is 3 "ece"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            Dictionary<char, int> lookup = new Dictionary<char, int>();

            int len = s.Length;
            int j = 0;

            int ans = 0;

            for (int i = 0; i < len; i++)
            {
                while (j < len && lookup.Keys.Count <= 2)
                {
                    var c = s[j];
                    if (!lookup.ContainsKey(c))
                    {
                        lookup.Add(c, 0);
                    }
                    lookup[c]++;

                    if (lookup.Keys.Count <= 2)
                    {
                        ans = Math.Max(ans, (j - i + 1));
                    }

                    j++;
                }

                // ready to move
                lookup[s[i]]--;

                if (lookup[s[i]] == 0)
                {
                    lookup.Remove(s[i]);
                }
            }

            return ans;
        }


        //TODO
        //30
        //https://leetcode.com/problems/substring-with-concatenation-of-all-words/description/




        /// <summary>
        /// 76
        /// Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n). 
        /// For example,
        /// S = "ADOBECODEBANC"
        /// T = "ABC"
        /// Minimum window is "BANC". 
        /// 
        /// YIC: Also need to check "AnagramSubstring" problem
        /// 
        /// https://leetcode.com/problems/minimum-window-substring/description/
        /// 
        /// /// // sliding window
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow(string s, string t)
        {
            int slen = s.Length;
            int tlen = t.Length;

            int ansLen = int.MaxValue;
            string ans = string.Empty;

            // build lookup table
            Dictionary<char, int> lookup = new Dictionary<char, int>();
            foreach(char c in t)
            {
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, 0);
                }
                lookup[c]++;
            }

            // two pointer pattern
            int score = tlen;
            int j = 0;  // j always move forward

            for (int i = 0; i < slen; i++)
            {
                while(j < slen && score > 0)
                {
                    if (lookup.ContainsKey(s[j]))
                    {
                        if (lookup[s[j]] >0)    // yic 
                        {
                            score--;
                        }

                        lookup[s[j]]--; 
                    }

                    j++;
                }

                if (score == 0)
                {
                    int tempLen = (j-1) - i + 1;        // yic  Note:  j-1 because j++ before out of while loop
                    if (ansLen > tempLen)
                    {
                        ans = s.Substring(i, tempLen);   // startidx, len
                        ansLen = tempLen;           // yic
                    }   
                }

                // i is about to move
                if (lookup.ContainsKey(s[i]))
                {
                    lookup[s[i]]++;

                    if (lookup[s[i]] > 0)    // yic 
                    {
                        score++;
                    }
                }
            }

            return ans;

        }

        public string MinWindowOld(string s, string t)
        {
            int start = 0;
            int end = 0;
            int count = t.Length;

            // put template in Dict with count
            Dictionary<char, int> lookupCount = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (lookupCount.ContainsKey(c))
                {
                    lookupCount[c]++;
                }
                else
                {
                    lookupCount[c] = 1;
                }
            }

            bool found = false;
            int finalHead = 0;
            Dictionary<char, int> charLocDict = new Dictionary<char, int>();
            int minLength = int.MaxValue;

            // now walk end
            while (end < s.Length)
            {
                char c = s[end];
                if (lookupCount.ContainsKey(c))
                {
                    lookupCount[c]--;

                    if (lookupCount[c] >= 0)  // in t
                    {
                        count--;
                    }

                    if (count == 0)
                    {
                        found = true;

                        while (count == 0)
                        {
                            // keep find best answer
                            // since start may not be optimal   aaabc  [abc]
                            int temp = end - start + 1;
                            if (minLength > temp)
                            {
                                minLength = temp;
                                finalHead = start;
                            }

                            // move start to until invalid   ie count >1
                            char schar = s[start];
                            if (lookupCount.ContainsKey(schar))
                            {
                                lookupCount[schar]++;
                                
                                if (lookupCount[schar] > 0)
                                {
                                    count++;
                                }
                            }

                            start++;
                        }
                    }
                }

                end++;   // always increase
            }

            if (found)
            {
                return s.Substring(finalHead, minLength);
            }

            return "";
        }
    }

}
