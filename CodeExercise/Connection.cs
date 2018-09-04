using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    class Connection
    {
        public String city1, city2;
        public int cost;
        public Connection(String city1, String city2, int cost)
        {
            this.city1 = city1;
            this.city2 = city2;
            this.cost = cost;
        }
    }
}
