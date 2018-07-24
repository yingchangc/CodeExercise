using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class LongestPalindromicSubsequence
    {
        /// <summary>
        /// 516
        /// https://leetcode.com/problems/longest-palindromic-subsequence/description/
        /// Given a string s, find the longest palindromic subsequence's length in s. You may assume that the maximum length of s is 1000.
        ///Example 1:
        ///Input:
        ///
        ///"bbbab"
        ///Output:
        ///4
        ///One possible longest palindromic subsequence is "bbbb".
        /// sol:
        /// 
        /// F("bbbab")   = max (  F(bbba), F(bbab), F(bba) + 2 ie frontChar==lstChar b==b)
        /// 區間型  for by check length
        /// 
        /// create
        /// f[N,N]
        /// 
        /// init
        /// f[i,i]=1
        /// f[i,i+1] = 1 or 2
        /// 
        /// for len = 3 ~ len
        ///    for i = 3
        ///       f[i,i+len-1] = max (f[i, i+len-2], f[i+1, i+len-1])   and max with (f[i+1, i+len-2] + 2)
        ///
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestPalindromeSubseq(string s)
        {
            int N = s.Length;

            int[,] F = new int[N, N];

            int ans = 1;
            // single char
            for (int i = 0; i < N; i++)
            {
                F[i, i] = 1;
            }

            // 2 char
            for (int i = 0; i < N-1; i++)
            {
                if (s[i] == s[i+1])
                {
                    F[i, i + 1] = 2;
                    ans = 2;
                }
                else
                {
                    F[i, i + 1] = 1;
                }
            }
            

            for (int len = 3; len <= N; len++)   // yic note len<=N
            {
                for (int i = 0; i <= N-len; i++)
                {
                    F[i, i + len-1] = Math.Max(F[i, i + len-1 - 1], F[i + 1, i + len-1]);  // cut last, cut front

                    if (s[i] == s[i+len-1])  // front == last char
                    {
                        F[i, i + len - 1] = Math.Max(F[i, i + len - 1], F[i + 1, i + len - 1 - 1] + 2);    // 2+ middle
                    }

                    ans = Math.Max(ans, F[i, i + len - 1]);
                }
            }

            return ans;
        }
    }
}
