using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class DecodeWays
    {
        /// <summary>
        /// 91
        /// https://leetcode.com/problems/decode-ways/description/
        /// http://zxi.mytechroad.com/blog/dynamic-programming/leetcode-91-decode-ways/
        /// A message containing letters from A-Z is being encoded to numbers using the following mapping: 
        ///'A' -> 1
        ///'B' -> 2
        ///...
        ///'Z' -> 26
        ///Given an encoded message containing digits, determine the total number of ways to decode it.
        ///For example,
        ///Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12). 
        ///The number of ways decoding "12" is 2. 
        /// just like fib  https://www.ics.uci.edu/~eppstein/161/960109.html   and HouseRobber question
        /// "102213"
        /// memo array   each loc means the ways can decode so far
        ///                                                                                       [i-2]  [i-1]  i
        /// if curr[i]  curr[i-1]curr[i]  are valid    memo[i] = memo[i-1] + memo[i-2]  ex "12"     *      1    2"
        ///                                                                                   memo  0      1    (0+1)
        /// if curr[i]  valid  only,    ex "*01"   cannot take * "01"   so memo[i] = memo[i-1]                                                                                   
        /// if "curr[i-1]curr[i]" valid only,    ex "*10"   cannot take "*1" 0   so  memo[i] = memo[i-1]
        /// if curr[i] and curr[i-1]curr[i]  both not valid  "*00"  return 0 cannot decode
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || !isValidNum(s, 0, 0))   // cannot have "" or "012"
            {
                return 0;
            }

            int numPP = 1;   // for index -1    when i = 2    "20"  it need to take numPP:1    
            int numP = 1;    // for index 0; since is valid 

            int len = s.Length;
            int[] memo = new int[len];
            for (int i = 1; i < len; i++)
            {
                bool currValid = isValidNum(s, i, i);
                bool preCurrValid = isValidNum(s, i - 1, i);
                int currNum = 0;
                if (currValid && preCurrValid)
                {
                    currNum = numP + numPP;   // ex 3"12"  when i = 2
                }
                else if (currValid)
                {
                    currNum = numP;      // ex 2 0 2     when i = 2    i can only consider 20 "2"
                }
                else if (preCurrValid)
                {                         //       i
                    currNum = numPP;      //   3 2 0    when i = 2    it can only consider 3 "20"
                }
                else
                {
                    return 0;          // 3 0 0    when i =2   cannot decode
                }

                // move forward
                numPP = numP;
                numP = currNum;
            }

            return numP;
        }

        //can use index to improve substring
        private bool isValidNum(string s, int l, int r)
        {
            if (l == r)
            {
                return ((s[l] - '0') > 0  && (s[l] - '0')<=26);
            }
            else
            {
                // two char
                int num = (s[l] - '0')*10 + (s[r]-'0');
                return (num >= 10 && num <= 26);
            }
        }


        /// <summary>
        /// 91 slow
        /// https://leetcode.com/problems/decode-ways/description/
        /// http://zxi.mytechroad.com/blog/dynamic-programming/leetcode-91-decode-ways/
        /// A message containing letters from A-Z is being encoded to numbers using the following mapping: 
        ///'A' -> 1
        ///'B' -> 2
        ///...
        ///'Z' -> 26
        ///Given an encoded message containing digits, determine the total number of ways to decode it.
        ///For example,
        ///Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12). 
        ///The number of ways decoding "12" is 2. 
        ///
        /// https://stackoverflow.com/questions/33045579/how-to-calculate-big-o-of-dynamic-programming-memoization-algorithm
        ///        /// Here's how I understand where 3n + 1 comes from. For each value of n you only have to do the line 
        ///        memo[n] = getNumOfStepCombos(n - 1, memo) + getNumOfStepCombos(n - 2, memo) + getNumOfStepCombos(n-3, memo);
        ///        exactly once.This is because we are recording the results and only doing this line if the answer has not already been calculated.
        ///        Therefore, when we start with n == 5 we run that line exacly 5 times;
        /// O(n)
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodingsABitSlow(string s)
        {
            if (string.IsNullOrEmpty(s))    // don't forget this
            {
                return 0;
            }
            HashSet<string> lookup = new HashSet<string>();
            for (int i = 1; i <=26; i++)
            {
                lookup.Add(i.ToString());
            }
            Dictionary<string, int> memo = new Dictionary<string, int>();   // substring, count

            int ans = waysToDecode(s, lookup, memo);

            return ans;
        }

        private int waysToDecode(string s, HashSet<string> lookup, Dictionary<string, int> memo)
        {
            if (memo.ContainsKey(s))
            {
                return memo[s];
            }

            int len = s.Length;

            // stop/base condition
            if (len == 0)
            {
                // yic,  the whole str len == 0 case should be handle at top, this level means good stop
                // meet condition
                return 1;
            }
            else if (len == 1)
            {
                if (lookup.Contains(s))
                {
                    memo[s] = 1;
                    return 1;
                }
                return 0;
            }


            int currLevelWays = 0;
            // can cut either 1 char or 2 char case
            string firstCharString = s.Substring(0, 1);
            string noFirstCharString = s.Substring(1);

            if (lookup.Contains(firstCharString))
            {
                currLevelWays += waysToDecode(noFirstCharString, lookup, memo);
            }

            string first2Char = s.Substring(0, 2);
            string noFirst2CharString = s.Substring(2);
            if (lookup.Contains(first2Char))
            {
                currLevelWays += waysToDecode(noFirst2CharString, lookup, memo);
            }

            memo[s] = currLevelWays;

            return currLevelWays;

        }
    }
}
