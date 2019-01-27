using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.LL
{
    class SwapNodesPairs
    {
        /// <summary>
        /// 24. Swap Nodes in Pairs
        /// https://leetcode.com/problems/swap-nodes-in-pairs/
        /// 
        /// Given a linked list, swap every two adjacent nodes and return its head.
        /// 
        /// Example:
        /// 
        /// Given 1->2->3->4, you should return the list as 2->1->4->3.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {

            var dummyHead = new ListNode(-1);

            var pre = dummyHead;

            var curr = head;

            //-1 > 1 > 2 > 3
            // p   c
            //     f   s    n
            while (curr != null && curr.next != null)
            {
                var nextStart = curr.next.next;
                var first = curr;
                var sec = curr.next;

                pre.next = sec;
                sec.next = first;
                first.next = nextStart;

                curr = nextStart;
                pre = first;

            }

            pre.next = curr;

            return dummyHead.next;

        }
    }
}
