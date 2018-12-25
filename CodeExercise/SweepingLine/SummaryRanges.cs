using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SweepingLine
{
    class SummaryRanges
    {
        /// <summary>
        /// 228. Summary Ranges
        /// https://leetcode.com/problems/summary-ranges/
        /// Example 1:
        /// 
        /// Input:  [0,1,2,4,5,7]
        /// Output: ["0->2","4->5","7"]
        /// Explanation: 0,1,2 form a continuous range; 4,5 form a continuous range.
        /// 
        /// Sol:
        /// 
        /// Similiar to MergetInterval
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<string> SummaryRangesSolver(int[] nums)
        {

            List<Interval> temp = new List<Interval>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    temp.Add(new Interval(nums[i], nums[i]));
                }
                else
                {
                    var itval = temp[temp.Count - 1];
                    if (itval.right + 1 == nums[i])
                    {
                        // pure update range
                        itval.right = nums[i];
                    }
                    else
                    {
                        // skip
                        temp.Add(new Interval(nums[i], nums[i]));
                    }
                }
            }

            List<string> ans = new List<string>();

            foreach (var itval in temp)
            {
                if (itval.left == itval.right)
                {
                    ans.Add(itval.left.ToString());
                }
                else
                {
                    ans.Add(itval.left.ToString() + "->" + itval.right.ToString());
                }
            }

            return ans;

        }

        public class Interval
        {
            public int left;
            public int right;

            public Interval(int l, int r)
            {
                left = l;
                right = r;
            }
        }
    }
}
