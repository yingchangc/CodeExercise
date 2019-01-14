using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    /// <summary>
    /// 563. Binary Tree Tilt
    /// https://leetcode.com/problems/binary-tree-tilt/
    /// Given a binary tree, return the tilt of the whole tree.
    /// 
    /// The tilt of a tree node is defined as the absolute difference between the sum of all left subtree node values and the sum of all right subtree node values.Null node has tilt 0.
    /// 
    /// The tilt of the whole tree is defined as the sum of all nodes' tilt.
    /// 
    /// Example:
    /// Input: 
    ///          1
    ///        /   \
    ///       2     3
    /// Output: 1
    /// Explanation: 
    /// Tilt of node 2 : 0
    /// Tilt of node 3 : 0
    /// Tilt of node 1 : |2-3| = 1
    /// Tilt of binary tree : 0 + 0 + 1 = 1
    /// </summary>
    class BinaryTreeTilt
    {
        int ans;
        public int FindTilt(TreeNode root)
        {
            ans = 0;

            GetSumandTilt(root);

            return ans;
        }

        int GetSumandTilt(TreeNode n)
        {
            if (n == null)
            {
                return 0;
            }

            int left = GetSumandTilt(n.left);
            int right = GetSumandTilt(n.right);

            int currTilt = Math.Abs(left - right);

            ans += currTilt;

            return left + right + n.val;

        }
    }
}
