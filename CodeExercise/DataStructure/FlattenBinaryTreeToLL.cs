using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class FlattenBinaryTreeToLL
    {
        /// <summary>
        /// lint 453
        /// http://www.lintcode.com/en/problem/flatten-binary-tree-to-linked-list/
        /// Flatten a binary tree to a fake "linked list" in pre-order traversal.
        /// Here we use the right pointer in TreeNode as the next pointer in ListNode.
        /// 
        /// Example
        ///                  1
        ///                   \
        ///         1          2
        ///        / \          \
        ///       2   5    =>    3
        ///      / \   \          \
        ///     3   4   6          4
        ///                         \
        ///                          5
        ///                           \
        ///                            6
        /// 
        /// </summary>
        /// <param name="root"></param>
        public void flatten(TreeNode root)
        {
            var last = findLast(root);
        }

        private TreeNode findLast(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode leftLast = findLast(root.left); // real last in the left branch (yic don't care the detail of left's r /l)
            TreeNode rightLast = findLast(root.right); // real last in the right branch

            if (leftLast != null)
            {
                leftLast.right = root.right;  // connect left last to right branch
                root.right = root.left;  // reconnect right to left;
                root.left = null;   // disconnect left
            }

            // real last after earlier reconnect
            if (rightLast != null)
            {
                return rightLast;
            }

            // no right, try leftlast, since it is the last so far after reconnect
            if (leftLast != null)
            {
                return leftLast;
            }


            // no left and right
            return root;
        }
    }
}
