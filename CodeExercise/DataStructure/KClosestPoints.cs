using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class KClosestPoints
    {
        class PointComparer : IComparer<Point>
        {
            public int Compare(Point p1, Point p2)
            {
                if (p1.x != p2.x)
                {
                    return p2.x.CompareTo(p1.x);
                }
                return p2.y.CompareTo(p1.y);
            }
        }

        class DistComparer : IComparer<double>
        {
            public int Compare(double d1, double d2)
            {
                return d2.CompareTo(d1);
            }
        }
        SortedDictionary<double, SortedDictionary<Point, int>> pq;

        


        /// <summary>
        /// https://www.lintcode.com/problem/k-closest-points/description
        /// lint 612. K Closest Points
        /// Given some points and a point origin in two dimensional space, find k points out of the some points which are nearest to origin.
        /// Return these points sorted by distance, if they are same with distance, sorted by x-axis, otherwise sorted by y-axis.
        /// 
        /// Example
        /// Given points = [[4,6],[4,7],[4,4],[2,5],[1,1]], origin = [0, 0], k = 3
        /// return [[1,1],[2,5],[4,4]]
        /// 
        /// 
        /// sol: 
        /// 
        /// insert to pq with longest dist order, when exceed k, pop
        /// 
        /// after insert all,  the pq remains size of k
        /// 
        /// reverse add to ans[--count] from pq.pop
        /// </summary>
        /// <param name="points"></param>
        /// <param name="origin"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public Point[] kClosest(Point[] points, Point origin, int k)
        {
            if (points.Length < k)
            {
                throw new Exception("k is larger than all points");
            }

            // <distance,  (pt, count)>
            pq = new SortedDictionary<double, SortedDictionary<Point, int>>(new DistComparer());

            int queueSize = 0;
            foreach(Point pt in points)
            {
                double dist = GetDistance(pt, origin);
                AddToPQ(pt, dist);
                queueSize++;

                if (queueSize > k)
                {
                    double longestDist = pq.Keys.First();
                    Point p = pq[longestDist].Keys.First();
                    RemoveFromPQ(p, longestDist);
                    queueSize--;
                }
            }

            Point[] ans = new Point[k];
            int count = k;

            while (count > 0)
            {
                foreach(var dist in pq.Keys)
                {
                    foreach (var pt in pq[dist].Keys)
                    {
                        // handle duplicate point
                        int ptCount = pq[dist][pt];

                        for(int i = 0; i < ptCount; i++)
                        {      
                            ans[--count] = pt;
                        }        
                    }
                }

                
                
            }

            return ans;
            
        }

        private void RemoveFromPQ(Point pt, double dist)
        {
            int ptDupCount = pq[dist][pt];
            if (ptDupCount == 1)
            {
                // only 1 pt of the dist
                if (pq[dist].Keys.Count == 1)
                {
                    pq.Remove(dist);
                }
                else
                {
                    pq[dist].Remove(pt);
                }
            }
            else
            {
                pq[dist][pt]--;
            }
        }
        private void AddToPQ(Point pt, double dist)
        {
            if (!pq.ContainsKey(dist))
            {
                pq.Add(dist, new SortedDictionary<Point, int>(new PointComparer()));
            }

            if (!pq[dist].ContainsKey(pt))
            {
                pq[dist].Add(pt, 1);
            }
            else
            {
                pq[dist][pt]++;
            }

        }

        private double GetDistance(Point pt, Point origin)
        {
            return Math.Sqrt((pt.x - origin.x)* (pt.x - origin.x) 
                + (pt.y - origin.y)* (pt.y - origin.y));
        }
    }
}
