using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    public class TopKFreqWords
    {
        /// <summary>
        /// 347. Top K Frequent Elements
        /// Given a non-empty array of integers, return the k most frequent elements.
        /// 
        /// Example 1:
        /// 
        /// Input: nums = [1,1,1,2,2,3], k = 2
        /// Output: [1,2]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();
            foreach(var num in nums)
            {
                if (!lookup.ContainsKey(num))
                {
                    lookup.Add(num, 0);
                }
                lookup[num]++;
            }

            SortedSet<ElementWord> minHeap = new SortedSet<ElementWord>(new MinElementComparer());
            
            foreach(var num in lookup.Keys)
            {
                var temp = new ElementWord(num, lookup[num]);
                minHeap.Add(temp);

                if (minHeap.Count > k)
                {
                    var top = minHeap.First();
                    minHeap.Remove(top);
                }
            }

            List<int> ans = new List<int>();
            foreach(var item in minHeap)
            {
                ans.Add(item.val);
            }
            ans.Sort();
            return ans.ToArray();

        }

        public class ElementWord
        {
            public int val;
            public int count;

            public ElementWord(int val, int count)
            {
                this.val = val;
                this.count = count;
            }
        }

        public class MinElementComparer : IComparer<ElementWord>
        {
            public int Compare(ElementWord x, ElementWord y)
            {
                if (x.count != y.count)
                {
                    return x.count.CompareTo(y.count);
                }
                return x.val.CompareTo(y.val);
            }
        }



    }
}
