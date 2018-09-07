using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class WoodCut
    {
        /// <summary>
        /// 182 Wood Cut
        /// http://www.lintcode.com/en/problem/wood-cut/
        /// Given n pieces of wood with length L[i] (integer array). Cut them into small pieces to guarantee you could 
        /// have equal or more than k pieces with the same length. What is the longest length you can get from the n pieces of wood? 
        /// Given L & k, return the maximum length of the small pieces.
        /// 
        /// Note: You couldn't cut wood into float length.
        /// If you couldn't get >= k pieces, return 0.
        /// 
        /// ex
        /// For L=[232, 124, 456], k=7, return 114.
        /// 
        /// sol.
        /// use the larget segment as right, 1 as left
        /// </summary>
        /// <param name="L"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int WoodCutSol(int[] L, int k)
        {
            if (L.GetLength(0) == 0)
            {
                return 0;
            }
            int maxWoodLen = FindMaxWoodLengthFromArray(L);

            int left = 1;
            int right = maxWoodLen;

            while((left+1) < right)
            {
                int mid = left + (right - left) / 2;
                int cuts = GetNumberOfCut(L, mid);

                if (cuts >= k)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            if (GetNumberOfCut(L, right)>=k)
            {
                return right;
            }
            else if (GetNumberOfCut(L, left) >= k)
            {
                return left;
            }

            return 0;
        }

        private int GetNumberOfCut(int[] L, int len)
        {
            int N = L.GetLength(0);
            int cuts = 0;
            for (int i = 0; i < N; i++)
            {
                cuts += (L[i] / len);
            }

            return cuts;
        }

        private int FindMaxWoodLengthFromArray(int[] L)
        {
            int N = L.GetLength(0);

            int max = L[0];

            for (int i =0; i <N; i++)
            {
                max = Math.Max(max, L[i]);
            }

            return max;
        }
    }
}
