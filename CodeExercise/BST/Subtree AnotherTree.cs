using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class Subtree_AnotherTree
    {
        /// <summary>
        /// 572. Subtree of Another Tree
        /// https://leetcode.com/problems/subtree-of-another-tree/
        /// Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s. A subtree of s is a tree consists of a node in s and all of this node's descendants. The tree s could also be considered as a subtree of itself.
        /// 
        /// Example 1:
        /// Given tree s:
        /// 
        ///      3
        ///     / \
        ///    4   5
        ///   / \
        ///  1   2
        /// Given tree t:
        ///    4 
        ///   / \
        ///  1   2
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            return IsSubtreeHelper(s, t);
        }

        private bool IsSubtreeHelper(TreeNode s, TreeNode t)
        {
            if (s == null)
            {
                return false;
            }

            if (IsSame(s, t))
            {
                return true;
            }
            else if (IsSubtreeHelper(s.left, t))
            {
                return true;
            }

            return IsSubtreeHelper(s.right, t);
        }

        private bool IsSame(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
            {
                return true;
            }
            if (s == null || t == null)
            {
                return false;
            }

            return (s.val == t.val) && IsSame(s.left, t.left) && IsSame(s.right, t.right);
        }



        public bool IsSubtree_Serlaizlie(TreeNode s, TreeNode t)
        {
            string sSerial = Preorder(s);
            string tSerial = Preorder(t);

            Console.WriteLine("{0}  vs  {1}", sSerial, tSerial);
            return (sSerial.IndexOf(tSerial) != -1);
        }

        private string Preorder(TreeNode s)
        {

            if (s == null)
            {
                return "#,";
            }

            string left = Preorder(s.left);
            string right = Preorder(s.right);

            // yic  must add , in the begining for case like  ,12,#,#   vs ,2,#,#     without it 12,#,#   vs 2,#,# will be a match
            return "," + s.val + "," + left + right;


        }
    }
}
