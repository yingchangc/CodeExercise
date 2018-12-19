using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class ScrambleString
    {
        /// <summary>
        /// 87
        /// https://leetcode.com/problems/scramble-string/description/
        /// Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively.
        /// Below is one possible representation of s1 = "great":
        ///
        ///        great
        ///       /    \
        ///      gr    eat
        ///     / \    /  \
        ///    g   r  e   at
        ///               / \
        ///              a   t
        ///    To scramble the string, we may choose any non-leaf node and swap its two children.
        ///
        ///    For example, if we choose the node "gr" and swap its two children, it produces a scrambled string "rgeat".
        ///
        ///        rgeat
        ///       /    \
        ///      rg     eat
        ///     / \    /  \
        ///    r   g  e   at
        ///               / \
        ///              a   t
        ///    We say that "rgeat" is a scrambled string of "great".
        ///
        ///    Similarly, if we continue to swap the children of nodes "eat" and "at", it produces a scrambled string "rgtae".
        ///
        ///        rgtae
        ///       /    \
        ///      rg     tae
        ///     / \    /  \
        ///    r   g  ta   e
        ///           / \
        ///          t    a
        ///    We say that "rgtae" is a scrambled string of "great".
        ///
        ///    Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1.
        ///    
        /// Sol:
        /// 
        /// F[i,j,w]  =  (F[i,j,k] && F[i+k,j+k,w-k])  || 
        ///              (F[i,j+w-k, w]) && F[i+w, j, w-k]       w = 2~N
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool IsScramble(string s1, string s2)
        {
            int M = s1.Length;
            int N = s2.Length;

            if (M!=N)
            {
                return false;
            }

            bool[,,] F = new bool[M, M, M+1];

            // 1 char case
            for (int i=0; i< M; i++)
            {
                for (int j =0; j<M; j++)
                {
                    F[i,j, 1] = (s1[i] == s2[j]);
                }
            }

            for (int w = 2; w <= M; w++)
            {
                for (int i = 0; i <=(M-w); i++)
                {
                    for (int j = 0; j <= (M - w); j++)
                    {
                        for (int k = 1; k < w; k++)     // offset loc to break the length w segment into 2   i... , i+k     k max is w-1 (offset)   
                        {
                            bool sameL = F[i, j, k];
                            bool sameR = F[i + k, j + k, w - k];
                            bool swapL = F[i, j + w - k, k];
                            bool swapR = F[i + k, j, w - k];

                            
                            F[i, j, w] = (sameL && sameR) || (swapL && swapR);

                            if (F[i, j, w] == true)
                            {
                                break;
                            }
                        }
                    }

                        
                } 
                
            }

            // ask i=0 j=0  total length is T/F
            return F[0, 0, M];
        }
    }
}
