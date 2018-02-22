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
                F[i] = (F[i - 2] & F[i - 3]) | (F[i - 3] & F[i - 4]);
            }

            return F[n];
        }
    }
}
