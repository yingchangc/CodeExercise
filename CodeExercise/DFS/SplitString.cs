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
        public List<List<string>> SplitStringSolverPractice(string s)
        {
            return DFSHelperPractice(s, new Dictionary<string, List<List<string>>>());

        }

        private List<List<string>> DFSHelperPractice(string s, Dictionary<string, List<List<string>>> memo)
        {
            if (string.IsNullOrEmpty(s))
            {
                return new List<List<string>>();
            }

            if (memo.ContainsKey(s))
            {
                return memo[s];
            }

            List<List<string>> currLevelAnss = new List<List<string>>();

            // take 1
            string curr1 = s.Substring(0, 1);
            if (s.Length == 1)
            {
                currLevelAnss.Add(new List<string>() { curr1 });
            }
            else
            {
                string nxt = s.Substring(1);
                var childLevelAnss = DFSHelperPractice(nxt, memo);
                foreach(var childLeveAns in childLevelAnss)
                {
                    List<string> temp = new List<string>();
                    temp.Add(curr1);
                    
                    foreach(var str in childLeveAns)
                    {
                        temp.Add(str);
                    }
                    currLevelAnss.Add(temp);
                }
            }

            // take 2
            if (s.Length ==2)
            {
                currLevelAnss.Add(new List<string>() { s });
            }
            
            if (s.Length >2)
            {
                string curr2 = s.Substring(0, 2);
                string nxt = s.Substring(2);

                var childLevelAnss = DFSHelperPractice(nxt, memo);
                foreach(var childLevelAns in childLevelAnss)
                {
                    List<string> temp = new List<string>();
                    temp.Add(curr2);
                    foreach(var str in childLevelAns)
                    {
                        temp.Add(str);
                    }
                    currLevelAnss.Add(temp);
                }
            }

            memo.Add(s, currLevelAnss);
            return currLevelAnss;
        }


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
