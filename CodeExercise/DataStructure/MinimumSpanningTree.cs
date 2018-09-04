using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class MinimumSpanningTree
    {
        /////Definition for a Connection.
        ///public class Connection
        ///{
        ///     public String city1, city2;
        ///     public int cost;
        ///     public Connection(String city1, String city2, int cost)
        ///     {  
        ///        this.city1 = city1;
        ///        this.city2 = city2;
        ///        this.cost = cost;
        ///     }
        ///}
        /// <summary>
        /// 629. Minimum Spanning Tree
        /// https://www.lintcode.com/problem/minimum-spanning-tree/description?_from=ladder
        /// Given a list of Connections, which is the Connection class (the city name at both ends of the edge and a cost between them), find some edges, connect all the cities and spend the least amount.
        /// Return the connects if can connect all the cities, otherwise return empty list.
        /// 
        /// 
        /// Example
        /// Gievn the connections = ["Acity", "Bcity", 1], ["Acity","Ccity",2], ["Bcity","Ccity",3]
        /// 
        /// Return ["Acity","Bcity",1], ["Acity","Ccity",2]
        /// 
        /// Notice
        ///         Return the connections sorted by the cost, or sorted city1 name if their cost is same, or sorted city2 if their city1 name is also same.
        /// 
        /// sol:
        /// goal is to find the all the connected edges with min edge cost,
        /// 
        /// HashSet Cities to init UnionFind,
        /// use UnionFind like GraphValidTree if any edge exist, skip adding current
        /// 
        /// </summary>
        /// <param name="connections"></param>
        /// <returns></returns>
        public List<Connection> LowestCost(List<Connection> connections)
        {
            // Find all Edges
            HashSet<string> cities = new HashSet<string>();
            foreach(var con in connections)
            {
                cities.Add(con.city1);
                cities.Add(con.city2);
            }

            // init Unionfind
            UnionFindMST uf = new UnionFindMST(cities);


            // get low cost edge order
            connections.Sort((x, y) => {
                if (x.cost != y.cost)
                {
                    return x.cost.CompareTo(y.cost);
                }
                else if (x.city1 != y.city1)
                {
                    return x.city1.CompareTo(y.city1);
                }
                return x.city2.CompareTo(y.city2);
            });
           
            List<Connection> ans = new List<Connection>();

            foreach(var con in connections)
            {
                if (uf.Find(con.city1) != uf.Find(con.city2))
                {
                    ans.Add(con);
                    uf.Union(con.city1, con.city2);
                }
            }

            // edge is 1 lesss than cities count
            if (cities.Count == (ans.Count + 1))
            {
                return ans;
            }
            return new List<Connection>();
        }

        public class UnionFindMST
        {
            Dictionary<string, string> parentLookup;
            public UnionFindMST(HashSet<string> cities)
            {
                parentLookup = new Dictionary<string, string>();

                foreach(string city in cities)
                {
                    parentLookup.Add(city, city);
                }

            }

            public string Find(string str)
            {
                if (str != parentLookup[str])
                {
                    string ancestor = Find(parentLookup[str]);
                    parentLookup[str] = ancestor;
                }
                return parentLookup[str];
            }

            public void Union(string strA, string strB)
            {
                string pA = Find(strA);
                string pB = Find(strB);

                if (pA != pB)
                {
                    parentLookup[pB] = pA;
                }
            }
        }  
    }
}
