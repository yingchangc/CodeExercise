using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.LL
{
    /// <summary>
    /// 86. Partition List
    /// https://leetcode.com/problems/partition-list/
    /// Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
    /// 
    /// You should preserve the original relative order of the nodes in each of the two partitions.
    /// 
    /// Example:
    /// 
    /// Input: head = 1->4->3->2->5->2, x = 3
    /// Output: 1->2->2->4->3->5
    /// 
    /// use SmallHead SamllTemp, BigHead BigTemp  to walk through each node
    /// 
    /// </summary>
    class PartitionList
    {
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null)
            {
                return null;
            }

            ListNode SH = null;
            ListNode ST = null;  // small temp
            ListNode BH = null;
            ListNode BT = null;  // big temp

            ListNode curr = head;

            while (curr != null)
            {
                if (curr.val < x)
                {
                    if (SH == null)
                    {
                        SH = curr;
                        ST = curr;
                    }
                    else
                    {
                        ST.next = curr;
                        ST = curr;
                    }
                }
                else
                {
                    if (BH == null)
                    {
                        BH = curr;
                        BT = curr;
                    }
                    else
                    {
                        BT.next = curr;
                        BT = curr;
                    }
                }

                curr = curr.next;

            }

            // [1] 0 case
            if (ST == null)
            {
                return BH;
            }

            if (BH != null)
            {
                ST.next = BH;

                BT.next = null;
            }


            return SH;
        }
    }
}
