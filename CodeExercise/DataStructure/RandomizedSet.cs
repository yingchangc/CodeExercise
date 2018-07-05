using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// https://www.lintcode.com/problem/insert-delete-getrandom-o1/description
    /// 380. Insert Delete GetRandom O(1)
    /// Design a data structure that supports all following operations in average O(1) time.
    ///insert(val): Inserts an item val to the set if not already present.
    ///remove(val): Removes an item val from the set if present.
    ///getRandom: Returns a random element from current set of elements.Each element must have the same probability of being returned.
    ///Example
    ///// Init an empty set.
    ///RandomizedSet randomSet = new RandomizedSet();
    ///
    ///// Inserts 1 to the set. Returns true as 1 was inserted successfully.
    ///randomSet.insert(1);
    ///
    ///// Returns false as 2 does not exist in the set.
    ///randomSet.remove(2);
    ///
    ///// Inserts 2 to the set, returns true. Set now contains [1,2].
    ///randomSet.insert(2);
    ///
    ///// getRandom should return either 1 or 2 randomly.
    ///randomSet.getRandom();
    ///
    ///// Removes 1 from the set, returns true. Set now contains [2].
    ///randomSet.remove(1);
    ///
    ///// 2 was already in the set, so return false.
    ///randomSet.insert(2);
    ///
    ///// Since 2 is the only number in the set, getRandom always return 2.
    ///randomSet.getRandom();
    /// </summary>
    class RandomizedSet
    {
        Dictionary<int, int> lookup; // (val, index)
        List<int> arr;
        Random rd;

        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            lookup = new Dictionary<int, int>();
            arr = new List<int>();
            rd = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (!lookup.ContainsKey(val))
            {
                int index = arr.Count;
                lookup.Add(val, index);
                arr.Add(val);
                return true;
            }

            return false;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        /// move the last item to the removed val index location to make a O(1) operation
        public bool Remove(int val)
        {
            if (!lookup.ContainsKey(val))
            {
                return false;
            }

            int index = lookup[val];

            // (1) remove from lookup
            lookup.Remove(val);

            // (2) remove from array. 
            // (2-1) the last item case
            if (arr.Count-1 == index)
            {
                arr.RemoveAt(arr.Count - 1);
            }
            else
            {
                // (2-2) swap last item with removed one
                int last = arr[arr.Count - 1];
                arr.RemoveAt(arr.Count - 1);
                arr[index] = last;
                lookup[last] = index;  // update last new index loc
            }

            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            if (arr.Count == 0)
            {
                throw new Exception();
            }

            

            int loc = rd.Next(arr.Count);

            return arr[loc];
        }
    }
}
