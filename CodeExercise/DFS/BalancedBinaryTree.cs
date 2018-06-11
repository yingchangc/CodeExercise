using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class BalancedBinaryTree
    {
        /// <summary>
        /// 110. Balanced Binary Tree
        /// https://leetcode.com/problems/balanced-binary-tree/description/
        /// Given a binary tree, determine if it is height-balanced.

        /// For this problem, 
        /// a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of 
        /// every node never differ by more than 1.
        /// 
        /// 
        /// Example
        /// Given binary tree A = {3,9,20,#,#,15,7}, B = {3,#,20,15,7}
        /// 
        /// A)  3            B)    3 
        ///    / \                  \
        ///   9  20                 20
        ///     /  \                / \
        ///    15   7              15  7
        /// The binary tree A is a height-balanced binary tree, but B is not.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            int longest = longestPath(root);

            return longest != -1;
        }

        private int longestPath(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftPath = longestPath(root.left);
            int rightPath = longestPath(root.right);

            // yic don't forget left or right  already == -1 case
            if (leftPath == -1 || rightPath == -1 || Math.Abs(leftPath - rightPath) > 1)
            {
                return - 1;
            }

            return Math.Max(1+leftPath, 1+rightPath);
        }
    }
}
