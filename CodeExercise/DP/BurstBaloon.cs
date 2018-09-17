using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class BurstBalloons
    {
        /// <summary>
        /// 312. Burst Balloons
        /// https://leetcode.com/problems/burst-balloons/description/
        /// Given n balloons, indexed from 0 to n-1. Each balloon is painted with a number on it represented by array nums. You are asked to burst all the balloons.
        /// If the you burst balloon i you will get nums[left] * nums[i] * nums[right] coins. Here left and right are adjacent indices of i. 
        /// After the burst, the left and right then becomes adjacent.

        /// Find the maximum coins you can collect by bursting the balloons wisely.
        /// 
        /// Note: 
        /// (1) You may imagine nums[-1] = nums[n] = 1.They are not real therefore you can not burst them.
        /// (2) 0 ≤ n ≤ 500, 0 ≤ nums[i] ≤ 100
        /// 
        ///     Given[3, 1, 5, 8]
        /// 
        /// Return 167
        /// 
        ///     nums = [3,1,5,8] --> [3,5,8] -->   [3,8]   -->  [8]  --> []
        ///    coins =  3*1*5      +  3*5*8    +  1*3*8      + 1*8*1   = 167
        /// </summary>
        /// 
        /// Sol:
        /// 
        /// loop all length for i~j   
        /// 
        /// F[i,j] = Max(F[i,k] + F[k,j] + A[i]*A[k]*A[j])   where i j  dont burst, k is range from i+1 to j-1
        /// 
        /// 
        /// Time O(N^3)  Space O(N^2)
        /// 
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxCoins(int[] nums)
        {
            int N = nums.GetLength(0);
            if (N == 0)
            {
                return 0;
            }

            N = N + 2;   // update to new N
            int[] A = new int[N];
            AppendFrontAndBack(A, nums);

            int[,] F = new int[N, N];

            /// dont burst single and two case
            // single balloon
            for (int i = 0; i < N; i++)
            {
                F[i, i] = 0;
            }

            // two adjacent balloon
            for (int i= 0; i < N-1; i++)
            {
                F[i, i + 1] = 0;
            }

            // start from small section  F[i,j]
            for (int len = 3; len <= N; len++)
            {
                for (int i = 0; i <= (N-len); i++)
                {
                    int j = i + len - 1;

                    for (int k = i+1; k <= j-1; k++)
                    {
                        F[i, j] = Math.Max(F[i, j],
                                           F[i, k] + F[k, j] + A[i] * A[k] * A[j]);
                    }
                    
                }
            }

            return F[0, N - 1];
        }

        private void AppendFrontAndBack(int[] A, int[] nums)
        {
            int N = nums.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                A[i + 1] = nums[i];
            }

            A[0] = 1;
            A[N + 1] = 1;
        }
    }
}
