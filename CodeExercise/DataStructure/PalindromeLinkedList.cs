using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class PalindromeLinkedList
    {
        /// <summary>
        /// https://leetcode.com/problems/palindrome-linked-list/description/
        /// Given a singly linked list, determine if it is a palindrome.
        /// 
        /// Example 1:
        /// 
        /// Input: 1->2
        /// Output: false
        /// Example 2:
        /// 
        /// Input: 1->2->2->1
        /// Output: true
        /// Follow up:
        /// Could you do it in O(n) time and O(1) space?
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {

            if (head == null)
            {
                return true;
            }

            ListNode slow = head;
            ListNode fast = head;

            // (1) find mid
            //  1 -> 2 ->  3        slow at 2
            //  1 ->  2 ->  3  -> 4    slow at 2
            while (fast != null && fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // (2) break LL and reverse 2nd half    can be even or odd. but we only need to check matched
            ListNode SecondHalf = slow.next;
            slow.next = null;
            ListNode Tail = Reverse(SecondHalf);

            // compare the two,  first is equal or 1 more node
            ListNode FirstHalf = head;
            while (FirstHalf != null && Tail != null)
            {
                if (FirstHalf.val != Tail.val)
                {
                    return false;
                }
                FirstHalf = FirstHalf.next;
                Tail = Tail.next;
            }

            return true;

        }

        private ListNode Reverse(ListNode head)
        {
            // single list case
            if (head == null)
            {
                return null;
            }

            ListNode pre = null;
            ListNode curr = head;


            while (curr != null)
            {
                ListNode nxt = curr.next;

                curr.next = pre;
                pre = curr;
                curr = nxt;
            }

            // tail
            return pre;
        }
    }
}
