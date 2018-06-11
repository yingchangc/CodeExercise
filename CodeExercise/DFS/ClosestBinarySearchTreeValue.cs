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
        /// 272. Closest Binary Search Tree Value II
        /// https://leetcode.com/problems/closest-binary-search-tree-value-ii/description/
        /// Given a non-empty binary search tree and a target value, find k values in the BST that are closest to the target.
        /// Note:
        /// 
        /// Given target value is a floating point.
        /// You may assume k is always valid, that is: k ≤ total nodes.
        /// You are guaranteed to have only one unique set of k values in the BST that are closest to the target.
        /// Example:
        /// 
        /// Input: root = [4, 2, 5, 1, 3], target = 3.714286, and k = 2
        /// 
        ///     4
        ///    / \
        ///   2   5
        ///  / \
        /// 1   3
        /// 
        /// Output: [4,3]
        /// Follow up:
        /// Assume that the BST is balanced, could you solve it in less than O(n) runtime(where n = total nodes)?
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> ClosestKValues(TreeNode root, double target, int k)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();

            // iteration
            //List<int> inorder = InOrderTraverse1(root, stk);
            // recursive
            List<int> inorder = InOrderTraverse2(root);

            int i = 0;
            for (i=0; i < inorder.Count; i++)
            {
                if (inorder[i] >= target)
                {
                    break;
                }
            }

            int left = i - 1;
            int right = i;
            List<int> ans = new List<int>();
            int count = 0;
            while( left >=0 && right <inorder.Count && count < k)
            {
                if (Math.Abs(inorder[left] - target) <= Math.Abs(inorder[right] - target))
                {
                    ans.Add(inorder[left--]);
                }
                else
                {
                    ans.Add(inorder[right++]);
                }
                count++;
            }

            if (count < k)
            {
                while(count < k && left >= 0)
                {
                    ans.Add(inorder[left--]);
                    count++;
                }
                while(count < k && right < inorder.Count)
                {
                    ans.Add(inorder[right++]);
                    count++;
                }
            }

            return ans;
        }

        // recursive
        private List<int> InOrderTraverse2(TreeNode root)
        {
            List<int> inorder = new List<int>();
            inordertraverseHelper(root, inorder);

            return inorder;

        }

        private void inordertraverseHelper(TreeNode root, List<int> inorder)
        {
            if (root == null)
            {
                return;
            }

            inordertraverseHelper(root.left, inorder);
            inorder.Add(root.val);
            inordertraverseHelper(root.right, inorder);
        }

        private List<int> InOrderTraverse1(TreeNode root, Stack<TreeNode> stk)
        {
            List<int> orderList = new List<int>();
            InsertAllLeftToStk(root, stk);

            while (stk.Count > 0)
            {
                TreeNode curr = stk.Pop();
                orderList.Add(curr.val);

                if (curr.right != null)
                {
                    InsertAllLeftToStk(curr.right, stk);
                }

            }

            return orderList;
        }

        private void InsertAllLeftToStk(TreeNode root, Stack<TreeNode> stk)
        {
            TreeNode curr = root;

            while(curr!=null)
            {
                stk.Push(curr);
                curr = curr.left;
            }
        }

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
