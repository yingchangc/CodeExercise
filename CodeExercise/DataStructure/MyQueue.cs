using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MyQueue
    {
        private Stack<int> stk1;
        private Stack<int> stk2;
        public MyQueue()
        {
            stk1 = new Stack<int>();
            stk2 = new Stack<int>();
        }

        /*
         * @param element: An integer
         * @return: nothing
         */
        public void push(int element)
        {
            stk1.Push(element);
        }

        /*
         * @return: An integer
         */
        public int pop()
        {
            if (stk2.Count == 0)
            {
                while(stk1.Count > 0)
                {
                    stk2.Push(stk1.Pop());
                }
            }

            return stk2.Pop();
        }

        /*
         * @return: An integer
         */
        public int top()
        {
            if(stk2.Count == 0)
            {
                while (stk1.Count > 0)
                {
                    stk2.Push(stk1.Pop());
                }
            }

            return stk2.Peek();
        }

    }
}
