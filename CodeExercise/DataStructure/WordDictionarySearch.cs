using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 211. Add and Search Word - Data structure design
    /// https://leetcode.com/problems/add-and-search-word-data-structure-design/description/
    /// 
    /// Design a data structure that supports the following two operations:
    ///
    ///    void addWord(word)
    ///bool search(word)
    ///search(word) can search a literal word or a regular expression string containing only letters a-z or..A.means it can represent any one letter.
    ///
    ///For example:
    ///
    ///addWord("bad")
    ///addWord("dad")
    ///addWord("mad")
    ///search("pad") -> false
    ///search("bad") -> true
    ///search(".ad") -> true
    ///search("b..") -> true
    ///Note:
    ///You may assume that all words are consist of lowercase letters a-z.
    /// </summary>
    class WordDictionary
    {
        class Node
        {
            public Node[] children;

            public bool hasWord;
            public Node()
            {
                children = new Node[26];
                hasWord = false;
            }  
        }

        private Node root;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            root = new Node();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            Node curr = root;
            foreach(char c in word)
            {
                if (curr.children[c-'a'] == null)
                {
                    curr.children[c - 'a'] = new Node();
                }
                curr = curr.children[c - 'a'];
            }

            curr.hasWord = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            char c = word[0];

            if (c == '.')
            {
                for(int i = 0; i < 26; i++)
                {
                    if (Search(word, 0, root.children[i]))
                    {
                        return true;
                    }
                }

                return false;
            }
            return Search(word, 0, root.children[c - 'a']);
        }

        private bool Search(string word, int index, Node curr)
        {
            if (curr == null)   // current no such char
            {
                return false;
            }

            if ((word.Length-1) == index)
            {
                return curr.hasWord;
            }

            char nextC = word[index+1];  

            if (nextC == '.')
            {
                for (int i = 0; i < 26; i++)
                {
                    if (Search(word, index + 1, curr.children[i]))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return Search(word, index + 1, curr.children[nextC - 'a']);
            } 
        }
    }
}
