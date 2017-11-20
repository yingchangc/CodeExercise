using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Tree
{
    /// <summary>
    /// https://github.com/mission-peace/interview/blob/master/src/com/interview/tree/LowestCommonAncestorInBinaryTree.java
    /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
    /// for somehow the code has runtime error but the same logic in java passed
    /// O(n)
    /// </summary>
    public class LowestCommonAncestor
    {
        public static TreeNode FindCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || (p!=null && root.val == p.val) || (q!=null && root.val ==q.val))
            {
                return root;
            }

            TreeNode findLeft = FindCommonAncestor(root.left, p, q);
            TreeNode findRight = FindCommonAncestor(root.right, p, q);

            if (findLeft != null && findRight != null)
            {
                return root;
            }

            return findLeft != null ? findLeft : findRight;
        }
    }
}
