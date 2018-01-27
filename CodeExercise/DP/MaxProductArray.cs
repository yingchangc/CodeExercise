using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class MaxProductArray
    {
        /// <summary>
        /// 152. Maximum Product Subarray
        /// Find the contiguous subarray within an array (containing at least one number) which has the largest product. 
        /// For example, given the array[2, 3, -2, 4],
        /// the contiguous subarray[2, 3] has the largest product = 6.
        /// 
        /// Sol: Similiar to MaximumSubArray 53,  but be awre of  -2 * -2  becouse postive and larger than positive* postive
        /// 
        /// so keep both Max and Min array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxProduct(int[] nums)
        {
            int len = nums.Length;
            int[] fMax = new int[len];
            int[] gMin = new int[len];


            int maxV = fMax[0] = gMin[0] = nums[0];   // yic initla maxV to the index 0  for single element array, like {-2}
            for (int i = 1; i<len; i++)
            {
                fMax[i] = Math.Max(Math.Max(fMax[i - 1] * nums[i], gMin[i - 1]*nums[i]),   nums[i]);  //(P*P,  N*N ,  nums[i]) considered 豬羊變色
                gMin[i] = Math.Min(Math.Min(fMax[i - 1] * nums[i], gMin[i - 1]*nums[i]),   nums[i]); // -*+ , P*N   nums[i]

                maxV = Math.Max(fMax[i], maxV);
            }


            return maxV;
        }

        //For example, given the array [2,3,-2,4], the contiguous subarray [2,3] has the largest product = 6.
        // space O(1)  time O(n)
        //http://www.lintcode.com/en/problem/maximum-product-subarray/
        public int maxProductNoMemo(int[] nums)
        {
            
            int len = nums.Length;

            if (len == 0 || nums == null)
            {
                return 0;
            }

            int minPre = nums[0];
            int maxPre = nums[0];
            int ans = nums[0];
            
            for (int i = 1; i < len; i++)
            {
                int currMin = Math.Min(nums[i], 
                                  Math.Min(nums[i] * minPre, nums[i] * maxPre));    // p*p  vs n*n    note cannot update minPre here because it will be use next.

                int currMax = Math.Max(nums[i],
                                  Math.Max(nums[i] * minPre, nums[i] * maxPre));    // p*p  vs n*n

                ans = Math.Max(ans, currMax);
                minPre = currMin;
                maxPre = currMax;
            }

            return ans;
        }
    }
}
