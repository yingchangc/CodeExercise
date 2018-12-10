using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class RandomPickIndex
    {
        int[] nums;
        Random rd;

        /// <summary>
        /// 398. Random Pick Index   [reservoir sampling] 
        /// https://leetcode.com/problems/random-pick-index/    
        /// Given an array of integers with possible duplicates, randomly output the index of a given target number. You can assume that the given target number must exist in the array.
        /// 
        /// Note:
        /// The array size can be very large.Solution that uses too much extra space will not pass the judge.
        /// 
        /// Example:
        /// 
        /// int[] nums = new int[] { 1, 2, 3, 3, 3 };
        ///         Solution solution = new Solution(nums);
        /// 
        ///         // pick(3) should return either index 2, 3, or 4 randomly. Each index should have equal probability of returning.
        ///         solution.pick(3);
        /// 
        /// // pick(1) should return 0. Since in the array only nums[0] is equal to 1.
        /// solution.pick(1);
        /// </summary>
        /// <param name="nums"></param>
        public RandomPickIndex(int[] nums)
        {
            this.nums = nums;
            this.rd = new Random();
        }

        public int Pick(int target)
        {

            int targetCount = 0;
            int loc = -1;

            Console.WriteLine("count = " + nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                if (target == nums[i])
                {
                    targetCount++;

                    int guessIdx = rd.Next(targetCount);

                    if (guessIdx == (targetCount - 1))    // 1/N probability
                    {
                        loc = i;
                    }
                }
            }

            return loc;
        }
    }
}
