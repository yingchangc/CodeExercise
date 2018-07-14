using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MergeTwoSortedLists
    {
        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// https://leetcode.com/problems/merge-two-sorted-lists/description/
        /// Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
        /// 
        /// Example:
        /// 
        /// Input: 1->2->4, 1->3->4
        /// Output: 1->1->2->3->4->4
        /// 
        /// sol
        /// Time complexity : O(n + m)O(n+m)
        /// 
        /// Because exactly one of l1 and l2 is incremented on each loop iteration, the while loop runs for a number of iterations equal to the sum of the lengths of the two lists.All other work is constant, so the overall complexity is linear.
        /// 
        /// Space complexity : O(1)O(1)
        /// 
        /// The iterative approach only allocates a few pointers, so it has a constant overall memory footprint.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(0);
            ListNode temp = head;

            while (l1 !=null && l2!=null)
            {
                if (l1.val <= l2.val)
                {
                    temp.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    temp.next = l2;
                    l2 = l2.next;
                }

                temp = temp.next;    // yic: need to move temp forward
            }

            if(l1!=null)
            {
                temp.next = l1;
            }
            
            if (l2!=null)
            {
                temp.next = l2;
            }

            return head.next;
        }
    }
}
