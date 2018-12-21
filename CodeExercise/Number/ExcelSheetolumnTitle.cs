using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class ExcelSheetolumnTitle
    {
        /// <summary>
        /// 168. Excel Sheet Column Title
        /// https://leetcode.com/problems/excel-sheet-column-title/
        /// Given a positive integer, return its corresponding column title as appear in an Excel sheet.
        /// 
        /// For example:
        /// 
        ///     1 -> A
        ///     2 -> B
        ///     3 -> C
        ///     ...
        ///     26 -> Z
        ///     27 -> AA
        ///     28 -> AB
        ///     ...
        /// Example 1:
        /// 
        /// Input: 1
        /// Output: "A"
        /// Example 2:
        /// 
        /// Input: 28
        /// Output: "AB"
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string ConvertToTitle(int n)
        {
            Dictionary<int, char> lookup = new Dictionary<int, char>();
            char c = 'A';
            for (int i = 0; i <= 25; i++)
            {
                lookup.Add(i, c);
                c++;
            }

            return Helper(n, lookup);

        }
        private string Helper(int n, Dictionary<int, char> lookup)
        {
            n--;  // start from 0 idx
            if (n <= 25)
            {
                return lookup[n % 26].ToString();
            }


            var higher = Helper((n) / 26, lookup);

            return higher + lookup[n % 26];
        }
    }
}
