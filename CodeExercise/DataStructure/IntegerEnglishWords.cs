using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    // Snapchat
    class IntegerEnglishWords
    {
        Dictionary<int, string> lookup = new Dictionary<int, string>();
        Dictionary<int, string> digitlookup = new Dictionary<int, string>();
        /// <summary>
        /// 273. Integer to English Words
        /// https://leetcode.com/problems/integer-to-english-words/description/
        /// Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 2^31 - 1.   (~2GB)
        /// Input: 1,234,567,891
        /// Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }

            initLookup();

            string ans = "";
            int level = 0;
            while(num > 0)
            {
                var ThreeDigit = num % 1000;
                num /= 1000;

                var strThreeDigig = Process3Digit(ThreeDigit);

                if (strThreeDigig != string.Empty)
                {
                    string space = (ans == string.Empty) ? "" : " ";
                    ans = strThreeDigig + digitlookup[level] + space + ans;    // 1,000
                }
                level++;
            }

            return ans;
        }

        private void initLookup()
        {
            lookup.Add(0, "");
            lookup.Add(1, "One");
            lookup.Add(2, "Two");
            lookup.Add(3, "Three");
            lookup.Add(4, "Four");
            lookup.Add(5, "Five");
            lookup.Add(6, "Six");
            lookup.Add(7, "Seven");
            lookup.Add(8, "Eight");
            lookup.Add(9, "Nine");
            lookup.Add(10, "Ten");
            lookup.Add(11, "Eleven");
            lookup.Add(12, "Twelve");
            lookup.Add(13, "Thirteen");
            lookup.Add(14, "Fourteen");
            lookup.Add(15, "Fifteen");
            lookup.Add(16, "Sixteen");
            lookup.Add(17, "Seventeen");
            lookup.Add(18, "Eighteen");
            lookup.Add(19, "Nineteen");
            lookup.Add(20, "Twenty");
            lookup.Add(30, "Thirty");
            lookup.Add(40, "Forty");
            lookup.Add(50, "Fifty");
            lookup.Add(60, "Sixty");
            lookup.Add(70, "Seventy");
            lookup.Add(80, "Eighty");
            lookup.Add(90, "Ninety");

            digitlookup.Add(0, "");
            digitlookup.Add(1, " Thousand");
            digitlookup.Add(2, " Million");
            digitlookup.Add(3, " Billion");
        }

        /// <summary>
        ///  123
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string Process3Digit(int num)
        {
            if (num <= 20)
            {
                return lookup[num];
            }
            else if (num < 100)
            {
                var Tenth = lookup[num - num%10];   // 21 - 1  = 20
                var reminder = Process3Digit(num % 10);
                if (reminder != string.Empty)
                {
                    Tenth += " " + reminder;
                }
                return Tenth;
            }
            else // (num >= 100)
            {
                var valStr = lookup[num / 100] + " Hundred";
                var reminder = Process3Digit(num % 100);
                if (reminder != string.Empty)
                {
                    valStr += " " + reminder;
                }
                return valStr;
            }
        }


    }
}
