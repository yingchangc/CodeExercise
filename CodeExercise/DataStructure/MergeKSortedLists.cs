using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    // java 
//    public class Solution
//    {
//        private Comparator<ListNode> ListNodeComparator = new Comparator<ListNode>()
//        {
//        public int compare(ListNode left, ListNode right)
//        {
//            return left.val - right.val;
//        }
//    };

//    public ListNode mergeKLists(List<ListNode> lists)
//    {
//        if (lists == null || lists.size() == 0)
//        {
//            return null;
//        }

//        Queue<ListNode> heap = new PriorityQueue<ListNode>(lists.size(), ListNodeComparator);
//        for (int i = 0; i < lists.size(); i++)
//        {
//            if (lists.get(i) != null)
//            {
//                heap.add(lists.get(i));
//            }
//        }

//        ListNode dummy = new ListNode(0);
//        ListNode tail = dummy;
//        while (!heap.isEmpty())
//        {
//            ListNode head = heap.poll();
//            tail.next = head;
//            tail = head;
//            if (head.next != null)
//            {
//                heap.add(head.next);
//            }
//        }
//        return dummy.next;
//    }
//}



class MergeKSortedLists
    {

        //https://www.jiuzhang.com/solution/merge-k-sorted-lists/
        /// <summary>
        /// use merge sort concept that merge 2 out of k lists each time
        /// 
        /// logK level, each level, each element will only touch once. N total
        /// 
        /// O(Nlogk)
        /// 
        /// 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists_MergeSort(ListNode[] lists)
        {
            int k = lists.Length;
            var ans = MergeSortHelper(lists, 0, k - 1);

            return ans;
        }

        private ListNode MergeSortHelper(ListNode[] lists, int start, int last)
        {
            if (start >= last)
            {
                return lists[start];
            }

            int mid = start + (last - start) / 2;
            ListNode leftHalf = MergeSortHelper(lists, start, mid);
            ListNode rightHallf = MergeSortHelper(lists, mid+1, last);

            ListNode dummyHead = new ListNode(0);
            ListNode temp = dummyHead;

            while (leftHalf != null && rightHallf != null)
            {
                if (leftHalf.val <= rightHallf.val)
                {
                    temp.next = leftHalf;
                    leftHalf = leftHalf.next;
                }
                else
                {
                    temp.next = rightHallf;
                    rightHallf = rightHallf.next;
                }

                // yic
                temp = temp.next;
            }

            if (leftHalf != null)
            {
                temp.next = leftHalf;
            }
            
            if (rightHallf != null)
            {
                temp.next = rightHallf;
            }

            return dummyHead.next;
        }



        class NodeListComparer : IComparer<ListNode>
        {
            public int Compare(ListNode x, ListNode y)
            {
                return x.val.CompareTo(y.val);
            }
        }




        /// <summary>
        /// 23. Merge k Sorted Lists
        /// https://leetcode.com/problems/merge-k-sorted-lists/description/
        /// Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
        /// Example:
        /// 
        /// Input:
        /// [
        ///   1->4->5,
        ///   1->3->4,
        ///   2->6
        /// ]
        /// Output: 1->1->2->3->4->4->5->6
        /// 
        /// Sol see how java PQ works on top
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            int num = lists.Length;

            if (num == 0)
            {
                return null;
            }

            // node,count
            SortedDictionary<ListNode, List<int>> PQ = new SortedDictionary<ListNode, List<int>>(new NodeListComparer());
            
            // insert first item to pq
            for (int i = 0; i < num; i++)
            {
                var node = lists[i];

                // yic for [[]] input
                if (node == null)
                {
                    continue;
                }

                if (!PQ.ContainsKey(node))
                {
                    PQ[node] = new List<int>();
                }
                PQ[node].Add(i);
                lists[i] = lists[i].next;
            }

            ListNode head = new ListNode(0);  // dummy first node
            ListNode temp = head;

            
            while(PQ.Count > 0)
            {
                // pop top and insert next
                var node = PQ.Keys.First();
                var idxs = PQ[node];          // get which list

                temp.next = new ListNode(node.val);
                temp = temp.next;

                // in case same val exists in diff ListNode
                var idx = idxs[0];
                idxs.RemoveAt(0);

                // pop from PQ
                if (idxs.Count == 0)
                {
                    PQ.Remove(node);
                }

                // insert next node to pq
                if (lists[idx] != null)
                {
                    var newnode = lists[idx];

                    if (!PQ.ContainsKey(newnode))
                    {
                        PQ.Add(newnode, new List<int>());
                    }

                    PQ[newnode].Add(idx);
                    lists[idx] = lists[idx].next;
                }
            }

            return head.next;
        }
    }
}
