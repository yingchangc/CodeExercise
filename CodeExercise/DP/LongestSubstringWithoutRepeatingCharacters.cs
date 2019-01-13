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
            var visited = new HashSet<char>();

            int j = 0;

            int maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                while (j < s.Length && !visited.Contains(s[j]))
                {
                    visited.Add(s[j]);
                    j++;
                }

                maxLen = Math.Max(maxLen, (j - i));

                // i is about to mve
                visited.Remove(s[i]);
            }

            return maxLen;
        }
        

    }
}
