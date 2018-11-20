using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class LargestRectangleInHistogram
    {
        int globalMin = 0;
        /// <summary>
        /// 84
        /// https://leetcode.com/problems/largest-rectangle-in-histogram/solution/
        /// Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.
        /// 
        /// For example,
        /// Given heights = [2, 1, 5, 6, 2, 3],
        /// return 10.
        /// 
        /// sol:
        /// 
        ///  H  2  1  5  6  2  3
        /// idx 0  1  2  3  4  5 
        /// 
        /// only put increase height into stack
        /// 
        /// case1
        /// Incoming height is higher means currH can apply to future, (unknown for now), so don't compute and insert the incoming height.
        /// 
        /// case2 
        /// Incoming height is smaller means currH (nextH:2 vs currH:6)cannot be used for future, can compute height now, do the "pop" stk until currH is smaller than incoming H. (keep stk increase in height)
        /// When compute, use (nextLoc - (preLoc+1)) as width.  Note:  preLoc+1  because preLoc is smaller and cannot use
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleAreaPractice(int[] heights)
        {
            if (heights == null || heights.Length == 0)
            {
                return 0;
            }
            Stack<LocH> mono = new Stack<LocH>();

            mono.Push(new LocH(0, heights[0]));

            globalMin = heights[0];  // yic

            int maxArea = 0;



            for (int i = 1; i < heights.Length; i++)
            {
                if (mono.Peek().height <= heights[i])
                {
                    // increasing, keep add
                    mono.Push(new LocH(i, heights[i]));
                }
                else
                {
                    int temp = KeepMonoAndComputeArea(mono, i, heights[i]);
                    maxArea = Math.Max(temp, maxArea);
                    globalMin = Math.Min(globalMin, heights[i]);
                }
            }

            // add virtial end wall to pop mono stack
            int tempMaxArea = KeepMonoAndComputeArea(mono, heights.Length, -1);
            maxArea = Math.Max(tempMaxArea, maxArea);

            // still need to compute globalMin to all area speical case
            maxArea = Math.Max(maxArea, globalMin * heights.Length);

            return maxArea;
        }
        private int KeepMonoAndComputeArea(Stack<LocH> mono, int right, int rH)
        {
            int maxArea = 0;
            // keep mono and compute area
            while (mono.Count > 0 && mono.Peek().height > rH)
            {
                var curr = mono.Pop();
                int width;
                if (mono.Count == 0)
                {
                    width = right;   // already global min so far, 
                }
                else
                {
                    width = (right - mono.Peek().loc - 1);  // take  pre loc and next loc as width   ex  H 0   2  5 
                                                            //                                           L 0 1 2  3  
                }


                int currArea = curr.height * width;
                maxArea = Math.Max(maxArea, currArea);
            }

            // add new height in
            mono.Push(new LocH(right, rH));

            return maxArea;
        }

        public class LocH
        {
            public int loc;
            public int height;

            public LocH(int loc, int height)
            {
                this.loc = loc;
                this.height = height;
            }
        }

        public int LargestRectangleArea(int[] heights)
        {
            Stack<Item> monotomicStk = new Stack<Item>();
            
            int maxArea = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                if (monotomicStk.Count == 0)
                {
                    monotomicStk.Push(new Item(i, heights[i]));
                    continue;
                }

                var nextItem = new Item(i, heights[i]);
                maxArea = Math.Max(maxArea, EvauluateAreaAndInsert(monotomicStk, nextItem));
            }

            // 4 5 6 7 case
            maxArea = Math.Max(maxArea, EvaluteFinalAreaFromMonStack(monotomicStk, heights.Length-1));

            return maxArea;

        }

        public class Item
        {
            public int loc;
            public int height;

            public Item(int loc, int height)
            {
                this.loc = loc;
                this.height = height;
            }
        }
        private int EvaluteFinalAreaFromMonStack(Stack<Item> stk, int lastIdx)
        {
            int maxArea = 0;

            while(stk.Count > 0)
            {
                var curr = stk.Pop();

                if (stk.Count == 0)
                {                                                                
                    maxArea = Math.Max(maxArea, curr.height * (lastIdx+1));     // +1 to include last one
                }
                else
                {
                    maxArea = Math.Max(maxArea, curr.height * ((lastIdx+1) - (stk.Peek().loc + 1)));   // inlcude +1 itself   -  (preLoc+1)
                }
            }

            return maxArea;
        }


        private int EvauluateAreaAndInsert(Stack<Item> stk, Item nextItem)
        {
            int curMaxArea = 0;
            // 4 6, <-3      6 cannot use for future, so compute are now
            // 4 5, <-5'      5 can be use for future, just insert
            while(stk.Count > 0 && stk.Peek().height > nextItem.height)
            {
                var currItem = stk.Pop();

                if (stk.Count == 0)
                {
                    // global width case 0~nextLoc                                              4  2
                    curMaxArea = Math.Max(curMaxArea, currItem.height * nextItem.loc);    //idx 3  7      // nextItemLoc-1 height is guarantee greater or equal to currH
                }

                else
                {                                                                          // preH is small, +1 for next loc,  (+1 loc, guarantee to be ge to currH)  <- monotomic incr height
                    curMaxArea = Math.Max(curMaxArea, currItem.height * (nextItem.loc - (stk.Peek().loc + 1)));
                }
            }

            // now put nextItem to monotomic (increase height) stack
            stk.Push(nextItem);
            return curMaxArea;
        }
    }
}
