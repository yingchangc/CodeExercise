using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class HouseRobber_DeleteAndEarn
    {
        /// <summary>
        /// 198  related to 740
        /// https://leetcode.com/problems/house-robber/description/
        /// You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
        //  Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
        /// </summary>
        /// 
        /// can pick odd or even and current Rob value should be the max value from either
        /// 
        /// num[i-2] + num[i]   or  num[i-1]
        /// 
        /// 
        /// 2 3 7 1| 2
        ///      
        /// when reach 1  the max value is from 2+7,  not from 3+1
        /// pre1 =9, pre2=9
        /// 
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            int pre1 = 0;
            int pre2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int curr = Math.Max(pre2 + nums[i], pre1);

                // move forward
                pre2 = pre1;
                pre1 = curr;
            }


            return pre1;
        }

        /// <summary>
        /// 740
        /// https://leetcode.com/problems/delete-and-earn/description/
        /// Given an array nums of integers, you can perform operations on the array. 
        ///         
        /// In each operation, you pick any nums[i] and delete it to earn nums[i] points.After, you must delete every element equal to nums[i] - 1 or nums[i] + 1. 
        /// You start with 0 points.Return the maximum number of points you can earn by applying such operations.
        /// 
        /// Note:
        /// The length of nums is at most 20000.
        /// Each element nums[i] is an integer in the range[1, 10000].
        /// --------------------------------------
        /// Example 1:
        /// Input: nums = [3, 4, 2]
        ///         Output: 6
        /// Explanation: 
        /// Delete 4 to earn 4 points, consequently 3 is also deleted.
        /// Then, delete 2 to earn 2 points. 6 total points are earned.
        /// -----------------------------------------------------
        /// Input: nums = [2, 2, 3, 3, 3, 4]
        ///         Output: 9
        /// Explanation: 
        /// Delete 3 to earn 3 points, deleting both 2's and the 4.
        /// Then, delete 3 again to earn 3 points, and 3 again to earn 3 points.
        /// 9 total points are earned.
        /// -------------------------------------------------------
        /// </summary>
        /// for repeated num, just sum them as a whole because they will not delete others after first
        /// [2, 2, 3, 3, 3, 4] -> [0 2*2 3*3 4], rob([0 2*2 3*3 4]) = 9
        /// check if next one is +1 value then skip like Rob question
        /// 
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DeleteAndEarn(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            // sort first
            Array.Sort(nums,new Comparison<int>(
                            (i1, i2) => i1.CompareTo(i2)
                    ));   // small to large


            Dictionary<int, int> lookup = new Dictionary<int, int>();
            AggregateNums(nums, lookup);

            int pre1 = 0;
            int pre2 = 0;
            int preNum = nums[0] - 1;  // we want to skip for pre1 initially

            var uniqueNums = lookup.Keys;
            foreach (int num in uniqueNums)
            {
                if ((preNum + 1) == num)
                {
                    // need to skip like rob
                    int curr = Math.Max(lookup[num] + pre2, pre1);   // get aggregate value

                    // moving forward
                    pre2 = pre1;
                    pre1 = curr;

                    preNum = num;
                }
                else
                {
                    int curr = Math.Max(lookup[num] + pre2, lookup[num] + pre1);   // get aggregate value for both since choose preNum, will not delete currentNum

                    // moving forward
                    pre2 = pre1;
                    pre1 = curr;

                    preNum = num;   
                }    
            }

            return pre1;
        }

        private void AggregateNums(int[] nums, Dictionary<int,int> lookup)
        {
            foreach(int num in nums)
            {
                if(lookup.ContainsKey(num))
                {
                    lookup[num] += num;
                }
                else
                {
                    lookup[num] = num;
                }
            }

        }
    }
}
