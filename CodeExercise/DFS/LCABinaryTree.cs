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

        private bool findAncestor3 = false;

        public TreeNode LowestCommonAncestor3(TreeNode root, TreeNode p, TreeNode q)
        {
            var candidate = Traversal(root, p, q);
            if (findAncestor3)
            {
                return candidate;
            }
            return null;
        }

        private TreeNode Traversal(TreeNode node, TreeNode p, TreeNode q)
        {
            if (node == null)
            {
                return null;
            }


            // yic:  must go left and right first  for case find ancestor 1 and 3
            //  1
            //      3

            var left = Traversal(node.left, p, q);
            var right = Traversal(node.right, p, q);

            //    2
            // [1]    [3]
            if (left != null && right != null)
            {
                findAncestor3 = true;
                return node;
            }

            // [1]   yic  don't forget the same node case.
            if (node.val == p.val && node.val == q.val)
            {
                findAncestor3 = true;
                return node;
            }

            //   [2]
            //         [3]  
            if (node.val == p.val || node.val == q.val)
            {
                if (left != null || right != null)
                {
                    findAncestor3 = true;  
                }
                return node;
            }

            if (left != null)
            {
                return left;
            }
            return right;   // can be null as well
        }


        
    }
}
