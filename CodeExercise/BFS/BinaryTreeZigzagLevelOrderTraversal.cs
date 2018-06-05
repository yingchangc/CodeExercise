using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class BinaryTreeZigzagLevelOrderTraversal
    {
        /// <summary>
        /// 103. Binary Tree Zigzag Level Order Traversal
        /// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
        /// Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).

        /// For example:
        /// Given binary tree[3, 9, 20, null, null, 15, 7],
        ///     3
        ///    / \
        ///   9  20
        ///     /  \
        ///    15   7
        /// return its zigzag level order traversal as:
        /// [
        ///   [3],
        ///   [20,9],
        ///   [15,7]
        /// ]
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<List<int>>().ToArray();
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            List<List<int>> ans = new List<List<int>>();

            bool isToLeft = true;

            while(queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> levelNodes = new List<int>();

                for(int i = 0; i < levelSize; i++)
                {
                    var curr = queue.Dequeue();
                    levelNodes.Add(curr.val);

                    if (curr.left != null)
                    {
                        queue.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        queue.Enqueue(curr.right);
                    }
                }

                if (!isToLeft)
                {
                    levelNodes.Reverse();
                }
                isToLeft = !isToLeft;

                ans.Add(levelNodes);
            }

            return ans.ToArray();
        }
    }
}
