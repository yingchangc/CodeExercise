using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class TwoSum
    {
        /// <summary>
        /// 1 Two Sum
        /// https://leetcode.com/problems/two-sum/description/
        /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.

        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        ///
        ///Example:
        ///
        ///Given nums = [2, 7, 11, 15], target = 9,
        ///
        ///Because nums[0] + nums[1] = 2 + 7 = 9,
        ///return [0, 1].
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSumSolver(int[] nums, int target)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int preElem = target - nums[i];

                if (lookup.ContainsKey(preElem))
                {
                    return new int[2] { lookup[preElem], i };
                }

                if (!lookup.ContainsKey(nums[i]))
                {
                    lookup.Add(nums[i], i);
                }
                
            }

            return null;
        }
    }
}
