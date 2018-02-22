using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MinStack
    {

        private Stack<int> stk1;
        private Stack<int> minRecord;

        /// 155
        /// https://leetcode.com/problems/min-stack/description/
        /// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

        /// push(x) -- Push element x onto stack.
        /// pop() -- Removes the element on top of the stack.
        /// top() -- Get the top element.
        /// getMin() -- Retrieve the minimum element in the stack.
        /** initialize your data structure here. */
        public MinStack()
        {
            stk1 = new Stack<int>();
            minRecord = new Stack<int>();
        }

        public void Push(int x)
        {
            stk1.Push(x);
            
            if (minRecord.Count == 0 || minRecord.Peek() > x)
            {
                minRecord.Push(x);
            }
            else
            {
                minRecord.Push(minRecord.Peek());
            }
        }

        public void Pop()
        {
            stk1.Pop();
            minRecord.Pop();
        }

        public int Top()
        {
            return stk1.Peek();
        }

        public int GetMin()
        {
            return minRecord.Peek();
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
