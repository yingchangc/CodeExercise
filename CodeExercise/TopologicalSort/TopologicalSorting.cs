using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TopologicalSort
{
    class DirectedGraphNode
    {
        public int label;
        public List<DirectedGraphNode> neighbors;
        public DirectedGraphNode(int x) { label = x; neighbors = new List<DirectedGraphNode>(); }
    };

    class TopologicalSorting
    {
        /// <summary>
        /// 127 Topological Sorting
        /// https://www.lintcode.com/problem/topological-sorting/description
        /// Given an directed graph, a topological order of the graph nodes is defined as follow:

        /// For each directed edge A -> B in graph, A must before B in the order list.
        /// The first node in the order can be any node in the graph with no nodes direct to it.
        /// Find any topological order for the given graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<DirectedGraphNode> TopSort(List<DirectedGraphNode> graph)
        {
            //(1) inbound and child lookup
            Dictionary<DirectedGraphNode, int> inbound = new Dictionary<DirectedGraphNode, int>();
            Dictionary<DirectedGraphNode, HashSet<DirectedGraphNode>> childrenLookup = new Dictionary<DirectedGraphNode, HashSet<DirectedGraphNode>>();
            // yic childrenlookup is not needed, can just use (foreach node in graph)
            foreach(DirectedGraphNode node in graph)
            {
                if (!childrenLookup.ContainsKey(node))
                {
                    childrenLookup.Add(node, new HashSet<DirectedGraphNode>());
                }

                foreach (DirectedGraphNode neighbor in node.neighbors)
                {
                    // update inbound
                    if (!inbound.ContainsKey(neighbor))
                    {
                        inbound.Add(neighbor, 0);
                    }
                    inbound[neighbor]++;

                    // update children lookup
                    childrenLookup[node].Add(neighbor);
                }
            }

            // build topology sort queue
            Queue<DirectedGraphNode> queue = new Queue<DirectedGraphNode>();
            List<DirectedGraphNode> ans = new List<DirectedGraphNode>();        // yic cannot use queue as ans , queue will pop

            foreach(DirectedGraphNode parentNode in childrenLookup.Keys)
            {
                if (!inbound.ContainsKey(parentNode))
                {
                    queue.Enqueue(parentNode);
                    ans.Add(parentNode);
                }
            }

            while(queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                // yic avoid last node no child
                if (childrenLookup.ContainsKey(currNode))
                {
                    var currChildren = childrenLookup[currNode];

                    foreach(DirectedGraphNode child in currChildren)
                    {
                        inbound[child]--;

                        if (inbound[child] == 0)
                        {
                            queue.Enqueue(child);
                            ans.Add(child);
                        }
                    }
                }
  
            }

            return ans;
        }
    }
}
