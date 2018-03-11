using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class Skyline
    {
        /// <summary>
        /// 218
        /// https://leetcode.com/problems/the-skyline-problem/description/
        /// Given N buildings in a x-axis，each building is a rectangle and can be represented by a triple (start, end, height)，where start is the 
        /// start position on x-axis, end is the end position on x-axis and height is the height of the building. Buildings may overlap if you see 
        /// them from far away，find the outline of them。An outline can be represented by a triple, (start, end, height), where start is the start 
        /// position on x - axis of the outline, end is the end position on x - axis and height is the height of the outline.
        /// 
        /// For instance, the dimensions of all buildings in Figure A are recorded as: [ [2 9 10], [3 7 15], [5 12 12], [15 20 10], [19 24 8] ] .
        ///The output is a list of "key points" (red dots in Figure B) in the format of[[x1, y1], [x2, y2], [x3, y3], ... ] that uniquely defines a skyline.
        ///A key point is the left endpoint of a horizontal line segment.Note that the last key point, where the rightmost building ends, 
        ///is merely used to mark the termination of the skyline, and always has zero height.Also, the ground in between any two adjacent 
        ///buildings should be considered part of the skyline contour.
        ///
        /// For instance, the skyline in Figure B should be represented as:[ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0] ].
        /// 
        /// 
        /// sol 
        /// ref
        /// https://briangordon.github.io/2014/08/the-skyline-problem.html
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public IList<int[]> GetSkyline(int[,] buildings)
        {
            int N = buildings.GetLength(0);

            // sort by x location
            SortedDictionary<int, List<int>> locHeap = new SortedDictionary<int, List<int>>(); //locHeap
            for (int i =0; i < N; i++)
            {
                insertToHeap(locHeap, buildings[i,0], buildings[i,2]);    // insert x, h
                insertToHeap(locHeap, buildings[i,1], -buildings[i, 2]);    // insert y, -h
            }

            SortedDictionary<int, int> maxHeap = new SortedDictionary<int, int>(new MaxHeapComarer());
            insertToMaxHeap(maxHeap, 0);

            List<int[]> ans = new List<int[]>();
            int preHeight = 0;

            foreach(var loc in locHeap.Keys)
            {
                var heights = locHeap[loc];

                foreach(var h in heights)
                {
                    if (h >=0)
                    {
                        insertToMaxHeap(maxHeap, h);
                    }
                    else
                    {
                        removeFromMaxHeap(maxHeap, -h);
                    }
                }

                int currMaxHeight = maxHeap.Keys.First();
                if (preHeight != currMaxHeight)
                {
                    preHeight = currMaxHeight;
                    var node = new int[2] { loc, currMaxHeight };
                    ans.Add(node);
                }
            }
            

            return ans.ToArray();
            
        }

       
        private void removeFromMaxHeap(SortedDictionary<int, int> heap, int v)
        {
            heap[v]--;

            if (heap[v] == 0)
            {
                heap.Remove(v);
            }

        }
        private void insertToMaxHeap(SortedDictionary<int, int> heap, int v)
        {
            if (!heap.ContainsKey(v))
            {
                heap.Add(v, 0);
            }

            heap[v]++;
        }

        private void insertToHeap(SortedDictionary<int, List<int>> heap, int loc, int h)
        {
            if (!heap.ContainsKey(loc))
            {
                heap.Add(loc, new List<int>());
            }

            heap[loc].Add(h);
        }

        class MaxHeapComarer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
