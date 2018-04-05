using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    /// <summary>
    /// 565
    /// http://www.lintcode.com/en/problem/heart-beat/
    /// In the Master-Slave architecture, slave server will ping master in every k seconds to tell master server he is alive. If a master server didn't receive any ping request from a slave server in 2 * k seconds, the master will trigger an alarm (for example send an email) to administrator.
    ///Let's mock the master server, you need to implement the following three methods:
    ///
    ///initialize(slaves_ip_list, k). salves_ip_list is a list of slaves' ip addresses. k is define above.
    ///ping(timestamp, slave_ip). This method will be called every time master received a ping request from one of the slave server.timestamp is the current timestamp in seconds.slave_ip is the ip address of the slave server who pinged master.
    ///getDiedSlaves(timestamp). This method will be called periodically(it's not guaranteed how long between two calls). timestamp is the current timestamp in seconds, and you need to return a list of slaves' ip addresses that died. Return an empty list if no died slaves found.
    ///You can assume that when the master started, the timestamp is 0, and every method will be called with an global increasing timestamp.
    ///
    /// Example
    /// initialize(["10.173.0.2", "10.173.0.3"], 10)
    /// ping(1, "10.173.0.2")
    /// getDiedSlaves(20)
    /// >> ["10.173.0.3"]
    /// getDiedSlaves(21)
    /// >> ["10.173.0.2", "10.173.0.3"]
    /// ping(22, "10.173.0.2")
    /// ping(23, "10.173.0.3")
    /// getDiedSlaves(24)
    /// >> []
    /// getDiedSlaves(42)
    /// >> ["10.173.0.2"]
    /// 
    /// </summary>
    class HeartBeat
    {
        Dictionary<string, int> slaveIPHeartbeat;
        int maxTTL;
        public HeartBeat()
        {
            slaveIPHeartbeat = new Dictionary<string, int>();
            maxTTL = 0;
        }

        public void initialize(List<String> slaves_ip_list, int k)
        {
            maxTTL = k;
            
            foreach(var ip in slaves_ip_list)
            {
                // 0 as current time stamp
                slaveIPHeartbeat.Add(ip, 0);
            }
        }

        public void ping(int timestamp, String slave_ip)
        {
            if (slaveIPHeartbeat.ContainsKey(slave_ip))
            {
                slaveIPHeartbeat[slave_ip] = timestamp;
            }
            
        }

        /*
         * @param timestamp: current timestamp in seconds
         * @return: a list of slaves'ip addresses that died
         */
        public List<String> getDiedSlaves(int timestamp)
        {
            List<string> dieIPs = new List<string>();

            foreach(var ip in slaveIPHeartbeat.Keys)
            {
                int lastTimeLog = slaveIPHeartbeat[ip];
                if ((timestamp - lastTimeLog) >= 2 *maxTTL)
                {
                    dieIPs.Add(ip);
                }
            }

            return dieIPs;
        }
    }
}
