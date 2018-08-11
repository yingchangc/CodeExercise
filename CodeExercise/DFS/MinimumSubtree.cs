using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class MinimumSubtree
    {
        public class ResultType
        {
            public int minV;
            public TreeNode node;

            public ResultType()
            {
                minV = Int32.MaxValue;
                node = null;
            }
        }

        public class ResultType2
        {
            public int minV;
            public TreeNode node;
            public int currSum;

            public ResultType2(int minV, TreeNode node, int sum)
            {
                this.minV = minV;
                this.node = node;
                this.currSum = sum;
            }
        }

        /// <summary>
        /// lint 596. Minimum Subtree
        /// https://www.lintcode.com/problem/minimum-subtree/description
        /// Given a binary tree, find the subtree with minimum sum.Return the root of the subtree.
        /// 
        ///        Example
        ///        Given a binary tree:
        /// 
        ///      1
        ///    /   \
        ///  -5     2
        ///  / \   /  \
        /// 0   2 -4  -5 
        /// return the node 1.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode FindSubtree(TreeNode root)
        {
            
            var result = FindSubtreeHelper2(root);

            return result == null ? null : result.node;
        }

        public ResultType2 FindSubtreeHelper2(TreeNode node)
        {
            if (node == null)
            {                             // min   node, sum
                var test =  new ResultType2(int.MaxValue, null, 0);  // yic  so that we don't need to check resultType null case
                return test;
            }

            var left = FindSubtreeHelper2(node.left);
            var right = FindSubtreeHelper2(node.right);

            int currSum = node.val + left.currSum + right.currSum;
                        
            if(currSum < left.minV && currSum < right.minV)
            {
                return new ResultType2(currSum, node, currSum);
            }
            else if (left.minV <= right.minV)
            {
                left.currSum = currSum;
                return left;
            }
            else
            {
                right.currSum = currSum;
                return right;
            }

        }

        public TreeNode FindSubtree_old(TreeNode root)
        {
            ResultType result = new ResultType();
            FindSubtreeHelper(root, result);

            return result.node;
        }

        public int FindSubtreeHelper(TreeNode root, ResultType result)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                if (result.minV > root.val)
                {
                    result.minV = root.val;
                    result.node = root;
                }
                return root.val;
            }

            int leftV = FindSubtreeHelper(root.left, result);
            int rightV = FindSubtreeHelper(root.right, result);

            int subtreeSum = leftV + rightV + root.val;

            if (subtreeSum < result.minV)
            {
                result.minV = subtreeSum;
                result.node = root;  
            }

            return subtreeSum;

        }
    }
}
