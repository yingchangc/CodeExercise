using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class SixDegree
    {
        public int SixDegreeSolver(List<UndirectedGraphNode> graph, UndirectedGraphNode s, UndirectedGraphNode t)
        {
            if (s == t)
            {
                return 0;
            }

            Queue<UndirectedGraphNode> queue = new Queue<UndirectedGraphNode>();
            HashSet<UndirectedGraphNode> visited = new HashSet<UndirectedGraphNode>();

            queue.Enqueue(s);
            visited.Add(s);

            int depth = 0;

            while(queue.Count > 0)
            {
                int currLevelSize = queue.Count;

                for (int i = 0; i < currLevelSize; i++)
                {
                    UndirectedGraphNode curr = queue.Dequeue();

                    foreach (UndirectedGraphNode neighbor in curr.neighbors)
                    {
                        if (visited.Contains(neighbor))
                        {
                            continue;
                        }

                        if (neighbor == t)
                        {
                            return depth + 1;
                        }

                        // yic add together
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }

                depth++;
            }

            return -1;
        }
    }
}
