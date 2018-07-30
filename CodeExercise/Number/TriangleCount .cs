using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class TriangleCount
    {
        /// <summary>
        /// Lint 382. Triangle Count 
        /// https://www.lintcode.com/en/old/problem/triangle-count/
        /// Given an array of integers, how many three numbers can be found in the array, 
        /// so that we can build an triangle whose three edges length is the three numbers that we find?
        /// 
        /// 
        /// 
        /// Given array S = [3,4,6,7], return 3. They are:
        ///
        ///[3,4,6]
        ///[3,6,7]
        ///[4,6,7]
        ///Given array S = [4,4,4,4], return 4. They are:
        ///
        ///[4(1),4(2),4(3)]
        ///[4(1),4(2),4(4)]
        ///[4(1),4(3),4(4)]
        ///[4(2),4(3),4(4)]
        ///
        /// 
        /// Sol
        /// The sum of the lengths of any two sides of a triangle is greater than the length of the third side.
        /// use 2 ptr
        /// 
        /// left, right   i
        /// 
        /// if (arr[left] + arr[right]) > arr[i]
        ///    ex  [3] 4 [6] [7]          means 4 can also be the answer, so ans += (right-left)   
        /// 
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public int TriangleCountSolver(int[] arr)
        {
            Array.Sort(arr);
            int ans = 0;
            int len = arr.Length;

            for (int i = len-1; i >=2; i--)
            {
                // two sum greater
                int left = 0;
                int right = i - 1;

                while (left < right)
                {
                    if (arr[left] + arr[right] > arr[i])
                    {
                        ans+=(right-left);
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            return ans;
        }
    }
}
