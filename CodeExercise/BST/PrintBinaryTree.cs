using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class PrintBinaryTree
    {
        /// <summary>
        /// 655. Print Binary Tree
        /// https://leetcode.com/problems/print-binary-tree/
        /// Print a binary tree in an m*n 2D string array following these rules:
        /// 
        /// The row number m should be equal to the height of the given binary tree.
        /// The column number n should always be an odd number.
        /// The root node's value (in string format) should be put in the exactly middle of the first row it can be put. The column and the row where the root node belongs will separate the rest space into two parts (left-bottom part and right-bottom part). You should print the left subtree in the left-bottom part and print the right subtree in the right-bottom part. The left-bottom part and the right-bottom part should have the same size. Even if one subtree is none while the other is not, you don't need to print anything for the none subtree but still need to leave the space as large as that for the other subtree.However, if two subtrees are none, then you don't need to leave space for both of them.
        /// Each unused space should contain an empty string "".
        /// Print the subtrees following the same rules.
        ///         Example 1:
        /// Input:
        ///      1
        ///     /
        ///    2
        /// Output:
        /// [["", "1", ""],
        ///  ["2", "", ""]]
        /// Example 2:
        /// Input:
        ///      1
        ///     / \
        ///    2   3
        ///     \
        ///      4
        /// Output:
        /// [["", "", "", "1", "", "", ""],
        ///  ["", "2", "", "", "", "3", ""],
        ///  ["", "", "4", "", "", "", ""]]
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            int depth = GetDepth(root);
            int columnSize = GetColumnSize(depth);

            var ans = InitAns(depth, columnSize);

            LevelTraverse(root, 0, 0, columnSize - 1, ans);

            return ans;

        }

        private string[][] InitAns(int r, int c)
        {
            string[][] ans = new string[r][];
            for (int i = 0; i < r; i++)
            {
                ans[i] = new string[c];
            }

            for (int j = 0; j < r; j++)
            {
                for (int i = 0; i <c; i++)
                {
                    ans[j][i] = "";
                }
            }

            return ans;
        }

        private void LevelTraverse(TreeNode node, int level, int left, int right, IList<IList<string>> ans)
        {
            if (level >= ans.Count)
            {
                return;
            }

            int mid = (left + right) / 2;

            if (node == null)
            {
                ans[level][mid] = "";
                return;
            }


            ans[level][mid] = node.val.ToString();

            LevelTraverse(node.left, level + 1, left, mid - 1, ans);
            LevelTraverse(node.right, level + 1, mid + 1, right, ans);

        }

        private int GetColumnSize(int depth)
        {
            return (1 << depth) - 1;
        }

        private int GetDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftD = GetDepth(root.left);
            int rightD = GetDepth(root.right);

            return 1 + Math.Max(leftD, rightD);
        }
    }
}
