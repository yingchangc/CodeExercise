using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
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
        /// 
        /// sol
        /// backtrack
        /// Every parent point (x, y) has two children, (x, x+y) and (x+y, y). However, every point (x, y) only has one parent candidate (x-y, y)
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="tx"></param>
        /// <param name="ty"></param>
        /// <returns></returns>
        public bool ReachingPointsSolver(int sx, int sy, int tx, int ty)
        {
            return Helper(sx, sy, tx, ty);
        }

        private bool Helper(int sx, int sy, int tx, int ty)
        {
            while (tx > 0 && ty > 0)
            {
                int px, py;
                if (tx >= ty)  // = won't happen
                {
                    px = (tx - ty);   // (x+y,y)
                    py = (tx - px);
                }
                else
                {
                    py = (ty - tx);            // x, x+y
                    px = (ty - py);
                }

                if (px == sx && py == sy)
                {
                    return true;
                }

                if (px < sx || py < sy)
                {
                    return false;
                }
                tx = px;
                ty = py;
            }

            return false;
        }
    }
}
