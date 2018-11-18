using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class ReorderLogFiles
    {
        //Reorder Log Files
        /// <summary>
        /// 937. Reorder Log Files
        /// https://leetcode.com/problems/reorder-log-files/description/
        /// You have an array of logs.  Each log is a space delimited string of words.
        /// 
        /// For each log, the first word in each log is an alphanumeric identifier.Then, either:
        /// 
        /// Each word after the identifier will consist only of lowercase letters, or;
        /// Each word after the identifier will consist only of digits.
        /// We will call these two varieties of logs letter-logs and digit-logs.It is guaranteed that each log has at least one word after its identifier.
        /// 
        /// Reorder the logs so that all of the letter-logs come before any digit-log.The letter-logs are ordered lexicographically ignoring identifier, with the identifier used in case of ties.  The digit-logs should be put in their original order.
        /// 
        /// Return the final order of the logs.
        /// 
        /// 
        /// 
        /// Example 1:
        /// 
        /// Input: ["a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"]
        /// Output: ["g1 act car","a8 act zoo","ab1 off key dog","a1 9 2 3 1","zo4 4 7"]
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        public string[] ReorderLogFilesSolverInplace(string[] logs)
        {
            Array.Sort(logs, new LogComparer());

            return logs;
        }

        public class LogComparer : IComparer<string>
        {
            public int Compare(string s1, string s2)
            {
                int split1 = s1.IndexOf(' ');
                string id1 = s1.Substring(0, split1);
                string context1 = s1.Substring(split1+1);
                bool isDigit1 = Char.IsDigit(context1[0]);

                int split2 = s2.IndexOf(' ');
                string id2 = s2.Substring(0, split2);
                string context2 = s2.Substring(split2 + 1);
                bool isDigit2 = Char.IsDigit(context2[0]);

                if (isDigit1 && isDigit2)
                {
                    return -1;
                }
                else if (isDigit1)
                {
                    return 1;
                }
                else if (isDigit2)
                {
                    return -1;
                }
                else
                {
                    return context1.CompareTo(context2);
                }
            }
        }

        public string[] ReorderLogFilesSolver(string[] logs)
        {
            SortedSet<StringHolder> letterlogs = new SortedSet<StringHolder>(new SHComparer());
            List<string> digitlogs = new List<string>();

            foreach (var log in logs)
            {
                string[] split = log.Split(' ');
                if (Char.IsDigit(split[1][0]))
                {
                    digitlogs.Add(log);
                }
                else
                {
                    letterlogs.Add(new StringHolder(log));
                }
            }

            List<string> ans = new List<string>();

            foreach (var sh in letterlogs)
            {
                ans.Add(sh.log);
            }

            foreach (var log in digitlogs)
            {
                ans.Add(log);
            }

            return ans.ToArray();
        }
    }


    public class StringHolder
    {
        public string content;
        public string id;
        public string log;

        public StringHolder(string log)
        {
            int index = log.IndexOf(' ');
            this.content = log.Substring(index+1);
            this.id = log.Substring(0, index);
            this.log = log;
        }
    }

    public class SHComparer : IComparer<StringHolder>
    {
        public int Compare(StringHolder s1, StringHolder s2)
        {
            if (s1.content != s2.content)
            {
                return s1.content.CompareTo(s2.content);
            }
            else
            {
                return s1.id.CompareTo(s2.id);
            }
        }
    }
}
