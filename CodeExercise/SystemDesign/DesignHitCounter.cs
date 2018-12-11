using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    /// <summary>
    /// 362. Design Hit Counter
    /// https://leetcode.com/problems/design-hit-counter/
    /// Design a hit counter which counts the number of hits received in the past 5 minutes.
    /// 
    /// Each function accepts a timestamp parameter(in seconds granularity) and you may assume that calls are being made to the system in chronological order(ie, the timestamp is monotonically increasing). You may assume that the earliest timestamp starts at 1.
    /// 
    /// It is possible that several hits arrive roughly at the same time.
    /// 
    /// Example:
    /// 
    /// HitCounter counter = new HitCounter();
    /// 
    ///     // hit at timestamp 1.
    ///     counter.hit(1);
    /// 
    /// // hit at timestamp 2.
    /// counter.hit(2);
    /// 
    /// // hit at timestamp 3.
    /// counter.hit(3);
    /// 
    /// // get hits at timestamp 4, should return 3.
    /// counter.getHits(4);
    /// 
    /// // hit at timestamp 300.
    /// counter.hit(300);
    /// 
    /// // get hits at timestamp 300, should return 4.
    /// counter.getHits(300);
    /// 
    /// // get hits at timestamp 301, should return 3.
    /// counter.getHits(301); 
    /// </summary>
    class DesignHitCounter
    {
        public class Second
        {
            public int sec;
            public int hitCount;

            public Second(int sec)
            {
                this.sec = sec;
                this.hitCount = 1;
            }

        }

        int TotalHit;
        Queue<Second> que;
        /** Initialize your data structure here. */
        public DesignHitCounter()
        {
            TotalHit = 0;
            que = new Queue<Second>();
        }

        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void Hit(int timestamp)
        {
            if (que.Count > 0 && que.First().sec == timestamp)
            {
                que.First().hitCount++;
            }
            else
            {
                que.Enqueue(new Second(timestamp));
            }
            
            TotalHit++;
        }

        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int GetHits(int timestamp)
        {
            while (que.Count > 0 && timestamp - que.First().sec >= 300)
            {
                var timeUnit = que.Dequeue();
                TotalHit -= timeUnit.hitCount;
            }

            return TotalHit;
        }
    }
}
