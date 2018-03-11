using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BitManipulation
{
    class DivideTwoIntegers
    {
        /// <summary>
        /// 29
        /// https://leetcode.com/problems/divide-two-integers/description/
        /// 
        /// Divide two integers without using multiplication, division and mod operator.
        /// If it is overflow, return MAX_INT.
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                if (dividend < 0)
                {
                    return Int32.MaxValue;
                }
                return Int32.MaxValue;
            }

            if (dividend == 0)
            {
                return 0;
            }

            // overflow case
            if (dividend == Int32.MinValue && divisor == -1)
            {
                return Int32.MaxValue;
            }
            if (dividend == Int32.MinValue && divisor == 1)
            {
                // ans will be overflow (-2147483648) for long it will be 2147483648  and become minus for ans, so take care of it here.
                return Int32.MinValue;
            }

            bool isNegative = (dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0);

            int ans = 0;

            long noSign_dividend = ABS_num((long)dividend);
            long noSign_divisor = ABS_num((long)divisor);

            while (noSign_dividend >= noSign_divisor)
            {
                long currDivisor = noSign_divisor;
                int temp = 1;

                while (noSign_dividend >= currDivisor)
                {
                    noSign_dividend -= currDivisor;
                    ans += temp;
                    currDivisor <<= 1;
                    temp <<= 1;
                }
            }

            return isNegative ? ~ans + 1 : ans;
        }

        private long ABS_num(long num)
        {
            if (num >=0)
            {
                return num;
            }
            return ~num + 1;
        }
    }
}
