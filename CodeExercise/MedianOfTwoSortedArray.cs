using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    /// <summary>
    /// 4. Median of Two Sorted Arrays
    /// https://leetcode.com/problems/median-of-two-sorted-arrays/description/
    /// https://github.com/mission-peace/interview/blob/master/src/com/interview/binarysearch/MedianOfTwoSortedArrayOfDifferentLength.java
    /// 
    /// There are two sorted arrays A and B of size m and n respectively. Find the median of the two sorted arrays.
    /// 
    /// Example
    /// Given A=[1,2,3,4,5,6]
    /// and B =[2, 3, 4, 5], the median is 3.5.
    /// 
    /// Given A =[1, 2, 3] and B =[4, 5], the median is 3.
    /// 
    /// sol
    /// 分治法。时间复杂度 log(n + m)
    /// </summary>
    public class MedianOfTwoSortedArray
    {
        // jiuzhang
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length;
            int len2 = nums2.Length;

            if ((len1 + len2) %2 == 0)
            {
                int ans1 = FindKthFromSortedArrays(nums1, nums2, 0, 0, (len1 + len2) / 2 );
                int ans2 = FindKthFromSortedArrays(nums1, nums2, 0, 0, (len1 + len2) / 2 +1);
                return 1.0 * (ans1 + ans2) / 2;
            }
            else
            {
                return FindKthFromSortedArrays(nums1, nums2, 0, 0, (len1 + len2) / 2+1);
            }
                
        }

        // yic use kth
        private static int FindKthFromSortedArrays(int[] nums1, int[] nums2, int start1, int start2, int kth)
        {
            //
            // 2 3
            // 4 5 6 7 8 9   shorter one used out.
            // can remove the longer one half since longer one must contrain waste
            if (start1 >= nums1.Length)
            {
                return nums2[start2+kth-1];     // yic "start"+kth -1
            }
            if (start2 >= nums2.Length)
            {
                return nums1[start1+kth-1];
            }

            // yic Important
            // 2 3
            // 1
            if (kth ==1)
            {
                return Math.Min(nums1[start1], nums2[start2]);
            }

            // 2 4 5 
            // 1 3 6    => half =  3

            int half = kth / 2;


            // cannot find half v from one of list
            if ((start1+half-1) >= nums1.Length)
            {
                //x 2 7
                //y 1 2 3 4
                return FindKthFromSortedArrays(nums1, nums2, start1, start2 + half, kth - half);
            }
            else if ((start2+half-1) >= nums2.Length)
            {
                return FindKthFromSortedArrays(nums1, nums2, start1 + half, start2, kth - half);
            }
            else
            {
                int num1HalfV = nums1[start1 + half - 1];
                int num2HalfV = nums2[start2 + half - 1];

                // redice size to half by rmove smaller half
                if (num1HalfV <= num2HalfV)
                {
                    return FindKthFromSortedArrays(nums1, nums2, start1 + half, start2, kth - half);
                }
                return FindKthFromSortedArrays(nums1, nums2, start1, start2 + half, kth - half);
            }
        }



        public static double FindMedianSortedArrays_old(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length;
            int len2 = nums2.Length;

            if (len1 > len2)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }


            int xlow = 0;
            int xhigh = len1;   // * concept of cut


            while (xlow <= xhigh)
            {
                int partitionX = (xlow + xhigh) / 2;
                int partitionY = (len1 + len2 + 1) / 2 - partitionX;
                int maxXLeft = partitionX == 0 ? int.MinValue : nums1[partitionX - 1]; // 0 means all in right, make a fake MinV in left for later compare,  partitionX - 1 to get right index
                int minXRight = partitionX == len1 ? int.MaxValue : nums1[partitionX]; // ==len1 meas all in left,make a fake MaxV in right, 

                int maxYLeft = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];
                int minYRight = partitionY == len2 ? int.MaxValue : nums2[partitionY];

                if (maxXLeft <= minYRight && maxYLeft <= minXRight)
                {
                    if ((len1 + len2) % 2 == 0)
                    {
                        //even
                        return (Math.Max(maxXLeft, maxYLeft) + Math.Min(minXRight, minYRight)) / 2.0;
                    }
                    else
                    {
                        //odd
                        return Math.Max(maxXLeft, maxYLeft);
                    }
                }
                else if (maxXLeft > minYRight)
                {
                    // nums1 cut location too big, move nums1 left
                    xhigh = partitionX - 1;
                }
                else
                {
                    xlow = partitionX + 1;
                }
            }

            throw new Exception("should not hit");
        }
    }
}
