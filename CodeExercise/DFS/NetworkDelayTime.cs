using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DFS
{
    class NetworkDelayTime
    {
        public int NetworkDelayTimesolver(int[,] times, int N, int K)
        {
            Dictionary<int, List<ToNode>> lookup = new Dictionary<int, List<ToNode>>();

            int size = times.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                int src = times[i, 0];
                int dst = times[i, 1];
                int wt = times[i, 2];

                if (!lookup.ContainsKey(src))
                {
                    lookup.Add(src, new List<ToNode>());
                }
                lookup[src].Add(new ToNode(dst, wt));
            }

            SortedSet<ToNode> pq = new SortedSet<ToNode>(new NodeComparer());

            pq.Add(new ToNode(K, 0));

            HashSet<int> visited = new HashSet<int>();
            int maxArriveTime = 0;

            while (pq.Count > 0)
            {
                var node = pq.First();
                pq.Remove(node);

                // yic pq may contains same node but sorted by shortest arrive time. if visited (taken) skip
                if (visited.Contains(node.label))
                {
                    continue;
                }

                visited.Add(node.label);
                var currArriveTime = node.wt;
                maxArriveTime = currArriveTime;

                // yic easy to forget
                if (!lookup.ContainsKey(node.label))
                {
                    // already the end branch of the graph ie. no out bound
                    continue;
                }

                var neighbors = lookup[node.label];

                foreach (var neighborNode in neighbors)
                {
                    // candidate node, the same label may have exisited in pq but this weight can be better
                    // don't insert if visited

                    if (visited.Contains(neighborNode.label))
                    {
                        continue;
                    }

                    pq.Add(new ToNode(neighborNode.label, currArriveTime + neighborNode.wt));
                }
            }

            if (visited.Count < N)
            {
                return -1;
            }

            return maxArriveTime;

        }

        public class NodeComparer : IComparer<ToNode>
        {
            public int Compare(ToNode n1, ToNode n2)
            {
                if (n1.wt != n2.wt)
                {
                    return n1.wt.CompareTo(n2.wt);
                }
                return n1.label.CompareTo(n2.label);
            }

        }

        public class ToNode
        {
            public int label;
            public int wt;

            public ToNode(int lb, int w)
            {
                label = lb;
                wt = w;
            }

        }
    }
}
