using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    
    class ValidPalindrome
    {
        /// <summary>
        /// 125
        /// https://leetcode.com/problems/valid-palindrome/description/
        /// Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        /// Note: For the purpose of this problem, we define empty string as valid palindrome.
        /// 
        /// Example 1:
        /// 
        /// Input: "A man, a plan, a canal: Panama"
        /// Output: true
        /// Example 2:
        /// 
        /// Input: "race a car"
        /// Output: false
        /// 
        /// sol: ref to qick selection
        /// </summary>
        public bool IsPalindromePractice(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;    // yic by quesiton definition
            }
            string lower = s.ToLower();   //yic
            int left = 0;
            int right = lower.Length - 1;

            while (left <= right)
            {
                while (left <= right && !isAlphaNumeric(lower[left]))
                {
                    left++;
                }
                while (left <= right && !isAlphaNumeric(lower[right]))
                {
                    right--;
                }

                // yic  the trick
                if (left <= right)
                {
                    if (lower[left] == lower[right])
                    {
                        left++;
                        right--;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
       

        private bool isAlphaNumeric(char c)
        {
            return Char.IsLetterOrDigit(c);
        }

        /// <summary>
        /// 680
        /// https://leetcode.com/problems/valid-palindrome-ii/description/
        /// Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.
        ///Example 1:
        ///Input: "aba"
        ///Output: True
        ///Example 2:
        ///Input: "abca"
        ///Output: True
        ///Explanation: You could delete the character 'c'.
        ///Note:
        ///The string will only contain lowercase characters a-z.The maximum length of the string is 50000.
        ///
        /// Sol:
        /// 
        /// check if curr string can be palindrome.
        /// if not, remove left char || remove right char and see
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidPalindrome2(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            bool hasMismatch = false;
            while(left <= right)
            {
                if (s[left] != s[right])
                {
                    hasMismatch = true;
                    break;
                    
                }
                else
                {
                    left++;
                    right--;
                }
            }

            if (!hasMismatch)
            {
                return true;
            }
            else
            {
                return simpleValidPalindrome(s.Substring(left, (right - left)))
                    || simpleValidPalindrome(s.Substring(left + 1, (right - left)));
            }
        }

        private bool simpleValidPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left <= right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                else
                {
                    left++;
                    right--;
                }
            }

            return true;
        }
    }
}
