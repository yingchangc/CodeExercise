using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TopologicalSort
{
    class CourseSchedule
    {
        /// <summary>
        /// 210. Course Schedule II
        /// https://leetcode.com/problems/course-schedule-ii/description/
        /// There are a total of n courses you have to take, labeled from 0 to n-1.

        /// Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
        /// 
        /// Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.
        /// 
        /// There may be multiple correct orders, you just need to return one of them.If it is impossible to finish all courses, return an empty array.
        /// 
        /// Example 1:
        /// 
        /// Input: 2, [[1,0]] 
        /// Output: [0,1]
        ///         Explanation: There are a total of 2 courses to take.To take course 1 you should have finished
        ///              course 0. So the correct course order is [0,1] .
        /// Example 2:
        /// 
        /// Input: 4, [[1,0],[2,0],[3,1],[3,2]]
        /// Output: [0,1,2,3]
        ///         or[0, 2, 1, 3]
        /// Explanation: There are a total of 4 courses to take.To take course 3 you should have finished both
        ///             courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0. 
        ///              So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3] .
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            // (1) get inBound and edge
            Dictionary<int, int> inbound = new Dictionary<int, int>();
            Dictionary<int, List<int>> childLookup = new Dictionary<int, List<int>>();

            int edges = prerequisites.GetLength(0);
            for(int i = 0; i < edges; i++)
            {
                int curr = prerequisites[i, 0];
                int pre = prerequisites[i, 1];

                if (!inbound.ContainsKey(curr))
                {
                    inbound.Add(curr, 0);
                }
                inbound[curr]++;

                if (!childLookup.ContainsKey(pre))
                {
                    childLookup.Add(pre, new List<int>());
                }
                childLookup[pre].Add(curr);
            }

            // (2) add 0 inbound to answer list 
            Queue<int> queue = new Queue<int>();

            List<int> ans = new List<int>();

            for (int i = 0; i < numCourses; i++)
            {
                if (!inbound.ContainsKey(i))
                {
                    ans.Add(i);
                    queue.Enqueue(i);
                }
            }

            //(3) traverse to child from 0 inbound node
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();

                // yic need to check  for last node case it is not in the lookup
                if (childLookup.ContainsKey(curr))
                {
                    var children = childLookup[curr];
                    foreach(var child in children)
                    {
                        inbound[child]--;

                        if (inbound[child] == 0)
                        {
                            ans.Add(child);
                            queue.Enqueue(child);
                        }
                    }
                }
            }


            // yic need to confirm no cycle first.
            if (ans.Count != numCourses)
            {
                ans.Clear();
            }


            return ans.ToArray();
        }


        /// <summary>
        /// 207. Course Schedule
        /// https://leetcode.com/problems/course-schedule/description/
        /// There are a total of n courses you have to take, labeled from 0 to n-1.

        /// Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
        /// 
        /// Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
        /// 
        /// Example 1:
        /// 
        /// Input: 2, [[1,0]] 
        /// Output: true
        /// Explanation: There are a total of 2 courses to take.
        ///              To take course 1 you should have finished course 0. So it is possible.
        /// Example 2:
        /// 
        /// Input: 2, [[1,0],[0,1]]
        /// Output: false
        /// Explanation: There are a total of 2 courses to take.
        ///      To take course 1 you should have finished course 0, and to take course 0 you should
        ///      also have finished course 1. So it is impossible.
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            // (1) compute the inbound count and build child graph
            Dictionary<int, int> inLookup = new Dictionary<int, int>();   // node , inbound count
            Dictionary<int, List<int>> childLookup = new Dictionary<int, List<int>>();   // parent-> children
            int edges = prerequisites.GetLength(0);
            
            for (int i =0; i < edges; i++)
            {
                int curr = prerequisites[i, 0];   //ex 1
                int pre = prerequisites[i, 1];    //ex 0

                // update inbund count
                if (!inLookup.ContainsKey(curr))
                {
                    inLookup[curr] = 0;
                }
                inLookup[curr]++;  // cuz pre point to curr

                // update child lookup
                if (!childLookup.ContainsKey(pre))
                {
                    childLookup.Add(pre, new List<int>());
                }
                childLookup[pre].Add(curr);
            }

            

            // (2) put no inbound to queue and add to finish count
            Queue<int> queue = new Queue<int>();

            for(int i = 0; i < numCourses; i++)
            {
                if (!inLookup.ContainsKey(i))
                {
                    queue.Enqueue(i);  // enqueue no inbound cource {0}
                }
            }

            // (3) traverse to next course
            int finishCount = 0;
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();  // 0  root
                finishCount++;
                if (childLookup.ContainsKey(curr))   // yic  prevent the last node  no child exception
                {
                    var ListNextCourses = childLookup[curr];
                    foreach (int nxt in ListNextCourses)
                    {
                        inLookup[nxt]--;

                        // new root node found
                        if (inLookup[nxt] == 0)
                        {
                            queue.Enqueue(nxt);  // only no pre can insert to queue
                        }
                    }
                }
            }

            return finishCount == numCourses;

        }
    }
}
