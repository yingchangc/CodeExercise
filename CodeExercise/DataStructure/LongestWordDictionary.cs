using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class LongestWordDictionary
    {
        /// <summary>
        /// 720. Longest Word in Dictionary
        /// https://leetcode.com/problems/longest-word-in-dictionary/description/
        /// Given a list of strings words representing an English Dictionary, find the longest word in words that can be built one character at a time by other words in words. If there is more than one possible answer, return the longest word with the smallest lexicographical order.
        /// 
        /// If there is no answer, return the empty string.
        /// Example 1:
        /// Input: 
        /// words = ["w","wo","wor","worl", "world"]
        ///         Output: "world"
        /// Explanation: 
        /// The word "world" can be built one character at a time by "w", "wo", "wor", and "worl".
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string LongestWordPractice(string[] words)
        {
            HashSet<string> lookup = new HashSet<string>();

            foreach (var word in words)
            {
                lookup.Add(word);
            }

            string ans = "";
            foreach (var word in words)
            {
                int len = word.Length;

                bool passCheck = true;
                for (int i = 1; i <= len; i++)
                {
                    string prefix = word.Substring(0, i);  // check prefix 1 ~ len-1

                    if (!lookup.Contains(prefix))
                    {
                        passCheck = false;
                        break;
                    }
                }
                if (passCheck)
                {
                    if (ans.Length < word.Length)
                    {
                        ans = word; //longer one
                    }
                    else if ((ans.Length == word.Length) && ans.CompareTo(word) > 0)
                    {
                        // take lexicographically smaller
                        ans = word;
                    }
                }

            }

            return ans;
        }

        public string LongestWord(string[] words)
        {
            Trie trie = new Trie();

            foreach (string word in words)
            {
                trie.Insert(word);
            }

            return trie.BFS();
        }

        public class Trie
        {
            TrieNode root;

            public Trie()
            {
                root = new TrieNode();
                root.hasWord = true;

            }

            public string BFS()
            {
                Queue<TrieNode> que = new Queue<TrieNode>();

                que.Enqueue(root);


                string ans = "";

                while (que.Count > 0)
                {
                    int count = que.Count;
                    bool findfirstInLevel = false;

                    for (int i = 0; i < count; i++)
                    {
                        // must be has word to enqueue earlier
                        var curr = que.Dequeue();

                        if (!findfirstInLevel)
                        {
                            findfirstInLevel = true;
                            ans = curr.prefix;
                        }

                        foreach (var child in curr.children)
                        {
                            if (child != null && child.hasWord)
                            {
                                que.Enqueue(child);
                            }
                        }

                    }
                }
                return ans;
            }

            public void Insert(string word)
            {
                var curr = root;

                foreach (char c in word)
                {
                    if (curr.children[c] == null)
                    {
                        curr.children[c] = new TrieNode();
                    }
                    string childprefix = curr.prefix + c;
                    curr = curr.children[c];
                    curr.prefix = childprefix;
                }

                curr.hasWord = true;
            }

        }

        public class TrieNode
        {
            public TrieNode[] children;
            public bool hasWord;

            public string prefix;

            public TrieNode()
            {
                children = new TrieNode[256];
                prefix = "";
            }
        }
    }
}
