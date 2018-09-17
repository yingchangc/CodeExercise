using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    /// <summary>
    /// 409. Longest Palindrome 
    /// Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.
    /// This is case sensitive, for example "Aa" is not considered a palindrome here.
    /// Note:
    /// Assume the length of given string will not exceed 1,010. 
    /// Example: 
    /// Input:
    /// "abccccdd"
    /// 
    /// Output:
    /// 7
    /// 
    /// Explanation:
    /// One longest palindrome that can be built is "dccaccd", whose length is 7.
    /// 
    /// 
    /// Note: order not matter~ can rearrange order.
    /// </summary>
    public class LongestPalindrome
    {
        /// <summary>
        /// First, characters are counted. Even occurring characters (v[i]%2 == 0) can always be used to build a palindrome. 
        /// For every odd occurring character (v[i]%2 == 1), v[i]-1 characters can be used. Res is incremented if there is at least one 
        /// character with odd occurrence number.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LongestPalindromeSize(string s)
        {
            Dictionary<char, int> computeArray = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (computeArray.ContainsKey(c))
                {
                    computeArray[c]++;
                }
                else
                {
                    computeArray[c] = 1;
                }
            }

            bool hasOdd = false;
            int ans = 0;

            foreach(var item in computeArray)
            {
                if (item.Value %2 == 0)
                {
                    ans += item.Value;
                }
                else
                {
                    ans += (item.Value - 1); // *YIC value -1 can be used. only 1 case will be 0.
                    hasOdd = true;
                }
            }

            if (hasOdd)
            {
                ans += 1;
            }
            return ans;
        }
    }
}
