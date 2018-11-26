using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class DailyTemperatures
    {
        /// <summary>
        /// 739. Daily Temperatures
        /// https://leetcode.com/problems/daily-temperatures/description/
        /// 
        /// Given a list of daily temperatures T, return a list such that, for each day in the input, tells you how many days you would have to wait until a warmer temperature. If there is no future day for which this is possible, put 0 instead.
        /// For example, given the list of temperatures T = [73, 74, 75, 71, 69, 72, 76, 73], your output should be[1, 1, 4, 2, 1, 1, 0, 0].
        /// 
        /// sol:
        /// 
        /// use mon stack starting from back, compare with stack to try find delta days, always push smaller in
        /// 
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public int[] DailyTemperaturesolver(int[] T)
        {
            Stack<Record> monoStk = new Stack<Record>();

            int[] ans = new int[T.Length];

            for (int i = T.Length - 1; i >= 0; i--)
            {
                int temp = T[i];

                while (monoStk.Count > 0)
                {
                    if (temp < monoStk.Peek().temp)
                    {
                        // curr is smaller, can maintain  mono
                        break;
                    }
                    monoStk.Pop();
                }

                if (monoStk.Count == 0)
                {
                    ans[i] = 0;
                }
                else
                {
                    ans[i] = monoStk.Peek().index - i;   // future warmer day index
                }

                monoStk.Push(new Record(temp, i));  // curr is always smaller than stack to maintain mono 
            }

            return ans;

        }

        public class Record
        {
            public Record(int temp, int index)
            {
                this.temp = temp;
                this.index = index;
            }

            public int temp;
            public int index;
        }
    }
}
