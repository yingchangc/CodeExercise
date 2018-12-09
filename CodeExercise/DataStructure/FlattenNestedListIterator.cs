using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 341. Flatten Nested List Iterator
    /// https://leetcode.com/problems/flatten-nested-list-iterator/
    /// Given a nested list of integers, implement an iterator to flatten it.
    /// 
    /// Each element is either an integer, or a list -- whose elements may also be integers or other lists.
    /// 
    /// Example 1:
    /// 
    /// Input: [[1,1],2,[1,1]]
    /// Output: [1,1,2,1,1]
    ///     Explanation: By calling next repeatedly until hasNext returns false, 
    ///              the order of elements returned by next should be: [1,1,2,1,1].
    /// </summary>
    class FlattenNestedListIterator
    {
        public interface NestedInteger
        {
        
             // @return true if this NestedInteger holds a single integer, rather than a nested list.
             bool IsInteger();
        
             // @return the single integer that this NestedInteger holds, if it holds a single integer
             // Return null if this NestedInteger holds a nested list
             int GetInteger();
        
             // @return the nested list that this NestedInteger holds, if it holds a nested list
             // Return null if this NestedInteger holds a single integer
             IList<NestedInteger> GetList();
         }

        private Stack<NestedInteger> stk;
        public FlattenNestedListIterator(IList<NestedInteger> nestedList)
        {
            stk = new Stack<NestedInteger>();

            for (int i = nestedList.Count - 1; i >= 0; i--)   // use stk because if is list still need to push to front
            {
                stk.Push(nestedList[i]);
            }
        }

        public bool HasNext()
        {
            if (stk.Count == 0)
            {
                return false;
            }

            // make sure the top nesteInteger is integer
            var peek = stk.Peek();

            if (peek.IsInteger())
            {
                return true;
            }
            else
            {
                // for case[[]]   after breakdown, we get nothing in the stack
                return BreakDown(stk.Pop());  // yic must pop
            }

        }

        private bool BreakDown(NestedInteger ni)
        {
            var listNi = ni.GetList();

            for (int i = listNi.Count - 1; i >= 0; i--)
            {
                stk.Push(listNi[i]);
            }

            return HasNext();
        }

        public int Next()
        {
            var top = stk.Pop();
            return top.GetInteger();
        }
    }
}
