using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SweepingLine
{
    class TimeIntersection
    {
        public class IntervalItem
        {
            public int loc;
            public int status;
            public IntervalItem(int loc, int status)
            {
                this.loc = loc;
                this.status = status;
            }
        }

        /// <summary>
        /// 821. Time Intersection
        /// https://www.lintcode.com/problem/time-intersection/description?_from=ladder
        /// Give two users' ordered online time series, and each section records the user's login time point x and offline time point y.Find out the time periods when both users are online at the same time, and output in ascending order.
        /// 
        /// 
        /// Example
        /// Given seqA = [(1, 2),(5,100)], seqB = [(1, 6)], return [(1, 2),(5, 6)].
        /// 
        /// Explanation:
        /// In these two time periods(1,2),(5,6), both users are online at the same time.
        /// Given seqA = [(1, 2),(10,15)], seqB = [(3, 5),(7, 9)], return [].
        /// 
        /// Explanation:
        /// There is no time period, both users are online at the same time.
        /// </summary>
        /// <param name="seqA"></param>
        /// <param name="seqB"></param>
        /// <returns></returns>
        public List<Interval> TimeIntersectionSolverPractice(List<Interval> seqA, List<Interval> seqB)
        {
            SortedDictionary<int, int> seqLookup = new SortedDictionary<int, int>();  // time, agg ops

            foreach(var duration in seqA)
            {
                if (!seqLookup.ContainsKey(duration.start))
                {
                    seqLookup.Add(duration.start, 0);
                }
                if (!seqLookup.ContainsKey(duration.end))
                {
                    seqLookup.Add(duration.end, 0);
                }

                seqLookup[duration.start]++;
                seqLookup[duration.end]--;
            }
            foreach (var duration in seqB)
            {
                if (!seqLookup.ContainsKey(duration.start))
                {
                    seqLookup.Add(duration.start, 0);
                }
                if (!seqLookup.ContainsKey(duration.end))
                {
                    seqLookup.Add(duration.end, 0);
                }

                seqLookup[duration.start]++;
                seqLookup[duration.end]--;
            }

            List<Interval> ans = new List<Interval>();
            Interval curr = null;
            int count = 0;
            foreach(var time in seqLookup.Keys)
            {
                count += seqLookup[time];
                if (count == 2)
                {
                    curr = new Interval();
                    curr.start = time;
                }
                else if (curr != null && count < 2)
                {
                    curr.end = time;
                    ans.Add(new Interval(curr.start, curr.end));
                    
                    //reset
                    curr = null;
                }
            }

            return ans;

        }
        public List<Interval> TimeIntersectionSolver(List<Interval> seqA, List<Interval> seqB)
        {
            List<IntervalItem> items = new List<IntervalItem>();
            int lenA = seqA.Count;
            for (int i = 0; i < lenA; i++)
            {
                Interval temp = seqA[i];
                IntervalItem left = new IntervalItem(temp.start, 1);
                IntervalItem right = new IntervalItem(temp.end, -1);
                items.Add(left);
                items.Add(right);
            }

            int lenB = seqB.Count;
            for (int i = 0; i < lenB; i++)
            {
                Interval temp = seqB[i];
                IntervalItem left = new IntervalItem(temp.start, 1);
                IntervalItem right = new IntervalItem(temp.end, -1);
                items.Add(left);
                items.Add(right);
            }

            // sort by loc and status -1 1
            items.Sort((x,y) =>
            {
                if (x.loc != y.loc)
                {
                    return x.loc.CompareTo(y.loc);
                }
                return x.status.CompareTo(y.status);
            });

            int currOnline = 0;
            List<int> records = new List<int>();

            for (int i= 0; i <items.Count; i++)
            {
                IntervalItem item = items[i];

                if (item.status > 0)
                {
                    currOnline++;
                }
                else
                {
                    currOnline--;
                }

                UpdateRecordsIfNecessary(currOnline, records, item);
            }

            return PrepareAnswer(records);
        }

        private void UpdateRecordsIfNecessary(int currOnline, List<int> records, IntervalItem item)
        {
            if (currOnline == 2)
            {
                records.Add(item.loc);
            }
            else if (currOnline == 1 && item.status == -1)
            {
                records.Add(item.loc);
            }
        }

        private List<Interval> PrepareAnswer(List<int> records)
        {
            List<Interval> ans = new List<Interval>();
            Interval curr = null;
            foreach(var time in records)
            {
                if (curr == null)
                {
                    curr = new Interval();
                    curr.start = time;
                }
                else
                {
                    curr.end = time;
                    ans.Add(curr);
                    curr = null;
                }
            }

            return ans;
        }
    }
}
