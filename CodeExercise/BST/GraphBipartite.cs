using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class GraphBipartite
    {
        /// <summary>
        /// https://leetcode.com/problems/is-graph-bipartite/description/
        /// 785. Is Graph Bipartite?
        /// Given an undirected graph, return true if and only if it is bipartite.
        /// 
        /// Recall that a graph is bipartite if we can split it's set of nodes into two independent subsets A and B such that every edge in the graph has one node in A and another node in B.
        /// 
        /// The graph is given in the following form: graph[i] is a list of indexes j for which the edge between nodes i and j exists.Each node is an integer between 0 and graph.length - 1.  There are no self edges or parallel edges: graph[i] does not contain i, and it doesn't contain any element twice.
        /// 
        /// 
        /// Example 1:
        /// Input: [[1,3], [0,2], [1,3], [0,2]]
        /// Output: true
        /// Explanation: 
        /// The graph looks like this:
        /// 0----1
        /// |    |
        /// |    |
        /// 3----2
        /// We can divide the vertices into two groups: {0, 2}
        ///     and {1, 3}.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite(int[][] graph)
        {     
            Dictionary<int, int> visited = new Dictionary<int, int>();  // node color

            for (int i = 0; i < graph.Length; i++)
            {
                if (visited.ContainsKey(i))
                {
                    continue;
                }

                if (BFS(graph, visited, i) == false)
                {
                    return false;
                }
            }

            return true;

        }

        private bool BFS(int[][] graph, Dictionary<int, int> visited, int rootIdex)
        {
            int currC = 0;
            int nextC = 1;

            Queue<int> que = new Queue<int>();
            que.Enqueue(rootIdex);
            visited.Add(rootIdex, currC);

            while (que.Count > 0)
            {
                int levelCount = que.Count;

                for(int i = 0; i < levelCount; i++)
                {
                    var curr = que.Dequeue();

                    var neighbors = graph[curr];

                    foreach(var n in neighbors)
                    {
                        if (visited.ContainsKey(n))
                        {
                            if (visited[n] == currC)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            visited.Add(n, nextC);
                            que.Enqueue(n);
                        }
                    }
                }

                // change color for next level
                currC = nextC;
                nextC = 1 - currC;
            }
            return true;
        }
        
        
    }
}
