using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SweepingLine
{
    class MergeIntervals
    {
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
            var copy = intervals.ToArray();
            Array.Sort(copy, new Comparison<Interval>(
                           (i1, i2) => i1.start.CompareTo(i2.start)   ));
            List<Interval> ans = new List<Interval>();

            Interval curr = null;
            foreach(var range in copy)
            {
                if (ans.Count == 0)
                {
                    ans.Add(range);
                }
                else
                {
                    var last = ans[ans.Count - 1];
                    if (last.end < range.start)
                    {
                        // 1 --- 3    4 ---5
                        ans.Add(range);
                    }
                    else if (last.end < range.end)
                    {
                        // just update the last one
                        ///  1---3   2---5
                        last.end = range.end;
                    }
                }
            }

          

            return ans.ToArray();
        }
    }
}
