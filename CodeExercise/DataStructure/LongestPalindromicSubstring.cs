using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class LongestPalindromicSubstring
    {
        /// <summary>
        /// 5
        /// https://leetcode.com/problems/longest-palindromic-substring/description/
        /// Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
        /// 
        /// Input: "babad"
        /// Output: "bab"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            int N = s.Length;

            int maxLen = 0;
            string ans = string.Empty;
            for (int i = 0; i<N; i++)
            {
                // odd
                int oddLen = longestPalindromeInSubString(s, i, i);
                
                if (maxLen <= oddLen)
                {
                    maxLen = oddLen;
                    ans = s.Substring(i-maxLen/2, maxLen);   
                }
                // even
                int evenLen = longestPalindromeInSubString(s, i, i+1);
                if (maxLen <= evenLen)
                {
                    maxLen = evenLen;
                    ans = s.Substring(i - evenLen / 2 + 1, evenLen);
                    
                }
            }

            return ans;
        }

        private int longestPalindromeInSubString(string s, int left, int right)
        {
            int len = 0;
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                len = (right - left) + 1 ;
                left--;
                right++;
            }

            return len;

        }

        public string LongestPalindromePractice(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            string ans = "";

            for (int i = 0; i < s.Length; i++)
            {
                // odd
                var oddstr = FindPalindromeFromCenter(s, i, i);
                if (ans.Length < oddstr.Length)
                {
                    ans = oddstr;
                }


                // even
                var evenstr = FindPalindromeFromCenter(s, i, i + 1);
                if (ans.Length < evenstr.Length)
                {
                    ans = evenstr;
                }
            }

            return ans;

        }

        private string FindPalindromeFromCenter(string s, int left, int right)
        {
            int start = 0;
            int last = 0;
            while (left >= 0 && right < s.Length)
            {
                if (s[left] == s[right])
                {
                    start = left;
                    last = right;
                    left--;
                    right++;
                }
                else
                {
                    break;
                }
            }

            return s.Substring(start, (last - start + 1));
        }
    }
}
