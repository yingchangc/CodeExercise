using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class NestedListWeightSum
    {
        public interface NestedInteger
        {
        
            
             bool IsInteger();
        
             // @return the single integer that this NestedInteger holds, if it holds a single integer
             // Return null if this NestedInteger holds a nested list
             int GetInteger();
        

        
             // @return the nested list that this NestedInteger holds, if it holds a nested list
             // Return null if this NestedInteger holds a single integer
             IList<NestedInteger> GetList();
         }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nestedList"></param>
        /// <returns></returns>
        public int DepthSumSolver(IList<NestedInteger> nestedList)
        {
            var ans = DFSHelper(nestedList, 1);
            return ans;
        }

        private int DFSHelper(IList<NestedInteger> nestedList, int baseNum)
        {

            int currSum = 0;
            foreach (var inner in nestedList)
            {
                if (inner.IsInteger())
                {
                    currSum += (inner.GetInteger() * baseNum);
                }
                else
                {

                    currSum += DFSHelper(inner.GetList(), baseNum + 1);
                }
            }
            return currSum;
        }
    }
}
