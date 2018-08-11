using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class SubtreewithMaximumAverage
    {
        class ResultType
        {
            public double currMaxAvg= double.MinValue;
            public int currSum =0;
            public int currCount=0;
            public TreeNode target = null;

        }

        private TreeNode subtree = null;
        private ResultType subtreeResult = null;
        /// <summary>
        /// 597. Subtree with Maximum Average
        ///Given a binary tree, find the subtree with maximum average.Return the root of the subtree.
        ///
        ///Example
        ///Given a binary tree:
        ///
        ///     1
        ///   /   \
        /// -5     11
        /// / \   /  \
        ///1   2 4    -2 
        ///return the node 11.
        ///
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode FindSubtree2(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            ResultType ans = Traversal(root);
            return ans.target;

        }

        private ResultType Traversal(TreeNode node)
        {
            if (node ==null)
            {
                return new ResultType();
            }

            ResultType left = Traversal(node.left);
            ResultType right = Traversal(node.right);

            int currSum = node.val + left.currSum + right.currSum;
            int currCount = 1 + left.currCount + right.currCount;

            double currAvg = 1.0 * currSum / currCount;
            
            //left + right + curr
            if (currAvg > left.currMaxAvg && currAvg > right.currMaxAvg)
            {
                ResultType curr =  new ResultType();
                curr.currMaxAvg = currAvg;
                curr.currSum = currSum;
                curr.currCount = currCount;
                curr.target = node;
                return curr;
            }
            else if (left.currMaxAvg >= right.currMaxAvg)
            {
                // update sum and count for future
                left.currSum = currSum;
                left.currCount = currCount;
                return left;
            }
            else
            {
                right.currCount = currCount;
                right.currSum = currSum;
                return right;
            }

        }
    }
}
