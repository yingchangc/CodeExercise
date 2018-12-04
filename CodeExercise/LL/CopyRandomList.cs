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

            Dictionary<RandomListNode, RandomListNode> lookup = new Dictionary<RandomListNode, RandomListNode>(); // orig copy

            var temp = head;

            // make new node lookup
            while (temp != null)
            {
                lookup.Add(temp, new RandomListNode(temp.label));
                temp = temp.next;
            }

            temp = head;

            while (temp != null)
            {
                var next = temp.next;
                var rnd = temp.random;

                if (next != null)
                {
                    lookup[temp].next = lookup[next];
                }

                if (rnd != null)
                {
                    lookup[temp].random = lookup[rnd];
                }


                temp = temp.next;
            }

            return lookup[head];
        }

    }
}
