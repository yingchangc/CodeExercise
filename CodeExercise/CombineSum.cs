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
        /// 40
        /// https://leetcode.com/problems/combination-sum-ii/description/
        /// No duplicate 
        /// For example, given candidate set [10, 1, 2, 7, 6, 1, 5] and target 8, 
        ///    A solution set is: 
        ///    [
        ///      [1, 7],
        ///      [1, 2, 5],
        ///      [2, 6],
        ///      [1, 1, 6]
        ///    ]
        ///    
        /// sort [10 7 6 5 2 1 1] 
        /// 
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates, new Comparison<int>(
                            (i1, i2) => i2.CompareTo(i1)
                    ));   // large to small,

            List<List<int>> results = new List<List<int>>();
            List<int> path = new List<int>();
            if (target > 0)
            {
                CombinationSum2Helper(candidates, target, 0, results, path);
            }

            return results.ToArray();
        }

        private static void CombinationSum2Helper(int[] candidates, int target, int index, List<List<int>> results, List<int> path)
        {
            if (target == 0)
            {
                List<int> result = new List<int>(path);
                results.Add(result);
                return;
            }


            for (int i = index; i < candidates.Length; i++)
            {
                // * YIC Note:  i != index, don't check previously because for case 
                // find 8, [6 , 1, [1]]   the last iteration [1] should not check i-1     
                //to find 2    [2,2,2], if 2 has reached previously, move on
                //  find 8, [7 , 1, 1]
                if (i != index && candidates[i] == candidates[i-1])
                {
                    continue;
                } 

                path.Add(candidates[i]);
                int newTarget = target - candidates[i];

                if (newTarget >= 0)
                {
                    CombinationSum2Helper(candidates, newTarget, i + 1, results, path);
                }
                path.Remove(candidates[i]);
        
            }
        }

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
            if (target > 0)
            {
                DFSForCombineSum_allowDup(candidates, target, 0, results, path);  // use helper method for For is enough
            }

            return results.ToArray();
        }

        private static void DFSForCombineSum_allowDup(int[] candidates , int target, int index, List<List<int>> results, List<int> path)
        {
            if (target == 0)
            {
                List<int> result = new List<int>(path);
                results.Add(result);
            }

            for(int i = index; i < candidates.Length; i++)
            {
                if (i > index && candidates[i] == candidates[i-1])
                {
                    // have use before, skip
                    continue;
                }

                int newTarget = target - candidates[i];
                if (newTarget < 0)
                {
                    // since sort by small to large, just return
                    return;
                }

                path.Add(candidates[i]);

                DFSForCombineSum_allowDup(candidates, newTarget, i, results, path);   // > 0 , keep using the same i, until next for

                path.Remove(candidates[i]);

            }

        }
    }
}
