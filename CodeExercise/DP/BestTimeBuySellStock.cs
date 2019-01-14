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

            // Note: it is okay to swap the for loop i  and j,  to conform with conin exchange, where coin is outside to prevent duplicat  target 10,  3 --7   vs 7 --3
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
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int len = prices.Length;

            int preBuy = -prices[0];
            int preSell = 0;

            for (int i = 1; i < len; i++)   // from day 2
            {
                int buy = Math.Max(preBuy, preSell - prices[i]);
                int sell = Math.Max(preSell, preBuy + prices[i] - fee);

                preBuy = buy;
                preSell = sell;
            }

            return preSell;
        }

        public int MaxProfit6_outfoMemory(int[] prices, int fee)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }
            int days = prices.Length;

            int tran = days / 2;
            if (days % 2 != 0)
            {
                tran++;
            }

            int[,] F = new int[days, 2 * tran + 1];

            for (int d = 1; d < days; d++)
            {
                for (int a = 1; a <= 2 * tran; a++)
                {
                    if (a % 2 == 0)
                    {
                        // sell
                        F[d, a] = Math.Max(F[d - 1, a], F[d - 1, a - 1] + prices[d] - prices[d - 1] - fee);
                    }
                    else
                    {
                        // buy
                        F[d, a] = Math.Max(F[d - 1, a] + prices[d] - prices[d - 1], F[d - 1, a - 1]);
                    }
                }
            }

            int ans = 0;
            for (int a = 0; a <= 2 * tran; a++)
            {
                if (a % 2 == 0)
                {
                    ans = Math.Max(ans, F[days - 1, a]);
                }
            }

            return ans;
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
            // buy  F[d,a] = Max( F[d-1,a] + (prices[d]-prices[d-1]), F[d-1,i-1] )      keep vs from Cool
            // sell F[d,a] = F[d-1,a-1] + (prices[d]-prices[d-1])
            // cool F[d,a] = Max(F[d-1,a], F[d-1,a-1]      keep  vs from sell

            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int days = prices.Length;
            int tran = days / 3;

            if (days % 3 != 0)
            {
                tran++;
            }

            int[,] F = new int[days, 3 * tran + 1];

            for (int d = 1; d < days; d++)
            {
                for (int a = 1; a <= 3 * tran; a++)
                {
                    if (a % 3 == 1)
                    {  // buy
                        F[d, a] = Math.Max(F[d - 1, a] + prices[d] - prices[d - 1], F[d - 1, a - 1]);
                    }
                    else if (a % 3 == 2)
                    {
                        // sell
                        F[d, a] = F[d - 1, a - 1] + prices[d] - prices[d - 1];
                    }
                    else
                    {
                        //cool
                        F[d, a] = Math.Max(F[d - 1, a], F[d - 1, a - 1]);
                    }
                }
            }
            int ans = 0;
            for (int a = 0; a <= 3 * tran; a++)
            {
                if (a % 3 != 1)
                {
                    ans = Math.Max(ans, F[days - 1, a]);
                }
            }
            return ans;
        }

        public int MaxProfitWithCooldown(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int preSell = 0;
            int preCool = 0;
            int preBuy = -prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                int sell = Math.Max(preSell, preBuy + prices[i]);
                int buy = Math.Max(preBuy, preCool - prices[i]);
                int cool = Math.Max(preCool, preSell);

                preSell = sell;
                preBuy = buy;
                preCool = cool;
            }

            return Math.Max(preSell, preCool);
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
        /// 122. Best Time to Buy and Sell Stock II
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
        public int MaxProfit2_AlignToCoolDownAndFee(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int preSell = 0;
            int preBuy = -prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                int sell = Math.Max(preSell, preBuy + prices[i]);
                int buy = Math.Max(preBuy, preSell - prices[i]);

                preSell = sell;
                preBuy = buy;
            }

            return preSell;
        }

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
