using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class FindAllNumbersDisappearedInArray
    {
        /// <summary>
        /// 448. Find All Numbers Disappeared in an Array
        /// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/description/
        /// 
        /// Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.
        /// 
        /// Find all the elements of[1, n] inclusive that do not appear in this array.
        /// 
        /// Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
        /// 
        /// Example:
        /// 
        /// Input:
        /// [4,3,2,7,8,2,3,1]
        /// 
        /// Output:
        /// [5,6]
        /// 
        /// sol:
        /// 
        /// since val is sequential and in the n range.
        /// 
        /// use the val as index,   [4   ]   as we visited 4th    3thm 2th 7th, 8th 3th 1th   mark those loc to -1*val   (so don't need to worry index loc val)
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            // use num as visited index

            for (int i = 0; i < nums.Length; i++)
            {
                int loc = Math.Abs(nums[i]);

                if (nums[loc - 1] > 0)
                {
                    nums[loc - 1] = -1 * nums[loc - 1];   // negative as visited but keep the same value
                }
            }

            var ans = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    ans.Add(i + 1);  // index to ith
                }
            }

            return ans;
        }
    }
}
