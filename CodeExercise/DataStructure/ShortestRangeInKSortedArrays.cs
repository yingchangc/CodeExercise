using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class ShortestRangeInKSortedArrays
    {
        class ItemComparer : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                if (x.value != y.value)
                {
                    return x.value.CompareTo(y.value);
                }
                else if (x.row != y.row)
                {
                    return x.row.CompareTo(y.row);
                }
                return x.col.CompareTo(y.col);
            }
        }

        class Item
        {
            public int value;
            public int row;
            public int col;
            public Item(int val, int r, int c)
            {
                value = val;
                row = r;
                col = c;
            }
        }

        /// <summary>
        /// SHORTEST RANGE IN K SORTED LISTS 
        /// https://www.youtube.com/watch?v=zplklOy7ENo
        /// 
        /// Given k sorted lists of integers of size n each, find the smallest range that includes at least 
        /// element from each of the k lists. If more than one smallest ranges are found, print any one of them
        /// 
        /// k =3
        /// 
        /// [4, 10, 15, 24]
        /// [0,9,12,20]
        /// [5,18,22,30]
        /// 
        /// Ans:
        /// 4,  can be 24
        ///            20, 
        ///         22
        /// 
        /// sol:
        /// 
        /// Just like moving window, each time add a new elem to windos of 3, use min heap to know min
        /// each time when add, update the max (since max will stay in heap until new max replace it)
        /// 
        /// O(n*log(k))   n*  minheap lookup 
        /// 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public int ShortestRange(List<List<int>> lists)
        {
            int k = lists.Count;

            SortedSet<Item> PQ = new SortedSet<Item>(new ItemComparer());

            int gMax = Int32.MinValue;

            int range = Int32.MaxValue;

            for(int i = 0; i <k; i++)
            {
                if (lists[i][0] == null)
                {
                    throw new Exception("");
                }

                int tempV = lists[i][0];

                gMax = Math.Max(gMax, tempV);

                PQ.Add(new Item(tempV, i, 0));
            }

            while(PQ.Count > 0)
            {
                Item itm = PQ.First();
                PQ.Remove(itm);

                int itmV = itm.value;
                int itmRow = itm.row;
                int itmCol = itm.col;

                range = Math.Min(range, gMax - itmV);

                // the smallest of k row, reached end,  we have finished visited 1 row, canoot find other range 
                if ((itmCol+1) >= lists[itmRow].Count)
                {
                    break;
                }

                gMax = Math.Max(gMax, lists[itmRow][itmCol + 1]);   // see if max can be replaced
                PQ.Add(new Item(lists[itmRow][itmCol + 1], itmRow, itmCol + 1));
            }

            return range;
        }
    }
}
