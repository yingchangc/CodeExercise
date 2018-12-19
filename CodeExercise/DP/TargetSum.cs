using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class TargetSum
    {
        /// <summary>
        /// 494
        /// http://zxi.mytechroad.com/blog/dynamic-programming/leetcode-494-target-sum/
        /// You are given a list of non-negative integers, a1, a2, ..., an, and a target, S. Now you have 2 symbols + and -. For each integer, you should choose one from + and - as its new symbol. 
        ///         Find out how many ways to assign symbols to make sum of integers equal to target S.
        ///         Example 1:
        /// Input: nums is [1, 1, 1, 1, 1], S is 3. 
        /// Output: 5
        /// Explanation: 
        /// 
        /// -1+1+1+1+1 = 3
        /// +1-1+1+1+1 = 3
        /// +1+1-1+1+1 = 3
        /// +1+1+1-1+1 = 3
        /// +1+1+1+1-1 = 3
        /// 
        /// There are 5 ways to assign symbols to make the sum of nums be target 3.
        /// 
        /// Note:
        /// The length of the given array is positive and will not exceed 20. 
        /// The sum of elements in the given array will not exceed 1000.
        /// Your output answer is guaranteed to be fitted in a 32-bit integer.
        /// 
        /// 
        /// BruteForce O(2^n)
        /// +     +    +    +    +
        ///   1 *   1    1    1    1      => 2^5 combination
        /// -     -    -    -    -
        /// 
        /// -------------------------------------------------
        /// 
        /// DP O(len*sum)  ie O(n*S)
        /// 
        /// input [1,1,1,1,1]
        ///  init start           0 
        /// index=0             [-1 1]
        /// append index=1      [-1-1, -1+1, 1-1, 1+1] => [-2,0,2]
        /// append index=2      [-3 -1 1,3]
        /// append index=3      [-4, -2 0, 2, 4]
        /// append index=4      [-5, -3, -1, 1, 3, 5]              ---------
        ///                                                                \|/
        /// 
        /// all possible ways of sum  = 2 * sum(a)   ie  2 * 5 +1    (-5 ~ 5)    
        /// and there are n level of index
        /// 
        /// O(n*S)          
        /// ---------------------------------------
        /// use memo
        ///                        \|/
        /// for example   [[1 -1 1], 1, 1]
        /// at index=3    if preSum = 1, we have memo  that there are 1 possible ways, since it has been compuated from [[1 1 -1] 1 1]
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int FindTargetSumWays(int[] nums, int S)
        {
            int[] ops = { -1, 1 };

            Dictionary<int, Dictionary<int, int>> visited = new Dictionary<int, Dictionary<int, int>>();

            return DFSHelper(nums, 0, 0, S, ops, visited);
        }

        private int DFSHelper(int[] nums, int idx, int preSum, int S, int[] ops, Dictionary<int, Dictionary<int, int>> visited)
        {
            if (idx >= nums.Length)
            {
                return (preSum == S) ? 1 : 0;
            }

            if (visited.ContainsKey(idx) && visited[idx].ContainsKey(preSum))
            {
                return visited[idx][preSum];
            }

            int currLevelWays = 0;

            foreach (var op in ops)
            {
                var curr = nums[idx] * op;
                currLevelWays += DFSHelper(nums, idx + 1, curr + preSum, S, ops, visited);
            }

            if (!visited.ContainsKey(idx))
            {
                visited.Add(idx, new Dictionary<int, int>());
            }
            visited[idx].Add(preSum, currLevelWays);

            return currLevelWays;
        }
    }
}
