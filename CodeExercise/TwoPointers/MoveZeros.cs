using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class MoveZeros
    {
        //
        /// <summary>
        /// 283. Move Zeroes
        /// https://leetcode.com/problems/move-zeroes/description/
        /// Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
        /// 
        /// Example:
        /// 
        /// Input: [0,1,0,3,12]
        ///         Output: [1,3,12,0,0]
        ///         Note:
        /// 
        /// You must do this in-place without making a copy of the array.
        /// Minimize the total number of operations.
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroesSolver(int[] nums)
        {
            int len = nums.Length;

            int zeroIdx = 0;

            for (int i =0; i <len; i++)
            {
                if (nums[i] != 0)
                {
                    swap(nums, i, zeroIdx++);
                }
            }
        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
