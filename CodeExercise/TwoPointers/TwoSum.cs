using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class TwoSum
    {
        /// <summary>
        /// 1 Two Sum
        /// https://leetcode.com/problems/two-sum/description/
        /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.

        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        ///
        ///Example:
        ///
        ///Given nums = [2, 7, 11, 15], target = 9,
        ///
        ///Because nums[0] + nums[1] = 2 + 7 = 9,
        ///return [0, 1].
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSumSolver(int[] nums, int target)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int preElem = target - nums[i];

                if (lookup.ContainsKey(preElem))
                {
                    return new int[2] { lookup[preElem], i };
                }

                if (!lookup.ContainsKey(nums[i]))
                {
                    lookup.Add(nums[i], i);
                }
                
            }

            return null;
        }

        /// <summary>
        /// 167. Two Sum II - Input array is sorted
        /// Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
        ///The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.
        ///
        ///Note:
        ///
        ///Your returned answers(both index1 and index2) are not zero-based.
        ///You may assume that each input would have exactly one solution and you may not use the same element twice.
        ///Example:
        ///
        ///Input: numbers = [2, 7, 11, 15], target = 9
        ///Output: [1,2]
        ///Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.     
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 1)
            {
                return null;
            }
            int left = 0;
            int right = numbers.Length-1;


            while(left < right)
            {
                int sum = numbers[left] + numbers[right];

                if (sum == target)
                {
                    return new int[2] { left+1, right+1 };  // not zero based
                }
                else if (sum > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return null;
        }

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

        /// sol:
        /// 
        ///  use 2 pointers
        /// 
        ///      [i]    j
        ///      
        //   start from   i = j-1, and find the first index that (nums[j]+nums[i]) <=target
        ///  at lease 0~i should also be able to count as valid (because is even lower after sort)
        /// 
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int TwoSumLE(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
            {
                return 0;
            }

            int ans = 0;

            Array.Sort(nums);

            int right = nums.Length - 1;
            int left = 0;

            while (left < right)
            {
                if (nums[left] + nums[right] <= target)
                {
                    ans += (right - left);   // yic  means, [left ...-> (right    will be smaller as well   ex.  [3]  4 5  6 [7]   target 3+7=  10,  means [3]+6  [3]+5 will be smaller, and 
                                             //  next step we move left [3], so won't have duplicate  
                    left++;
                }
                else
                {
                    right--;
                }

            }

            return ans;
        }

        public int TwoSumLESlow(int[] nums, int target)
        {
            Array.Sort(nums);   // sort from small to large
            int len = nums.Length;
            int ans = 0;
            for (int i = 0; i < len; i++)
            {
                int j = i - 1;
                while (j >= 0)
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

        /// <summary>
        /// 443. Two Sum - Greater than target
        /// https://www.lintcode.com/problem/two-sum-greater-than-target/description
        /// Given an array of integers, find how many pairs in the array such that their sum is bigger than a specific target number. 
        /// Please return the number of pairs.
        ///Example
        ///Given numbers = [2, 7, 11, 15], target = 24. Return 1. (11 + 15 is the only pair)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int TwoSumGreater(int[] nums, int target)
        {
            if (nums == null || nums.Length <2)
            {
                return 0;
            }

            int ans = 0;

            Array.Sort(nums);

            int right = nums.Length-1;
            int left = 0;

            while(left < right)
            {
                if (nums[left] + nums[right] > target)
                {
                    ans += (right - left);    // yic means [left  .... + (right will be also greater   ex.  3  4 5  6 [7]   target  3+[7] =10  
                                              //means 4+[7]  5+[7] will be greater as well,  next step we move left [7], so won't have duplicate  
                    right--;
                }
                else
                {
                    left++;
                }
                
            }

            return ans;
        }

        public int TwoSumGreaterSlow(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
            {
                return 0;
            }

            int ans = 0;

            Array.Sort(nums);

            for (int i = 0; i <nums.Length; i++)
            {
                int j = 0;
                while(j < i)
                {
                    if ((nums[i]+nums[j]) > target)
                    {
                        ans += (i - j);
                        break;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return ans;
        }


        /// <summary>
        /// 610. Two Sum - Difference equals to target
        /// https://www.lintcode.com/problem/two-sum-difference-equals-to-target/description
        /// Given an array of integers, find two numbers that their difference equals to a target value.
        /// where index1 must be less than index2.Please note that your returned answers(both index1 and index2) are NOT zero-based.
        /// 
        ///   Example
        ///   Given nums = [2, 7, 15, 24], target = 5
        /// return [1, 2] (7 - 2 = 5)
        /// 
        /// sol  
        /// if use the origin sum   left     .... right
        /// 
        /// if a[right] -a[left] > target.   should move left or right? is confusing
        /// 
        /// so   use the 
        /// 
        /// 我们可以先尝试一下两数之和的方法，发现并不奏效，因为即便在数组已经排好序的前提下，nums[i] - nums[j] 与 target 之间的关系并不能决定我们淘汰掉 nums[i] 或者 nums[j]。

        /// 那么我们尝试一下将两根指针同向前进而不是相向而行，在 i 指针指向 nums[i] 的时候，j 指针指向第一个使得 nums[j] - nums[i] >= |target| 的下标 j：
        /// 
        /// 如果 nums[j] - nums[i] == |target|，那么就找到答案
        /// 否则的话，我们就尝试挪动 i，让 i 向右挪动一位 => i++
        /// 此时我们也同时将 j 向右挪动，直到 nums[j] - nums[i] >= |target|
        /// 可以知道，由于 j 的挪动不会从头开始，而是一直递增的往下挪动，那么这个时候，i 和 j 之间的两个循环的就不是累乘关系而是叠加关系。
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] twoSum7_diff(int[] nums, int target)
        {
            Array.Sort(nums);

            int len = nums.Length;
            int j = 0;

            
            for (int i = 0; i < len; i++)
            {
                while(j < len && (nums[j] - nums[i]) <= target)
                {
                    int temp = (nums[j] - nums[i]);

                    if (temp == target && (i != j))
                    {
                        int[] ans = new int[2] { nums[i], nums[j]};
                        return ans;
                    }
                    j++;
                }

                // ready to move i forward

            }

            return null;
        }

        public int[] twoSum7_diffHashmap(int[] nums, int target)
        {
            int len = nums.Length;

            Dictionary<int, int> lookup = new Dictionary<int, int>();

            for (int i = 0; i < len; i++)
            {
                // x - arr[i] == target

                if (lookup.ContainsKey(nums[i] + target))
                {
                    int[] ans = new int[2];
                    ans[0] = lookup[nums[i] + target];
                    ans[1] = i;
                    return ans;
                }

                // arr[i] -x == target
                if (lookup.ContainsKey(nums[i] - target))
                {
                    int[] ans = new int[2];
                    ans[0] = lookup[nums[i] - target];
                    ans[1] = i;
                    return ans;
                }

                lookup.Add(nums[i], i);

            }

            return null;
        }
    }

    
}
