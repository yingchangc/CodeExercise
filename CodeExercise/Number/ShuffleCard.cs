using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Number
{
    class ShuffleCard
    {
        private static Random rdm = new Random();
        public void Shuffle<T>(T[] array)
        {
            int len = array.Length;

            for (int i = 0; i < len;i++)
            {
                int j = rdm.Next(len - i) + i;  // Next(len)   --> 0~len-1 
                swap(array, i, j);
            }
          
        }

        private void swap<T>(T[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

    }
}
