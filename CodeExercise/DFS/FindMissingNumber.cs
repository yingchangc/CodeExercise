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
        public int FindMissing2(int n, string str)
        {
            bool[] visited = new bool[n + 1];
            totalNum = n;
            int temp = n;
            while(temp > 0)
            {
                digit++;
                temp /= 10;
            }

            dfs(str, visited, 0);

            if (foundFlag)
            {
                return ans;
            }
            return -1;
        }

        private void dfs(string str, bool[] visited, int index)
        {
            if (foundFlag || index >= str.Length)
            {
                if (foundFlag == true)
                {
                    return;
                }
                foundFlag = true;
                ans = FindMissing(visited);
                return;
            }

            // yic case when "0"345
            if (str[index] == '0')
            {
                return;
            }

            for(int i =1; i <= digit; i++)
            {
                if ((index +i-1) <str.Length) // yic index+i-1   (i : width) is the end idx location
                {
                    string valstr = str.Substring(index, i);
                    int val = Convert.ToInt32(valstr);

                    if (0<val &&  val <= totalNum && !visited[val])   // yic cannot consider 0
                    {
                        visited[val] = true;
                        dfs(str, visited, index + i);
                        visited[val] = false;   // yic take back
                    }
                }    
            }
        }

        

        private int FindMissing(bool[] visited)
        {
            for (int i=1; i <= totalNum; i++)
            {
                if(!visited[i])
                {
                    return i;
                }
            }
            return -1;
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
