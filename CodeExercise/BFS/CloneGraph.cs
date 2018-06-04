using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class CloneGraph
    {
        /// <summary>
        /// 133 Clone Graph
        /// https://leetcode.com/problems/clone-graph/description/
        /// 
        /// Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors.
        /// 
        /// Nodes are labeled uniquely.
        /// 
        /// We use # as a separator for each node, and , as a separator for node label and each neighbor of the node.
        /// As an example, consider the serialized graph {
        ///             0,1,2#1,2#2,2}.
        /// 
        /// The graph has a total of three nodes, and therefore contains three parts as separated by #.
        /// 
        /// First node is labeled as 0.Connect node 0 to both nodes 1 and 2.
        /// Second node is labeled as 1.Connect node 1 to node 2.
        /// Third node is labeled as 2.Connect node 2 to node 2(itself), thus forming a self-cycle.
        /// 
        /// 
        /// Sol:
        //  first copy node by bfs to dictionary<orig, new>
        /// for each dic keys, find orig neighbors and assign coped neighbor to new node 
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public UndirectedGraphNode CloneGraphSolver(UndirectedGraphNode node)
        {
            if (node == null)
            {
                return null;
            }

            Queue<UndirectedGraphNode> queue = new Queue<UndirectedGraphNode>();
            Dictionary<UndirectedGraphNode, UndirectedGraphNode> lookup = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();

            queue.Enqueue(node);
            lookup.Add(node, new UndirectedGraphNode(node.label));

            // BFS to iterate nodes and copy and flattern it to dictionary
            //  (origin_node, new_node)
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                foreach(UndirectedGraphNode neighbor in curr.neighbors)
                {
                    if (!lookup.ContainsKey(neighbor))
                    {
                        // enqueue neighbor
                        queue.Enqueue(neighbor);

                        // copy of neigobor 
                        lookup.Add(neighbor, new UndirectedGraphNode(neighbor.label));
                    }
                }
            }

            // link new neighbors by old neighbors
            foreach(UndirectedGraphNode n in lookup.Keys)
            {
                var copiedNode = lookup[n];
                foreach(var neighbor in n.neighbors)
                {
                    copiedNode.neighbors.Add(lookup[neighbor]);
                }
            }

            return lookup[node];
        }
    }
}
