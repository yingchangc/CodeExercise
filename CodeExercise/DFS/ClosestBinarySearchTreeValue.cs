using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class ClosestBinarySearchTreeValue
    {
        /// <summary>
        /// 270. Closest Binary Search Tree Value
        /// https://leetcode.com/problems/closest-binary-search-tree-value/description/
        /// Given a non-empty binary search tree and a target value, find the value in the BST that is closest to the target.
        /// Note:
        /// 
        /// Given target value is a floating point.
        /// You are guaranteed to have only one unique value in the BST that is closest to the target.
        /// Example:
        /// 
        /// Input: root = [4, 2, 5, 1, 3], target = 3.714286
        /// 
        ///     4
        ///    / \
        ///   2   5
        ///  / \
        /// 1   3
        /// 
        /// Output: 4
        /// 
        /// Sol:
        // [lower bound  <=]
        /// 
        /// (1)
        /// target 4

        ///    /
        ///   4   retrun 4
        ///  
        /// (2)
        /// target 3.1
        /// 
        ///      /
        ///     4
        ///    to left null, retrun null    because no lower
        ///  
        /// (3)
        /// target 4.1
        /// 
        ///     /
        ///    4
        ///   to right null, return null, but at current level return 4
        ///   
        /// 
        /// 
        /// [upper bond >]
        /// 
        /// (1)  target   4
        ///   
        ///       /
        ///      4
        ///   retrun null, since no  greater
        ///   
        /// (2) target  3
        /// 
        ///       /
        ///      4
        ///   to left, null, but at current level return 4
        ///   
        /// (3)  target 5
        /// 
        ///       /
        ///      4 
        ///    to right, null, return null becase no greater
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ClosestValue(TreeNode root, double target)
        {
            TreeNode smaller = CloseLower(root, target);
            TreeNode larger = CloseLarger(root, target);

            if (smaller == null)
            {
                return larger.val;
            }

            if (larger == null)
            {
                return smaller.val;
            }

            double diffSm = Math.Abs(target - smaller.val);
            double diffLg = Math.Abs(target - larger.val);

            if (diffSm <= diffLg)
            {
                return smaller.val;
            }

            return larger.val;

        }

        // <= target
        private TreeNode CloseLower(TreeNode root, double target)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val == target)
            {
                return root;
            }

            if (root.val < target)
            {
                // to right
                TreeNode right = CloseLower(root.right, target);
                if (right == null)
                {                  // no find child, since target is bigger
                    return root;   // so this is closest smaller than target
                }
                return right;
            }
            // else

            // curr > target
            // go to left ,  smaller is not yet find
            return CloseLower(root.left, target);   // can be null becasue we cannot find any lower than target

        }

        // > target
        private TreeNode CloseLarger(TreeNode root, double target)
        {
            if (root == null || root.val == target)
            {
                return null;
            }

            if (root.val < target)
            {
                return CloseLarger(root.right, target);   // find right larger, if there is 
            }

            // else   root > target
            // find left larger
            TreeNode left = CloseLarger(root.left, target);

            if (left != null)
            {
                // curr is bigger and close
                return left;
            }

            return root;
        }
    }
}
