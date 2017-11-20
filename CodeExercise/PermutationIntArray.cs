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
    }
}
