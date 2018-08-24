using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 251. Flatten 2D Vector
    /// https://leetcode.com/problems/flatten-2d-vector/description/
    /// Implement an iterator to flatten a 2d vector.
    /// 
    /// Example:
    /// 
    /// Input: 2d vector =
    /// [
    ///   [1,2],
    ///   [3],
    ///   [4,5,6]
    /// ]
    /// Output: [1,2,3,4,5,6]
    /// Explanation: By calling next repeatedly until hasNext returns false, 
    ///              the order of elements returned by next should be: [1,2,3,4,5,6].
    /// </summary>
    class Flatten2D_Vector
    {
        Queue<int> que;
         
        public Flatten2D_Vector(IList<IList<int>> vec2d)
        {
            que = new Queue<int>();
            foreach(var rowarr in vec2d)
            {
                foreach (var num in rowarr)
                {
                    que.Enqueue(num);
                }
            }
        }

        public bool HasNext()
        {
            return (que.Count > 0);

        }

        public int Next()
        {
            if (HasNext())
            {
                return que.Dequeue();
            }
            return -1;

        }
    }
}
