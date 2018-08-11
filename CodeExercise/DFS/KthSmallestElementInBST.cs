using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class KthSmallestElementInBST
    {
        /// <summary>
        /// 230. Kth Smallest Element in a BST
        /// https://leetcode.com/problems/kth-smallest-element-in-a-bst/description/
        /// Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.
        /// Note: 
        /// You may assume k is always valid, 1 ≤ k ≤ BST's total elements.
        /// 
        /// Example 1:
        /// 
        /// Input: root = [3,1,4,null,2], k = 1
        ///    3
        ///   / \
        ///  1   4
        ///   \
        ///    2
        /// Output: 1
        /// Example 2:
        /// 
        /// Input: root = [5,3,6,2,4,null,null,1], k = 3
        ///        5
        ///       / \
        ///      3   6
        ///     / \
        ///    2   4
        ///   /
        ///  1
        /// Output: 3
        /// Follow up:
        /// What if the BST is modified(insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest_inorder(TreeNode root, int k)
        {
            ResultType res = new ResultType();
            inorder(0, root, k, res);

            return res.kth;
        }

        class ResultType
        {
            public bool found = false;
            public int kth = -1;

        }

        private int inorder(int precount, TreeNode node, int k, ResultType res)
        {
            if (res.found)
            {
                return precount;
            }

            if (node == null)
            {
                return precount;
            }

            int leftCount = inorder(precount, node.left, k, res);

            if (res.found)
            {
                return leftCount;
            }

            if ((leftCount+1) == k)
            {
                res.found = true;
                res.kth = node.val;
                return leftCount + 1;
            }

            int rightCount = inorder(leftCount + 1, node.right, k, res);

            return rightCount;

        }


        /// <summary>
        /// 使用 Binary Search Tree Iterator 的方式（可以参考 binary search tree iterator 那个题）
        ///用 stack，从第一个点开始，走 k-1 步，就是第 k 个点了。
        /// 时间复杂度是 O(h + k)O(h+k) h 是树的高度。
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(TreeNode root, int k)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();

            InsertAllLeft(root, stk);

            int count = 0;
            int ans = -1;
            while (stk.Count > 0)
            {
                TreeNode node = stk.Pop();
                count++;
                Console.WriteLine(node.val);

                if (count ==k)
                {
                    ans = node.val;
                    break;
                }

                if (node.right !=null)
                {
                    InsertAllLeft(node.right, stk);
                }
            }

            return ans;
            
        }

        private void InsertAllLeft(TreeNode root, Stack<TreeNode> stk)
        {
            TreeNode node = root;
            while(node != null)
            {
                stk.Push(node);
                node = node.left;
            }
        }
    }
}
