using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class DecodeString
    {
        /**
         * 
         * (yic)  deprecated. use  Check "DecodeWays"
         * 
 * Below is how we encode a string to number
 * 'a' -> 1
 * 'b' -> 2
 * ...
 * 'z' -> 26
 * 
 * Write a function to find number of ways to decode an encoded string
 * 
 * '12' -> return 2 ('ab' or 'l')
 
 *  1
 O(n)  time space
 **/
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 1;
            }


            int count = DFSHelper(s, new Dictionary<string, int>());
            return count;
        }

        private int DFSHelper(string s, Dictionary<string, int> visited)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 1;
            }

            if (visited.ContainsKey(s))
            {
                return visited[s];
            }

            int count = 0;

            if (IsValid1Char(s))
            {
                count += DFSHelper(s.Substring(1), visited);
            }

            if (IsValid2Char(s))
            {
                count += DFSHelper(s.Substring(2), visited);
            }

            visited[s] = count;

            return count;
        }

        private bool IsValid1Char(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            var num = int.Parse(s[0].ToString());

            if (num >= 1 && num <= 9)
            {
                return true;
            }
            return false;
        }

        private bool IsValid2Char(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2)
            {
                return false;
            }

            var num = int.Parse(s.Substring(0,2));

            if (num >= 10 && num <= 26)
            {
                return true;
            }
            return false;
        }

        /**
          * Node can be painted in two colors
          * Valid graph -> No adjacent nodes can be painted in the same color
          */

        
    }
}
