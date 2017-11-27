using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    public class PalindromePartition
    {
        public static IList<IList<string>> Partition(string s)
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
