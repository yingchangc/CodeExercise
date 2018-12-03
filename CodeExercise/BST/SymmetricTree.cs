using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    /// <summary>
    /// 101. Symmetric Tree
    /// https://leetcode.com/problems/symmetric-tree/
    /// Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
    /// 
    /// For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
    /// 
    ///     1
    ///    / \
    ///   2   2
    ///  / \ / \
    /// 3  4 4  3
    /// 
    /// But the following[1, 2, 2, null, 3, null, 3] is not:
    ///     1
    ///    / \
    ///   2   2
    ///    \   \
    ///    3    3
    /// </summary>
    class SymmetricTree
    {
        public bool IsSymmetric(TreeNode root)
        {

            if (root == null)
            {
                return true;
            }
            return Helper(root.left, root.right);
        }

        private bool Helper(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 == null)
            {
                return true;
            }
            if (n1 == null || n2 == null)
            {
                return false;
            }


            if (n1.val != n2.val)
            {
                return false;
            }

            return Helper(n1.left, n2.right) && Helper(n1.right, n2.left);
        }
    }
}
