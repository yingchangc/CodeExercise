using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class BinaryTreePaths
    {
        /// <summary>
        /// 257. Binary Tree Paths
        /// https://leetcode.com/problems/binary-tree-paths/description/
        /// 
        /// Given a binary tree, return all root-to-leaf paths.
        /// Note: A leaf is a node with no children.
        /// 
        /// Example:
        /// 
        /// Input:
        /// 
        ///    1
        ///  /   \
        /// 2     3
        ///  \
        ///   5
        /// 
        /// Output: ["1->2->5", "1->3"]
        /// 
        ///         Explanation: All root-to-leaf paths are: 1->2->5, 1->3
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePathsSolver(TreeNode root)
        {
            List<string> paths = new List<string>();

            BinaryTreePathHelper(root, "", paths);
            return paths;
        }

        
        // "preapth" = 1->2   or ""
        private void BinaryTreePathHelper(TreeNode node, string prePath, List<string> paths)
        {
            if (node == null)
            {
                return;
            }

            string currPath = string.IsNullOrEmpty(prePath) ? node.val.ToString() : (prePath + "->" + node.val);

            if (node.left == null && node.right == null)
            {
                // leaf
                paths.Add(currPath);
                return;
            }

            if (node.left != null)
            {
                BinaryTreePathHelper(node.left, currPath, paths);
            }

            if (node.right != null)
            {
                BinaryTreePathHelper(node.right, currPath, paths);
            }

        }
    }
}
