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

        

        public bool IsMatch_Recursive(string s, string p)
        {
            int lenS = s.Length;
            int lenP = p.Length;

            return DFSHelper(s, lenS - 1, p, lenP - 1, new bool[lenS, lenP]);
        }


        private bool DFSHelper(string s, int idxS, string p, int idxP, bool[,] visited)
        {
            if (idxS < 0 && idxP < 0)
            {
                return true;
            }

            if (idxP < 0)
            {
                return false;
            }

            if (idxS < 0)
            {
                if (p[idxP] == '*')
                {
                    return DFSHelper(s, idxS, p, idxP - 1, visited);
                }
                return false;
            }

            if (visited[idxS, idxP])
            {
                return false;
            }

            visited[idxS, idxP] = true;

            if (s[idxS] == p[idxP])
            {
                return DFSHelper(s, idxS - 1, p, idxP - 1, visited);
            }
            else if (p[idxP] == '?')
            {
                return DFSHelper(s, idxS - 1, p, idxP - 1, visited);
            }
            else if (p[idxP] == '*')
            {
                bool match0 = DFSHelper(s, idxS, p, idxP - 1, visited);
                bool match1 = DFSHelper(s, idxS - 1, p, idxP - 1, visited);
                bool matchM = DFSHelper(s, idxS - 1, p, idxP, visited);

                return match0 || match1 || matchM;
            }

            return false;
        }
    }
}
