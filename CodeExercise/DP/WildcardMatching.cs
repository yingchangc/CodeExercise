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
        /// 
        /// sol:
        /// 
        ///  if (B[j] == '*')
        ///     F[i,j] =    F[i,j-1]     match 0
        ///              || F[i-1,j-1] match 1
        ///              || F[i-1,j] match multiple
        ///              
        /// else if (B[j] =='?')
        ///   F[i,j] = F[i-1,j-1]
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            int M = s.Length;
            int N = p.Length;
            bool[,] F = new bool[M + 1, N + 1];

            for (int i = 0; i <=M; i++)
            {
                for (int j = 0; j <=N; j++)
                {
                    //base condition
                    if (i == 0 && j == 0)
                    {
                        F[i, j] = true;
                    }
                    else if (j ==0)
                    {
                        F[i, j] = false;        // "ab" <--""
                    }
                    else if (i == 0)
                    {
                        if (p[j-1] == '*')
                        {
                            F[i, j] = F[i, j - 1];   // ""  <- "*"
                        }
                        else
                        {
                            F[i, j] = false;   // ""  "?"
                        }
                    }
                    else
                    {
                        if (s[i-1] == p[j-1] || p[j-1] == '?')
                        {
                            F[i, j] = F[i - 1, j - 1];
                        }
                        else if (p[j-1] == '*')
                        {
                            bool match0 = F[i, j - 1];  // match 0 char case   "ab" <- "ab*"
                            bool match1 = F[i-1, j-1];   // match 1 cahr case    "ab"  <- "a*"
                            bool match2 = F[i - 1, j];    // match multi char case "abc"  <- "a*"

                            F[i, j] = match0 || match1 || match2;   
                        }
                        else
                        {
                            F[i, j] = false;    // "abc" <-- "abx"
                        }
                    }
                }
            }

            return F[M, N];
        }

        public bool IsMatch_recursive2(string s, string p)
        {
            int M = s.Length;
            int N = p.Length;
            bool[,] visited = new bool[M, N];

            bool[,] F = new bool[M, N];

            var ans = IsMatchHelper2(s, p, visited, F, 0, 0);

            return ans;
        }

        private bool IsMatchHelper2(string s, string p, bool[,] visited,  bool[,] memo, int i, int j)
        {
            int sLen = s.Length;
            int pLen = p.Length;
            if (i == sLen && j == pLen)  // both ran out
            {
                return true;
            }

            if (j == p.Length)   // yic: only pattern ran out
            {
                return false;
            }
            if (i == s.Length)  // yic s ran out
            {
                if (p[j] == '*')
                {
                    return IsMatchHelper2(s, p, visited, memo, i, j + 1);  // match 0 case
                }
                return false;
            }

            if (visited[i,j])
            {
                return memo[i, j];
            }

            bool canMatch = false;

            if (s[i] == p[j])
            {
                canMatch = IsMatchHelper2(s, p, visited, memo, i + 1, j + 1);
            }
            else if (p[j] == '?')
            {
                canMatch = IsMatchHelper2(s, p, visited, memo, i + 1, j + 1);
            }
            else if (p[j] == '*')
            {
                canMatch = IsMatchHelper2(s, p, visited, memo, i, j + 1)   // match 0
                        || IsMatchHelper2(s, p, visited, memo, i+1, j + 1)   // match 1
                        || IsMatchHelper2(s, p, visited, memo, i+1, j);  // match many
            }
            else
            {
                //s[i]!=p[j]
                canMatch = false;
            }
            visited[i, j] = true;
            memo[i, j] = canMatch;

            return canMatch;
        }


        public bool IsMatch_recursive(string s, string p)
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
