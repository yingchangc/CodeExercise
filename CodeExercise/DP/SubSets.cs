﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    public class SubSets
    {
        /// <summary>
        /// 78. Subsets 
        /// Given a set of distinct integers, nums, return all possible subsets (the power set). 
        /// Note: The solution set must not contain duplicate subsets.
        /// For example,
        /// If nums = [1, 2, 3], a solution is: 
        /// [
        ///  [3],
        ///  [1],
        ///  [2],
        ///  [1,2,3],
        ///  [1,3],
        ///  [2,3],
        ///  [1,2],
        ///  []
        ///]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> FindSubsets(int[] nums)
        {
            List<List<int>> results = new List<List<int>>();
            List<int> path = new List<int>();
            // add empty result
            results.Add(new List<int>());
            SubSetsHelper(nums, 0, results, path);

            return results.ToArray();
        }

        private static void SubSetsHelper(int[] nums, int index, List<List<int>> results, List<int> path)
        {
            for (int i = index; i < nums.Length; i++)
            {
                path.Add(nums[i]);     // *YIC always add to result and move on
                List<int> result = new List<int>(path);
                results.Add(result);

                SubSetsHelper(nums, i+1, results, path);

                path.Remove(nums[i]);
            }
        }

        /// <summary>
        /// 79 
        /// Given a collection of integers that might contain duplicates, nums, return all possible subsets (the power set). 
        /// If nums = [1,2,2], a solution is: 
        ///           [
        ///             [2],
        ///             [1],
        ///             [1,2,2],
        ///             [2,2],
        ///             [1,2],
        ///             []
        ///           ]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {

            // * YIC must sort first
            Array.Sort(nums, new Comparison<int>(
                            (i1, i2) => i1.CompareTo(i2)
                    ));   // small to large,

            List<List<int>> results = new List<List<int>>();
            List<int> path = new List<int>();
            SubsetsWithDupHelper(nums, 0, results, path);

            // add empty reuslt
            results.Add(new List<int>());
            return results.ToArray();
        }

        private static void SubsetsWithDupHelper(int[] nums, int index, List<List<int>> results, List<int> path)
        {
            for (int i = index; i < nums.Length; i++)
            {
                // * YIC part differ from #78 subsets
                if (i > index && nums[i-1] == nums[i])
                {
                    continue;
                }

                path.Add(nums[i]);

                List<int> result = new List<int>(path);
                results.Add(result);

                SubsetsWithDupHelper(nums, i + 1, results, path);

                path.Remove(nums[i]);
            }
        }
    }
}
