using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.LL
{
    class ReverseKLL
    {
        /// <summary>
        /// 25. Reverse Nodes in k-Group
        /// https://leetcode.com/problems/reverse-nodes-in-k-group/
        /// Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
        /// 
        /// k is a positive integer and is less than or equal to the length of the linked list.If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.
        /// 
        /// Example:
        /// 
        /// Given this linked list: 1->2->3->4->5
        /// 
        /// For k = 2, you should return: 2->1->4->3->5
        /// 
        /// For k = 3, you should return: 3->2->1->4->5
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode dummyHead = new ListNode(-1);   // dummy
            dummyHead.next = head;

            ListNode n1 = head;
            ListNode n2 = head;
            ListNode pre = dummyHead;

            int i = 0;


            while (n2 != null)
            {
                i++;
                if (i % k == 0)
                {
                    ListNode nextSegStart = n2.next;
                    ListNode segmentHead = ReverseK(n1, nextSegStart);
                    pre.next = segmentHead;
                    pre = n1;
                    n2 = nextSegStart;
                    n1 = nextSegStart;
                }
                else
                {
                    n2 = n2.next;
                    
                }
                
            }

            return dummyHead.next;
        }

        private ListNode  ReverseK(ListNode node, ListNode next)
        {
            ListNode n1 = next;
            ListNode n2 = node;
            ListNode n3 = node.next;

            while (n2.next != next)
            {
                n2.next = n1;
                n1 = n2;
                n2 = n3;
                n3 = n2.next;

            }

            n2.next = n1;

            return n2;
        }
    }
}
