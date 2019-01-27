using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class KEditDistance
    {
        /// <summary>
        /// 623
        /// http://www.lintcode.com/en/problem/k-edit-distance/
        /// 
        /// Given a set of strings which just has lower case letters and a target string, output all the strings for each the edit distance with the target no greater than k.

        /// You have the following 3 operations permitted on a word:
        /// 
        /// Insert a character
        /// Delete a character
        /// Replace a character
        /// 
        /// Example
        /// Given words = ["abc", "abd", "abcd", "adc"] and target = "ac", k = 1
        /// Return["abc", "adc"]
        ///
        /// sol: trie+edit distance
        /// 
        /// think of it as edit distance 2D array,    
        /// 
        ///        nu   t a  r   g e t
        /// nu     0   ---------------
        /// t      --------------------
        /// [node] --------------i-----        Node:  i only need to know pre row  and curr row,
        /// a
        /// r
        /// 
        /// 
        /// </summary>
        /// <param name="words"></param>
        /// <param name="target"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public List<String> kDistance(String[] words, String target, int k)
        {
            //(1) build trie tree
            TrieTree tree = new TrieTree();
            foreach(string word in words)
            {
                tree.Insert(word);
            }

            var ans = new List<string>();

            // build first row
            //      null t a r g e t
            //null  0    1 2 3 4 5 6

            int[] F = new int[target.Length + 1];
            for (int i = 0; i <= target.Length; i++)
            {
                F[i] = i;
            }

            for (int j = 0; j < 26; j++)
            {
                if (tree.root.children[j] != null)
                {
                    Search(tree.root.children[j], target, k, ans, F);
                }
            }

            return ans;
        }


        // construct current row given preRow F, refer to edit distance computation
        private void Search(TrieNode node, string target, int kLimit, List<string> ans, int[] preRowF)
        {

            string currStr = node.currentString;
            char lastChar = currStr[currStr.Length - 1];

            // note
            //      nu    t a r g e t
            //   nu  0 
            //    a  1
            //    b F[0]
            int[] F = new int[target.Length + 1];
            F[0] = currStr.Length;    // yic see fig above for why


            for (int i = 1; i <= target.Length; i++)
            {
                if (lastChar == target[i-1])
                {
                    F[i] = preRowF[i - 1];
                }
                else
                {
                    F[i] = Math.Min(F[i - 1], Math.Min(preRowF[i - 1], preRowF[i])) +1;
                }
            }

            if (node.hasWord && F[target.Length] <= kLimit)
            {
                ans.Add(currStr);
            }

            for(int j = 0; j < 26; j++)
            {
                if (node.children[j] != null)
                {
                    Search(node.children[j], target, kLimit, ans, F);
                }
            }
        }


        public class TrieTree
        {
            public TrieNode root;

            public TrieTree()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {
                string wordLower = word.ToLower();
                TrieNode curr = root;
                string str = string.Empty;
                foreach(char c in wordLower)
                {
                    str += c;
                    int idx = c - 'a';
                    if (curr.children[idx] == null)
                    {
                        curr.children[idx] = new TrieNode(str);
                    }
                    curr = curr.children[idx];
                }

                curr.hasWord = true;
            }
        }

        public class TrieNode
        {
            public TrieNode()
            {
                hasWord = false;
                children = new TrieNode[26];
                currentString = string.Empty;
            }

            public TrieNode(string str)
            {
                hasWord = false;
                children = new TrieNode[26];
                currentString = str;
            }

            public bool hasWord { get; set; }
            public TrieNode[] children;
            public string currentString;
        }
    }
}
