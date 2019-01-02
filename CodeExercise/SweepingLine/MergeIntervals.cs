using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SweepingLine
{
    class MergeIntervals
    {

        public class IntervalComparer : IComparer<Interval>
        {
            public int Compare(Interval i1, Interval i2)
            {
                if (i1.start != i2.start)
                {
                    return i1.start.CompareTo(i2.start);
                }
                return i1.end.CompareTo(i2.start);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/merge-intervals/description/
        /// 56. Merge Intervals
        /// Given a collection of intervals, merge all overlapping intervals.
        /// 
        /// Example 1:
        /// 
        /// Input: [[1,3],[2,6],[8,10],[15,18]]
        /// Output: [[1,6],[8,10],[15,18]]
        /// Explanation: Since intervals[1, 3] and[2, 6] overlaps, merge them into[1, 6].
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            List<Interval> ans = new List<Interval>();

            var intervalsArr = intervals.ToArray();
            Array.Sort(intervalsArr, new IntervalComparer());

            foreach (var itv in intervalsArr)
            {
                if (ans.Count == 0)
                {
                    ans.Add(itv);
                }
                else
                {
                    var last = ans[ans.Count - 1];
                    if (last.end < itv.start)
                    {
                        ans.Add(itv);
                    }
                    else
                    {
                        //overlapped
                        if (last.end < itv.end)
                        {
                            last.end = itv.end;
                        }
                    }
                }
            }
            return ans;
        }
    }
}
