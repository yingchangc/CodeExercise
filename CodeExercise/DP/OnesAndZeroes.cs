using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class OnesAndZeroes
    {
        /// <summary>
        /// 474. Ones and Zeroes
        /// https://leetcode.com/problems/ones-and-zeroes/description/
        /// In the computer world, use restricted resource you have to generate maximum benefit is what we always want to pursue.
        ///For now, suppose you are a dominator of m 0s and n 1s respectively.On the other hand, there is an array with strings consisting of only 0s and 1s.
        ///
        ///Now your task is to find the maximum number of strings that you can form with given m 0s and n 1s.Each 0 and 1 can be used at most once.
        ///
        ///
        ///Note:
        ///The given numbers of 0s and 1s will both not exceed 100
        ///The size of given string array won't exceed 600.
        ///Example 1:
        ///Input: Array = { "10", "0001", "111001", "1", "0"}, m = 5, n = 3
        ///Output: 4
        ///
        ///Explanation: This are totally 4 strings can be formed by the using of 5 0s and 3 1s, which are “10,”0001”,”1”,”0”
        ///Example 2:
        ///Input: Array = {"10", "0", "1"}, m = 1, n = 1
        ///Output: 2
        ///
        ///Explanation: You could form "10", but then you'd have nothing left. Better form "0" and "1".
        ///
        /// 
        // F[i][m][n] = max (  F[i-1][m][n]     <--  skip current
        //                     F[i-1][m-"a0_i-1"][n-"a1_i-1"]    <-- take current ) 
        /// 
        /// </summary>
        /// <param name="strs"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindMaxForm(string[] strs, int m, int n)
        {
            int len = strs.Length;

            if (len == 0)
            {
                return 0;
            }

            int[,,] F = new int[len + 1, m+1, n+1];

            int ans = 0;

            for (int i = 1; i <= len; i++)
            {
                for(int j = 0; j <=m; j++)
                {
                    for(int k =0; k <=n; k++)
                    {
                        F[i, j, k] = F[i - 1, j, k];  // don't take current str

                        string currStr = strs[i - 1];

                        int zeroCount = 0;
                        int oneCount = 0;
                        GetZeroOnesInStr(currStr, out zeroCount, out oneCount);

                        if ((j - zeroCount >=0) && (k - oneCount) >=0)
                        {
                            F[i, j, k] = Math.Max(F[i, j, k], (F[i - 1, j - zeroCount, k - oneCount] + 1));   // yic +1 if consider current valid string
                        }

                        ans = Math.Max(ans, F[i, j, k]);
                    }
                }
            }

            return ans;
        }

        private void GetZeroOnesInStr(string str, out int zeroCount, out int oneCount)
        {
            int len = str.Length;

            zeroCount = 0;
            oneCount = 0;

            for (int i = 0; i < len; i++)
            {
                if (str[i] == '0')
                {
                    zeroCount += 1;
                }
                else
                {
                    oneCount += 1;
                }
            }
        }
    }
}
