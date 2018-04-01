using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class StoneGame
    {
        /// <summary>
        /// 476. Stone Game 
        /// http://www.lintcode.com/en/problem/stone-game/
        /// here is a stone game.At the beginning of the game the player picks n piles of stones in a line.

        /// The goal is to merge the stones in one pile observing the following rules:
        /// 
        /// At each step of the game, the player can merge two adjacent piles to a new pile.
        ///  The score is the number of stones in the new pile.
        ///  You are to determine the minimum of the total score.
        ///  
        /// For [4, 1, 1, 4], in the best solution, the total score is 18:
        /// 1. Merge second and third piles => [4, 2, 4], score +2
        /// 2. Merge the first two piles => [6, 4]，score +6
        /// 3. Merge the last two piles => [10], score +10
        /// Other two examples:
        /// [1, 1, 1, 1] return 8
        /// [4, 4, 5, 9] return 43
        /// 
        /// 
        /// Score[i,j] = min (Score[i,k] + Score[k+1,j] + computeScoreWhenMerge(i~j))
        /// 
        /// Note: computeMergescore can be simplifiy by
        //      initial memo 
        //    for(int i=0;i<A.length;i++){
        //    sums[i + 1]=sums[i]+A[i];
        // }
        /// sums[end + 1]-sums[start];


    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
    public int StoneGameSolver(int[] A)
        {
            int N = A.Length;
            if (N == 0)   // yic corner condition
            {
                return 0;
            }

            // yic init score to max
            int[,] Score = new int[N, N];
            for (int i = 0; i <N;i++)
            {
                for (int j = 0; j <N;j++)
                {
                    Score[i, j] = Int32.MaxValue;
                }
            }

            bool[,] visited = new bool[N, N];

            int ans = StoneGameHelper(A, Score, visited, 0, N - 1);
            return ans;
        }

        private int StoneGameHelper(int[] A, int[,] Score, bool[,] visited, int i, int j)
        {
            if (visited[i,j])
            {
                return Score[i, j];
            }

            if (i == j)
            {
                Score[i, j] = 0;    // only merge can get score
                visited[i, j] = true;
                return Score[i, j];
            }

            for (int k = i; k < j; k++)
            {
                int leftScore = StoneGameHelper(A, Score, visited, i, k);
                int rightScore = StoneGameHelper(A, Score, visited, k + 1, j);
                int newScore = leftScore + rightScore + computeMergeScore(A,i,j);
                Score[i, j] = Math.Min(Score[i, j], newScore);
            }

            visited[i, j] = true;
            return Score[i, j];
        }

        private int computeMergeScore(int[] A, int i, int j)
        {
            int score = 0;
            for (int k = i; k <=j; k++)
            {
                score += A[k];
            }

            return score;
        }



        /// <summary>
        /// There is a stone game.At the beginning of the game the player picks n piles of stones in a circle.
        /// 
        /// The goal is to merge the stones in one pile observing the following rules:
        /// 
        /// At each step of the game, the player can merge two adjacent piles to a new pile.
        ///  The score is the number of stones in the new pile.
        ///  You are to determine the minimum of the total score.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int stoneGame2(int[] A)
        {
            int N = A.Length;
            int[,] score = new int[2 * N, 2 * N];

            for (int i = 0; i < 2 * N; i++)
            {
                for (int j = 0; j < 2 * N; j++)
                {
                    score[i, j] = Int32.MaxValue;
                }
            }

            bool[,] visited = new bool[2 * N, 2 * N];

            int[] sum = new int[(2 * N)+1];
            sum[0] = 0;
            for (int i = 1; i <= 2 * N; i++)
            {
                sum[i] = sum[i-1] + A[(i-1) % N];         
            }

            int ans = Int32.MaxValue;
            for (int i =0; i < N; i++ )
            {
                int temp = StoneGame2Helper(A, score, visited, i, i+N-1, sum);
                ans = Math.Min(ans, temp);
            }
            

            return ans;
        }

        private int StoneGame2Helper(int[] A, int[,] score, bool[,] visited, int i, int j, int[] sum)
        {
            if (visited[i, j])
            {
                return score[i, j];
            }

            if (i == j)
            {
                score[i, j] = 0;   // yic only merge can get score
                visited[i, j] = true;
                return score[i, j];
            }

            for (int k = i; k < j; k++)
            {
                int leftScore = StoneGame2Helper(A, score, visited, i, k, sum);
                int rightScore = StoneGame2Helper(A, score, visited, k+1, j, sum);
                int computeMergeScore = sum[j+1] - sum[i];  // j+1/i+1 is the real upper/lower index
                int newScore = leftScore + rightScore + computeMergeScore;
                score[i, j] = Math.Min(score[i, j], newScore);
            }

            visited[i, j] = true;

            return score[i, j];
        }

    }

    
}
