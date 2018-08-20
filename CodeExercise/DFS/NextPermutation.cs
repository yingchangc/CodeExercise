using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class NextPermutation
    {
        /// <summary>
        /// 31. Next Permutation
        /// https://leetcode.com/problems/next-permutation/description/
        /// Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
        /// 
        /// If such arrangement is not possible, it must rearrange it as the lowest possible order(ie, sorted in ascending order).
        /// 
        /// The replacement must be in-place and use only constant extra memory.
        /// 
        /// Here are some examples.Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
        /// 
        /// 1,2,3 → 1,3,2
        /// 3,2,1 → 1,2,3
        /// 1,1,5 → 1,5,1
        /// 
        /// sol
        /// 
        ///  --> 1 3 2 3 1       search for ascending from righ to left, stop  (2),   and swap with value just greater (3)
        ///  --> 1 3 3 [2 1]     it will be ascending , but we want smaller so, revese the after swap
        ///  --> 1 3 3 [1 2]
        ///  
        ///  (1)  find anchor index start to descend,  right part is ascending
        ///  (2)  swap achor index with the position value just greater than anchor V,  so that we can make min high bit change
        ///
        ///          1 [2] 8 7 6 0
        ///
        ///		  swap with 6
        ///	=>    1 [6] 8 7 2 0
        ///	            reverse right part so that this become the next 
        ///	==>   1 [6] 0 2 7 8
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutationSolver(int[] nums)
        {
            int len = nums.Length;
            int pre = nums[len - 1];
            int i;

            // find the first loc not ascending from right
            for (i = len-2; i >=0; i--)
            {
                if (nums[i] >= pre)
                {
                    pre = nums[i];
                }
                else
                {
                    break;
                }
            }

            if (i >=0)
            {
                int anchor = i;

                for (int j = len-1; j >anchor; j--)
                {
                    // find num that is just greater than nums[anchor] so that the high bit change is smallest
                    if (nums[j] > nums[anchor])
                    {
                        swap(nums, j, anchor);
                        break;
                    }
                }

                // then, reverse anchor+1 ~len-1
                int left = anchor + 1;
                int right = len - 1;
                while(left <right)
                {
                    swap(nums, left, right);
                    left++;
                    right--;
                }
            }
            else
            {
                // restart over 
                Array.Reverse(nums);
            }
        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }


        /// <summary>
        /// 51. Previous Permutation
        /// https://www.lintcode.com/problem/previous-permutation/description
        /// Given a list of integers, which denote a permutation.
        /// 
        /// Find the previous permutation in ascending order.
        /// 
        /// 
        /// Example
        /// For [1,3,2,3], the previous permutation is [1,2,3,3]
        /// 
        /// For [1,2,3,4], the previous permutation is [4,3,2,1]
        /// 
        /// 
        /// sol:
        /// 
        ///     not like next permutation,   ascending from right. it need to descending
        ///     
        ///    5 2 3 [4] 6
        ///    
        ///    find anchor at 5, then find the first one just smaller to swap (so we can get a smaller to front)
        ///    
        ///  -> 4 2 3 5 6    lower, so need to swap anchor point to increase a bit
        ///  -> 4 6 5 3 2     ans
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] previousPermuation(int[] nums)
        {
            int i;
            // find first non descending loc as anchor
            for (i = nums.Length -2; i >=0; i--)
            {
                if (nums[i] > nums[i+1])
                {
                    break;
                }
            }

            if (i < 0)
            {
                Array.Reverse(nums);
                return nums;
            }

            int anchor = i;
            
            // swap with first smaller to get whole number to be smaller
            for (int j = nums.Length-1; j >=0; j--)
            {
                if (nums[j] < nums[anchor])
                {
                    swap(nums, j, anchor);
                    break;
                }
            }

            int left = anchor + 1;
            int right = nums.Length - 1;

            while(left < right)
            {
                swap(nums, left++, right--);
            }

            return nums;
        }
    }
}
