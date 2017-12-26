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
