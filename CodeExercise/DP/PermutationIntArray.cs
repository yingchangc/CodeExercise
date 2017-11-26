using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    public class PermutationIntArray
    {
        public static IList<IList<int>> Permute(int[] nums)
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

            // * important
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
