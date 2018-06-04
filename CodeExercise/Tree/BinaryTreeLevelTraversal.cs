using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Tree
{
    class BinaryTreeLevelTraversal
    {
        /// <summary>
        /// 102. Binary Tree Level Order Traversal
        /// https://leetcode.com/problems/binary-tree-level-order-traversal/description/
        /// Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).
        /// For example:
        /// Given binary tree[3, 9, 20, null, null, 15, 7],
        ///     3
        ///    / \
        ///   9  20
        ///     /  \
        ///    15   7
        /// return its level order traversal as:
        /// [
        ///   [3],
        ///   [9,20],
        ///   [15,7]
        /// ]
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<List<int>> ans = new List<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (root == null)
            {
                return ans.ToArray();
            }

            queue.Enqueue(root);

            while(queue.Count >0)
            {
                // each time current queue contains all node of this level
                int size = queue.Count;

                List<int> levelAns = new List<int>();

                for(int i = 0; i <size; i++)
                {
                    var top = queue.Dequeue();

                    levelAns.Add(top.val);

                    if (top.left != null)
                    {
                        queue.Enqueue(top.left);
                    }

                    if (top.right != null)
                    {
                        queue.Enqueue(top.right);
                    }
                }

                ans.Add(levelAns); 
            }

            return ans.ToArray();
        }
    }
}
