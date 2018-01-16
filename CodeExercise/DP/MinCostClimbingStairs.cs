using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class MinCostClimbingStairs
    {
        /// <summary>
        /// 746
        /// On a staircase, the i-th step has some non-negative cost cost[i] assigned (0 indexed). 
        ///         Once you pay the cost, you can either climb one or two steps.You need to find minimum cost to reach the top of the floor, and you can either start from the step with index 0, or the step with index 1. 
        /// Example 1:
        /// Input: cost = [10, 15, 20]
        ///         Output: 15
        /// Explanation: Cheapest is start on cost[1], pay that cost and go to the top.
        /// 
        /// 
        ///         Example 2:
        /// Input: cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
        ///         Output: 6
        /// Explanation: Cheapest is start on cost[0], and only step on 1s, skipping cost[3].
        /// 
        /// Note:
        /// cost will have a length in the range[2, 1000].
        ///Every cost[i] will be an integer in the range[0, 999].
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairsSolver(int[] cost)
        {
            // A better solution
            /*
            int minCostClimbingStairs(vector < int > &cost) {
                int n = (int)cost.size();
                vector<int> dp(n);
                dp[0] = cost[0];
                dp[1] = cost[1];
                for (int i = 2; i < n; ++i)
                    dp[i] = cost[i] + min(dp[i - 2], dp[i - 1]);
                return min(dp[n - 2], dp[n - 1]);
            }
            */


            Dictionary<int, int> lookup = new Dictionary<int, int>(); // index , best cost
            
            return Math.Min(BestPreviousCostHelper(cost, cost.Length-1, lookup), BestPreviousCostHelper(cost, cost.Length-2, lookup));

        }

        private int BestPreviousCostHelper(int[] cost, int index, Dictionary<int, int> lookup)
        {
            if (index <= 1)
            {
                return cost[index];
            }

            if (lookup.ContainsKey(index))
            {
                return lookup[index];
            }

            int preBestCost = Math.Min(BestPreviousCostHelper(cost, index - 1, lookup), BestPreviousCostHelper(cost, index - 2, lookup));

            int finalcost = cost[index] + preBestCost;
            lookup[index] = finalcost;

            return finalcost;

        }
    }
}
