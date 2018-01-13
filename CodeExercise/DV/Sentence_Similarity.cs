using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DV
{
    class Sentence_Similarity
    {
        // to check
        //http://www.jiuzhang.com/article/cFRngC/
        //http://zxi.mytechroad.com/blog/hashtable/leetcode-737-sentence-similarity-ii/
        //https://www.usenix.org/system/files/conference/hotcloud13/hotcloud13-wang.pdf
        //https://www.youtube.com/watch?v=Y6Ev8GIlbxc
        //https://www.youtube.com/watch?v=tpspO9K28PM
        /// <summary>
        /// 737
        /// Sentence Similarity II
        /// 
        /// Given two sentences words1, words2 (each represented as an array of strings), and a list of similar word pairs pairs, determine if two sentences are similar.
        /// 
        /// For example, words1 = ["great", "acting", "skills"] and words2 = ["fine", "drama", "talent"] are similar, if the similar word pairs are pairs = [["great", "good"], ["fine", "good"], ["acting", "drama"], ["skills", "talent"]].
        ///Note that the similarity relation "is transitive". For example, if “great” and “good” are similar, and “fine” and “good” are similar, then “great” and “fine” are similar.
        ///Similarity "is also symmetric". For example, “great” and “fine” being similar is the same as “fine” and “great” being similar.
        ///Also, a word is always similar with itself. For example, the sentences words1 = ["great"], words2 = ["great"], pairs = [] are similar, even though there are no specified similar word pairs.
        ///Finally, sentences can only be similar if they have the same number of words.So a sentence like words1 = ["great"] can never be similar to words2 = ["doubleplus", "good"].
        /// 
        /// 
        /// 
        /// DFS traversal 
        /// 
        /// Optimize DFS
        ///  O(pairs + words)
        ///  
        /// go to each pairs (edges) to setup lookup  O(pair)
        /// DFS each edge to set index with memo help stop earlier(O(pair))
        /// go to each word and check if memo[i] index are the same  O(wordcount)
        /// 
        /// 
        /// </summary>
        /// <param name="words1"></param>
        /// <param name="words2"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, List<Tuple<string, string>> pairs)
        {
            if (words1.Length != words2.Length)
            {
                return false;
            }

            // build lookup table with symmetric  A<->B  B<->C  K<->C   j<->m
            Dictionary<string, HashSet<string>> lookup = new Dictionary<string, HashSet<string>>();
            foreach (var pair in pairs)
            {
                string key = pair.Item1;
                string value = pair.Item2;
                if (!lookup.ContainsKey(key))
                {
                    lookup[key] = new HashSet<string>();
                }
                if (!lookup.ContainsKey(value))
                {
                    lookup[value] = new HashSet<string>();
                }
                lookup[key].Add(value);         
                lookup[value].Add(key);         // for symmetric    so that we can for sure dfs can lookup all bidirection
            }

            int index = 0;
            Dictionary<string, int> memo = new Dictionary<string, int>();
            foreach (string word in lookup.Keys)
            {
                DFS_Pairs(lookup, word, memo, index++);
            }

            int len = words1.Length;
            for(int i =0; i<len; i++)
            {
                string word1 = words1[i];
                string word2 = words2[i];
                if (words1[i]==(words2[i]))
                {
                    continue;
                }

                // what if word not in memo? and they are not the same 
                if (!memo.ContainsKey(word1) || !memo.ContainsKey(word2))
                {
                    return false;
                }

                int index1 = memo[word1];
                int index2 = memo[word2];
                if (index1 == index2)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void DFS_Pairs(Dictionary<string, HashSet<string>> lookup, string word1, Dictionary<string, int> memo, int index)
        {
            // stop condition
            if (memo.ContainsKey(word1))
            {
                return;
            }

            memo[word1] = index;   // YIC  set here; do not need to set at caller; otherwise, will hit stop condition first

            HashSet<string> word1RelatedWords = lookup[word1];
            foreach(string relatedWord in word1RelatedWords)
            {
                DFS_Pairs(lookup, relatedWord, memo, index);
            }
        }

        //Slow O(paris * words)
        public bool AreSentencesSimilarTwo_slow(string[] words1, string[] words2, List<Tuple<string, string>> pairs)
        {
            if (words1.Length != words2.Length)
            {
                return false;
            }

            // build lookup table with symmetric and transitive    A->B  C->B
            Dictionary<string, HashSet<string>> lookup = new Dictionary<string, HashSet<string>>();
            foreach(var pair in pairs)
            {
                string key = pair.Item1;
                string value = pair.Item2;
                if (!lookup.ContainsKey(key))
                {
                    lookup[key] = new HashSet<string>();
                }
                lookup[key].Add(value);

                //symmetric
                if (!lookup.ContainsKey(value))
                {
                    lookup[value] = new HashSet<string>();
                }
                lookup[value].Add(key);
                     
            }

            ///////////////////////////////////

            int len = words1.Length;
            for (int i = 0; i < len; i++)
            {
                string word1 = words1[i];
                string word2 = words2[i];
                if (String.Equals(word1, word2, StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                HashSet<string> visited = new HashSet<string>();
                if (!CanLookupString(lookup, word1, word2, visited))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CanLookupString(Dictionary<string, HashSet<string>> lookup, string word1, string word2, HashSet<string> visited)
        {
            // can be not in pair
            if (!lookup.ContainsKey(word1))
            {
                return false;
            }

            // already try visited
            if (visited.Contains(word1))
            {
                return false;
            }
            visited.Add(word1);

            if (lookup[word1].Contains(word2))
            {
                return true;
            }

            // Performa DFS
            // (A-B)  and (B-C)   -> for check (A,C)?   use dfs recursive  
            HashSet<string> word1RelatedWords = lookup[word1];
            foreach (string relatedWord in word1RelatedWords)
            {
                if (CanLookupString(lookup, relatedWord, word2, visited))
                {
                    return true;
                }
            }

            return false;

        }
    }
}
