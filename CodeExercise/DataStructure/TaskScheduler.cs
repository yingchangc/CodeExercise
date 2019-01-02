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
        public int LeastInterval(char[] tasks, int n)
        {
            var pq = new SortedSet<Item>(new ItemComparer());
            Dictionary<char, int> lookup = new Dictionary<char, int>();
            int taskLeft = 0;
            foreach (var c in tasks)
            {
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, 0);
                }
                lookup[c]++;
                taskLeft++;
            }

            // insert to PQ
            foreach (char c in lookup.Keys)
            {
                pq.Add(new Item(c, lookup[c]));
            }

            int ans = 0;
            while (taskLeft > 1)
            {
                HashSet<Item> temp = new HashSet<Item>();  // temp collect pop item
                for (int i = 0; i <= n; i++)  // <= n    
                {
                    if (pq.Count > 0)
                    {
                        var top = pq.First();
                        pq.Remove(top);
                        //Console.WriteLine("{0}:{1}", top.c, top.freq);
                        ans++;
                        top.freq--;
                        temp.Add(top);
                        taskLeft--;

                    }
                    else
                    {
                        if (taskLeft > 0)
                        {
                            // don't have inventory. just add idle
                            ans++;
                        }

                    }

                }
                //Console.WriteLine("----------------------");

                // put back
                foreach (var itm in temp)
                {
                    if (itm.freq > 0)
                    {
                        pq.Add(itm);
                    }
                }
            }

            if (taskLeft == 1)
            {
                // just add the last;
                ans++;
            }

            return ans;

        }

        public class Item
        {
            public char c;
            public int freq;

            public Item(char c, int freq)
            {
                this.c = c;
                this.freq = freq;
            }
        }

        public class ItemComparer : IComparer<Item>
        {
            public int Compare(Item i1, Item i2)
            {
                if (i1.freq != i2.freq)
                {
                    return i2.freq.CompareTo(i1.freq);
                }

                return i1.c.CompareTo(i2.c);
            }
        }
    }
}
