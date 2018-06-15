using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class SplitString
    {
        /// <summary>
        /// 680. Split String
        /// https://www.lintcode.com/problem/split-string/description
        /// 
        /// Give a string, you can choose to split the string after one character or two adjacent characters, and make the string to be composed of only one character or two characters.Output all possible results.
        /// 
        /// Example
        /// Given the string "123"
        /// return [["1","2","3"], ["12","3"], ["1","23"]]
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public List<List<string>> SplitStringSolver(string s)
        {
            List<List<string>> results = new List<List<string>>();


            if (!string.IsNullOrEmpty(s))
            {
                List<string> currRes = new List<string>();
                SplitStringHelper(s, results, currRes);
            }

            return results;
        }

        public void SplitStringHelper(string s, List<List<string>> results, List<string> currRes)
        {
            if (string.IsNullOrEmpty(s))
            {
                List<string> copy = new List<string>(currRes);
                results.Add(copy);
                return;
            }

            // take 1 char
            string substr1 = s.Substring(0, 1);
            currRes.Add(substr1);
            string substr2 = s.Substring(1);
            SplitStringHelper(substr2, results, currRes);
            currRes.RemoveAt(currRes.Count-1);  // recover
            
            // take 2 char
            if (s.Length > 1)
            {
                string substr3 = s.Substring(0, 2);
                currRes.Add(substr3);
                string substr4 = s.Substring(2);
                SplitStringHelper(substr4, results, currRes);
                currRes.RemoveAt(currRes.Count - 1);  // recover
            }
        }
    }
}
