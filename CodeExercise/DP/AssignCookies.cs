using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    /// <summary>
    /// 455 Assign Cookies
    /// </summary>
    class AssignCookies
    {
        /// <summary>
        /// Input: [1,2,3], [1,1]

        ///        Output: 1
        ///
        ///Explanation: You have 3 children and 2 cookies.The greed factors of 3 children are 1, 2, 3. 
        ///And even though you have 2 cookies, since their size is both 1, you could only make the child whose greed factor is 1 content.
        ///You need to output 1.

        ///        Input: [1,2], [1,2,3]
        ///
        ///        Output: 2
        ///
        ///Explanation: You have 2 children and 3 cookies.The greed factors of 2 children are 1, 2. 
        ///You have 3 cookies and their sizes are big enough to gratify all of the children, 
        ///You need to output 2.

        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int FindContentChildren(int[] children, int[] cookies)
        {
            Array.Sort(children, new Comparison<int>(
                            (i1, i2) => i1.CompareTo(i2)
                    ));   // small to large

            Array.Sort(cookies, new Comparison<int>(
                            (i1, i2) => i1.CompareTo(i2)
                    ));   // small to large

            int i = 0;
            int j = 0;
            int res = 0;

            while(i<children.Length && j < cookies.Length)
            {
                // [1,2,3]         [1,3,4]
                if (children[i] <= cookies[j])
                {
                    i++;
                    j++;
                    res++;
                }
                else
                {
                    //child [3,4,5]     cookie [1,2,3]
                    j++;
                }
            }

            return res;
        }
    }
}
