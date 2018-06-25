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
        /// 126. Word Ladder II
        /// https://leetcode.com/problems/word-ladder-ii/description/
        /// Given two words (start and end), and a dictionary, find all shortest transformation sequence(s) from start to end, such that:
        ///Only one letter can be changed at a time
        ///Each intermediate word must exist in the dictionary
        ///Example
        ///Given:
        ///start = "hit"
        ///end = "cog"
        ///dict = ["hot","dot","dog","lot","log"]
        ///        Return
        ///  [
        ///    ["hit", "hot", "dot", "dog", "cog"],
        ///    ["hit","hot","lot","log","cog"]
        ///  ]
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public IList<IList<string>> FindLadders2(string beginWord, string endWord, IList<string> wordList)
        {
            Dictionary<string, int> visited = new Dictionary<string, int>();  // currString, distance from start
            Dictionary<string, List<string>> parentsLookup = new Dictionary<string, List<string>>();
            HashSet<string> wordDict = new HashSet<string>(wordList);

            List<List<string>> ans = new List<List<string>>();
            BFSHelper(beginWord, endWord, wordDict, visited, parentsLookup);
            DFSHelper(endWord, beginWord, visited, parentsLookup, new List<string>() { endWord}, ans);
            return ans.ToArray();
        }

        // end to begin and then reverse
        private void DFSHelper(string beginWord, string endWord,
                                Dictionary<string, int> visited,
                                Dictionary<string, List<string>> parentsLookup,
                                List<string> currPath,
                                List<List<string>> ans)
        {
            if (string.Compare(beginWord, endWord) == 0)
            {
                List<string> copy = new List<string>(currPath);
                copy.Reverse();
                ans.Add(copy);
                return;
            }

            if (!parentsLookup.ContainsKey(beginWord))
            {
                return;
            }
            List<string> parents = parentsLookup[beginWord];

            foreach(string parent in parents)
            {
                if (visited[beginWord] == (visited[parent] +1))  // yic must have to make sure alsways go down rather tahn go up to diff level.
                {
                    currPath.Add(parent);
                    DFSHelper(parent, endWord, visited, parentsLookup, currPath, ans);
                    currPath.RemoveAt(currPath.Count - 1);
                }
                
            }
        }

        private void BFSHelper(string beginWord, string endWord, HashSet<string> wordList,
            Dictionary<string, int> visited,
            Dictionary<string, List<string>> parentsLookup)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            visited.Add(beginWord, 0);
            int distance = 0;
            bool found = false;
            while(queue.Count > 0)
            {
                int levelSize = queue.Count;
                     
                distance++;

                for (int i = 0; i < levelSize; i++)
                {
                    string curr = queue.Dequeue();
                    var candidates = FindAllCandidates(curr, wordList);

                    foreach (string nxt in candidates)
                    {
                        if (!parentsLookup.ContainsKey(nxt))
                        {
                            parentsLookup.Add(nxt, new List<string>());
                        }
                        parentsLookup[nxt].Add(curr); // set parent

                        if (!visited.ContainsKey(nxt))
                        {
                            if (string.Compare(nxt, endWord) == 0)
                            {
                                found = true;
                            }

                            visited.Add(nxt, distance);  // update distance
                            queue.Enqueue(nxt);
                        }
                    }
                }

                if (found == true)
                {
                    break;
                }
            }
        }

        // get all candidates by changing 1 letter, don't care if visited earlier by better path
        private List<string> FindAllCandidates(string curr, HashSet<string> wordList)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            List<string> candidates = new List<string>();

            for(int i = 0; i < curr.Length; i++)
            {
                StringBuilder sb = new StringBuilder(curr);

                foreach(char c in letters)
                {
                    if (c == curr[i])
                    {
                        continue;
                    }
                    char orig = sb[i];
                    sb[i] = c;
                    if (wordList.Contains(sb.ToString()))
                    {
                        candidates.Add(sb.ToString());
                    }

                    sb[i] = orig;
                }
            }

            return candidates;
        }

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
