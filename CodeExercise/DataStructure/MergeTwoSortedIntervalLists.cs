using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 839. Merge Two Sorted Interval Lists
    /// https://www.lintcode.com/problem/merge-two-sorted-interval-lists/description
    /// Merge two sorted(ascending) lists of interval and return it as a new sorted list.The new sorted list should be made by splicing together the intervals of the two lists and sorted in ascending order.
    /// 
    ///   Example
    ///   Given list1 = [(1, 2),(3,4)] and list2 = [(2, 3),(5,6)], return [(1, 4),(5, 6)].
    ///   
    /// sol:
    /// 用一个 last 来记录最后一个还没有被放到 merge results 里的 Interval，用于和新加入的 interval 比较看看能不能合并到一起。

    /// 时间复杂度 O(n + m)O(n+m)
    /// </summary>
    class MergeTwoSortedIntervalLists
    {
        class IntervalComparer : IComparer<Interval>
        {
            public int Compare(Interval x, Interval y)
            {
                if (x.start != y.start)
                {
                    return x.start.CompareTo(y.start);
                }
                return x.end.CompareTo(y.end);
            }
        }

        public List<Interval> MergeTwoInterval(List<Interval> list1, List<Interval> list2)
        {
            if (list1 == null || list2 == null)
            {
                if (list1!= null)
                {
                    return list1;
                }
                return list2;
            }

            List<Interval> ans = new List<Interval>();
            SortedSet<Interval> pq = new SortedSet<Interval>(new IntervalComparer());

            AddToPQ(pq, list1);
            AddToPQ(pq, list2);

            Interval pre = null; 
            while(pq.Count > 0 )
            {
                // pop from pq
                Interval curr = pq.First();
                pq.Remove(curr);

                if (pre != null)
                {
                    // pre has dis join, can add directly
                    if (pre.end < curr.start)
                    {
                        ans.Add(pre);
                    }
                    else
                    {
                        // has intersection, cannot add to ans, and just need to update pre end
                        if (pre.end < curr.end)
                        {
                            pre.end = curr.end;
                        }
                    }
                }
                pre = curr;
            }

            ans.Add(pre);

            return ans;
            
        }

        private void AddToPQ(SortedSet<Interval> pq, List<Interval> list)
        {
            foreach(var interval in list)
            {
                pq.Add(interval);
            }

        }
    }

}
