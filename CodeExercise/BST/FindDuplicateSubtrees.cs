using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class FindDuplicateSubtrees
    {
        /// <summary>
        /// 652. Find Duplicate Subtrees
        /// https://leetcode.com/problems/find-duplicate-subtrees/
        /// Given a binary tree, return all duplicate subtrees. For each kind of duplicate subtrees, you only need to return the root node of any one of them.
        /// 
        /// Two trees are duplicate if they have the same structure with same node values.
        /// 
        /// Example 1:
        /// 
        ///         1
        ///        / \
        ///       2   3
        ///      /   / \
        ///     4   2   4
        ///        /
        ///       4
        /// The following are two duplicate subtrees:
        /// 
        ///       2
        ///      /
        ///     4
        /// and
        /// 
        ///     4
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<TreeNode> FindDuplicateSubtreesSolver(TreeNode root)
        {
            Dictionary<string, int> lookup = new Dictionary<string, int>(); // tree structure, freq
            List<TreeNode> ans = new List<TreeNode>();

            Traverse(root, lookup, ans);

            return ans;

        }

        private string Traverse(TreeNode node, Dictionary<string, int> lookup, List<TreeNode> ans)
        {
            if (node == null)
            {
                return "#";
            }

            var left = Traverse(node.left, lookup, ans);
            var right = Traverse(node.right, lookup, ans);

            // yic must be in the post order
            string levelStr = left + ","  + right + "," + node.val;  

            // consider  
            /*
             * 
             *              X                   X                
             *            X  #                #   X
             *           # #                     #  #
             *     
             *      serialize
             *          #X#X#       ==  ??       #X#X# 
             */


            if (!lookup.ContainsKey(levelStr))
            {
                lookup.Add(levelStr, 0);
            }
            else if (lookup.ContainsKey(levelStr) && lookup[levelStr] == 1)
            {
                ans.Add(node);
            }

            lookup[levelStr]++;

            return levelStr;
        }
    }
}
