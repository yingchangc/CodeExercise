using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    // todo  https://coderpad.io/DATRW6Q7
    class Indeed
    {
        /* 
        Suppose we have some input data describing a graph of relationships between parents and children over multiple generations. The data is formatted as a list of (parent, child) pairs, where each individual is assigned a unique integer identifier.

        For example, in this diagram, 3 is a child of 1 and 2, and 5 is a child of 4:

          
        1   2   4
         \ /   / \
          3   5   8
           \ / \   \
            6   7   10

        Write a function that takes this data as input and returns two collections: one containing all individuals with zero known parents, and one containing all individuals with exactly one known parent.

        Sample output (pseudodata):

        findNodesWithZeroAndOneParents(parentChildPairs) => [
          [1, 2, 4],    // Individuals with zero parents
          [5, 7, 8, 10] // Individuals with exactly one parent
        ]

        Write a function that, for two given individuals in our dataset, returns true if and only if they share at least one ancestor.

        Sample input and output:
        hasCommonAncestor(parentChildPairs, 3, 8) => false
        hasCommonAncestor(parentChildPairs, 5, 8) => true
        hasCommonAncestor(parentChildPairs, 6, 8) => true
        hasCommonAncestor(parentChildPairs, 1, 3) => false
 */
        public class Node
        {
            public int v;

            public HashSet<Node> parents;


            public Node(int v)
            {
                this.v = v;
                this.parents = new HashSet<Node>();
            }
        }

        static bool hasCommonAncestor(List<Tuple<int, int>> inputs, int i, int j)
        {

            Dictionary<int, Node> lookup = new Dictionary<int, Node>();

            // build graph
            foreach (var t in inputs)
            {
                var p = t.Item1;
                var c = t.Item2;

                if (!lookup.ContainsKey(p))
                {
                    lookup.Add(p, new Node(p));
                }


                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, new Node(c));
                }

                lookup[c].parents.Add(lookup[p]);   // add parent node to 
            }

            var ni = lookup[i];
            var nj = lookup[j];

            var visited = new HashSet<Node>();
            FindParents(ni, visited, ni);

            var ans = CheckOverlap(nj, visited);

            return ans;

        }

        static bool CheckOverlap(Node n, HashSet<Node> visited)
        {
            if (n == null)
            {
                return false;
            }

            if (visited.Contains(n))
            {

                return true;
            }

            foreach (var pn in n.parents)
            {
                if (CheckOverlap(pn, visited))
                {
                    return true;
                }
            }

            return false;
        }
        static void FindParents(Node n, HashSet<Node> visited, Node self)
        {
            if (n == null)
            {
                return;
            }

            if (n != self)
            {
                visited.Add(n);
            }


            foreach (var pn in n.parents)
            {
                FindParents(pn, visited, self);
            }
        }


        static List<List<int>> findNodesWithZeroAndOneParents(List<Tuple<int, int>> inputs)
        {
            var lookup = new Dictionary<int, int>();  // node freq

            foreach (var t in inputs)
            {
                var p = t.Item1;
                var c = t.Item2;

                if (!lookup.ContainsKey(p))
                {
                    lookup.Add(p, 0);
                }


                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, 0);
                }
                lookup[c]++;
            }

            var ans = new List<List<int>>();

            var zerocase = new List<int>();
            var onecase = new List<int>();

            foreach (var key in lookup.Keys)
            {
                if (lookup[key] == 0)
                {
                    zerocase.Add(key);
                }
                else if (lookup[key] == 1)
                {
                    onecase.Add(key);
                }
            }

            ans.Add(zerocase);
            ans.Add(onecase);

            return ans;
        }
    }
}
