using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class TwoSumLETarget
    {
        /// <summary>
        /// 609. Two Sum - Less than or equal to target
        /// https://www.lintcode.com/en/old/problem/two-sum-less-than-or-equal-to-target/
        /// Given an array of integers, find how many pairs in the array such that their sum is less than or equal to a specific target number.
        /// Please return the number of pairs.
        /// Have you met this question in a real interview?
        /// Example
        /// Given nums = [2, 7, 11, 15], target = 24.
        /// Return 5. 
        //  2 + 7 < 24
        //  2 + 11 < 24
        //  2 + 15 < 24
        //  7 + 11 < 24
        //  7 + 15 < 25
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int TwoSum5(int[] nums, int target)
        {
            Array.Sort(nums);   // sort from small to large
            int len = nums.Length;
            int ans = 0;
            for(int i = 0; i < len; i++)
            {
                int j = i-1;
                while (j >=0)
                {
                    if ((nums[i] + nums[j]) <= target)
                    {
                        ans += (j + 1);
                        break;
                    }
                    else
                    {
                        j--;
                    }
                }
            }

            return ans;
        }
    }
}
