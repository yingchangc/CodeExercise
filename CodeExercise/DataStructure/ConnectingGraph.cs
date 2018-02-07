using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{

    public class UnionFind
    {
        int[] ufArray;
        public UnionFind(int n)
        {
            ufArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                ufArray[i] = i;
            }
        }

        public int Find(int x)
        {
            if (x != ufArray[x])
            {
                int topAncestor = Find(ufArray[x]);
                ufArray[x] = topAncestor;   // compress and reset to topAncestor
            }

            return ufArray[x];
        }

        public void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA != rootB)
            {
                ufArray[rootB] = rootA;
            }
        }
    }

    //lint code 589. Connecting Graph
    ///http://www.lintcode.com/en/problem/connecting-graph/
    /// <summary>
    /// Given n nodes in a graph labeled from 1 to n. There is no edges in the graph at beginning.
    ///     You need to support the following method:
    /// 1. connect(a, b), add an edge to connect node a and node b. 2.query(a, b)`, check if two nodes are connected
    /// 
    /// Have you met this question in a real interview? Yes
    /// Example
    /// 5 // n = 5
    /// query(1, 2) return false
    /// connect(1, 2)
    /// query(1, 3) return false
    /// connect(2, 4)
    /// query(1, 4) return true
    /// </summary>

    class ConnectingGraph
    {

        UnionFind uf;

        /*
            * @param n: An integer
            */
        public ConnectingGraph(int n)
        {
            uf = new UnionFind(n);
            // do intialization if necessary
        }

        /*
         * @param a: An integer
         * @param b: An integer
         * @return: nothing
         */
        public void connect(int a, int b)
        {
            uf.Union(a, b);
            // write your code here
        }

        /*
         * @param a: An integer
         * @param b: An integer
         * @return: A boolean
         */
        public bool query(int a, int b)
        {
            // write your code here
            return uf.Find(a) == uf.Find(b);
        }
    }

    /// <summary>
    /// 590
    /// http://www.lintcode.com/en/problem/connecting-graph-ii/
    /// Given n nodes in a graph labeled from 1 to n. There is no edges in the graph at beginning.
    ///
    ///    You need to support the following method:
    ///1. connect(a, b), an edge to connect node a and node b
    ///2. query(a), Returns the number of connected component nodes which include node a.
    /// </summary>
    public class ConnectingGraph2
    {
        int[] ufArray;
        int[] countArray;

        public ConnectingGraph2(int n)
        {
            ufArray = new int[n];    // store parent and count
            countArray = new int[n];
            for (int i = 0; i<n; i++)
            {
                ufArray[i] = i;     // parent loc to itself
                countArray[i] = 1;    // count
            }
        }

        private int Find(int x)
        {
            if (x != ufArray[x])
            {
                int topAncestor = Find(ufArray[x]);
                ufArray[x] = topAncestor;
            }

            return ufArray[x];
        }

        public void connect(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA != rootB)
            {
                ufArray[rootB] = rootA;
                countArray[rootA] += countArray[rootB];  // dump the rootB count to RootA
            }
        }

        public int query(int a)
        {
            int rootA = Find(a);
            return countArray[rootA];
        }
    }

    /// <summary>
    ///  591
    ///  http://www.lintcode.com/en/problem/connecting-graph-iii/
    ///  Given n nodes in a graph labeled from 1 to n. There is no edges in the graph at beginning.
    ///
    ///    You need to support the following method:
    ///1. connect(a, b), an edge to connect node a and node b
    ///2. query(), Returns the number of connected component in the graph
    /// </summary>
    public class ConnectingGraph3
    {
        int[] ufArray;
        int componentsCount;

        public ConnectingGraph3(int n)
        {
            ufArray = new int[n];
            for (int i = 0; i <n; i++)
            {
                ufArray[i] = i;
            }

            this.componentsCount = n;
        }

        int Find(int a)
        {
            if (ufArray[a] != a)
            {
                int topAncestor = Find(ufArray[a]);
                ufArray[a] = topAncestor;
            }

            return ufArray[a];
        }
        
        public void connect(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootB != rootA)
            {
                ufArray[rootB] = rootA;
                componentsCount--;
            }
        }

        /*
         * @return: An integer
         */
        public int query()
        {
            return componentsCount;
        }
    }
}
