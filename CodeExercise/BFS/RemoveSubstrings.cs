using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class RemoveSubstrings
    {
        /// <summary>
        /// 624. Remove Substrings
        /// https://www.lintcode.com/problem/remove-substrings/description
        /// Given a string s and a set of n substrings.You are supposed to remove every instance of those n substrings 
        /// from s so that s is of the minimum length and output this minimum length.
        /// 
        /// Example
        /// Given s = ccdaabcdbb, substrs = ["ab", "cd"]
        /// Return 2
        /// 
        /// 
        /// Explanation:
        /// ccdaabcdbb -> ccdacdbb -> cabb -> cb (length = 2)
        /// 
        /// sol:
        /// remove substrs from orig string with diff index  stat locs
        public int MinLengthIterationQue(string s, HashSet<string> dict)
        {
            Queue<string> que = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            que.Enqueue(s);
            visited.Add(s);

            string ansStr = s;
            int minLen = s.Length;

            while(que.Count > 0)
            {
                var curr = que.Dequeue();

                if (curr.Length < minLen)
                {
                    minLen = curr.Length;
                    ansStr = curr;
                }

                foreach(var w in dict)
                {
                    // yic must find candidates
                    var candidates = FindCandidates(curr, w);
                    
                    foreach(var candidate in candidates)
                    {
                        if (!visited.Contains(candidate))
                        {
                            visited.Add(candidate);
                            que.Enqueue(candidate);
                        }
                    }
                }
            }

            return minLen;
        }

        // yic remove order matters, so need to find all candidate at this level
        private List<string> FindCandidates(string s, string word)
        {
            int startIdx = 0;
            List<string> candidates = new List<string>();
            while((startIdx = s.IndexOf(word, startIdx)) != -1)
            {
                string prefix = s.Substring(0, startIdx);
                string suffix = s.Substring(startIdx + word.Length);
                candidates.Add(prefix + suffix);
                startIdx++;
            }
            return candidates;
        }


        

    }
}
