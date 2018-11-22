using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class RomanToInteger
    {
        /// <summary>
        /// 13. Roman to Integer
        /// https://leetcode.com/problems/roman-to-integer/description/
        /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        /// 
        /// Symbol Value
        /// I             1
        /// V             5
        /// X             10
        /// L             50
        /// C             100
        /// D             500
        /// M             1000
        /// For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.
        /// 
        /// Roman numerals are usually written largest to smallest from left to right.However, the numeral for four is not IIII. Instead, the number four is written as IV.Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:
        /// 
        /// I can be placed before V (5) and X(10) to make 4 and 9. 
        /// X can be placed before L(50) and C(100) to make 40 and 90. 
        /// C can be placed before D(500) and M(1000) to make 400 and 900.
        /// Given a roman numeral, convert it to an integer.Input is guaranteed to be within the range from 1 to 3999.
        /// 
        /// Example 1:
        /// 
        /// Input: "III"
        /// Output: 3
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            Dictionary<string, int> lookup = new Dictionary<string, int>();

            lookup.Add("M", 1000);
            lookup.Add("CM", 900);
            lookup.Add("D", 500);
            lookup.Add("CD", 400);
            lookup.Add("C", 100);
            lookup.Add("XC", 90);
            lookup.Add("L", 50);
            lookup.Add("XL", 40);
            lookup.Add("X", 10);
            lookup.Add("IX", 9);
            lookup.Add("V", 5);
            lookup.Add("IV", 4);
            lookup.Add("I", 1);

            return Helper(s, lookup);
        }

        private int Helper(string str, Dictionary<string, int> lookup)
        {
            if (str == null || string.IsNullOrEmpty(str))
            {
                return 0;
            }

            if (str.Length == 1)
            {
                return lookup[str];
            }

            string firstTwo = str.Substring(0, 2);
            if (lookup.ContainsKey(firstTwo))
            {
                int currNum = lookup[firstTwo];

                return currNum + Helper(str.Substring(2), lookup);
            }
            else
            {
                int currNum = lookup[str[0].ToString()];
                return currNum + Helper(str.Substring(1), lookup);
            }
        }
    }

    class IntegertoRoman
    {
        /// <summary>
        /// 12. Integer to Roman
        /// https://leetcode.com/problems/integer-to-roman/description/
        /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        /// 
        /// Symbol Value
        /// I             1
        /// V             5
        /// X             10
        /// L             50
        /// C             100
        /// D             500
        /// M             1000
        /// For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.
        /// 
        /// Roman numerals are usually written largest to smallest from left to right.However, the numeral for four is not IIII. Instead, the number four is written as IV.Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:
        /// 
        /// I can be placed before V (5) and X(10) to make 4 and 9. 
        /// X can be placed before L(50) and C(100) to make 40 and 90. 
        /// C can be placed before D(500) and M(1000) to make 400 and 900.
        /// Given an integer, convert it to a roman numeral.Input is guaranteed to be within the range from 1 to 3999.
        /// 
        /// Example 1:
        /// 
        /// Input: 3
        /// Output: "III"
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IntToRoman(int num)
        {
            Dictionary<int, string> lookup = new Dictionary<int, string>();
            
            lookup.Add(1000, "M");
            lookup.Add(900, "CM");
            lookup.Add(500, "D");
            lookup.Add(400, "CD");
            lookup.Add(100, "C");
            lookup.Add(90, "XC");
            lookup.Add(50, "L");
            lookup.Add(40, "XL");
            lookup.Add(10, "X");
            lookup.Add(9, "IX");
            lookup.Add(5, "V");
            lookup.Add(4, "IV");
            lookup.Add(1, "I");

            int start = 0;

            StringBuilder sb = new StringBuilder();


            int count = lookup.Keys.Count;

            foreach (int candidate in lookup.Keys)
            {
                while (num >= candidate)
                {
                    num -= candidate;
                    sb.Append(lookup[candidate]);
                }
            }

            return sb.ToString();

        }
    }
}
