using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class FractionRecurringDecimal
    {
        /// <summary>
        /// 166. Fraction to Recurring Decimal
        /// https://leetcode.com/problems/fraction-to-recurring-decimal/
        /// Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
        /// 
        /// If the fractional part is repeating, enclose the repeating part in parentheses.
        /// 
        /// Example 1:
        /// 
        /// Input: numerator = 1, denominator = 2
        /// Output: "0.5"
        /// Example 2:
        /// 
        /// Input: numerator = 2, denominator = 1
        /// Output: "2"
        /// Example 3:
        /// 
        /// Input: numerator = 2, denominator = 3
        /// Output: "0.(6)"
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        public string FractionToDecimal(int numerator, int denominator)
        {
            bool ispostive = true;
            if ((numerator > 0 && denominator < 0) || (numerator < 0 && denominator > 0))
            {
                ispostive = false;
            }

            if (denominator == 0)
            {
                return ispostive ? "INF" : "-INF";
            }
            long absnum = numerator >= 0 ? numerator : (long)numerator * -1;
            long absden = denominator >= 0 ? denominator : (long)denominator * -1;
            var ans = AbsFractionToDecimal(absnum, absden);

            return ispostive ? ans : "-" + ans;
        }

        private string AbsFractionToDecimal(long numerator, long denominator)
        {
            StringBuilder sb = new StringBuilder();
            // integer part
            sb.Append(numerator / denominator);

            if (numerator % denominator == 0)
            {
                return sb.ToString();
            }

            sb.Append(".");

            // fractional part

            numerator = numerator % denominator;

            Dictionary<long, int> lookup = new Dictionary<long, int>();  // num, loc

            while (numerator > 0)
            {
                // 4 / 9
                numerator *= 10;

                if (lookup.ContainsKey(numerator))
                {
                    sb.Insert(lookup[numerator]-1, "(");
                    sb.Append(")");
                    break;
                }

                if (numerator < denominator)
                {
                    sb.Append("0");
                    lookup.Add(numerator, sb.Length);  // yic remember  0.4   len =3    when repeat happened, we know where to add (
                }
                else
                {
                    sb.Append(numerator / denominator);

                    lookup.Add(numerator, sb.Length);  // yic remember  0.4   len =3    when repeat happened, we know where to add (

                    numerator = numerator % denominator;
                }
            }
            return sb.ToString();
        }
    }
}
