using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class PermutationSequence
    {
        /// <summary>
        /// 60. Permutation Sequence
        /// The set [1,2,3,...,n] contains a total of n! unique permutations.
        /// 
        /// By listing and labeling all of the permutations in order, we get the following sequence for n = 3:
        /// 
        /// "123"
        /// "132"
        /// "213"
        /// "231"
        /// "312"
        /// "321"
        /// Given n and k, return the kth permutation sequence.
        /// 
        /// Note:
        /// 
        /// Given n will be between 1 and 9 inclusive.
        /// Given k will be between 1 and n! inclusive.
        /// Example 1:
        /// 
        /// Input: n = 3, k = 3
        /// Output: "213"
        /// 
        /// 
        /// sol:
        /// say n = 4, you have {1, 2, 3, 4}
        /// 
        /// If you were to list out all the permutations you have
        /// 
        /// 1 + (permutations of 2, 3, 4)
        /// 
        /// 2 + (permutations of 1, 3, 4)
        /// 
        /// 3 + (permutations of 1, 2, 4)
        /// 
        /// 4 + (permutations of 1, 2, 3)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetPermutation(int n, int k)
        {

            List<int> candidate = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                candidate.Add(i);
            }
                                    // kth  means the loc is k-1
            var ans = Helper("", n, k-1, candidate);

            return ans;
        }

        private string Helper(string currPath, int n, int k, List<int> candidate)
        {
            if (candidate.Count == 1)
            {
                currPath += candidate[0];
                return currPath;
            }

            int subCombinations = 1;

            for (int i = 1; i < n; i++)
            {
                subCombinations *= i;
            }

            int pickIndex = k / subCombinations;

            currPath += candidate[pickIndex];
            candidate.Remove(candidate[pickIndex]);

            int remainK = k - pickIndex * subCombinations;

            return Helper(currPath, n - 1, remainK, candidate);
        }
    }
}
