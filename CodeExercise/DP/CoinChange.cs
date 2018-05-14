using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class CoinChange
    {
        /// <summary>
        /// Question: 
        ///   CleanCodeHandbook_v1.0.3.pdf  #47
        /// There are n coins in a line. (Assume n is even). Two players take turns to take a coin from one of 
        /// the ends of the line until there are no more coins left.The player with the larger amount of money wins. 1.
        /// Would you rather go first or second? Does it matter? 2. Assume that you go first, describe an algorithm to compute 
        /// the maximum amount of money you can win.
        /// 
        /// 
        /// sol:
        /// Let us look one extra step ahead this time by considering the two coins the opponent will possibly take, Ai+1 and Aj. 
        /// If the opponent takes Ai+1, the remaining coins are { Ai+2 … Aj }, which our maximum is denoted by P(i + 2, j). 
        /// On the other hand, if the opponent takes Aj, our maximum is P(i + 1, j – 1). Since the opponent is as smart as you, 
        /// he would have chosen the choice that yields the minimum amount to you. Therefore, the maximum amount you can get when 
        /// you choose Ai is: 
        /// Therefore, the maximum amount you can get when you choose Ai is: 
        /// 𝑃1 = 𝐴𝑖 + 𝑚𝑖𝑛(𝑃(𝑖 + 2,𝑗),𝑃(𝑖 + 1,𝑗 − 1)) 
        /// Similarly, the maximum amount you can get when you choose Aj is: 
        /// 𝑃2 = 𝐴𝑗 + 𝑚𝑖𝑛(𝑃(𝑖 + 1,𝑗 − 1),𝑃(𝑖,𝑗 − 2)) 
        /// 
        /// P(i,j) = Max(P1, P2) 
        /// 
        /// O(n^2) time and takes O(n^2) space
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CoinsInALine(int[] nums)
        {
            int len = nums.Length;

            if (len == 0)
            {
                return 0;
            }

            int[,] memo = new int[len, len];

            return CoinsInALineHelper(nums, 0, len - 1, memo);
        }

        private int CoinsInALineHelper(int[] nums, int i, int j, int[,] memo)
        {
            // base condition
            if ((j - i) <= 1)    // can be even or odd
            {
                int maxV = Math.Max(nums[i], nums[j]);
                memo[i, j] = maxV;
                return maxV;
            }

            if (memo[i,j] > 0)
            {
                return memo[i, j];
            }
                       
            // Choose i, opponent can smart choose num[i+1]  or num[j] that is bigger, so  for me use min
            int Pi = nums[i] + Math.Min(CoinsInALineHelper(nums, i + 1, j - 1, memo), CoinsInALineHelper(nums, i + 2, j, memo));

            // Choose j, opponent can choose num[i]  or num[j-1]
            int Pj = nums[j] + Math.Min(CoinsInALineHelper(nums, i + 1, j - 1, memo), CoinsInALineHelper(nums, i, j-2, memo));

            int currLevelMax = Math.Max(Pi, Pj);
            memo[i, j] = currLevelMax;

            return currLevelMax;

        }

        /// <summary>
        /// 518
        /// u are given coins of different denominations and a total amount of money. Write a function to compute the number of combinations that make up that amount. You may assume that you have infinite number of each kind of coin. 
        /// Note: You can assume that 
        /// 0 ge amount le 5000
        /// 1 ge coin le 5000
        /// the number of coins is less than 500 
        /// the answer is guaranteed to fit into signed 32-bit integer
        /// 
        /// {1,2,5}  target = 5
        /// 
        /// memo 
        ///  idx 0  1  2  3  4  5
        ///  v   1  0  0  0  0  0
        ///  
        ///  1   1 "1"            because use 1-1 = 0   mem[0] = 1   so  mem[1]+=mem[0] 
        /// 
        /// 
        /// there will be 4 ways
        /// 1 1 1 1 1
        /// 1 1 1 2
        /// 1 2 2
        /// 5
        /// 
        /// 
        /// Example 1: 
        ///         Input: amount = 5, coins = [1, 2, 5]
        ///         Output: 4
        /// Explanation: there are four ways to make up the amount:
        /// 5=5
        /// 5=2+2+1
        /// 5=2+1+1+1
        /// 5=1+1+1+1+1
        /// 
        /// Example 2: 
        /// Input: amount = 3, coins = [2]
        ///         Output: 0
        /// Explanation: the amount of 3 cannot be made up just with coins of 2.
        /// 
        /// Example 3: 
        /// Input: amount = 10, coins = [10]
        ///         Output: 1
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int CoinChange2(int amount, int[] coins)
        {
            int[] memo = new int[amount + 1];

            memo[0] = 1;    

            foreach(int coin in coins)
            {
                for (int currentTarget = 0; currentTarget <= amount; currentTarget++)
                {
                    if (currentTarget >= coin)
                    {
                        memo[currentTarget] += memo[currentTarget - coin];
                    }
                }
            }

            return memo[amount];
        }

        /// <summary>
        /// http://www.lintcode.com/en/problem/coin-change/
        /// 
        /// the same as leetcode 322
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int coinChange(int[] coins, int amount)
        {

            int[] memo = new int[amount + 1];
            memo[0] = 0;
            for(int i = 1; i <= amount; i++)
            {
                memo[i] = Int32.MaxValue;
            }

            for (int i = 0; i <= amount; i++)
            {
                foreach(var coin in coins)
                {
                    if ( i >= coin)
                    {
                        memo[i] = Math.Min(memo[i], 
                                           (memo[i - coin] == Int32.MaxValue) ? Int32.MaxValue : memo[i - coin] + 1);
                    }
                }
            }

            return (memo[amount] == Int32.MaxValue) ? -1 : memo[amount];

        }


        /// <summary>
        /// 322
        /// You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1. 
        ///   Example 1:
        /// coins = [1, 2, 5], amount = 11
        /// return 3 (11 = 5 + 5 + 1) 
        ///   Example 2:
        /// coins = [2], amount = 3
        /// return -1. 
        /// Note:
        /// You may assume that you have an infinite number of each kind of coin.
        /// 
        /// 
        /// get all number smaller than target length so that it can accumulate length to target 
        ///  
        /// init array [0~target]   with 0 = 0 (default no coin), than the reset default to maxLenght
        /// 
        /// for each coin selected, update len[amount] = Min(len[amount], 1+len[amount-coin])       note: len[amount-coin] already the best len so far with coin selected
        /// 
        /// 
        /// Check CombineSum  questions
        /// https://www.youtube.com/watch?v=jaNZ83Q3QGc
        /// https://www.youtube.com/watch?v=NJuKJ8sasGk
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int MinCoinChangeSolver(int[] coins, int amount)
        {
            if (amount == 0)
            {
                return 0;
            }

            int[] ansLength = new int[amount + 1];

            // init with 0 position to 0 (no coin) and the rest to lenght value to Max
            ansLength[0] = 0;
            for(int i = 1; i <= amount; i++)
            {
                ansLength[i] = Int32.MaxValue;
            } 

            foreach (int currCoin in coins)
            {
                for(int currAmount = 0; currAmount <= amount; currAmount++)
                {
                    if (currAmount >= currCoin)
                    {
                        // if len[currAmoint - currCoin] != MaxValue  then we can try 1+ the len[currAmoint - currCoin]  and compare if smaller than original 
                        ansLength[currAmount] = Math.Min(ansLength[currAmount],
                                                         ansLength[currAmount - currCoin] == Int32.MaxValue ? Int32.MaxValue : 1 + ansLength[currAmount - currCoin]);
                    }
                }

                PrintRow(ansLength, currCoin);
            }

            return ansLength[amount] == Int32.MaxValue ? -1 : ansLength[amount];
        }

        private void PrintRow(int[] arr, int currCoin)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(i + "  ");
            }

            Console.WriteLine("current coin selected: " + currCoin);



            for(int i =0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "  ");
            }

            Console.WriteLine();
        }

        //Exceeded time~
        public int CoinChangeSolverSlow(int[] coins, int amount)
        {
            Array.Sort(coins, new Comparison<int>(
                    (i1, i2) => i2.CompareTo(i1)
                ));                                      // sort large to small

            List<int> currentRes = new List<int>();
            List<List<int>> collection = new List<List<int>>();
            if (amount > 0)
            {
                CoinChangeHelper(coins, amount, 0, currentRes, collection);
                if (collection.Count > 0)
                {
                    int minNum = Int32.MaxValue;

                    foreach (var ans in collection)
                    {
                        minNum = Math.Min(minNum, ans.Count);
                    }

                    return minNum;
                }
                return -1;
            }


            return 0;
        }

        private void CoinChangeHelper(int[] coints, int amount, int index, List<int> currentRes, List<List<int>> collection)
        {
            // stop condition
            if (amount == 0)
            {
                List<int> ans = new List<int>(currentRes);
                collection.Add(ans);
                return;
            }

            for (int i = index; i < coints.Length; i++)
            {

                int leftAmount = amount - coints[i];

                currentRes.Add(coints[i]);
                if (leftAmount >= 0)
                {
                    CoinChangeHelper(coints, leftAmount, i, currentRes, collection);
                }
                currentRes.RemoveAt(currentRes.Count-1);   // pop the current add one
            }
        }

        //http://www.cnblogs.com/grandyang/p/4840713.html
        //Given an infinite number of quarters (25 cents), dimes (10 cents), nickels (5 cents) and pennies (1 cent), 
        //write code to calculate the number of ways of representing n cents.
        public int NumberCoinChange(int amount, int[] denoms)
        {
            if (amount  == 0)
            {
                return 0;
            }

            Dictionary<Tuple<int,int>, int> lookup = new Dictionary<Tuple<int,int>, int>();
            int index = 0;
            int ans = NumCoinChange(amount, denoms, index, lookup);
            return ans;
        }

        // use index to make sure don't revisit previous index (ie index-1), so no duplicate case  (25, 25, 5) vs (25, 5, 25)
        private int NumCoinChange(int amount, int[] denoms, int index, Dictionary<Tuple<int,int>,int> lookup)
        {
            if (amount == 0)
            {
                return 1;
            }

            var amount_index = Tuple.Create(amount, index);
            if (lookup.ContainsKey(amount_index))
            {
                return lookup[amount_index];
            }

            if (index >= denoms.Length)
            {
                return 0;
            }

            int ways = 0;
            int maxChangebyCoinI = amount / denoms[index];

            for (int i = 0; i <= maxChangebyCoinI; i++)
            {
                int newAmount = amount - i * denoms[index];
                int leftWays = NumCoinChange(newAmount, denoms, index + 1, lookup);  // move on to next coint type, dont revisit
                ways += leftWays;
            }

            
            lookup[amount_index] = ways;
            return ways;
        }

    }
}
