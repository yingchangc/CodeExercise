using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TopologicalSort
{
    class SequenceReconstruction
    {
        /// <summary>
        /// 444. Sequence Reconstruction
        /// https://leetcode.com/problems/sequence-reconstruction/description/
        /// Check whether the original sequence org can be uniquely reconstructed from the sequences in seqs. The org sequence is a 
        /// permutation of the integers from 1 to n, with 1 ≤ n ≤ 10^4. Reconstruction means building a shortest common supersequence 
        /// of the sequences in seqs (i.e., a shortest sequence so that all sequences in seqs are subsequences of it). 
        /// Determine whether there is only one sequence that can be reconstructed from seqs and it is the org sequence.
        /// Example 1:
        /// 
        /// Input:
        /// org: [1,2,3], seqs: [[1,2],[1,3]]
        /// 
        /// Output:
        /// false
        /// 
        /// Explanation:
        /// [1,2,3] is not the only one sequence that can be reconstructed, because[1, 3, 2] is also a valid sequence 
        /// that can be reconstructed.
        /// </summary>
        /// <param name="org"></param>
        /// <param name="seqs"></param>
        /// <returns></returns>
        public bool SequenceReconstructionSolver(int[] org, IList<IList<int>> seqs)
        {
            // (1) get inbound and edge
            Dictionary<int, int> inbound = new Dictionary<int, int>();
            Dictionary<int, List<int>> childLookup = new Dictionary<int, List<int>>();   // use list for case like [1,2] [1,2]  2 only count 1 for HashSet

            foreach(var seq in seqs)
            {
                int seqLen = seq.Count;

                if (seqLen == 0)
                {
                    continue;
                }

                int pre = seq[0];

                // hanlde 1st position; don't add inbound
                if(!inbound.ContainsKey(seq[0]))
                {
                    inbound.Add(seq[0], 0);
                }

                for (int i = 1; i < seqLen; i++)
                {
                    if (!inbound.ContainsKey(seq[i]))
                    {
                        inbound.Add(seq[i], 0);
                    }
                    inbound[seq[i]]++;

                    // update child 
                    if (!childLookup.ContainsKey(pre))
                    {
                        childLookup.Add(pre, new List<int>());
                    }
                    childLookup[pre].Add(seq[i]);

                    // update pre
                    pre = seq[i];

                }
            }

            // (2) build graph
            Queue<int> queue = new Queue<int>();
            foreach(int n in inbound.Keys)
            {
                if (inbound[n] == 0)
                {
                    queue.Enqueue(n);
                }
            }

            List<int> tSortArr = new List<int>();

            // early terminate when more than 1 choices
            while(queue.Count == 1)
            {
                int n = queue.Dequeue();
                tSortArr.Add(n);

                if (childLookup.ContainsKey(n))  // yic  easy to get wrong here, as the last node, no child
                {
                    var children = childLookup[n];  

                    foreach (int child in children)
                    {
                        inbound[child]--;

                        if (inbound[child] == 0)
                        {
                            queue.Enqueue(child);
                        }
                    }    
                }
                
            }

            if (org.Length == tSortArr.Count && inbound.Keys.Count == org.Length)   //yic make sure inbound all node are calculated
            {
                for(int i = 0; i < org.Length; i++)
                {
                    if (org[i] != tSortArr[i])
                    {
                        return false; ;
                    }
                }

                // all match
                return true;
            }

            return false;
        }
    }
}
