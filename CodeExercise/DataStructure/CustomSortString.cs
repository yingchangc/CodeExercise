using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class CustomSortString
    {
        /// <summary>
        /// 791. Custom Sort String
        /// https://leetcode.com/problems/custom-sort-string/description/
        /// S and T are strings composed of lowercase letters. In S, no letter occurs more than once.
        /// 
        /// S was sorted in some custom order previously.We want to permute the characters of T so that they match the order that S was sorted.More specifically, if x occurs before y in S, then x should occur before y in the returned string.
        /// 
        /// 
        /// Return any permutation of T (as a string) that satisfies this property.
        /// 
        /// Example :
        /// Input: 
        /// S = "cba"
        /// T = "abcd"
        /// Output: "cbad"
        /// Explanation: 
        /// "a", "b", "c" appear in S, so the order of "a", "b", "c" should be "c", "b", and "a". 
        /// Since "d" does not appear in S, it can be at any position in T. "dcba", "cdba", "cbda" are also valid outputs.
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public string CustomSortStringSolver(string S, string T)
        {
            SortedDictionary<char, int> freqLookup = new SortedDictionary<char, int>();

            foreach (char c in T)
            {
                if (!freqLookup.ContainsKey(c))
                {
                    freqLookup.Add(c, 0);
                }
                freqLookup[c]++;
            }

            StringBuilder sb = new StringBuilder();

            // topological sorting order
            foreach (char c in S)
            {
                if (freqLookup.ContainsKey(c))
                {
                    int freq = freqLookup[c];
                    for (int i = 0; i < freq; i++)
                    {
                        sb.Append(c);
                    }

                    //reset
                    freqLookup[c] = 0;
                }
            }

            //put reset T in
            foreach (char c in T)
            {
                if (freqLookup[c] > 0)
                {
                    int freq = freqLookup[c];
                    for (int i = 0; i < freq; i++)
                    {
                        sb.Append(c);
                    }

                    //reset
                    freqLookup[c] = 0;
                }
            }

            return sb.ToString();
        }
    }
}
