using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    /// <summary>
    /// 520 lint
    /// Consistent Hashing II
    /// http://www.lintcode.com/en/problem/consistent-hashing-ii/
    /// 在 Consistent Hashing I 中我们介绍了一个比较简单的一致性哈希算法，这个简单的版本有两个缺陷：

    // 增加一台机器之后，数据全部从其中一台机器过来，这一台机器的读负载过大，对正常的服务会造成影响。
    // 当增加到3台机器的时候，每台服务器的负载量不均衡，为1:1:2。
    // 为了解决这个问题，引入了 micro-shards 的概念，一个更好的算法是这样：
    // 
    // 将 360° 的区间分得更细。从 0~359 变为一个 0 ~n-1 的区间，将这个区间首尾相接，连成一个圆。
    // 当加入一台新的机器的时候，随机选择在圆周中撒 k 个点，代表这台机器的 k 个 micro-shards。
    // 每个数据在圆周上也对应一个点，这个点通过一个 hash function 来计算。
    // 一个数据该属于那台机器负责管理，是按照该数据对应的圆周上的点在圆上顺时针碰到的第一个 micro-shard 点所属的机器来决定。
    // n 和 k在真实的 NoSQL 数据库中一般是 2^64 和 1000。
    // 
    // 请实现这种引入了 micro-shard 的 consistent hashing 的方法。主要实现如下的三个函数：
    // 
    // create(int n, int k)
    // addMachine(int machine_id) // add a new machine, return a list of shard ids.
    // getMachineIdByHashCode(int hashcode) // return machine id
    // 
    //     Example
    // create(100, 3)
    // addMachine(1)
    // >> [3, 41, 90]  => 三个随机数
    // getMachineIdByHashCode(4)
    // >> 1
    // addMachine(2)
    // >> [11, 55, 83]
    // getMachineIdByHashCode(61)
    // >> 2
    // getMachineIdByHashCode(91)
    // >> 1
    /// </summary>
    class ConsistentHashing2
    {
        SortedDictionary<int, int> hashMachineLookup;
        private int TotalHashCount { get; set; }

        private int virtualNode { get; set; }

        public ConsistentHashing2(int n, int k)
        {
            hashMachineLookup = new SortedDictionary<int, int>();
            TotalHashCount = n;
            virtualNode = k;
        }

        /*
         * @param machine_id: An integer
         * @return: a list of shard ids
         */
        public List<int> addMachine(int machine_id)
        {
            Random r = new Random();
            int nodeToAdd = virtualNode;
            List<int> shard_ids = new List<int>();
            while(nodeToAdd > 0)
            {
                int randomHash = r.Next() % TotalHashCount;
                if (hashMachineLookup.ContainsKey(randomHash))
                {
                    continue;
                }
                hashMachineLookup.Add(randomHash, machine_id);
                shard_ids.Add(randomHash);
                nodeToAdd--;
            }
            shard_ids.Sort();

            return shard_ids;
        }

        /*
         * @param hashcode: An integer
         * @return: A machine id
         */
        public int getMachineIdByHashCode(int hashcode)
        {           
            // corner case  bigger than last  or smaller than 1st
            if (hashcode > hashMachineLookup.Keys.Last() || hashcode < hashMachineLookup.Keys.First())
            {
                int shardID = hashMachineLookup.Keys.First();
                return hashMachineLookup[shardID];
            }
            else 
            {
                foreach(var shardID in hashMachineLookup.Keys)
                {
                    //clock wise just greater than
                    if (hashcode <= shardID)
                    {
                        return hashMachineLookup[shardID];
                    }
                }
            }


            // should not hit here
            return -1;
        }
    }
}
