using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Window
{
    class MinimumSizeSubarraySum
    {
        /// <summary>
        /// 209. Minimum Size Subarray Sum
        /// 
        /// Given an array of n positive integers and a positive integer s, find the minimal length of a contiguous subarray of which the sum ≥ s. 
        /// If there isn't one, return 0 instead. 
        /// For example, given the array[2, 3, 1, 2, 4, 3] and s = 7,
        ///  the subarray[4, 3] has the minimal length under the problem constraint.
        ///  
        /// sol: thought
        /// 
        /// O(n^2) i and j nested for loop to find all possible lens
        /// 
        /// O(n)
        /// forwarding with 2 pointer,  i  j(move forward only)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int s, int[] nums)
        {
            int j = 0;

            int minLen = nums.Length;
            int currlen = 0;

            int currSum = 0;

            bool foundAns = false;       // yic  for no ans case

            for (int i = 0; i <nums.Length; i++)
            {
                while (j < nums.Length && currSum < s)
                {
                    currSum += nums[j++];
                    currlen++;
                }

                if (currSum >= s)
                {
                    foundAns = true;
                    minLen = Math.Min(minLen, currlen);

                    // now i can move forward
                    currlen--;
                    currSum -= nums[i];
                }
            }

            return foundAns ? minLen : 0;
        }
        public int MinSubArrayLenOld(int s, int[] nums)
        {
            int len = nums.Length;
            int j = 0;
            int currSum = 0;
            int currLen = 0;
            int minLen = Int32.MaxValue;

            // pattern
            for (int i = 0; i < len; i++)
            {
                while (j < len)
                {
                    if (currSum >= s)
                    {
                        break;
                    }
                    else
                    {
                        currSum += nums[j++];
                        currLen++;
                    }
                }

                if (currSum >= s)
                {
                    minLen = Math.Min(minLen, currLen);

                    // can now move i
                    currSum -= nums[i];
                    currLen--;
                }
            }

            return minLen != Int32.MaxValue ? minLen : 0;
        }
    }
}
