using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class CompareVersionNumbers
    {
        /// <summary>
        /// 165. Compare Version Numbers
        /// https://leetcode.com/problems/compare-version-numbers/
        /// Compare two version numbers version1 and version2.
        /// If version1 > version2 return 1; if version1<version2 return -1;otherwise return 0.
        /// 
        /// You may assume that the version strings are non-empty and contain only digits and the.character.
        /// The.character does not represent a decimal point and is used to separate number sequences.
        /// For instance, 2.5 is not "two and a half" or "half way to version three", it is the fifth second-level revision of the second first-level revision.
        /// 
        /// Example 1:
        /// 
        /// Input: version1 = "0.1", version2 = "1.1"
        /// Output: -1
        /// Example 2:
        /// 
        /// 
        /// Input: version1 = "1.0.1", version2 = "1"
        /// Output: 1
        /// Example 3:
        /// 
        /// 
        /// Input: version1 = "7.5.2.4", version2 = "7.5.3"
        /// Output: -1
        /// 
        /// YIC :  1.0   vs  1  returns 0
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public int CompareVersion(string version1, string version2)
        {
            var tokens1 = version1.Split('.');
            var tokens2 = version2.Split('.');

            int len1 = tokens1.Length;
            int len2 = tokens2.Length;
            int len = Math.Max(len1, len2);
            for (int i = 0; i < len; i++)
            {
                int v1 = i >= len1 ? 0 : int.Parse(tokens1[i]);
                int v2 = i >= len2 ? 0 : int.Parse(tokens2[i]);

                if (v1 != v2)
                {
                    return v1 > v2 ? 1 : -1;
                }
            }
            return 0;

        }
    }
}
