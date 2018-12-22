using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class SplitArrayIntoConsecutiveSubsequences
    {
        /// <summary>
        /// 659. Split Array into Consecutive Subsequences
        /// https://leetcode.com/problems/split-array-into-consecutive-subsequences/
        /// You are given an integer array sorted in ascending order (may contain duplicates), you need to split them into several subsequences, where each subsequences consist of at least 3 consecutive integers. Return whether you can make such a split.
        /// 
        /// Example 1:
        /// Input: [1,2,3,3,4,5]
        ///         Output: True
        ///         Explanation:
        /// You can split them into two consecutive subsequences : 
        /// 1, 2, 3
        /// 3, 4, 5
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IsPossible(int[] nums)
        {
            // get freq
            SortedDictionary<int, int> lookup = new SortedDictionary<int, int>();
            foreach (var num in nums)
            {
                if (!lookup.ContainsKey(num))
                {
                    lookup.Add(num, 0);
                }
                lookup[num]++;
            }


            while (lookup.Keys.Count > 0)
            {
                var temp = new List<int>();
                int preFreq = 0;
                int preNum = 0;
                bool isBegin = true;


                foreach (var num in lookup.Keys.ToList())   // yic must copy key since lookup.Keys cannot change lookup value or key
                {
                    // stop when freq is smaller than prev, stop otherwise, next time will have gap
                    if (preFreq > lookup[num])
                    {
                        break;
                    }

                    if (isBegin)
                    {
                        preNum = num - 1;
                        isBegin = false;
                    }

                    // consecutive
                    if ((preNum + 1) != num)
                    {
                        break;
                    }

                    // update pre
                    preFreq = lookup[num];
                    preNum = num;

                    // decrease freq
                   lookup[num] = preFreq -1;
                   temp.Add(num);

                    if (lookup[num] == 0)
                    {
                        lookup.Remove(num);
                    }

                }

                

                if (temp.Count < 3)
                {
                    return false;
                }
            }

            return true;
        }

       
    }
}
