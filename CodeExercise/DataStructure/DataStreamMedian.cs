using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 295. Find Median from Data Stream
    /// 
    /// Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value. So the median is the mean of the two middle value.
    /// Examples: 
    /// [2,3,4] , the median is 3
    /// 
    /// [2,3], the median is (2 + 3) / 2 = 2.5
    /// 
    /// Design a data structure that supports the following two operations:
    /// 
    /// void addNum(int num) - Add a integer number from the data stream to the data structure.
    /// double findMedian() - Return the median of all elements so far.
    /// For example:
    /// 
    /// addNum(1)
    /// addNum(2)
    /// findMedian() -> 1.5
    /// addNum(3)
    /// findMedian() -> 2
    /// </summary>
    class DataStreamMedian
    {
        SortedDictionary<int, int> maxHeap;
        SortedDictionary<int, int> minHeap;

        int totalCount;    // yic, Easy to get wrong,  cannot use heap.count  because it is key, not real total count

        public DataStreamMedian()
        {
            maxHeap = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            minHeap = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => x.CompareTo(y)));
            totalCount = 0;   // yic   this is to know where median is left or left+right
        }

        public void AddNum(int num)
        {
            totalCount++;
            // add to left
            AddToHeap(maxHeap, num);

            // swap top
            if (minHeap.Count > 0 && (maxHeap.Keys.First() > minHeap.Keys.First()))
            {
                int num1 = maxHeap.Keys.First();
                int num2 = minHeap.Keys.First();

                RemoveFromHeap(maxHeap, num1);
                RemoveFromHeap(minHeap, num2);

                AddToHeap(maxHeap, num2);
                AddToHeap(minHeap, num1);
            }

            // balance
            // yic: since we always add to left first, even count means left has 2 more, so need to rebalance
            if (totalCount %2 == 0)
            {
                int num1 = maxHeap.Keys.First();
                RemoveFromHeap(maxHeap, num1);
                AddToHeap(minHeap, num1);
            }
        }

        public double FindMedian()
        {
            if (totalCount == 0)
            {
                return 0;
            }

            if (totalCount %2 ==1)
            {
                // odd number
                return maxHeap.Keys.First();
            }

            return (maxHeap.Keys.First() + minHeap.Keys.First()) / 2.0;
        }

        private void AddToHeap(SortedDictionary<int, int> heap, int num)
        {
            if (!heap.ContainsKey(num))
            {
                heap.Add(num, 0);
            }
            heap[num]++;
        }

        private void RemoveFromHeap(SortedDictionary<int, int> heap, int num)
        {
            if (heap.ContainsKey(num))
            {
                heap[num]--;

                if (heap[num] == 0)
                {
                    heap.Remove(num);
                }
            }
        }
    }
}
