﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BFS
{
    class UndirectedGraphNode
    {
       public int label;
       public IList<UndirectedGraphNode> neighbors;
       public UndirectedGraphNode(int x)
       {
            label = x;
            neighbors = new List<UndirectedGraphNode>();
       }
    }
}
