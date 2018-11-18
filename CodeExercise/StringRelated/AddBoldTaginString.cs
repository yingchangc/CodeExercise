using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.StringRelated
{
    class AddBoldTaginString
    {
        public class Interval
        {
            //string word;
            public int left;
            public int right;
            public Interval(int left, int right)
            {

                this.left = left;
                this.right = right;
            }
        }

        /// <summary>
        /// 616. Add Bold Tag in String
        /// https://leetcode.com/problems/add-bold-tag-in-string/description/
        /// Given a string s and a list of strings dict, you need to add a closed pair of bold tag <b> and </b> to wrap the substrings in s that exist in dict. If two such substrings overlap, you need to wrap them together by only one pair of closed bold tag. Also, if two substrings wrapped by bold tags are consecutive, you need to combine them.
        /// Example 1:
        /// Input: 
        /// s = "abcxyz123"
        /// dict = ["abc","123"]
        ///         Output:
        /// "<b>abc</b>xyz<b>123</b>"
        /// Example 2:
        /// Input: 
        /// s = "aaabbcc"
        /// dict = ["aaa","aab","bc"]
        ///         Output:
        /// "<b>aaabbc</b>c"
        /// 
        /// Note:related to "MergeIntervals"
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public string AddBoldTag(string s, string[] dict)
        {

            List<Interval> sortedList = new List<Interval>();

            foreach (string word in dict)
            {
                int index = 0;

                while((index = s.IndexOf(word, index)) != -1)
                {
                    sortedList.Add(new Interval(index, index + word.Length - 1));
                    index = index+1;  //yic   S:aaaa   word: "aa"   
                }
            }

            sortedList.Sort((x, y) => x.left.CompareTo(y.left));

            if (sortedList.Count == 0)
            {
                return s;
            }

            List<Interval> mergedList = new List<Interval>();

            foreach(Interval item  in sortedList)
            {
                if (mergedList.Count == 0)
                {
                    mergedList.Add(item);
                }
                else
                {
                    var last = mergedList[mergedList.Count - 1];
                    if ((last.right + 1) < item.left)
                    {
                        mergedList.Add(item);
                    }
                    else
                    {
                        last.right = Math.Max(last.right, item.right);
                    }
                }
            }

            int start = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mergedList.Count; i++)
            {
                var temp = mergedList[i];

                var prefix = s.Substring(start, temp.left - start);  // check if there is pre fix  ex   zzz "abc"
                var substr = s.Substring(temp.left, temp.right - temp.left + 1);
                sb.Append(prefix + "<b>" + substr + "</b>");
                start = temp.right + 1;
            }


            // tail case
            if (start + 1 <= s.Length)
            {
                var substr = s.Substring(start, s.Length - start);
                sb.Append(substr);
            }

            return sb.ToString();

        }
    }
}
