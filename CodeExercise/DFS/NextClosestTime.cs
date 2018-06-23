using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class NextClosestTime
    {
        //681. Next Closest Time
        //https://leetcode.com/problems/next-closest-time/description/
        /// <summary>
        /// Given a time represented in the format "HH:MM", form the next closest time by reusing the current digits. There is no limit on how many times a digit can be reused.

        ///You may assume the given input string is always valid.For example, "01:34", "12:09" are all valid. "1:34", "12:9" are all invalid.
        ///
        ///Example 1:
        ///
        ///
        ///Input: "19:34"
        ///Output: "19:39"
        ///Explanation: The next closest time choosing from digits 1, 9, 3, 4, is 19:39
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string NextClosestTimeSolver(string time)
        {
            HashSet<char> lookup = new HashSet<char>();
            foreach(var c in time)
            {
                lookup.Add(c);
            }

            int currTimeInMin = ConvertTimeStrToMinute(time);

            string ans = string.Empty;
            while(true)
            {
                ans = ConvertTimeNumToStr(++currTimeInMin);

                if (IsMatch(lookup, ans))
                {
                    break;
                }
            }
            return ans;
        }

        private bool IsMatch(HashSet<char> lookup, string timeStr)
        {
            foreach(var c in timeStr)
            {
                if (!lookup.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        private int ConvertTimeStrToMinute(string time)
        {
            int hr = Convert.ToInt32( time.Substring(0, 2));
            int min = Convert.ToInt32(time.Substring(3));

            return 60 * hr + min;
        }

        private string ConvertTimeNumToStr(int time)
        {
            int hr = (time / 60) % 24;   // yic need to %24 for overflow to another day
            int min = time % 60;

            string timeStr = "";

            timeStr = hr < 10 ? "0" + hr : hr.ToString();  // yic need append 0 for  02:02 case

            if (min < 10)
            {
                timeStr = timeStr + ":0" + min; 
            }
            else
            {
                timeStr += ":" + min;
            }
            return timeStr;
        }
    }
}
