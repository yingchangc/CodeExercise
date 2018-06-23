using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    //https://leetcode.com/problems/combination-sum/discuss/

    public class PermutationIntArray
    {
        /// <summary>
        /// 46
        ///https://leetcode.com/problems/permutations/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Permute(int[] nums)
        {
            List<List<int>> resArray = new List<List<int>>();

            // method 1  swap originl array
            //permute(nums, 0, resArray);

            // method 2, use extra array to hold. each DFS level, for 0~n-1  skip when visited
            Array.Sort(nums);

            DFSHelper(nums, new List<int>(), resArray, new bool[nums.Length]);

            return resArray.ToArray();
        }

        private static void DFSHelper(int[] nums, List<int> currPath, List<List<int>> ans, bool[] visited)
        {
            if (currPath.Count == nums.Length)
            {
                List<int> copy = new List<int>(currPath);
                ans.Add(copy);
                return;
            }
            HashSet<int> currLevelHasVisitedValue = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                if (currLevelHasVisitedValue.Contains(nums[i]))
                {
                    continue;
                }

                currLevelHasVisitedValue.Add(nums[i]);

                visited[i] = true;
                currPath.Add(nums[i]);

                DFSHelper(nums, currPath, ans, visited);

                currPath.RemoveAt(currPath.Count - 1);
                visited[i] = false;
            }
        }


        public static IList<IList<int>> PermuteSwapArray(int[] nums)
        {
            List<List<int>> resArray = new List<List<int>>();
            permute(nums, 0, resArray);
            return resArray.ToArray();
        }

        private static void permute(int[] nums, int index, List<List<int>> resArray)
        {
            int len = nums.Length;
            if (index == (len -1))
            {
                List<int> res = new List<int>();

                for (int i = 0; i< len; i++)
                {
                    res.Add(nums[i]);
                }

                resArray.Add(res);
                return;
            }

            for (int j = index; j < len; j++)
            {
                swapArray(nums, index, j);
                permute(nums, index + 1, resArray); // move Index+1  not j
                swapArray(nums, j, index);

            }
        }

        private static void swapArray(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        /// <summary>
        /// Given a collection of numbers that might contain duplicates, return all possible unique permutations. 
        ///        For example,
        ///        [1, 1, 2] have the following unique permutations:
        ///        [
        ///          [1,1,2],
        ///          [1,2,1],
        ///          [2,1,1]
        ///        ]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
           
            List<List<int>> results = new List<List<int>>();
            PermuteUniqueHelper(nums, 0, results);

            return results.ToArray();
        }

        private static void PermuteUniqueHelper(int[] nums, int index, List<List<int>> results)
        {
            if (index == nums.Length)
            {
                List<int> result = new List<int>(nums);
                results.Add(result);
                return;
            }

            // * important  yic  cannot use i != index && num[i] == num[i-1]
            // because after top level has been swapped and num[i] == num[i-1] cannot hold
            //  0 9 0 1 0   < start level
            //  0 9 0 0 1

            //  0 9 1 0 0   < swap idx 2 and 3

            //  0 9 0 1 0   < swap idx 2 and 4  (no repeated)

            HashSet<int> appeared = new HashSet<int>();

            for (int i = index; i<nums.Length; i++)
            {

                //* YIC skip the same 
                if (appeared.Contains(nums[i]))
                {
                    continue;
                }

                appeared.Add(nums[i]);

                swapArray(nums, index, i);
                PermuteUniqueHelper(nums, index + 1, results);
                swapArray(nums, i, index);
            }
        }
    }
}
