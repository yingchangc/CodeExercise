using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class FrogJump
    {
        /// <summary>
        /// https://leetcode.com/problems/frog-jump/description/
        /// 403. Frog Jump
        /// A frog is crossing a river. The river is divided into x units and at each unit there may or may not exist a stone. The frog can jump on a stone, but it must not jump into the water.
        /// 
        /// Given a list of stones' positions (in units) in sorted ascending order, determine if the frog is able to cross the river by landing on the last stone. Initially, the frog is on the first stone and assume the first jump must be 1 unit.
        /// 
        /// If the frog's last jump was k units, then its next jump must be either k - 1, k, or k + 1 units. Note that the frog can only jump in the forward direction.
        /// 
        /// Note:
        /// 
        // The number of stones is ≥ 2 and is < 1,100.
        // Each stone's position will be a non-negative integer < 231.
        /// The first stone's position is always 0.
        /// Example 1:
        /// 
        /// [0,1,3,5,6,8,12,17]
        /// 
        ///         There are a total of 8 stones.
        ///         The first stone at the 0th unit, second stone at the 1st unit,
        ///         third stone at the 3rd unit, and so on...
        ///         The last stone at the 17th unit.
        /// 
        /// 
        ///         Return true. The frog can jump to the last stone by jumping 
        /// 1 unit to the 2nd stone, then 2 units to the 3rd stone, then
        ///         2 units to the 4th stone, then 3 units to the 6th stone,
        ///         4 units to the 7th stone, and 5 units to the 8th stone.
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public bool CanCross(int[] stones)
        {
            Dictionary<int, HashSet<int>> lookup = new Dictionary<int, HashSet<int>>();   // loc : {k-1 k, k+1 jump distance so that move to currloc}

            int[] deltas = { -1, 0, 1 };

            foreach (var loc in stones)
            {
                lookup.Add(loc, new HashSet<int>());
            }

            // 1st stone can jump at most 1  step (k+1)   so k = 0
            lookup[0].Add(0);

            int lastLoc = 0;
            foreach (var loc in stones)
            {
                lastLoc = loc;

                var jumpSet = lookup[loc];

                // cannot put here as [0,1,3,6,10,15,16,21]  16 has never reached  but 21 can be
                //if (jumpSet.Count == 0)
                //{
                //    return false;
                //}

                foreach (var move in jumpSet)
                {
                    // k-1, k , k+1
                    foreach (int delta in deltas)
                    {
                        int candidateMove = (move + delta);
                        if (candidateMove > 0 && lookup.ContainsKey(candidateMove + loc))  // has the stone to move
                        {
                            // can move to next stone
                            lookup[candidateMove + loc].Add(candidateMove);

                            //Console.WriteLine(candidateMove + loc + " : " + candidateMove);
                        }
                    }
                }
            }

            return lookup[lastLoc].Count > 0;
        }
    }
}
