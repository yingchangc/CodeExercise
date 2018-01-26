using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class KthSmallestElementInMatrix
    {
        /// <summary>
        /// 378. Kth Smallest Element in a Sorted Matrix
        /// Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.
        /// 
        ///         Note that it is the kth smallest element in the sorted order, not the kth distinct element.
        /// 
        ///         Example:
        /// 
        /// matrix = [
        ///    [ 1,  5,  9],
        ///    [10, 11, 13],
        ///    [12, 13, 15]
        /// ],
        /// k = 8,
        /// 
        /// return 13.
        /// Note: 
        /// You may assume k is always valid, 1 ≤ k ≤ n2.
        /// 
        /// sol, use minheap, C# does not have PriorityQueue, use SortedDictionary O(LogN)
        /// 
        /// (1) use BinarySearch
        /// https://www.youtube.com/watch?v=UP4RF_UjyNk
        /// use top-left as smallest, bottom-right as largest
        /// get mid and see if kth is in left or right   O(n *Log(Max-Min))    n is from count the worst is all matrix
        /// 
        /// Tricky part is how to compute mid is in Xth 
        /// ues left-bottom as start, if mid is smaller, go up (j-1),
        /// if mid is targer, count += j+1   (consider all to the top row is smaller than mid, so the count should consider it) then i++
        /// if j smaller than 0  or i greater than width, stop 
        /// 
        /// (2)
        /// Use Priority Queue,  then O(kLog(m))  where m is the inserted lengh for sort
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(int[,] matrix, int k)
        {
            ///    [[ 1,  5,  9],
            ///    [10, 11, 13],
            ///    [12, 13, 15]]
            ///     k = 8,
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);
            int left = matrix[0, 0];
            int right = matrix[M - 1, N - 1];  //(j,i)      

            while (left < right)
            {
                int mid = (left + right) / 2;
                int rank = countRank(matrix, mid);

                if (rank >= k)                 // note >=  use mid
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;    // note mid +1
                }
            }

            return left;
        }

        // count where mid rank, start from botton-left as moving point
        private int countRank(int[,] matrix, int mid)
        {
            int M = matrix.GetLength(0);   // for j
            int N = matrix.GetLength(1);   // for i
            int i = 0;
            int j = N - 1;

            int rank = 0;
            // move i, j
            while(i < N && j >= 0)
            {
                int debug = matrix[j, i];
                if (matrix[j,i] > mid)  // note  yic   [j,i]
                {
                    j--;
                }
                else
                {
                    rank +=( j + 1);  // i becasue consider all the to top +1 to include itself
                    i++;
                }
            }

            return rank;
        }

        public int KthSmallestPQ(int[,] matrix, int k)
        {
            int h = 2 + (3-2) / 2;
            SortedDictionary<int, List<Location>> pq = new SortedDictionary<int, List<Location>>();   // key num, count,  since each key has to be unique
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            // insert (0,0)
            bool[,] memo = new bool[m, n];
            memo[0, 0] = true;
            pq.Add(matrix[0, 0], new List<Location>() { new Location(0,0)});

            int kth = matrix[0, 0];

            // dx helper
            List<Location> deltas = new List<Location>() { new Location(1, 0), new Location(0, 1) }; 

            for (int i = 0; i < k; i++)
            {
                var item = pq.First();

                // (1) update kth
                kth = item.Key;

                // (2) insert right and bottom
                var locas = item.Value;
                var loc = locas[0];

                foreach(var delta in deltas)
                {
                    if (((loc.x + delta.x) < m && (loc.y + delta.y) < n) && !memo[loc.x + delta.x, loc.y + delta.y])   // yic notice the boundary check
                    { 
                        if (pq.ContainsKey(matrix[loc.x + delta.x, loc.y + delta.y]))
                        {
                            var storeLocs = pq[matrix[loc.x + delta.x, loc.y + delta.y]];
                            storeLocs.Add(new Location(loc.x + delta.x, loc.y + delta.y));
                        }
                        else
                        {
                            pq.Add(matrix[loc.x + delta.x, loc.y + delta.y], new List<Location>() { new Location(loc.x + delta.x, loc.y + delta.y) });
                        }

                        memo[loc.x + delta.x, loc.y + delta.y] = true;
                    }
                }

                // (3) remove item
                if (item.Value.Count == 1)
                {
                    pq.Remove(item.Key);
                }
                else
                {
                    locas.RemoveAt(0);
                }   
            }

            return kth;

        }

        class Location
        {
            public Location(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int x { get; set; }
            public int y { get; set; }
        }
    }
}
