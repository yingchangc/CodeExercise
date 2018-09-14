using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class CoinsInALine
    {
        /// <summary>
        /// 394 Coins in a line
        /// http://www.lintcode.com/en/problem/coins-in-a-line/
        /// There are n coins in a line. Two players take turns to take one or two coins from right side until there are no more coins left. The player who take the last coin wins.
        ///Could you please decide the first play will win or lose?
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool firstWillWin(int n)
        {
            
            if (n == 0 || n ==3)
            {
                return false;
            }
            if (n== 1 || n == 2 || n==4)
            {
                return true;
            }

            bool[] F = new bool[n + 1];
            F[0] = false;   // no coin to choose, loose
            F[1] = true;
            F[2] = true;
            F[3] = false;
            F[4] = true;   // choose 1   and let opponent F[3] state

            for (int i = 4; i <=n; i++)
            {
                // take 1|2,   and refer to F state after the opponent finish his term. Opponent will choose the winner side, so use &
                // (1) take one, opponent take 1 or 2, so check F[i-1-1] & F[i-1-2]
                // (2) take two, opponent take 1 or 2, so check F[i-2-1] & F[i-2-2]
                F[i] = (F[i - 2] && F[i - 3]) || (F[i - 3] && F[i - 4]);
            }

            return F[n];
        }

        public bool firstWillWin2(int[] values)
        {
            int N = values.GetLength(0);

            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += values[i];
            }

            int[] F = new int[N];
            bool[] memo = new bool[N];

            int firstSum = firstWillWin2Helper(values, F, memo, 0, N);

            return (firstSum * 2) >= sum;
        }

        private int firstWillWin2Helper(int[] values, int[] F, bool[] memo, int i, int N)
        {
            if (i >= N)
            {
                return 0;
            }

            if (memo[i])
            {
                return F[i];
            }

            memo[i] = true;

            int takeOne = values[i] + Math.Min(firstWillWin2Helper(values, F, memo, i + 2, N),
                                               firstWillWin2Helper(values, F, memo, i + 3, N));

            int takeTwo = 0;
            if ((i+1) <= (N-1))
            {
                takeTwo = values[i] + values[i+1] + Math.Min(firstWillWin2Helper(values, F, memo, i + 3, N),
                                                             firstWillWin2Helper(values, F, memo, i + 4, N));
            }

            F[i] = Math.Max(takeOne, takeTwo);

            return F[i];
        }

        /// <summary>
        /// 396 coins in a line 3
        /// http://www.lintcode.com/en/problem/coins-in-a-line-iii/
        /// here are n coins in a line. Two players take turns to take a coin from one of the ends of the line until there are no more coins left. 
        /// The player with the larger amount of money wins.
        /// Could you please decide the first player will win or lose?
        /// 
        /// F[i,j] = Max    
        ///                 take left coin[i]  + Math.min(         // opponet will try make us smaller
        ///                                               F[i+2,j]  , F[i+1,j-1])
        ///                                               
        ///                 take right coint[j] + Math.min(
        ///                                                F[i,j-2] , F[i+1,j-1])
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool firstWillWin3(int[] values)
        {
            int N = values.GetLength(0);
            
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += values[i];
            }

            int[,] F = new int[N, N];
            bool[,] memo = new bool[N, N];

            int firstSum = firstWillWin3Helper(values, F, 0, N - 1, memo);

            return (firstSum*2) >= sum;
        }

        private int firstWillWin3Helper(int[] values, int[,] F, int i, int j, bool[,] memo)
        {
            // yic don't ref F or memo, because i j maybe out of bound
            if (i > j)
            {
                return 0;
            }

            if (memo[i,j])
            {
                return F[i, j];
            }

            memo[i, j] = true;

            if (i == j)
            {
                F[i, j] = values[i];
                return F[i, j];
            }

            int takeLeft = values[i] + Math.Min(firstWillWin3Helper(values, F, i+2, j, memo),
                                                firstWillWin3Helper(values, F, i+1, j-1, memo));

            int takeRight = values[j] + Math.Min(firstWillWin3Helper(values, F, i+1, j-1, memo),
                                                firstWillWin3Helper(values, F, i, j - 2, memo));


            F[i, j] = Math.Max(takeLeft, takeRight);

            return F[i, j]; 
        }
    }
}
