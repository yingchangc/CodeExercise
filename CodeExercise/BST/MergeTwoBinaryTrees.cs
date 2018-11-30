using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class MergeTwoBinaryTrees
    {
        /// <summary>
        /// 617. Merge Two Binary Trees
        /// https://leetcode.com/problems/merge-two-binary-trees/
        /// Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.
        /// 
        /// You need to merge them into a new binary tree.The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node.Otherwise, the NOT null node will be used as the node of new tree.
        /// 
        /// Example 1:
        /// 
        /// Input: 
	    ///     Tree 1                     Tree 2                  
        ///           1                         2                             
        ///          / \                       / \                            
        ///         3   2                     1   3                        
        ///        /                           \   \                      
        ///       5                             4   7                  
        /// Output: 
        /// Merged tree:
	    ///          3
	    ///         / \
	    ///        4   5
	    ///       / \   \ 
	    ///      5   4   7
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {

            return MergeHelper(t1, t2);
        }

        
        private TreeNode MergeHelper(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return null;
            }

            if (t1 == null)
            {
                // note if use new TreeNode, need to traverse down and get all chain
                return t2;
            }
            if (t2 == null)
            {
                return t1;
            }

            // merge root
            var curr = t1;
            curr.val = t1.val + t2.val;

            // mergeleft
            curr.left = MergeHelper(t1.left, t2.left);

            // merge right
            curr.right = MergeHelper(t1.right, t2.right);

            return curr;
        }
    }
}
