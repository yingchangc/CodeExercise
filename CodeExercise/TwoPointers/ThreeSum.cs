using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class ThreeSum
    {
        /// <summary>
        /// 59. 3Sum Closest
        /// https://www.lintcode.com/problem/3sum-closest/description
        /// Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. 
        /// Return the sum of the three integers.
        /// For example, given array S = [-1 2 1 -4], and target = 1. The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length<3)
            {
                return -1;
            }

            Array.Sort(numbers);

            int ans = numbers[0]+ numbers[1] + numbers[2];

            for (int i = 0; i < numbers.Length; i++)
            {
                int left = i + 1;
                int right = numbers.Length - 1;

                while (left < right)
                {
                    int sum = numbers[i]+numbers[left] + numbers[right];

                    // update answer
                    if( Math.Abs(ans - target) > Math.Abs(sum - target))
                    {
                        ans = sum;
                    }

                    if (sum == target)
                    {
                        return target;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }

                }
            }

            return ans;
            
        }

        // can be used for HashSet de duplicate
        class TrippleNode
        {
            public int a;
            public int b;
            public int c;

            public TrippleNode(int a, int b, int c)
            {
                this.a = a;
                this.b = b;
                this.c = c;

            }

            public override bool Equals(Object obj)
            {
                if (obj == null || !(obj is TrippleNode))
                    return false;
                else
                    return a == ((TrippleNode)obj).a && b == ((TrippleNode)obj).b && c == ((TrippleNode)obj).c;
            }

            public override int GetHashCode()
            {
                return 33*33*a+33*b+c;
            }
        }


        /// <summary>
        /// lint 57. 3Sum
        ///https://www.lintcode.com/problem/3sum/description
        ///Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in 
        ///the array which gives the sum of zero.
        ///Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ≤ b ≤ c)
        ///The solution set must not contain duplicate triplets.
        ///
        /// For example, given array S = {-1 0 1 2 -1 -4}, A solution set is:
        /// (-1, 0, 1)
        /// (-1, -1, 2)     
        /// 
        /// sol:
        /// 
        /// cannot use hashset as it does not rember the index and if it has appear before,
        /// so use 2 pointers,  if first number exist, go right
        ///  if second number (after add to answer) exists before, go right
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public List<List<int>> ThreeSumsolver(int[] numbers)
        {
            if (numbers == null || numbers.Length <3)
            {
                return null;
            }

            // sort for the ans requirement (list to be ascending)
            Array.Sort(numbers);
            int len = numbers.Length;

            List<List<int>> ans = new List<List<int>>();

            for (int i =0; i <len-2; i++)
            {
                if (i > 0 && numbers[i]==numbers[i-1])
                {
                    continue;

                    // YIC (numbers[i-1], numbers[i]), numbers[i+1]     if num i-1  == num i, i-1 has done all the possible combination
                }

                // apply two sum
                int target = 0 - numbers[i];

                int left = i + 1;
                int right = len-1;

                while (left < right)
                {
                    if ((numbers[left] + numbers[right]) == target)
                    {
                        ans.Add(new List<int>() { numbers[i], numbers[left], numbers[right] });

                        left++;
                        
                        // yic Note: after add to ans, need to keep go right to de-duplicate   [1,1,1],1  target =3
                        while (left < len && numbers[left] == numbers[left-1])
                        {
                            //just need to move left, because dup right cannot fullfil after
                            left++;
                        }
                    }
                    else if ((numbers[left] + numbers[right]) < target)
                    {
                        //yic just need to move left
                        left++;
                    }
                    else
                    {
                        right--;
                    }

                }
            }

            return ans;
        }
    }
}
