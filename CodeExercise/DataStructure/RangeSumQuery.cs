using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{

    class RangeSumQuery
    {

        public int[] sumArr;
        /// <summary>
        /// 303. Range Sum Query - Immutable
        /// https://leetcode.com/problems/range-sum-query-immutable/description/
        /// Given an integer array nums, find the sum of the elements between indices i and j(i ≤ j), inclusive.
        /// 
        /// Example
        /// Given nums = [-2, 0, 3, -5, 2, -1]
        /// 
        /// 
        /// sumRange(0, 2) -> 1
        /// sumRange(2, 5) -> -1
        /// sumRange(0, 5) -> -3
        /// 
        /// 
        /// sol:
        /// 
        ///      sum = [0, -2, -2, 1, -4, -2, -3]
        /// </summary>
        /// <param name="nums"></param>
        public RangeSumQuery(int[] nums)
        {
            sumArr = new int[nums.Length+1];

            for (int i = 1; i<= nums.Length; i++)
            {
                sumArr[i] += nums[i - 1] + sumArr[i-1];
            }
        }

        public int SumRange(int i, int j)
        {
            return sumArr[j + 1] - sumArr[i];
        }
    }


    /// <summary>
    /// 307. Range Sum Query - Mutable
    /// https://leetcode.com/problems/range-sum-query-mutable/description/
    /// Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
    /// 
    /// The update(i, val) function modifies nums by updating the element at index i to val.
    /// 
    /// Example:
    /// 
    /// Given nums = [1, 3, 5]
    /// 
    /// 
    /// sumRange(0, 2) -> 9
    /// update(1, 2)
    /// sumRange(0, 2) -> 8
    /// Note:
    /// 
    /// The array is only modifiable by the update function.
    /// You may assume the number of calls to update and sumRange function is distributed evenly.
    /// 
    /// 
    /// Binary Index Tree
    /// (1)
    /// update is affect to right
    /// add last bit until high bit
    /// 
    /// update[2]  =affect=>   B[2],  B[4]  ,  B[8]
    ///    0010                       0100     1000
    ///    
    /// 
    /// update[6]   =affect=>  B[6],  B[8]
    ///    0110                       1000 
    /// bit      1      2  3  4   5   6  7   8    9  
    /// binary   0001  01
    /// 
    /// 
    /// 
    /// (2)
    /// Get is accumlate from left
    /// by remove the last bit and until 0
    /// 
    /// getPrefix(4)  =>  B[4] 
    ///                   0100
    ///                   
    /// getPrefix(6)  =>   B[6]  +  B[4]
    ///                    0110     0100
    /// </summary>
    public class NumArrayMutable
    {
        int[] B;
        int[] arr;
        public NumArrayMutable(int[] nums)
        {
            arr = new int[nums.Length];
            B = new int[nums.Length + 1];  // start from 1 index #1
            
            // update inital B (init from 0)
            for (int i = 0; i < arr.Length; i++)
            {
                Update(i, nums[i]);
            }
        }

        //update will affect to B (i+1) self and B's right,  + last bit
        public void Update(int i, int val)
        {
            int pre = arr[i];

            // update to new val
            arr[i] = val;
            int delta = arr[i] - pre;
            

            // i is 0 based
            for (int j = i+1; j <= arr.Length; j += getLastBit(j))
            {
                B[j] += delta;
            }
        }


        
        public int SumRange(int i, int j)
        {
            int pre2 = GetPreFixSum(j);
            int pre1 = GetPreFixSum(i - 1);

            return pre2 - pre1;
        }

        // get sum will look left,  - last bit
        private int GetPreFixSum(int i)
        {
            int sum = 0;
            for (int j = i+1; j >0; j-= getLastBit(j))
            {
                sum += B[j];
            }

            return sum;
        }

        private int getLastBit(int x)
        {
            // 0010  &  1110

            return x & (-x);
        }
    }
}
