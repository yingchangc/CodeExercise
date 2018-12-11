using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class PartitionKEqualSumSubsets
    {
        /// <summary>
        /// 698. Partition to K Equal Sum Subsets
        /// https://leetcode.com/problems/partition-to-k-equal-sum-subsets/
        /// Given an array of integers nums and a positive integer k, find whether it's possible to divide this array into k non-empty subsets whose sums are all equal.
        /// 
        /// Example 1:
        /// Input: nums = [4, 3, 2, 3, 5, 2, 1], k = 4
        /// Output: True
        /// Explanation: It's possible to divide it into 4 subsets (5), (1, 4), (2,3), (2,3) with equal sums.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanPartitionKSubsets(int[] nums, int k)
        {

            int total = 0;
            foreach (var num in nums)
            {
                total += num;
            }

            if (total % k != 0)
            {
                return false;
            }

            int target = total / k;

            Array.Sort(nums);   
                                        // start from big
            return DFS(nums, new int[k], nums.Length - 1, target);

        }

        private bool DFS(int[] nums, int[] bucket, int index, int target)
        {
            if (index < 0)
            {
                return true;
            }

            int num = nums[index];

            for (int i = 0; i < bucket.Length; i++)  // k bucket
            {
                // try put in one of K buckets and see if which one can reach end
                if (bucket[i] + num <= target)
                {
                    bucket[i] += num;

                    if (DFS(nums, bucket, index - 1, target))
                    {
                        return true;
                    }

                    bucket[i] -= num;
                }

            }

            return false;
        }
    }
}
