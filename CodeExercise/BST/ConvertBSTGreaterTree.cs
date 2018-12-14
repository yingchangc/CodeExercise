using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class ConvertBSTGreaterTree
    {
        /// <summary>
        /// 538. Convert BST to Greater Tree
        /// https://leetcode.com/problems/convert-bst-to-greater-tree/
        /// Given a Binary Search Tree (BST), convert it to a Greater Tree such that every key of the original BST is changed to the original key plus sum of all keys greater than the original key in BST.
        /// 
        /// Example:
        /// 
        /// Input: The root of a Binary Search Tree like this:
        ///               5
        ///             /   \
        ///            2     13
        /// 
        /// Output: The root of a Greater Tree like this:
        ///              18
        ///             /   \
        ///           20     13
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST(TreeNode root)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();

            InsertAllRight(root, stk);

            int sum = 0;
            while (stk.Count > 0)
            {
                var curr = stk.Pop();
                curr.val += sum;
                sum = curr.val;

                InsertAllRight(curr.left, stk);
            }

            return root;

        }

        private void InsertAllRight(TreeNode node, Stack<TreeNode> stk)
        {
            while (node != null)
            {
                stk.Push(node);
                node = node.right;
            }
        }
    }
}
