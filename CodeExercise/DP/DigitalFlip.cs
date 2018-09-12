using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class DigitalFlip
    {
        /// <summary>
        /// 843. Digital Flip
        /// https://www.lintcode.com/problem/digital-flip/description?_from=ladder
        /// Give you an array of 01. Find the minimum number of flipping steps so that the array meets the following rules:
        /// The back of 1 can be either1 or 0, but0 must be followed by 0.
        /// 
        /// Example
        /// Given array = [1,0,0,1,1,1], return 2.
        /// 
        /// Explanation:
        /// Turn two 0s into 1s.
        /// Given array = [1, 0, 1, 0, 1, 0], return 2.
        /// 
        /// Explanation:
        /// Turn the second 1 and the third 1 into 0.
        /// 
        /// ans should be like
        /// 11110000
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FlipDigit(int[] nums)
        {
            int len = nums.Length;
            int[,] F = new int[len + 1, 2];    //  0~N:1 or 0

            for (int i = 1; i <=len; i++)
            {
                // goal  1111000
                if (nums[i-1] == 0)
                {
                    // curr is 0, keep 0, pre can be 0 or 1 
                    F[i, 0] = Math.Min(F[i - 1, 0], F[i - 1,1]);

                    // curr is 0, flip to 1, pre can be 1 only
                    F[i, 1] = F[i - 1, 1] + 1;
                }
                else
                {   // curr is 1, keep 1, pre can be 1 only
                    F[i, 1] = F[i - 1, 1];

                    // curr is 1, flip to 0, pre can be 0 or 1,
                    F[i, 0] = (Math.Min(F[i - 1, 0], F[i - 1, 1]))    + 1; 
                }
            }

            return Math.Min(F[len, 0], F[len, 1]);
        }
    }
}
