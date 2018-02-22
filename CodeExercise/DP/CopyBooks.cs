using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    
    class CopyBooks
    {
        /// <summary>
        /// lint code 437
        /// http://www.lintcode.com/en/problem/copy-books/
        /// 
        /// Given n books and the ith book has A[i] pages. You are given k people to copy the n books.
        ///n books list in a row and each person can claim a continous range of the n books.For example one copier can copy the books from ith to jth continously, but he can not copy the 1st book, 2nd book and 4th book (without 3rd book).
        ///They start copying books at the same time and they all cost 1 minute to copy 1 page of a book.What's the best strategy to assign books so that the slowest copier can finish at earliest time?
        /// <summary>
        /// 
        ///                        
        ///                     (Max(F[k-1,i], A[i]+...A[j-1])    //  either prev k-1 people has someone longest  or kth people is the longest
        /// F[k,j] = min i:0~j-1                       // find a i  that can minimize the
        /// 
        /// 
        /// Ans:
        /// Given array A = [3,2,4], k = 2.
        // Return 5( First person spends 5 minutes to copy book 1 and book 2 and second person spends 4 minutes to copy book 3. )
        /// <param name="pages"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int copyBooksSolver(int[] pages, int k)
        {
            int N = pages.Length;
            int[,] F = new int[k+1,N + 1];

            for (int numP = 0; numP <= k; numP++)
            {
                for (int j = 1; j <= N; j++)
                {
                    F[numP, j] = Int32.MaxValue;
                }       
            }

            // k people  0 books, effort is 0
            for (int i = 0; i <= k; i++)
            {
                F[i, 0] = 0;
            }         

            for (int numP = 1; numP <= k; numP++)
            {
                for (int j = 1; j <=N; j++)
                {
                    // Below need another for loop to compute pages[0] + ...pages[j-1]  ->->->-> pages[j-1]
                    // so can do reverse 

                    //for (int i = 0; i < j; i++)
                    //{
                    //    F[numP, j] = Math.Min(F[numP,j],  Math.Max(F[numP, i], pages[i] + ... pages[j - 1]) );
                    //}

                    int sum = 0;
                    for (int i = j; i >= 0; i--)
                    {
                                                                // either one of the previous numP-1 ppl dominate,  or the current writer 
                        F[numP, j] = Math.Min(F[numP, j], Math.Max(F[numP-1, i], sum));   // check from copy 0 to copy all

                        if ((i-1) >= 0)
                        {
                            sum += pages[i - 1];  // pre compute for next
                        }
                    }
                }
            }

            return F[k, N];
        }
    }
}
