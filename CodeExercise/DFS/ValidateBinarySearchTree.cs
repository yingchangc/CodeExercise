using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class ValidateBinarySearchTree
    {
        /// <summary>
        /// 98. Validate Binary Search Tree
        /// https://leetcode.com/problems/validate-binary-search-tree/description/
        /// Given a binary tree, determine if it is a valid binary search tree (BST).
        /// Assume a BST is defined as follows:
        /// 
        /// The left subtree of a node contains only nodes with keys less than the node's key.
        /// The right subtree of a node contains only nodes with keys greater than the node's key.
        /// Both the left and right subtrees must also be binary search trees.
        /// Example 1:
        /// 
        /// Input:
        ///     2
        ///    / \
        ///   1   3
        /// Output: true
        /// Example 2:
        /// 
        ///     5
        ///    / \
        ///   1   4
        ///      / \
        ///     3   6
        /// Output: false
        /// Explanation: The input is: [5,1,4,null,null,3,6]. The root node's value
        ///              is 5 but its right child's value is 4.
        ///              
        /// sol:
        /// 
        /// think use stack
        /// 
        ///                5
        ///              4    9
        ///            3     8
        ///          2      7                   to store   2 3 4 5           than 7 8 9
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        TreeNode pre;
        bool isValid;
        public bool IsValidBST_Traverse(TreeNode root)  // O(n)  O(1) space good at space
        {
            isValid = true;
            pre = null;
            Inorder(root);

            return isValid;
        }

        private void Inorder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Inorder(node.left);

            if (!isValid)
            {
                return;
            }

            if (pre != null && pre.val >= node.val)
            {
                isValid = false;
                return;
            }

            pre = node;

            Inorder(node.right);

        }

        public bool IsValidBST_better(TreeNode root)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();
            InsertAllLeft(root, stk);

            int pre = Int32.MinValue;

            // yic: to prevent first node is MinValue
            bool isFirst = true;

            while (stk.Count > 0)
            {
                TreeNode curr = stk.Pop();
                if (!isFirst && pre >= curr.val)
                {
                    return false;
                }
                isFirst = false;

                pre = curr.val;

                if (curr.right != null)
                {
                    InsertAllLeft(curr.right, stk);
                }
            }

            return true;
        }

        private void InsertAllLeft(TreeNode root, Stack<TreeNode> stk)
        {
            TreeNode curr = root;
            while (curr != null)
            {
                stk.Push(curr);
                curr = curr.left;
            }
        }
    }
}
