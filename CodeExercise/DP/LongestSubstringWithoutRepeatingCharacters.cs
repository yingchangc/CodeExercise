using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    /// <summary>
    /// 3   
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
    /// Given a string, find the length of the longest substring without repeating characters.
    /// Examples:
    /// Given "abcabcbb", the answer is "abc", which the length is 3.
    /// 
    /// Sliding window technique
    /// </summary>
    public class LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            bool[] memo = new bool[256];  // map from character's ASCII to its last occured index

            int j = 0;
            int currLen = 0;
            int maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                while (j < s.Length && memo[s[j]] == false)   // yic note is s[j]
                {
                    memo[s[j++]] = true;
                    currLen++;
                }

                maxLen = Math.Max(maxLen, currLen);

                // now i can move forward
                currLen--;
                memo[s[i]] = false;
            }

            return maxLen;
        }
        

    }
}
