using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BitManipulation
{
    class AddBinary
    {
        /// <summary>
        /// 67. Add Binary
        ///  https://leetcode.com/problems/add-binary/
        ///  Given two binary strings, return their sum (also a binary string).
        /// 
        /// The input strings are both non-empty and contains only characters 1 or 0.
        /// 
        /// Example 1:
        /// 
        /// Input: a = "11", b = "1"
        /// Output: "100"
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinarySovler(string a, string b)
        {
            int len1 = a.Length;
            int len2 = b.Length;

            int i = len1 - 1;
            int j = len2 - 1;

            int carry = 0;

            StringBuilder sb = new StringBuilder();

            while (i >= 0 || j >= 0)
            {
                int numA = i >= 0 ? a[i--] - '0' : 0;
                int numB = j >= 0 ? b[j--] - '0' : 0;
                int sum = numA + numB + carry;
                sb.Append(sum % 2);
                carry = sum / 2;
            }

            // yic 
            if (carry > 0)
            {
                sb.Append("1");
            }

            var arr = sb.ToString().ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }
    }
}
