using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Tree
{
    public class DiameterOfBT
    {
        /// <summary>
        /// https://leetcode.com/problems/diameter-of-binary-tree/description/
        /// https://www.youtube.com/watch?v=ey7DYc9OANo
        /// Given a binary tree 
        ///         1
        ///        / \
        ///       2   3
        ///      / \     
        ///     4   5    
        ///
        ///eturn 3, which is the length of the path[4, 2, 1, 3] or[5, 2, 1, 3]. 
        ///
        /// diameter can be hight left +1 + right or left/right diameter it self
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = FindHeight(root.left);
            int rightHeight = FindHeight(root.right);
            int diameter = leftHeight + rightHeight; // Note not 1 +  becasue we are compute the distance  not num of nodes

            int leftDiameter = DiameterOfBinaryTree(root.left);
            int rightDiameter = DiameterOfBinaryTree(root.right);

            return Math.Max(diameter, Math.Max(leftDiameter, rightDiameter));
        }

        private static int FindHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = FindHeight(root.left);
            int rightHeight = FindHeight(root.right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
}
