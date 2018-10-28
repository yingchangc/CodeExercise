using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.OOD
{
    /// <summary>
    /// 460. LFU Cache
    /// https://leetcode.com/problems/lfu-cache/description/
    /// Design and implement a data structure for Least Frequently Used (LFU) cache. It should support the following operations: get and put.
    /// 
    /// get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    /// put(key, value) - Set or insert the value if the key is not already present.When the cache reaches its capacity, it should invalidate the least frequently used item before inserting a new item.For the purpose of this problem, when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted.
    /// 
    /// Follow up:
    /// Could you do both operations in O(1) time complexity?
    /// 
    /// Repace LinkedList with structure like LRU for O(1) lookup
    /// 
    /// Sol:
    /// 做法是维护一个有序序列（用链表来维护），每个链表的节点的key是 count，value是list of elements that has this count，也用linked list串起来。 比如 a出现2次，b出现3次，c出现2次，d出现1次。那么这个链表就是：

    /// {3: [b] } --> {2: [a ->c]} --> {1: [d]}
    /// 然后另外还需要一个hashmap，key是element，value是这个element在链表上的具体位置。
    /// 因为每一次的操作都是 count + 1和 count - 1，那么每次你通过 hashmap 找到对应的element在数据结构中的位置，+1的话，就是往头移动一格，-1的话，就是往尾巴移动一格
    /// 
    /// 
    /// [DataStructure]
    /// Node:  key,value, currFreq    so that when lookupNode, I know where the freq is to remove
    /// 
    /// NodeLookup (key, Node)
    /// FreqLookup (freq,  ListNodes)
    /// 
    /// 
    /// 
    /// the hard part is maintain where the MinFreq is,  when insert a new node, evit first and the new minFreq =1
    /// when update node,  remove node, and update value (freq, and value) and re-insert
    /// 
    /// </summary>
    class LFUCache
    {
        public class LFUNode
        {
            public int key;
            public int value;
            public int currFreq;
            public LFUNode(int key, int value)
            {
                this.key = key;
                this.value = value;
                this.currFreq = 1;
            }
        }

        Dictionary<int, LinkedList<LFUNode>> freqLookup;  // freq, ListNodes
        Dictionary<int, LFUNode> nodeLookup;  // key, node
        int CurrMinFreq = -1;
        int Capacity = 0;

        public LFUCache(int capacity)
        {
            freqLookup = new Dictionary<int, LinkedList<LFUNode>>();
            nodeLookup = new Dictionary<int, LFUNode>();
            this.Capacity = capacity;
        }

        public int Get(int key)
        {
            if (!nodeLookup.ContainsKey(key))
            {
                return -1;
            }

            var node = nodeLookup[key];

            Put(node.key, node.value);

            return node.value;

        }

        public void Put(int key, int value)
        {
            if (Capacity == 0)
            {
                return;
            }

            LFUNode currNode = null;
            if (!nodeLookup.ContainsKey(key))
            {
                // will add a new node
                if (nodeLookup.Count == Capacity)
                {
                    EvictLeastFreqNodeFromFreqList();
                }
                currNode = new LFUNode(key, value);
                nodeLookup.Add(key, currNode);

                if (!freqLookup.ContainsKey(1))
                {
                    freqLookup.Add(1, new LinkedList<LFUNode>());
                }

                var sameFreqNodesList = freqLookup[1];
                sameFreqNodesList.AddFirst(currNode);

                // [Important]
                CurrMinFreq = 1;
            }
            else
            {
                // case won't increase node count
                currNode = nodeLookup[key];
                Evict(currNode);

                //yic update freq and value
                currNode.currFreq++;
                currNode.value = value;

                Insert(currNode);

                if (freqLookup[CurrMinFreq].Count == 0)  // in case the currMinFreq list gone because of this operation
                {
                    CurrMinFreq = currNode.currFreq;
                }

            }
        }

        private void EvictLeastFreqNodeFromFreqList()
        {
            var nodeList = freqLookup[CurrMinFreq];
            var lruNode = nodeList.Last();  // get minFreq last node (lru strategy)
            Evict(lruNode);
        }

        private void Evict(LFUNode node)
        {
            // remove from freq list
            var nodesList = freqLookup[node.currFreq];
            nodesList.Remove(node);

            // remove from key-node lookup
            nodeLookup.Remove(node.key);
        }

        private void Insert(LFUNode node)
        {
            if (!freqLookup.ContainsKey(node.currFreq))
            {
                freqLookup.Add(node.currFreq, new LinkedList<LFUNode>());
            }
            // insert to freq list
            var nodesList = freqLookup[node.currFreq];
            nodesList.AddFirst(node);

            // insert to node lookup
            nodeLookup.Add(node.key, node);
        }
    }
}
