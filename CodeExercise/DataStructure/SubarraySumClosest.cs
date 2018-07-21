using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class SubarraySumClosest
    {
        class Item
        {
            public int sum;
            public int loc;

            public Item(int sum, int loc)
            {
                this.sum = sum;
                this.loc = loc;
            }
        }

        class ItemComparer : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                return x.sum.CompareTo(y.sum);
            }
        }

        /// <summary>
        /// 139. Subarray Sum Closest
        /// https://www.jiuzhang.com/solution/subarray-sum-closest/
        /// Given an integer array, find a subarray with sum closest to zero. Return the indexes of the first number and last number.
        /// 
        /// Example
        /// Given[-3, 1, 1, -3, 5], return [0, 2], [1, 3], [1, 1], [2, 2] or[0, 4].
        /// 
        /// 
        /// sol:
        /// 
        /// yic  need to add pre 0   at -1, so that idx 0 can be count from 
        /// 
        /// sum       0 |  -3  -2, -1 -4  1     check closeest value meaning the diff is small
        /// sort     -4   -3  -2  -1  0  1
        /// 
        /// idx       3    0   1   2 -1  4
        /// 
        /// check the neighbors and try find the smallest diff
        /// ex        -4   -3
        ///     idx    3     0          val   [-3, 1, 1, -3, 5]
        ///     so  idx loc 1 2 3  sum is close to 0
        ///          
        ///            -2    -1
        ///     idx     1     2
        ///     so  idx log  2  sum is cose to 0
        /// Challenge
        /// O(nlogn) time
        /// 
        /// 
        /// 问：为什么需要一个(0,0) 的初始 Pair?
        /// 答：
        /// 我们首先需要回顾一下，在 subarray 这节课里，我们讲过一个重要的知识点，叫做 Prefix Sum
        /// 比如对于数组[1, 2, 3, 4]，他的 Prefix Sum 是[1, 3, 6, 10]
        /// 分别表示 前1个数之和，前2个数之和，前3个数之和，前4个数之和
        /// 这个时候如果你想要知道 子数组 从下标  1 到下标 2 的这一段的和(2+3)，就用前 3个数之和 减去 前1个数之和 = PrefixSum[2] - PrefixSum[0] = 6 - 1 = 5
        /// 你可以看到这里的 前 x 个数，和具体对应的下标之间，存在 +-1 的问题
        /// 第 x 个数的下标是 x - 1，反之 下标 x 是第 x + 1 个数
        /// 那么问题来了，如果要计算 下标从 0~2 这一段呢？也就是第1个数到第3个数，因为那样会访问到 PrefixSum[-1]
        /// 所以我们把 PrefixSum 整体往后面移动一位，把第0位空出来表示前0个数之和，也就是0. => [0,1,3,6,10]
        ///         那么此时就用 PrefixSum[3] - PrefixSum[0] ，这样计算就更方便了。
        /// 此时，PrefixSum[i] 代表 前i个数之和，也就是 下标区间在 0 ~i-1 这一段的和
        /// 
        /// 那么回过头来看看，为什么我们需要一个(0,0) 的 pair 呢？
        /// 因为 这个 0,0 代表的就是前0个数之和为0
        /// 一个 n 个数的数组， 变成了 prefix Sum 数组之后，会多一个数出来
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SubarraySumClosestSol(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return null;
            }

            if (nums.Length==1)
            {
                return new int[2] { 0, 0 };
            }

            List<Item> sumLookup = new List<Item>();

            sumLookup.Add(new Item(0, -1));

            int sum = 0;
            for (int i = 0; i <nums.Length; i++)
            {
                sum += nums[i];
                sumLookup.Add(new Item(sum, i));
            }

            sumLookup.Sort(new ItemComparer());


            int minDiff = Int32.MaxValue;

            int[] ans = new int[2];

            Item pre = sumLookup[0];
            for (int i = 1;  i < sumLookup.Count; i++)
            {
                Item curr = sumLookup[i];

                int currDiff = Math.Abs(curr.sum - pre.sum);  // yic take abs
                if (currDiff <= minDiff)
                {
                    minDiff = currDiff;
                    
                    ans[0] = pre.loc <= curr.loc ? (pre.loc + 1) : (curr.loc + 1);    // + 1 becaue sum start from following loc
                    ans[1] = pre.loc <= curr.loc ? curr.loc : pre.loc;
                }
                
                // move to next
                pre = curr;
            }

            return ans;
        }
    }
}
