using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class MinimumWindowSubsequence
    {
        /// <summary>
        /// 727. Minimum Window Subsequence
        /// https://leetcode.com/problems/minimum-window-subsequence/
        /// Given strings S and T, find the minimum (contiguous) substring W of S, so that T is a subsequence of W.
        /// 
        /// If there is no such window in S that covers all characters in T, return the empty string "". If there are multiple such minimum-length windows, return the one with the left-most starting index.
        /// 
        /// Example 1:
        /// 
        /// Input: 
        /// S = "abcdebdde", T = "bde"
        /// Output: "bcde"
        /// Explanation: 
        /// "bcde" is the answer because it occurs before "bdde" which has the same length.
        /// "deb" is not a smaller window because the elements of T in the window must occur in order.
        /// 
        /// 
        /// sol:
        /// [Time exceeded]
        /// use 2 ptr can make timout since every time we found T all, move to next, i, need to reset search T   O(n^2)
        /// 
        /// find a new start i,   remember to set j =i, score = T.Length
        /// 
        /// 遍历S，更新T的index
        /// 当找到T中最后一个字符后，退出当前遍历
        /// 对找到的window的size进行比较更新
        /// 以找到的window的左边界+1为新的起始位置位置继续找下一个window
        /// 
        /// [Faster DP]
        /// dp[i][j] stores the starting index of the substring where T has length i and S has length j.
        ///
        ///So dp[i][j would be:
        ///if T[j - 1] == S[i - 1], this means we could borrow the start index from dp[j - 1][i - 1] to make the current substring valid;
        ///else, we only need to borrow the start index from dp[j][i - 1]
        ///        which could either exist or not.
        /// 
        /// 
        ///    nu a  b  c  d  e  b  d  d  e
        /// nu  0 1  2  3  4  5  6  7  8  9
        ///  b -1-1  1                         1 take from diag
        ///  d -1
        ///  e -1 
        ///  
        /// 
        ///     nu a  b  c  d  e  b  d  d  e
        /// nu  0  1  2  3  4  5  6  7  8  9
        ///  b -1 -1  1  1  1  1  5  5  5  5                1 take from diag
        ///  d -1 -1 -1 -1  1  1  1  5  5                   5 take from both diag 
        ///  e -1 
        /// 
        /// 
        ///     nu a  b  c  d  e  b  d  d  e
        /// nu  0  1  2  3  4  5  6  7  8  9
        ///  b -1 -1  1  1  1  1  5  5  5  5                
        ///  d -1 -1 -1 -1  1  1  1  5  5  5                 
        ///  e -1 -1 -1 -1 -1 {1} 1  1  1 {5}    
        ///  
        /// 
        /// check the last row   {1} is starting idx, and e at loc 5     substring ({1}, 5-1)  find min len
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public string MinWindow(string S, string T)
        {
            int lenS = S.Length;
            int lenT = T.Length;

            int[,] F = new int[lenT + 1, lenS + 1];

            for (int i = 1; i <= lenS; i++)
            {
                F[0, i] = i;      // nu Target, very i len in S can be starting Idx
            }

            // T target,  nu S should always -1   
            for (int j = 1; j <= lenT; j++)
            {
                F[j, 0] = -1;
            }


            for (int j = 1; j <= lenT; j++)
            {
                for (int i = 1; i <= lenS; i++)
                {
                    if (S[i - 1] == T[j - 1])
                    {
                        F[j, i] = F[j - 1, i - 1];   // store starting idx stored from j-1, len i-1 len
                    }
                    else
                    {
                        F[j, i] = F[j, i - 1];
                    }
                }
            }

            int minStart = 0;
            int minLen = int.MaxValue;
            // check last row
            for (int i = 1; i <= lenS; i++)
            {
                if (F[lenT, i] >= 0)
                {
                    int start = F[lenT, i];
                    int len = i - start;

                    if (minLen > len)
                    {
                        minLen = len;
                        minStart = start;
                    }

                }
            }


            if (minLen < int.MaxValue)
            {
                return S.Substring(minStart, minLen);
            }

            return "";
        }
    }
}
