using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class LCABinaryTree
    {
        /// <summary>
        /// 236. Lowest Common Ancestor of a Binary Tree
        /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
        /// Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
        /// According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants(where we allow a node to be a descendant of itself).”
        /// 
        /// Given the following binary search tree:  root = [3,5,1,6,2,0,8,null,null,7,4]
        /// 
        ///         _______3______
        ///        /              \
        ///     ___5__          ___1__
        ///    /      \        /      \
        ///    6      _2       0       8
        ///          /  \
        ///          7   4
        /// Example 1:
        /// 
        /// Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
        /// Output: 3
        /// Explanation: The LCA of of nodes 5 and 1 is 3.
        /// Example 2:
        /// 
        /// Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
        /// Output: 5
        /// Explanation: The LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself
        ///              according to the LCA definition.
        /// Note:
        /// 
        /// All of the nodes' values will be unique.
        /// p and q are different and both values will exist in the binary tree.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val == p.val || root.val == q.val)
            {
                return root;
            }

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
            {
                return root;
            }

            if (left != null)
            {
                return left;
            }

            return right;
        }

        public class ResultType
        {
            public bool pExist;

            public bool qExist;

            public TreeNode node;

            public ResultType()
            {
                pExist = false;
                qExist = false;
                node = null;
            }

            public ResultType(bool pexist, bool qexist, TreeNode n)
            {
                pExist = pexist;
                qExist = qexist;
                node = n;
            }
        }

        public TreeNode LowestCommonAncestor3(TreeNode root, TreeNode p, TreeNode q)
        {
            ResultType res = LowestCommonAncestor3Helper(root, p, q);

            if (res.pExist && res.qExist)
            {
                return res.node;
            }
            return null;
        }

        // Question qhere p  or q can be not in the tree
        public ResultType LowestCommonAncestor3Helper(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return new ResultType();
            }

            ResultType left = LowestCommonAncestor3Helper(root.left, p, q);
            ResultType right = LowestCommonAncestor3Helper(root.right, p, q);

            bool pexist = root.val == p.val || left.pExist || right.pExist;
            bool qexist = root.val == q.val || left.qExist || right.qExist;

            if (!pexist && !qexist)
            {
                return new ResultType();
            }
            else if (pexist && qexist)
            {
                // mid and one side
                if (root.val == p.val || root.val == q.val)
                {
                    return new ResultType(true, true, root);
                }

                // both side
                if (left.node != null && right.node !=null)
                {
                    return new ResultType(true, true, root);
                }

                // from only one child and is descend
                if (left.node != null)
                {
                    return new ResultType(true, true, left.node);
                }
                
                return new ResultType(true, true, right.node);
            }
            else if (pexist)
            {
                // root
                if (p.val == root.val)
                {
                    return new ResultType(true, false, root);
                }
                // child
                if (left.node != null)
                {
                    return new ResultType(true, false, left.node);
                }
                return new ResultType(true, false, right.node);
            }
            else
            {
                // root
                if (q.val == root.val)
                {
                    return new ResultType(false, true, root);
                }
                // child
                if (left.node != null)
                {
                    return new ResultType(false, true, left.node);
                }
                return new ResultType(false, true, right.node);
            }
        }
    }
}
