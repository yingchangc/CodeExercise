using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    public class Interval
    {
        public int start, end;
        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }

    class TimeComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    class AirplaneInSky
    {
        /// <summary>
        /// 391 Lint 
        /// http://www.lintcode.com/en/problem/number-of-airplanes-in-the-sky/
        /// Given an interval list which are flying and landing time of the flight. How many airplanes are on the sky at most?
        /// 
        /// [
        ///     [1,10],
        ///     [2,3],
        ///     [5,8],
        ///     [4,7]
        /// ]
        /// Return 3
        /// 
        /// </summary>
        /// <param name="airplanes"></param>
        /// <returns></returns>
        public int CountOfAirplanes(List<Interval> airplanes)
        {
            SortedDictionary<int, int> heap = new SortedDictionary<int, int>(new TimeComparer());
            foreach(var airplane in airplanes)
            {
                insertToHeap(heap, airplane.start, true);
                insertToHeap(heap, airplane.end, false);
            }

            int ans = 0;
            int numFlight = 0;
            foreach(var time in heap.Keys)
            {
                numFlight += heap[time];   // include start and end in order of time 
                ans = Math.Max(ans, numFlight);
            }

            return ans;
        }

        private void insertToHeap(SortedDictionary<int, int> heap, int time, bool isStart)
        {
            if (!heap.ContainsKey(time))
            {
                heap[time] = 0;
            }
            heap[time] += (isStart ? 1 : -1);
        }

    }
}
