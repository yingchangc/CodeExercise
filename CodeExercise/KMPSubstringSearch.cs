using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    public class KMPSubstringSearch
    {
        /// <summary>
        /// construct memorization array
        /// ex  
        ///   j
        /// i
        /// a a b a a b a a a
        /// 0 1 0 1 2 3 4 5 2   
        /// 
        /// Compute temporary array to maintain size of suffix which is same as prefix
        /// Time/space complexity is O(size of pattern)
        /// 
        /// O(m+n)
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int[] ComputeMemorizationArray(string pattern)
        {
            int patternlen = pattern.Length;
            int[] refArray = new int[patternlen];

            int i = 0, j = 0;

            while(j < patternlen)
            {
                if (pattern[j] == pattern[i])
                {
                    if (j == 0)
                    {
                        refArray[j] = 0;
                        j++;
                    }
                    else
                    {
                        refArray[j] = i + 1;   // ie move to index i next as start point 
                        i++;
                        j++;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        // already back to last, give up
                        refArray[j] = 0;
                        j++;

                    }
                    else
                    {
                        i = refArray[i - 1];  // **check where should we back up
                    }
                }
            }

            return refArray;
        }  

        /// <summary>
        /// given 
        /// pattern             a b a c a b y
        /// text    a b x a b a c a b c a b y
        /// 
        /// should match
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool KMP_IsMatch(string pattern, string text)
        {
            int[] refArray = ComputeMemorizationArray(pattern);

            int i = 0, j = 0;
            int textLen = text.Length;

            bool isMatch = false;
            while (j < textLen)
            {
                if (pattern[i] == text[j])
                {
                    i++;
                    j++;

                    if (i == pattern.Length)
                    {
                        isMatch = true;

                        // j-1 will be the last index of match locaiton
                        break;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        // already the back to the end, stop
                        j++;
                    }
                    else
                    {
                        i = refArray[i - 1];  // check where to backup 
                    }
                }
            }

            return isMatch;
            
        }
    }
}
