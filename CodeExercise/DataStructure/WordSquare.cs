using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class WordSquare
    {
        /// <summary>
        /// 425. Word Squares
        /// https://leetcode.com/problems/word-squares/description/
        /// Given a set of words (without duplicates), find all word squares you can build from them.
        ///
        ///A sequence of words forms a valid word square if the kth row and column read the exact same string, where 0 ≤ k<max(numRows, numColumns).
        ///
        //  For example, the word sequence["ball", "area", "lead", "lady"] forms a word square because each word reads the same both horizontally and vertically.
        ///
        /// sol:
        /// 
        /// since all word must be unique
        /// 
        /// step 1
        ///   b  [a]   l  l          -> currently  we have 1 word,  so Indx = 1
        /// 
        /// find next word with prefix of word   ball[1]   ie "a"    so choose  "a"rea
        /// 
        /// step 2  
        ///   
        ///   b  a     l   l
        ///   a  r     e   a              -> currently, we have 2 words   so index =2
        ///   
        /// find next word with prefix  char    ball[2]  +  area[2]      ie  "le"    so choose  "le"ad
        /// 
        /// 
        /// step3
        /// 
        ///   b a  l  l
        ///   a r  e  a
        ///   l e  a  d              -> currently, we have 3 words   so index =3
        /// 
        /// find next word with prefix  char    ball[3]  +  area[3] + lead[3]      ie  "lad"    so choose  "lad"y
        /// 
        /// 
        /// note:  if find all, store to ans, else, remove pre added word and try next
        /// 
        /// 
        ///   Input:
        /// ["area","lead","wall","lady","ball"]
        /// 
        ///   Output:
        /// [
        ///   [ "wall",
        ///     "area",
        ///     "lead",
        ///     "lady"
        ///   ],
        ///   [ "ball",
        ///     "area",
        ///     "lead",
        ///     "lady"
        ///   ]
        /// ]
        /// 
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<IList<string>> WordSquares(string[] words)
        {
            if (words == null)
            {
                return null;
            }

            // create trie
            WQTrie trie = new WQTrie();
            foreach(string w in words)
            {
                trie.AddWord(w);
            }

            List<List<string>> allAns = new List<List<string>>();
            List<string> oneAns = new List<string>();

            int finalLen = words[0].Length;

            foreach(string w in words)
            {
                oneAns.Add(w);
                WordSquaresHelper(finalLen, trie, oneAns, allAns);
                oneAns.RemoveAt(oneAns.Count - 1);  // remove w
            }

            return allAns.ToArray();
        }

        

        private void WordSquaresHelper(int finalLen, WQTrie trie, List<string> oneAns, List<List<string>> allAns)
        {
            if (oneAns.Count == finalLen)
            {
                CopyOneAns(oneAns, allAns);
                return;
            }

            int index = oneAns.Count;
            string prefix = "";
            foreach (string str in oneAns)
            {
                prefix += str[index];      // take a char from index of each ans word      b [a]  xxx
                                           //                                              a [r]  yyy
            }

            List<string> startWithPrefixStrs = trie.startWithPrefix(prefix);
            foreach(string str in startWithPrefixStrs)
            {
                oneAns.Add(str);
                WordSquaresHelper(finalLen, trie, oneAns, allAns);
                oneAns.RemoveAt(oneAns.Count - 1);   // remove str just added.  can be we have store in AllAns or not fix. Now, we try next word for OneAns
            }
        }

        private void CopyOneAns(List<string> oneAns, List<List<string>> allAns)
        {
            var copy = new List<string>();
            foreach (var str in oneAns)
            {
                copy.Add(str);
            }

            allAns.Add(copy);
        }

        class WQNode
        {
            public bool hasWord;
            public WQNode[] children;

            public List<string> startWith;

            public WQNode()
            {
                hasWord = false;
                children = new WQNode[256];
                startWith = new List<string>();
            }
        }

        public class WQTrie
        {
            WQNode root;

            public WQTrie()
            {
                root = new WQNode();
            }

            public void AddWord(string str)
            {
                WQNode curr = root;

                foreach(char c in str)
                {
                    if (curr.children[c] == null)
                    {
                        curr.children[c] = new WQNode();
                    }

                    curr = curr.children[c];
                    curr.startWith.Add(str);   // yic  record   "ap"    contains apple
                }

                curr.hasWord = true;
            }

            public List<string> startWithPrefix(string str)
            {
                WQNode curr = root;
                foreach(char c in str)
                {
                    if (curr.children[c] == null)
                    {
                        return new List<string>();
                    }
                    curr = curr.children[c];
                }

                return curr.startWith;

            }
        }
    }
}
