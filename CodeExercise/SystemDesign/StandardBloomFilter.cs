using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CodeExercise.SystemDesign
{
    class BloomHash
    {
        private int seed;

        private int capacity;

        public BloomHash(int seed, int cap)
        {
            this.seed = seed;
            this.capacity = cap;
        }

        public int GetHash(string str)
        {
            int raw = 0;
            foreach(char c in str)
            {
                int test = c + seed;
                raw = (raw * seed) + (c + seed);
            }

            return raw % capacity;
        }
    }

    /// <summary>
    /// 556. Standard Bloom Filter 
    /// http://www.lintcode.com/en/problem/standard-bloom-filter/
    /// 
    /// Implement a standard bloom filter. Support the following method:
    /// 1. StandardBloomFilter(k),The constructor and you need to create k hash functions.
    /// 2. add(string). add a string into bloom filter.
    /// 3. contains(string). Check a string whether exists in bloom filter.
    /// 
    /// StandardBloomFilter(3)
    /// add("lint")
    /// add("code")
    /// contains("lint") // return true
    /// contains("world") // return false
    /// </summary>
    class StandardBloomFilter
    {
        List<BloomHash> hashCollection;
        BitArray bits;
        public StandardBloomFilter(int k)
        {
            hashCollection = new List<BloomHash>();
            for (int i =0; i <k; i++)
            {
                hashCollection.Add(new BloomHash(i*3+7, 10000));  // yic i+1  becase we don't want seed = 0 and multiply seed get 0 for all
            }

            bits = new BitArray(10000);
            bits.SetAll(false);
        }

        /*
         * @param word: A string
         * @return: nothing
         */
        public void add(String word)
        {
            foreach(char c in word)
            {
                foreach(var bloomHash in hashCollection)
                {
                    int hash = bloomHash.GetHash(word);
                    bits.Set(hash, true);
                }
            }
        }

        /*
         * @param word: A string
         * @return: True if contains word
         */
        public bool contains(String word)
        {
            foreach(var bloomHash in hashCollection)
            {
                int hash = bloomHash.GetHash(word);
                if (!bits.Get(hash))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
