using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MaxPointsOnLine
    {
        /// <summary>
        /// 149
        /// https://leetcode.com/problems/max-points-on-a-line/description/
        /// Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
        /// 
        /// Example 1:
        /// 
        /// Input: [[1,1],[2,2],[3,3]]
        /// Output: 3
        /// Explanation:
        /// ^
        /// |
        /// |        o
        /// |     o
        /// |  o  
        /// +------------->
        /// 0  1  2  3  4
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxPoints(Point[] points)
        {
            int count = points.Length;

            if (count == 0)
            {
                return 0;
            }
            if (count == 1)
            {
                return 1;
            }

            int maxPointInLine = 0;

            Dictionary<Point, Dictionary<double, int>> lookup = new Dictionary<Point, Dictionary<double, int>>(); // point,   {slope, count}

            for (int i = 0; i < count; i++)
            {
                var slopeCollection = new Dictionary<double, int>();
                int samepoint = 0;
                for(int j = i+1; j < count; j++)
                {
                    if (points[i].x == points[j].x && points[i].y == points[j].y)
                    {
                        samepoint++;   // save later for all points
                    }
                    else
                    {
                        double slope = ComputeSlope(points[i], points[j]);
                        if (!slopeCollection.ContainsKey(slope))
                        {
                            slopeCollection.Add(slope, 0);
                        }
                        slopeCollection[slope]++;
                    }
                }

                int localMax = 0;
                foreach(var slopCount in slopeCollection.Values)
                {
                    localMax = Math.Max(localMax, slopCount);
                }

                maxPointInLine = Math.Max(maxPointInLine, 1 + samepoint + localMax);
            }

            return maxPointInLine;
        }

        private double ComputeSlope(Point p1, Point p2)
        {
            if (p1.x == p2.x)
            {
                return Double.MaxValue;
            }

            var diffX = p1.x - p2.x;
            var diffY = p1.y - p2.y;

            return (1.0*(p1.y - p2.y)) / (1.0*(p1.x - p2.x));

        }

        private int gcd(int big, int small)
        {
            if (small != 0)
            {
                return gcd(small, big % small);
            }
            else
            {
                return big;
            }
        }
    }
}
