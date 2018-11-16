using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Probability
{
    class ReservoirSampling
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/reservoir-sampling/
        /// https://www.jiuzhang.com/tutorial/big-data-interview-questions/220
        /// 等概率的挑选Google搜索记录日志中的一百万条中文搜索记录
        /// 
        /// 我们用 5 条 Queries 里挑 3 条来作为例子证明每条 Query 被挑中的概率都是 3/5。
        /// 
        /// 依次处理每条 Query，前 3 条 Queries 直接进入 Buffer => [1, 2, 3]，此时前 3 条 Queries 被选中的概率 100%
        /// 第 4 条 Query 处理时，有 3/4 的概率被留下，那么第 4 条 Query 被选中的概率此时就是 3/4。
        /// 第 4 条 Query 处理时，如果留下之后，会从 Buffer 中以 1/3 的概率踢走一条 Query。那么这些在 Buffer 中留下的概率是`1/4 + 2/3 * 3/4 = 3/4)。其中 1/4 是第 4 条 Query 没有被选中的概率。
        /// 综上在处理到第 4 条 Query 的时候，所有 Query 被选中的概率均为 3/4。
        /// 第 5 条 Query 处理时，有 3/5 的概率被留下，那么第 5 条 Query 被选中的概率此时就是 3/4。
        /// 第 5 条 Query 处理时，如果留下之后，会从 Buffer 中以 1/3 的概率踢走一条 Query。前4条Query能够顺利进入Buffer并被留下的概率是：3/4 * (2/5 + 2/3 * 3/5) = 3/5。其中 2/5 是第 5 条 Query 没有被选中的概率。3/4 是前3条 Queries 在处理完第4条 Query 之后，进入 Buffer的概率，2/3 * 3/5 第5条Query被选中之后但是没有踢走自己的概率。
        /// </summary>
        /// 
        /// goal:  every time new stream inserted.  I want  to have k/total  probability to keep
        /// 
        /// k = 3
        // if n <=3  all kept  probability is 1 
        /// 
        /// (1) 4th   to keep it  we use     3/4 rate
        ///    
        //     1             * (  1/4      * 1             +        3/4      *  2/3  )     =  3/4           <=    3 out of 4 in buffer
        ///   preProbability       no keep    3items                keep 4th     2/3 buffer items can stay
        ///  for seq insert                  in buffer all kept
        /// 
        /// (2) 5th    to keep it,  we use 3/5 rate
        /// 
        //    3/4          * (2/5 * 1    +   3/5 * 2/3) =   3/5                          <=  3 out of 5 in buffer
        /// preProbability
        /// <param name="stream"></param>
        /// <param name="k"></param>
        private int[] buffer;

        public void SelectKItems(int[] stream, int k)
        {
            buffer = new int[k];

            // take all in to buffer size of k
            for (int i = 0; i < stream.Length && i < k; i++)
            {
                buffer[i] = stream[i];
            }

            // probability is 1
            if (k >= stream.Length)
            {
                return;
            }

            Random rd = new Random();

            // want k/total probability when consider each new item

            for (int i = k; i < stream.Length; i++)
            {
                // random pick index from 0~i
                int index = rd.Next(i+1);

                if (index < k)
                {
                    // k/total probability  if to replace existing in buffer
                    buffer[index] = stream[i];
                }
            }

        }
    }
}
