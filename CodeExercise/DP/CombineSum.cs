using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    //https://leetcode.com/problems/combination-sum/discuss/

    public class CombineSum
    {
        /// <summary>
        /// 216. Combination Sum III
        /// Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.
        ///        Example 1:
        ///Input: k = 3, n = 7
        ///Output: 
        ///
        ///[[1,2,4]]
        ///
        ///
        ///Example 2:
        ///Input: k = 3, n = 9
        ///Output: 
        ///
        ///[[1,2,6], [1,3,5], [2,3,4]]
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum3(int k, int n)
        {
            List<List<int>> answers = new List<List<int>>();
            List<int> currPath = new List<int>();

            CombinationSum3Helper(1, k, n, answers, currPath);

            return answers.ToArray();
        }

        private static void CombinationSum3Helper(int startNum, int leftSizeK, int n, List<List<int>> answers, List<int> currPath)
        {
            if (leftSizeK == 0)
            {
                if (n == 0)
                {
                    List<int> ans = new List<int>(currPath);
                    answers.Add(ans); 
                }
                return;
            }

            for (int i = startNum; i <= 9; i++)
            {
                int newNum = n - i;
                if (newNum < 0)
                {
                    continue;
                }

                currPath.Add(i);
                CombinationSum3Helper(i+1, leftSizeK - 1, newNum, answers, currPath);  // use startNum, to prevent target=3  [1,1,1] [1,2]      [2,1]   
                currPath.RemoveAt(currPath.Count - 1);   // note remove the last insert
            }
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=jaNZ83Q3QGc
        /// </summary>
        /// You are given coins of different denominations and a total amount of money.
        /// Write a function to compute the number of combinations that make up that amount. 
        /// 
        /// (1,2,3)  target 4
        /// 
        /// ans = 4
        /// ->
        /// [1 1 1 1]
        /// [1 1 2]
        /// [1 3]
        /// [2 2]
        /// 
        /// 
        /// sol:                                                                       amount
        /// 
        ///       0 1 2 3 4             for each new coin seleciton     orig + (how many combine before current coin)
        ///init   1 0 0 0 0
        ///give 1   1 a b 1              a = arr[2]_orig_b4_coin1 + arr[2-1] = 1    b =arr[3]+arr[3-1]= 1    
        ///give 2     c d e              c=  arr[2] + arr[2-1] = 1+1  d =arr[3]+arr[3-2]=1+1=2   e= arr[4]+arr[4-2]=1+2=3
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int CombinationSum4_1NoDupCombination(int[] coins, int target)
        {
            int[] ansArr = new int[target + 1];   // put 0 as 1 for padding purpose and a[0] = 1 
            ansArr[0] = 1;

            foreach(int coin in coins)
            {
                for(int currentTarget = 0; currentTarget <= target; currentTarget++)
                {
                    if (currentTarget >= coin)
                    {
                        ansArr[currentTarget] += ansArr[currentTarget - coin];    //inital currAns before having the coin + ways if having the current coin
                    }
                }

                Print4_1ForEachCoin(ansArr, coin, target);
            }

            return ansArr[target];
        }

        private static void Print4_1ForEachCoin(int[] ansArr, int currentCoint, int target)
        {
            Console.WriteLine("Add coin :" + currentCoint + " ");

            for (int i = 0; i <= target; i++)
            {
                Console.Write(i + "   ");
            }
            Console.WriteLine();

            for (int i = 0; i<=target; i++)
            {
                Console.Write(ansArr[i] + "   ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 377
        /// Given an integer array with all positive numbers and no duplicates, find the number of possible combinations that add up to a positive integer target.
        ///        Example: 
        ///nums = [1, 2, 3]
        ///        target = 4
        ///
        ///The possible combination ways are:
        ///(1, 1, 1, 1)
        ///(1, 1, 2)
        ///(1, 2, 1)
        ///(1, 3)
        ///(2, 1, 1)
        ///(2, 2)
        ///(3, 1)
        ///
        ///Note that different sequences are counted as different combinations.
        ///
        ///not like q39 q40 the answer does not require unique combination 
        /// 
        ///Therefore the output is 7.
        ///
        ///Follow up:
        ///What if negative numbers are allowed in the given array?
        ///How does it change the problem?
        ///What limitation we need to add to the question to allow negative numbers?
        ///
        ///The problem with negative numbers is that now the combinations could be potentially of infinite length. Think about nums = [-1, 1] and target = 1. We can have all sequences of arbitrary length that follow the patterns -1, 1, -1, 1, ..., -1, 1, 1 and 1, -1, 1, -1, ..., 1, -1, 1 (there are also others, of course, just to give an example). So we should limit the length of the combination sequence, so as to give a bound to the problem.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int CombinationSum4(int[] nums, int target)
        {
            if (target == 0)
            {
                return 0;
            }

            Dictionary<int, int> memo = new Dictionary<int, int>();

            int ans=  CombinenaitonSum4Helper(nums, target, memo);
            return ans;
        }

        private static int CombinenaitonSum4Helper(int[] num, int target, Dictionary<int, int> memo)
        {
            // stop condition
            if (memo.ContainsKey(target))
            {
                return memo[target];
            }

            if (target == 0)
            {
                return 1;
            }

            int currentTargetAns = 0;

            // unlike q39 and q40  this quesiton can contain like  target=4,  [1,1,2] and [2,1,1] and [1,2,1].  
            // this can get repeat the same num 1,1,1,1  and also give diff combination
            // input [1,2,3]   target = 4
            // [1],1,1,1    [1],1,2,     [1],2,1      [1],3   =>   memo[1] = 1  memo[2]  = 2, memo[3] = 4

            // note at first iteration [1], we have collect memo for diff target count, but currentans =4  since target =3 

            // [2],1,1      [2],2              direct return memo[2]
            // [3],1                           direct return memo[1]
            

            // has to be start fomr 0,   sort and make it start with StartIndex will not work for unique combinaiton!, this sol is for random all combination
            for (int i = 0; i < num.Length; i++)
            {
                
                int newTarget = target - num[i];
                if (newTarget < 0)
                {
                    continue;
                }

                currentTargetAns += CombinenaitonSum4Helper(num, newTarget, memo);
            }

            memo[target] = currentTargetAns;

            return currentTargetAns;
        }

        /// <summary>
        /// 40
        /// https://leetcode.com/problems/combination-sum-ii/description/
        /// Given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T. 
        ///         Each number in C may only be used once in the combination.
        ///         Note:
        /// All numbers (including target) will be positive integers.
        /// The solution set must not contain duplicate combinations.
        /// No duplicate 
        /// For example, given candidate set [10, 1, 2, 7, 6, 1, 5] and target 8, 
        ///    A solution set is: 
        ///    [
        ///      [1, 7],
        ///      [1, 2, 5],
        ///      [2, 6],
        ///      [1, 1, 6]
        ///    ]
        ///    
        /// sort [10 7 6 5 2 1 1] 
        /// 
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<List<int>> ans = new List<List<int>>();
            List<int> currPath = new List<int>();
            DFSHelper2(candidates, target, 0, ans, currPath);
            return ans.ToArray();

        }

        private static void DFSHelper2(int[] candidates, int target, int index, List<List<int>> ans, List<int> currPath)
        {
            if (index > candidates.Length)
            {
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                if (i != index && candidates[i] == candidates[i-1])
                {
                    continue;
                }
                int temp = target - candidates[i];

                if (temp == 0)
                {
                    currPath.Add(candidates[i]);
                    List<int> copy = new List<int>(currPath);
                    ans.Add(copy);
                    currPath.RemoveAt(currPath.Count - 1);
                    break;
                }
                else if (temp > 0)
                {
                    currPath.Add(candidates[i]);
                    DFSHelper2(candidates, temp, i + 1, ans, currPath);
                    currPath.RemoveAt(currPath.Count - 1);
                }
            }

        }

        public static IList<IList<int>> CombinationSum2_old(int[] candidates, int target)
        {
            Array.Sort(candidates, new Comparison<int>(
                            (i1, i2) => i2.CompareTo(i1)
                    ));   // large to small,

            List<List<int>> results = new List<List<int>>();
            List<int> path = new List<int>();
            if (target > 0)
            {
                CombinationSum2Helper(candidates, target, 0, results, path);
            }

            return results.ToArray();
        }

        private static void CombinationSum2Helper(int[] candidates, int target, int index, List<List<int>> results, List<int> path)
        {
            if (target == 0)
            {
                List<int> result = new List<int>(path);
                results.Add(result);
                return;
            }


            for (int i = index; i < candidates.Length; i++)
            {
                // * YIC Note:  i != index, don't check previously because for case 
                // find 8, [6 , 1, [1]]   the last iteration [1] should not check i-1     
                //to find 2    [2,2,2], if 2 has reached previously, move on
                //  find 8, [7 , 1, 1]
                if (i != index && candidates[i] == candidates[i-1])
                {
                    continue;
                } 

                path.Add(candidates[i]);
                int newTarget = target - candidates[i];

                if (newTarget >= 0)
                {
                    CombinationSum2Helper(candidates, newTarget, i + 1, results, path);
                }
                path.Remove(candidates[i]);
        
            }
        }

        /// <summary>
        /// 39 https://leetcode.com/problems/combination-sum/description/
        /// Given a set of candidate numbers (C) (without duplicates) and a target number (T), find all unique combinations in C where the candidate numbers sums to T. 
        ///         The same repeated number may be chosen from C unlimited number of times.
        ///         Note:
        /// All numbers(including target) will be positive integers.
        /// The solution set must not contain duplicate combinations.
        /// given candidate set [2, 3, 6, 7] and target 7, 
        /// A solution set is: 
        ///        [
        ///          [7],
        ///          [2, 2, 3]
        ///        ]
        ///        
        /// 
        /// do not use the one has used before in dfs
        /// 
        /// ref 
        /// https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/SubsetSum.java
        /// https://www.youtube.com/watch?v=K20Tx8cdwYY
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSumAllowDuplicate(int[] candidates, int target)
        {
            List<List<int>> ans = new List<List<int>>();
            List<int> currPath = new List<int>();

            Array.Sort(candidates);
            DFSHelperDupe(candidates, target, 0, ans, currPath);

            return ans.ToArray();
        }

        private static void DFSHelperDupe(int[] candidates, int target, int index, List<List<int>> ans, List<int> currPath)
        {
            if (index >= candidates.Length)
            {
                return;
            }

            // candidate is sorted
            for (int i = index; i < candidates.Length; i++)
            {
                int temp = target - candidates[i];
                if (temp == 0)
                {
                    currPath.Add(candidates[i]);
                    List<int> copy = new List<int>(currPath);
                    ans.Add(copy);
                    currPath.RemoveAt(currPath.Count - 1);  // yic need to remove 
                    break;
                }
                else if (temp > 0)
                {
                    currPath.Add(candidates[i]);
                    DFSHelperDupe(candidates, temp, i, ans, currPath);
                    currPath.RemoveAt(currPath.Count-1);
                }
            }
        }

        public static IList<IList<int>> CombinationSumAllowDuplicate_old(int[] candidates, int target)
        {
            Array.Sort(candidates, new Comparison<int>(
                            (i1, i2) => i2.CompareTo(i1)
                    ));   // small to large,

            List<List<int>> results = new List<List<int>>();
            List<int> path = new List<int>();
            if (target > 0)
            {
                DFSForCombineSum_allowDup(candidates, target, 0, results, path);  // use helper method for For is enough
            }

            return results.ToArray();
        }

        private static void DFSForCombineSum_allowDup(int[] candidates , int target, int index, List<List<int>> results, List<int> path)
        {
            if (target == 0)
            {
                List<int> result = new List<int>(path);
                results.Add(result);
            }

            for(int i = index; i < candidates.Length; i++)
            {
                if (i > index && candidates[i] == candidates[i-1])
                {
                    // have use before, skip
                    continue;
                }

                int newTarget = target - candidates[i];
                if (newTarget < 0)
                {
                    // since sort by small to large, just return
                    return;
                }

                path.Add(candidates[i]);

                DFSForCombineSum_allowDup(candidates, newTarget, i, results, path);   // > 0 , keep using the same i, until next for

                path.Remove(candidates[i]);

            }

        }
    }
}
