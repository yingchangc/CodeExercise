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
    }
}
