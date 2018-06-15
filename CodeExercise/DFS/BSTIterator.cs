using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    //
    // 
    // (2) pop  and 
    /// 
    class BSTIterator
    {
        private Stack<TreeNode> stk;

        /// <summary>
        /// Example
        /// For the following binary search tree, in-order traversal by using iterator is [1, 6, 10, 11, 12]
        /// 
        ///    10
        ///  /    \
        /// 1      11
        ///  \       \
        ///   6       12
        ///   
        /// sol
        /// (1) insert root left path to stk.   10, 1
        /// (2) pop 1 and find 1 has right branch starting from 6, insert all 6's left path to stk, because the leaf is 1's next bigger {10,6}
        /// (3) pop stk 6,  since 6 has no right , keep pop next element ie 10, and find 10 has righ branch starting from 11, insert all 11's left "path" to stk   {11},
        /// (4) pop stk 11, and find 11's right branch, insert all 12's left paths to stk, {12}
        /// </summary>
        /// <param name="root"></param>
        public BSTIterator(TreeNode root)
        {
            stk = new Stack<TreeNode>();
            InsertAllLeft(root);
        }

        private void InsertAllLeft(TreeNode node)
        {
            TreeNode curr = node;

            while(curr != null)
            {
                stk.Push(curr);
                curr = curr.left;
            }
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return stk.Count > 0;
        }

        /** @return the next smallest number */
        public int Next()
        {
            TreeNode temp = stk.Pop();

            if (temp.right != null)
            {
                InsertAllLeft(temp.right);
            }

            return temp.val;
        }
    }
}
