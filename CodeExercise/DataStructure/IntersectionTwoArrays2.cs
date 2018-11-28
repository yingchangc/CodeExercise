using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class IntersectionTwoArrays2
    {
        /// <summary>
        /// 350. Intersection of Two Arrays II
        /// https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
        /// 
        /// Given two arrays, write a function to compute their intersection.
        ///
        ///Example 1:
        ///
        ///Input: nums1 = [1,2,2,1], nums2 = [2,2]
        ///        Output: [2,2]
        ///        Example 2:
        ///
        ///Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        ///        Output: [4,9]
        ///        Note:
        ///
        ///Each element in the result should appear as many times as it shows in both arrays.
        ///The result can be in any order.
        ///Follow up:
        ///
        ///What if the given array is already sorted? How would you optimize your algorithm?
        ///
        /// Ans: use HelperSort()
        /// 
        ///What if nums1's size is small compared to nums2's size? Which algorithm is better?
        ///
        /// put smaller one to HashSet() to save space    Time cost still O(M+N)
        /// 
        ///What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
        ///
        /// Divide and counqur, external sort    num1_1 num1_2... vs   num2_1  num2_2
        /// 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length;
            int len2 = nums2.Length;

            return HelperSort(nums1, nums2);

            //if (len1 <= len2)
            //{
            //    return HelperHashMap(nums1, nums2);
            //}

            // return HelperHashMap(nums2, nums1);
        }


        public int[] HelperSort(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1, (x1, x2) => x1.CompareTo(x2));
            Array.Sort(nums2, (x1, x2) => x1.CompareTo(x2));

            List<int> ans = new List<int>();

            int len1 = nums1.Length;
            int len2 = nums2.Length;

            int i = 0;
            int j = 0;

            while (i < len1 && j < len2)
            {
                if (nums1[i] == nums2[j])
                {
                    ans.Add(nums1[i]);
                    i++;
                    j++;
                }
                else if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return ans.ToArray();
        }

        // num1 len is always SE to num2
        public int[] HelperHashMap(int[] nums1, int[] nums2)
        {
            List<int> ans = new List<int>();

            Dictionary<int, int> lookup = new Dictionary<int, int>();

            foreach (var num in nums1)
            {
                if (!lookup.ContainsKey(num))
                {
                    lookup.Add(num, 0);
                }
                lookup[num]++;
            }

            foreach (var num in nums2)
            {
                if (lookup.ContainsKey(num) && lookup[num] > 0)
                {
                    ans.Add(num);
                    lookup[num]--;
                }
            }

            return ans.ToArray();

        }
    }
}
