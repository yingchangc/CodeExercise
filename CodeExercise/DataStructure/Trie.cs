using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class Node
    {
        public bool hasWord { get; set; }
        public Node[] children { get; set; }

        public Node()
        {
            children = new Node[26];  //You may assume that all inputs are consist of lowercase letters a-z.
            hasWord = false;
        }
    }

    class Trie
    {
        

        private Node root;

        public Trie()
        {
            root = new Node();
        }

        /*
         * @param word: a word
         * @return: nothing
         */
        public void insert(String word)
        {
            Node curr = root;

            foreach(char c in word)
            {
                if (curr.children[c - 'a'] == null)
                {
                    curr.children[c - 'a'] = new Node(); 
                }

                curr = curr.children[c - 'a'];
            }

            curr.hasWord = true;
        }

        /*
         * @param word: A string
         * @return: if the word is in the trie.
         */
        public bool search(String word)
        {
            Node curr = root;

            foreach (char c in word)
            {
                if (curr.children[c-'a'] == null)
                {
                    return false;
                }
                curr = curr.children[c - 'a'];
            }

            return curr.hasWord;

        }

        /*
         * @param prefix: A string
         * @return: if there is any word in the trie that starts with the given prefix.
         */
        public bool startsWith(String prefix)
        {
            Node curr = root;

            foreach (char c in prefix)
            {
                if (curr.children[c - 'a'] == null)
                {
                    return false;
                }
                curr = curr.children[c - 'a'];
            }

            return true;
        }
    }
}
