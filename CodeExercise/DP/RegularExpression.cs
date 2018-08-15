using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class RegularExpression
    {
        /// <summary>
        /// 10
        /// https://leetcode.com/problems/regular-expression-matching/description/
        /// '.' Matches any single character.
        /// '*' Matches zero or more of the preceding element.
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
        /// isMatch("aa", "a*") → true
        /// isMatch("aa", ".*") → true
        /// isMatch("ab", ".*") → true
        /// isMatch("aab", "c*a*b") → true
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
                for (int j =0; j <=N; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        F[i, j] = true;
                    }
                    else if (j == 0)
                    {
                        F[i, j] = false;
                    }
                    else if (i == 0)
                    {
                        if (p[j-1] == '*')  // match 0 case;
                        {
                            F[i, j] = F[i, j - 2];
                        }
                        else
                        {
                            F[i, j] = false;    // ""  <-- "xafd"
                        }
                    }
                    else
                    {
                        if (s[i-1] == p[j-1] || p[j-1] == '.')
                        {
                            F[i, j] = F[i - 1, j - 1];
                        }
                        else if (p[j-1] == '*')
                        {
                            bool match0 = F[i, j - 2];      // match 0    "ab"  "abc*"
                            bool match1 = false;
                            bool match2 = false;
                            if (s[i-1] == p[j-2]  || p[j-2] == '.')
                            {
                                match1 = F[i - 1, j - 2];  // match 1 char     "abc"  "abc*"
                                match2 = F[i - 1, j];      // match multiple char   "abcc"  "abc*"
                            }

                            F[i,j] = match1 || match2 || match0;
                        }
                        else
                        {
                            F[i, j] = false;    // "abc"  "abd"
                        }
                    }
                }
            }

            return F[M, N];
        }

        /// <summary>
        /// sol: reverse check because  .*
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch_recursive(string s, string p)
        {
            int M = s.Length;
            int N = p.Length;
            bool[,] F = new bool[M, N];
            bool[,] visited = new bool[M, N];

            bool ans = IsMatchHelper(s, p, F, visited, M-1, N-1);
            return ans;

        }

        private bool IsMatchHelper(string s, string p, bool [,] F, bool[,] visited, int i, int j)
        {
            if (i < 0 & j < 0)
            {
                return true;
            }
            if (i < 0)
            {
                if (p[j] == '*')
                {
                    return IsMatchHelper(s, p, F, visited, i, j-2);  // assume th patern is valid,   s""  p "a*"
                }
                else
                {
                    return false;
                }
            }
            else if (j < 0)   // i != 0  & j==0
            {
                return false;
            }   

            if (visited[i,j])
            {
                return F[i, j];
            }

            if (s[i] == p[j])
            {
                F[i, j] = IsMatchHelper(s, p, F, visited, i - 1, j - 1);
            }
            else if (p[j] == '.')   // match any single char
            {
                F[i, j] = IsMatchHelper(s, p, F, visited, i - 1, j - 1);
            }
            else if (p[j] == '*')
            {
                bool match0 = IsMatchHelper(s, p, F, visited, i, j - 2);   // match 0 case
                bool match1 = false;
                bool match2 = false;

                if (p[j-1] == s[i] || p[j-1] == '.')   // yic: remember char need to match before going down
                {
                    match1 = IsMatchHelper(s, p, F, visited, i - 1, j - 2); // match 1 case    abc   <-- ab.*  | abc*
                    match2 = IsMatchHelper(s, p, F, visited, i - 1, j);   // match multi case
                }
                

                F[i, j] = match0 || match1 || match2;
            }
            else
            {
                F[i, j] = false;
            }

            visited[i, j] = true;

            return F[i, j];
        }
    }
}
