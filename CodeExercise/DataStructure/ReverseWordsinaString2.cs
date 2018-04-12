using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class ReverseWordsinaString2
    {
        /// <summary>
        /// 186. Reverse Words in a String II
        /// https://leetcode.com/problems/reverse-words-in-a-string-ii/description/
        ///  Given an input string, reverse the string word by word.A word is defined as a sequence of non-space characters.
        /// 
        /// The input string does not contain leading or trailing spaces and the words are always separated by a single space.
        /// 
        /// For example,
        /// Given s = "the sky is blue",
        /// return "blue is sky the".
        /// 
        /// sol:
        /// 
        /// step1 mirror all "eulb si yks eht"
        /// step2 mirror each word    note: can mirror space
        /// </summary>
        /// <param name="str"></param>
        public void ReverseWords(char[] str)
        {
            // this can hanlde empty arr case
            // step 1 mirror all
            Console.WriteLine(str);

            Rotate(str, 0, str.Length-1);
            Console.WriteLine(str);
            // step 2 rotate each word
            int len = str.Length;
            int start = 0;
            for (int i = 0; i < len; i++)
            {
                if (str[i] == ' ')
                {
                    Rotate(str, start, i - 1);
                    start = i + 1;  // yic : assume next is not space, if is, it will just rotate itself
                }
            }

            if (start < len)
            {
                Rotate(str, start, len - 1);
            }

            Console.WriteLine(str);
        }

        private void Rotate(char[] str, int i, int j)
        {
            while(i < j)
            {
                var temp = str[i];
                str[i] = str[j];
                str[j] = temp;
                i++;            // yic  easy to forget
                j--;
            }
        }
    }
}
