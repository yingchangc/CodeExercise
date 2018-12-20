using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class AsteroidCollision
    {
        /// <summary>
        /// 735. Asteroid Collision
        /// We are given an array asteroids of integers representing asteroids in a row.
        /// 
        /// For each asteroid, the absolute value represents its size, and the sign represents its direction(positive meaning right, negative meaning left). Each asteroid moves at the same speed.
        /// 
        /// Find out the state of the asteroids after all collisions.If two asteroids meet, the smaller one will explode.If both are the same size, both will explode.Two asteroids moving in the same direction will never meet.
        /// 
        /// 
        /// Example 1:
        /// Input: 
        /// asteroids = [5, 10, -5]
        ///        Output: [5, 10]
        /// Explanation: 
        /// The 10 and -5 collide resulting in 10.  The 5 and 10 never collide.
        /// Example 2:
        /// Input: 
        /// asteroids = [8, -8]
        ///        Output: []
        /// Explanation: 
        /// The 8 and -8 collide exploding each other.
        /// Example 3:
        /// Input: 
        /// asteroids = [10, 2, -5]
        ///        Output: [10]
        /// Explanation: 
        /// The 2 and -5 collide resulting in -5.  The 10 and -5 collide resulting in 10.
        /// Example 4:
        /// Input: 
        /// asteroids = [-2, -1, 1, 2]
        ///        Output: [-2, -1, 1, 2]
        /// Explanation: 
        /// The -2 and -1 are moving left, while the 1 and 2 are moving right.
        ///        Asteroids moving the same direction never meet, so no asteroids will meet each other.
        /// 
        /// sol:
        /// 
        // mono stack    insert when same sign or  -5   3 case (ie  peek<=val)
        /// </summary>
        /// <param name="asteroids"></param>
        /// <returns></returns>
        public int[] AsteroidCollisionSolver(int[] asteroids)
        {
            Stack<int> mono = new Stack<int>();

            foreach (int val in asteroids)
            {
                bool done = false;
                while (mono.Count > 0)
                {
                    int peek = mono.Peek();

                    bool sameSign = (peek * val) >= 0;

                    // -4 -5           -3  5   mono
                    if (sameSign || peek <= val)
                    {
                        mono.Push(val);
                        done = true;
                        break;
                    }
                    else
                    {
                        if (Math.Abs(peek) == Math.Abs(val))
                        {
                            mono.Pop();
                            done = true;
                            break;
                        }
                        else if (Math.Abs(peek) > Math.Abs(val))
                        {
                            done = true;
                            break;
                        }
                        else
                        {
                            mono.Pop();
                        }
                    }
                }

                if (!done)
                {
                    mono.Push(val);
                }

            }

            int finalCount = mono.Count;

            int[] ans = new int[finalCount];

            for (int i = finalCount - 1; i >= 0; i--)
            {
                ans[i] = mono.Pop();
            }

            return ans;


        }
    }
}
