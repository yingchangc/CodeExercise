using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TopologicalSort
{
    class AlienDictionary
    {

        Dictionary<char, int> inbound = new Dictionary<char, int>();
        Dictionary<char, List<char>> childrenLookup = new Dictionary<char, List<char>>();
        HashSet<char> UniqueChars = new HashSet<char>();
        /// <summary>
        /// 269. Alien Dictionary
        /// https://leetcode.com/problems/alien-dictionary/description/
        /// There is a new alien language which uses the latin alphabet. However, the order among letters are unknown to you. You receive a list of non-empty words from the dictionary, where words are sorted lexicographically by the rules of this new language. Derive the order of letters in this language.
        /// 
        /// Example 1:
        /// 
        /// Input:
        /// [
        ///   "wrt",
        ///   "wrf",
        ///   "er",
        ///   "ett",
        ///   "rftt"
        /// ]
        /// 
        ///         Output: "wertf"
        ///         
        /// Sol:
        ///   check neighbor words to get order
        ///   t->f
        ///   w->e
        ///   r->t
        ///   e->r
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string AlienOrder(string[] words)
        {
            if (words ==null || words.Length <= 1)
            {
                return "";
            }

            

            int count = words.Length;

            for(int i = 0; i <count-1; i++)
            {
                CompareTwoWords(words[i], words[i + 1]);
            }

            Queue<char> que = new Queue<char>();

            foreach(var c in childrenLookup.Keys)
            {
                if (!inbound.ContainsKey(c))
                {
                    que.Enqueue(c);
                }
            }

            string ans = string.Empty;

            //GetUniqueChars(words);

            while (que.Count > 0)
            {
                char c = que.Dequeue();
                ans += c;

                // yic special handle for unique
                //UniqueChars.Remove(c);

                // yic  for the last char case
                if (childrenLookup.ContainsKey(c))
                {
                    var children = childrenLookup[c];
                    foreach (var childC in children)
                    {
                        var remain = --inbound[childC];

                        if (remain == 0)
                        {
                            que.Enqueue(childC);
                        }
                    }
                }
                
            }

            // for isolate chars z z
            //if(AllInboundClear() && UniqueChars.Count > 0)
            //{
            //    foreach(char c in UniqueChars)
            //    ans += c;
            //}


            return ans;
        }

        private void CompareTwoWords(string s1, string s2)
        {
            int i = 0;
            for(i= 0; i <s1.Length && i < s2.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    break;
                }
            }

            //   ab       z
            //   abc      z
            if (i >= s1.Length || i >= s2.Length)
            {
                return;
            }

            // we...
            // wr...
            //     r -> +1
            if (!inbound.ContainsKey(s2[i]))
            {
                inbound.Add(s2[i], 0);
            }
            inbound[s2[i]]++;


            // we...
            // wr...
            // e -> r
            if (!childrenLookup.ContainsKey(s1[i]))
            {
                childrenLookup.Add(s1[i], new List<char>());
            }
            childrenLookup[s1[i]].Add(s2[i]);
        }

        private void GetUniqueChars(string[] words)
        {
            foreach(string word in words)
            {
                foreach(char c in word)
                {
                    UniqueChars.Add(c);
                }
            }
        }

        private bool AllInboundClear()
        {
            foreach(char c in inbound.Keys)
            {
                if (inbound[c] != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
