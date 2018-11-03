using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class BinaryTreeRightSideView
    {
        /// <summary>
        /// 199. Binary Tree Right Side View
        /// https://leetcode.com/problems/binary-tree-right-side-view/description/
        /// Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
        /// 
        /// Example:
        /// 
        /// Input: [1,2,3,null,5,null,4]
        ///         Output: [1, 3, 4]
        ///         Explanation:
        /// 
        //    1            <---
        //  /   \
        // 2     3         <---
        //  \     \
        //   5     4       <---
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);

            while(que.Count > 0)
            {
                int levelSize = que.Count;

                TreeNode node = null;
                for (int i = 0; i < levelSize; i ++)
                {
                    node = que.Dequeue();

                    if (node.left != null)
                    {
                        que.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        que.Enqueue(node.right);
                    }
                }

                // take the last one
                result.Add(node.val);
            }

            return result;
        }
    }
}
