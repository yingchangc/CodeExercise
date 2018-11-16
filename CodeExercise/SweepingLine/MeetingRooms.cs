using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SweepingLine
{
    class MeetingRooms
    {
        /* Definition for an interval.
 * public class Interval
        {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */

        public class IntervalItem
        {
            public int occupy;
            public int time;

            public IntervalItem(int time, int occupy)
            {
                this.occupy = occupy;
                this.time = time;
            }
        }

        /// <summary>
        /// 253. Meeting Rooms II
        /// https://leetcode.com/problems/meeting-rooms-ii/description/
        /// Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.
        /// 
        /// Example 1:
        /// 
        /// Input: [[0, 30],[5, 10],[15, 20]]
        /// Output: 2
        /// Example 2:
        /// 
        /// Input: [[7,10],[2,4]]
        /// Output: 1
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRoomsPractice(Interval[] intervals)
        {
            SortedDictionary<int, int> lookup = new SortedDictionary<int, int>();
            foreach(var intval in intervals)
            {
                if (!lookup.ContainsKey(intval.start))
                {
                    lookup.Add(intval.start, 0);
                }
                if (!lookup.ContainsKey(intval.end))
                {
                    lookup.Add(intval.end, 0);
                }
                lookup[intval.start]++;
                lookup[intval.end]--;
            }

            int currRoom = 0;
            int maxroom = 0;
            foreach (var key in lookup.Keys)
            {
                currRoom += lookup[key];
                maxroom = Math.Max(maxroom, currRoom);
            }

            return maxroom;
        }

        public int MinMeetingRooms(Interval[] intervals)
        {
            List<IntervalItem> collection = new List<IntervalItem>();
            foreach(var interval in intervals)
            {
                collection.Add(new IntervalItem(interval.start, 1));
                collection.Add(new IntervalItem(interval.end, -1));
            }

            collection.Sort((x,y) =>
            {
                if (x.time != y.time)
                {
                    return x.time.CompareTo(y.time);
                }
                return x.occupy.CompareTo(y.occupy);   // -1 earlier to prevent over count
            });

            int count = 0;
            int ans = 0;

            foreach(var item in collection)
            {
                count += item.occupy;
                ans = Math.Max(ans, count);
            }

            return ans;
        }
    }
}
