using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    public class CombineSum
    {
        /// <summary>
        /// 39 https://leetcode.com/problems/combination-sum/description/
        /// given candidate set [2, 3, 6, 7] and target 7, 
        /// A solution set is: 
        ///        [
        ///          [7],
        ///          [2, 2, 3]
        ///        ]
        ///        
        /// 
        /// do not use the one has used before in dfs
        /// 
        /// ref 
        /// https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/SubsetSum.java
        /// https://www.youtube.com/watch?v=K20Tx8cdwYY
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSumAllowDuplicate(int[] candidates, int target)
        {
            Array.Sort(candidates, new Comparison<int>(
                            (i1, i2) => i1.CompareTo(i2)
                    ));   // small to large,

            List<List<int>> results = new List<List<int>>();
            List<int> path = new List<int>();
            DFSForCombineSum_allowDup(candidates, target, 0, results, path);  // use helper method for For is enough

            return results.ToArray();
        }

        private static void DFSForCombineSum_allowDup(int[] candidates , int target, int index, List<List<int>> results, List<int> path)
        {
            for (int i = index; i < candidates.Length; i++)
            {
                int newTarget = target - candidates[i];

                // has been sorted, just return directly
                if (newTarget < 0)
                {
                    return;
                }

                path.Add(candidates[i]);

                if (newTarget == 0)
                {        
                    List<int> res = new List<int>(path);
                    results.Add(res);

                    path.Remove(candidates[i]);     // * remember to remove...!!
                    return;
                }
                else
                {
                    DFSForCombineSum_allowDup(candidates, newTarget, i, results, path);   // > 0 , keep using the same i, until next for

                }

                path.Remove(candidates[i]);          // * remember to remove...!!

            }
        }
    }
}
