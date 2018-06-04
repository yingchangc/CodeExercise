using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class WordLadder
    {
        /// <summary>
        /// 127 Word Ladder
        /// https://leetcode.com/problems/word-ladder/description/
        /// Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest transformation sequence from beginWord to endWord, such that:
        /// Only one letter can be changed at a time.
        /// Each transformed word must exist in the word list.Note that beginWord is not a transformed word.
        /// Note:
        /// 
        /// Return 0 if there is no such transformation sequence.
        /// All words have the same length.
        /// All words contain only lowercase alphabetic characters.
        ///        You may assume no duplicates in the word list.
        ///        You may assume beginWord and endWord are non-empty and are not the same.
        /// Example 1:
        /// 
        /// 
        ///        Input:
        ///        beginWord = "hit",
        ///        endWord = "cog",
        ///        wordList = ["hot", "dot", "dog", "lot", "log", "cog"]
        /// 
        /// 
        ///        Output: 5
        /// 
        /// 
        ///        Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
        ///        return its length 5.
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (wordList == null)
            {
                return 0;
            }

            if (string.Compare(beginWord, endWord) == 0)
            {
                return 1;
            }

            HashSet<string> dictionary = new HashSet<string>(wordList);

            HashSet<string> visited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            visited.Add(beginWord);

            int len = 0;

            // bfs level
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                len++;

                for (int i = 0; i < levelSize; i++)
                {     
                    string curr = queue.Dequeue();

                    // get all possitble combinations
                    // if already exists in pre level, don't count, since we care about the shortest path
                    HashSet<string> candidates = getNextWords(curr, visited, dictionary);

                    foreach (string candidate in candidates)
                    {
                        if (string.Compare(endWord, candidate) == 0)
                        {
                            // pre level len +1
                            return len + 1;
                        }

                        queue.Enqueue(candidate);
                        visited.Add(candidate);
                    }
                }

            }

            return 0;

        }


        private HashSet<string> getNextWords(string word, HashSet<string> visited, HashSet<string> dictionary)
        {
            HashSet<string> candidates = new HashSet<string>();  

            for (int i = 0; i < word.Length; i++)
            {
                foreach(char x in "abcdefghijklmnopqrstuvwxyz")
                {
                    StringBuilder candidate = new StringBuilder(word);

                    // not the same as curr word
                    if (word[i] != x)
                    {                  
                        // replace and make as a candidate
                        candidate[i] = x;

                        if (!visited.Contains(candidate.ToString()) && dictionary.Contains(candidate.ToString()))
                        {
                            candidates.Add(candidate.ToString());
                        }
                        
                    }
                }
            }
            return candidates;
        }
    }
}
