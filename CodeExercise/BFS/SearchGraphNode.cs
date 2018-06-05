using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class SearchGraphNode
    {
        /// <summary>
        /// lint 618. Search Graph Nodes
        /// https://www.lintcode.com/problem/search-graph-nodes/description
        /// Given a undirected graph, a node and a target, return the nearest node to given node which value of it is target, 
        /// return NULL if you can't find.
        /// There is a mapping store the nodes' values in the given parameters.
        /// 
        /// Example
        ///  2------3  5
        ///   \     |  | 
        ///    \    |  |
        ///     \   |  |
        ///      \  |  |
        ///        1 --4
        ///  Give a node 1, target is 50
        ///  
        ///  there a hash named values which is [3,4,10,50,50], represent:
        ///  Value of node 1 is 3
        ///  Value of node 2 is 4
        ///  Value of node 3 is 10
        ///  Value of node 4 is 50
        ///  Value of node 5 is 50
        ///  
        ///  Return node 4
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="values"></param>
        /// <param name="node"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public UndirectedGraphNode searchNode(List<UndirectedGraphNode> graph,
                                          Dictionary<UndirectedGraphNode, int> values,
                                          UndirectedGraphNode node,
                                          int target)
        {
            Queue<UndirectedGraphNode> queue = new Queue<UndirectedGraphNode>();
            HashSet<UndirectedGraphNode> set = new HashSet<UndirectedGraphNode>();

            // yic this two are together
            queue.Enqueue(node);
            set.Add(node);

            while(queue.Count > 0)
            {
                var curr = queue.Dequeue();

                if (target == values[curr])
                {
                    return curr;
                }

                foreach(UndirectedGraphNode n in curr.neighbors)
                {
                    if (!set.Contains(n))
                    {
                        queue.Enqueue(n);
                        set.Add(n);
                    }
                }
            }

            return null;
        }
    }
}
