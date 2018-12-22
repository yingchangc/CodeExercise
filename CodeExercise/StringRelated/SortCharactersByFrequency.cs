using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class SortCharactersByFrequency
    {
        /// <summary>
        /// 451. Sort Characters By Frequency
        /// https://leetcode.com/problems/sort-characters-by-frequency/
        /// Given a string, sort it in decreasing order based on the frequency of characters.
        /// 
        /// Example 1:
        /// 
        /// Input:
        /// "tree"
        /// 
        /// Output:
        /// "eert"
        /// 
        /// Explanation:
        /// 'e' appears twice while 'r' and 't' both appear once.
        /// So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FrequencySort(string s)
        {
            Dictionary<char, int> lookup = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, 0);
                }
                lookup[c]++;
            }

            SortedSet<Item> pq = new SortedSet<Item>(new ItemComparer());

            foreach (var c in lookup.Keys)
            {
                pq.Add(new Item(c, lookup[c]));
            }

            StringBuilder sb = new StringBuilder();

            foreach (var itm in pq)
            {
                int count = itm.freq;

                for (int i = 0; i < count; i++)
                {
                    sb.Append(itm.c);
                }

            }

            return sb.ToString();

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

        public class Item
        {
            public char c;
            public int freq;
            public Item(char c, int f)
            {
                this.c = c;
                this.freq = f;
            }

        }
    }
}
