using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class ExclusiveTimeFunctions
    {
        /// <summary>
        /// 636. Exclusive Time of Functions
        /// https://leetcode.com/problems/exclusive-time-of-functions/
        /// Given the running logs of n functions that are executed in a nonpreemptive single threaded CPU, find the exclusive time of these functions.
        /// 
        /// Each function has a unique id, start from 0 to n-1. A function may be called recursively or by another function.
        /// 
        /// A log is a string has this format : function_id:start_or_end:timestamp.For example, "0:start:0" means function 0 starts from the very beginning of time 0. "0:end:0" means function 0 ends to the very end of time 0.
        /// 
        /// 
        /// Exclusive time of a function is defined as the time spent within this function, the time spent by calling other functions should not be considered as this function's exclusive time. You should return the exclusive time of each function sorted by their function id.
        /// 
        /// 
        /// Example 1:
        /// Input:
        /// n = 2
        ///         logs =
        ///         ["0:start:0",
        ///          "1:start:2",
        ///          "1:end:5",
        ///          "0:end:6"]
        ///         Output:[3, 4]
        /// Explanation:
        /// Function 0 starts at time 0, then it executes 2 units of time and reaches the end of time 1. 
        /// Now function 0 calls function 1, function 1 starts at time 2, executes 4 units of time and end at time 5.
        /// Function 0 is running again at time 6, and also end at the time 6, thus executes 1 unit of time.
        ///         So function 0 totally execute 2 + 1 = 3 units of time, and function 1 totally execute 4 units of time.
        ///         
        /// Sol
        /// The sample input is very confusing when time t has mixed meaning of beginning of time t for start and end of time t for end
        /// 
        /// logs = 
        /// ["0:start:0",
        ///  "1:start:2",
        ///  "1:end:5",
        ///  "0:end:6"]
        ///         We can increase all end time by 1 to normalize the meaning of time t, so time talways means "beginning of time t"
        /// 
        /// logs = 
        /// ["0:start:0",
        ///  "1:start:2",
        ///  "1:end:6",
        ///  "0:end:7"]
        /// </summary>
        /// <param name="n"></param>
        /// <param name="logs"></param>
        /// <returns></returns>
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            Stack<int> stk = new Stack<int>();

            int[] ans = new int[n];
            int preT = 0;


            for (int i = 0; i < logs.Count; i++)
            {
                var token = logs[i].Split(':');
                int currT = int.Parse(token[2]);
                int newId = int.Parse(token[0]);
                bool isStart = string.Compare(token[1], "start") == 0;

                if (!isStart)
                {
                    currT++;
                }

                // yic for all cases like this starting thread, (pre all ended)
                // "0:start:0","0:end:0", --- stk will be empty now  "1:start:1","1:end:1"
                if (stk.Count > 0)
                {
                    int runId = stk.Peek();
                    ans[runId] += currT - preT;
                }


                if (isStart)
                {
                    stk.Push(newId);
                }
                else
                {
                    stk.Pop();
                }

                preT = currT;
            }

            return ans;
        }
    }
}
