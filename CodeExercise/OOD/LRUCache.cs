using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.OOD
{
    /// <summary>
    /// 146 LRU cache
    /// https://leetcode.com/problems/lru-cache/description/
    /// 
    /// Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.
    /// get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    ///put(key, value) - Set or insert the value if the key is not already present.When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.
    /// 
    ///ex
    ///LRUCache cache = new LRUCache(2 /* capacity */ );
    ///
    ///cache.put(1, 1);
    ///cache.put(2, 2);
    ///cache.get(1);       // returns 1
    ///cache.put(3, 3);    // evicts key 2
    ///cache.get(2);       // returns -1 (not found)
    ///cache.put(4, 4);    // evicts key 1
    ///cache.get(1);       // returns -1 (not found)
    ///cache.get(3);       // returns 3
    ///cache.get(4);       // returns 4

    /// </summary>
    class LRUCache
    {
        private CacheNode head;
        private CacheNode tail;
        private Dictionary<int, CacheNode> lookup;
        private int capacity;

        public LRUCache(int capacity)
        {
            if (capacity == 0)
            {
                throw new Exception("capacity cannot be 0");
            }

            lookup = new Dictionary<int, CacheNode>();
 
            this.capacity = capacity;

            head = new CacheNode();
            tail = new CacheNode();
            head.next = tail;
            tail.pre = head;
        }

        public int Get(int key)
        {
            if(!lookup.ContainsKey(key))
            {
                return -1;
            }

            CacheNode n = lookup[key];

            detatch(n);
            attachToHead(n);

            return n.value;
        }

        public void Put(int key, int value)
        {
            if (lookup.ContainsKey(key))
            {
                CacheNode n = lookup[key];
                n.value = value;  // update new value

                detatch(n);
                attachToHead(n);
                return;
            }

            if (lookup.Count == this.capacity)   // already full
            {
                // yic : need to detach and update map
                CacheNode least = tail.pre;
                detatch(least);
                lookup.Remove(least.key);
            }

            CacheNode newNode = new CacheNode(key, value);
            lookup.Add(key, newNode);

            attachToHead(newNode);

        }

        private void detatch(CacheNode n)
        {
            CacheNode pre = n.pre;
            CacheNode next = n.next;

            pre.next = next;
            next.pre = pre;
        }

        private void attachToHead(CacheNode n)
        {
            CacheNode curr1st = head.next;
            head.next = n;

            n.pre = head;
            n.next = curr1st;

            curr1st.pre = n;
        }
    }

    class CacheNode
    {
        public int value;
        public int key;    // yic  need this for remove from lookup map.

        public CacheNode pre;
        public CacheNode next;

        public CacheNode()
        {
            value = -1;
            pre = null;
            next = null;
        }

        public CacheNode(int k, int v)
        {
            key =k;
            value = v;

            pre = null;
            next = null;
        }
    }
}
