using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class IntervalSearch
    {
        /// <summary>
        /// https://www.lintcode.com/problem/interval-search/description?_from=ladder&&fromId=62
        /// 
        /// 1564. Interval Search
        /// Given a List of intervals, the length of each interval is 1000, such as [500,1500], [2100,3100].Give a number arbitrarily and determine if the number belongs to any of the intervals.return True or False.
        /// 
        /// Example
        /// Given:
        /// 
        /// 
        /// List = [[100, 1100], [1000,2000], [5500,6500]]
        /// number = 6000
        /// </summary>
        /// <param name="intervalList"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsInterval(List<List<int>> intervalList, int number)
        {
            int rowCandidate = RowIndexFinder(intervalList, number);

            return intervalList[rowCandidate][0] <= number && number <= intervalList[rowCandidate][1];
        }

        private int RowIndexFinder(List<List<int>> intervalList, int target)
        {
            int height = intervalList.Count;
            int left = 0;
            int right = height-1;

            while(left + 1 < right)
            {
                int midIdx = (left + (right - left) / 2);
                int midV = intervalList[midIdx][0];

                if (target == midV)
                {
                    return midIdx;
                }
                else if (target > midV)
                {
                    left = midIdx;
                }
                else
                {
                    right = midIdx;
                }
            }

            // two item left
            if (target >= intervalList[right][0])
            {
                return right;
            }
            return left;
        }
    }
}
