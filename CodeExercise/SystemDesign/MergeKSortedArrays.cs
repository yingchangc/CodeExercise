using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    class Element
    {
        public int row;
        public int col;
        public int val;

        public Element(int row, int col, int val)
        {
            this.row = row;
            this.col = col;
            this.val = val;
        }
    }

    class ElemComparer : IComparer<Element>
    {

        /// <summary>
        /// yic  note how we do compare by val  row  col
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Element x, Element y)
        {
            if (x.val != y.val)
            {
                return x.val.CompareTo(y.val);
            }

            if (x.row != y.row)
            {
                return x.row.CompareTo(y.row);
            }

            return x.col.CompareTo(y.col);
        }
    }

    class MergeKSortedArrays
    {
        /// <summary>
        /// 486. Merge K Sorted Arrays
        /// http://www.lintcode.com/en/problem/merge-k-sorted-arrays/
        /// Given k sorted integer arrays, merge them into one sorted array.
        /// 
        /// Example,
        /// Given 3 sorted arrays:
        /// 
        /// [
        ///   [1, 3, 5, 7],
        ///   [2, 4, 6],
        ///   [0, 8, 9, 10, 11]
        /// ]
        /// return [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public int[] MergekSortedArraysSolver(List<int[]> arrays)
        {
            SortedDictionary<Element, int> pq = new SortedDictionary<Element, int>(new ElemComparer());

            int M = arrays.Count;

            // add first element of each row of the arrays
            for (int i = 0; i < M; i++)
            {
                var elem = new Element(i, 0, arrays[i][0]);
                AddToPQ(pq, elem);
            }

            var ans = new List<int>();

            //pop and insert the next one of the top
            while(pq.Count != 0)
            {
                var top = pq.Keys.First();
                ans.Add(top.val);
                RemoveFromPQ(pq, top);

                int currRow = top.row;
                int currCol = top.col;

                var row = arrays[currRow];
                if ((currCol+1) < row.Length)
                {
                    AddToPQ(pq, new Element(currRow, currCol + 1, row[currCol + 1]));
                }
                
            }

            return ans.ToArray();
        }

        private static void AddToPQ(SortedDictionary<Element,int> pq, Element elem)
        {
            if (pq.ContainsKey(elem))
            {
                pq[elem]++;
            }
            else
            {
                pq.Add(elem, 1);
            } 
        }

        private static void RemoveFromPQ(SortedDictionary<Element, int> pq, Element elem)
        {
            if (pq.ContainsKey(elem))
            {
                pq[elem]--;

                if (pq[elem]==0)
                {
                    pq.Remove(elem);
                }
            }
            
        }
    }
}
