using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class ConstructBinaryTree
    {
        /// <summary>
        /// 1137. Construct String from Binary Tree
        /// You need to construct a string consists of parenthesis and integers from a binary tree with the preorder traversing way.
        /// 
        /// The null node needs to be represented by empty parenthesis pair "()". And you need to omit all the empty parenthesis pairs that don't affect the one-to-one mapping relationship between the string and the original binary tree.
        /// 
        /// Example 1:
        /// 
        /// Input: Binary tree: [1,2,3,4]
        ///        1
        ///      /   \
        ///     2     3
        ///    /    
        ///   4     
        /// 
        /// Output: "1(2(4))(3)"
        /// 
        /// Explanation: Originallay it needs to be "1(2(4)())(3()())", 
        /// but you need to omit all the unnecessary empty parenthesis pairs.
        /// And it will be "1(2(4))(3)".
        /// Example 2:
        /// 
        /// Input: Binary tree: [1,2,3,null,4]
        ///        1
        ///      /   \
        ///     2     3
        ///      \  
        ///       4 
        /// 
        /// Output: "1(2()(4))(3)"
        /// 
        /// Explanation: Almost the same as the first example, 
        /// except we can't omit the first parenthesis pair to break the one-to-one mapping relationship between the input and the output.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public string Tree2Str(TreeNode t)
        {
            return Tree2StrHelper(t);
        }

        private string Tree2StrHelper(TreeNode t)
        {
            if (t == null)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            var left = Tree2StrHelper(t.left);
            var right = Tree2StrHelper(t.right);

            if (string.IsNullOrEmpty(left) && string.IsNullOrEmpty(right))
            {
                sb.Append(t.val);
            }
            else if (string.IsNullOrEmpty(left))
            {
                sb.Append(t.val).Append("()").Append("(" + right + ")");
                
            }
            else if (string.IsNullOrEmpty(right))
            {
                sb.Append(t.val).Append("(" + left + ")");
            }
            else
            {
                sb.Append(t.val).Append("(" + left + ")").Append("(" + right + ")");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// https://www.geeksforgeeks.org/construct-tree-inorder-level-order-traversals/
        /// Construct a tree from Inorder and Level order traversals
        /// 
        /// Input: Two arrays that represent Inorder
        ///and level order traversals of a
        ///Binary Tree
        ///in[]    = {4, 8, 10, 12, 14, 20, 22};
        ///level[] = {20, 8, 22, 4, 12, 10, 14};
        ///
        ///                  20
        ///             8         22
        ///         4     12
        ///             10  14
        /// 
        ///Output: Construct the tree represented
        ///        by the two arrays.
        ///        For the above two arrays, the
        ///        constructed tree is shown in 
        ///        the diagram on right side
        ///        
        /// sol
        /// Let us consider the above example.
        /// 
        /// in[] = {4, 8, 10, 12, 14, 20, 22};
        /// level[] = {20, 8, 22, 4, 12, 10, 14};
        /// 
        /// In a Levelorder sequence, the first element is the root of the tree.So we know ’20’ is root for given sequences.By searching ’20’ in Inorder sequence, we can find out all elements on left side of ‘20’ are in left subtree and elements on right are in right subtree. So we know below structure now.
        /// 
        ///              20
        ///            /    \
        ///           /      \ 
        ///  { 4,8,10,12,14}  {22}   
        /// Let us call {4,8,10,12,14} as left subarray in Inorder traversal and {22} as right subarray in Inorder traversal.
        /// In level order traversal, keys of left and right subtrees are not consecutive.So we extract all nodes from level order traversal which are in left subarray of Inorder traversal.To construct the left subtree of root, we recur for the extracted elements from level order traversal and left subarray of inorder traversal.In the above example, we recur for following two arrays.
        /// 
        /// // Recur for following arrays to construct the left subtree
        /// In[]    = { 4, 8, 10, 12, 14}
        ///         level[] = {8, 4, 12, 10, 14} 
        /// Similarly, we recur for following two arrays and construct the right subtree.
        /// 
        /// // Recur for following arrays to construct the right subtree
        /// In[]    = { 22}
        ///         level[] = {22} 
        /// 
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="levelorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree_InorderLevelorder(int[] inorder, int[] levelorder)
        {
            if (inorder == null || levelorder == null || inorder.Length != levelorder.Length || inorder.Length == 0)
            {
                return null;
            }

            return HelperInorderLevelorder(inorder, 0, inorder.Length - 1, levelorder);
        }

        private int[] extractLevelorder(int[] inorder, int inS, int inE, int[] levelorder)
        {
            // inorder left part are all left branch
            var level = new List<int>();
            var hashSet = new HashSet<int>();

            for (int i = inS; i <= inE; i++)
            {
                hashSet.Add(inorder[i]);
            }

            for (int i = 0; i < levelorder.Length; i++)
            {
                if (hashSet.Contains(levelorder[i]))
                {
                    level.Add(levelorder[i]);
                }
            }

            return level.ToArray();
        }

        private TreeNode HelperInorderLevelorder(int[] inorder, int inS, int inE, int[] levelorder)
        {
            if (inS > inE || levelorder.Length == 0)
            {
                return null;
            }

            int rootV = levelorder[0];
            var root = new TreeNode(rootV);
            int idx = FindRootIdxForInorder(inorder, inS, inE, rootV);

            // inorder left part are all left branch
            int[] levelLeft = extractLevelorder(inorder, inS, idx - 1, levelorder);

            // inorder right part are all right branch
            int[] levelRight = extractLevelorder(inorder, idx+1, inE, levelorder);
            

            root.left = HelperInorderLevelorder(inorder, inS, idx - 1, levelLeft);
            root.right = HelperInorderLevelorder(inorder, idx+1, inE, levelRight);

            return root;
        }

        private int FindRootIdxForInorder(int[] inorder, int inS, int inE, int rootV)
        {
            for (int i= inS; i<=inE; i++)
            {
                if (inorder[i] == rootV)
                {
                    return i;
                }
            }

            Console.WriteLine("error");
            return -1;
        }

        /// <summary>
        /// 105. Construct Binary Tree from Preorder and Inorder Traversal
        /// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
        /// Given preorder and inorder traversal of a tree, construct the binary tree.
        /// 
        /// Note:
        /// You may assume that duplicates do not exist in the tree.
        /// 
        /// For example, given
        /// 
        /// preorder = [3, 9, 20, 15, 7]
        /// inorder = [9, 3, 15, 20, 7]
        /// Return the following binary tree:
        /// 
        ///     3
        ///    / \
        ///   9  20
        ///     /  \
        ///    15   7
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree_InorderPreorder(int[] preorder, int[] inorder)
        {
            return HelperPI(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
        }

        private TreeNode HelperPI(int[] preorder, int[] inorder, int preS, int preE, int inS, int inE)
        {
            if (preS > preE || inS > inE)
            {
                return null;
            }

            int rootV = preorder[preS];
            var root = new TreeNode(rootV);

            int idx = FindInorderRootIdxForPI(inorder, inS, inE, rootV);

            int leftBranchSize = idx - inS;
            int rightBranchSize = inE - idx;

            root.left = HelperPI(preorder, inorder, preS + 1, preS + 1 + leftBranchSize - 1, inS, inS + leftBranchSize - 1);
            root.right = HelperPI(preorder, inorder, preE - rightBranchSize + 1, preE, idx + 1, inE);

            return root;

        }

        private int FindInorderRootIdxForPI(int[] inorder, int inS, int inE, int rootV)
        {
            for (int i = inS; i <= inE; i++)
            {
                if (rootV == inorder[i])
                {
                    return i;
                }
            }

            Console.WriteLine("error");
            return -1;
        }


        /// <summary>
        /// 106. Construct Binary Tree from Inorder and Postorder Traversal
        /// https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
        /// Given inorder and postorder traversal of a tree, construct the binary tree.
        /// 
        /// Note:
        /// You may assume that duplicates do not exist in the tree.
        /// 
        /// For example, given
        /// 
        /// inorder = [9, 3, 15, 20, 7]
        /// postorder = [9, 15, 7, 20, 3]
        /// Return the following binary tree:
        /// 
        ///     3
        ///    / \
        ///   9  20
        ///     /  \
        ///    15   7
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree_InorderPostorder(int[] inorder, int[] postorder)
        {
            if (inorder == null || postorder == null ||
                inorder.Length == 0 || inorder.Length != postorder.Length)
            {
                return null;
            }

            return Helper(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);
        }

        private TreeNode Helper(int[] inorder, int[] postorder, int inS, int inE, int postS, int postE)
        {
            if (inS > inE || postS > postE)
            {
                return null;
            }

            int rootV = postorder[postE];
            var root = new TreeNode(rootV);
            int idx = FindRootIdxInorder(inorder, inS, inE, rootV);

            int leftBranchSize = (idx - inS);
            int rightBranchSize = (inE - idx);
            root.left = Helper(inorder, postorder, inS, inS + leftBranchSize - 1,
                                                 postS, postS + leftBranchSize - 1);

            root.right = Helper(inorder, postorder, idx + 1, idx + 1 + rightBranchSize - 1,
                                                 postE - rightBranchSize, postE - 1);

            return root;
        }

        private int FindRootIdxInorder(int[] inorder, int inS, int inE, int rootV)
        {
            for (int i = inS; i <= inE; i++)
            {
                if (inorder[i] == rootV)
                {
                    return i;
                }
            }


            Console.WriteLine("error");

            return -1;
        }
    }
}
