using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class FindMissingNumber
    {
        bool foundFlag = false;
        int ans = -1;
        int totalNum = -1;
        int digit = 0;
        /// <summary>
        /// 570. Find the Missing Number II
        /// Giving a string with number from 1-n in random order, but miss 1 number.Find that number.
        /// 
        /// Example
        /// Given n = 20, str = 19201234567891011121314151618
        /// 
        /// return 17
        /// </summary>
        /// <param name="n"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private int missed = 0;

        public int FindMissing2(int n, string str)
        {
            int scan = 1;
            for (int i = 2; i <=n; i++)
            {
                scan = scan ^ i;
            }

            var res = DFS(str, scan, n, new HashSet<int>());

            if (res)
            {
                return missed;
            }

            return -1;
        }

        private bool DFS(string str, int scan, int n, HashSet<int> visited)
        {
            if (str.Length == 0)
            {
                missed = scan;
                return true;
            }

            // take1
            var one = str.Substring(0, 1);
            int oneNum = int.Parse(one);
            if (oneNum > 0 && oneNum < 10 && !visited.Contains(oneNum))
            {
                visited.Add(oneNum);
                var res1 = DFS(str.Substring(1), scan ^ oneNum, n, visited);
                if (res1 == true)
                {
                    return true;
                }
                visited.Remove(oneNum);
            }


            if (str.Length >=2)
            {
                var two = str.Substring(0, 2);

                int twonum = int.Parse(two);
                if (twonum >= 10 && twonum <= n && !visited.Contains(twonum))
                {
                    visited.Add(twonum);
                    bool res2 = DFS(str.Substring(2), scan ^ twonum, n, visited);
                    if (res2)
                    {
                        return true;
                    }
                    visited.Remove(twonum);
                }
            }

            return false;

        }


        /// <summary>
        /// 268. Missing Number
        /// https://leetcode.com/problems/missing-number/description/
        /// Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.
        /// Example 1:
        /// 
        /// Input: [3,0,1]
        ///         Output: 2
        /// Example 2:
        /// 
        /// Input: [9,6,4,2,3,5,7,0,1]
        ///         Output: 8
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
            int len = nums.Length;

            int ans = 0;
            for(int i =0; i<len; i++)
            {
                ans = ans ^ nums[i];
            }

            // do twice to cancel the exist number
            for (int i = 0; i <= len; i++)
            {
                ans = ans ^ i;
            }

            return ans;
        }
    }
}
