using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class LongPressedName
    {
        /// <summary>
        /// 925. Long Pressed Name
        /// https://leetcode.com/problems/long-pressed-name/
        /// Your friend is typing his name into a keyboard.  Sometimes, when typing a character c, the key might get long pressed, and the character will be typed 1 or more times.
        /// 
        /// You examine the typed characters of the keyboard.Return True if it is possible that it was your friends name, with some characters (possibly none) being long pressed.
        /// 
        /// 
        /// 
        /// Example 1:
        /// 
        /// Input: name = "alex", typed = "aaleex"
        ///       Output: true
        /// Explanation: 'a' and 'e' in 'alex' were long pressed.
        /// Example 2:
        /// 
        /// 
        /// Input: name = "saeed", typed = "ssaaedd"
        /// Output: false
        /// Explanation: 'e' must have been pressed twice, but it wasn't in the typed output.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typed"></param>
        /// <returns></returns>
        public bool IsLongPressedName(string name, string typed)
        {
            int len1 = name.Length;
            int len2 = typed.Length;

            int i = 0;
            int j = 0;
            while (i < len1 && j < len2)
            {
                if (name[i] == typed[j])
                {
                    i++;
                    j++;
                }
                else if (i > 0 && name[i - 1] == typed[j]) // i just finish pre
                {
                    j++;
                }
                else
                {
                    return false;
                }
            }

            if (i < len1)
            {
                return false;
            }

            if (j < len2)
            {
                while (j < len2 && name[i - 1] == typed[j])
                {
                    j++;
                }

                if (j < len2)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
