using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class FastPower
    {
        /// <summary>
        /// lint 140 fast power
        ///  https://www.lintcode.com/problem/fast-power/description
        ///  Calculate the a^n % b where a, b and n are all 32bit integers.
        ///  For 2^31 % 3 = 2
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="n"></param>
        /// <returns></returns>

        public int fastPowerSolver(int a, int b, int n)
        {
            if (n == 0)
            {
                return 1 % b;
            }

            if (n == 1)
            {
                return a % b;
            }

            long product = fastPowerSolver(a, b, n / 2);
            product = (product * product) %b;
            if (n%2 == 0)
            {
                return (int)product;
            }
            return (int)((product * a) %b);

            
        }
    }
}
