using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class ProductOfArrayExceptSelf
    {
        /// <summary>
        /// https://leetcode.com/problems/product-of-array-except-self/description/
        /// Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
        /// 
        /// Example:
        /// 
        /// Input:  [1,2,3,4]
        /// Output: [24,12,8,6]
        /// Note: Please solve it without division and in O(n).
        /// 
        /// sol:
        /// 
        /// sweep product from left with 1 lag.   means each loc product does not include self.    next will consider it
        /// sweep product from right with 1 lag  
        /// 
        /// ex
        ///       2,  4,  6,  8
        //   L->  1,  2,  8, 48,
        /// 
        //      192, 48, 8,  1   <--R

        //      think at last loc,  left sweep don't consider itself,  from right sweep, last loc is 1    
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            int len = nums.Length;
            int[] leftDir = new int[len];
            int[] rightDir = new int[len];

            leftDir[0] = 1;
            rightDir[len-1] = 1;

            //         2, 4 ,6 ,8
            //          \  \  \ 
            // Left    1, 2, 8, 48   accumulate
            for (int i=1; i < len; i++)
            {
                leftDir[i] = leftDir[i - 1] * nums[i-1];
            }

            //           2 , 4,  6, 8
            //              /  /   /   
            // Right     192 48  8  1 
            for(int i = len-2; i>=0; i--)
            {
                rightDir[i] = rightDir[i + 1] * nums[i + 1];
            }

            int[] res = new int[len];

            for(int i =0; i <len; i++)
            {
                res[i] = leftDir[i] * rightDir[i];
            }

            return res;
        }
    }
}
