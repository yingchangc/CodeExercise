using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class LetterCombinationsPhoneNumber
    {
        Dictionary<char, List<char>> lookup;
        /// <summary>
        /// 17. Letter Combinations of a Phone Number
        /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
        /// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

        /// A mapping of digit to letters(just like on the telephone buttons) is given below.Note that 1 does not map to any letters.
        ///     Input: "23"
        /// Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return new List<string>().ToArray();
            }
            InitLookup();
            List<string> ans = new List<string>();
            DFSHelper(digits, 0, new StringBuilder(), ans);

            return ans.ToArray();
        }

        private void InitLookup()
        {
            lookup = new Dictionary<char, List<char>>();
            lookup.Add('2', new List<char>() { 'a', 'b', 'c' });
            lookup.Add('3', new List<char>() { 'd', 'e', 'f' });
            lookup.Add('4', new List<char>() { 'g', 'h', 'i' });
            lookup.Add('5', new List<char>() { 'j', 'k', 'l' });
            lookup.Add('6', new List<char>() { 'm', 'n', 'o' });
            lookup.Add('7', new List<char>() { 'p', 'q', 'r', 's' });
            lookup.Add('8', new List<char>() { 't', 'u', 'v' });
            lookup.Add('9', new List<char>() { 'w', 'x', 'y', 'z' });

        }

        private void DFSHelper(string digits, int index, StringBuilder sb,  List<string> ans)
        {
            if (index == digits.Length)
            {
                ans.Add(sb.ToString());

                return;
            }

            List<char> candidate;
            if (lookup.TryGetValue(digits[index], out candidate))
            {
                foreach(char c in candidate)
                {
                    sb.Append(c);

                    DFSHelper(digits, index + 1, sb, ans);

                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }
    }
}
