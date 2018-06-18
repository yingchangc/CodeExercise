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
            List<string> ans = new List<string>();
            DFSHelper(s, 0, 0, "", ans);
            return ans.ToArray();
        }

        private void DFSHelper(string s, int index, int section, string currPath, List<string> ans)
        {
            if (section == 4 && index >= s.Length) 
            {
                // remove the head '.'
                string copy = currPath.Substring(1);
                ans.Add(copy);

                return;
            }
            else if (index >= s.Length && section != 4)
            {
                return;
            }
            else if (section > 4)
            {
                return;
            }

            for (int i = index; i < s.Length; i++)
            {
                // only check 3 position
                if (i > index+3)
                {
                    break;
                }

                string substr = s.Substring(index, i - index + 1);
                int val = Convert.ToInt32(substr);

                if (val < 256)
                {
                    currPath += ("." + substr);
                    DFSHelper(s, i + 1, section + 1, currPath, ans);
                    currPath= currPath.Substring(0,currPath.Length - ("." + substr).Length);
                }
            }
        }
    }
}
