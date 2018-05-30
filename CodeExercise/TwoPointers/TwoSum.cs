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

        /// <summary>
        /// 167. Two Sum II - Input array is sorted
        /// Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
        ///The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.
        ///
        ///Note:
        ///
        ///Your returned answers(both index1 and index2) are not zero-based.
        ///You may assume that each input would have exactly one solution and you may not use the same element twice.
        ///Example:
        ///
        ///Input: numbers = [2, 7, 11, 15], target = 9
        ///Output: [1,2]
        ///Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.     
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 1)
            {
                return null;
            }
            int left = 0;
            int right = numbers.Length-1;


            while(left < right)
            {
                int sum = numbers[left] + numbers[right];

                if (sum == target)
                {
                    return new int[2] { left+1, right+1 };  // not zero based
                }
                else if (sum > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return null;
        }
    }
}
