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
