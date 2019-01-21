using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class PathSum
    {
        private List<List<int>> ans;
        /// <summary>
        /// 113. Path Sum II
        /// https://leetcode.com/problems/path-sum-ii/
        /// Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.
        /// 
        /// Note: A leaf is a node with no children.
        /// 
        /// Example:
        /// 
        /// Given the below binary tree and sum = 22,
        /// 
        ///       5
        ///      / \
        ///     4   8
        ///    /   / \
        ///   11  13  4
        ///  /  \    / \
        /// 7    2  5   1
        /// Return:
        /// 
        /// [
        ///    [5,4,11,2],
        ///    [5,8,4,5]
        /// ]
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public IList<IList<int>> PathSum2(TreeNode root, int sum)
        {

            ans = new List<List<int>>();

            PathHelper(root, sum, new List<int>());

            return ans.ToArray();
        }

        private void PathHelper(TreeNode n, int remaining, List<int> currPath)
        {
            if (n == null)
            {
                return;
            }

            remaining -= n.val;
            currPath.Add(n.val);


            if (remaining == 0 && n.left == null && n.right == null)
            {
                var cpy = new List<int>(currPath);
                ans.Add(cpy);
            }

            if (n.left != null)
            {
                PathHelper(n.left, remaining, currPath);
            }

            if (n.right != null)
            {
                PathHelper(n.right, remaining, currPath);
            }

            currPath.RemoveAt(currPath.Count - 1);
        }

        /// <summary>
        /// 112. Path Sum
        /// https://leetcode.com/problems/path-sum/solution/
        /// Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
        /// 
        /// Note: A leaf is a node with no children.
        /// 
        /// Example:
        /// 
        /// Given the below binary tree and sum = 22,
        /// 
        ///       5
        ///      / \
        ///     4   8
        ///    /   / \
        ///   11  13  4
        ///  /  \      \
        /// 7    2      1
        /// return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int sum)
        {
            return DFSHelper(root, sum);
        }

        private bool DFSHelper(TreeNode n, int remaining)
        {
            if (n == null)
            {
                return false;
            }

            remaining -= n.val;

            if (remaining == 0 && n.left == null && n.right == null)
            {
                return true;
            }

            if (n.left != null && DFSHelper(n.left, remaining))
            {
                return true;
            }

            if (n.right != null && DFSHelper(n.right, remaining))
            {
                return true;
            }

            return false;
        }
    }
}
