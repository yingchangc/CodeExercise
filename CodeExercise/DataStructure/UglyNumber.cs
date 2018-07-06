using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class UglyNumber
    {
        /// <summary>
        /// 263. Ugly Number
        /// https://leetcode.com/problems/ugly-number/description/
        /// Write a program to check whether a given number is an ugly number.
        /// 
        /// Ugly numbers are positive numbers whose prime factors only include 2, 3, 5.
        /// 
        /// Example 1:
        /// 
        /// Input: 6
        /// Output: true
        /// Explanation: 6 = 2 × 3
        /// Example 2:
        /// 
        /// Input: 8
        /// Output: true
        /// Explanation: 8 = 2 × 2 × 2
        /// Example 3:
        /// 
        /// Input: 14
        /// Output: false 
        /// Explanation: 14 is not ugly since it includes another prime factor 7.
        /// Note:
        /// 
        /// 1 is typically treated as an ugly number.
        /// Input is within the 32-bit signed integer range: [−231,  231 − 1].
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsUgly(int num)
        {
            if (num == 0)
            {
                return false;
            }

            while(num%5 == 0)
            {
                num /= 5;
            }

            while(num%3 == 0)
            {
                num /= 3;
            }
            while(num%2 == 0)
            {
                num /= 2;
            }

            return num == 1;
        }

        class IntComparer : IComparer<long>
        {
            public int Compare(long x, long y)
            {
                return x.CompareTo(y);
            }
        }

        /// <summary>
        /// 264. Ugly Number II
        /// https://leetcode.com/problems/ugly-number-ii/description/
        /// 
        /// Write a program to find the n-th ugly number.
        /// Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 
        /// 
        /// Example:
        /// 
        /// Input: n = 10
        /// Output: 12
        /// Explanation: 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.
        /// Note:  
        /// 
        /// 1 is typically treated as an ugly number.
        /// n does not exceed 1690.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n)
        {
            SortedSet<long> pq = new SortedSet<long>(new IntComparer());
            pq.Add(1);

            int count = 0;
            long top = 1;
            while(count < n)
            {

                top = pq.First();
                pq.Remove(top);
                pq.Add(top * 5);
                pq.Add(top * 2);
                pq.Add(top * 3);

                count++;
            }

            return (int)top;

        }
    }
}
