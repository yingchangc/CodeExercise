using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class AccountsMerge
    {
        /// <summary>
        /// 721. Accounts Merge
        /// https://leetcode.com/problems/accounts-merge/description/
        /// Given a list accounts, each element accounts[i] is a list of strings, where the first element accounts[i][0] is a name, and the rest of the elements are emails representing emails of the account.
        /// 
        /// Now, we would like to merge these accounts.Two accounts definitely belong to the same person if there is some email that is common to both accounts.Note that even if two accounts have the same name, they may belong to different people as people could have the same name. A person can have any number of accounts initially, but all of their accounts definitely have the same name.
        /// 
        /// 
        /// After merging the accounts, return the accounts in the following format: the first element of each account is the name, and the rest of the elements are emails in sorted order. The accounts themselves can be returned in any order.
        /// 
        /// 
        /// Example 1:
        /// Input: 
        /// accounts = [["John", "johnsmith@mail.com", "john00@mail.com"], ["John", "johnnybravo@mail.com"], ["John", "johnsmith@mail.com", "john_newyork@mail.com"], ["Mary", "mary@mail.com"]]
        /// Output: [["John", 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com'],  ["John", "johnnybravo@mail.com"], ["Mary", "mary@mail.com"]]
        /// Explanation: 
        /// The first and third John's are the same person as they have the common email "johnsmith@mail.com".
        /// The second John and Mary are different people as none of their email addresses are used by other accounts.
        /// We could return these lists in any order, for example the answer[['Mary', 'mary@mail.com'], ['John', 'johnnybravo@mail.com'],
        /// ['John', 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com']] would still be accepted.
        /// Note:
        /// 
        /// The length of accounts will be in the range [1, 1000].
        /// The length of accounts[i] will be in the range [1, 10].
        /// The length of accounts[i][j] will be in the range [1, 30].
        /// 
        /// sol:
        /// 
        /// (1) use UnionFind to get all emails connected components.
        /// (2) also use Hashset to store emails, walk through each key and if they have the same parent, put into the same List, so each List will belong to the same person   Dicitonary(ParentMail, List(mails))
        /// (3) for each person, get the first email and find its parent, and then find the corresponding list, note  need use hashset to cache visited ancestor mail since we want to skip the same user
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public IList<IList<string>> AccountsMergeSolver(IList<IList<string>> accounts)
        {
            HashSet<string> emails = new HashSet<string>();
            foreach(var account in accounts)
            {
                int len = account.Count;
                for (int i = 1; i < len; i++)    // user, email1, email2 ...
                {
                    emails.Add(account[i]);
                }
            }

            // step1  find email connected component
            UnionFindAccont uf = new UnionFindAccont(emails);
            foreach (var account in accounts)
            {
                int len = account.Count;
                for (int i = 2; i < len; i++)    // user, email1, email2 ...
                {
                    uf.Union(account[1], account[i]);
                }
            }

            //step2  already have emails set, find email groups  (ancestor, {email1, email2, ...})
            Dictionary<string, List<string>> emailsGraph = new Dictionary<string, List<string>>();
            foreach(var email in emails)
            {
                string ancestor = uf.Find(email);
                if (!emailsGraph.ContainsKey(ancestor))
                {
                    emailsGraph.Add(ancestor, new List<string>());
                }
                emailsGraph[ancestor].Add(email);
            }

            //step3  link to user
            List<List<string>> ans = new List<List<string>>();
            HashSet<string> visited = new HashSet<string>();  // yic 
            foreach (var account in accounts)
            {
                string user = account[0];
                string firstEmail = account[1];
                string ancestor = uf.Find(firstEmail);

                if (visited.Contains(ancestor))
                {
                    continue;
                }
                visited.Add(ancestor);

                List<string> temp = new List<string>();
                temp.Add(user);
                var sortedEmail = emailsGraph[ancestor];
                sortedEmail.Sort();
                temp.AddRange(sortedEmail);
                ans.Add(temp);  
            }

            return ans.ToArray();
        }

        public class UnionFindAccont
        {
            Dictionary<string, string> unionLookup;

            public UnionFindAccont(HashSet<string> emails)
            {
                unionLookup = new Dictionary<string, string>();
                foreach (var email in emails)
                {
                    unionLookup.Add(email, email);
                }
            }

            public string Find(string email)
            {
                if (email != unionLookup[email])
                {
                    var ancestor = Find(unionLookup[email]);
                    unionLookup[email] = ancestor;
                }
                return unionLookup[email];
            }

            public void Union(string email1, string email2)
            {
                // yic use find  
                string p1 = Find(email1);
                string p2 = Find(email2);

                if (p1 != p2)
                {
                    //  yic use p2, not email
                    unionLookup[p2] = p1;
                }
            }

        }
    }
}
