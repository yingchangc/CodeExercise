﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class IntersectionofTwoArrays
    {
        /// <summary>
        /// 349. Intersection of Two Arrays
        /// https://leetcode.com/problems/intersection-of-two-arrays/description/
        /// iven two arrays, write a function to compute their intersection.
        /// 
        /// Example:
        /// Given nums1 = [1, 2, 2, 1], nums2 = [2, 2], return [2].
        /// 
        /// Note:
        /// Each element in the result must be unique.
        /// The result can be in any order.
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> lookup1 = new HashSet<int>();


            foreach (int v in nums1)
            {
                lookup1.Add(v);
            }

            HashSet<int> ans = new HashSet<int>();

            foreach(int v in nums2)
            {
                if (lookup1.Contains(v))
                {
                    ans.Add(v);
                }
            }
            return ans.ToArray();

        }

        public int[] IntersectionSort(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            int len1 = nums1.Length;
            int len2 = nums2.Length;

            int count1 = 0;
            int count2 = 0;

            HashSet<int> ans = new HashSet<int>();
            while(count1 < len1 && count2 < len2)
            {
                if (nums1[count1] == nums2[count2])
                {
                    ans.Add(nums1[count1]);
                    count1++;
                    count2++;
                }
                else if (nums1[count1] > nums2[count2])
                {
                    count2++;
                }
                else
                {
                    count1++;
                }
            }

            return ans.ToArray();
        }
    }
}
