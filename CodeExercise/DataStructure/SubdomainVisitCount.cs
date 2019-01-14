using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class SubdomainVisitCount
    {
        /// <summary>
        /// 811. Subdomain Visit Count
        /// https://leetcode.com/problems/subdomain-visit-count/
        /// A website domain like "discuss.leetcode.com" consists of various subdomains. At the top level, we have "com", at the next level, we have "leetcode.com", and at the lowest level, "discuss.leetcode.com". When we visit a domain like "discuss.leetcode.com", we will also visit the parent domains "leetcode.com" and "com" implicitly.
        /// 
        /// Now, call a "count-paired domain" to be a count(representing the number of visits this domain received), followed by a space, followed by the address.An example of a count-paired domain might be "9001 discuss.leetcode.com".
        /// 
        /// We are given a list cpdomains of count-paired domains.We would like a list of count-paired domains, (in the same format as the input, and in any order), that explicitly counts the number of visits to each subdomain.
        /// 
        /// Example 2:
        /// Input: 
        /// ["900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"]
        ///         Output: 
        /// ["901 mail.com","50 yahoo.com","900 google.mail.com","5 wiki.org","5 org","1 intel.mail.com","951 com"]
        ///         Explanation: 
        /// We will visit "google.mail.com" 900 times, "yahoo.com" 50 times, "intel.mail.com" once and "wiki.org" 5 times.For the subdomains, we will visit "mail.com" 900 + 1 = 901 times, "com" 900 + 50 + 1 = 951 times, and "org" 5 times.
        /// </summary>
        /// <param name="cpdomains"></param>
        /// <returns></returns>
        public IList<string> SubdomainVisits(string[] cpdomains)
        {

            var lookup = new Dictionary<string, int>();

            foreach (string dm in cpdomains)
            {
                var dmTokens = dm.Split(' ');
                int freq = int.Parse(dmTokens[0]);
                string address = dmTokens[1];

                var addrTokens = address.Split('.');
                int len = addrTokens.Length;
                string addr = "";
                for (int i = len - 1; i >= 0; i--)
                {
                    if (addr == "")
                    {
                        addr = addrTokens[i];
                    }
                    else
                    {
                        addr = addrTokens[i] + "." + addr;
                    }

                    if (!lookup.ContainsKey(addr))
                    {
                        lookup.Add(addr, 0);
                    }
                    lookup[addr] += freq;
                }
            }

            var ans = new List<string>();

            foreach (var key in lookup.Keys)
            {
                string addr = key;
                int freq = lookup[addr];

                ans.Add(freq + " " + addr);
            }

            return ans;

        }
    }
}
