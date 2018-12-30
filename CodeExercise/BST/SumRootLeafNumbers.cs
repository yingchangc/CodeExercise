using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class SumRootLeafNumbers
    {
        private int globalSum;

        /// <summary>
        /// 129. Sum Root to Leaf Numbers
        /// https://leetcode.com/problems/sum-root-to-leaf-numbers/
        /// Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.
        /// 
        /// An example is the root-to-leaf path 1->2->3 which represents the number 123.
        /// 
        /// Find the total sum of all root-to-leaf numbers.
        /// 
        /// Note: A leaf is a node with no children.
        /// 
        /// Example:
        /// 
        /// Input: [1,2,3]
        ///     1
        ///    / \
        ///   2   3
        /// Output: 25
        /// Explanation:
        /// The root-to-leaf path 1->2 represents the number 12.
        /// The root-to-leaf path 1->3 represents the number 13.
        /// Therefore, sum = 12 + 13 = 25.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumNumbers(TreeNode root)
        {
            globalSum = 0;

            DFSHelper(root, 0);

            return globalSum;
        }

        private void DFSHelper(TreeNode node, int num)
        {
            if (node == null)
            {
                return;
            }

            num = num * 10 + node.val;

            if (node.left != null)
            {
                DFSHelper(node.left, num);
            }

            if (node.right != null)
            {
                DFSHelper(node.right, num);
            }

            if (node.left == null && node.right == null)
            {
                globalSum += num;
            }
        }
    }
}
