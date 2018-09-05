using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class ThreeSum
    {
        /// <summary>
        /// 59. 3Sum Closest
        /// https://www.lintcode.com/problem/3sum-closest/description
        /// Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. 
        /// Return the sum of the three integers.
        /// For example, given array S = [-1 2 1 -4], and target = 1. The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length<3)
            {
                return -1;
            }

            Array.Sort(numbers);

            int ans = numbers[0]+ numbers[1] + numbers[2];

            for (int i = 0; i < numbers.Length; i++)
            {
                int left = i + 1;
                int right = numbers.Length - 1;

                while (left < right)
                {
                    int sum = numbers[i]+numbers[left] + numbers[right];

                    // update answer
                    if( Math.Abs(ans - target) > Math.Abs(sum - target))
                    {
                        ans = sum;
                    }

                    if (sum == target)
                    {
                        return target;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }

                }
            }

            return ans;
            
        }

        // can be used for HashSet de duplicate
        class TrippleNode
        {
            public int a;
            public int b;
            public int c;

            public TrippleNode(int a, int b, int c)
            {
                this.a = a;
                this.b = b;
                this.c = c;

            }

            public override bool Equals(Object obj)
            {
                if (obj == null || !(obj is TrippleNode))
                    return false;
                else
                    return a == ((TrippleNode)obj).a && b == ((TrippleNode)obj).b && c == ((TrippleNode)obj).c;
            }

            public override int GetHashCode()
            {
                return 33*33*a+33*b+c;
            }
        }

        // worng for case [0,0',0'']     0 already in the set, falsely skip
        public IList<IList<int>> ThreeSum_WrongWithHahset(int[] nums)
        {
            Array.Sort(nums, (x, y) =>
            {
                return x.CompareTo(y);
            });

            
            List<List<int>> ans = new List<List<int>>();
            int len = nums.Length;
            int pre = 0;
            for (int i = 0; i <= len - 3; i++)
            {
                // skip duplicate
                if (i != 0 && pre == nums[i])
                {
                    continue;
                }
                int left = i + 1;
                int target = 0 - nums[i];
                int v1 = nums[i];
                TwoSumHelper(nums, left, ans, target, v1);
                pre = nums[i];
            }

            return ans.ToArray();
        }

        private void TwoSumHelper(int[] nums, int left, List<List<int>> ans, int target, int v1)
        {
            HashSet<int> lookup = new HashSet<int>();

            for (int i = left; i < nums.Length; i++)
            {
                int curr = nums[i];

                // already sorted, if contains, skip to avoid duplicate
                if (!lookup.Contains(curr) && lookup.Contains(target-curr))
                {
                    ans.Add(new List<int>() { v1, curr, target - curr });
                    
                }
                lookup.Add(curr);
            }
        }

        /// <summary>
        /// lint 57. 3Sum
        /// https://leetcode.com/problems/3sum/description/
        ///https://www.lintcode.com/problem/3sum/description
        ///Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in 
        ///the array which gives the sum of zero.
        ///Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ≤ b ≤ c)
        ///The solution set must not contain duplicate triplets.
        ///
        /// For example, given array S = {-1 0 1 2 -1 -4}, A solution set is:
        /// (-1, 0, 1)
        /// (-1, -1, 2)     
        /// 
        /// sol:
        /// 
        /// cannot use hashset as it does not rember the index and if it has appear before,
        /// so use 2 pointers,  if first number exist, go right
        ///  if second number (after add to answer) exists before, go right
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSumsolver(int[] nums)
        {
            Array.Sort(nums, (x, y) =>
            {
                return x.CompareTo(y);
            });

            int pre = 0;

            List<List<int>> ans = new List<List<int>>();
            int len = nums.Length;

            for (int i = 0; i <= len - 3; i++)
            {
                // skip duplicate
                if (i != 0 && pre == nums[i])
                {
                    continue;
                }

                int target = -1 * nums[i];
                int left = i + 1;
                int right = len - 1;

                while (left < right)
                {
                    if (nums[left] + nums[right] == target)
                    {
                        ans.Add(new List<int>() { nums[i], nums[left], nums[right] });

                        int origLeftV = nums[left];
                        left++;

                        while (left < right && nums[left] == origLeftV)
                        {
                            left++;
                        }
                    }
                    else if ((nums[left] + nums[right]) > target)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }

                pre = nums[i];
            }


            return ans.ToArray();
        }
    }
}
