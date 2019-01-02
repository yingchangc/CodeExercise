using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.LL
{
    class RemoveNthNodeFromEndList
    {
        /// <summary>
        /// 19. Remove Nth Node From End of List
        /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        /// Given a linked list, remove the n-th node from the end of list and return its head.
        /// 
        /// Example:
        /// 
        /// Given linked list: 1->2->3->4->5, and n = 2.
        /// 
        /// After removing the second node from the end, the linked list becomes 1->2->3->5.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null)
            {
                return null;
            }

            ListNode pf = head;
            ListNode curr = head;
            ListNode pre = null;

            for (int i = 0; i < n; i++)
            {
                pf = pf.next;
            }

            while (pf != null)
            {
                pre = curr;
                pf = pf.next;
                curr = curr.next;
            }

            ListNode next = curr.next;

            if (pre == null)
            {
                // remove head case
                return next;
            }
            else
            {
                pre.next = next; ;
                return head;
            }
        }
    }
}
