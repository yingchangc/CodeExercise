using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    public class ListNode
    {
       public int val;
       public ListNode next;
       public ListNode(int x)
       {
            val = x;
            next = null;
       }
   }

    public class Record
    {
        public int id, score;
        public Record(int id, int score)
        {
            this.id = id;
            this.score = score;
        }

    }

    class LinkedListCycleII
    {
        /// <summary>
        /// 142
        /// https://leetcode.com/problems/linked-list-cycle-ii/description/
        /// Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
        /// ref https://cs.stackexchange.com/questions/10360/floyds-cycle-detection-algorithm-determining-the-starting-point-of-cycle
        /// Note: Do not modify the linked list.
        /// 
        /// sol
        /// phase 1
        /// Distance travelled by slowPointer before meeting =x+y
        /// Distance travelled by fastPointer before meeting = (x + y + z) + y = x + 2y + z
        /// 
        /// phase2
        /// Since fastPointer travels with double the speed of slowPointer, and time is constant for both when the reach the meeting point. So by using simple speed, time and distance relation (slowPointer traveled half the distance):

        /// 2∗dist(slowPointer)2(x+y) = dist(fastPointer)    
        /// 2(x+y) = x + 2y + z    => 2x = x+z     => x=z
        /// 
        /// so just walk from beginnng and slow point, when meet, it is start cycle point
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode slow = head;
            ListNode fast = head;

            //phase 1 find meet point
            while (fast != null && fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    break;
                }
            }

            if (fast == null || fast.next == null || fast.next.next == null)
            {
                return null;
            }

            // phase 2
            ListNode start = head;
            while (start != slow)
            {
                start = start.next;
                slow = slow.next;
            }

            return start;
        }
    }
}
