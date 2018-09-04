using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class TrapRainWater
    {
        /// <summary>
        /// 42. Trapping Rain Water
        /// https://leetcode.com/problems/trapping-rain-water/description/
        /// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water 
        /// it is able to trap after raining.
        /// 
        /// Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.
        /// 
        /// sol:
        /// 
        /// use left and right,
        /// 
        // pick smaller height and got one direction to get area (since the otherside is higher, won't go over)  (stop when leftH <= arr[i])
        // then reconsider choose left or right
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int TrapRainWaterPractice(int[] height)
        {
            int N = height.GetLength(0);

            if (N == 0)
            {
                return 0;
            }

            int left = 0;
            int right = N - 1;

            int area = 0;

            while (left < right)
            {
                int leftH = height[left];
                int rightH = height[right];

                if (leftH <= rightH)
                {
                    int i = left + 1;
                    while (leftH > height[i])
                    {
                        area += (leftH - height[i]);
                        i++;
                    }
                    left = i;
                }
                else
                {
                    int i = right - 1;
                    while (height[i] < rightH)
                    {
                        area += (rightH - height[i]);
                        i--;
                    }
                    right = i;
                }
            }

            return area;
        }
        public int TrapRainWaterSolution(int[] height)
        {
            int N = height.GetLength(0);

            if (N == 0)
            {
                return 0;
            }

            int i = 0;
            int j = N - 1;

            int area = 0;

            while (i != j)
            {
                int left = height[i];
                int right = height[j];

                if (left <= right)
                {
                    while(left > height[++i])     //yic only left to prevent all height equal and i, j corss case
                    {                        // when choose left, means if we later encounter a new higher, it can be either  <j  or just j.  will not have cross case
                        area += (left - height[i]);
                    }
                }
                else
                {
                    while (height[--j] < right)
                    {
                        area += (right - height[j]);
                    }
                }
            }

            return area; 
        }

        /// <summary>
        /// 407
        /// Given n x m non-negative integers representing an elevation map 2d where the area of each cell is 1 x 1, compute how much water it is able to trap after raining.
        /// Note:
        /// Both m and n are less than 110. The height of each unit cell is greater than 0 and is less than 20,000.
        /// 
        /// Example:
        /// 
        /// Given the following 3x6 height map:
        /// [
        ///   [1,4,3,1,3,2],
        ///   [3,2,1,3,2,4],
        ///   [2,3,3,2,3,1]
        /// ]
        /// 
        /// Return 4.
        /// 
        /// Sol:
        /// 
        /// find contour to get boundary, and start to pop smallest and compute the neighbor can trapped water
        /// </summary>
        /// <param name="heightMap"></param>
        /// <returns></returns>
        public int TrapRainWater2(int[,] heightMap)
        {
            // sort ascending
            SortedDictionary<int, List<Location>> pq = new SortedDictionary<int, List<Location>>(new NumComparer());

            int Y = heightMap.GetLength(0);
            int X = heightMap.GetLength(1);

            bool[,] visited = new bool[Y, X];

            // insert bounddary
            insertBoundaryToPQ(pq, heightMap, visited, X, Y);

            var deltas = new List<Location> { new Location(1,0),
                                              new Location(-1,0),
                                              new Location(0,1),
                                              new Location(0,-1),
            };

            int area = 0;

            while(pq.Count > 0)
            {
                int currH = pq.Keys.First();

                while (pq.ContainsKey(currH))
                {
                    var firstLocOfCurrH = pq[currH].First();
                    // four neightbors
                    foreach(var delta in deltas)
                    {
                        int neighborX = firstLocOfCurrH.x + delta.x;
                        int neighborY = firstLocOfCurrH.y + delta.y;

                        if (neighborX < 0 || neighborX >=X 
                            || neighborY < 0 || neighborY >= Y
                            || visited[neighborY, neighborX])  // other smaller H has also visited the neighbor, should skip
                        {
                            continue;
                        }

                        visited[neighborY, neighborX] = true;

                        //compute trap water, can only be inward
                        if (currH > heightMap[neighborY, neighborX])
                        {
                            area += (currH - heightMap[neighborY, neighborX]);
                        }

                        insertToPQ(pq, Math.Max(currH, heightMap[neighborY, neighborX]), neighborX, neighborY);
                    }

                    removeFirstLocationOfKeyFromPQ(pq, currH);
                }
            }

            return area;
        }

        private void insertBoundaryToPQ(SortedDictionary<int, List<Location>> pq, int[,] heightMap, bool[,] visited, int X, int Y)
        {
            for (int j = 0; j < Y; j++)
            {
                if (visited[j, 0] || visited[j, X - 1])
                {
                    continue;
                }
                int heightLeft = heightMap[j, 0];
                int heighRight = heightMap[j, X-1];

                visited[j, 0] = true;
                visited[j, X - 1] = true;

                if (!pq.ContainsKey(heightLeft))
                {
                    pq.Add(heightLeft, new List<Location>());
                }
                pq[heightLeft].Add(new Location(0, j));

                if (!pq.ContainsKey(heighRight))
                {
                    pq.Add(heighRight, new List<Location>());
                }
                pq[heighRight].Add(new Location(X-1, j));
            }

            for (int i = 1; i < X - 1; i++)
            {
                if (visited[0, i] || visited[Y - 1, i])
                {
                    continue;
                }
                int heightUp = heightMap[0, i];
                int heighDown = heightMap[Y-1, i];

                visited[0, i] = true;
                visited[Y - 1, i] = true;

                if (!pq.ContainsKey(heightUp))
                {
                    pq.Add(heightUp, new List<Location>());
                }
                pq[heightUp].Add(new Location(i, 0));

                if (!pq.ContainsKey(heighDown))
                {
                    pq.Add(heighDown, new List<Location>());
                }
                pq[heighDown].Add(new Location(i, Y-1));
            }
        }

        private void insertToPQ(SortedDictionary<int, List<Location>> pq, int height, int x, int y)
        {
            if (!pq.ContainsKey(height))
            {
                pq.Add(height, new List<Location>());
                
            }
            pq[height].Add(new Location(x, y));
        }

        private void removeFirstLocationOfKeyFromPQ(SortedDictionary<int, List<Location>> pq, int height)
        {
            if (pq.ContainsKey(height))
            {
                if (pq[height].Count == 1)
                {
                    pq.Remove(height);
                }
                else
                {
                    pq[height].RemoveAt(0);
                }
            }
        }

        class Location
        {
            public Location(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int x;
            public int y;
        }

        // ascending
        class NumComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x - y;
            }
        }

    }
}
