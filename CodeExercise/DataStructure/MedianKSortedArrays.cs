using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MedianKSortedArrays
    {
        /// <summary>
        /// 931. Median of K Sorted Arrays
        /// 
        /// https://www.lintcode.com/problem/median-of-k-sorted-arrays/description
        /// 
        /// There are k sorted arrays nums.Find the median of the given k sorted arrays.
        /// 
        /// 
        /// Example
        /// Given nums = [[1], [2], [3]], return 2.00.
        /// 
        /// sol:
        /// (1)PQ
        /// (2) random select number and count total left size and adjust number to meet median index
        /// 
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public double FindMedian(List<List<int>> nums)
        {
            int k = nums.Count;

            int totalCounts = GetTotalNum(nums);

            if (totalCounts % 2 == 0)
            {
                return ((1.0 * FindKthHeler(nums, totalCounts / 2)) + (1.0 * FindKthHeler(nums, totalCounts / 2 + 1))) / 2.0;
            }

            return FindKthHeler(nums, totalCounts / 2 + 1);
        }

        private int FindKthHeler(List<List<int>> nums, int kth)
        {
            int minV = GetTotalMin(nums);
            int maxV = GetTotalMax(nums);

            // guess a mid value and count total how many below the threshold
            while ((minV + 1) < maxV)
            {
                int midV = minV + (maxV - minV) / 2;
                int countSEmidV = GetSmEqCountByRows(nums, midV);

                // == kth  still need to keep mke int more cloer until minV = maxV-1
                // for test case    guess midV == 50  can have count = 23   the same as true value 46 also has count = 23
                if (countSEmidV >= kth)
                {
                    maxV = midV;
                    
                }
                else
                {
                    minV = midV;
                }
            }

            // check minV  and midV
            int countMinV = GetSmEqCountByRows(nums, minV);
            if (countMinV == kth)
            {
                return minV;
            }
            return maxV;
        }

        private int GetSmEqCountByRows(List<List<int>> nums, int threshold)
        {
            int count = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                count += GetSmEqCountByRow(nums[i], threshold);
            }

            return count;
        }

        private int GetSmEqCountByRow(List<int> num, int threshold)
        {
            if (num == null || num.Count == 0)
            {
                return 0;
            }

            int left = 0;
            int right = num.Count - 1;

            while ((left+1) < right)
            {
                int mid = (left + (right - left) / 2);
                int midV = num[mid];
                if (threshold == midV)
                {
                    return mid + 1;
                }
                else if (threshold > midV)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            // t==[L]=t==[R]===t
            if (num[right] <= threshold)
            {
                return right + 1;
            }
            if (threshold < num[left])
            {
                return left;
            }
            return left + 1;

        }

        //already sorted
        private int GetTotalMin(List<List<int>> nums)
        {
            int k = nums.Count;

            int minV = Int32.MaxValue;
            for (int i = 0; i <k; i++)
            {
                if (nums[i].Count > 0)
                {
                    minV = Math.Min(nums[i][0], minV);
                }
            }

            return minV;
        }

        private int GetTotalMax(List<List<int>> nums)
        {
            int k = nums.Count;

            // might need to consider row 0 size case
            int maxV = Int32.MinValue;
            for (int i = 0; i < k; i++)
            {
                if (nums[i].Count > 0)
                {
                    maxV = Math.Max(nums[i][nums[i].Count-1], maxV);
                }
                
            }

            return maxV;
        }

        private int GetTotalNum(List<List<int>> nums)
        {
            int k = nums.Count;

            int count = 0;
            for (int i = 0; i < k; i++)
            {
                count += nums[i].Count;
            }

            return count;
        }
    }
}
