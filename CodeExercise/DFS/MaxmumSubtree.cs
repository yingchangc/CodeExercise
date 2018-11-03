using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class MaxmumSubtree
    {
        public class ResultType
        {
            public TreeNode maxNode;
            public int maxNodeV;

            public int rootSum;

            public ResultType(TreeNode maxNode, int maxNodeV, int rootSum)
            {
                this.maxNode = maxNode;
                this.maxNodeV = maxNodeV;
                this.rootSum = rootSum;
            }
        }

        public TreeNode FindSubtree(TreeNode node)
        {
            var r = findSubtreeSolver(node);

            return r.maxNode;
        }

        private ResultType findSubtreeSolver(TreeNode node)
        {
            if (node == null)
            {
                return new ResultType(maxNode:null, maxNodeV:Int32.MinValue, rootSum: 0);
            }

            var left = findSubtreeSolver(node.left);
            var right = findSubtreeSolver(node.right);

            int currLevelSum = left.rootSum + right.rootSum + node.val;

            if (currLevelSum >= left.maxNodeV && currLevelSum >= right.maxNodeV)
            {
                return new ResultType(maxNode:node, maxNodeV:currLevelSum, rootSum:currLevelSum);
            }
            else if (left.maxNodeV >= right.maxNodeV)
            {
                return new ResultType(left.maxNode, left.maxNodeV, currLevelSum);
            }
            else
            {
                return new ResultType(right.maxNode, right.maxNodeV, currLevelSum);
            }
        }
    }
}
