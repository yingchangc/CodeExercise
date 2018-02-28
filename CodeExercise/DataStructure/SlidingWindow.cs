using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class SlidingWindow
    {
        /// <summary>
        /// 239
        /// Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.
        /// For example,
        /// Given nums = [1,3,-1,-3,5,3,6,7], and k = 3.
        /// 
        /// Window position Max
        /// ---------------               -----
        /// [1  3  -1] -3  5  3  6  7       3
        ///  1 [3  -1  -3] 5  3  6  7       3
        ///  1  3 [-1  -3  5] 3  6  7       5
        ///  1  3  -1 [-3  5  3] 6  7       5
        ///  1  3  -1  -3 [5  3  6] 7       6
        ///  1  3  -1  -3  5 [3  6  7]      7
        /// Therefore, return the max sliding window as [3,3,5,5,6,7].
        /// 
        /// Note: 
        /// You may assume k is always valid, ie: 1 ≤ k ≤ input array's size for non-empty array.
        /// 
        /// O(nLog(k))
        /// 
        /// Follow up:
        /// Could you solve it in linear time?
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow_Heap(int[] nums, int k)
        {
            SortedDictionary<int, int> maxHeap = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            int N = nums.GetLength(0);

            if (N == 0)
            {
                return new List<int>().ToArray();
            }

            for (int i = 0; i < k; i++)
            {
                addToHeap(maxHeap, nums[i]);
            }

            var ans = new List<int>();
            ans.Add(maxHeap.Keys.First());

            for (int i= k;  i < N; i++)
            {
                removeFromHeap(maxHeap, nums[i - k]);
                addToHeap(maxHeap, nums[i]);
                ans.Add(maxHeap.Keys.First());
            }

            return ans.ToArray();
        }

        // O(n)
        // use dequeue 
        /// <summary>
        /// 
        /// window size =3
        ///  [4 5 6]   is actually need to store 6  
        ///  
        ///  when 7 insert, replace 6,   and try remove 4 if is there (not because 5 and 6 insertion has removed it)
        ///  
        /// [7] 5 4 3    insert 5 and 4 as usual,   insert 3, remove 7
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow_DEQUEU(int[] nums, int k)
        {
            int N = nums.GetLength(0);

            if (N == 0)
            {
                return new List<int>().ToArray();
            }

            LinkedList<int> dequeue = new LinkedList<int>();
            List<int> ans = new List<int>();

            //[1,3,-1,-3,5,3,6,7]
            for (int i = 0; i <k; i++)
            {
                insertToDequeue(dequeue, nums[i]);
            }
            ans.Add(dequeue.Last());

            for (int i = k; i < N; i++)
            {
                removeFromDequeue(dequeue, nums[i - k]);
                insertToDequeue(dequeue, nums[i]);
                ans.Add(dequeue.Last());
            }

            return ans.ToArray();
        }

        private void insertToDequeue(LinkedList<int> dequeue, int num)
        {
            while(dequeue.Count > 0 && dequeue.First() < num)   // keep the same number in the list, only discard smaller
            {
                dequeue.RemoveFirst();
            }
            dequeue.AddFirst(num);
        }

        private void removeFromDequeue(LinkedList<int> dequeue, int num)
        {
            if (dequeue.Last() == num)
            {
                dequeue.RemoveLast();
            }
        }

        /// <summary>
        /// Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value. So the median is the mean of the two middle value.
        /// 
        /// For example,
        /// Given nums = [1, 3, -1, -3, 5, 3, 6, 7], and k = 3.
        /// 
        /// Window position                Median
        /// ---------------               -----
        /// [1  3  -1] -3  5  3  6  7       1
        ///  1 [3  -1  -3] 5  3  6  7       -1
        ///  1  3 [-1  -3  5] 3  6  7       -1
        ///  1  3  -1 [-3  5  3] 6  7       3
        ///  1  3  -1  -3 [5  3  6] 7       5
        ///  1  3  -1  -3  5 [3  6  7]      6
        /// Therefore, return the median sliding window as [1,-1,-1,3,5,6].
        /// 
        /// Note: 
        /// You may assume k is always valid, ie: k is always smaller than input array's size for non-empty array.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            // 1 2 3 4   ->    ([2], 1)  ([3],  4)
            SortedDictionary<int, int> minHeap = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => x.CompareTo(y)));
            SortedDictionary<int, int> maxHeap = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            
            List<double> medians = new List<double>();

            // init insert all to left (max heap),  then pop (N/2) to right
            InitHeap(maxHeap, minHeap, nums, k);
            medians.Add(getMedian(maxHeap, minHeap, k));

            int N = nums.GetLength(0);
            for (int i = k; i < N; i++)
            {
                insert(maxHeap, minHeap, k, nums[i], nums[i-k]);
                medians.Add(getMedian(maxHeap, minHeap, k));
            }

            return medians.ToArray();
        }

        private void removeFromHeap(SortedDictionary<int, int> heap, int num)
        {
            if (heap[num] > 1)
            {
                heap[num]--;
            }
            else
            {
                heap.Remove(num);
            }
        }

        private void addToHeap(SortedDictionary<int, int> heap, int num)
        {
            if (!heap.ContainsKey(num))
            {
                heap.Add(num, 0);
            }
            heap[num]++;
        }

        private void insert(SortedDictionary<int, int> maxHeap, SortedDictionary<int, int> minHeap, int k, int newNum, int oldNum)
        {
            // delete old num
            if (maxHeap.ContainsKey(oldNum))
            {
                // remove from left
                removeFromHeap(maxHeap, oldNum);

                // so need to put a num back to left.
                addToHeap(maxHeap, newNum);
            }
            else
            {
                // remove from right
                removeFromHeap(minHeap, oldNum);

                // so need to put a num back to right
                addToHeap(minHeap, newNum);
            }

            // Make sure maxHeap top is smaller than minHeap top   ex insert 6   to L(2, 1,)  R(5,8)    
            // YIC for k windows == 1, skip
            if (k > 1)
            {
                balanceHeaps(maxHeap, minHeap);
            }
            
        }

        private void balanceHeaps(SortedDictionary<int, int> maxHeap, SortedDictionary<int, int> minHeap)
        {
            // Make sure maxHeap top is smaller than minHeap top   ex insert 6   to L(2, 1,)  R(5,8)    
            int left = maxHeap.Keys.First();
            int right = minHeap.Keys.First();
            if (left > right)
            {
                removeFromHeap(maxHeap, left);
                removeFromHeap(minHeap, right);
                addToHeap(maxHeap, right);
                addToHeap(minHeap, left);
            }
        }

        private double getMedian(SortedDictionary<int, int> maxHeap, SortedDictionary<int, int> minHeap, int k)
        {
            if (k%2 == 1)
            {
                return maxHeap.Keys.First();
            }

            return ((double)(maxHeap.Keys.First()) + (double)(minHeap.Keys.First())) /2.0;
        }

        private void InitHeap(SortedDictionary<int, int> maxHeap, SortedDictionary<int, int> minHeap, int[] nums, int k)
        {
            for (int i = 0; i < k; i++)
            {
                int num = nums[i];
                addToHeap(maxHeap, num);
            }

            for (int i = 0; i < k / 2; i++)
            {
                int num = maxHeap.Keys.First();

                // add to right
                addToHeap(minHeap, num);


                // remove num from left list
                removeFromHeap(maxHeap, num);
            }
        }
    }
}
