﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class JumpGame
    {
        /// <summary>
        /// 55 Jump Game
        /// Given an array of non-negative integers, you are initially positioned at the first index of the array. 
        /// Each element in the array represents your maximum jump length at that position.
        /// Determine if you are able to reach the last index. 
        /// For example:
        /// A = [2, 3, 1, 1, 4], return true. 
        /// A = [3, 2, 1, 0, 4], return false. 
        /// </summary>
        /// 
        /// walk through each i   and keep update the max reach location
        /// if i > reach location in the walk, meaning no jum step can reach i
        /// 
        /// O(n)
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJump(int[] nums)
        {
            int maxReachLoc = 0;
            for (int i = 0; i<nums.Length; i++)
            {
                if (i > maxReachLoc)
                {
                    return false;
                }

                maxReachLoc = Math.Max(maxReachLoc, i + nums[i]);
            }

            return true;
        }

        //45
        /// https://www.youtube.com/watch?v=cETfFsSTGJI
        ///        Given an array of non-negative integers, you are initially positioned at the first index of the array.
        ///Each element in the array represents your maximum jump length at that position. 
        ///Your goal is to reach the last index in the minimum number of jumps.
        ///You can assume that you can always reach the last index.
        ///For example:
        ///Given array A = [2, 3, 1, 1, 4]
        /// minJumArr  =   [0, 1, 1, 2, 2]
        ///The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.)
        /// keep track the min of each index
        public static int Jump(int[] nums)
        {
            int maxJumpLoc = 0;
            int cend = 0;
            int jump = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int newLoc = Math.Min(nums.Length - 1, i + nums[i]);
                maxJumpLoc = Math.Max(maxJumpLoc, newLoc);

                if (i == cend)
                {
                    // *YIC reach max it can be, in the current [begin to end] someone need to jump
                    jump++;

                    cend = maxJumpLoc;
                }

            }

            // the fist jump to [0] does not count
            return jump -1;

            //  int[] minJumpArr = new int[nums.Length];
            //minJumpArr[0] = 0;  // init with first loc

            //for (int j = 0; j < nums.Length; j++)
            //{
            //    int minjumpToJ = j;
            //    for (int i = 0; i < j; i++)
            //    {
            //        if ((i + nums[i]) >= j)
            //        {
            //            // can reach
            //            minjumpToJ = Math.Min(minjumpToJ, minJumpArr[i] + 1);
            //        }
            //    }
            //    minJumpArr[j] = minjumpToJ;
            //}

            //return minJumpArr[nums.Length - 1];
        }
    }
}
