using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class AddString
    {
        /// <summary>
        /// 415. Add Strings
        /// https://leetcode.com/problems/add-strings/
        /// Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
        /// 
        /// Note:
        /// 
        /// The length of both num1 and num2 is < 5100.
        /// Both num1 and num2 contains only digits 0-9.
        /// Both num1 and num2 does not contain any leading zero.
        /// You must not use any built-in BigInteger library or convert the inputs to integer directly.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string AddStrings(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            int i = len1 - 1;
            int j = len2 - 1;
            int carry = 0;

            StringBuilder sb = new StringBuilder();

            while (i >= 0 || j >= 0)
            {
                int v1 = i >= 0 ? num1[i] - '0' : 0;
                int v2 = j >= 0 ? num2[j] - '0' : 0;

                sb.Append(((v1 + v2 + carry) % 10).ToString());
                carry = (v1 + v2 + carry) / 10;
                i--;
                j--;
            }

            if (carry > 0)
            {
                sb.Append(1);
            }

            var arr = sb.ToString().ToCharArray();
            Array.Reverse(arr);

            return new String(arr);
        }
    }
}
