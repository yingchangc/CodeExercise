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
            var inbound = new Dictionary<int, int>();
            var lookupChild = new Dictionary<int, List<int>>();

            //inbound and child lookup
            foreach (var seq in seqs)
            {
                // for case []
                if (seq.Count == 0)
                {
                    continue;
                }

                // seq can be [1]  or [1 2 3 4]     
                int s = seq[0];
                if (!inbound.ContainsKey(s))
                {
                    inbound.Add(s, 0);
                }


                for (int i = 1; i < seq.Count; i++)
                {
                    int e = seq[i];

                    if (!inbound.ContainsKey(e))
                    {
                        inbound.Add(e, 0);
                    }
                    inbound[e]++;

                    if (!lookupChild.ContainsKey(s))
                    {
                        lookupChild.Add(s, new List<int>());
                    }
                    lookupChild[s].Add(e);

                    // if there is next, curr e as source
                    s = e;
                }
            }


            // que for head
            Queue<int> que = new Queue<int>();

            foreach (var node in inbound.Keys)
            {
                if (inbound[node] == 0)
                {
                    que.Enqueue(node);
                }
            }

            // yic for case  [1][2][3]    or    [1][2,3][3,2]
            if (que.Count != 1 || inbound.Keys.Count != org.Length)
            {
                return false;
            }

            List<int> ans = new List<int>();
            while (que.Count > 0)
            {
                var node = que.Dequeue();
                ans.Add(node);

                // children
                if (lookupChild.ContainsKey(node))
                {
                    var children = lookupChild[node];

                    foreach (var child in children)
                    {
                        inbound[child]--;

                        if (inbound[child] == 0)
                        {
                            que.Enqueue(child);
                            inbound.Remove(child);
                        }
                    }
                }

                if (que.Count > 1)
                {
                    return false;  // cannot have have multiple choices
                }
            }

            if (ans.Count != org.Length)
            {
                return false;
            }

            for (int i = 0; i < ans.Count; i++)
            {
                if (ans[i] != org[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
