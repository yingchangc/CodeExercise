using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    public class EditDistance
    {
        /// <summary>
        /// 161. One Edit Distance
        /// https://leetcode.com/problems/one-edit-distance/description/
        /// Given two strings S and T, determine if they are both one edit distance apart.
        /// 
        /// Sol:
        /// 
        /// [delete]
        ///    in    marts  
        ///target     mart
        /// 
        /// [Insert]
        ///    in   mart
        ///  target marts
        ///  
        /// [Replace]
        ///    in  mart
        /// target mark

        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsOneEditDistance(string s, string t)
        {
            int M = s.Length;
            int N = t.Length;

            if (Math.Abs(M-N) > 1)
            {
                return false;
            }

            
            return IsOneEditDistanceHelper(s, t);
        }


        // helper input guarantee (s.len - t.len) <=1
        private static bool IsOneEditDistanceHelper(string s, string t)
        {
            if (s == t)
            {
                return false;
            }

            int i = s.Length-1;   // index  off len by 1
            int j = t.Length-1;

            

            while (i >=0 && j >=0)
            {
                if (s[i] == t[j])
                {
                    i--;
                    j--;
                }
                else
                {
                    // delete case
                    if (s.Substring(0, i) == t.Substring(0,j+1))   // yic note both s   i for len  current len-1, j+1 is totla len
                    {
                        return true;
                    }
                    // insert case
                    else if ((s.Substring(0,i+1) + t[j]) == t.Substring(0, j + 1))
                    {
                        return true;
                    }
                    // replace case
                    else if ((s.Substring(0,i) + t[j]) == t.Substring(0, j + 1))
                    {
                        return true;
                    }
                    return false;
                }
            }

            // since s len is greater than t by 1, if diff, this fit 1 delete case; otherwise s==t, is not one edit 
            return s != t;
            
        }


        /// <summary>
        /// * Time complexity is O(m*n)
        /// * Space complexity is O(m* n)
        /// https://www.youtube.com/watch?v=We3YDTzNXEk
        /// https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/EditDistance.java
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static int[,] ConstructMemorizationMatrix(string s1, string s2)
        {
            int len1 = s1.Length;
            int len2 = s2.Length;
            int[,] res = new int[len1+1, len2+1];
            
            //                  null 
            //                   0  1 2 3 ... len1
            // pre fill the null 0  
            for (int i = 0; i <= len1; i++)
            {
                res[i,0] = i;
            }

            for (int j = 0; j <= len2; j++)
            {
                res[0,j] = j;
            }

            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    
                    if (s1[i-1] == s2[j-1])
                    {
                        res[i, j] = res[i - 1, j - 1];  //* must use diag to take previous [i-1,j-1] best conclude steps
                    }
                    else
                    {
                        int minOfTopToLeftCorner = Math.Min(res[i - 1, j - 1], Math.Min(res[i - 1, j], res[i, j - 1]));
                        res[i, j] = minOfTopToLeftCorner + 1;
                    }
                }
            }

            printOutArray(res, len1+1, len2+1);
            return res;
        }

        private static void printOutArray(int[,] arr, int len1, int len2)
        {
            for (int j = 0; j < len2; j++)
            {
                for (int i = 0; i<len1; i++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void FindDistanceAndPrint(string s1, string s2)
        {
            int[,] resArray = ConstructMemorizationMatrix(s1, s2);

            int len1 = s1.Length;
            int len2 = s2.Length;

            Console.WriteLine("Distance is {0}", resArray[len1, len2]); // note for extra initial row and col

            // print out what to change
            int i = len1;
            int j = len2;
            while(i > 0 && j >0)
            {
                // match
                if (s1[i-1] == s2[j-1])  // index -1 
                {
                    i--;
                    j--;
                }
                else
                {
                    //min from Diag
                    if (resArray[i, j] == (resArray[i - 1, j - 1] + 1))
                    {
                        Console.WriteLine("string2 @{0} need to replace to with {1}", j-1, s1[i - 1]); //string index need to -1
                        i--;
                        j--;
                    }
                    // min from left
                    else if (resArray[i, j] == (resArray[i - 1, j] + 1))
                    {
                        Console.WriteLine("string2 @{0} need to insert to with {1}", j-1, s1[i - 1]);
                        i--;
                    }
                    // min from top
                    else
                    {
                        Console.WriteLine("string2 @{0} need to remove {1}", i-1, s2[j - 1]);
                        j--;
                    }
                }
            }
            
        }
    }
}
