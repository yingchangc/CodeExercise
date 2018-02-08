using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class NumberConnectedComponentsInUG
    {
        class UnionFindForUG
        {
            private int[] ufArray;

            private int componentCount;
            
            public UnionFindForUG(int size)
            {
                ufArray = new int[size];
                for (int i =0; i < size; i++)
                {
                    ufArray[i] = i;
                }

                componentCount = size;
            }

            public int Find(int a)
            {
                if (ufArray[a] != a)
                {
                    int topAncestor = Find(ufArray[a]);
                    ufArray[a] = topAncestor;
                }

                return ufArray[a];
            }

            public void Union(int a, int b)
            {
                int rootA = Find(a);
                int rootB = Find(b);

                if (rootA != rootB)
                {
                    ufArray[rootB] = rootA;
                    componentCount--;
                }
            }

            public int Query()
            {
                return componentCount;
            }
        }

        /// <summary>
        /// 323
        /// https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/description/
        /// Given n nodes labeled from 0 to n - 1 and a list of undirected edges (each edge is a pair of nodes), write a function to find the number of connected components in an undirected graph.
        /// 
        /// ex.
        /// Given n = 5 and edges = [[0, 1], [1, 2], [3, 4]], return 2.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int CountComponents(int n, int[,] edges)
        {
            int numOfEdges = edges.GetLength(0);

            var uf = new UnionFindForUG(n);

            for(int i = 0; i < numOfEdges; i++)
            {
                int node1 = edges[i, 0];
                int node2 = edges[i, 1];

                uf.Union(node1, node2);
            }

            return uf.Query();
        }


        public int CountComponents2(int n, int[,] edges)
        {
            int count = 0;
            int[] root = new int[n];
            for (int i = 0; i < n; i++)
            {
                root[i] = i;
            }

            for (int i = 0; i < edges.GetLength(0); i++)
            {

                int f = edges[i,0];
                int s = edges[i,1];
                while (f != root[f])
                    f = root[f];
                while (s != root[s])
                    s = root[s];

                root[f] = s;
            }
            for (int i = 0; i < n; i++)
            {
                if (root[i] == i)
                    ++count;
            }
            return count;
        }
    }
}
