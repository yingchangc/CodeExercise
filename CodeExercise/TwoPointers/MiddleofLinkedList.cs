using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class MiddleofLinkedList
    {
        /// <summary>
        /// 228. Middle of Linked List

        /// https://www.lintcode.com/problem/middle-of-linked-list/description
        /// Given 1->2->3, return the node with value 2.
        /// Given 1->2, return the node with value 1.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode middleNode(ListNode head)
        {
            var slow = head;
            var fast = head;

            while (fast!=null && fast.next !=null && fast.next.next!=null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }
    }
}
