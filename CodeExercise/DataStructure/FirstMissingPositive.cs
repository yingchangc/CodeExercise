using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class FirstMissingPositive
    {
        /// <summary>
        /// 41. First Missing Positive
        /// https://leetcode.com/problems/first-missing-positive/
        /// Given an unsorted integer array, find the smallest missing positive integer.
        /// 
        /// Example 1:
        /// 
        /// Input: [1,2,0]
        ///         Output: 3
        /// Example 2:
        /// 
        /// Input: [3,4,-1,1]
        ///         Output: 2
        /// Example 3:
        /// 
        /// Input: [7,8,9,11,12]
        ///         Output: 1
        ///         
        /// sol:
        /// https://www.cnblogs.com/yuzhangcmu/p/4200096.html
        /// So, given a number in the array,
        /// 
        /// if it is non-positive, ignore it;
        /// if it is positive, say we have A[i] = x, we know it should be in slot A[x - 1]! That is to say, we can swap A[x - 1] with A[i] so as to place x into the right place.
        ///     We need to keep swapping until all numbers are either non-positive or in the right places.The result array could be something like[1, 2, 3, 0, 5, 6, ...]. Then it's easy to tell that the first missing one is 4 by iterate through the array and compare each value with their index.
        /// 
        ///    3 ,4 -1 ,1
        ///  3  index = 2
        ///   
        ///    -1 4  3  1      -1   stoped
        ///    -1 1  3  4       4   swap to loc idx 4
        ///                     1   still need to swpaped to idx 0   (1-1)
        ///    1 -1 3   4      -1  stopped
        ///    
        ///                     3  is at loc index 2 , skip
        ///                     4  is at loc index 3, skip
        /// 
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositiveSolver(int[] nums)
        {
            int len = nums.Length;

            for (int i = 0; i < len; i++)
            {
                int pos = nums[i];
                int posIdx = pos - 1;

                while (posIdx != i && posIdx < len && posIdx >= 0 && nums[i] != nums[posIdx])
                {
                    swap(nums, i, posIdx);
                    posIdx = nums[i] - 1;
                }
            }


            //skip 0

            for (int i = 1; i <= len; i++)
            {
                if (i != nums[i - 1])
                {
                    return i;
                }
            }
            return len + 1;
        }

        private void swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
