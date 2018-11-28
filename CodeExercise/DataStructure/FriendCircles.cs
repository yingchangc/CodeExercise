using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class FriendCircles
    {
        /// <summary>
        /// 547. Friend Circles
        /// https://leetcode.com/problems/friend-circles/description/
        /// There are N students in a class. Some of them are friends, while some are not. Their friendship is transitive in nature. For example, if A is a direct friend of B, and B is a direct friend of C, then A is an indirect friend of C. And we defined a friend circle is a group of students who are direct or indirect friends.
        /// 
        /// Given a N* N matrix M representing the friend relationship between students in the class. If M[i][j] = 1, then the ith and jth students are direct friends with each other, otherwise not.And you have to output the total number of friend circles among all the students.
        /// 
        /// Example 1:
        /// Input: 
        /// [[1,1,0],
        ///  [1,1,0],
        ///  [0,0,1]]
        /// Output: 2
        /// Explanation:The 0th and 1st students are direct friends, so they are in a friend circle.
        /// The 2nd student himself is in a friend circle.So return 2.
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public int FindCircleNum(int[,] M)
        {
            int size = M.GetLength(0);
            var uf = new UnionFind(size);

            for (int j = 0; j < size; j++)
            {
                for (int i = j + 1; i < size; i++)
                {
                    if (M[j, i] == 1)
                    {
                        uf.Union(j, i);
                    }
                }
            }

            return uf.GetUniqueSize();

        }

        public class UnionFind
        {
            int[] ufarray;
            int count;

            public UnionFind(int size)
            {
                ufarray = new int[size];
                count = size;

                for (int i = 0; i < size; i++)
                {
                    ufarray[i] = i;
                }
            }

            public int Find(int i)
            {
                int parent = ufarray[i];

                if (parent != i)
                {
                    int ancestor = Find(ufarray[i]);

                    ufarray[i] = ancestor;
                }

                return ufarray[i];
            }

            public void Union(int a, int b)
            {
                int pA = Find(a);
                int pB = Find(b);

                if (pA != pB)
                {
                    ufarray[pB] = pA;

                    count--;
                }
            }

            public int GetUniqueSize()
            {
                return count;
            }

        }
    }
}
