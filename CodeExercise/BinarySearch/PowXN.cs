using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class PowXN
    {
        /// <summary>
        /// 50. Pow(x, n)
        /// https://leetcode.com/problems/powx-n/description/
        /// Implement pow(x, n), which calculates x raised to the power n (xn).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double MyPow(double x, int n)
        {
            if (x ==0)
            {
                return x;
            }

            if (n == 0)
            {
                return 1;
            }
            else if (n < 0)
            {
                // yic
                //max 2147483647
                //min -2147483648
                if (n == Int32.MinValue)     
                {
                    return MyPow(Math.Abs(1 / x), Int32.MaxValue);  // -2147483648  -> 2147483647   if - value, the final is positive
                }
                return MyPow(1 / x, -n);
            }          
            
            
            return powerHelper(x, n);
        }

        private double powerHelper(double x, int n)
        {
            if (n == 1)
            {
                return x;
            }
            double half = powerHelper(x, n / 2);

            if (n%2 == 0)
            {
                return half * half;
            }

            return half * half * x;

        }
    }
}
