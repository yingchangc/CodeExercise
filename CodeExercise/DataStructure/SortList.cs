using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class SortList
    {
        //148. Sort List
        public ListNode SortListSolver(ListNode head)
        {

            return Helper(head);
        }
    
        private ListNode Helper(ListNode node)
        {
            if (node == null)
            {
                return null;
            }
            // yic easy to get wrong   ex : only 1 node left, w/o it will cause stackoverflow
            else if (node.next == null)
            {
                return node;
            }
        
            ListNode fast = node;
            ListNode slow = node;
        
            while (fast != null && fast.next != null && fast.next.next !=null)
            {
                slow = slow.next;
                fast =fast.next.next;
            }
        
            var secondHalf = slow.next;
            slow.next = null;
            var firstHalf = node;
        
            Console.WriteLine(firstHalf.val);
        
            var sortedFirstHalf = Helper(firstHalf);
            var sortedSecondHalf = Helper(secondHalf);
        
            var dummyHead = new ListNode(-1);
            var curr = dummyHead;
        
            while(sortedFirstHalf != null && sortedSecondHalf!= null)
            {
                if (sortedFirstHalf.val <= sortedSecondHalf.val)
                {
                    curr.next = sortedFirstHalf;
                    curr = curr.next;
                    sortedFirstHalf = sortedFirstHalf.next;       
                }
                else
                {
                    curr.next = sortedSecondHalf;
                    curr = curr.next;
                    sortedSecondHalf = sortedSecondHalf.next;  
                }
            }
        
            if (sortedFirstHalf != null)
            {
                curr.next =sortedFirstHalf;
            }
            else 
            {
                curr.next =sortedSecondHalf;
            }
        
            return dummyHead.next;
        }
    }
}
