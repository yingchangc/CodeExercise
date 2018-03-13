using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class MergeSortedArray
    {
        /// <summary>
        /// Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
        ///        Note:
        ///You may assume that nums1 has enough space(size that is greater or equal to m + n) to hold additional elements from nums2.
        ///The number of elements initialized in nums1 and nums2 are m and n respectively.
        /// 
        /// PS: merge from end 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int index = m + n -1;

            // Use indexM   easy to get wrong!
            int indexM = m - 1; 
            int indexN = n - 1;
            while (indexM >= 0 && indexN >= 0)
            {
                if (nums1[indexM] > nums2[indexN])
                {
                    nums1[index--] = nums1[indexM--];   
                }
                else
                {
                    nums1[index--] = nums2[indexN--];
                }
            }

            while (indexM >= 0)
            {
                nums1[index--] = nums1[indexM--];
            }
            while (indexN >= 0)
            {
                nums1[index--] = nums2[indexN--];
            }
        }
    }
}
