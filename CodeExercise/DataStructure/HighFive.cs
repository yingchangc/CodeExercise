using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class HighFive
    {
        /// <summary>
        /// https://www.lintcode.com/problem/high-five/description
        /// 613. High Five
        /// There are two properties in the node student id and scores, to ensure that each student will have at least 5 points, find the average of 5 highest scores for each person.
        /// 
        /// Example
        /// Given results = [[1, 91], [1,92], [2,93], [2,99], [2,98], [2,97], [1,60], [1,58], [2,100], [1,61]]
        

        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public Dictionary<int, Double> HighFiveSolver(List<Record> results)
        {
            // id, (score, count)
            Dictionary<int, SortedDictionary<int, int>> lookup = new Dictionary<int, SortedDictionary<int, int>>();
            Dictionary<int, int> pidCountLookup = new Dictionary<int, int>();  // id, currCount

            int len = results.Count;
            for (int i = 0; i <len; i++)
            {
                Record temp = results[i];
                if (!lookup.ContainsKey(temp.id))
                {
                    lookup.Add(temp.id, new SortedDictionary<int, int>());
                    pidCountLookup.Add(temp.id, 0);
                }

                if (!lookup[temp.id].ContainsKey(temp.score))
                {
                    lookup[temp.id].Add(temp.score, 0);
                }
                lookup[temp.id][temp.score]++;
                pidCountLookup[temp.id]++;

                if (pidCountLookup[temp.id] > 5)
                {
                    pidCountLookup[temp.id]--;

                    int lowestScore = lookup[temp.id].Keys.First();
                    lookup[temp.id][lowestScore]--;

                    if (lookup[temp.id][lowestScore] == 0)
                    {
                        lookup[temp.id].Remove(lowestScore);
                    }
                }
            }

            Dictionary<int, double> ans = new Dictionary<int, double>();

            foreach (var pid in lookup.Keys)
            {
                var personRecord = lookup[pid];

                double sum = 0;
                foreach (int v in personRecord.Keys)
                {
                    int count = personRecord[v];
                    sum += v * count;
                }

                ans.Add(pid, sum / 5);
            }

            return ans;
        }

    }
}
