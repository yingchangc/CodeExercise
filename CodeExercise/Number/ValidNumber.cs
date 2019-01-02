using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class ValidNumber
    {
        /// <summary>
        /// 65. Valid Number
        /// Validate if a given string can be interpreted as a decimal number.
        /// 
        /// Some examples:
        /// "0" => true
        /// " 0.1 " => true
        /// "abc" => false
        /// "1 a" => false
        /// "2e10" => true
        /// " -90e3   " => true
        /// " 1e" => false
        /// "e3" => false
        /// " 6e-1" => true
        /// " 99e2.5 " => false
        /// "53.5e93" => true
        /// " --6 " => false
        /// "-+3" => false
        /// "95a54e53" => false
        /// 
        /// 
        /// sol
        /// We start with trimming.
        ///
        ///If we see[0 - 9] we reset the number flags.
        /// We can only see. if we didn't see e or .
        ///We can only see e if we didn't see e but we did see a number. We reset numberAfterE flag.
        ///We can only see + and - in the beginning and after an e
        /// any other character break the validation.
        ///At the and it is only valid if there was at least 1 number and if we did see an e then a number after it as well.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsNumber(string s)
        {
            bool hasSeenNumber = false;
            bool hasSeenPoint = false;
            //bool hasSeenSign = false;
            bool hasSeenExp = false;
            string str = s.Trim();  // remove leading and trailing spaces

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (Char.IsDigit(c))
                {
                    hasSeenNumber = true;
                }
                else if (c == 'E' || c == 'e')
                {//We can only see e if we didn't see e but we did see a number. We reset numberAfterE flag.
                    if (hasSeenExp || !hasSeenNumber)    // e3  is wromng
                    {
                        Console.WriteLine("error: Exp");
                        return false;
                    }
                    hasSeenExp = true;
                    hasSeenNumber = false;   // reset  for case  like "1e"
                }
                else if (c == '+' || c == '-')
                {//We can only see + and - in the beginning and after an e
                    if (i > 0 && (str[i - 1] != 'e' && str[i - 1] != 'E'))
                    {
                        Console.WriteLine("error: incorrect +/- position");
                        return false;
                    }
                }
                else if (c == '.')
                {//We can only see. if we didn't see e or .
                    if (hasSeenPoint || hasSeenExp)   // okay to have ".1"
                    {
                        Console.WriteLine("error: seen point");
                        return false;
                    }

                    hasSeenPoint = true;
                }
                else
                {
                    return false;
                }

            }

            return hasSeenNumber;
        }
    }
}
