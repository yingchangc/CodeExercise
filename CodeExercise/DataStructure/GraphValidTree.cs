using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    class GraphValidTree
    {
        class UnionFindGraphValidTree
        {
            int[] ufArray;

            public int Count;

            public UnionFindGraphValidTree(int size)
            {
                this.Count = size;   // init with num of nodes
                ufArray = new int[size];
                for (int i = 0; i < size; i++)
                {
                    ufArray[i] = i;
                }
            }

            public int Find(int a)
            {
                if (a != ufArray[a])
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

                    this.Count--;
                }
            }
        }

        /// <summary>
        /// 261 Graph Valid Tree
        /// https://leetcode.com/problems/graph-valid-tree/description/
        /// Given n nodes labeled from 0 to n - 1 and a list of undirected edges (each edge is a pair of nodes), write a function to check whether these edges make up a valid tree.
        /// 
        ///         For example:
        /// 
        /// Given n = 5 and edges = [[0, 1], [0, 2], [0, 3], [1, 4]], return true.
        /// 
        /// Given n = 5 and edges = [[0, 1], [1, 2], [2, 3], [1, 3], [1, 4]], return false.
        /// 
        /// Note: you can assume that no duplicate edges will appear in edges.Since all edges are undirected, [0, 1] is the same as [1, 0]
        ///         and thus will not appear together in edges.
        ///         
        /// Wikipedia: “a tree is an undirected graph in which any two vertices are connected by exactly one path.”
        /// 
        /// 
        /// Sol:
        ///  UnionFind when add a node their parent should not be the same initially,          
        /// in case 2 , when [1,3] is added, found that 1  and 3 point to the same parent, which should not be the case for real tree
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool ValidTree(int n, int[,] edges)
        {
            int numEdges = edges.GetLength(0);
            UnionFindGraphValidTree uf = new UnionFindGraphValidTree(n); // n nodes

            for (int i = 0; i< numEdges; i++)
            {
                int n1 = edges[i, 0];
                int n2 = edges[i, 1];

                int rootA = uf.Find(n1);
                int rootB = uf.Find(n2);

                if (rootA == rootB)
                {
                    return false;
                }

                uf.Union(n1, n2);
            }

            return (uf.Count==1);  // yic for disjoin graph

        }
    }
}
