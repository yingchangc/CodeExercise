using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class WildcardMatching
    {
        /// <summary>
        /// 44
        /// https://leetcode.com/problems/wildcard-matching/description/
        /// 
        /// '?' Matches any single character.
        /// '*' Matches any sequence of characters(including the empty sequence).
        /// 
        /// The matching should cover the entire input string (not partial).
        /// 
        /// The function prototype should be:
        /// bool isMatch(const char* s, const char* p)
        /// 
        /// Some examples:
        /// isMatch("aa","a") → false
        /// isMatch("aa","aa") → true
        /// isMatch("aaa","aa") → false
        /// isMatch("aa", "*") → true
        /// isMatch("aa", "a*") → true
        /// isMatch("ab", "?*") → true
        /// isMatch("aab", "c*a*b") → false
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            int M = s.Length;
            int N = p.Length;
            bool[,] visited = new bool[M+1, N+1];

            bool[,] F = new bool[M + 1, N + 1];

            var ans = IsMatchHelper(s, p, visited, F, M, N);

            return ans;
        }

        private bool IsMatchHelper(string s, string p, bool[,] visited, bool[,] F, int i , int j)
        {
            // base condidition
            if (i ==0 & j == 0)
            {
                return true;
            }
            else if (i == 0)
            {
                if (p[j-1] == '*')    // yic corner case   for "ab"  <-- "**ab",  need to keep walk down
                {
                    return IsMatchHelper(s, p, visited, F, i, j - 1);
                }
                return false;
            }
            else if (j == 0)   // i >0   j==0
            {
                return false;
            }
            else if (visited[i,j])
            {
                return F[i, j];
            }

            visited[i, j] = true;
            
            // char matching
            if (s[i-1] == p[j-1])
            {
                F[i, j] = IsMatchHelper(s,p,visited,F,i-1,j-1);    
            }
            else if (p[j-1] == '?')
            {
                F[i, j] = IsMatchHelper(s, p, visited, F, i - 1, j - 1);
            }
            else if (p[j-1] == '*')
            {
                F[i, j] = IsMatchHelper(s, p, visited, F, i, j - 1) // pattern  0 match   "ab" <-- "ab*"
                        || IsMatchHelper(s, p, visited, F, i - 1, j - 1)  // pattern  1 match   "ab" <-- "a*"
                        || IsMatchHelper(s, p, visited, F, i-1, j);    // pattern multi mathc  "abb"  <-- "a*"  
            }
            else
            {
                F[i, j] = false;
            } 


            return F[i, j];
        }
    }
}
