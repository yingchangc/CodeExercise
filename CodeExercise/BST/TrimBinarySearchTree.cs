using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class TrimBinarySearchTree
    {
        /// <summary>
        /// 669. Trim a Binary Search Tree
        /// https://leetcode.com/problems/trim-a-binary-search-tree/
        /// Given a binary search tree and the lowest and highest boundaries as L and R, trim the tree so that all its elements lies in [L, R] (R >= L). You might need to change the root of the tree, so the result should return the new root of the trimmed binary search tree.
        /// 
        /// Example 1:
        /// Input: 
        ///     1
        ///    / \
        ///   0   2
        /// 
        ///   L = 1
        ///   R = 2
        /// 
        /// Output: 
        ///     1
        ///       \
        ///        2
        /// </summary>
        /// <param name="root"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            var trim = TrimSmaller(root, L);
            trim = TrimBigger(trim, R);

            return trim;
        }

        private TreeNode TrimSmaller(TreeNode node, int v)
        {
            if (node == null)
            {
                return null;
            }

            if (node.val >= v)
            {
                node.left = TrimSmaller(node.left, v);
                return node;
            }
            else //(node.val < v)
            {
                return TrimSmaller(node.right, v);
            }
        }

        private TreeNode TrimBigger(TreeNode node, int v)
        {
            if (node == null)
            {
                return null;
            }

            if (node.val <= v)
            {
                node.right = TrimBigger(node.right, v);
                return node;
            }
            else
            {
                return TrimBigger(node.left, v);
            }
        }
    }
}
