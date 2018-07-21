using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class IntersectionOfArrays
    {
        /// <summary>
        /// 793. Intersection of Arrays
        /// https://www.lintcode.com/problem/intersection-of-arrays/description
        /// 
        /// Give a number of arrays, find their intersection, and output their intersection size.
        /// 
        /// Example
        /// Given[[1,2,3],[3,4,5],[3,9,10]], return 1
        /// 
        /// explanation:
        /// Only element 3 appears in all arrays, the intersection is [3], and the size is 1.
        /// Given[[1, 2, 3, 4],[1,2,5,6,7]
        ///         [9,10,1,5,2,3]], return 2
        /// 
        /// explanation:
        /// Only element 1,2 appear in all arrays, the intersection is [1,2], the size is 2.
        /// 
        /// Note:
        /// The total number of all array elements is not more than 500000.
        /// There are no duplicated elements in each array.
        /// </summary>
        /// <param name="arrs"></param>
        /// <returns></returns>
        public int IntersectionOfArraysSolver(List<List<int>> arrs)
        {
            Dictionary<int, int> countLookup = new Dictionary<int, int>();
            int totalArrs = arrs.Count;

            for (int i = 0; i < totalArrs; i++)
            {
                foreach(var v in arrs[i])
                {
                    if (!countLookup.ContainsKey(v))
                    {
                        countLookup.Add(v, 0);
                    }
                    countLookup[v]++;
                }
            }

            int ans = 0;

            foreach (int key in countLookup.Keys)
            {
                if (countLookup[key] == totalArrs)
                {
                    ans++;
                }
            }

            return ans;
        }
    }
}
