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
            if (section == 4)
            {
                if (index >= s.Length)
                {
                    ans.Add(currPath.Substring(1)); // skip the first .
                }
                return;
            }

            

            for (int i = index; i < s.Length; i++)
            {
                string cutStr = s.Substring(index, i - index + 1);

                // invalid  00, 01 >255
                if (!isValildIP(cutStr))
                {
                    break;
                }

                DFSHelper(s, i + 1, section + 1, (currPath + "." + cutStr), ans);
            }
        }

        // yic  this is core of this question
        private bool isValildIP(string cutStr)
        {
            if (cutStr.Length > 1 && cutStr[0] == '0')
            {
                return false;
            }

            int val = Convert.ToInt32(cutStr);
            
            if (val > 255)
            {
                return false;
            }

            return true;
        }
    }
}
