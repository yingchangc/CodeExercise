using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class FirstUniqueCharacterinaString
    {
        /// <summary>
        /// 387. First Unique Character in a String
        /// https://leetcode.com/problems/first-unique-character-in-a-string/description/
        /// Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
        /// 
        /// Examples:
        /// 
        /// s = "leetcode"
        /// return 0.
        /// 
        /// s = "loveleetcode",
        /// return 2.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> lookup = new Dictionary<char, int>();
            int N = s.Length;
            for (int i = 0; i < N; i++)
            {
                if (!lookup.ContainsKey(s[i]))
                {
                    lookup[s[i]] = 1;
                }
                else
                {
                    lookup[s[i]]++;
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (lookup[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
