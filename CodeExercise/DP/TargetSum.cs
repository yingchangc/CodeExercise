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
            Dictionary<int, Dictionary<int, int>> memo = new Dictionary<int, Dictionary<int, int>>();  // (indexLevel-> (presum, Ways))
            InitMemoization(nums, memo);

            int[] operatorArr = new int[2];
            operatorArr[0] = 1;
            operatorArr[1] = -1;

            int preSum = 0;
            int index = 0;
            int ans = FindTargetSumHelper(nums, operatorArr, preSum, S, index, memo);

            return ans;
        }

        

        private int FindTargetSumHelper(int[] nums, int[] operatorArr, int preSum, int target, int index, Dictionary<int, Dictionary<int,int>> memo)
        {
            // stop condition
            if (index >= nums.Length)
            {
                if (preSum == target)
                {
                    return 1;
                }
                return 0;
            }
            else if (memo[index].ContainsKey(preSum))
            {
                return memo[index][preSum];  // we have compuate before, when preSum at current index, we know how many ways
            }

            int currentLevelWays = 0;

            foreach(int op in operatorArr)
            {
                int temp = op * nums[index] + preSum;
                int ways = FindTargetSumHelper(nums, operatorArr, temp, target, index + 1, memo);
                currentLevelWays += ways;
            }

            memo[index][preSum] = currentLevelWays;

            return currentLevelWays;
        }


        private void InitMemoization(int[] nums, Dictionary<int, Dictionary<int, int>> memo)
        {
            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                memo[i] = new Dictionary<int, int>();
            }
        }
    }
}
