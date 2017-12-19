using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class GroupAnagrams
    {
        /// <summary>
        /// 
        /// Given an array of strings, group anagrams together. 
        ///         For example, given: ["eat", "tea", "tan", "ate", "nat", "bat"], 
        /// Return: 
        /// [
        ///   ["ate", "eat","tea"],
        ///   ["nat","tan"],
        ///   ["bat"]
        /// ]
        /// 
        /// Note: All inputs will be in lower-case.
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> FindAnagrams(string[] strs)
        {
            List<List<string>> results = new List<List<string>>();

            Dictionary<string, List<string>> lookup = new Dictionary<string, List<string>>();

            foreach(var str in strs)
            {
                string sortedStr = SortString(str);

                if (!lookup.ContainsKey(sortedStr))
                {
                    lookup[sortedStr] = new List<string>();
                }

                lookup[sortedStr].Add(str);
            }

            foreach(var listOfSameAnagramStrings in lookup.Values)
            {
                results.Add(listOfSameAnagramStrings);
            }
            return results.ToArray();
        }

        private string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
