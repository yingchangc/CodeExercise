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
    }
}
