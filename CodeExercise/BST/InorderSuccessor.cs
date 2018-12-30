using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class InorderSuccessor
    {
        /// <summary>
        /// 285. Inorder Successor in BST
        /// https://leetcode.com/problems/inorder-successor-in-bst/
        /// Given a binary search tree and a node in it, find the in-order successor of that node in the BST.
        /// 
        /// Note: If the given node has no in-order successor in the tree, return null.
        /// 
        /// Example 1:
        /// 
        /// Input: root = [2,1,3], p = 1
        /// 
        ///   2
        ///  / \
        /// 1   3
        /// 
        /// Output: 2
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public TreeNode InorderSuccessorSolver(TreeNode root, TreeNode p)
        {
            TreeNode ans = null;

            TreeNode curr = root;

            while (curr != null)
            {
                if (curr.val > p.val)
                {
                    // YIC can be candidate
                    ans = curr;
                    curr = curr.left;
                }
                else
                {
                    // curr <= p  
                    curr = curr.right;
                }
            }

            return ans;
        }
        public TreeNode InorderSuccessorSolver_slow(TreeNode root, TreeNode p)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();
            InsertAllLeftToStk(stk, root);

            while (stk.Count > 0)
            {
                var temp = stk.Pop();

                InsertAllLeftToStk(stk, temp.right);

                if (temp == p)
                {
                    if (stk.Count > 0)
                    {
                        return stk.Pop();
                    }
                    return null;
                }

            }

            return null;
        }

        private void InsertAllLeftToStk(Stack<TreeNode> stk, TreeNode n)
        {
            while (n != null)
            {
                stk.Push(n);
                n = n.left;
            }
        }
    }
}
