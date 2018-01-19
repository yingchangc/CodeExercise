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
        /// 70
        /// You are climbing a stair case. It takes n steps to reach to the top.
        /// Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        /// Note: Given n will be a positive integer.
        /// </summary>
        /// just like fib[n] = fib[n-1] + fib[n-2]
        /// 
        /// No Memo  O(2^n)
        /// with memo  O(n)  with space O(n)
        /// 
        /// use fib
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {

            // fib way
            //if (n <=2)
            //{
            //    return n;
            //}

            //int pre = 2;     // n =2
            //int prepre = 1;  // n=1

            //for (int i = 3; i <= n; i++)
            //{
            //    int curr = pre + prepre;
            //    prepre = pre;
            //    pre = curr;
            //}

            //return pre;


            // with memo
            if (n == 0)
            {
                return 0;
            }

            Dictionary<int, int> lookup = new Dictionary<int, int>();  // (nth, ways)

            return climbHelper(n, lookup);
        }

        private int climbHelper(int n, Dictionary<int, int> lookup)
        {
            // base condition
            if (n <=2)
            {
                return n;
            }

            if (lookup.ContainsKey(n))
            {
                return lookup[n];
            }

            int steps = climbHelper(n-1, lookup) + climbHelper(n-2, lookup);

            lookup[n] = steps;

            return steps;
        }

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
