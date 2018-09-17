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
        public void ReverseWordsPractice(char[] str)
        {
            // this can hanlde empty arr case
            // step 1 mirror all
            Console.WriteLine(str);

            Rotate(str, 0, str.Length - 1);
            Console.WriteLine(str);
            // step 2 rotate each word
            int len = str.Length;
            int i = 0;

            while(i <len)
            {
                while(i < len && str[i] == ' ')
                {
                    i++;
                }

                if (i < len)
                {
                    int nextSpaceIdx = findSpaceIdx(str, i);
                    Rotate(str, i, nextSpaceIdx - 1);

                    i = nextSpaceIdx;
                }
                
            }

            Console.WriteLine(str);
        }

        private int findSpaceIdx(char[] str, int startIdx)
        {
            int idx = startIdx;
            while(idx < str.Length)
            {
                if (str[idx] == ' ')
                {
                    break;
                }
                idx++;
            }

            // idx can be space idx or len+1
            return idx;
        }


        public void ReverseWords(char[] str)
        {
            // this can hanlde empty arr case
            // step 1 mirror all
            Console.WriteLine(str);

            Rotate(str, 0, str.Length-1);
            Console.WriteLine(str);
            // step 2 rotate each word
            int len = str.Length;
            int left = 0;
            int right = 0;
            while (left < len)
            {
                if (right == len || str[right] == ' ')
                {
                    Rotate(str, left, right - 1);

                    // reset left and right
                    right = right + 1;   // skip curr space
                    left = right;
                }
                else
                {
                    right++;
                }
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
