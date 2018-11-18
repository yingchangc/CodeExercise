using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Probability
{
    class ShuffleArray
    {
        int[] copy;
        int[] original;
        Random r = new Random();

        /// <summary>
        /// 384. Shuffle an Array   (snapchat)
        /// https://leetcode.com/problems/shuffle-an-array/description/
        /// Shuffle a set of numbers without duplicates.
        /// 
        /// Example:
        /// 
        /// // Init an array with set 1, 2, and 3.
        /// int[] nums = { 1, 2, 3 };
        ///         Solution solution = new Solution(nums);
        /// 
        ///         // Shuffle the array [1,2,3] and return its result. Any permutation of [1,2,3] must equally likely to be returned.
        ///         solution.shuffle();
        /// 
        /// // Resets the array back to its original configuration [1,2,3].
        /// solution.reset();
        /// 
        /// // Returns the random shuffling of array [1,2,3].
        /// solution.shuffle();
        /// </summary>
        /// <param name="nums"></param>
        public ShuffleArray(int[] nums)
        {
            copy = nums;
            original = nums.ToArray();
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            copy = original.ToArray();
            return original.ToArray();
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            int length = copy.Length;


            for (int i = 0; i < length; i++)
            {
                int loc = r.Next(length - i) + i;
                swap(copy, i, loc);
            }

            return copy;
        }

        private void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
