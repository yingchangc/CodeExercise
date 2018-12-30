using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TopologicalSort
{
    class AlienDictionary
    {
        /// <summary>
        /// /// 269. Alien Dictionary
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
        public string AlienOrderPractice(string[] words)
        {
            if (words == null || words.Length ==0)
            {
                return "";
            }


            var inbound = new Dictionary<char, int>();
            var childLookup = new Dictionary<char, List<char>>();

            var charSet = new HashSet<char>();
            GetAllUniqueChar(words, charSet);
            InitInBound(inbound, charSet);

            // inbound, childlookup
            int count = words.Length;
            for (int i = 1; i < count; i++)
            {
                CompareWords(inbound, childLookup, words[i - 1], words[i]);
            }

            StringBuilder sb = new StringBuilder();

            Queue<char> que = new Queue<char>();

            foreach (var c in charSet)
            {
                if (inbound[c] == 0)
                {
                    sb.Append(c);
                    que.Enqueue(c);
                }
            }

            while(que.Count > 0)
            {
                var curr = que.Dequeue();

                if (!childLookup.ContainsKey(curr))
                {
                    continue;
                }

                var children = childLookup[curr];

                foreach (var c in children)
                {
                    inbound[c]--;

                    if (inbound[c] == 0)
                    {
                        que.Enqueue(c);
                        inbound.Remove(c);
                        sb.Append(c);
                    }
                }
            }

            if (sb.Length != charSet.Count)
            {
                return "";
            }

            return sb.ToString();

        }

        private void GetAllUniqueChar(string[] words, HashSet<char> charSet)
        {
            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    charSet.Add(c); 
                }
            }
        }

        private void InitInBound(Dictionary<char, int> inbound, HashSet<char> charSet)
        {
            foreach (var c in charSet)
            {
                inbound.Add(c, 0);
            }
        }

        private void CompareWords(Dictionary<char, int> inbound, Dictionary<char, List<char>> childLookup, string word1, string word2)
        {
            if (word1.Length == 0 || word2.Length == 0)
            {
                return;
            }

            for (int i = 0; i < word1.Length && i < word2.Length; i++)
            {
                if (word1[i] != word2[i])
                {
                    if (!inbound.ContainsKey(word2[i]))
                    {
                        inbound.Add(word2[i],0);
                    }
                    inbound[word2[i]]++;
                    
                    if (!childLookup.ContainsKey(word1[i]))
                    {
                        childLookup.Add(word1[i], new List<char>());
                    }
                    childLookup[word1[i]].Add(word2[i]);
                    break;
                }
            } 
        }

       
    }
}
