using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    /// <summary>
    /// https://github.com/mission-peace/interview/blob/master/src/com/interview/binarysearch/MedianOfTwoSortedArrayOfDifferentLength.java
    /// Time complexity is O(log(min(x,y))
    /// Space complexity is O(1)
    /// </summary>
    public class MedianOfTwoSortedArray
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
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
