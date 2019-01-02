using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class RemoveSubstrings
    {
        public int MinLengthIteration(string s, HashSet<string> dict)
        {
            Queue<string> que = new Queue<string>();

            HashSet<string> visited = new HashSet<string>();

            que.Enqueue(s);
            visited.Add(s);

            int minLen = s.Length;
            string ans = s;

            while(que.Count > 0)
            {
                var curr = que.Dequeue();

                if (minLen > curr.Length)
                {
                    minLen = curr.Length;
                    ans = curr;
                }

                var collection = RemoveHelper(curr, dict, visited);

                foreach (var sub in collection)
                {
                    que.Enqueue(sub);
                }
            }

            Console.WriteLine(ans);

            return minLen;


        }

        private HashSet<string> RemoveHelper(string s, HashSet<string> dict, HashSet<string> visited)
        {
            HashSet<string> collection = new HashSet<string>();

            foreach (var w in dict)
            {
                int idx = s.IndexOf(w,0);
                while(idx != -1)
                {
                    var parsed = s.Substring(0, idx) + s.Substring(idx + w.Length);

                    if (!visited.Contains(parsed))
                    {
                        collection.Add(parsed);
                        visited.Add(parsed);
                    }
                    
                    idx = s.IndexOf(w, idx+1);
                }   
            }
            return collection;
            
        }


        private int minLen = Int32.MaxValue;
        private HashSet<string> visited = new HashSet<string>();
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
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        

        public int MinLengthRecursive(string s, HashSet<string> dict)
        {   
            MinLengthHelper(s, dict);
            return minLen;
        }

        private void MinLengthHelper(string s, HashSet<string> dict)
        {
            // yic  need this optimizaiton
            if (visited.Contains(s))
            {
                return;
            }

            minLen = Math.Min(s.Length, minLen);

            foreach(string word in dict)
            {
                if (s.Contains(word))
                {
                    HashSet<string> shorterStrs = RemoveSubstr(s, word);
                    foreach(string shorterStr in shorterStrs)
                    {
                        MinLengthHelper(shorterStr, dict);
                    }
                                      
                }
            }

            visited.Add(s);
        }

        // yic  need to get all substrings combination    abcdabd "ab" -> "cdabd"  and "abcdd" because order matters  
        private HashSet<string> RemoveSubstr(string s, string word)
        {
            int startIdx = 0;
            HashSet<string> collection = new HashSet<string>();
            while(s.IndexOf(word, startIdx)!= -1)
            {
                int firstOccurrent = s.IndexOf(word, startIdx);
                string shorterStr = s.Substring(0, firstOccurrent) + s.Substring(firstOccurrent + word.Length);
                collection.Add(shorterStr);

                startIdx = firstOccurrent + 1;
            }

           

            return collection;
        }
    }
}
