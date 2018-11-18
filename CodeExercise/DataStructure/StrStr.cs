using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class RotateString
    {
        /// <summary>
        /// 796. Rotate String
        /// https://leetcode.com/problems/rotate-string/description/
        /// We are given two strings, A and B.
        /// 
        /// A shift on A consists of taking string A and moving the leftmost character to the rightmost position.For example, if A = 'abcde', then it will be 'bcdea' after one shift on A.Return True if and only if A can become B after some number of shifts on A.
        /// 
        /// Example 1:
        /// Input: A = 'abcde', B = 'cdeab'
        /// Output: true
        /// 
        /// Example 2:
        /// Input: A = 'abcde', B = 'abced'
        /// Output: false
        /// 
        /// 
        /// Sol: 
        /// 
        ///  B contains in (A+A)    O(N^2)      contains  can be optionmized by strstr
        ///  
        /// Space O(N)     
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public bool CanRotateString(string A, string B)
        {
            if (A.Length != B.Length)
            {
                return false;
            }

            var temp = A + A;

            return temp.Contains(B);
        }
    }


    class StrStr
    {
        private static readonly int HashSlots = 1000;
        /// <summary>
        /// https://www.lintcode.com/problem/implement-strstr/description
        /// 13. Implement strStr()
        /// For a given source string and a target string, you should output the first index(from 0) of target string in source string.
        /// 
        /// If target does not exist in source, just return -1.
        /// 
        /// Example
        /// If source = "source" and target = "target", return -1.
        /// 
        /// If source = "abcdabcdefg" and target = "bcd", return 1.
        /// 
        /// Challenge
        /// O(n^2) is acceptable.Can you implement an O(n) algorithm? (hint: KMP)
        /// 
        /// Implement strStr function in O(n + m) time.
        /// strStr return the first index of the target string in a source string. 
        /// The length of the target string is m and the length of the source string is n.
        /// If target does not exist in source, just return -1.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int strStr2(String source, String target)
        {
            if (string.IsNullOrEmpty(target))
            {
                return 0;
            }
            if (string.IsNullOrEmpty(source))
            {
                return -1;
            }
            if (source.Length < target.Length)
            {
                return -1;
            }

            // yic check this case
            if (target.Equals(""))
            {
                return 0;
            }

            int targetHash = 0;
            foreach (char c in target)
            {
                targetHash = (targetHash * 31 + c) % HashSlots;
            }

            int sourceSubStrHash = 0;
            int slen = source.Length;
            int highestpower = PrecomputeHightestOverflowReminder(target.Length);
            for (int i = 0; i < slen; i++)
            {
                // (a*31*31 + b*31 + c)  % 5
                sourceSubStrHash = (sourceSubStrHash * 31 + source[i]) % HashSlots;

                // now we have full length of target, check if first match. 
                if (i==(target.Length-1) && sourceSubStrHash == targetHash)
                {
                    return i - target.Length + 1;
                }
                // abc  + d,  remove the highest hash so we can add a newer low bit to hash (keep the same lenght as target) 
                if (i >= target.Length)
                {

                    // substract the highest bit number
                    //sourceSubStrHash -= ((source[i-targetlen] * 31 ^ (target.Length))%HashSlots);    // might overflow

                    sourceSubStrHash -= ((source[i-target.Length] * highestpower)%HashSlots);

                    if (sourceSubStrHash < 0)
                    {
                        sourceSubStrHash += HashSlots;
                    }

                    if (sourceSubStrHash == targetHash)
                    {
                        // need to double confirm with reach char compare, to prevent hash collision
                        if (source.Substring(i-target.Length+1, target.Length).Equals(target) )
                        {
                            return i - target.Length + 1;
                        }                
                    }

                }
            }
            

            return -1;

        }

        private int PrecomputeHightestOverflowReminder(int targetLen)
        {
            int hash = 1;
            for(int i = 1; i <=targetLen; i++)
            {
                hash = (hash * 31) % HashSlots;
            }

            return hash;
        }


        /// <summary>
        /// 28. Implement strStr()
        /// https://leetcode.com/problems/implement-strstr/description/
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr1(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }
            else if (string.IsNullOrEmpty(haystack))
            {
                return -1;
            }


            int lenSource = haystack.Length;
            int lenTarget = needle.Length;

            if (lenSource < lenTarget)
            {
                return -1;
            }

            string source = haystack.ToLower();
            string target = needle.ToLower();

            for(int i=0; i <= (lenSource-lenTarget); i++)
            {
                if (containsTarget(source, target, i, lenTarget))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool containsTarget(string source, string target, int startIndex, int len)
        {
            for (int i = 0; i < len; i++)
            {
                if (source[startIndex + i] != target[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
