using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class RearrangeString
    {
        /// <summary>
        /// 358. Rearrange String k Distance Apart
        /// https://leetcode.com/problems/rearrange-string-k-distance-apart/description/
        /// 
        /// Given a non-empty string s and an integer k, rearrange the string such that the same characters are at least distance k from each other.
        /// 
        /// All input strings are given in lowercase letters.If it is not possible to rearrange the string, return an empty string "".
        /// 
        /// 
        /// Example 1:
        /// 
        /// 
        /// Input: s = "aabbcc", k = 3
        /// Output: "abcabc" 
        /// Explanation: The same letters are at least distance 3 from each other.
        /// Example 2:
        /// 
        /// 
        /// Input: s = "aaabc", k = 3
        /// Output: "" 
        /// Explanation: It is not possible to rearrange the string.
        /// 
        /// 
        /// Similiar question to "ReorganizeString"
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RearrangeStringSoler(string s, int k)
        {
            if (k == 0)
            {
                return s;
            }

            SortedSet<Item> pq = new SortedSet<Item>(new ItemComparer());
            Dictionary<char, int> lookup = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, 0);
                }
                lookup[c]++;
            }

            foreach (var c in lookup.Keys)
            {
                pq.Add(new Item(c, lookup[c]));
            }

            StringBuilder sb = new StringBuilder();


            while (pq.Count >= k)
            {
                List<Item> arr = new List<Item>();
                for (int i = 0; i < k; i++)
                {
                    var temp = pq.First();  //pop
                    pq.Remove(temp);
                    temp.freq--;

                    sb.Append(temp.c);

                    arr.Add(temp);
                }

                // put it back
                for (int i = 0; i < k; i++)
                {
                    if (arr[i].freq > 0)
                    {
                        pq.Add(arr[i]);
                    }
                }
            }

            // remaing count < k
            while (pq.Count > 0)
            {
                var temp = pq.First();
                pq.Remove(temp);
                if (temp.freq > 1)
                {
                    return "";
                }
                sb.Append(temp.c);
            }

            return sb.ToString();

        }

        public class Item
        {
            public char c;
            public int freq;

            public Item(char c, int freq)
            {
                this.c = c;
                this.freq = freq;
            }
        }

        public class ItemComparer : IComparer<Item>
        {
            public int Compare(Item i1, Item i2)
            {
                if (i1.freq != i2.freq)
                {
                    return i2.freq.CompareTo(i1.freq);
                }

                return i1.c.CompareTo(i2.c);
            }
        }
    }
}
