using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class MajorityElement
    {
        /// <summary>
        /// 169 
        /// Given an array of size n, find the majority element. The majority element is the element that appears more than "n/2" times.
        /// You may assume that the array is non-empty and the majority element always exist in the array.
        /// 
        /// Note: this solution only use O(1) space
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElementSolver(int[] nums)
        {
            // preset the first element
            int count = 1;
            int majorNum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (majorNum == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }

                // change to other major num
                if (count == 0)
                {
                    majorNum = nums[i];
                    count = 1;
                }
            }

            return majorNum;
        }
    }
}
