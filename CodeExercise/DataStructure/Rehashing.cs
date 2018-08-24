using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class Rehashing
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

        /// <summary>
        /// 129. Rehashing
        /// https://www.lintcode.com/problem/rehashing/description
        /// The size of the hash table is not determinate at the very beginning.If the total size of keys is too large (e.g.size >= capacity / 10), we should double the size of the hash table and rehash every keys.Say you have a hash table looks like below:
        /// 
        /// size=3, capacity=4
        /// 
        /// [null, 21, 14, null]
        ///        ↓    ↓
        ///        9   null
        ///        ↓
        ///       null
        /// The hash function is:
        /// 
        /// int hashcode(int key, int capacity)
        /// {
        ///     return key % capacity;
        /// }
        /// C++/Java: if you directly calculate -4 % 3 you will get -1. You can use function: a % b = (a % b + b) % b to make it is a non negative integer.
        /// </summary>
        /// <param name="hashTable"></param>
        /// <returns></returns>
        public ListNode[] RehashingSolver(ListNode[] hashTable)
        {
            int count = hashTable.Count();
            int newSize = 2 * count;
            ListNode[] doubleHash = new ListNode[newSize];

            for(int i = 0; i < hashTable.Length; i++)
            {
                ListNode node = hashTable[i];

                while(node!= null)
                {
                    int idx = (node.val % newSize + newSize) % newSize;    // -7 % 3 = -1   (-1+3)%3 = 2
                    if (doubleHash[idx] == null)
                    {
                        doubleHash[idx] = new ListNode(node.val);
                    }
                    else
                    {
                        var temp = doubleHash[idx];
                        while (temp.next != null)
                        {
                            temp = temp.next;
                        }
                        temp.next = new ListNode(node.val);
                    }

                    node = node.next;
                }

                
            }

            return doubleHash;
        }
    }
}
