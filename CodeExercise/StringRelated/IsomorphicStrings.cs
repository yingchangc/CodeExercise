using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class IsomorphicStrings
    {
        /// <summary>
        /// 205. Isomorphic Strings
        /// https://leetcode.com/problems/isomorphic-strings/description/
        /// Given two strings s and t, determine if they are isomorphic.
        /// 
        /// Two strings are isomorphic if the characters in s can be replaced to get t.
        /// 
        /// All occurrences of a character must be replaced with another character while preserving the order of characters.No two characters may map to the same character but a character may map to itself.
        /// 
        /// Example 1:
        /// 
        /// Input: s = "egg", t = "add"
        ///        Output: true
        /// Example 2:
        /// 
        /// 
        ///        Input: s = "foo", t = "bar"
        ///        Output: false
        /// Example 3:
        /// 
        /// 
        ///        Input: s = "paper", t = "title"
        ///        Output: true
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsIsomorphic(string s, string t)
        {

            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, char> lookup = new Dictionary<char, char>();
            HashSet<char> used = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (lookup.ContainsKey(s[i]))
                {
                    char mustBe = lookup[s[i]];
                    if (t[i] != mustBe)
                    {
                        return false;
                    }
                }
                else
                {
                    //  s:ac  t:bb    
                    //  b has been used by some other char
                    if (used.Contains(t[i]))
                    {
                        return false;
                    }
                    lookup.Add(s[i], t[i]);
                    used.Add(t[i]);
                }

            }

            return true;
        }
    }
}
