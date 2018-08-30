using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MergeTwoSortedArrays
    {
        /// <summary>
        /// 6. Merge Two Sorted Arrays
        /// https://www.lintcode.com/problem/merge-two-sorted-arrays/description
        /// Merge two given sorted integer array A and B into a new sorted integer array.
        /// 
        /// Example
        /// A =[1, 2, 3, 4]
        /// 
        /// B=[2,4,5,6]
        /// 
        /// return [1,2,2,3,4,4,5,6]
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[] MergeSortedArraySolver(int[] A, int[] B)
        {
            if (A == null || B == null)
            {
                return null; 
            }

            int totalLen = A.Length + B.Length;
            int[] ans = new int[totalLen];

            int ptrA = 0;
            int ptrB = 0;
            int index = 0;

            while (ptrA < A.Length && ptrB < B.Length)
            {
                if (A[ptrA] <= B[ptrB])
                {
                    ans[index++] = A[ptrA++];
                }
                else
                {
                    ans[index++] = B[ptrB++];
                }
            }

            while (ptrA < A.Length)
            {
                ans[index++] = A[ptrA++];
            }

            while(ptrB < B.Length)
            {
                ans[index++] = B[ptrB++];
            }

            return ans;  

        }
    }
}
