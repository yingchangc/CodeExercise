using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class Point
    {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }
    }
    
    class UnionFindIsland2
    {
        int[] ufArray;

        public int Count { get; set; }

        public UnionFindIsland2(int n)
        {
            ufArray = new int[n];
            for(int i = 0; i <n; i++)
            {
                ufArray[i] = i;
            }

            this.Count = 0;
        } 
    
        public void Connect(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA != rootB)
            {
                ufArray[rootB] = rootA;

                Count--;
            }

        }


        public int Find(int a)
        {
            if (a!= ufArray[a])
            {
                int topAncestor = Find(ufArray[a]);
                ufArray[a] = topAncestor;  // compress
            }

            return ufArray[a];
        }

        public int Query()
        {
            return this.Count;
        }
    }

    class NumberOfIsland2
    {

        /// <summary>
        /// Lintcode 434
        /// http://www.lintcode.com/en/problem/number-of-islands-ii/
        /// Given a n,m which means the row and column of the 2D matrix and an array of pair A( size k). Originally, the 2D matrix is all 0 which means there is only sea in the matrix. The list pair has k operator and each operator has two integer A[i].x, A[i].y means that you can change the grid matrix[A[i].x][A[i].y] from sea to island. Return how many island are there in the matrix after each operator.
        ///         Notice
        /// 0 is represented as the sea, 1 is represented as the island.If two 1 is adjacent, we consider them in the same island.We only consider up/down/left/right adjacent.
        /// 
        /// Have you met this question in a real interview? Yes
        /// Example
        /// Given n = 3, m = 3, array of pair A = [(0, 0),(0,1),(2,2),(2,1)].
        /// 
        /// return [1,1,2,2].
        /// 
        /// Sol:
        /// 
        /// use union find technique
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="operators"></param>
        /// <returns></returns>
        public int[] NumIslands2(int n, int m, Point[] operators)
        {
            UnionFindIsland2 uf = new UnionFindIsland2(n * m);
            bool[,] grid = new bool[n, m];

            List<int> ans = new List<int>();

            var deltas = new List<Point>() { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1) };
            foreach (var op in operators)
            {
                // check map if connected
                int x = op.x;
                int y = op.y;

                grid[y, x] = true;
                uf.Count++;

                foreach (var delta in deltas)
                {
                    int nx = x + delta.x;
                    int ny = y + delta.y;

                    if ((nx >= 0 && nx < m) && (ny >= 0 && ny < n) && grid[ny, nx] == true)
                    {
                        int opLoc = y * m + x;
                        int nearLoc = ny * m + nx;
                        uf.Connect(opLoc, nearLoc);
                    }
                }

                ans.Add(uf.Count);
            }

            return ans.ToArray();
        }


        /// <summary>
        /// 305
        /// https://leetcode.com/problems/number-of-islands-ii/description/
        /// A 2d grid map of m rows and n columns is initially filled with water. We may perform an addLand operation which turns the water at position (row, col) into a land. Given a list of positions to operate, count the number of islands after each addLand operation. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
        ///
        ///        Example:
        ///
        ///Given m = 3, n = 3, positions = [[0, 0], [0, 1], [1, 2], [2, 1]].
        ///Initially, the 2d grid grid is filled with water. (Assume 0 represents water and 1 represents land).
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="positions"></param>
        /// <returns></returns>
        public IList<int> NumIslands2LeetCode(int m, int n, int[,] positions)
        {
            List<int> ans = new List<int>();

            UnionFindIsland2 uf = new UnionFindIsland2(m * n);

            var deltasX = new int[] { 1, -1, 0, 0 };
            var deltasY = new int[] { 0, 0, 1, -1};

            bool[,] grid = new bool[m, n];

            int numPositions = positions.GetLength(0);
            for (int i = 0; i < numPositions; i++)
            {
                int y = positions[i, 0];
                int x = positions[i, 1];

                uf.Count++;
                grid[y, x] = true;

                for(int k = 0; k < 4; k++)
                {
                    int ny = y + deltasY[k];
                    int nx = x + deltasX[k];

                    if ((ny >=0 && ny <m) && (nx >=0 && nx <n) && grid[ny,nx] == true)
                    {
                        int locA = y * n + x;
                        int locB = ny * n + nx;
                        uf.Connect(locA, locB);
                    }
                }

                ans.Add(uf.Count);
            }

            return ans;
        }
    }
}
