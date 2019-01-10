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
            if (points == null || points.Length < 1)
            {
                return 0;
            }
            else if (points.Length == 1)
            {
                return 1;
            }

            int count = points.Length;

            int gMax = 0;

            for (int i = 0; i < count; i++)
            {
                int samePt = 0;
                int levelMax = 0;
                var lookup = new Dictionary<string, int>();  // slope, freq   at curr level

                for (int j = i + 1; j < count; j++)
                {
                    // the same start p1, if same slope, it will be in the same line

                    // same pt can be count as any slope
                    if (points[i].x == points[j].x && points[i].y == points[j].y)
                    {
                        samePt++;
                        continue;   // yic
                    }

                    int deltaX = (points[j].x - points[i].x);
                    int deltaY = (points[j].y - points[i].y);

                    string nslope;
                    if (deltaX == 0)
                    {
                        nslope = "INF";
                    }
                    else if (deltaY == 0)
                    {
                        nslope = "0";
                    }
                    else
                    {
                        int big = Math.Max(deltaX, deltaY);
                        int small = Math.Min(deltaX, deltaY);
                        int gcd = ComputeGCD(big, small);
                        deltaX /= gcd;
                        deltaY /= gcd;

                        string sign = "+";
                        if ((deltaX > 0 && deltaY < 0) || (deltaX < 0 && deltaY > 0))
                        {
                            sign = "-";
                        }

                        nslope = sign + Math.Abs(deltaX) + "," + Math.Abs(deltaY); // normalized slope as point
                    }

                    if (!lookup.ContainsKey(nslope))
                    {
                        lookup.Add(nslope, 0);  // bo self i, because [0,0][0,0] same point case cannot get self
                    }
                    var freq = ++lookup[nslope];

                    levelMax = Math.Max(freq, levelMax);
                }

                levelMax += samePt;

                gMax = Math.Max(gMax, levelMax + 1);  // yic add self
            }

            return gMax;
        }

        int ComputeGCD(int big, int small)
        {
            if (small == 0)
            {
                return big;
            }

            return ComputeGCD(small, big % small);
        }
    }
}
