using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class FirstUniqueCharacterinaString
    {
        public int FirstUniqChar_Best(string s)
        {
            Dictionary<char, int> lookup = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!lookup.ContainsKey(s[i]))
                {
                    lookup.Add(s[i], 0);
                }
                lookup[s[i]]++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (lookup[s[i]] == 1)
                {
                    return i;
                }

            }

            return -1;

        }


        public class HelperNode
        {
            public char val;
            public int index;
            public HelperNode next;
            public HelperNode prev;
            public HelperNode()
            {
                next = null;
                prev = null;
            }
            public HelperNode(char x, int idx)
            {
                val = x;
                index = idx;
                next = null;
                prev = null;
            }
        }

        private HelperNode dummyHead = null;
        private HelperNode dummyTail = null;
        private Dictionary<char, HelperNode> lookup;
        /// <summary>
        /// 387. First Unique Character in a String
        /// https://leetcode.com/problems/first-unique-character-in-a-string/description/
        /// Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
        /// 
        /// Examples:
        /// 
        /// s = "leetcode"
        /// return 0.
        /// 
        /// s = "loveleetcode",
        /// return 2.
        /// 
        /// 
        /// Sol:
        /// 
        /// LRU cache
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public FirstUniqueCharacterinaString()
        {
            dummyHead = new HelperNode();
            dummyTail = new HelperNode();
            lookup = new Dictionary<char, HelperNode>();
            dummyHead.next = dummyTail;
            dummyTail.prev = dummyHead;
        }

        private void insert(char c, int index)
        {
            if (!lookup.ContainsKey(c))
            {
                HelperNode node = new HelperNode(c, index);
                var last = dummyTail.prev;
                last.next = node;
                dummyTail.prev = node;
                node.prev = last;
                node.next = dummyTail;
                lookup.Add(c, node);
            }
            else
            {
                removeFrimList(c);
            }

            
        }

        private void removeFrimList(char c)
        {
            var curr = lookup[c];
            // already removed
            if (curr == null)
            {
                return;
            }

            var pre = curr.prev;
            var next = curr.next;

            pre.next = next;
            next.prev = pre;

            lookup[c] = null;   // yic need to reset
        }

        public int FirstUniqChar(string s)
        {
            for (int i = 0; i < s.Length; i ++)
            {
                insert(s[i], i);
            }

            if (dummyHead.next == dummyTail)
            {
                return -1;
            }

            return dummyHead.next.index;

        }
        public int FirstUniqChar_old(string s)
        {
            Dictionary<char, int> lookup = new Dictionary<char, int>();
            int N = s.Length;
            for (int i = 0; i < N; i++)
            {
                if (!lookup.ContainsKey(s[i]))
                {
                    lookup[s[i]] = 1;
                }
                else
                {
                    lookup[s[i]]++;
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (lookup[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
