using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.LL
{
    public class RandomListNode
    {
        public int label;
        public RandomListNode next, random;
        public RandomListNode(int x) { this.label = x; }
    };

    public class CopyRandomList
    {
        /// <summary>
        /// 138. Copy List with Random Pointer
        /// https://leetcode.com/problems/copy-list-with-random-pointer/description/
        /// 
        /// A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.
        ///Return a deep copy of the list.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public RandomListNode CopyRandomListSolver(RandomListNode head)
        {
            if (head == null)
            {
                return null;
            }

            Queue<RandomListNode> que = new Queue<RandomListNode>();
            Dictionary<RandomListNode, RandomListNode> lookup = new Dictionary<RandomListNode, RandomListNode>();

            que.Enqueue(head);

            var copy = new RandomListNode(head.label);
            lookup.Add(head, copy);

            while (que.Count > 0)
            {
                var curr = que.Dequeue();
                copy = lookup[curr];

                var next = curr.next;
                var rand = curr.random;

                // yic for each graph has reject null case, but we need to handle null next   
                if (next!=null && !lookup.ContainsKey(next))
                {
                    var copyNext = new RandomListNode(next.label);
                    lookup.Add(next, copyNext);
                    copy.next = copyNext;
                    que.Enqueue(next);     // yic enqueue next  (NOT copiedNext)
                }
                else if (next != null)
                {
                    copy.next = lookup[next];
                }


                if (rand != null && !lookup.ContainsKey(rand))
                {
                    var copyRand = new RandomListNode(rand.label);
                    lookup.Add(rand, copyRand);
                    copy.random = copyRand;
                    que.Enqueue(rand);
                }
                else if (rand!= null)
                {
                    copy.random = lookup[rand];
                }
            }

            return lookup[head];
        }

    }
}
