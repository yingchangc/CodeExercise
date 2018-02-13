using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class PaintHouse
    {
        /// <summary>
        /// 256
        /// https://leetcode.com/problems/paint-house/description/
        /// 
        /// There are a row of n houses, each house can be painted with one of the three colors: red, blue or green. The cost of painting each house with a certain color is different. You have to paint all the houses such that no two adjacent houses have the same color.
        /// 
        /// The cost of painting each house with a certain color is represented by a n x 3 cost matrix.For example, costs[0][0] is the cost of painting house 0 with color red; costs[1][2] is the cost of painting house 1 with color green, and so on...Find the minimum cost to paint all houses.
        /// 
        ///       Note:
        /// All costs are positive integers.
        /// 
        /// Sol:
        /// 
        /// f[i][R] = min (f[i-1][G], f[i-1][B])   + cost[i-1][R]
        /// 
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int MinCost(int[,] costs)
        {
            int N = costs.GetLength(0);

            if (N ==0)
            {
                return 0;
            }

            int Colors = costs.GetLength(1); // should be 3
            int[,] F = new int[N + 1, Colors];  

            // padding to avoid first 
            for (int k = 0; k < Colors; k++)
            {
                F[0, k] = 0;
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j < Colors; j++)
                {
                    int minPreCost = Int32.MaxValue;
                    for (int k = 0; k < Colors; k++)
                    {
                        if (k != j)    // j=R    k choose G,B
                        {
                            minPreCost = Math.Min(minPreCost, F[i - 1, k]);
                        }
                    }

                    F[i, j] = minPreCost + costs[i - 1, j];
                }
            }

            return Math.Min(F[N, 0], Math.Min(F[N, 1], F[N, 2]));
        }

        public int MinCostOptimizeSpace(int[,] costs)
        {
            int N = costs.GetLength(0);

            if (N == 0)
            {
                return 0;
            }

            int Colors = costs.GetLength(1); // should be 3
            int[,] F = new int[2, Colors];

            // padding to avoid first 
            for (int k = 0; k < Colors; k++)
            {
                F[0, k] = 0;
            }

            int now = 0;
            int old = 1;

            for (int i = 1; i <= N; i++)
            {
                now = 1 - now;
                old = 1 - old;

                for (int j = 0; j < Colors; j++)
                {
                    int minPreCost = Int32.MaxValue;
                    for (int k = 0; k < Colors; k++)
                    {
                        if (k != j)    // j=R    k choose G,B
                        {
                            minPreCost = Math.Min(minPreCost, F[old, k]);
                        }
                    }

                    F[now, j] = minPreCost + costs[i - 1, j];
                }
            }

            return Math.Min(F[now, 0], Math.Min(F[now, 1], F[now, 2]));
        }
    }
}
