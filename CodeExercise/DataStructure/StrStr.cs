using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class StrStr
    {
        private static readonly int HashSlots = 1000;
        /// <summary>
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

                // abc  + d 
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

    }
}
