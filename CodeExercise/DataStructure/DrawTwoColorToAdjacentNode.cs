﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    public class GraphNode
    {
        public int color;   // 0 or 1
        public List<GraphNode> neighbors;
        public int label;
        public GraphNode(int val)
        {
            label = val;
            neighbors = new List<GraphNode>();
        }
    }
   
    class DrawTwoColorToAdjacentNode
    {

        /// <summary>
        /// In a graph, you have 2 colors to paint on a node, adjacent node cannot have the same color,
        /// If node are the same,
        /// 
        /// similiar question   "IsBipartite"
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool CanDrawTowColorInNode(GraphNode root)
        {
            if (root == null)
            {
                return true;
            }

            return CanDrawWithColor(root, 0);

        }

        bool CanDrawWithColor(GraphNode root, int initColor)
        {
            Queue<GraphNode> que = new Queue<GraphNode>();
            HashSet<GraphNode> visited = new HashSet<GraphNode>();

            var currColor = initColor;
            var nextColor = 1 - currColor;

            root.color = initColor;
            que.Enqueue(root);
            visited.Add(root);

            while(que.Count > 0)
            {
                int currLevel = que.Count;

                for (int i = 0; i < currLevel; i++)
                {
                    var curr = que.Dequeue();

                    foreach(var neighbor in curr.neighbors)
                    {
                        if (visited.Contains(neighbor))
                        {
                            if (currColor == neighbor.color)
                            {
                                return false;
                            }                            
                        }
                        else
                        {
                            //paint
                            neighbor.color = nextColor; 
                        }

                        if (!visited.Contains(neighbor))
                        {
                            que.Enqueue(neighbor);
                            visited.Add(neighbor);
                        }
                        
                    }
                }

                // swap color
                currColor = nextColor;
                nextColor = 1 - currColor;
            }

            return true;
        }


        public class GraphNode2
        {
            public int color;   // -1, 1, 0
            public GraphNode2[] neighbors;

            public GraphNode2()
            {
                color = -1;
            }
        }

        //    A    : 0
        // C  B   D : 1
        //    D
        // 2018 12 04 morris chuang
        public bool validGraphSolver(GraphNode2 node)
        {

            if (node == null)
            {
                return false;
            }

            Queue<GraphNode2> que = new Queue<GraphNode2>();

            int currColor = 0;
            int nextColor = 1;
            node.color = currColor;

            que.Enqueue(node);

            while (que.Count > 0)
            {
                int levelcount = que.Count;   // 3

                for (int i = 0; i < levelcount; i++)
                {
                    var curr = que.Dequeue();    // B  

                    foreach (var neighbor in curr.neighbors)    // BCD
                    {
                        if (neighbor.color == -1)
                        {
                            neighbor.color = nextColor;     // 1
                            que.Enqueue(neighbor);   //B  
                        }
                        else if (neighbor.color == currColor)      //  1  == 1
                        {
                            return false;
                        }
                    }

                }

                currColor = nextColor;    // c :0   n: 1       c:1  n :0       
                nextColor = 1 - nextColor;
            }

            return true;

        }
    }
}
