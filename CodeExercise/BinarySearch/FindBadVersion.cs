﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BinarySearch
{
    class FindBadVersion
    {
        /// <summary>
        ///74. First Bad Version
        /// https://www.lintcode.com/problem/first-bad-version/?_from=ladder
        /// You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.
        /// Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
        /// You are given an API bool isBadVersion(version) which will return whether version is bad.Implement a function to find the first bad version.You should minimize the number of calls to the API.
        /// </summary>
        /// 
        /// public int findFirstBadVersion(int n) {
        //  int start = 1, end = n;
        //  while (start + 1 < end) {
        //      int mid = start + (end - start) / 2;
        //      if (SVNRepo.isBadVersion(mid)) {
        //          end = mid;
        //      } else {
        //          start = mid;
        //      }
        //  }
        //      
        //  if (SVNRepo.isBadVersion(start)) {
        //      return start;
        //  }
        //  return end;

        /// 
        /// 
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;

            while (left + 1 < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }

            if (IsBadVersion(left))
            {
                return left;
            }
            else if (IsBadVersion(right))
            {
                return right;
            }
            return -1;
        }

        private bool IsBadVersion(int n)
        {
            return true;
        }
    }
}
