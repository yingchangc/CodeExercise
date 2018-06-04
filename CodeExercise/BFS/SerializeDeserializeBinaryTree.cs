using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    /// <summary>
    /// 297. Serialize and Deserialize Binary Tree
    /// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/
    /// 
    /// Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
    ///    Design an algorithm to serialize and deserialize a binary tree.There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized 
    ///    to the original tree structure.
    ///
    ///    Example: 
    ///
    ///
    ///    You may serialize the following tree:
    ///
    ///    1
    ///   / \
    ///  2   3
    ///     / \
    ///    4   5
    ///
    ///as "[1,2,3,null,null,4,5]"
    /// </summary>
    class SerializeDeserializeBinaryTree
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            // BST
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count >0)
            {
                var node = queue.Dequeue();

                if (node != null)
                {
                    sb.Append(node.val);
                }
                else
                {
                    sb.Append("#");
                }

                sb.Append(",");

                if (node != null)   // yic: easy to get wrong here
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }

            sb.Remove(sb.Length - 1, 1);  // remove the last ','

            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        // 1,2,3,#,#,4,5,#,#,#,#
        // use array to maintain the nodes
        // use isLeft to link from parent (currIdx)
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            // yic trick:  Use list to collect node
            List<TreeNode> arr = new List<TreeNode>();
            var tokens = data.Split(',');

            // handle root node (since no pre)
            TreeNode root = new TreeNode(Convert.ToInt32(tokens[0]));
            arr.Add(root);

            int len = tokens.Length;
            int currIdx = 0;        // trick
            bool isLeft = true;      // trick
            for(int i = 1; i <len; i++)
            {
                if (tokens[i] != "#")
                {
                    TreeNode node = new TreeNode(Convert.ToInt32(tokens[i]));
                    arr.Add(node);

                    // assign curr node to parent
                    var parent = arr[currIdx];

                    if (isLeft)
                    {
                        parent.left = node;
                    }
                    else
                    {
                        parent.right = node;
                    }
                }

                if (!isLeft)
                {
                    currIdx++;
                }

                isLeft = !isLeft;   // swap   
            }

            return root;
        }
    }
}
