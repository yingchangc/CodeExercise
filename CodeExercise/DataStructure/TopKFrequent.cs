using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    public class WordNode
    {
        public string word;
        public int count;

        public WordNode(string word, int count)
        {
            this.word = word;
            this.count = count;
        }
    }

    // for minheap   (want top count and alpaha order, so reverse requirement)
    class WordNodeComarer : IComparer<WordNode>
    {
        public int Compare(WordNode x, WordNode y)
        {
            if (x.count != y.count)
            {
                return x.count.CompareTo(y.count);
            }
            return y.word.CompareTo(x.word);
        }
    }

    class TopKFrequent
    {
        /// <summary>
        /// 692. Top K Frequent Words
        /// https://leetcode.com/problems/top-k-frequent-words/description/
        /// Given a non-empty list of words, return the k most frequent elements.
        /// 
        /// Your answer should be sorted by frequency from highest to lowest.If two words have the same frequency, then the word with the lower alphabetical order comes first.
        /// 
        /// Example 1:
        /// Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
        ///        Output: ["i", "love"]
        /// Explanation: "i" and "love" are the two most frequent words.
        /// 
        ///            Note that "i" comes before "love" due to a lower alphabetical order.
        /// Example 2:
        /// Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
        ///        Output: ["the", "is", "sunny", "day"]
        /// Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
        ///            with the number of occurrence being 4, 3, 2 and 1 respectively.
        ///        Note:
        /// You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
        /// Input words contain only lowercase letters.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<string> TopKFrequentSolver(string[] words, int k)
        {
            Dictionary<string, int> wordAndFreq = new Dictionary<string, int>();
            foreach(string word in words)
            {
                if (!wordAndFreq.ContainsKey(word))
                {
                    wordAndFreq.Add(word, 0);
                }
                ++wordAndFreq[word];
            }

            SortedSet<WordNode> minHeap = new SortedSet<WordNode>(new WordNodeComarer());

            foreach(string word in wordAndFreq.Keys)
            {
                WordNode wd = new WordNode(word, wordAndFreq[word]);
                minHeap.Add(wd);

                if (minHeap.Count > k)
                {
                    var node = minHeap.First();
                    minHeap.Remove(node);
                }
            }


            var ans = new List<string>();

            foreach(var item in minHeap)
            {
                ans.Add(item.word);
            }

            ans.Reverse();   // sort Top to small freq

            return ans.ToArray();

        }
    }
}
