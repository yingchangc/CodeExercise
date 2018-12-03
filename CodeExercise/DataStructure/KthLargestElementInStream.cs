using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 703. Kth Largest Element in a Stream
    /// https://leetcode.com/problems/kth-largest-element-in-a-stream/
    /// Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.
    /// 
    /// Your KthLargest class will have a constructor which accepts an integer k and an integer array nums, which contains initial elements from the stream.For each call to the method KthLargest.add, return the element representing the kth largest element in the stream.
    /// 
    /// Example:
    /// 
    /// int k = 3;
    ///     int[] arr = [4, 5, 8, 2];
    ///     KthLargest kthLargest = new KthLargest(3, arr);
    ///     kthLargest.add(3);   // returns 4
    /// kthLargest.add(5);   // returns 5
    /// kthLargest.add(10);  // returns 5
    /// kthLargest.add(9);   // returns 8
    /// kthLargest.add(4);   // returns 8
    /// </summary>
    class KthLargestElementInStream
    {
        private SortedSet<Item> minHeap;
        private int kth;

        public KthLargestElementInStream(int k, int[] nums)
        {
            minHeap = new SortedSet<Item>(new ItemComparer());
            kth = k;

            foreach (var num in nums)
            {
                InsertToHeap(num);
            }
        }

        private void InsertToHeap(int num)
        {
            minHeap.Add(new Item(num));


            if (minHeap.Count > kth)
            {
                var top = minHeap.First();
                minHeap.Remove(top);
            }

        }

        public int Add(int val)
        {
            InsertToHeap(val);

            return minHeap.First().val;
        }

        public class ItemComparer : IComparer<Item>
        {
            public int Compare(Item i1, Item i2)
            {
                if (i1.val != i2.val)
                {
                    return i1.val.CompareTo(i2.val);
                }
                return i1.GetHashCode().CompareTo(i2.GetHashCode());
            }

        }

        public class Item
        {
            public int val;

            public Item(int v)
            {
                val = v;
            }
        }
    }
}
