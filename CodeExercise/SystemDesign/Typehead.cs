using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    /// <summary>
    /// 231. Typeahead
    /// Implement typeahead. Given a string and a dictionary, return all words that contains the string as a substring. The dictionary will give at the initialize method and wont be changed. The method to find all words with given substring would be called multiple times.
    /// 
    /// ex
    /// Given dictionary = {"Jason Zhang", "James Yu", "Bob Zhang", "Larry Shi"}
    ///search "Zhang", return ["Jason Zhang", "Bob Zhang"].
    ///
    ///search "James", return ["James Yu"].
    /// </summary>
    class Typehead
    {
        TrieTree tree;
        public Typehead(List<NodeContent> input)
        {
            // the input should has been hashed ans assign to the machine

            tree = new TrieTree();
            
            foreach(NodeContent n in input)
            {
                tree.Insert(n.str, n.freq);
            }
        }

        public List<String> search(String str)
        {
            var ans = tree.Search(str);

            return ans;
        }
    }

    class NodeContent
    {
        public string str;
        public int freq;

        public NodeContent(string s, int f)
        {
            str = s;
            freq = f;
        }
    }

    class TrieNodeComparer : IComparer<NodeContent>
    {
        int IComparer<NodeContent>.Compare(NodeContent x, NodeContent y)
        {
            return y.freq.CompareTo(x.freq);
        }
    }

    class TrieNode
    {
        public SortedDictionary<NodeContent, int> Top3;
        public TrieNode[] children;

        public TrieNode()
        {
            Top3 = new SortedDictionary<NodeContent, int>(new TrieNodeComparer());
            children = new TrieNode[256]; // ascii + extend ascii chars
        }
        
    }

    class TrieTree
    {
        TrieNode root;

        public TrieTree()
        {
            root = new TrieNode();
        }

        public void Insert(string str, int freq)
        {
            TrieNode curr = root;

            foreach(char c in str)
            {
                int num = c;
                if (curr.children[num] == null)
                {
                    curr.children[num] = new TrieNode();
                }
                curr.children[num].Top3.Add(new NodeContent(str, freq), 0);    // store origin str and freq at each level

                // remove extra
                if (curr.children[num].Top3.Keys.Count > 3)
                {
                    var last = curr.children[num].Top3.Keys.Last();
                    curr.children[num].Top3.Remove(last);
                }
                curr = curr.children[num];
            }
        }

        public List<String> Search(String str)
        {
            TrieNode curr = root;

            var ans = new List<string>();

            foreach(var c in str)
            {
                if (curr.children[c] == null)
                {
                    return ans;
                }
                curr = curr.children[c];
            }

            foreach(var nodecontent in curr.Top3.Keys)
            {
                ans.Add(nodecontent.str);
            }

            return ans;
        }
    }
}
