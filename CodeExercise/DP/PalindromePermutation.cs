using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    public class PalindromePermutation
    {
        /// <summary>
        /// 267. Palindrome Permutation II
        /// Given a string s, return all the palindromic permutations (without duplicates) of it. Return an empty list if no palindromic permutation could be form.
        /// 
        /// Example 1:
        /// 
        /// Input: "aabb"
        /// Output: ["abba", "baab"]
        ///         Example 2:
        /// 
        /// Input: "abc"
        /// Output: []
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> GeneratePalindromes(string s)
        {
            Dictionary<char, int> lookup = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, 0);
                }
                lookup[c]++;
            }

            bool hasSingleOdd = false;

            List<string> ans = new List<string>();

            char oddChar = ' ';

            foreach (char c in lookup.Keys)
            {
                if (lookup[c] % 2 != 0)
                {
                    if (hasSingleOdd)
                    {
                        return ans;
                    }
                    hasSingleOdd = true;
                    oddChar = c;
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (char c in lookup.Keys)
            {
                for (int i = 0; i < lookup[c] / 2; i++)
                {
                    sb.Append(c);
                }
            }

            List<string> collection = Permute(sb.ToString());

            foreach (var str in collection)
            {
                char[] reverseChars = str.ToCharArray();
                Array.Reverse(reverseChars);
                if (hasSingleOdd)
                {
                    ans.Add(str + oddChar + new string(reverseChars));
                }
                else
                {
                    ans.Add(str + new string(reverseChars));
                }
            }

            return ans;

        }

        private List<string> Permute(string s)
        {
            List<string> collection = new List<string>();
            PermuteHelper(s.ToArray(), 0, collection);
            return collection;
        }

        private void PermuteHelper(char[] s, int index, List<string> collection)
        {
            if (index >= s.Length)
            {
                collection.Add(new string(s));
                return;
            }

            HashSet<char> visited = new HashSet<char>();

            for (int i = index;  i < s.Length; i++)
            {
                if (visited.Contains(s[i]))
                {
                    continue;
                }
                visited.Add(s[i]);

                Swap(s, index, i);
                PermuteHelper(s, index + 1, collection);
                Swap(s, i, index);
            }
        }

        private void Swap(char[] s, int i, int j)
        {
            char temp = s[i];
            s[i] = s[j];
            s[j] = temp;
        }



        /// <summary>
        /// palindrome permutation leetcode 267
        /// determine a string if its permutation can form palindrome
        /// 
        /// code  => false
        /// 
        /// carerac => true    (c a r e r a c)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CanPalidromePermute(string str)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var ch in str)
            {
                if (dic.ContainsKey(ch))
                {
                    // flip value
                    int val;
                    dic.TryGetValue(ch, out val);
                    if (val == 1)
                    {
                        val = 0;
                    }
                    else
                    {
                        val = 1;
                    }
                    dic[ch] = val;
                }
                else
                {
                    dic.Add(ch, 1);
                }
            }

            int sum = 0;

            foreach(var item in dic)
            {
                sum += (item.Value);
            }

            return sum <= 1 ? true : false;
        }
    }
}
