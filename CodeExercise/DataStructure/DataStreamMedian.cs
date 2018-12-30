using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 295. Find         Median from Data Stream
    /// https://leetcode.com/problems/find-median-from-data-stream/
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
        private SortedSet<Num> maxHeap;   // left
        private SortedSet<Num> minHeap;   // right

        /** initialize your data structure here. */
        public DataStreamMedian()
        {
            maxHeap = new SortedSet<Num>(new NumDescComparer());
            minHeap = new SortedSet<Num>(new NumAscComparer());
        }

        public void AddNum(int num)
        {

            maxHeap.Add(new Num(num));



            if ((maxHeap.Count) > (minHeap.Count + 1))
            {
                // balance
                var temp = maxHeap.First();
                maxHeap.Remove(temp);
                minHeap.Add(temp);
            }
            else
            {
                var tempL = maxHeap.First();

                // yic
                if (minHeap.Count == 0)
                {
                    return;
                }

                var tempR = minHeap.First();

                // {1,10}  vs {5}
                if (tempL.val > tempR.val)
                {
                    maxHeap.Remove(tempL);
                    minHeap.Remove(tempR);

                    maxHeap.Add(tempR);
                    minHeap.Add(tempL);
                }
            }
        }

        public double FindMedian()
        {
            if (maxHeap.Count == minHeap.Count)
            {
                var tempL = maxHeap.First();
                var tempR = minHeap.First();

                return (1.0 * tempL.val + 1.0 * tempR.val) / 2;
            }
            else
            {
                var tempL = maxHeap.First();
                return tempL.val;
            }

        }

        public class Num
        {
            public int val;
            public Num(int number)
            {
                val = number;
            }
        }

        public class NumAscComparer : IComparer<Num>
        {
            public int Compare(Num n1, Num n2)
            {
                if (n1.val != n2.val)
                {
                    return n1.val.CompareTo(n2.val);
                }
                else
                {
                    return n1.GetHashCode().CompareTo(n2.GetHashCode());
                }
            }
        }

        public class NumDescComparer : IComparer<Num>
        {
            public int Compare(Num n1, Num n2)
            {
                if (n1.val != n2.val)
                {
                    return n2.val.CompareTo(n1.val);
                }
                else
                {
                    return n1.GetHashCode().CompareTo(n2.GetHashCode());
                }
            }
        }
       
    }
}
