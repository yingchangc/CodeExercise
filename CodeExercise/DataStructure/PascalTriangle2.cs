using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class PascalTriangle2
    {
        /// <summary>
        /// 119. Pascal's Triangle II
        /// https://leetcode.com/problems/pascals-triangle-ii/
        /// Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle.
        ///
        ///    1
        ///    11
        ///    121
        ///    1331
        ///    14641
        /// 
        ///Note that the row index starts from 0.
        ///
        ///
        ///In Pascal's triangle, each number is the sum of the two numbers directly above it.
        ///
        ///Example:
        ///
        ///Input: 3
        ///Output: [1,3,3,1]
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            int[] ans = new int[rowIndex + 1];

            ans[0] = 1;

            for (int i = 1; i <= rowIndex; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    ans[j] += ans[j - 1];
                }
            }

            return ans;
        }
    }
}
