using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class BestTimeBuySellStock
    {
        /// <summary>
        /// 188
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/description/
        /// 
        /// Say you have an array for which the ith element is the price of a given stock on day i.
        ///
        ///        Design an algorithm to find the maximum profit.You may complete at most k transactions.
        ///
        ///
        ///        Note:
        ///You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
        /// </summary>
        /// <param name="k"></param>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit4(int k, int[] prices)
        {
            int N = prices.GetLength(0);

            if (N == 0)
            {
                return 0;
            }

            if (2*k >= N)
            {
                // MaxProfit3   have transaction each day   (each transation contains 1 buy 1 sell)
                return MaxProfit4Helper(prices);
            }

            int[,] F = new int[N, 2*k+1];    // +1 include the initial state

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= 2*k; j++)
                {
                    F[i, j] = 0;
                }
            }

            //{ 2, 1, 2, 0, 1 };

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j <= 2*k; j++)
                {
                    if (j%2 == 0)
                    {
                        // state 0 2 4 2k  (sold)   can be keep sold state  or just sold
                        // F[iDay, jState] = max( F[i-1, j] , F[i-1, j-1] + P[i] - P[i-1])
                        F[i, j] = Math.Max(F[i-1, j], F[i-1, j-1] + prices[i] - prices[i-1]);
                    }
                    else
                    {
                        // state 1 3 5 2k-1  (bought)   can be keep bought state (need to keep update the diff)  or just bought
                        // F[i,j] = max (F[i-1,j] + P[i]-P[i-1],  F[i-1, j-1])
                        F[i, j] = Math.Max(F[i - 1, j] + prices[i] - prices[i - 1], F[i - 1, j - 1]);
                    }
                }
            }

            int ans = 0;
            for (int j = 0; j <= 2*k; j++)
            {
                if (j%2 == 0)
                {
                    ans = Math.Max(ans, F[N - 1, j]);
                }
                
            }

            return ans;
        }

        private int MaxProfit4Helper(int[] prices)
        {
            int N = prices.GetLength(0);
            int pre = prices[0];
            int ans = 0;
            for (int i = 1; i < N; i++)
            {
                int diff = (prices[i] - pre);
                if ( diff > 0)
                {
                    ans += diff;
                }
                pre = prices[i];
            }

            return ans;
        }

        /// <summary>
        /// 151
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/description/
        /// 
        /// Say you have an array for which the ith element is the price of a given stock on day i.
        ///        Design an algorithm to find the maximum profit.You may complete at most two transactions.
        ///
        ///
        ///        Note:
        ///You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit3(int[] prices)
        {
            int N = prices.GetLength(0);

            if (N==0)
            {
                return 0;
            }

            int[,] F = new int[N, 5];            // init : 0, bought1:1, sold1:2, bought2:3, sold2:4


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    F[i, j] = 0;
                }
            }

            // 0 2 4 (sold) is the answer to compare
            // F[iday,jstate] = max(F[i-1][j-1] + P[i]-P[i-1], F[i-1][j])     either just sold today or has been sold and keep as is

            // 1,3  (bought) to keep  update p[i]-p[i-1]
            // F[iday,jstate] = max(F[i-1][j] + P[i]-P[i-1], F[i-1][j-1])

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j <5; j++)
                {
                    if (j % 2 == 0)
                    {
                        int justSold = (F[i - 1, j - 1] + prices[i] - prices[i - 1]);
                        int soldAndNoAction = F[i - 1, j];
                        F[i, j] = Math.Max(justSold, soldAndNoAction);
                    }
                    else
                    {
                        int justBought = F[i - 1, j - 1];
                        int keepBought = F[i - 1, j] + prices[i] - prices[i - 1];
                        F[i, j] = Math.Max(justBought, keepBought);
                    }
                }
                
            }

            int ans = 0;
            for (int j = 0; j < 5; j++)
            {
                if (j%2 == 0)
                {
                    ans = Math.Max(ans, F[N - 1, j]);
                }
                
            }

            return ans;
        }

        /// <summary>
        /// 714
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/description/
        /// Your are given an array of integers prices, for which the i-th element is the price of a given stock on day i; and a non-negative integer fee representing a transaction fee.
        /// 
        /// You may complete as many transactions as you like, but you need to pay the transaction fee for each transaction.You may not buy more than 1 share of a stock at a time (ie.you must sell the stock share before you buy again.)
        /// 
        /// Return the maximum profit you can make.
        /// 
        /// Example 1:
        /// Input: prices = [1, 3, 2, 8, 4, 9], fee = 2
        /// Output: 8
        /// Explanation: The maximum profit can be achieved by:
        /// Buying at prices[0] = 1
        /// Selling at prices[3] = 8
        /// Buying at prices[4] = 4
        /// Selling at prices[5] = 9
        /// The total profit is ((8 - 1) - 2) + ((9 - 4) - 2) = 8.
        /// </summary>
        /// 
        /// Sol refer to MaxProfitWithCooldown state machine.
        /// 
        /// Now have s0 and s1,
        /// 
        /// S0 can from S0  or S1 sold            int atS0 = Math.Max(preS1 + price - fee, preS0);   note initially set preS1 = - price[0] we do not have stock
        /// 
        /// S1 can from S1  or S0 bought.         int atS1 = Math.Max(preS0 - price, preS1);
        /// 
        /// <param name="prices"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public int MaxProfit6WithFee(int[] prices, int fee)
        {
            int N = prices.GetLength(0);

            if (N == 0)
            {
                return 0;
            }

            int preS0 = 0;
            int preS1 = -1 * prices[0];

            for (int i = 0; i < N; i++)
            {
                int price = prices[i];

                int atS0 = Math.Max(preS1 + price - fee, preS0);
                int atS1 = Math.Max(preS0 - price, preS1);

                preS0 = atS0;
                preS1 = atS1;
            }

            return preS0;
        }


        //309 Best Time to Buy and Sell Stock with Cooldown
        //http://zxi.mytechroad.com/blog/dynamic-programming/leetcode-309-best-time-to-buy-and-sell-stock-with-cooldown/
        //https://www.usenix.org/system/files/conference/hotcloud13/hotcloud13-wang.pdf
        /// <summary>
        /// Say you have an array for which the ith element is the price of a given stock on day i.
        ///  Design an algorithm to find the maximum profit.You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:
        ///  You may not engage in multiple transactions at the same time(ie, you must sell the stock before you buy again).
        ///  After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
        ///  Example:
        ///  prices = [1, 2, 3, 0, 2]
        ///          maxProfit = 3
        ///  transactions = [buy, sell, cooldown, buy, sell]
        ///  
        /// State machines s0, s1, s2  with action buy sell and cool
        /// 
        ///      
        ///   
        /// 
        ///    s0  --cool-->  s0
        ///        --buy -->  s1
        ///        
        ///    s1  --cool--> s1      ( must sell before can buy)
        ///    s1  --sell--> s2
        ///    
        ///    s2  --cool--> s0      (note cannot also have cool to itself, conflict)
        ///    
        /// 
        ///  =>        s0  _
        ///           /   |\
        ///         |/_     \
        ///         s1 ----> s2 
        /// 
        ///    s_[i] is the max profit at day i
        ///  
        ///    s0[i] = Max(s0[i-1], s2[i-1])     // cool again at s0 or cool from s2
        ///    s1[i] = Max(s1[i-1], s0[i-1] - price[i])  // cool again at s1 or buy from s0
        ///    s2[i] = s1[i-1] + price[i]           // sell from s1
        /// 
        /// 
        ///    base condition
        ///    
        ///    s0[0] set to 0
        ///    s1[0]  -Max
        ///    s2[0]  -Max
        ///    
        /// time:O(n)
        /// space: O(n)  can imporve to O(1)
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit5(int[] prices)
        {
            int N = prices.GetLength(0);
            if (N == 0)
            {
                return 0;
            }

            int k = N / 3 + 1;

            int[,] F = new int[N, 3*k];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 3*k; j++)
                {
                    F[i, j] = 0;
                }
            }

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < 3*k; j++)
                {
                    if (j % 3 == 1)  // bought;    kept in bought status  or just bought
                    {
                        F[i, j] = Math.Max(F[i - 1, j] + prices[i] - prices[i - 1], F[i - 1, j - 1]);
                    }
                    else if (j % 3 == 2)   // just sold
                    {
                        F[i, j] = F[i - 1, j - 1] + prices[i] - prices[i - 1];
                    }
                    else
                    {
                        // j == 3  cool down;  just cool down  or keept in cool down
                        F[i, j] = Math.Max(F[i - 1, j - 1], F[i - 1, j]);
                    }
                }
            }

            int ans = 0;
            for (int j = 1; j < 3*k; j++)
            {
                if ((j % 3) != 1)
                {
                    ans = Math.Max(ans, F[N - 1, j]);
                }
                
            }

            return ans;
        }

        public int MaxProfitWithCooldown(int[] prices)
        {
            int len = prices.Length;

            if (len == 0)
            {
                return 0;
            }

            // s_  is the max profit of current state, I can be at any state from pre_s
            // set base condition for preveious state
            int pre_s0 = 0;
            int pre_s1 = Int32.MinValue;
            int pre_s2 = Int32.MinValue;

            for (int i = 0; i < len; i++)
            {
                int price = prices[i];
                int at_s0 = Math.Max(pre_s0, pre_s2);   // come from : rest_s0  or rest from s2
                int at_s1 = Math.Max(pre_s0 - price, pre_s1);  // come from : buy from s0, or rest from s1
                int at_s2 = pre_s1 + price;

                pre_s0 = at_s0;
                pre_s1 = at_s1;
                pre_s2 = at_s2;
            }

            return Math.Max(pre_s0, pre_s2);   // s1 is just buying (substract) from s1 or keep as is, is smallest 
        }

        /// <summary>
        /// 121 Best Time to Buy and Sell stock I
        /// Say you have an array for which the ith element is the price of a given stock on day i.
        ///        If you were only permitted to complete at most one transaction(ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.
        ///       Example 1:
        ///Input: [7, 1, 5, 3, 6, 4]
        ///Output: 5
        ///
        ///
        ///       max.difference = 6 - 1 = 5(not 7 - 1 = 6, as selling price needs to be larger than buying price)
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            // don't forget this
            if(prices.Length <=0)
            {
                return 0;
            }

            int currentMin = prices[0];
            int maxPostiveDiff = 0;
            foreach(var price in prices)
            {
                currentMin = Math.Min(price, currentMin);
                maxPostiveDiff = Math.Max(price - currentMin, maxPostiveDiff);
            }

            return maxPostiveDiff;
        }
        
        /// <summary>
        /// All the straight forward solution should work, but if the interviewer twists the question slightly by giving the difference array of prices, Ex: for {1, 7, 4, 11}, if he gives {0, 6, -3, 7}, you might end up being confused.
        /// Here, the logic is to calculate the difference(maxCur += prices[i] - prices[i - 1]) of the original array, and find a contiguous subarray giving maximum profit.If the difference falls below 0, reset it to zero.
        /// </summary>
        /// <param name="pricesDiff"></param>
        /// <returns></returns>
        public int MaxProfitFromDiff(int[] pricesDiff)
        {
            // don't forget this
            if (pricesDiff.Length <= 0)
            {
                return 0;
            }

            int currDiff = 0;
            int ans = 0;

            // price 0 1 3 6  5 7
            // diff    1 2 3 -1 2  

            // price 1 2 4 7  0 1
            // diff    1 2 3 -7 1 
            // if <= 0   just start over from 0 without continue count  
            foreach (var diff in pricesDiff)
            {
                int newDiff = currDiff + diff;
                if (newDiff > 0)
                {
                    // maybe still postive trend, this time is just a small down Adjustment
                    currDiff = newDiff;
                    ans = Math.Max(ans, currDiff);
                }
                else
                {
                    currDiff = 0;  // start over   new lowest, we can ignore the past and start over
                }
            }

            return ans;
        }

        /// <summary>
        /// 122 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/
        /// Say you have an array for which the ith element is the price of a given stock on day i.
        //Design an algorithm to find the maximum profit.You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times). However, you may not engage in multiple transactions at the same time(ie, you must sell the stock before you buy again).
        /// 
        /// Sol:
        /// 
        /// always update pre, and calculate >0 diff
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit2(int[] prices)
        {

            if (prices.GetLength(0) == 0)
            {
                return 0;
            }

            int maxProfit = 0;
            int pre = prices[0];
            foreach (int price in prices)
            {
                if (price > pre)
                {
                    maxProfit += (price - pre);
                }

                pre = price;              // YIC update pre each time
            }

            return maxProfit;
        }
    }
}
