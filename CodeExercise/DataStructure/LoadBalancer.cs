using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// 526. Load Balancer
    /// 
    /// https://www.lintcode.com/problem/load-balancer/description
    /// 
    /// Implement a load balancer for web servers.It provide the following functionality:
    /// 
    /// 
    /// Add a new server to the cluster => add(server_id).
    /// Remove a bad server from the cluster => remove(server_id).
    /// Pick a server in the cluster randomly with equal probability => pick().
    /// Example
    /// At beginning, the cluster is empty => {}.
    /// 
    /// add(1)
    /// add(2)
    /// add(3)
    /// pick()
    /// >> 1         // the return value is random, it can be either 1, 2, or 3.
    /// pick()
    /// >> 2
    /// pick()
    /// >> 1
    /// pick()
    /// >> 3
    /// remove(1)
    /// pick()
    /// >> 2
    /// pick()
    /// >> 3
    /// pick()
    /// >> 3
    /// </summary>
    class LoadBalancer
    {
        List<int> pool = new List<int>();
        Random rd = new Random();
        Dictionary<int, int> lookup = new Dictionary<int, int>(); // id, loc

        public void add(int server_id)
        {
            if (!lookup.ContainsKey(server_id))
            {
                pool.Add(server_id);
                lookup.Add(server_id, pool.Count - 1);
            }
            
        }

        /*
         * @param server_id: server_id remove a bad server from the cluster
         * @return: nothing
         */
        public void remove(int server_id)
        {
            if (!lookup.ContainsKey(server_id))
            {
                return;
            }

            int serverIdx = lookup[server_id];
            
            //swap serverId the last one
            int lastIdx = pool.Count - 1;
            int lastSererID = pool[lastIdx];
            pool[serverIdx] = lastSererID;
            lookup[lastSererID] = serverIdx;

            pool.RemoveAt(lastIdx);
            lookup.Remove(server_id);
            
        }

        /*
         * @return: pick a server in the cluster randomly with equal probability
         */
        public int pick()
        {
            int count = pool.Count;
            int tempIdx = rd.Next(count);

            return pool[tempIdx];
        }
    }
}
