using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class PourWater
    {
        SortedSet<LocH> pq = new SortedSet<LocH>(new LocHComparer());

        /// <summary>
        /// 755. Pour Water
        /// https://leetcode.com/problems/pour-water/description/
        /// We are given an elevation map, heights[i] representing the height of the terrain at that index. The width at each index is 1. After V units of water fall at index K, how much water is at each index?
        /// 
        /// Water first drops at index K and rests on top of the highest terrain or water at that index.Then, it flows according to the following rules:
        /// 
        /// If the droplet would eventually fall by moving left, then move left.
        /// Otherwise, if the droplet would eventually fall by moving right, then move right.
        /// Otherwise, rise at it's current position.
        /// Here, "eventually fall" means that the droplet will eventually be at a lower level if it moves in that direction. Also, "level" means the height of the terrain plus any water in that column.
        /// We can assume there's infinitely high terrain on the two sides out of bounds of the array. Also, there could not be partial water being spread out evenly on more than 1 grid block - each unit of water has to be in exactly one block.
        /// </summary>
        /// <param name="heights"></param>
        /// <param name="V"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int[] PourWaterSolver(int[] heights, int V, int K)
        {
            

            pq.Add(new LocH(K, heights[K]));

            int left = K - 1;
            int right = K + 1;

            int minBoundaryH = heights[K];

            UpdatePQ(heights, ref left, ref right, ref minBoundaryH);   // left can be -1 loc or loc with height[left] > height[k]


            while (V > 0)
            {
                var curr = pq.First();
                pq.Remove(curr);
                heights[curr.loc]++;
                curr.height++;
                pq.Add(curr);
                V--;


                if (pq.First().height >= minBoundaryH)
                {
                    UpdatePQ(heights, ref left, ref right, ref minBoundaryH);
                }
            }

            return heights;
        }

        private void UpdatePQ(int[] heights, ref int left, ref int right, ref int minBoundaryH)
        {
            while (left >= 0 && heights[left] <= minBoundaryH)
            {
                pq.Add(new LocH(left, heights[left]));
                left--;
            }

            while (right < heights.Length && heights[right] <= minBoundaryH)
            {
                pq.Add(new LocH(right, heights[right]));
                right++;
            }

            if (left >= 0 && right < heights.Length)
            {
                minBoundaryH = Math.Max(minBoundaryH, Math.Min(heights[left], heights[right]));
            }
            else if (left >= 0)
            {
                minBoundaryH = heights[left];
            }
            else if (right < heights.Length)
            {
                minBoundaryH = heights[right];
            }
            else
            {
                minBoundaryH = Int32.MaxValue;  // reach boarder
            }
        }

        public class LocH
        {
            public int loc;
            public int height;
            public LocH(int loc, int h)
            {
                this.loc = loc;
                this.height = h;
            }
        }

        public class LocHComparer : IComparer<LocH>
        {
            public int Compare(LocH l1, LocH l2)
            {
                if (l1.height != l2.height)
                {
                    return l1.height.CompareTo(l2.height);
                }
                return l1.loc.CompareTo(l2.loc);
            }
        }
    }
}
