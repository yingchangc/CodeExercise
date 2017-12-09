using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    /// <summary>
    /// 3   
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
            Dictionary<char, int> locationDict = new Dictionary<char, int>();
            int maxLength = 0;
            int end = 0;
            int start = 0;
            while(end < s.Length)
            {
                char c = s[end];
                if (locationDict.ContainsKey(c) && (locationDict[c] + 1 > start ))   //yic   tm[mzuxt]   t exist but is behund start 
                {
                    start = locationDict[c] + 1;   // fast move forward ex  so far "startbg" next found 'b'  . then just move to g because have compute length earlier
                    
                }

                locationDict[c] = end;    // update location of the char
                maxLength = Math.Max(maxLength, end - start + 1);

                // always move end
                end++;
            }

            return maxLength;
        }
    }
}
