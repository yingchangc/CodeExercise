using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 57. Insert Interval
    /// https://leetcode.com/problems/insert-interval/description/
    /// Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
    /// 
    /// You may assume that the intervals were initially sorted according to their start times.
    /// 
    /// Example 1:
    /// 
    /// Input: intervals = [[1, 3], [6,9]], newInterval = [2,5]
    /// Output: [[1,5],[6,9]]
    /// Example 2:
    /// 
    /// Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
    /// Output: [[1,2],[3,10],[12,16]]
    /// Explanation: Because the new interval[4, 8] overlaps with[3, 5],[6,7],[8,10].
    /// </summary>
    class InsertInterval
    {
        public IList<Interval> InsertPractice(IList<Interval> intervals, Interval newInterval)
        {
            List<Interval> ans = new List<Interval>();
            intervals.Add(newInterval);

            var copy = intervals.ToArray();

            Array.Sort(copy, (i1, i2) => i1.start.CompareTo(i2.start));

            Interval pre = copy[0];
            for(int i = 1; i< copy.Length; i++)
            {
                Interval curr = copy[i];

                if (pre.end < curr.start)
                {
                    ans.Add(pre);
                    pre = curr;
                }
                else
                {
                    // overlap
                    // update pre end if needed
                    if (pre.end < curr.end)
                    {
                        pre.end = curr.end;
                    }
                }
            }

            ans.Add(pre);

            return ans;

        }

        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            List<Interval> ans = new List<Interval>();
            intervals.Add(newInterval);

            var copy = intervals.ToArray();

            Array.Sort(copy, (i1, i2) => i1.start.CompareTo(i2.start));

            Interval pre = intervals[0];
            for (int i = 0; i < copy.Length; i++)
            {
                if (i ==0)
                {
                    ans.Add(copy[0]);
                }
                else
                {
                    Interval curr = copy[i];
                    if (pre.end < curr.start)   // okay to seperate
                    {
                        ans.Add(curr);
                        pre = curr;
                    }
                    else  if (pre.end < curr.end)
                    {
                        pre.end = curr.end;   // override to longer interval end
                    }
                }

            }

            return ans;
            

        }
    }
}
