using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class TaskScheduler
    {
        /// <summary>
        /// 621. Task Scheduler
        /// https://leetcode.com/problems/task-scheduler/description/
        /// Given a char array representing tasks CPU need to do. It contains capital letters A to Z where different letters represent different tasks.Tasks could be done without original order. Each task could be done in one interval. For each interval, CPU could finish one task or just be idle.
        /// 
        /// However, there is a non-negative cooling interval n that means between two same tasks, there must be at least n intervals that CPU are doing different tasks or just be idle.
        /// 
        /// You need to return the least number of intervals the CPU will take to finish all the given tasks.
        /// 
        /// Example:
        /// 
        /// Input: tasks = ["A","A","A","B","B","B"], n = 2
        /// Output: 8
        /// Explanation: A -> B -> idle -> A -> B -> idle -> A -> B.
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastCharFreq(char[] tasks, int n)
        {
            Dictionary<char, int> lookup = new Dictionary<char, int>();

            foreach (char c in tasks)
            {
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, 0);
                }
                lookup[c]++;
            }

            SortedSet<CharFreq> maxHeap = new SortedSet<CharFreq>(new CharFreqComparer());

            foreach (char c in lookup.Keys)
            {
                maxHeap.Add(new CharFreq(c, lookup[c]));
            }

            int ans = 0;

            while (maxHeap.Count > 0)
            {
                List<CharFreq> temp = new List<CharFreq>();
                for (int i = 0; i <= n; i++)  //yic  <= n because we need n space for next same
                {
                    if (maxHeap.Count > 0)
                    {
                        temp.Add(maxHeap.First());
                        maxHeap.Remove(temp[i]);  // pop
                        temp[i].freq--;
                        ans++;
                    }
                }

                // Find the gap to fill
                int inserted = temp.Count;
                int gap = ((n + 1) - inserted);


                // put remaining back
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].freq > 0)
                    {
                        maxHeap.Add(temp[i]);
                    }
                }

                // yic for the last round, no need to add gap.
                if (maxHeap.Count > 0)
                {
                    ans += gap;
                }

            }

            return ans;
        }

        public class CharFreq
        {
            public char c;
            public int freq;

            public CharFreq(char c, int freq)
            {
                this.c = c;
                this.freq = freq;
            }


        }

        public class CharFreqComparer : IComparer<CharFreq>
        {
            public int Compare(CharFreq x, CharFreq y)
            {
                if (x.freq != y.freq)
                {
                    return y.freq.CompareTo(x.freq);
                }

                return x.c.CompareTo(y.c);
            }
        }
    }
}
