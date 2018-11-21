using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.LL
{
    class RemoveDuplicatesfromSortedList
    {
        /// <summary>
        /// 83. Remove Duplicates from Sorted List
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-list/description/
        /// Given a sorted linked list, delete all duplicates such that each element appear only once.
        /// 
        /// Example 1:
        /// 
        /// Input: 1->1->2
        /// Output: 1->2
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode dummy = new ListNode(head.val - 1);
            ListNode pre = dummy;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode left = curr;
                ListNode right = curr;

                // move right untill diff val
                while (right != null && left.val == right.val)
                {
                    right = right.next;
                }

                pre.next = left;
                pre = pre.next;

                curr = right;
            }

            pre.next = null;    // close   1-> 2    2

            return dummy.next;
        }

        /// <summary>
        /// 82. Remove Duplicates from Sorted List II
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/description/
        /// Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.
        /// 
        /// Example 1:
        /// 
        /// Input: 1->2->3->3->4->4->5
        /// Output: 1->2->5
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates2(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode dummy = new ListNode(head.val - 1);

            ListNode pre = dummy;
            ListNode curr = head;

            while (curr != null)
            {
                int sameCount = 0;
                ListNode left = curr;
                ListNode right = curr;

                while (right != null && left.val == right.val)
                {
                    right = right.next;
                    sameCount++;
                }

                if (sameCount == 1)
                {
                    pre.next = curr;
                    pre = pre.next;
                }

                // move to diff val
                curr = right;
            }

            pre.next = null;   //yic :  close      ex  1,2,2      Inf -> 1     ------>set next null

            return dummy.next;
        }
    }
}
