using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class LongestCommonPrefix
    {
        /// <summary>
        /// 14
        /// https://leetcode.com/problems/longest-common-prefix/description/
        /// Write a function to find the longest common prefix string amongst an array of strings.
        /// 
        /// For strings "ABCD", "ABEF" and "ACEF", the LCP is "A"
        /// For strings "ABCDEFG", "ABCEFG" and "ABCEFA", the LCP is "ABC"
        /// 
        /// 
        /// use first string as  prefix (or better scan array find the smallest string as prefix candidate), gradually trim it with others in the array. Be sure preFix can be longer than toCompare during process, aware the corner case
        /// Note: This is faster than build a trie a and walk to fix each node has 1 valid child and stop when diverse or stop when isWord reached.    ex .[leet  le]
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        // 
        public string LongestCommonPrefixSolver(string[] strs)
        {
            if (strs ==null)
            {
                return string.Empty;

            }
            int N = strs.Length;

            if (N == 0)
            {
                return string.Empty;
            }

            string prefix = strs[0];
            
            for (int i = 1; i<N; i++)
            {
                string toCompare = strs[i];

                int j = 0;

                for (j = 0; j < prefix.Length; j++)   // compare use prefix char
                {
                    // yic previent prefix string longer than toCompare
                    if (j < toCompare.Length && prefix[j] == toCompare[j])   
                    {
                        // good keep going
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                prefix = prefix.Substring(0, j);  // j is index, off len by 1
            }

            return prefix;
        }
    }
}
