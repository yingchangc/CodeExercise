using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class ReorganizeString
    {
        public class CharFreq
        {
            public char c;
            public int freq;

            public CharFreq(char c, int num)
            {
                this.c = c;
                this.freq = num;
            }
        }

        public class CompareCharFreq : IComparer<CharFreq>
        {
            public int Compare(CharFreq c1, CharFreq c2)
            {
                if (c1.freq != c2.freq)
                {
                    return c2.freq.CompareTo(c1.freq);
                }
                return c1.c.CompareTo(c2.c);
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/reorganize-string/description/
        /// 767. Reorganize String
        /// Given a string S, check if the letters can be rearranged so that two characters that are adjacent to each other are not the same.
        /// 
        /// If possible, output any possible result.If not possible, return the empty string.
        /// 
        /// Example 1:
        /// 
        /// Input: S = "aab"
        /// Output: "aba"
        /// Example 2:
        /// 
        /// Input: S = "aaab"
        /// Output: ""
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string ReorganizeStringSolver(string S)
        {
            SortedSet<CharFreq> pq = new SortedSet<CharFreq>(new CompareCharFreq());

            Dictionary<char, int> lookup = new Dictionary<char, int>();

            foreach (char c in S)
            {
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, 0);
                }
                lookup[c]++;
            }

            // sort c by freq
            foreach (var c in lookup.Keys)
            {
                pq.Add(new CharFreq(c, lookup[c]));
            }

            StringBuilder sb = new StringBuilder();

            while (pq.Count > 1)
            {
                // [get top 2]
                var firstCwihtFreq = pq.First();
                pq.Remove(firstCwihtFreq);
                var SecCWithFreq = pq.First();
                pq.Remove(SecCWithFreq);

                // [Append]
                sb.Append(firstCwihtFreq.c);
                sb.Append(SecCWithFreq.c);
                firstCwihtFreq.freq--;
                SecCWithFreq.freq--;

                // [update pq]
                if (firstCwihtFreq.freq > 0)
                {
                    pq.Add(firstCwihtFreq);
                }
                if (SecCWithFreq.freq > 0)
                {
                    pq.Add(SecCWithFreq);
                }
            }

            if (pq.Count == 1)
            {
                var CwithFreq = pq.First();
                if (CwithFreq.freq == 1)
                {
                    sb.Append(CwithFreq.c);
                    CwithFreq.freq--;
                }
                else
                {
                    return "";
                }
            }

            return sb.ToString();
        }
    }
}
