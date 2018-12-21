using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class BinaryTreeVerticalOrderTraversal
    {
        /// <summary>
        /// 314. Binary Tree Vertical Order Traversal
        /// https://leetcode.com/problems/binary-tree-vertical-order-traversal/
        /// Given a binary tree, return the vertical order traversal of its nodes' values. (ie, from top to bottom, column by column).
        /// 
        /// If two nodes are in the same row and column, the order should be from left to right.
        /// 
        /// Examples 1:
        /// 
        /// Input: [3,9,20,null,null,15,7]
        /// 
        ///    3
        ///   /\
        ///  /  \
        ///  9  20
        ///     /\
        ///    /  \
        ///   15   7 
        /// 
        /// 
        ///         Output:
        /// 
        /// 
        ///         [
        ///           [9],
        ///           [3,15],
        ///           [20],
        ///           [7]
        /// ]
        /// Examples 2:
        /// 
        /// Input: [3,9,8,4,0,1,7]
        /// 
        ///      3
        ///     /\
        ///    /  \
        ///    9   8
        ///   /\  /\
        ///  /  \/  \
        ///  4  01   7 
        /// 
        /// Output:
        /// 
        /// [
        ///   [4],
        ///   [9],
        ///   [3,0,1],
        ///   [8],
        ///   [7]
        /// ]
        /// 
        /// 
        /// sol: 
        /// 
        /// cannot use preorder  becase  the order of below will get wrong 
        ////// Input: [3,9,8,4,0,1,7,null,null,null,2,5] (0's right child is 2 and 1's left child is 5)
        ///
        ///     3
        ///    /\
        ///   /  \
        ///   9   8
        ///  /\  /\
        /// /  \/  \
        /// 4  01   7
        ///    /\
        ///   /  \
        ///   5   2
        ///
        ///Output:
        ///
        ///[
        ///  [4],
        ///  [9,5],
        ///  [3,0,1],
        ///  [8,2],
        ///  [7]
        ///]
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            var ans = new List<List<int>>();
            if (root == null)
            {
                return ans.ToArray();
            }
            Queue<TreeNode> que = new Queue<TreeNode>();
            Dictionary<TreeNode, int> lookup = new Dictionary<TreeNode, int>();

            SortedDictionary<int, List<int>> ansDict = new SortedDictionary<int, List<int>>();

            que.Enqueue(root);
            lookup.Add(root, 0);

            while (que.Count > 0)
            {
                int lvCount = que.Count;
                for (int i = 0; i < lvCount; i++)
                {
                    var curr = que.Dequeue();
                    int idx = lookup[curr];

                    if (!ansDict.ContainsKey(idx))
                    {
                        ansDict.Add(idx, new List<int>());
                    }
                    ansDict[idx].Add(curr.val);


                    if (curr.left != null)
                    {
                        que.Enqueue(curr.left);
                        lookup.Add(curr.left, idx - 1);
                    }
                    if (curr.right != null)
                    {
                        que.Enqueue(curr.right);
                        lookup.Add(curr.right, idx + 1);
                    }

                }
            }



            foreach (var lst in ansDict.Values)
            {
                ans.Add(lst);
            }

            return ans.ToArray();
        }
        }
}
