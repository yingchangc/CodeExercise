using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class SecondMinNodeInBTree
    {
        /// <summary>
        /// 671. Second Minimum Node In a Binary Tree
        /// https://leetcode.com/problems/second-minimum-node-in-a-binary-tree/
        /// Given a non-empty special binary tree consisting of nodes with the non-negative value, where each node in this tree has exactly two or zero sub-node. If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes.
        /// 
        /// Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree.
        /// 
        /// If no such second minimum value exists, output -1 instead.
        /// 
        /// Example 1:
        /// Input: 
        ///     2
        ///    / \
        ///   2   5
        ///      / \
        ///     5   7
        /// 
        /// Output: 5
        /// Explanation: The smallest value is 2, the second smallest value is 5.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return -1;
            }

            // must have left and right

            var left = FindCandidate(root.left, root.val);
            var right = FindCandidate(root.right, root.val);

            var min = Math.Min(left, right);
            var max = Math.Max(left, right);

            if (min == root.val && max == root.val)
            {
                return -1;
            }
            else if (min == root.val)
            {
                return max;
            }
            else
            {
                return min;
            }


        }

        private int FindCandidate(TreeNode n, int rootV)
        {
            if (n.left == null && n.right == null)
            {
                return n.val;
            }


            // curr is min, early terminate
            if (rootV != n.val)
            {
                return n.val;
            }

            var left = FindCandidate(n.left, rootV);
            var right = FindCandidate(n.right, rootV);

            var min = Math.Min(left, right);
            var max = Math.Max(left, right);

            if (rootV == min)
            {
                return max;
            }

            return min;

        }
    }
}
