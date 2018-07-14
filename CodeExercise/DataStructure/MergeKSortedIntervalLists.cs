using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MergeKSortedIntervalLists
    {
        class IntervalInfo
        {
            public int rowIdx;
            public int colIdx;

            public Interval interval;

            public IntervalInfo(int row, int col, Interval itv)
            {
                rowIdx = row;
                interval = itv;
                colIdx = col;
            }
        }


        class IntervalComparer : IComparer<IntervalInfo>
        {
            public int Compare(IntervalInfo x, IntervalInfo y)
            {
                if (x.interval.start != y.interval.start)
                {
                    return x.interval.start.CompareTo(y.interval.start);
                }
                else if (x.interval.end != y.interval.end)
                {
                    return x.interval.end.CompareTo(y.interval.end);
                }
                else if (x.rowIdx != y.rowIdx)
                {
                    return x.rowIdx.CompareTo(y.rowIdx);
                }
                return x.colIdx.CompareTo(y.colIdx);
            }
        }
        /// <summary>
        /// lint 577. Merge K Sorted Interval Lists
        /// https://www.lintcode.com/problem/merge-k-sorted-interval-lists/description
        /// Merge K sorted interval lists into one sorted interval list.You need to merge overlapping intervals too.
        /// Example
        /// Given
        /// 
        /// 
        /// [
        ///   [(1,3),(4,7),(6,8)],
        ///   [(1, 2),(9, 10)]
        /// ]
        /// Return
        /// 
        /// [(1, 3), (4, 8), (9, 10)]
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public List<Interval> MergeKSortedIntervalListsSolver(List<List<Interval>> intervals)
        {
            SortedSet<IntervalInfo> PQ = new SortedSet<IntervalInfo>(new IntervalComparer());

            int numRows = intervals.Count;
            for (int i = 0; i < numRows; i++)
            {
                // get ith row 1st item, a row maybe empty
                if (intervals[i].Count > 0)
                {
                    var itvInfo = new IntervalInfo(i, 0, intervals[i][0]);
                    PQ.Add(itvInfo);
                }      
            }

            List<Interval> ans = new List<Interval>();
            Interval preItv = null;

            while (PQ.Count > 0)
            {
                // pop
                var itvInfo = PQ.First();
                PQ.Remove(itvInfo);


                // pre logic, update or insert
                var currItv = itvInfo.interval;
                if (preItv == null)
                {
                    preItv = currItv;
                }
                else
                {
                    // pre             curr
                    // start--end      start--end
                    if (preItv.end < currItv.start)
                    {
                        ans.Add(preItv);   // ok to add pre interval
                        preItv = currItv;
                    }
                    else
                    {
                        // pre           curr               
                        // p_start  c_start    
                        //                    p_end    c_end

                        //just  update pre end and reuse it
                        if (preItv.end < currItv.end)
                        {
                            preItv.end = currItv.end;
                        }
                    }
                }

                // insert new to pq
                int currRowIdx = itvInfo.rowIdx;
                int currColIdx = itvInfo.colIdx;
                if ((currColIdx+1) < intervals[currRowIdx].Count)
                {
                    PQ.Add(new IntervalInfo(currRowIdx, currColIdx + 1, intervals[currRowIdx][currColIdx + 1]));
                }
            }

            // yic don't forget the last interval
            ans.Add(preItv);

            return ans;

        }


    }
}
