﻿using System;
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
        /// 
        /// 
        /// 
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


        public int ClimbStairs(int n)
        {
            return DFSHelper(n, new Dictionary<int, int>());
        }

        private int DFSHelper(int n, Dictionary<int, int> visited)
        {
            if (n <= 1)
            {
                return 1;
            }

            if (visited.ContainsKey(n))
            {
                return visited[n];
            }

            int count2 = DFSHelper(n - 2, visited);
            int count1 = DFSHelper(n - 1, visited);

            visited[n] = count2 + count1;

            return visited[n];
        }

        /// <summary>
        /// 70. Climbing Stairs
        /// You are climbing a stair case. It takes n steps to reach to the top.
        /// 
        /// Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        /// 
        ///        Note: Given n will be a positive integer.
        /// 
        ///        Example 1:
        /// 
        /// Input: 2
        /// Output: 2
        /// Explanation: There are two ways to climb to the top.
        /// 1. 1 step + 1 step
        /// 2. 2 steps
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs_DP(int n)
        {
            if (n <= 2)
            {
                return n;
            }

            int[] f = new int[n];
            f[0] = 1;
            f[1] = 1;

            for (int i = 2; i < n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }

            return f[n - 1] + f[n - 2];


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
        public int MinCostClimbingStairs_DP(int[] cost)
        {
            if (cost == null || cost.Length == 0)
            {
                return 0;
            }

            int len = cost.Length;

            if (len == 1)
            {
                return cost[0];
            }
            if (len == 2)
            {
                return Math.Min(cost[0], cost[1]);
            }

            int[] F = new int[len];
            F[0] = cost[0];
            F[1] = cost[1];

            for (int i = 2; i < len; i++)
            {
                F[i] = Math.Min(F[i - 1], F[i - 2]) + cost[i];
            }

            //                
            //  1 2 3 [top]
            return Math.Min(F[len - 1], F[len - 2]);


        }

        public int MinCostClimbingStairs_Back(int[] cost)
        {

            if (cost == null || cost.Length == 0)
            {
                return 0;
            }

            Dictionary<int, int> visited = new Dictionary<int, int>();

            int len = cost.Length;

            if (len <= 1)
            {
                return cost[0];
            }

            return DFSHelper(cost, cost.Length, visited);
        }

        public int DFSHelper(int[] cost, int index, Dictionary<int, int> visited)
        {
            if (index <= 1)
            {
                return cost[index];
            }

            if (visited.ContainsKey(index))
            {
                return visited[index];
            }


            int climb1Cost = DFSHelper(cost, index - 1, visited);
            int climb2Cost = DFSHelper(cost, index - 2, visited);

            if (index == cost.Length)
            {
                visited.Add(index, Math.Min(climb1Cost, climb2Cost));  // already top 
            }
            else
            {
                visited.Add(index, Math.Min(climb1Cost, climb2Cost) + cost[index]);
            }


            return visited[index];
        }
    }
}
