using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    /// <summary>
    /// lint 502. Mini Cassandra
    /// http://www.lintcode.com/en/problem/mini-cassandra/
    /// 
    /// Cassandra is a NoSQL storage. The structure has two-level keys.

    /// Level 1: raw_key.The same as hash_key or shard_key.
    /// Level 2: column_key.
    /// Level 3: column_value
    /// raw_key is used to hash and can not support range query.let's simplify this to a string.
    /// column_key is sorted and support range query.let's simplify this to integer.
    /// column_value is a string. you can serialize any data into a string and store it in column value.
    /// 
    /// implement the following methods:
    /// 
    /// insert(raw_key, column_key, column_value)
    /// query(raw_key, column_start, column_end) // return a list of entries
    /// 
    /// insert("google", 1, "haha")
    /// query("google", 0, 1)
    /// >> [（1, "haha")]
    /// </summary>
    class MiniCassandra
    {
        Dictionary<string, SortedDictionary<int, string>> dict;
        public MiniCassandra()
        {
            dict = new Dictionary<string, SortedDictionary<int, string>>();   // <key, <int (to sort), serialized_string> >
        }

        /*
         * @param raw_key: a string
         * @param column_key: An integer
         * @param column_value: a string
         * @return: nothing
         */
        public void insert(String raw_key, int column_key, String column_value)
        {
            if (!dict.ContainsKey(raw_key))
            {
                dict.Add(raw_key, new SortedDictionary<int, string>(new CustomComparer()));
            }

            var raw = dict[raw_key];

            if (!raw.ContainsKey(column_key))
            {
                raw.Add(column_key, column_value);
            }
            else
            {
                raw[column_key] = column_value;
            }
        }

        /*
         * @param raw_key: a string
         * @param column_start: An integer
         * @param column_end: An integer
         * @return: a list of Columns
         */
        public List<Column> query(String raw_key, int column_start, int column_end)
        {
            List<Column> ans = new List<Column>();

            
            if (dict.ContainsKey(raw_key))
            {
                var row = dict[raw_key];
                foreach(var colkey in row.Keys)
                {
                    if (colkey >= column_start && colkey <= column_end)
                    {
                        ans.Add(new Column(colkey, row[colkey]));
                    }
                }
            }

            return ans;
        }
    }

    class CustomComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    public class Column
    {
        public int key;
        public String value;
        public Column(int key, String value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
