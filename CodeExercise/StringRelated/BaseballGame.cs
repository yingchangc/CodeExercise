using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class BaseballGame
    {
        /// <summary>
        /// 682. Baseball Game
        /// https://leetcode.com/problems/baseball-game/description/
        /// 
        /// You're now a baseball game point recorder.
        /// 
        /// Given a list of strings, each string can be one of the 4 following types:
        /// 
        /// Integer(one round's score): Directly represents the number of points you get in this round.
        /// "+" (one round's score): Represents that the points you get in this round are the sum of the last two valid round's points.
        /// "D" (one round's score): Represents that the points you get in this round are the doubled data of the last valid round's points.
        /// "C" (an operation, which isn't a round's score): Represents the last valid round's points you get were invalid and should be removed.
        /// Each round's operation is permanent and could have an impact on the round before and the round after.
        /// 
        /// You need to return the sum of the points you could get in all the rounds.
        /// 
        /// Example 1:
        /// Input: ["5","2","C","D","+"]
        ///         Output: 30
        /// Explanation: 
        /// Round 1: You could get 5 points.The sum is: 5.
        /// Round 2: You could get 2 points.The sum is: 7.
        /// Operation 1: The round 2's data was invalid. The sum is: 5.  
        /// Round 3: You could get 10 points(the round 2's data has been removed). The sum is: 15.
        /// Round 4: You could get 5 + 10 = 15 points.The sum is: 30.
        /// 
        /// </summary>
        /// <param name="ops"></param>
        /// <returns></returns>
        public int CalPoints(string[] ops)
        {
            Stack<int> stk = new Stack<int>();

            foreach (string op in ops)
            {
                int num;
                if (int.TryParse(op, out num))
                {
                    stk.Push(num);
                }
                else
                {
                    if (op == "C")
                    {
                        stk.Pop();
                    }
                    else if (op == "D")
                    {
                        stk.Push(stk.Peek() * 2);
                    }
                    else if (op == "+")
                    {
                        int first = stk.Pop();
                        int sec = stk.Pop();

                        int top = first + sec;

                        stk.Push(sec);
                        stk.Push(first);
                        stk.Push(top);
                    }

                }
            }

            int ans = 0;
            foreach (var num in stk)
            {
                ans += num;
            }

            return ans;
        }
    }
}
