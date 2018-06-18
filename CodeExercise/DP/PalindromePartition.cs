using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    public class PalindromePartition
    {
        /// <summary>
        /// 132
        /// Given a string s, partition s such that every substring of the partition is a palindrome. 
        ///        Return the minimum cuts needed for a palindrome partitioning of s.
        ///        For example, given s = "aab",
        ///Return 1 since the palindrome partitioning["aa", "b"] could be produced using 1 cut.
        ///
        /// Sol  F[j] = min (F[i] where i: 0~j-1 and i to j is palindrome ) +1
        /// 
        /// O(n^2)
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// 
        public static int MinCut(string s)
        {
            int len = s.Length;

            bool[,] calPalindrome = computePalindrome(s);

            int[] F = new int[len+1];    // pre j how many segments, add padding for no char

            F[0] = 0;   

            for (int j = 1; j <= len; j++)
            {
                F[j] = Int32.MaxValue;
                for (int i=0; i <= j-1; i++)
                {
                    if (calPalindrome[i,j-1])
                    {
                        F[j] = Math.Min(F[i] + 1, F[j]);   // F[i] can never be int32.max  because it has been update to at mose number of chars
                    }  
                }
            }

            return F[len] - 1;  
        }

        private static bool[,] computePalindrome(string s)
        {
            int len = s.Length;
            bool[,] memo = new bool[len, len];   // init to all false
            for (int i = 0; i <len; i++)
            {
                // odd
                int mid = i;
                int left = mid;
                int right = mid;
                while(left >= 0 && right <len && s[left] == s[right])
                {
                    memo[left, right] |= true;
                    left--;
                    right++;
                }

                // even
                left = mid;
                right = mid+1;
                while (left >= 0 && right < len && s[left] == s[right])
                {
                    memo[left, right] |= true;
                    left--;
                    right++;
                }
            }

            return memo;   
        }

        public static int MinCut_old(string s)
        {
            bool[,] memorizationIsPalindromeArray = new bool[s.Length, s.Length];

            int[] memorizationCutNum = new int[s.Length];

            for (int j =0; j < s.Length; j++)
            {
                int minCutNum = j + 1;   // assume need to cut each element. try to increase i to find best cut
                for (int i = 0; i<=j; i++)
                {
                    if (s[i] == s[j] && (j - i) <= 1)
                    {
                        memorizationIsPalindromeArray[i, j] = true;
                        if (i == 0)
                        {
                            minCutNum = Math.Min(minCutNum, 0);      
                        }
                        else
                        {
                            minCutNum = Math.Min(minCutNum, 1 + memorizationCutNum[i - 1]);
                        }    
                    }
                    else if (s[i] == s[j] && (memorizationIsPalindromeArray[i + 1, j - 1] == true)) // j-1 >1  long sequence   c x x c
                    {                        // must have been processed since we have reached j, and i swip from 0 to j
                        memorizationIsPalindromeArray[i, j] = true;

                        if (i == 0)
                        {
                            minCutNum = Math.Min(minCutNum, 0);
                        }
                        else
                        {
                            minCutNum = Math.Min(minCutNum, 1 + memorizationCutNum[i - 1]);
                        }
                    }
                }

                // find thes min cut number after swipping i (as cut)
                memorizationCutNum[j] = minCutNum;
            }

            return memorizationCutNum[s.Length - 1];
        }

        public static int MinCutSlow(string s)
        {
            int[,] Cut = new int[s.Length, s.Length];

            for(int columnInc = 0; columnInc < s.Length; columnInc++)
            {
                for (int row=0; (row + columnInc) < s.Length; row++)
                {
                    int i = row;
                    int j = row + columnInc;

                    string substr = s.Substring(i, (j - i + 1));
                    if (isPalindrome(substr))
                    {
                        Cut[i, j] = 0;
                    }
                    else
                    {
                        int min = int.MaxValue;
                        for (int k = i; k <= j - 1; k++)
                        {
                            min = Math.Min(min, (Cut[i, k] + Cut[k + 1, j]));
                        }

                        Cut[i, j] = 1 + min;
                    }
                }
                
            }
            printCutArray(Cut,s);
            return Cut[0, s.Length - 1];
        }

        private static void printCutArray(int[,] cut, string s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                for(int j =0; j<s.Length; j++)
                {
                    Console.Write(cut[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 131
        /// Given a string s, partition s such that every substring of the partition is a palindrome. 
        ///        Return all possible palindrome partitioning of s.
        ///        For example, given s = "aab",
        /// Return
        /// [
        ///  ["aa","b"],
        ///  ["a","a","b"]
        ///]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IList<IList<string>> Partition(string s)
        {
            List<List<string>> ans = new List<List<string>>();
            List<string> currPath = new List<string>();
            DFSHelper1(s, ans, currPath, 0);
            return ans.ToArray();
        }

        private static void DFSHelper1(string s, List<List<string>> ans, List<string> currPath, int index)
        {
            if (index >= s.Length)
            {
                List<string> copy = new List<string>(currPath);
                ans.Add(copy);
                return;
            }

            for (int i = index; i < s.Length; i++)
            {
                if (IsPalindrome1(s, index, i))
                {
                    currPath.Add(s.Substring(index, (i - index + 1)));
                    DFSHelper1(s, ans, currPath, i + 1);
                    currPath.RemoveAt(currPath.Count - 1);    // remove
                }
            }
        }

        private static bool IsPalindrome1(string s, int left, int right)
        {
            while(left<right)
            {
                if (s[left] == s[right])
                {
                    left++;
                    right--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static IList<IList<string>> PartitionOld(string s)
        {
            List<List<string>> results = new List<List<string>>();
            List<string> path = new List<string>();
            PalindromePartitionHelper(s, 0, results, path);

            return results.ToArray();
        }

        private static void PalindromePartitionHelper(string s, int index, List<List<string>> results, List<string> path)
        {
            if (index == s.Length)
            {
                List<string> clone = new List<string>(path);
                results.Add(clone);
                return;
            }

            for(int i = index; i < s.Length; i++)
            {
                int subLen = (i - index) + 1;
                string sub = s.Substring(index, subLen);
                
                if (isPalindrome(sub))
                {
                    path.Add(sub);
                    PalindromePartitionHelper(s, i + 1, results, path);
                    path.RemoveAt(path.Count - 1);         //* YIC remove the last one from List<string>  can't path.Remove(sub) it will remove the first match from front.
                }
            }
        }

        private static bool isPalindrome(string s)
        {
            int start = 0;
            int last = s.Length - 1;

            while (start <= last)
            {
                if (s[start] != s[last])
                {
                    return false;
                }
                start++;
                last--;
            }

            return true;
        }
    }
}
