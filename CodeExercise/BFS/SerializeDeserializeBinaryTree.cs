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
    ///
    /// sol:
    /// 
    ///  serialize level order, always add node, dequeue append # or num
    /// </summary>
    class SerializeDeserializeBinaryTree
    {

        public string serialize(TreeNode root)
        {
            if (root == null)
            {
                return string.Empty;
            }
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            StringBuilder sb = new StringBuilder();

            while (que.Count > 0)
            {
                var node = que.Dequeue();

                if (node == null)
                {
                    sb.Append("#,");
                }
                else
                {
                    sb.Append(node.val);
                    sb.Append(",");
                    que.Enqueue(node.left);
                    que.Enqueue(node.right);
                }
            }

            sb.Remove(sb.Length - 1, 1);  // remove the last ,

            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {

            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            var tokens = data.Split(',');

            if (tokens.Length == 0)
            {
                return null;
            }

            Queue<TreeNode> que = new Queue<TreeNode>();
            TreeNode root = new TreeNode(int.Parse(tokens[0]));
            que.Enqueue(root);

            TreeNode curr = null;

            for (int i = 1; i < tokens.Length; i++)   // 1 # 2
            {
                if (curr == null)
                {
                    curr = que.Dequeue();

                    if (tokens[i] == "#")
                    {
                        curr.left = null;
                    }
                    else
                    {
                        curr.left = new TreeNode(int.Parse(tokens[i]));
                        que.Enqueue(curr.left);
                    }
                }
                else
                {
                    if (tokens[i] == "#")
                    {
                        curr.right = null;
                    }
                    else
                    {
                        curr.right = new TreeNode(int.Parse(tokens[i]));
                        que.Enqueue(curr.right);
                    }

                    // yic reset
                    curr = null;
                }

            }
            return root;
        }

        //// Encodes a tree to a single string.
        //public string serialize(TreeNode root)
        //{
        //    if (root == null)
        //    {
        //        return string.Empty;
        //    }

        //    StringBuilder sb = new StringBuilder();

        //    // BST
        //    Queue<TreeNode> queue = new Queue<TreeNode>();
        //    queue.Enqueue(root);

        //    while (queue.Count >0)
        //    {
        //        var node = queue.Dequeue();
        //        EncodeNode(node, sb);   // add (num|#)  + ","

        //        if (node != null)   // yic: easy to get wrong here
        //        {
        //            queue.Enqueue(node.left);    // add node or null
        //            queue.Enqueue(node.right);
        //        }
        //    }

        //    sb.Remove(sb.Length - 1, 1);  // remove the last ','

        //    return sb.ToString();
        //}

        //private void EncodeNode(TreeNode node, StringBuilder sb)
        //{
        //    if (node == null)
        //    {
        //        sb.Append("#");
        //    }
        //    else
        //    {
        //        sb.Append(node.val);
        //    }
        //    sb.Append(",");
        //}

        //// Decodes your encoded data to tree.
        //// 1,2,3,#,#,4,5,#,#,#,#
        //// use array to maintain the nodes
        //// use isLeft to link from parent (currIdx)

        ///// <summary>
        ///// sol:
        ///// use BFS queue to memorize node created, needed when curr left and right has filled
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public TreeNode deserializePractice(string data)
        //{
        //    if (string.IsNullOrEmpty(data) || string.Compare(data, "#") == 0)
        //    {
        //        return null;
        //    }

        //    // yic use queue to memo the next node to add child

        //    var tokens = new Queue<string>(data.Split(','));

        //    // handle root node (since no pre)
        //    TreeNode root = new TreeNode(Convert.ToInt32(tokens.Dequeue()));

        //    Queue<TreeNode> queue = new Queue<TreeNode>();
        //    queue.Enqueue(root);

        //    bool isleft = true;
        //    while(queue.Count > 0)
        //    {
        //        var curr = queue.Dequeue();

        //        // hanlde left , right child
        //        for (int i = 0; i < 2; i++)
        //        {
        //            string childV = tokens.Dequeue();
        //            TreeNode child = null;
        //            if (string.Compare(childV, "#") != 0)
        //            {
        //                child = new TreeNode(Convert.ToInt32(childV));
        //                queue.Enqueue(child);
        //            }

        //            if (isleft)
        //            {
        //                curr.left = child;
        //            }
        //            else
        //            {
        //                curr.right = child;
        //            }
        //            isleft = !isleft;
        //        }

        //    }
        //    return root;  
        //}


        //public TreeNode deserialize(string data)
        //{
        //    if (string.IsNullOrEmpty(data))
        //    {
        //        return null;
        //    }

        //    // yic use queue to memo the next node to add child
        //    Queue<TreeNode> queue = new Queue<TreeNode>();
        //    var tokens = data.Split(',');

        //    // handle root node (since no pre)
        //    TreeNode root = new TreeNode(Convert.ToInt32(tokens[0]));

        //    TreeNode parent = root;

        //    int len = tokens.Length;
        //    bool isLeft = true;      // trick
        //    for(int i = 1; i <len; i++)
        //    {
        //        TreeNode child = null;
        //        if (tokens[i] != "#")
        //        {
        //            child = new TreeNode(Convert.ToInt32(tokens[i]));
        //            queue.Enqueue(child);
        //        }

        //        if (isLeft)
        //        {
        //            parent.left = child;
        //        }
        //        if (!isLeft)
        //        {
        //            parent.right = child; 
        //        }

        //        if (!isLeft && queue.Count > 0)    // yic: prevent last node          1                  case
        //        {                                  //                           null    null    
        //            parent = queue.Dequeue();
        //        }

        //        isLeft = !isLeft;   // swap   
        //    }

        //    return root;
        //}
    }
}
