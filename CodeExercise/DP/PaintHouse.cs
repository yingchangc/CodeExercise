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


        /// <summary>
        /// 265 paint  house 2
        /// https://leetcode.com/problems/paint-house-ii/description/
        /// There are a row of n houses, each house can be painted with one of the k colors. The cost of painting each house with a certain color is different. You have to paint all the houses such that no two adjacent houses have the same color.
        //The cost of painting each house with a certain color is represented by a n x k cost matrix.For example, costs[0][0] is the cost of painting house 0 with color 0; costs[1][2] is the cost of painting house 1 with color 2, and so on...Find the minimum cost to paint all houses.
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int MinCostII(int[,] costs)
        {
            int N = costs.GetLength(0);
            int colors = costs.GetLength(1);

            if (N == 0)
            {
                return 0;
            }

            int[,] F = new int[N + 1, colors];

            // init F[0,X]
            for (int k = 0; k <colors; k++)
            {
                F[0, k] = 0;
            }

            for (int i= 1; i <=N; i++)
            {
                for (int j = 0; j < colors; j++)
                {
                    int minPre = Int32.MaxValue;
                    for (int k = 0; k < colors; k++)
                    {
                        if (j!=k)
                        {
                            minPre = Math.Min(minPre, F[i - 1, k]);
                        }  
                    }

                    if (minPre == Int32.MaxValue)           // Note [[8]] case
                    {
                        minPre = 0;
                    }

                    F[i, j] = minPre + costs[i-1,j];
                }

            }

            int ans = Int32.MaxValue;

            for (int i =0; i<colors; i++)
            {
                ans = Math.Min(F[N, i], ans);
            }

            return ans;
        }

        public int MinCostIIOptimizeSpace(int[,] costs)
        {
            int N = costs.GetLength(0);
            int colors = costs.GetLength(1);

            if (N == 0)
            {
                return 0;
            }

            int[,] F = new int[2, colors];

            // init F[0,X]
            int now = 0;
            int old = 1;

            for (int k = 0; k < colors; k++)
            {
                F[now, k] = 0;
            }

            for (int i = 1; i <= N; i++)
            {
                now = 1 - now;
                old = 1 - old;
                for (int j = 0; j < colors; j++)
                {
                    int minPre = Int32.MaxValue;
                    for (int k = 0; k < colors; k++)
                    {
                        if (j != k)
                        {
                            minPre = Math.Min(minPre, F[old, k]);
                        }
                    }

                    if (minPre == Int32.MaxValue)           // Note [[8]] case
                    {
                        minPre = 0;
                    }

                    F[now, j] = minPre + costs[i-1, j];
                }

            }

            int ans = Int32.MaxValue;

            for (int i = 0; i < colors; i++)
            {
                ans = Math.Min(F[now, i], ans);
            }

            return ans;
        }
    }
}
