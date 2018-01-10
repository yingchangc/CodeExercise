using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class BestTimeBuySellStock
    {
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
        /// State machines s0, s1, s2  with action buy sellm and cool
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
        /// 121
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
    }
}
