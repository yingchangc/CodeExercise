using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class AllNodesDistanceKBinaryTree
    {
        /// <summary>
        /// 863. All Nodes Distance K in Binary Tree
        /// https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/
        /// We are given a binary tree (with root node root), a target node, and an integer value K.
        /// 
        /// Return a list of the values of all nodes that have a distance K from the target node.The answer can be returned in any order.
        /// 
        /// Example 1:
        /// 
        /// 
        /// Input: root = [3, 5, 1, 6, 2, 0, 8, null, null, 7, 4], target = 5, K = 2
        /// 
        /// 
        /// Output: [7,4,1]
        /// 
        /// Explanation: 
        /// The nodes that are a distance 2 from the target node (with value 5)
        /// have values 7, 4, and 1.
        /// 
        /// sol:
        /// 
        /// construct parent map  by DFS.  then use BFS  left, right , parent to find level as distance.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {

            List<int> ans = new List<int>();

            if (root == null)
            {
                return ans;
            }

            // acquire parent lookup
            Dictionary<TreeNode, TreeNode> parent = new Dictionary<TreeNode, TreeNode>();
            DFS(root, parent);

            return BFSFindKDist(target, K, parent);

        }

        private List<int> BFSFindKDist(TreeNode root, int k, Dictionary<TreeNode, TreeNode> parent)
        {
            Queue<TreeNode> que = new Queue<TreeNode>();
            HashSet<TreeNode> visited = new HashSet<TreeNode>();
            que.Enqueue(root);
            visited.Add(root);

            List<int> ans = new List<int>();

            int level = 0;
            while (que.Count > 0 && level <= k)
            {
                int levelCount = que.Count;

                for (int i = 0; i < levelCount; i++)
                {
                    var node = que.Dequeue();

                    if (level == k)
                    {
                        ans.Add(node.val);
                    }

                    // try enqueue left, right, parent
                    if (node.left != null && !visited.Contains(node.left))
                    {
                        que.Enqueue(node.left);
                        visited.Add(node.left);
                    }
                    if (node.right != null && !visited.Contains(node.right))
                    {
                        que.Enqueue(node.right);
                        visited.Add(node.right);
                    }

                    // root don't have parent
                    if (parent.ContainsKey(node))
                    {
                        var parentNode = parent[node];
                        if (!visited.Contains(parentNode))
                        {
                            que.Enqueue(parentNode);
                            visited.Add(parentNode);
                        }
                    }
                }

                level++;
            }

            return ans;

        }

        private void DFS(TreeNode node, Dictionary<TreeNode, TreeNode> parent)
        {
            if (node == null)
            {
                return;
            }

            if (node.left != null)
            {
                parent.Add(node.left, node);
                DFS(node.left, parent);
            }

            if (node.right != null)
            {
                parent.Add(node.right, node);
                DFS(node.right, parent);
            }
        }
    }
}
