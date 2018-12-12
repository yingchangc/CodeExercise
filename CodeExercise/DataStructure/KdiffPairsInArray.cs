using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class KdiffPairsInArray
    {
        /// <summary>
        /// 532. K-diff Pairs in an Array
        /// https://leetcode.com/problems/k-diff-pairs-in-an-array/
        /// Given an array of integers and an integer k, you need to find the number of unique k-diff pairs in the array. Here a k-diff pair is defined as an integer pair (i, j), where i and j are both numbers in the array and their absolute difference is k.
        /// 
        /// Example 1:
        /// Input: [3, 1, 4, 1, 5], k = 2
        /// Output: 2
        /// Explanation: There are two 2-diff pairs in the array, (1, 3) and(3, 5).
        /// Although we have two 1s in the input, we should only return the number of unique pairs.
        /// Example 2:
        /// Input:[1, 2, 3, 4, 5], k = 1
        /// Output: 4
        /// Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and(4, 5).
        /// Example 3:
        /// Input: [1, 3, 1, 5, 4], k = 0
        /// Output: 1
        /// Explanation: There is one 0-diff pair in the array, (1, 1).
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindPairs(int[] nums, int k)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!lookup.ContainsKey(num))
                {
                    lookup.Add(num, 0);
                }
                lookup[num]++;
            }

            int count = 0;
            foreach (var num in lookup.Keys)   // unique key
            {
                if (lookup.ContainsKey(num + k))
                {
                    if (k == 0)
                    {
                        if (lookup[num + k] > 1)
                        {
                            count++;     //  1 1   k = 0
                        }

                    }
                    else if (k > 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
