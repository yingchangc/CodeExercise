using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class FindDuplicateNumber
    {
        /// <summary>
        /// 287. Find the Duplicate Number
        /// https://leetcode.com/problems/find-the-duplicate-number/description/
        /// Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.

        /// Note:
        /// You must not modify the array(assume the array is read only).
        /// You must use only constant, O(1) extra space.
        /// Your runtime complexity should be less than O(n2).
        /// There is only one duplicate number in the array, but it could be repeated more than once.
        /// 
        /// refer to LinkedListCycle2
        /// 
        /// ex  
        /// idx 0  1  2  3  4  5  6
        /// val 1  4  6  6  6  2  3
        /// 
        /// ex 
        ///     0 1 2 3
        ///  v  1 3 1 2
        /// 
        /// start from 0th idx, its value shows position to jump
        /// 
        /// 1 -> 4 -> 6  -> 3  -> 6 -> 3 -> 6 ->3   cycle happened    cycle stat point will be duplicate   (because start == end)
        /// 
        /// 
        /// time: O(n)
        /// space: O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindDuplicate(int[] nums)
        {
            int N = nums.GetLength(0);

            int slow = 0;
            int fast = 0;

            // phase 1, find intersection
            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];   // move 2 steps
            }while(slow != fast);

            //fase 2, walk w==z distance   to find cycle begin point as warp around (dup)

            int pt1 = 0;
            int pt2 = slow;

            while(pt1 != pt2)
            {
                pt1 = nums[pt1];
                pt2 = nums[pt2];
            }

            return pt2;
        }



        /// sol nlog(n)
        public int FindDuplicate_NLOGN(int[] nums)
        {
            int N = nums.GetLength(0);

            Array.Sort(nums);

            int pre = nums[0];
            for (int i = 1; i < N; i++)
            {
                if (nums[i] == pre)
                {
                    return pre;
                }

                pre = nums[i];
            }

            // should not hit here
            return pre;
        }
    }
}
