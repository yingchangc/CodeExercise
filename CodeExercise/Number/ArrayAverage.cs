using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class ArrayAverage
    {
        public double ComputeAverage(long[] arr)
        {
            

            var len = arr.Length;

            // get quotiant
            double ans = 0;
            foreach (long value in arr)
            {
                //guarantee no overflow
                ans += (value / len);
            }
            //worst is max or min


            // get remainder
            long r = 0;
            int sign = 1;

            foreach (long value in arr)
            {
                r += (value % len);     // var test = -10 % 7;  note : reminder = -3
                sign = (r >= 0) ? 1 : -1;

                if (Math.Abs(r)>=len)
                {
                    if ((ans==long.MaxValue) && sign ==1)
                    {
                        return long.MaxValue;
                    }
                    else if ((ans == long.MinValue) && sign == -1)
                    {
                        return long.MinValue;
                    }

                    // if curr reminder sum >=len    q++
                    ans += (r/len);
                    r = r % len;
                }
            }

            ans += (1.0 * r / len);

            return ans;
        }
    }
}
