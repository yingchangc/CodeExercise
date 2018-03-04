using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 346
    /// https://leetcode.com/problems/moving-average-from-data-stream/description/
    /// Given a stream of integers and a window size, calculate the moving average of all integers in the sliding window.
    ///
    /// For example,
    /// MovingAverage m = new MovingAverage(3);
    /// m.next(1) = 1
    /// m.next(10) = (1 + 10) / 2
    /// m.next(3) = (1 + 10 + 3) / 3
    /// m.next(5) = (10 + 3 + 5) / 3
    /// </summary>
    class MovingAverage
    {
        int maxSize;
        int sum;
        Queue<int> slideWindow;
        public MovingAverage(int size)
        {
            slideWindow = new Queue<int>();
            maxSize = size;
            int sum = 0;
        }

        public double Next(int val)
        {
            if (slideWindow.Count >= maxSize)
            {
                //evict the earliest one
                var old = slideWindow.Dequeue();
                sum -= old;
            }

            slideWindow.Enqueue(val);
            sum += val;

            return 1.0 * sum / slideWindow.Count;
        }
    }
}
