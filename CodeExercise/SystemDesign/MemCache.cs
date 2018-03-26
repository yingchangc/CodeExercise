﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
        /// <summary>
        /// 538
        /// http://www.lintcode.com/en/problem/memcache/
        /// 
        /// Implement a memcache which support the following features:

        /// get(curtTime, key). Get the key's value, return 2147483647 if key does not exist.
        /// set(curtTime, key, value, ttl). Set the key-value pair in memcache with a time to live(ttl). The key will be valid from curtTime to curtTime + ttl - 1 and it will be expired after ttl seconds. if ttl is 0, the key lives forever until out of memory.
        /// delete(curtTime, key). Delete the key.
        /// incr(curtTime, key, delta). Increase the key's value by delta return the new value. Return 2147483647 if key does not exist.
        /// decr(curtTime, key, delta). Decrease the key's value by delta return the new value. Return 2147483647 if key does not exist.
        /// It's guaranteed that the input is given with increasingcurtTime.
        /// 
        /// 
        /// Clarification
        //  Actually, a real memcache server will evict keys if memory is not sufficient, and it also supports variety of value types like string and integer.In our case, let's make it simple, we can assume that we have enough memory and all of the values are integers.
        //  
        //  Search "LRU" & "LFU" on google to get more information about how memcache evict data.
        //  
        //  Try the following problem to learn LRU cache:
        //  http://www.lintcode.com/problem/lru-cache
        //  
        //  Example
        //  get(1, 0)
        //  >> 2147483647
        //  set(2, 1, 1, 2)
        //  get(3, 1)
        //  >> 1
        //  get(4, 1)
        //  >> 2147483647
        //  incr(5, 1, 1)
        //  >> 2147483647
        //  set(6, 1, 3, 0)
        //  incr(7, 1, 1)
        //  >> 4
        //  decr(8, 1, 1)
        //  >> 3
        //  get(9, 1)
        //  >> 3
        //  delete(10, 1)
        //  get(11, 1)
        //  >> 2147483647
        //  incr(12, 1, 1)
        //  >> 2147483647
        /// </summary>
        public class Memcache
        {
            private Dictionary<int, Resource> dict;
            public Memcache()
            {
                dict = new Dictionary<int, Resource>();
            }

            /*
             * @param curtTime: An integer
             * @param key: An integer
             * @return: An integer
             */
            public int get(int curtTime, int key)
            {
                if (!dict.ContainsKey(key))
                {
                    return Int32.MaxValue;
                }

                // 0 don't evict
                if (dict[key].expireTime == 0 || (curtTime < dict[key].expireTime))
                {
                    return dict[key].value;
                }

                dict.Remove(key);

                return Int32.MaxValue;
            }

            /*
             * @param curtTime: An integer
             * @param key: An integer
             * @param value: An integer
             * @param ttl: An integer
             * @return: nothing
             */
            public void set(int curtTime, int key, int value, int ttl)
            {
                int expireTime = (ttl == 0) ? 0 : curtTime + ttl;
                if (dict.ContainsKey(key))
                {
                    dict[key].expireTime = expireTime;
                    return;
                }

                dict.Add(key, new Resource(value, expireTime));
            }

            /*
             * @param curtTime: An integer
             * @param key: An integer
             * @return: nothing
             */
            public void delete(int curtTime, int key)
            {
                if (dict.ContainsKey(key))
                {
                    dict.Remove(key);
                }
            }

            /*
             * @param curtTime: An integer
             * @param key: An integer
             * @param delta: An integer
             * @return: An integer
             */
            public int incr(int curtTime, int key, int delta)
            {
                if (dict.ContainsKey(key))
                {
                    if (dict[key].expireTime == 0 || dict[key].expireTime > curtTime)  // yic note for expireTime =0, live forever
                    {
                        dict[key].value += delta;

                        return dict[key].value;
                    }
                    else
                    {
                        dict.Remove(key);
                    }
                }

                return Int32.MaxValue;
            }

            /*
             * @param curtTime: An integer
             * @param key: An integer
             * @param delta: An integer
             * @return: An integer
             */
            public int decr(int curtTime, int key, int delta)
            {
                if (dict.ContainsKey(key))
                {
                    if (dict[key].expireTime == 0 || dict[key].expireTime > curtTime)
                    {
                        dict[key].value -= delta;

                        return dict[key].value;
                    }
                    else
                    {
                        dict.Remove(key);
                    }
                }

                return Int32.MaxValue;
            }
        }

        class Resource
        {
            public int value { get; set; }

            public int expireTime { get; set; }

            public Resource(int v, int time)
            {
                value = v;
                expireTime = time;
            }
        }
}
