using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    public class PalindromePartition
    {
        // start look into range j 
        // scan i : 0~ j     if S[i~j] is palindrome
        // F[j] = MIN(F[j], F[i-1] + 1)
        public int MinCutPractice_dp(string s)
        {

            int len = s.Length;

            int[] F = new int[s.Length + 1];

            for (int i = 0; i <= len; i++)
            {
                // cut all segments
                F[i] = i;
            }

            for (int j = 1; j <= len; j++)
            {
                for (int i = 1; i <= j; i++)
                {
                    if (IsPalindrome(s, i - 1, j - 1))
                    {
                        F[j] = Math.Min(F[j], F[i - 1] + 1);
                    }
                }
            }

            return F[s.Length] - 1;  // "a b c"   make 2 cut   a | b | c
        }

        private bool IsPalindrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        /// 132. Palindrome Partitioning II
        /// https://leetcode.com/problems/palindrome-partitioning-ii/
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
        public static int MinCutPractice(string s)
        {
            int len = s.Length;
            int[] F = new int[len+1];
            bool[,] calPalindrome = computePalindromeOutward(s);

            for (int i = 0; i <= len; i++)
            {
                F[i] = i;   // pre cut for all places
            }

            for(int i = 1; i <= s.Length; i++)
            {
                for(int j = i; j <=s.Length; j++)
                {
                    if (calPalindrome[i-1,j-1])
                    {
                        F[j] = Math.Min(F[j], F[i-1] + 1);
                    }
                }
            }

            return F[len]-1;

        }

        private static bool[,] computePalindromeOutward(string s)
        {
            int len = s.Length;
            bool[,] memo = new bool[len, len];

            for (int i = 0; i< len; i++)
            {
                //odd 
                int left = i;
                int right = i;

                while (left >= 0 && right < len)
                {
                    if (s[left] == s[right])
                    {
                        memo[left, right] = true;
                        left--;
                        right++;
                    }
                    else
                    {
                        break;
                    }
                }

                //even
                left = i;
                right = i + 1;

                while (left >= 0 && right < len)
                {
                    if (s[left] == s[right])
                    {
                        memo[left, right] = true;
                        left--;
                        right++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return memo;
             
        }

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
        /// 131. Palindrome Partitioning
        /// https://leetcode.com/problems/palindrome-partitioning/submissions/
        /// https://www.lintcode.com/problem/palindrome-partitioning/description
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
            bool[,] pLookup = IsPartitionLookup(s);
            var memo = new Dictionary<int, List<List<string>>>();
            var ans2= DFS(s, pLookup, 0, memo);
            return ans2.ToArray();
        }

        private static bool[,] IsPartitionLookup(string s)
        {
            bool[,] F = new bool[s.Length, s.Length];
            
            for (int len = 1; len <= s.Length; len++)
            {
                for (int i = 0; i <= s.Length-len; i++)
                {
                    int left = i;
                    int right = i + len - 1;
                    if (len ==1)
                    {
                        F[left, right] = true;
                    }
                    else if (len ==2)
                    {
                        if (s[left] == s[right])
                        {
                            F[left, right] = true;
                        }
                    }
                    else
                    {
                        if (s[left] == s[right])
                        {
                            F[left, right] = F[left + 1, right - 1];  // depends on smaller region
                        }
                    }
                }     
            }
            return F;
        }

        private static List<List<string>> DFS(string s, bool[,] pLookup, int idx, Dictionary<int, List<List<string>>> memo)
        {
            List<List<string>> ans = new List<List<string>>();

            if (idx >= s.Length)
            {
                var sub = new List<string>() { "" };
                ans.Add(sub);
                return ans;
            }

            if (memo.ContainsKey(idx))
            {
                return memo[idx];
            }

            for (int i = idx; i < s.Length; i++)
            {
                if (pLookup[idx, i] == true)
                {
                    var prefix = s.Substring(idx, i - idx + 1);
                    var suffix = s.Substring(i + 1);

                    if (string.IsNullOrEmpty(suffix))
                    {
                        var temp = new List<string>() { prefix};
                        ans.Add(temp);
                    }
                    else
                    {
                        var suffixCandidate = DFS(s, pLookup, i + 1, memo);
                        foreach (var candidiate in suffixCandidate)
                        {
                            var temp = new List<string>();
                            temp.Add(prefix);
                            temp.AddRange(candidiate);
                            ans.Add(temp);
                        }
                    }
                    
                }
            }

            memo.Add(idx, ans);

            return ans;

        }

        public IList<IList<string>> Partition131(string s)
        {

            List<List<string>> ans = new List<List<string>>();
            DFSHelper(s, ans, new List<string>());

            return ans.ToArray();
        }

        private void DFSHelper(string s, List<List<string>> ans, List<string> currPath)
        {
            if (string.IsNullOrEmpty(s))
            {
                // must copy ctor
                ans.Add(new List<string>(currPath));
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                string prefix = s.Substring(0, i + 1);
                if (IsPalindromeHelper(s, 0, i))
                {
                    currPath.Add(prefix);

                    DFSHelper(s.Substring(i + 1), ans, currPath);

                    currPath.RemoveAt(currPath.Count - 1);
                }
            }
        }

        private bool IsPalindromeHelper(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }
    }
}
