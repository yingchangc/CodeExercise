using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class GrayCode
    {
        /// <summary>
        /// 89. Gray Code
        /// https://leetcode.com/problems/gray-code/description/
        /// The gray code is a binary numeral system where two successive values differ in only one bit.
        /// 
        /// Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code.A gray code sequence must begin with 0.
        /// 
        /// Example 1:
        /// 
        /// Input: 2
        /// Output: [0,1,3,2]
        ///         Explanation:
        /// 00 - 0
        /// 01 - 1
        /// 11 - 3
        /// 10 - 2
        /// 
        /// For a given n, a gray code sequence may not be uniquely defined.
        /// For example, [0,2,3,1] is also a valid gray code sequence.
        /// 
        /// 00 - 0
        /// 10 - 2
        /// 11 - 3
        /// 01 - 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> GrayCodeSolver(int n)
        {
            List<int> ans = new List<int>();
            ans.Add(0);   // 0
            if (n == 0)
            {
                return ans;
            }

            ans.Add(1);   // 1  
            if (n == 1)
            {
                return ans;
            }

            // 0 00
            // 0 01
            // 0 11
            // 0 10
            // to add 1 bit and make sure 1 bit can change, pick array reversely
            // 1 10
            // 1 11
            // 1 01
            // 1 00

            // =>
            //0 0 00
            //0 0 01
            //0 0 11
            //0 0 10
            //0 1 10
            //0 1 11
            //0 1 01
            //0 1 00
            // to add 1 bit and make sure 1 bit can change, pick array reversely
            //1 1 00
            //1 1 01



            for (int i = 2; i < n; i++)
            {
                int size = ans.Count;
                for (int k = size - 1; k >= 0; k--)  // yic
                {
                    ans.Add((int)(Math.Pow(2, i)) + ans[k]);

                }
            }

            return ans;
        }
    }
}
