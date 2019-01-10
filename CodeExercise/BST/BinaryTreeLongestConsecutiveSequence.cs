using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class BinaryTreeLongestConsecutiveSequence
    {
        private int maxLen;

        /// <summary>
        /// 298. Binary Tree Longest Consecutive Sequence
        /// https://leetcode.com/problems/binary-tree-longest-consecutive-sequence/
        /// Given a binary tree, find the length of the longest consecutive sequence path.
        /// 
        /// The path refers to any sequence of nodes from some starting node to any node in the tree along the parent-child connections.The longest consecutive path need to be from parent to child (cannot be the reverse).
        /// 
        /// Example 1:
        /// 
        /// Input:
        /// 
        ///    1
        ///     \
        ///      3
        ///     / \
        ///    2   4
        ///         \
        ///          5
        /// 
        /// Output: 3
        /// 
        /// Explanation: Longest consecutive sequence path is 3-4-5, so return 3.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int LongestConsecutive(TreeNode root)
        {
            maxLen = 0;

            DFSHelper(root);

            return maxLen;
        }

        private int DFSHelper(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            var leftConseqLen = DFSHelper(node.left);
            var rightConseqLen = DFSHelper(node.right);

            var levelLenL = 1;
            var levelLenR = 1;

            if (node.left != null && node.val + 1 == node.left.val)
            {
                levelLenL += leftConseqLen;
            }


            if (node.right != null && node.val + 1 == node.right.val)
            {
                levelLenR += rightConseqLen;
            }


            maxLen = Math.Max(maxLen, Math.Max(levelLenL, levelLenR));


            return Math.Max(levelLenL, levelLenR);
        }
    }
}
