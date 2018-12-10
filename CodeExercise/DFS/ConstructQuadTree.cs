using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class ConstructQuadTree
    {
        // Definition for a QuadTree node.
        public class Node
        {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node() { }
            public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }

        }

        /// <summary>
        /// 427. Construct Quad Tree
        /// https://leetcode.com/problems/construct-quad-tree/
        /// We want to use quad trees to store an N x N boolean grid. Each cell in the grid can only be true or false. The root node represents the whole grid. For each node, it will be subdivided into four children nodes until the values in the region it represents are all the same.
        /// 
        /// Each node has another two boolean attributes : isLeaf and val.isLeaf is true if and only if the node is a leaf node.The val attribute for a leaf node contains the value of the region it represents.
        /// 
        /// Your task is to use a quad tree to represent a given grid.The following example may help you understand the problem better:
        /// 
        /// 
        /// Given the 8 x 8 grid below, we want to construct the corresponding quad tree:
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Node Construct(int[][] grid)
        {

            int lenY = grid.GetLength(0);
            int lenX = grid[0].GetLength(0);

            return Helper(grid, 0, lenY - 1, 0, lenX - 1);
        }

        private Node Helper(int[][] grid, int y1, int y2, int x1, int x2)
        {
            if (x1 == x2 && y1 == y2)
            {
                return new Node(grid[y1][x1] == 1, true, null, null, null, null);
            }

            // break into  x1, (x1+x2)/2, (x1+x2)/2+1, y1, (y1+y2)/2, (y1+y2)/2+1
            var TL = Helper(grid, y1, (y1 + y2) / 2, x1, (x1 + x2) / 2);
            var TR = Helper(grid, y1, (y1 + y2) / 2, (x1 + x2) / 2 + 1, x2);

            var BL = Helper(grid, (y1 + y2) / 2 + 1, y2, x1, (x1 + x2) / 2);
            var BR = Helper(grid, (y1 + y2) / 2 + 1, y2, (x1 + x2) / 2 + 1, x2);

            if (TL.val == TR.val && TR.val == BL.val && BL.val == BR.val
               && TL.isLeaf && TR.isLeaf && BL.isLeaf && BR.isLeaf)
            {
                return new Node(TL.val, true, null, null, null, null);
            }

            return new Node(false, false, TL, TR, BL, BR);   //non-leaf nodes, val can be arbitrary, so it is represented as *.
        }
    }
}
