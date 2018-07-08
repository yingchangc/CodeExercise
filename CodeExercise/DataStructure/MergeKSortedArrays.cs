using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MergeKSortedArrays
    {
        class Element
        {
            public int row;
            public int col;
            public int val;

            public Element(int r, int c, int v)
            {
                row = r;
                col = c;
                val = v;
            }
        }

        class ElementComparer : IComparer<Element>
        {
            public int Compare(Element x, Element y)
            {
                if (x.val != y.val)
                {
                    return x.val.CompareTo(y.val);
                }
                else if (x.row != y.row)
                {
                    return x.row.CompareTo(y.row);
                }

                return x.col.CompareTo(y.col);

            }
        }

        /// <summary>
        /// 486. Merge K Sorted Arrays
        /// 
        /// https://www.lintcode.com/problem/merge-k-sorted-arrays/description
        /// Given k sorted integer arrays, merge them into one sorted array.
        /// 
        /// Example
        /// Given 3 sorted arrays:
        /// 
        /// 
        /// [
        ///   [1, 3, 5, 7],
        ///   [2, 4, 6],
        ///   [0, 8, 9, 10, 11]
        /// ]
        /// return [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11].
        /// 
        /// Challenge
        /// Do it in O(N log k).
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public int[] mergekSortedArrays(List<List<int>> arrays)
        {
            SortedSet<Element> PQ = new SortedSet<Element>(new ElementComparer());

            int numArrs = arrays.Count;
            int total = 0;
            for (int i = 0; i < numArrs; i++)
            {
                // should have one item by
                PQ.Add(new Element(i, 0, arrays[i][0]));
                total += arrays[i].Count;
            }

            int[] ans = new int[total];

            int idx = 0;
            while(PQ.Count > 0)
            {
                Element top = PQ.First();
                PQ.Remove(top);
                ans[idx++] = top.val;

                if (top.col+1 < arrays[top.row].Count)
                {
                    PQ.Add(new Element(top.row, top.col+1, arrays[top.row][top.col + 1]));
                }
            }

            return ans;
        }
    }
}
