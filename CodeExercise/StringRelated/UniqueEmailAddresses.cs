using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class UniqueEmailAddresses
    {
        /// <summary>
        /// 929. Unique Email Addresses
        /// https://leetcode.com/problems/unique-email-addresses/description/
        /// Every email consists of a local name and a domain name, separated by the @ sign.
        /// 
        /// For example, in alice @leetcode.com, alice is the local name, and leetcode.com is the domain name.
        /// 
        /// Besides lowercase letters, these emails may contain '.'s or '+'s.
        /// 
        /// If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.For example, "alice.z@leetcode.com" and "alicez@leetcode.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
        /// 
        /// If you add a plus('+') in the local name, everything after the first plus sign will be ignored.This allows certain emails to be filtered, for example m.y+name @email.com will be forwarded to my@email.com.  (Again, this rule does not apply for domain names.)
        /// 
        /// It is possible to use both of these rules at the same time.
        /// 
        /// Given a list of emails, we send one email to each address in the list.How many different addresses actually receive mails? 
        /// 
        /// 
        /// 
        /// 
        /// Example 1:
        /// 
        /// Input: ["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"]
        /// Output: 2
        /// Explanation: "testemail@leetcode.com" and "testemail@lee.tcode.com" actually receive mails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns></returns>
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> collection = new HashSet<string>();

            foreach (string email in emails)
            {
                int indexAt = email.IndexOf("@");
                string suffix = email.Substring(indexAt);
                string rawprefix = email.Substring(0, indexAt + 1);
                string prefixWithPlus = rawprefix.Replace(".", "");

                int indexPlus = prefixWithPlus.IndexOf("+");

                if (indexPlus == -1)
                {
                    collection.Add(prefixWithPlus + suffix);
                    Console.WriteLine(prefixWithPlus + suffix);
                }
                else
                {
                    string prefix = prefixWithPlus.Substring(0, indexPlus);
                    collection.Add(prefix + suffix);
                    Console.WriteLine(prefix + suffix);
                }

            }

            return collection.Count;
        }
    }
}
