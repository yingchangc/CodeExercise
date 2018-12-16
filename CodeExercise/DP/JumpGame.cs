using System;
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
        /// A = [2, 3, 1, 1, 4], return true. 
        /// A = [3, 2, 1, 0, 4], return false. 
        /// http://www.lintcode.com/en/problem/jump-game/
        public static bool CanJump(int[] nums)
        {
            int len = nums.Length;
            int maxCanReach = 0;
            for (int i = 0; i < len; i++)
            {
                if (maxCanReach < i)
                {
                    return false;
                }

                maxCanReach = Math.Max(maxCanReach, i + nums[i]);
            }

            return true;
        }



        // version 1: Dynamic Programming
        // 这个方法，复杂度是 O(n^2) 可能会超时，但是依然需要掌握。
        //{ 2, 3, 1, 1, 4 };  
        // { 3,2,1,0,4};
        public static bool canJumpDP(int[] nums)
        {
            int len = nums.Length;
            bool[] memo = new bool[len];
            memo[0] = true;

            for (int j = 0; j < len; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    if (memo[i] && (i + nums[i]) >= j)    // i can jump to and then can jump ge to j
                    {
                        memo[j] = true;
                        break;
                    }
                }
            }

            return memo[len - 1];
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
        public static int JumpPractice_slow(int[] nums)
        {
            Dictionary<int, HashSet<int>> lookup = new Dictionary<int, HashSet<int>>();   // loc, {froms}
            Dictionary<int, int> minSteps = new Dictionary<int, int>(); // loc  minstep
            for (int i = 0; i < nums.Length; i++)
            {
                lookup.Add(i, new HashSet<int>());
                minSteps.Add(i, int.MaxValue);
            }

            minSteps[0] = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int canJumpRange = nums[i];

                for (int k = 1; k <= canJumpRange; k++)
                {
                    if ((i + k) < nums.Length)
                    {
                        lookup[i + k].Add(i); // add from
                        minSteps[i + k] = Math.Min(minSteps[i + k], minSteps[i] + 1);
                    }

                }
            }

            return minSteps[nums.Length - 1];
        }

        public static int Jump(int[] nums)
        {
            int maxJumpLoc = 0;
            int cend = 0;
            int jump = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int newLoc = i + nums[i];
                maxJumpLoc = Math.Max(maxJumpLoc, newLoc);

                if (i >= cend && i != (nums.Length - 1))
                {
                    // *YIC reach max it can be, in the current [begin to end] someone need to jump
                    jump++;

                    cend = maxJumpLoc;
                }

            }

            return jump;

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
