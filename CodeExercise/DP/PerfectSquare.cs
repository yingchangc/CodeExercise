using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class PerfectSquare
    {
        /// <summary>
        /// 69
        /// Implement int sqrt(int x).

        /// Compute and return the square root of x.
        /// 
        /// x is guaranteed to be a non-negative integer.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            int left = 0;
            int right = x;
            while (left+1 < right)
            {
                int mid = left + (right - left) / 2;
                if ((long)mid * (long)mid == (long)x)
                {
                    return mid;
                }
                else if ((long)mid * (long)mid > (long)x)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }

            if ((long)right * (long)right <= (long)x)
            {
                return right;
            }
            
            return left;
        }

        /// <summary>
        /// 586
        /// http://www.lintcode.com/en/problem/sqrtx-ii/
        /// Implement double sqrt(double x) and x >= 0.         Compute and return the square root of x.
        /// Given n = 2 return 1.41421356
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double sqrt2(double x)
        {
            if (x < 0) return -1;
            double start = 0;
            double last = x;

            if (x < 1)
            {
                start = x;
                last = 1;
            }

            double precision = 0.000000001;

            while (true)
            {
                double mid = start + (last - start) / 2;
                double diff = mid * mid - x;
                if (mid * mid > x)
                {
                    last = mid;
                }
                else
                {
                    if (Math.Abs(diff) <= precision)
                    {
                        return mid;
                    }

                    start = mid;
                }
            }

        }

        /// <summary>
        /// 279
        /// Perfect Square
        /// https://leetcode.com/problems/perfect-squares/description/
        /// 
        /// Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.
        /// For example, given n = 12, return 3 because 12 = 4 + 4 + 4; given n = 13, return 2 because 13 = 4 + 9.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares(int n)
        {
            int[] F = new int[n + 1];
            F[0] = 0;
            for (int i = 1; i <=n; i++)
            {
                F[i] = Int32.MaxValue;
                for (int j = 1; j*j <= i; j++)
                {
                    F[i] = Math.Min(F[i], F[i - j * j] + 1);      // F[pre] is always smaller than Int32.Max  because F[2] = F[1] + 1
                }  
            }

            return F[n];
        }

        /// <summary>
        /// 367
        /// https://leetcode.com/problems/valid-perfect-square/description/
        /// Given a positive integer num, write a function which returns True if num is a perfect square else False.
        /// Note: Do not use any built-in library function such as sqrt.
        /// 
        /// Example 1:
        /// 
        /// Input: 16
        /// Returns: True
        /// Example 2:
        /// 
        /// Input: 14
        /// Returns: False
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsPerfectSquare(int num)
        {
            int start = 0;
            int last = num;

            while (start <= last)
            {
                int mid = start + (last - start) / 2;
                long midLongsqr = (long)mid * (long)mid;     //yic note must cast mid first, otherwise ,midLongsqr will be wrong

                if (midLongsqr == num)
                {
                    return true;
                }
                else if (midLongsqr > num )
                {
                    last = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }  
            }

            return false;
        }
    }
}
