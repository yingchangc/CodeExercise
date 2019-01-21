using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class ReachingPoints
    {
        /// <summary>
        /// 780. Reaching Points
        /// https://leetcode.com/problems/reaching-points/
        /// A move consists of taking a point (x, y) and transforming it to either (x, x+y) or (x+y, y).
        /// 
        /// Given a starting point(sx, sy) and a target point(tx, ty), return True if and only if a sequence of moves exists to transform the point(sx, sy) to(tx, ty). Otherwise, return False.
        /// 
        ///     Examples:
        /// Input: sx = 1, sy = 1, tx = 3, ty = 5
        /// Output: True
        /// Explanation:
        /// One series of moves that transforms the starting point to the target is:
        /// (1, 1) -> (1, 2)
        /// (1, 2) -> (3, 2)
        /// (3, 2) -> (3, 5)
        /// 
        /// Input: sx = 1, sy = 1, tx = 2, ty = 2
        /// Output: False
        /// 
        /// Input: sx = 1, sy = 1, tx = 1, ty = 1
        /// Output: True
        /// 
        /// sol
        /// Say tx > ty. We know that the next parent operations will be to subtract ty from tx, 
        /// until such time that tx = tx % ty. When both tx > ty and ty > sy, we can perform all these parent operations in one step, replacing while tx > ty: tx -= ty with tx %= ty.
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="tx"></param>
        /// <param name="ty"></param>
        /// <returns></returns>
        public bool ReachingPoints_leetcode(int sx, int sy, int tx, int ty)
        {
            while (tx >= sx && ty >= sy)
            {
                //if (tx == sx && ty == sy)
                //{
                //    return true;
                //}

                if (tx >= ty)
                {
                    //(1)naive tx = tx - ty;

                    //(2) (9,3)  <- (6-3)  3 is min here
                    if (ty == sy)   // ty is min   tx is sx + accumu of sy
                    {
                        return ((tx - sx) % sy) == 0;
                    }
                    else
                    { // 15,9   <-  (6,9)   9 is not min here
                        tx = tx % ty;  // rather than tx -ty    ex. 2000 , 3    keep substract
                    }
                }
                else
                {
                    //ty = ty - tx;

                    if (tx == sx)
                    {
                        return ((ty - sy) % sx == 0);
                    }
                    else
                    {
                        ty = ty % tx;
                    }

                }
            }
            return false;
        }


        public bool ReachingPointsSolver_slow(int sx, int sy, int tx, int ty)
        {
            var visited = new HashSet<string>();

            var que = new Queue<Node>();

            que.Enqueue(new Node(sx, sy));

            while (que.Count > 0)
            {
                var curr = que.Dequeue();

                if (curr.x == tx && curr.y == ty)
                {
                    return true;
                }

                var n1_x = curr.x;
                var n1_y = curr.x + curr.y;
                string encodeN1 = n1_x + "," + n1_y;

                var n2_x = curr.x + curr.y;
                var n2_y = curr.y;
                string encodeN2 = n2_x + "," + n2_y;

                if (n1_x <= tx && n1_y <= ty && !visited.Contains(encodeN1))
                {
                    Console.WriteLine(encodeN1);
                    que.Enqueue(new Node(n1_x, n1_y));
                    visited.Add(encodeN1);
                }

                if (n2_x <= tx && n2_y <= ty && !visited.Contains(encodeN2))
                {
                    Console.WriteLine(encodeN2);
                    que.Enqueue(new Node(n2_x, n2_y));
                    visited.Add(encodeN2);
                }
            }

            return false;

        }

        class Node
        {
            public int x;
            public int y;
            public Node(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
