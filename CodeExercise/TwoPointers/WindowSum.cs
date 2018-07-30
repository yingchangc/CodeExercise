using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class WindowSum
    {
        /// <summary>
        /// 604. Window Sum
        /// https://www.lintcode.com/problem/window-sum/description
        /// Given an array of n integer, and a moving window(size k), move the window at each iteration from the start of the array, find the sum of the element inside the window at each moving.
        /// 
        /// Example
        /// For array[1, 2, 7, 8, 5], moving window size k = 3.
        ///    1 + 2 + 7 = 10
        ///     2 + 7 + 8 = 17
        ///     7 + 8 + 5 = 20
        ///     return [10,17,20]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] WinSum(int[] nums, int k)
        {
            int len = nums.Length;

            if (k > len)
            {
                return null;
            }

            int[] ans = new int[len - k + 1];
            int right = 0;
            int currSum = 0;
            for (int i = 0; i < len; i++)
            {
                while(right<len)
                {
                    currSum += nums[right++];

                    if ((right-i) == k)
                    {
                        ans[i] = currSum;
                        break;
                    }
                }

                currSum -= nums[i];
            }

            return ans;
        }
    }
}
