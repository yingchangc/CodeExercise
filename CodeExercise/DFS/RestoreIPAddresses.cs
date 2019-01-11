using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class RestoreIPAddresses
    {
        /// <summary>
        /// 93. Restore IP Addresses
        /// https://leetcode.com/problems/restore-ip-addresses/description/
        /// Given a string containing only digits, restore it by returning all possible valid IP address combinations.
        /// 
        /// Example:
        /// 
        /// Input: "25525511135"
        /// Output: ["255.255.11.135", "255.255.111.35"]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RestoreIpAddressesSolver(string s)
        {
            return DFSHelper(s, 0, new Dictionary<string, List<string>>());
        }

        // memo replies on curr "string" and "level"
        private List<string> DFSHelper(string s, int level, Dictionary<string, List<string>> memo)
        {
            List<string> ans = new List<string>();

            if (level == 4)
            {
                if (s.Length == 0)
                {
                    ans.Add("");
                    return ans;
                }
                return ans;
            }

            var key = s + "," + level; 

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            // take number
            for (int i = 1; i <= 3 && i <= s.Length; i++)   // yic "&& i <= s.Length"
            {
                var num = int.Parse(s.Substring(0, i));
                if (i == 2 && !(num >= 10 && num <= 99))
                {
                    continue;
                }
                if (i == 3 && !(num >= 100 && num <= 255))
                {
                    continue;
                }

                List<string> subnum = DFSHelper(s.Substring(i), level + 1, memo);

                foreach (var subn in subnum)
                {
                    if (subn != "")
                    {
                        ans.Add(num + "." + subn);
                    }
                    else
                    {
                        ans.Add(num.ToString());
                    }
                }
            }

            memo.Add(key, ans);

            return ans;
        }
        
    }
}
