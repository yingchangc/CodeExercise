using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class FruitIntoBaskets
    {
        /// <summary>
        /// 904. Fruit Into Baskets
        /// https://leetcode.com/problems/fruit-into-baskets/
        /// You start at any tree of your choice, then repeatedly perform the following steps:
        /// 
        /// Add one piece of fruit from this tree to your baskets.If you cannot, stop.
        /// Move to the next tree to the right of the current tree.  If there is no tree to the right, stop.
        /// Note that you do not have any choice after the initial choice of starting tree: you must perform step 1, then step 2, then back to step 1, then step 2, and so on until you stop.
        /// 
        /// 
        /// You have two baskets, and each basket can carry any quantity of fruit, but you want each basket to only carry one type of fruit each.
        /// 
        /// What is the total amount of fruit you can collect with this procedure?
        /// 
        /// Sol: Find out the longest length of subarrays with at most 2 different numbers
        /// 
        /// Example 1:
        /// 
        /// Input: [1,2,1]
        /// Output: 3
        /// Explanation: We can collect[1, 2, 1].
        /// Example 2:
        /// 
        /// Input: [0,1,2,2]
        ///         Output: 3
        /// Explanation: We can collect[1, 2, 2].
        /// If we started at the first tree, we would only collect[0, 1].
        /// Example 3:
        /// 
        /// Input: [1,2,3,2,2]
        ///         Output: 4
        /// Explanation: We can collect[2, 3, 2, 2].
        /// If we started at the first tree, we would only collect[1, 2].
        /// Example 4:
        /// 
        /// Input: [3,3,3,1,2,1,1,2,3,3,4]
        ///         Output: 5
        /// Explanation: We can collect[1, 2, 1, 1, 2].
        /// If we started at the first tree or the eighth tree, we would only collect 4 fruits.
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public int TotalFruit(int[] tree)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();

            int len = tree.Length;
            int ans = 0;
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                while (j < len && (lookup.Keys.Count < 3))
                {
                    var fruitT = tree[j];
                    if (!lookup.ContainsKey(fruitT))
                    {
                        lookup.Add(fruitT, 0);
                    }
                    lookup[fruitT]++;

                    j++;
                }

                if (lookup.Keys.Count <= 2)
                {
                    var temp = ComputeFruitCount(lookup);
                    ans = Math.Max(ans, temp);
                }
                else
                {
                    var temp = ComputeFruitCount(lookup);
                    ans = Math.Max(ans, temp - 1);     // j add extra to make key count = 3
                }

                // ready to move i forward
                var fruitType = tree[i];
                var fruitT_Left = (--lookup[fruitType]);

                if (fruitT_Left == 0)
                {
                    lookup.Remove(fruitType);
                }

            }

            return ans;
        }

        private int ComputeFruitCount(Dictionary<int, int> lookup)
        {
            int num = 0;

            foreach (var count in lookup.Values)
            {
                num += count;
            }

            return num;
        }
    }
}
