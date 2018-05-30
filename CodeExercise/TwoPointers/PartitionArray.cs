using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class PartitionArray
    {
        /// <summary>
        /// lint 31 Partition Array
        /// https://www.lintcode.com/problem/partition-array/description
        /// Given an array nums of integers and an int k, partition the array (i.e move the elements in "nums") such that:
        // All elements<k are moved to the left
        /// All elements >= k are moved to the right
        // Return the partitioning index, i.e the first index i nums[i] >= k.
        /// 
        /// ex
        /// If nums = [3,2,2,1] and k=2, a valid answer is 1.
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int partitionArraySolver(int[] nums, int k)
        {
            if (nums ==null || nums.Length ==0)
            {
                return 0;
            }

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                while(left<=right && nums[left] < k)
                {
                    left++;
                }

                while(left <= right && nums[right] >= k)
                {
                    right--;
                }

                if (left <= right)
                {
                    swap(nums, left, right);
                    left++;
                    right--;
                }
            }

            

            return left;
        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
