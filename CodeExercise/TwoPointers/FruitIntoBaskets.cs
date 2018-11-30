using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.TwoPointers
{
    class FruitIntoBaskets
    {
        public int TotalFruit(int[] tree)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();

            int len = tree.Length;
            int ans = 0;
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                while (j < len && lookup.Keys.Count <= 2)
                {
                    var fruitT = tree[j];
                    if (!lookup.ContainsKey(fruitT))
                    {
                        lookup.Add(fruitT, 0);
                    }
                    lookup[fruitT]++;

                    if (lookup.Keys.Count <= 2)
                    {
                        // yic update ans here.
                        ans = Math.Max(ans, ComputeFruitCount(lookup));
                    }
                    j++;
                }

                // ready to move i forward; 
                // yic  just remove 1 fruit    not whole type,  can 1 0 1 1 '2' 1 1  when 2 comes in, we jsut want to remove first 1, not all 1s
                var fruitType = tree[i];
                var fruitT_Left = (--lookup[fruitType]);

                if (fruitT_Left == 0)
                {
                    lookup.Remove(fruitType);
                }

            }

            return ans;
        }

        private int ComputeFruitCount(Dictionary<int, int> lookup)
        {
            int num = 0;

            foreach (var count in lookup.Values)
            {
                num += count;
            }

            return num;
        }
    }
}
