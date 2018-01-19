using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class SearchInsertPosition
    {
        /// <summary>
        /// Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        ///         You may assume no duplicates in the array.
        ///         Example 1: 
        /// Input: [1,3,5,6], 5
        /// Output: 2
        /// 
        /// 
        ///         Example 2: 
        /// Input: [1,3,5,6], 2
        /// Output: 1
        /// 
        /// 
        ///         Example 3: 
        /// Input: [1,3,5,6], 7
        /// Output: 4
        /// 
        /// 
        ///         Example 1: 
        /// Input: [1,3,5,6], 0
        /// Output: 0
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l <= r)
            {
                int midIdx = (l + r) / 2;
                int m = nums[midIdx];
                if (target == m)
                {
                    return midIdx;
                }
                else if (target < m)   // in left
                {
                    r = midIdx - 1;
                }
                else
                {                     // in right
                    l = midIdx + 1;
                }
            }

            // r , l swapped, the ans is in the middle.  it will not have problem when insert at front.  -1+1 = 0;
            return r+1;
        }
    }
}
