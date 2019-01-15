using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MultiplyStrings
    {
        /// <summary>
        /// 43. Multiply Strings
        /// https://leetcode.com/problems/multiply-strings/
        /// 
        /// Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
        /// 
        /// Example 1:
        /// 
        /// Input: num1 = "2", num2 = "3"
        /// Output: "6"
        /// Example 2:
        /// 
        /// Input: num1 = "123", num2 = "456"
        /// Output: "56088"
        /// 
        /// sol 
        ///     max len is len1+len2+1
        ///     
        ///    8 8
        ///    1 1
        ///    
        ///      8  <-  loc at i+j  (0+0)
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            var ca1 = num1.ToCharArray();
            var ca2 = num2.ToCharArray();
            Array.Reverse(ca1);
            Array.Reverse(ca2);
            string str1 = new string(ca1);
            string str2 = new string(ca2);

            int len1 = str1.Length;
            int len2 = str2.Length;

            var prod = new int[len1 + len2 + 1];
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    int n1 = str1[i] - '0';
                    int n2 = str2[j] - '0';
                    prod[i + j] += n1 * n2;
                }
            }

            int carry = 0;
            for (int i = 0; i <= len1 + len2; i++)
            {
                int v = prod[i] + carry;
                carry = v / 10;
                int res = v % 10;
                prod[i] = res;
            }

            if (carry > 0)
            {
                prod[len1 + len2] = carry;
            }

            StringBuilder sb = new StringBuilder();

            bool hasNonZero = false;
            for (int i = len1 + len2; i >= 0; i--)
            {
                if (prod[i] == 0 && hasNonZero)
                {
                    sb.Append(prod[i]);
                }
                else if (prod[i] != 0)
                {
                    sb.Append(prod[i]);
                    hasNonZero = true;
                }
            }

            if (sb.Length == 0)
            {
                return "0";
            }

            return sb.ToString();

        }
    }
}
