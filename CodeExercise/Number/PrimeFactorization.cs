using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    //235
    //Prime Factorization
    //https://www.lintcode.com/problem/prime-factorization/description
    // Given 10, return [2, 5].
    //Given 660, return [2, 2, 3, 5, 11].
    // O(sqrt(N))
    class PrimeFactorization
    {
        public List<int> primeFactorizationSolver(int num)
        {
            List<int> ans = new List<int>();

            // 34,   sqrt = 5   i = 2~5 check, any thing > 5 must be prime, otherwise, a smaller one should make it small
            for (int i = 2; i*i <= num; i++)    // yic sqrt   34  after sqrt, if != 1, the rest must be a prime
            {
                while (num%i ==0)
                {
                    ans.Add(i);
                    num /= i;
                }
            }

            if (num > 1)
            {
                ans.Add(num);
            }

            return ans;
        }


        /// <summary>
        /// 652. Factorization
        /// https://www.lintcode.com/problem/factorization/description
        /// A non-negative numbers can be regarded as product of its factors.
        /// Write a function that takes an integer n and return all possible combinations of its factors.
        /// 
        /// 
        /// Example
        /// Given n = 8
        /// return [[2,2,2], [2,4]]
        /// // 8 = 2 x 2 x 2 = 2 x 4.
        /// 
        /// Given n = 1
        /// return []
        /// 
        ///         Given n = 12
        /// return [[2,6],[2,2,3],[3,4]]
        /// 
        /// Notice
        /// Elements in a combination(a1, a2, … , ak) must be in non-descending order. (ie, a1 ≤ a2 ≤ … ≤ ak).
        /// The solution set must not contain duplicate combination.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<List<int>> GetFactors(int n)
        {
            List<List<int>> ans = new List<List<int>>();
            List<int> currPath = new List<int>();

            GetFactorHelpers(n, currPath, ans, n);

            return ans;

        }

        public void GetFactorHelpers(int n, List<int> path, List<List<int>> ans, int orig)
        {
            if (n <= 1)
            {
                List<int> copy = new List<int>(path);
                ans.Add(copy);
                return;
            }

            int last = path.Count > 0 ? path[path.Count - 1] : 2;

            // yic : i*i so that won't happen big*sm case, ex 5*4 case.  only 4 * 4 or 4*5
            for (int i = last; i*i <= n; i++)
            {
                if (n%i ==0)
                {
                    path.Add(i);

                    GetFactorHelpers(n / i, path, ans, orig);

                    path.RemoveAt(path.Count - 1);
                }
            }


            // yic : can include prime and total n; special case don't include orig
            if (n != orig)
            {
                path.Add(n);
                GetFactorHelpers(n / n, path, ans, orig);
                path.RemoveAt(path.Count - 1);
            }
            
        }
    }
}
