using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    /// <summary>
    /// 505. Web Logger
    /// https://www.lintcode.com/en/problem/web-logger/
    /// Implement a web logger, which provide two methods:
    /// 
    /// hit(timestamp), record a hit at given timestamp.
    /// get_hit_count_in_last_5_minutes(timestamp), get hit count in last 5 minutes.
    /// the two methods will be called with non-descending timestamp(in sec).
    /// 
    /// hit(1);
    /// hit(2);
    /// get_hit_count_in_last_5_minutes(3);
    /// >> 2
    /// hit(300);
    /// get_hit_count_in_last_5_minutes(300);
    /// >> 3
    /// get_hit_count_in_last_5_minutes(301);
    /// >> 2
    /// 
    /// </summary>
    class WebLogger
    {
        List<int> record;
        public WebLogger()
        {
            record = new List<int>();
        }

        /*
         * @param timestamp: An integer
         * @return: nothing
         */
        public void hit(int timestamp)
        {
            record.Add(timestamp);
        }

        /*
         * @param timestamp: An integer
         * @return: An integer
         */
        public int get_hit_count_in_last_5_minutes(int timestamp)
        {
            int startTime = timestamp - 300;
            while(record.Count > 0)
            {
                if(record[0] <= startTime)        // record is ascending; yic note <=
                {
                    record.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }

            return record.Count;
        }
    }
}
