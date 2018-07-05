using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// https://www.lintcode.com/problem/implement-stack-by-two-queues/description
    /// 494. Implement Stack by Two Queues
    /// Implement a stack by two queues.The queue is first in first out (FIFO). That means you can not directly pop the last element in a queue.
    /// 
    /// Example
    /// push(1)
    /// pop()
    /// push(2)
    /// isEmpty() // return false
    /// top() // return 2
    /// pop()
    /// isEmpty() // return true
    /// 
    /// Sol: 
    /// 
    /// que1 can think as a pipe flow downward, keep only 1 item for pop
    /// 
    /// </summary>
    class StackUsingQueues
    {
        Queue<int> que1;
        Queue<int> que2;
        public StackUsingQueues()
        {
            que1 = new Queue<int>();
            que2 = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            que1.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            if (Empty())
            {
                throw new Exception("attemp to pop item from empty stack");
            }

            if (que1.Count ==0)
            {
                var temp = que1;
                que1 = que2;
                que2 = temp;
            }

            // leave the last item in que1 as newest
            while (que1.Count > 1)
            {
                que2.Enqueue(que1.Dequeue());
            }

            int res = que1.Dequeue();
            return res;
            
        }

        /** Get the top element. */
        public int Top()
        {
            if (Empty())
            {
                throw new Exception("attemp to top item from empty stack");
            }

            if (que1.Count == 0)
            {
                var temp = que1;
                que1 = que2;
                que2 = temp;
            }

            // leave the last item in que1 as newest
            while (que1.Count > 1)
            {
                que2.Enqueue(que1.Dequeue());
            }

            int res = que1.Peek();
            return res;

        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return que1.Count == 0 && que2.Count == 0;
        }
    }
}
