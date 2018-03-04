using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MaxBinaryTree
    {
        /// <summary>
        /// 654. Maximum Binary Tree
        /// https://leetcode.com/problems/maximum-binary-tree/description/
        /// Given an integer array with no duplicates. A maximum tree building on this array is defined as follow:

        /// The root is the maximum number in the array.
        /// The left subtree is the maximum tree constructed from left part subarray divided by the maximum number.
        /// The right subtree is the maximum tree constructed from right part subarray divided by the maximum number.
        /// Construct the maximum tree by the given array and output the root node of this tree.
        /// 
        /// Input: [3,2,1,6,0,5]
        /// Output: return the tree root node representing the following tree:
        /// 
        ///       6
        ///     /   \
        ///    3     5
        ///     \    / 
        ///      2  0   
        ///        \
        ///         1
        ///         
        /// (1)monotonic stack, alwasy put smaller in , and attach to prev node's right.
        ///   [7,2,1]     ------0
        /// (2)if to put (curr) is bigger, pop stack until find stack.peek is greater than curr
        ///    [7,2,1,0]   -------6
        /// since curr is new,  curr->left  ------- last pop (smaller),
        ///  
        ///  stck.peek() -> right       --------- curr
        ///     
        ///      6-> left = 2
        ///    
        ///    put 6 back
        ///   
        ///     [7, 6] 
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            Stack<TreeNode> monotonicStk = new Stack<TreeNode>();
            int N = nums.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                TreeNode curr = new TreeNode(nums[i]);


                if (monotonicStk.Count == 0)
                {
                    monotonicStk.Push(curr);
                }
                else if (curr.val <= monotonicStk.Peek().val)
                {// (1) smaller equal, add to right and push to stack
                    monotonicStk.Peek().right = curr;
                    monotonicStk.Push(curr);
                }
                else
                {// (2) is bigger
                    while (monotonicStk.Count > 0 && monotonicStk.Peek().val < curr.val)
                    {
                        // just pop  since we have connect use right node.
                        var smallerNode = monotonicStk.Pop();

                        // curr is new, no left, keep try until find the biggest smaller (left side in the stack)
                        curr.left = smallerNode;
                    }

                    // now , put curr to stk, since it can be someone's smaller right
                    if (monotonicStk.Count > 0)
                    {
                        monotonicStk.Peek().right = curr;
                    }

                    monotonicStk.Push(curr);
                }
            }

            // the 1st is the root
            TreeNode ans = null;
            while (monotonicStk.Count > 0)
            {
                ans = monotonicStk.Pop();
            }

            return ans;
        }


        //Sol: recursive, find segment max as root, and break into left and right
        public TreeNode ConstructMaximumBinaryTree_slow(int[] nums)
        {
            // O(n^2)
            return MaxTreeHelper(nums, 0, nums.GetLength(0) - 1);
        }

        private TreeNode MaxTreeHelper(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            int maxIdx = left;
            int maxV = nums[left];
            for (int i = left; i <= right; i++)
            {
                if (maxV < nums[i])
                {
                    maxV = nums[i];
                    maxIdx = i;
                }
            }

            TreeNode curr = new TreeNode(maxV);
            curr.left = MaxTreeHelper(nums, left, maxIdx - 1);
            curr.right = MaxTreeHelper(nums, maxIdx+1, right);

            return curr;
        }

    }
}
