using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MonotonicArray
    {
        /// <summary>
        /// 896. Monotonic Array
        /// https://leetcode.com/problems/monotonic-array/description/
        /// An array is monotonic if it is either monotone increasing or monotone decreasing.
        /// 
        /// An array A is monotone increasing if for all i <= j, A[i] <= A[j].  An array A is monotone decreasing if for all i <= j, A[i] >= A[j].
        /// 
        /// Return true if and only if the given array A is monotonic.
        /// 
        /// 
        /// 
        /// Example 1:
        /// 
        /// Input: [1,2,2,3]
        ///         Output: true
        /// Example 2:
        /// 
        /// Input: [6,5,4,4]
        ///         Output: true
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public bool IsMonotonic(int[] A)
        {
            if (A == null || A.Length <= 1)
            {
                return true;
            }

            int triState = 0;  // -1(inc) 0 1 (dec)

            int pre = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (pre == A[i])
                {
                    continue;
                }

                if (pre < A[i])
                {
                    if (triState > 0)
                    {
                        return false;
                    }
                    triState = -1;
                }
                else
                {
                    // pre  > A[i]
                    if (triState < 0)
                    {
                        return false;
                    }
                    triState = 1;
                }

                pre = A[i];
            }

            return true;
        }
    }
}
