using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class Backpack
    {
        /// <summary>
        /// 564 Backpack VI
        /// http://www.lintcode.com/en/problem/backpack-vi/
        /// </summary>
        /// 
        /// Given an integer array nums with all positive numbers and no duplicates, find the number of possible combinations that add up to a positive integer target
        /// 
        /// 
        /// Given nums = [1, 2, 4], target = 4

        ///         The possible combination ways are:
        ///         [1, 1, 1, 1]
        ///         [1, 1, 2]
        ///         [1, 2, 1]
        ///         [2, 1, 1]
        ///         [2, 2]
        ///         [4]
        ///         return 6
        /// 
        /// 
        /// sol
        /// 和Backpack V唯一区别：组合中数字可以按不同的顺序，比如1+1+2与1+2+1算两种组合
        /// 
        /// 
        /// nums = {1,2,4}
        /// F[4] = F[4-4] + F[4-2] + F[4-1]
        /// 
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int BackPackVI(int[] nums, int target)
        {
            int N = nums.GetLength(0);

            if (N == 0)
            {
                return 0;
            }

            int[] F = new int[target+1];   // for intial 0 value has 1 case

            F[0] = 1;

            for (int v = 0; v <= target; v++)
            {
                for (int i = 0; i < N; i++)
                {
                    int currNum = nums[i];
                    if ((v - currNum) >=0 )
                    {
                        F[v] += F[v - currNum];
                    }  
                }
            }

            return F[target];
        }

        /// <summary>
        /// 92
        /// http://www.lintcode.com/en/problem/backpack/
        /// Given n items with size Ai, an integer m denotes the size of a backpack. How full you can fill this backpack?
        /// 
        /// If we have 4 items with size [2, 3, 5, 7], the backpack size is 11, we can select [2, 3, 5], so that the max size we can fill this backpack is 10. If the backpack size is 12. we can select [2, 3, 7] so that we can fulfill the backpack.
        /// You function should return the max size we can fill in the given backpack.
        /// 
        /// not sure which W can be true, so need to check each weight
        /// 
        /// F[i,W] = F[i-1,W]  || F[i-1, W - P[i-1]]    maxWeight is when F[N, maxWeight] == true;
        /// 
        /// </summary>
        /// <param name="m"> weight constraint</param>
        /// <param name="A"> list of weights</param>
        /// <returns></returns>
        public int BackPack1(int m, int[] A)
        {
            int N = A.GetLength(0);

            if (N == 0)
            {
                return 0;
            }

            int weightConstraint = m;

            bool[,] F = new bool[N + 1, weightConstraint+1];   // init to all false, previous i day, can reach w is true/false
            F[0,0] = true;

            for (int i = 1; i <= N; i++)    // previouse i day
            {
                int currWeight = A[i-1];
                for (int w = 0; w <= weightConstraint; w++)
                {
                    F[i, w] = F[i - 1, w];   // already reached w a day before

                    if (w - currWeight >= 0)
                    {
                        F[i, w] |= F[i - 1, (w - currWeight)];  // today add currWeight reached w
                    }
                }
            }

            int ans = 0;
            for (int w = 0; w <= weightConstraint; w++)   // from smll to lg and find the last w that F[N,w] == true
            {
                if (F[N,w] == true)
                {
                    ans = w;
                }
            }

            return ans;
        }

        public int BackPack1_optSpace(int m, int[] A)
        {
            int N = A.GetLength(0);

            if (N == 0)
            {
                return 0;
            }

            int weightConstraint = m;

            bool[,] F = new bool[2, weightConstraint + 1];   // init to all false, previous i day, can reach w is true/false
            F[0, 0] = true;

            int now = 0;
            int old = 1;

            for (int i = 1; i <= N; i++)    // previouse i day
            {
                now = 1 - now;
                old = 1 - old;
                int currWeight = A[i - 1];
                for (int w = 0; w <= weightConstraint; w++)
                {
                    F[now, w] = F[old, w];   // already reached w a day before

                    if (w - currWeight >= 0)
                    {
                        F[now, w] |= F[old, (w - currWeight)];  // today add currWeight reached w
                    }
                }
            }

            int ans = 0;
            for (int w = 0; w <= weightConstraint; w++)   // from smll to lg and find the last w that F[N,w] == true
            {
                if (F[now, w] == true)
                {
                    ans = w;
                }
            }

            return ans;
        }

        /// <summary>
        /// 563 Backpack V
        /// http://www.lintcode.com/en/problem/backpack-v/
        /// Given n items with size nums[i] which an integer array and all positive numbers. 
        /// An integer target denotes the size of a backpack. Find the number of possible fill the backpack.
        /// 
        /// sol
        /// Given candidate items [1,2,3,3,7] and target 7,
        ///        A solution set is: 
        ///        [7]
        ///        [1, 3, 3]
        ///        return 2
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int BackPackV(int[] nums, int target)
        {
            int N = nums.GetLength(0);
            int[,] F = new int[N + 1, target + 1];

            // init all 0 and F[0,0] = 1;      note F[i, 0]  = 1 can be set in later for loop
            F[0, 0] = 1;

            for (int i = 1; i <= N; i++)
            {
                for (int v = 0; v <= target; v++)  // YIC start from 0, don't rush to get target, compute on the fly to get final target
                {
                    F[i, v] = F[i - 1, v];     // a day before has reached v

                    if (v - nums[i - 1] >=0)
                    {
                        F[i, v] += F[i - 1, v - nums[i - 1]];   // today after add nums[i-1] reach v
                    }      
                }
            }

            return F[N, target];
        }

        public int BackPackV_OptSpace(int[] nums, int target)
        {
            int N = nums.GetLength(0);
            int[,] F = new int[2, target + 1];

            // init all 0 and F[0,0] = 1;      note F[i, 0]  = 1 can be set in later for loop
            F[0, 0] = 1;
            int now = 0;
            int old = 1;

            for (int i = 1; i <= N; i++)
            {
                now = 1 - now;
                old = 1 - old;
                for (int v = 0; v <= target; v++)  // YIC start from 0, don't rush to get target, compute on the fly to get final target
                {
                    F[now, v] = F[old, v];     // a day before has reached v

                    if (v - nums[i - 1] >= 0)
                    {
                        F[now, v] += F[old, v - nums[i - 1]];   // today after add nums[i-1] reach v
                    }
                }
            }

            return F[now, target];
        }

        /// <summary>
        /// lint 125
        /// http://www.lintcode.com/en/problem/backpack-ii/
        /// Given n items with size Ai and value Vi, and a backpack with size m. What's the maximum value can you put into the backpack?
        /// 
        /// ex
        /// Given 4 items with size [2, 3, 5, 7] and value [1, 5, 2, 4], and a backpack with size 10. The maximum value is 9.
        /// 
        /// F[i,W] = Max( F[i-1,w] , F[i,W-wi] + vi )
        /// </summary>
        /// <param name="s"> backpack size</param>
        /// <param name="A"></param>
        /// <param name="V"></param>
        /// <returns></returns>
        public int BackPackII(int s, int[] A, int[] V)
        {
            int N = A.Length;

            int[,] F = new int[N + 1, s + 1];   // numItems, size

            for (int i = 0; i <= N;i++)
            {
                F[i, 0] = 0;     // no size quota
            }

            for (int w = 0; w <= s; w++)
            {
                F[0, w] = 0;   // no item for value
            }

            for(int w = 1; w <= s; w++)
            {
                for (int i = 1; i <= N; i++)
                {
                    //F[i,W] = Max( F[i-1,w] , F[i,W-wi] + vi )
                    F[i, w] = F[i - 1, w];

                    if ((w - A[i-1]) >= 0)
                    {
                        F[i, w] = Math.Max(F[i-1, w], F[i-1, w - A[i - 1]] + V[i - 1]);
                    }
                }
            }

            return F[N, s];
        }

        /// <summary>
        /// lint 440
        /// http://www.lintcode.com/en/problem/backpack-iii/
        /// 
        /// Given n kind of items with size Ai and value Vi( each item has an infinite number available) and a backpack with size m. 
        /// What's the maximum value can you put into the backpack?
        /// 
        /// Given 4 items with size [2, 3, 5, 7] and value [1, 5, 2, 4], and a backpack with size 10. The maximum value is 15.
        /// 
        /// Sol:
        /// 
        /// F[i,w] = max (F[i-1, w] ,  F[i-1, w-w_i-1], F[i-1, w-2w_i-1], F[i-1, w-k*2_i-1])
        /// </summary>
        /// <param name="A"></param>
        /// <param name="V"></param>
        /// <param name="m"> backpack size</param>
        /// <returns></returns>
        public int backPackIII_slow(int[] A, int[] V, int m)
        {
            int N = A.Length;
            int[,] F = new int[N+1, m+1];

            for (int i = 0; i <= N; i++)
            {
                F[i, 0] = 0;   // no size allowed
            }

            for (int w = 0; w<=m; w++)
            {
                F[0, w] = 0;  // no value
            }

            for (int i = 1; i <=N; i++)
            {
                for (int w = 1; w<=m; w++)
                {
                    F[i, w] = 0;
                    for (int k = 0; k <= w/A[i-1]; k++)
                    {
                        F[i, w] = Math.Max(F[i, w], 
                                           F[i - 1, w - k * A[i-1]] + k*V[i-1]);
                    }

                }
            }

            return F[N, m];
        }

        // F[i,w] = max (F[i-1,w-kWi-1] + k*Vi-1)
        // F[i,w-wi-1] = max (F[i-1,w], F[i,w-wi-1]+vi)
        public int backPackIII(int[] A, int[] V, int m)
        {
            int N = A.Length;
            int[,] F = new int[N + 1, m + 1];

            for(int i = 1; i <= N; i++)
            {
                for (int w= 1; w<=m; w++)
                {
                    F[i, w] = F[i-1, w];

                    if (w-A[i-1] >=0)
                    {
                        F[i, w] = Math.Max(F[i-1, w],
                                          F[i, w - A[i - 1]] + V[i - 1]);
                    }
                }
            }

            return F[N, m];
        }


    }
}
