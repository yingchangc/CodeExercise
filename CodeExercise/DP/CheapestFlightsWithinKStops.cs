using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DP
{
    class CheapestFlightsWithinKStops
    {
        /// <summary>
        /// 787. Cheapest Flights Within K Stops
        /// https://leetcode.com/problems/cheapest-flights-within-k-stops/
        /// 
        /// There are n cities connected by m flights. Each fight starts from city u and arrives at v with a price w.
        /// 
        /// Now given all the cities and flights, together with starting city src and the destination dst, your task is to find the cheapest price from src to dst with up to k stops.If there is no such route, output -1.
        /// 
        /// 
        /// Example 1:
        /// Input: 
        /// n = 3, edges = [[0, 1, 100], [1,2,100], [0,2,500]]
        /// src = 0, dst = 2, k = 1
        /// Output: 200
        /// Explanation: 
        /// The graph looks like this:
        /// 
        /// 
        /// The cheapest price from city 0 to city 2 with at most 1 stop costs 200, as marked red in the picture.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="flights"></param>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            Dictionary<int, HashSet<ToNode>> lookup = new Dictionary<int, HashSet<ToNode>>();

            int len = flights.GetLength(0);
            for (int i = 0; i < len; i++)
            {
                var flight = flights[i];
                var source = flight[0];
                var dstation = flight[1];
                var wt = flight[2];
                if (!lookup.ContainsKey(source))
                {
                    lookup.Add(source, new HashSet<ToNode>());
                }
                lookup[source].Add(new ToNode(dstation, wt));
            }


            Queue<ToNode> pq = new Queue<ToNode>();
            Dictionary<int, int> visited = new Dictionary<int, int>();

            pq.Enqueue(new ToNode(src, 0));

            int day = 0;


            while (pq.Count > 0 && day <= K+1)
            {
                int levelCount = pq.Count;

                for (int i = 0; i < levelCount; i++)
                {
                    var node = pq.Dequeue();

                    var currArriveTime = node.wt;

                    if (!visited.ContainsKey(node.label))
                    {
                        visited.Add(node.label, currArriveTime);
                    }

                    if (visited[node.label] > currArriveTime)
                    {
                        visited[node.label] = currArriveTime;
                    }


                    // no neighbor
                    if (!lookup.ContainsKey(node.label))
                    {
                        continue;
                    }

                    var neighbors = lookup[node.label];

                    foreach (var neighborNode in neighbors)
                    {

                        pq.Enqueue(new ToNode(neighborNode.label, currArriveTime + neighborNode.wt));
                    }
                }


                day++;
            }

           

            if (visited.ContainsKey(dst))
            {
                return visited[dst];
            }

            return -1;
        }


        

        public class ToNode
        {
            public int label;
            public int wt;

            public ToNode(int label, int wt)
            {
                this.label = label;
                this.wt = wt;
            }

        }


        /// <summary>
        /// DP solution
        /// </summary>
        /// <param name="n"></param>
        /// <param name="flights"></param>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int FindCheapestPriceDP(int n, int[][] flights, int src, int dst, int K)
        {
            // F[kday][city] = F[kday-1][city-1] + cost[city-1, city]  vs  F[kday-1][city]

            int numEdges = flights.GetLength(0);
            int[,] F = new int[K + 2, n];

            int[,] costs = new int[n, n];

            // init cost to max
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        costs[i, j] = 0;
                    }
                    else
                    {
                        costs[i, j] = int.MaxValue;
                    }
                    
                }
            }

            // construct city - city cost
            for (int i = 0; i < numEdges; i++)
            {
                var edge = flights[i];
                var c1 = edge[0];
                var c2 = edge[1];
                var cost = edge[2];
                costs[c1, c2] = cost;
            }

            // init F to max
            for (int d = 0; d <= K+1; d++)
            {
                for (int city = 0; city < n; city++)
                {
                    F[d, city] = int.MaxValue;
                }

            }

            F[0, src] = 0;

            // DP compute F
            for (int d = 1; d <= K+1; d++)
            {
                for (int depart = 0; depart < n; depart++)
                {
                    for (int arrive = 0; arrive < n; arrive++)
                    {
 
                        int flightCost = 0;
                        if (F[d - 1, depart] == int.MaxValue || costs[depart, arrive] == int.MaxValue)
                        {
                            flightCost = int.MaxValue;
                        }
                        else
                        {
                            flightCost = F[d - 1, depart] + costs[depart, arrive];
                        }

                        F[d, arrive] = Math.Min(F[d, arrive], Math.Min(flightCost, F[d-1, arrive]));
                    }

                }
            }

            int ans = int.MaxValue;
            for (int d = 1; d <= K+1; d++)
            {
                ans = Math.Min(ans, F[d, dst]);
            }

            return ans < int.MaxValue ? ans : -1;
        }
    }
}
