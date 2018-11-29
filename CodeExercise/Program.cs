using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeExercise
{
    class Program
    {
        static void Run_KMP_Question()
        {
            // demo case
            int[] refArray = KMPSubstringSearch.ComputeMemorizationArray("aabaabaaa");
            Console.WriteLine(string.Join(",", refArray));

            // match text  a b x a b c a b c a b y
            // with pattern            a b c a b y
            bool isMathc = KMPSubstringSearch.KMP_IsMatch("abcaby", "abxabcabcaby");
        }


        /// <summary>
        ///       _______3______
        ///      /              \
        ///   ___5__          ___1__
        ///  /      \        /      \
        ///  6      _2       0       8
        ///        /  \
        ///        7   4
        /// </summary>
        static void Run_LowestCommonAncestorINBTree()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(5);
            root.left.left = new TreeNode(6);
            root.left.right = new TreeNode(2);
            root.left.right.left = new TreeNode(7);
            root.left.right.right = new TreeNode(4);

            root.right = new TreeNode(1);
            root.right.left = new TreeNode(0);
            root.right.right = new TreeNode(8);

            TreeNode p6 = new TreeNode(6);
            TreeNode q0 = new TreeNode(0);
            TreeNode ans1 = CodeExercise.Tree.LowestCommonAncestor.FindCommonAncestor(root, p6, q0);

            TreeNode p5 = new TreeNode(5);
            TreeNode q7 = new TreeNode(7);
            TreeNode ans2 = CodeExercise.Tree.LowestCommonAncestor.FindCommonAncestor(root, p5, q7);

        }

        static void Run_EditDistanceQuestion()
        {
            bool isOneEditDistance = EditDistance.IsOneEditDistance("marts", "mart");
            isOneEditDistance = EditDistance.IsOneEditDistance("mart", "marts");
            isOneEditDistance = EditDistance.IsOneEditDistance("mart", "mark");
            isOneEditDistance = EditDistance.IsOneEditDistance("cb", "ab");

            string s1 = "abcfg";
            string s2 = "adceg";
            int[,] resArray = EditDistance.ConstructMemorizationMatrix(s1, s2);

            int distance = resArray[s1.Length, s2.Length];
            Console.WriteLine();

            // demo all
            String str1 = "azced";
            String str2 = "abcdef";
            EditDistance.FindDistanceAndPrint(str1, str2);
        }

        //14
        static void Run_LongestCommonPrefix()
        {
            string[] strs = { "aa", "a"};

            DataStructure.LongestCommonPrefix question = new DataStructure.LongestCommonPrefix();
            var ans = question.LongestCommonPrefixSolver(strs);

        }

        //97
        static void Run_InterleavingString()
        {
            DP.InterleavingString question = new DP.InterleavingString();
            string s1 = "aabcc";
            string s2 = "dbbca";
            string s3 = "aadbbcbcac"; // return true.
            string s4 = "aadbbbaccc"; //return false.
            var ans = question.IsInterleave(s1, s2, s3);
            ans = question.IsInterleave(s1, s2, s4);
            
        }

        static void Run_LongestCommonSubsequence()
        {
            DP.LongestCommonSubsequence question = new DP.LongestCommonSubsequence();

            string A = "ABCD";
            string B = "EACB";
            int ans = question.longestCommonSubsequenceSolver(A, B);
        }

        //46
        static void Run_permuteIntArray()
        {
            int testlengh = 4;
            int[] arr = new int[testlengh];
            for (int i = 0; i < testlengh; i++)
            {
                arr[i] = i + 1;
            }

            IList<IList<int>> permutation = PermutationIntArray.Permute(arr);

            foreach (var intList in permutation)
            {
                Console.WriteLine(string.Join(",", intList));
            }
        }

        //216
        static void Run_CombinationSum3()
        {
            var answers = CombineSum.CombinationSum3(3, 9);
        }

        // 377
        static void Run_CombinationSum4()
        {
            int[] candidates = { 1, 2, 3 };
            int ans = CombineSum.CombinationSum4(candidates, 4);

            //optional
            int[] candidates2 = { 1, 2, 5 };
            ans = CombineSum.CombinationSum4_1NoDupCombination(candidates2, 12);
        }

        // 39
        static void Run_CombinationSumAllowDuplicate()
        {
            int[] candidates = { 2, 7, 3, 6 };
            CombineSum.CombinationSumAllowDuplicate(candidates, 7);
        }

        // 40
        static void Run_CombinationSumNoDuplicate()
        {
            int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };
            CombineSum.CombinationSum2(candidates, 8);
        }

        //78. Subsets 
        static void Run_SubSets()
        {
            int[] candidates = { 1, 2, 3 };
            var ans = SubSets.FindSubsets(candidates);
        }

        //79. Subsets with dup element
        static void Run_SubSetsWithDup()
        {
            //int[] candidates = { 1, 2, 2 };
            int[] candidates = { 4, 4, 1, 4 };
            SubSets.SubsetsWithDup(candidates);
        }

        // 47. 
        static void Run_PermuteUnique()
        {
            int[] nums = {0,1,0};
            IList<IList<int>> results = PermutationIntArray.PermuteUnique(nums);

            foreach (var intList in results)
            {
                Console.WriteLine(string.Join(",", intList));
            }
        }

        //267
        static void Run_PalindromePermutation()
        {
            string test1 = "careac";
            bool canPermute = PalindromePermutation.CanPalidromePermute(test1);
            string test2 = "aaabbcccc";
            canPermute = PalindromePermutation.CanPalidromePermute(test2);
        }

        //131. Palindrome Partitioning 
        static void Run_Palindrome_Partitioning()
        {
            string test1 = "cbbbcc";
            IList<IList<string>> results = DP.PalindromePartition.Partition(test1);
            foreach (var result in results)
            {
                Console.WriteLine(string.Join(",", result));
            }
        }

        // 409. Longest Palindrome 
        static void Run_Longest_Palindrome()
        {
            string test = "civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth";
            int ans = DP.LongestPalindrome.LongestPalindromeSize(test);
        }

        // 132. PalindromePartitioning min cut
        static void Run_Palindrome_Partitioning_II()
        {
            string test = "aab";

            int res = DP.PalindromePartition.MinCutPractice(test);
        }

        // 55. Jump Game
        static void Run_JumpGame()
        {
            int[] nums1 = { 2, 3, 1, 1, 4 };
            bool canjump = DP.JumpGame.CanJump(nums1);

            int[] nums2 = { 3, 2, 1, 0, 4 };
            canjump = DP.JumpGame.CanJump(nums2);

            canjump = DP.JumpGame.canJumpDP(nums1);
            canjump = DP.JumpGame.canJumpDP(nums2);
        }

        // 45. min Jump Game
        static void Run_MinJumpGame()
        {
            int[] nums1 = { 2, 3, 1, 1, 4 };
            int minjump = DP.JumpGame.Jump(nums1);


        }
        // 455.assign cookies
        static void Run_AssignCookies()
        {
            int[] children = { 1, 2, 3 };
            int[] cookies = { 1, 2, 2 };
            int contentChildren = DP.AssignCookies.FindContentChildren(children, cookies);
        }

        // 438. Find All Anagrams in a String 
        static void Run_AnagramSubstring()
        {
            string s = "cbaebabacd";
            string p = "abc";

            IList<int> res = DP.AnagramSubstring.FindAnagrams(s, p);

        }

        // 3.
        static void Run_LongestSubstringWithoutRepeatingCharacters()
        {
            var test = new DP.LongestSubstringWithoutRepeatingCharacters();
            int maxLength = test.LengthOfLongestSubstring("abc");

            maxLength = test.LengthOfLongestSubstring("tmmzuxt");

        }

        // 159
        static void Run_lengthOfLongestSubstringTwoDistinct()
        {
            var test = new DP.SubStringRelated();
            int maxlength = test.lengthOfLongestSubstringTwoDistinct("eceba");
        }

        // 76
        static void Run_Minimum_Window_Substring()
        {
            var test = new DP.SubStringRelated();
            string minSubstring = test.MinWindow("ADOBECODEBANC", "ABC");    //ans : BANC

        }

        // 79
        static void Run_WordSearch()
        {
            char[,] board = { {'A','B','C','E'},
                              {'S','F','C','S'},
                              {'A','D','E','E' }
                };

            matrixQuestion.WordSearch question = new matrixQuestion.WordSearch();
            bool isExist = question.Exist(board, "ABCCED");

            matrixQuestion.WordSearch2 question2 = new matrixQuestion.WordSearch2();

            char[,] board2 = {  {'o','a','a','n'},
                                {'e','t','a','e'},
                                {'i','h','k','r' },
                                { 'i','f','l','v' }  };

            string[] words = { "oath", "pea", "eat", "rain" };
            var ans = question2.FindWords(board2, words);

        }

        //49 
        static void Run_GroupAnagrams()
        {
            string[] input = { "eat", "tea", "tan", "ate", "nat", "bat" };
            DP.GroupAnagrams question = new DP.GroupAnagrams();
            var result = question.FindAnagrams(input);

        }

        // 139&140
        static void Run_WordBreak()
        {
            //139
            DP.WordBreak question = new DP.WordBreak();
            string test = "catsanddog";
            string[] worddict = { "cat", "cats", "and", "sand", "dog" };
            bool canBreak = question.CheckWordBreak(test, worddict);


            // pre test code
            string subleft = test.Substring(0, 0);
            string subRight = test.Substring(test.Length);  // Note will be empty string


            var ans2_1 = question.CheckWordBreakv2(test, worddict);
            string test2 = "aaaaaaa";
            string[] worddict2 = { "aaaa", "aa", "a" };

            //140
            var ans2_2 = question.CheckWordBreakv2(test2, worddict2);
        }

        //121, 151, 309, 188 
        static void Run_BestTimeBuySellStock()
        {
            //121
            int[] test = { 7, 1, 5, 3, 6, 4 };

            DP.BestTimeBuySellStock question = new DP.BestTimeBuySellStock();
            int profit = question.MaxProfit(test);

            // diff (price(I) = price(I-1)) from test
            int[] diff = { 0, -6, 4, -2, 3, -2 };
            profit = question.MaxProfitFromDiff(diff);


            //151
            int[] prices151 = { 4, 4, 6, 1, 1, 4, 2, 5 };
            profit = question.MaxProfit3(prices151);

            //188
            int[] prices188 = { 2, 1, 2, 0, 1 };
            profit = question.MaxProfit4(2, prices188);

            // 309
            int[] prices = { 2, 6, 8, 7, 8, 7, 9, 4, 1, 2, 4, 5, 8 };
            profit = question.MaxProfitWithCooldown(prices);
            profit = question.MaxProfit5(prices);

            //714
            int[] prices714 = { 1, 3, 2, 8, 4, 9 };
            profit = question.MaxProfit6WithFee(prices714, 2);
        }

        //746, 70
        static void Run_MinCostClimbingStairs()
        {
            // 746
            int[] cost = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
            DP.MinCostClimbingStairs question = new DP.MinCostClimbingStairs();
            int ans = question.MinCostClimbingStairsSolver(cost);

            // 70
            ans = question.ClimbStairs(6);
        }

        //169
        static void Run_MajorityElement()
        {
            int[] nums = { 1, 4, 5, 7, 1, 3, 1, 3, 3, 1, 1, 1, 1 };
            //int[] nums = { 1,1,1,3,3 };
            DP.MajorityElement question = new DP.MajorityElement();
            int majornum = question.MajorityElementSolver(nums);
        }

        // 198 & 740
        static void Run_HouseRobber_DeleteAndEarn()
        {
            DP.HouseRobber_DeleteAndEarn question = new DP.HouseRobber_DeleteAndEarn();



            // 198 rob
            //int[] nums1 = { 2, 3, 7, 8, 4 };
            int[] nums1 = { 3, 8, 4 };
            int ans1 = question.Rob(nums1);   // should be rob 2 +7 +4

            //213 rob2
            int ans213 = question.Rob2(nums1);

            // 740 Delete and Earn
            int[] nums2 = { 2, 2, 2, 2, 4, 4, 4, 5, 5, 1 };   // should be [1(1), 2(8), 4(12), 5(10)] -> 8 + 12
            int ans2 = question.DeleteAndEarn(nums2);
        }

        //64
        static void Run_MinimumPathSum()
        {
            int[,] grid = { {1,3,1},
                            {1,5,1},
                            {4,2,1 } };

            DP.MinimumPathSum question = new DP.MinimumPathSum();
            int ans = question.MinPathSumSolver(grid);
        }

        // 674
        static void Run_LongestContinuousIncreasingSubsequence()
        {
            int[] nums = { 1, 3, 5, 4, 7 };

            //398 Lint
            int[,] matrix = {
                              {1, 2, 3, 4, 5 },
                              {16, 17, 24, 23, 6 },
                              {15, 18, 25, 22, 7 },
                              {14, 19, 20, 21, 8 },
                              { 13, 12, 11, 10, 9 }
                            };

            int[,] matrix2 = {
                              {1, 5,  3 },
                              {4, 10, 9 },
                              {2, 8,  7 }
                            };

            DP.LongestIncreasingContinuousSubsequence2 question2 = new DP.LongestIncreasingContinuousSubsequence2();
            var ans398 = question2.LongestIncreasingContinuousSubsequenceIISolver(matrix2);

            var ans398_2 = question2.LongestIncreasingContinuousSubsequenceIIPractice_slow(matrix2);

            //674
            DP.LongestContinuousIncreasingSubsequence question = new DP.LongestContinuousIncreasingSubsequence();
            int ans = question.FindLengthOfLCIS(nums);

            // 673
            int[] num2 = { 1, 2, 4, 3, 5, 4, 7, 2 };
            //int[] num2 = {3,4,-1,0,6,2,3 };
            DP.LongestIncreasingSubsequence q2 = new DP.LongestIncreasingSubsequence();
            int ans2 = q2.FindNumberOfLIS(num2);

            // 300   should be 5 [1 2 3 3 4 4 5]
            int ans3 = q2.LengthOfLIS(num2);

            ans3 = q2.LengthOfLIS_ONlongN(num2);
            int[] num22 = { 2, 2 };
            ans3 = q2.LengthOfLIS_ONlongN(num22);

            //128
            DP.LongestConsecutiveSequence q3 = new DP.LongestConsecutiveSequence();
            int[] nums3 = { 100, 4, 200, 1, 3, 2 };
            int ans4 = q3.LongestConsecutiveSolver(nums3);
        }

        //153
        static void Run_FindMinimumInRotatedSortedArray()
        {
            DP.FindMinimumInRotatedSortedArray question = new DP.FindMinimumInRotatedSortedArray();
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int ans = question.FindMin(nums);


            int[] nums2 = { 10, 1, 10, 10, 10 };
            int ans2 = question.FindMinWithDupInArray(nums2);
        }

        //322
        static void Run_CointChange()
        {
            int[] nums = { 1, 2, 5 };
            DP.CoinChange question = new DP.CoinChange();
            int ans = question.CoinChangeSolverSlow(nums, 11);


            // 
            int[] denoms = { 25, 10, 5, 1 };
            int ansDenoms = question.NumberCoinChange(25, denoms);


            // #coin change 1
            ans = question.MinCoinChangeSolver(nums, 11);
            //int[] nums2 = { 3, 7, 405, 436};
            //ans = question.CoinChangeSolverSlow(nums2, 8839);
            //ans = question.MinCoinChangeSolver(nums2, 8839);

            ans = question.coinChange(nums, 11);

            int[] numsWrong = { 2 };
            ans = question.coinChange(numsWrong, 3);
            // #Coins in a line and can choose left for right most

            int[] nums2 = { 1, 2, 3 };
            ans = question.CoinsInALine(nums2);

            // Coin change 2
            ans = question.CoinChange2(5, nums);


            
        }

        //361
        static void Run_BombEnemy()
        {
            DP.BonbEnemy question = new DP.BonbEnemy();

            char[,] grid = { { '0' ,'E', '0', '0' },
                             { 'E' ,'0', 'W', 'E' },
                             { '0' ,'E', '0', '0' }};

            var ans = question.MaxKilledEnemies(grid);

            char[,] grid2 = { { 'E' }, { 'E' }, { 'E' } };
            ans = question.MaxKilledEnemies(grid2);
        }

        //494
        static void Run_TargetSum()
        {
            int[] nums = { 1, 1, 1, 1, 1 };
            var question = new DP.TargetSum();
            int ans = question.FindTargetSumWays(nums, 3);
        }

        //737 
        static void Run_Sentence_Similarity()
        {
            string[] words1 = { "great", "acting", "skills", "yic", "talent" };
            string[] words2 = { "fine", "drama", "smart", "yic", "talent" };
            List<Tuple<string, string>> paris = new List<Tuple<string, string>>();
            paris.Add(Tuple.Create("great", "fine"));
            paris.Add(Tuple.Create("acting", "drama"));
            paris.Add(Tuple.Create("skills", "talent"));
            paris.Add(Tuple.Create("talent", "smart"));

            DV.Sentence_Similarity quesiton = new DV.Sentence_Similarity();
            bool ans = quesiton.AreSentencesSimilarTwo(words1, words2, paris);
        }

        //338
        static void Run_CountingBits()
        {
            DP.CountingBits question = new DP.CountingBits();
            var ans = question.CountBitsSolver(5);
        }

        // 91
        static void Run_DecodeWays()
        {
            string EncodeStr = "12";
            DP.DecodeWays question = new DP.DecodeWays();
            int ans = question.NumDecodings(EncodeStr);

            // there are 5 ways
            ans = question.NumDecodings("1227");

            ans = question.NumDecodings("102213");
        }

        //747
        static void Run_LargestNumberAtLeastTwiceOthers()
        {
            int[] nums = { 3, 6, 1, 0 };
            Number.LargestNumberAtLeastTwiceOthers question = new Number.LargestNumberAtLeastTwiceOthers();
            int ans = question.DominantIndex(nums);

            int[] nums2 = { 1, 2, 3, 4 };  // no ans
            ans = question.DominantIndex(nums2);

            int[] nums3 = { 7, 6, 5, 4 };  // no ans
            ans = question.DominantIndex(nums3);
        }

        // 724
        static void Run_FindPivotIndex()
        {
            int[] nums1 = { 1, 7, 3, 6, 5, 6 };
            Number.FindPivotIndex question = new Number.FindPivotIndex();
            int ans = question.PivotIndexHelper(nums1);

            int[] nums2 = { 1, 2, 3, 4 };
            ans = question.PivotIndexHelper(nums2);
        }

        //35
        static void Run_SearchInsertPosition()
        {
            int[] nums = { 1, 3, 5, 6 };

            BinarySearch.SearchInsertPosition question = new BinarySearch.SearchInsertPosition();
            int ans = question.SearchInsert(nums, 5);
            ans = question.SearchInsert(nums, 2);
            ans = question.SearchInsert(nums, 7);
            ans = question.SearchInsert(nums, 0);
        }

        //62, 63
        static void Run_UniquePaths()
        {
            //62
            DP.UniquePath question = new DP.UniquePath();
            int ans = question.NumofUniquePaths(2, 2);

            int[,] grid = { {0,0,0},
                            {0,1,0},
                            {0,0,0 } };

            //63
            ans = question.UniquePathsWithObstacles(grid);

            int[,] grid2 = { { 1 } };
            ans = question.UniquePathsWithObstacles(grid2);
        }

        // 53
        static void Run_MaxSumSubarray()
        {
            int[] nums2 = { -2, 2, -3, 4, -1, 2, 1, -5, 3 };
            DP.MaximumSubarray question3 = new DP.MaximumSubarray();
            var ans4=question3.MinSubarray(nums2);

            DP.MaximumSubarray question2 = new DP.MaximumSubarray();
            var ans3 = question2.MaxSubarray4(nums2, 2);


            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            DP.MaximumSubarray question = new DP.MaximumSubarray();
            int ans2 = question.MaxSubArrayPractice(nums);
            int ans = question.MaxSubArraySolver(nums);
  
        }

        //152
        static void Run_MaxProductArray()
        {
            int[] nums = { 2, 3, -2, 4 };
            DP.MaxProductArray question = new DP.MaxProductArray();
            int ans = question.MaxProduct(nums);

            ans = question.maxProductNoMemo(nums);
        }


        //209
        static void Run_MinSuzeSubArraySum()
        {
            int[] nums = { 2, 3, 1, 2, 4, 3 };
            Window.MinimumSizeSubarraySum question = new Window.MinimumSizeSubarraySum();
            int ans = question.MinSubArrayLen(7, nums);

        }

        //378   lintcode 465
        static void Run_KthSmallestElementInMatrix()
        {
            DataStructure.KthSmallestElementInMatrix question = new DataStructure.KthSmallestElementInMatrix();

            int[,] matrix = {
                 { 1,  5,  9 },
                 { 10, 11, 13 },
                 { 12, 13, 15 }
            };


            var ans = question.KthSmallest(matrix, 2);

            int[] arrA = { 1, 3, 5 };
            int[] arrB = { 2, 4, 6 };
            ans = question.kthSmallestSumPQ(arrA, arrB, 3);
            ans = question.kthSmallestSumPQ(arrA, arrB, 4);
            ans = question.kthSmallestSumPQ(arrA, arrB, 8);
        }

        //340
        static void Run_LongestSubstringAtMostKDistinctChar()
        {
            DP.LongestSubstringAtMostKDistinctChar question = new DP.LongestSubstringAtMostKDistinctChar();
            int ans = question.LengthOfLongestSubstringKDistinct("eceba", 3);
        }

        //200
        static void Run_NumberOfIsland()
        {
            char[,] grid = {
                 { '1', '1',  '0' },
                 { '0',  '0',  '1' }
            };

            int m = grid.GetLength(0);
            int n = grid.GetLength(1);

            DataStructure.NumberOfIsland question = new DataStructure.NumberOfIsland();
            int ans = question.NumIslandsBFS(grid);
            ans = question.NumIslandsUF(grid);

            char[,] grid2 = {
                 { '1', '1',  '0' },
                 { '1',  '1',  '1' }
            };

            ans = question.NumIslandsUF(grid2);
        }

        //347
        static void Run_TopKFrequent()
        {
            DataStructure.TopKFreqWords question = new DataStructure.TopKFreqWords();
            int[] nums = { 1,2 };
            var ans = question.TopKFrequent(nums, 2);
        }

        //lintcode 434   leetcode 305
        static void Run_NumberOfIsland2()
        {
            // Given n = 3, m = 3, array of pair A = [(0, 0),(0,1),(2,2),(2,1)].
            //return [1, 1, 2, 2].
            var paris = new List<DataStructure.Point> { new DataStructure.Point(0, 0),
                                                        new DataStructure.Point(0, 1),
                                                        new DataStructure.Point(2, 2),
                                                        new DataStructure.Point(2, 1)};
            DataStructure.NumberOfIsland2 question = new DataStructure.NumberOfIsland2();
            var ans = question.NumIslands2(3, 3, paris.ToArray());


            var paris2 = new List<DataStructure.Point> { new DataStructure.Point(1, 1),
                                                        new DataStructure.Point(0, 1),
                                                        new DataStructure.Point(3, 3),
                                                        new DataStructure.Point(3, 4)};
            //4
            //5
            //[[1, 1],[0,1],[3,3],[3,4]]
            //Expected
            //[1, 1, 2, 2]
            ans = question.NumIslands2(5, 4, paris2.ToArray());



            int[,] positions = { { 0, 0 }, { 0, 1 }, { 1, 2 }, { 2, 1 } };

            //[[0, 0], [0, 1], [1, 2], [2, 1]].
            var ans2 = question.NumIslands2LeetCode(3, 3, positions);

        }

        //lint code 589
        static void Run_ConnectingGraph()
        {
            ///5 // n = 5
            ///query(1, 2) return false
            ///connect(1, 2)
            ///query(1, 3) return false
            ///connect(2, 4)
            ///query(1, 4) return true
            int n = 5;
            DataStructure.ConnectingGraph cg = new DataStructure.ConnectingGraph(n);
            bool ans = cg.query(1, 2);
            cg.connect(1, 2);
            ans = cg.query(1, 3);
            cg.connect(2, 4);
            ans = cg.query(1, 4);

        }

        // lint code 442
        static void Run_Trie()
        {
            DataStructure.Trie trie = new DataStructure.Trie();
            trie.insert("lintcode");
            var ans = trie.search("code");
            ans = trie.startsWith("lint");
            ans = trie.startsWith("linterror");
            trie.insert("linterror");
            ans = trie.search("lintcod");
            ans = trie.startsWith("linterror");
        }

        //lint code 590
        static void Run_ConnectingGraph2()
        {
            /// 5 // n = 5
            /// query(1) return 1
            /// connect(1, 2)
            /// query(1) return 2
            /// connect(2, 4)
            /// query(1) return 3
            /// connect(1, 4)
            /// query(1) return 3
            int n = 5;
            DataStructure.ConnectingGraph2 cg = new DataStructure.ConnectingGraph2(n);
            int ans = cg.query(1);
            cg.connect(1, 2);
            ans = cg.query(2);
            cg.connect(2, 4);
            ans = cg.query(1);
            cg.connect(1, 4);
            ans = cg.query(1);
        }

        //lint code 591
        static void Run_ConnectingGraph3()
        {
            ///5 // n = 5
            ///query() return 5
            ///connect(1, 2)
            ///query() return 4
            ///connect(2, 4)
            ///query() return 3
            ///connect(1, 4)
            ///query() return 3
            int n = 5;
            DataStructure.ConnectingGraph3 cg = new DataStructure.ConnectingGraph3(n);
            int ans = cg.query();
            cg.connect(1, 2);
            ans = cg.query();
            cg.connect(2, 4);
            ans = cg.query();
            cg.connect(1, 4);
            ans = cg.query();
        }

        //261
        static void Run_GraphValidTree()
        {
            int[,] validPositions = { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 4 } };

            GraphValidTree question = new GraphValidTree();
            var ans = question.ValidTree(5, validPositions);

            int[,] inValidTreepositions = { { 0, 1 }, { 1, 2 }, { 2, 3 }, { 1, 3 }, { 1, 4 } };
            ans = question.ValidTree(5, inValidTreepositions);

            int[,] inValidTreepositions2 = { { 0, 1 }, { 2, 3 } };
            ans = question.ValidTree(4, inValidTreepositions2);
        }

        //211
        static void Run_WordDictionary()
        {
            DataStructure.WordDictionary question = new DataStructure.WordDictionary();
            //addWord("bad")
            //addWord("dad")
            //addWord("mad")
            //search("pad")-> false
            //search("bad")-> true
            //search(".ad")-> true
            //search("b..")-> true

            question.AddWord("bad");
            question.AddWord("dad");
            question.AddWord("mad");
            var ans = question.Search("pad");
            ans = question.Search("bad");
            ans = question.Search(".ad");
            ans = question.Search("b..");

        }

        //323
        static void Run_NumberConnectedComponentsInUG()
        {
            DataStructure.NumberConnectedComponentsInUG question = new DataStructure.NumberConnectedComponentsInUG();
            //Given n = 5 and edges = [[0, 1], [1, 2], [3, 4]], return 2.
            //Given n = 5 and edges = [[0, 1], [1, 2], [2, 3], [3, 4]], return 1.

            int[,] edges1 = { { 0, 1 }, { 1, 2 }, { 3, 4 } };
            int[,] edges2 = { { 2, 3 }, { 1, 2 }, { 1, 3 } };

            var ans = question.CountComponents(5, edges1);
            ans = question.CountComponents(4, edges2);

            ans = question.CountComponents2(4, edges2);
        }

        // 256 265
        static void Run_PaintHouse()
        {
            //Given costs = [[14, 2, 11],[11, 14, 5],[14, 3, 10]] return 10
            // house 0 is blue, house 1 is green, house 2 is blue, 2 + 5 + 3 = 10

            int[,] costs = { { 14, 2, 11 }, { 11, 14, 5 }, { 14, 3, 10 } };

            DP.PaintHouse question = new DP.PaintHouse();

            var ans = question.MinCost(costs);

            ans = question.MinCostOptimizeSpace(costs);


            /////265 paint  house 2
            ans = question.MinCostII(costs);
        }

        //lint 92
        static void Run_Backpack()
        {
            DP.Backpack question = new DP.Backpack();
            //440
            int[] A_440 = { 2, 3, 5, 7 };
            int[] V_440 = { 1, 5, 2, 4 };

            var ans440 = question.backPackIII(A_440, V_440, 10);
            // 125
            int[] A_125 = { 2, 3, 5, 7 };
            int[] V_125 = { 1, 5, 2, 4 };
            var ans125 = question.BackPackII(10, A_125, V_125);
            //92 backpack 
            int[] weight92 = new int[] { 2, 3, 5, 7 };
            var ans = question.BackPack1_optSpace(11, weight92);

            //563 backback V
            int[] value563 = new int[] { 1, 2, 3, 3, 7 };
            ans = question.BackPackV_OptSpace(value563, 7);

            //564 backpack VI
            int[] value564 = { 1, 2, 4 };
            ans = question.BackPackVI(value564, 4);
        }

        //42, 407
        static void Run_TrapRainWater()
        {
            int[] heights = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            DataStructure.TrapRainWater question = new DataStructure.TrapRainWater();
            var ans = question.TrapRainWaterSolution(heights);

            int[,] heightMap = {
                                 { 1,4,3,1,3,2 },
                                 { 3,2,1,3,2,4 },
                                 { 2,3,3,2,3,1 }
            };

            ans = question.TrapRainWater2(heightMap);
        }

        //367, 279, 69
        static void Run_PerfectSquare()
        {
            DP.PerfectSquare question = new DP.PerfectSquare();

            //586
            var ans586 = question.sqrt2(0.01);
            ans586 = question.sqrt2(0);
            ans586 = question.sqrt2(2);

            //69
            var ans69 = question.MySqrt(10);
            ans69 = question.MySqrt(16);

            //367
            var ans = question.IsPerfectSquare(16);
            ans = question.IsPerfectSquare(14);
            ans = question.IsPerfectSquare(2147395600);

            //279
            var ans279 = question.NumSquares(13);

        }

        //643
        static void Run_MaxAvgSubarray()
        {
            SweepingLine.MaximumAverageSubarray question = new SweepingLine.MaximumAverageSubarray();

            int[] arr644 = { 1, 12, -5, -6, 50, 3 };
            var ans644 = question.FindMaxAverage2(arr644, 3);

            int[] array = { 1, 12, -5, -6, 50, 3 };

            var ans = question.FindMaxAverage(array, 4);


        }

        // Lint 394, 396
        static void Run_CoinseInALine()
        {
            //394
            DP.CoinsInALine question = new DP.CoinsInALine();
            var ans394 = question.firstWillWin(7);

            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 13, 11, 10, 9 };
            //395
            var ans395 = question.firstWillWin2(values);
            //396
            var ans396=question.firstWillWin3(values);

        }

        //lint 437
        static void Run_CopyBooks()
        {
            DP.CopyBooks question = new DP.CopyBooks();

            int[] pages = { 3, 2, 4 };
            var ans = question.copyBooksSolver(pages, 2);
        }

        static void Run_MyQueue()
        {
            DataStructure.MyQueue queue = new DataStructure.MyQueue();
            queue.push(1);
            var ans = queue.pop();
            queue.push(2);
            queue.push(3);
            ans = queue.top();
            ans = queue.pop();
        }

        //575
        static void Run_ExpandExpression()
        {
            DataStructure.ExpandExpression question = new DataStructure.ExpandExpression();
            var ans = question.ExpressionExpandSolver("abc3[a]");
            ans = question.ExpressionExpandSolver("3[abc]");
            ans = question.ExpressionExpandSolver("4[ac]dy");
            ans = question.ExpressionExpandSolver("3[2[ad]3[pf]]xyz");

            if (ans == "adadpfpfpfadadpfpfpfadadpfpfpfxyz")
            {
                Console.WriteLine("pass");
            }
        }

        //84, 85
        static void Run_LargestRectangle()
        {
            //84
            DataStructure.LargestRectangleInHistogram question = new DataStructure.LargestRectangleInHistogram();
            int[] heights = { 1,1 };
            var ans = question.LargestRectangleArea(heights);

            //85
            //1 0 1 0 0
            /// 1 0 1 1 1
            /// 1 1 1 1 1
            /// 1 0 0 1 0
            DataStructure.MaxRectangle question2 = new DataStructure.MaxRectangle();

            char[,] matrix = {
                               {'1', '0', '1', '0', '0'},
                               {'1', '0', '1', '1', '1'},
                               {'1', '1', '1', '1', '1'},
                               {'1', '0', '0', '1', '0'},
                            };

            var ans2 = question2.MaximalRectangle(matrix);

        }

        // 480, 239
        static void Run_SlidingWindow()
        {
            DataStructure.SlidingWindow question = new DataStructure.SlidingWindow();
            int[] array4 = { 2147483647, 2147483647 };
            var ans = question.MedianSlidingWindow(array4, 2);

            int[] array = { 1, 3, -1, -3, 5, 3, 6, 7 };
            ans = question.MedianSlidingWindow(array, 3);

            int[] array2 = { -2147483648, -2147483648, 2147483647, -2147483648, 1, 3, -2147483648, -100, 8, 17, 22, -2147483648, -2147483648, 2147483647, 2147483647, 2147483647, 2147483647, -2147483648, 2147483647, -2147483648 };
            ans = question.MedianSlidingWindow(array2, 6);

            int[] array3 = { 1, 4, 2, 3 };
            ans = question.MedianSlidingWindow(array3, 4);

            int[] array5 = { 1, 3, -1, -3, 5, 3, 6, 7 };
            var ans2 = question.MaxSlidingWindow_Heap(array5, 3);
            ans2 = question.MaxSlidingWindow_DEQUEU(array5, 3);

        }

        //346
        static void Run_MovingAverage()
        {
            DataStructure.MovingAverage question = new DataStructure.MovingAverage(3);
            var ans = question.Next(1);
            ans = question.Next(10);
            ans = question.Next(3);
            ans = question.Next(5);
        }

        // 295
        static void Run_DataStreamMedian()
        {
            DataStructure.DataStreamMedian question = new DataStructure.DataStreamMedian();

            question.AddNum(0);
            var ans = question.FindMedian();
            question.AddNum(0);
            ans = question.FindMedian();

            //question.AddNum(6);
            //var ans = question.FindMedian();
            //question.AddNum(10);
            //ans = question.FindMedian();
            //question.AddNum(2);
            //ans = question.FindMedian();
            //question.AddNum(6);
            //ans = question.FindMedian();
            //question.AddNum(5);
            //ans = question.FindMedian();
            //question.AddNum(0);
            //ans = question.FindMedian();
            //question.AddNum(6);
            //ans = question.FindMedian();
            //question.AddNum(3);
            //ans = question.FindMedian();
            //question.AddNum(1);
            //ans = question.FindMedian();
            //question.AddNum(0);
            //ans = question.FindMedian();
            //question.AddNum(0);
            //ans = question.FindMedian();
        }

        // 654
        static void Run_MaxBinaryTree()
        {
            DataStructure.MaxBinaryTree question = new DataStructure.MaxBinaryTree();

            int[] arr = { 3, 2, 1, 6, 0, 5 };
            var node = question.ConstructMaximumBinaryTree(arr);
        }

        // 48 rotate image clockwise
        static void Run_RotateImage()
        {
            DataStructure.RotateImage question = new DataStructure.RotateImage();
            int[,] image = { { 1,2,3},
                             { 4,5,6},
                             { 7,8,9} };
            question.Rotate(image);
        }

        // 391 lint
        static void Run_NumberOfAirplanesTheSky()
        {
            List<DataStructure.Interval> airplanes = new List<DataStructure.Interval>
            {
                new DataStructure.Interval(1,10),
                new DataStructure.Interval(2,3),
                new DataStructure.Interval(5,8),
                new DataStructure.Interval(4,7),
            };

            DataStructure.AirplaneInSky question = new DataStructure.AirplaneInSky();
            var ans = question.CountOfAirplanes(airplanes);
        }

        //29
        static void Run_Divide2Integer()
        {
            BitManipulation.DivideTwoIntegers question = new BitManipulation.DivideTwoIntegers();
            var ans = question.Divide(-2147483648, 1);
        }

        //162
        static void Run_FindPeakElemet()
        {
            BinarySearch.FindPeakElement question = new BinarySearch.FindPeakElement();
            int[] arr = { 1, 2, 1 };
            var ans = question.FindPeakElementSolver(arr);

            int[,] matrix = { {1, 2, 3, 4, 5},
                              {16,41,23,22,6},
                              {15,24,17,21,7},
                              {14,18,19,20,8},
                              {13,12,11,10,9}};

            int[,] matrix2 = { { 0, 0, 0, 0, 0, 0 }, { 0, 1, 12, 3, 4, 0 }, { 0, 5, 11, 7, 12, 0 }, { 0, 9, 10, 9, 13, 0 }, { 0, 13, 9, 15, 16, 0 }, { 0, 0, 0, 0, 0, 0 } };
            var ansMatrix = question.findPeakII(matrix2);
            ansMatrix = question.findPeakII(matrix);
        }

        //183 lint
        static void Run_WoodCut()
        {
            BinarySearch.WoodCut question = new BinarySearch.WoodCut();

            int[] L = { 232, 124, 456 };
            question.WoodCutSol(L, 7);
        }
        
        //142
        static void Run_LinkedListcycle2()
        {
            DataStructure.LinkedListCycleII question = new DataStructure.LinkedListCycleII();

            DataStructure.ListNode n = new DataStructure.ListNode(3);
            var ans = question.DetectCycle(n);
        }

        //287
        static void Run_FindDuplicateNumber()
        {
            DataStructure.FindDuplicateNumber question = new DataStructure.FindDuplicateNumber();
            int[] arr = { 1, 4, 5, 6, 6, 2, 3 };
            var ans = question.FindDuplicate(arr);
        }

        //218
        static void Run_SkyLine()
        {
            DataStructure.Skyline question = new DataStructure.Skyline();
            int[,] buildings = { { 2, 9, 10 }, { 3, 7, 15 }, { 5, 12, 12 }, { 15, 20, 10 }, { 19, 24, 8 } };

            var ans = question.GetSkyline(buildings);

        }


        //5
        static void Run_LongestPalindromicSubstring()
        {
            DataStructure.LongestPalindromicSubstring question = new DataStructure.LongestPalindromicSubstring();
            var ans = question.LongestPalindrome("abb");
        }

        //516
        static void Run_LongestPalindromeSubseq()
        {
            DP.LongestPalindromicSubsequence question = new DP.LongestPalindromicSubsequence();
            var ans = question.LongestPalindromeSubseq("bbbab");
            ans = question.LongestPalindromeSubseq("abbc");
        }

        //355
        static void Run_DesignTweetter()
        {
            SystemDesign.Twitter twitter = new SystemDesign.Twitter();

            // User 1 posts a new tweet (id = 5).
            twitter.PostTweet(1, 5);

            // User 1's news feed should return a list with 1 tweet id -> [5].
            var ans = twitter.GetNewsFeed(1);

            // User 1 follows user 2.
            twitter.Follow(1, 2);

            // User 2 posts a new tweet (id = 6).
            twitter.PostTweet(2, 6);

            // User 1's news feed should return a list with 2 tweet ids -> [6, 5].
            // Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
            ans = twitter.GetNewsFeed(1);

            // User 1 unfollows user 2.
            twitter.Unfollow(1, 2);

            // User 1's news feed should return a list with 1 tweet id -> [5],
            // since user 1 is no longer following user 2.
            ans = twitter.GetNewsFeed(1);
        }

        //312
        static void Run_BurstBalloon()
        {
            DP.BurstBalloons question = new DP.BurstBalloons();
            int[] nums = {3,1,5,8 };
            var ans = question.MaxCoins(nums);
        }

        //87
        static void Run_ScrambleString()
        {
            DP.ScrambleString question = new DP.ScrambleString();
            var ans = question.IsScramble("eat", "tae");
        }

        //221
        static void Run_MaxSquare()
        {
            char[,] matrix =
            {
                { '1','0','1','0','0' },
                { '1','0','1','1','1' },
                { '1','1','1','1','1' }, 
                { '1','0','0','1','0' }
            };

            DP.MaximalSquare question = new DP.MaximalSquare();
            var ans = question.MaximalSquareSolver(matrix);
            
        }

        // lint 519
        static void Run_ConsistentHash()
        {
            SystemDesign.ConsistentHash question = new SystemDesign.ConsistentHash();
            var ans = question.consistentHashing(5);
        }

        // lint 538
        static void Run_MemCache()
        {
            SystemDesign.Memcache question = new SystemDesign.Memcache();
            var ans = question.get(1, 0);  //  >> 2147483647
            question.set(2, 1, 1, 2);  
            ans = question.get(3, 1);  //  >> 1
            ans = question.get(4, 1);  //  >> 2147483647
            ans = question.incr(5, 1, 1); //  >> 2147483647
            question.set(6, 1, 3, 0);
            ans = question.incr(7, 1, 1);   //  >> 4
            ans = question.decr(8, 1, 1);  //  >> 3
            ans = question.get(9, 1);   //  >> 3
            question.delete(10, 1);
            ans = question.get(11, 1);  //  >> 2147483647
            ans = question.incr(12, 1, 1);  //  >> 2147483647


        }

        // 520
        static void Run_ConsistentHashing2()
        {
           
            // create(100, 3)
            // addMachine(1)
            // >> [3, 41, 90]  => 三个随机数
            // getMachineIdByHashCode(4)
            // >> 1
            // addMachine(2)
            // >> [11, 55, 83]
            // getMachineIdByHashCode(61)
            // >> 2
            // getMachineIdByHashCode(91)
            // >> 1
            SystemDesign.ConsistentHashing2 question = new SystemDesign.ConsistentHashing2(1000, 3);
            var randomlist1 = question.addMachine(1);
            var machine = question.getMachineIdByHashCode(100);
            var randomlist2 = question.addMachine(2);
            machine = question.getMachineIdByHashCode(61);
            machine = question.getMachineIdByHashCode(961);

        }

        //lint 502
        static void Run_MiniCassandra()
        {
            SystemDesign.MiniCassandra question = new SystemDesign.MiniCassandra();
            question.insert("gg", 2, "ggValue2");
            question.insert("gg", 3, "ggValue3");
            question.insert("gg", 1, "ggValue1");
            question.insert("msft", 1, "msftValue1");
            var ans = question.query("gg", 0, 3);

            ans = question.query("msft", 0, 1);
        }

        //232 lint
        static void Run_TinyUrl()
        {
            SystemDesign.TinyUrl question = new SystemDesign.TinyUrl();

            string longUrl = "http://www.lintcode.com/en/problem/tiny-url/";
            string tiny = question.LongToShort(longUrl);
            string recoverLong = question.ShortToLong(tiny);


            string ans = question.createCustom("http://www.lintcode.com/", "lccode"); // http://tiny.url/lccode
            ans = question.createCustom("http://www.lintcode.com/", "lc"); // error
            string newtiny = question.LongToShort("http://www.lintcode.com/problem/"); // http://tiny.url/1Ab38c   // this is just an example, you can have you own 6 characters.
            ans = question.ShortToLong("http://tiny.url/lccode"); // http://www.lintcode.com/
            ans = question.ShortToLong(newtiny); // http://www.lintcode.com/problem/
            ans = question.ShortToLong("http://tiny.url/1Ab38d"); // null

        }

        //476
        static void Run_StoneGame()
        {
            DP.StoneGame question = new DP.StoneGame();
            int[] A = { 4, 1, 1 ,4};
            var ans = question.StoneGameSolver(A);
            int[] B = { 1, 1, 1, 1 };
            int[] C = { 4, 4, 5, 9 };
            ans = question.StoneGameSolver(B);
            ans = question.StoneGameSolver(C);

            int[] D = { 1, 1, 4, 4 };
            ans = question.stoneGame2(D);
        }

        // 115
        static void Run_DistinctSubsequences()
        {
            DP.DistinctSubsequences question = new DP.DistinctSubsequences();
            var ans = question.NumDistinct("raab", "ra");


            string s = "daacaedaceacabbaabdccdaaeaebacddadcaeaacadbceaecddecdeedcebcdacdaebccdeebcbdeaccabcecbeeaadbccbaeccbbdaeadecabbbedceaddcdeabbcdaeadcddedddcececbeeabcbecaeadddeddccbdbcdcbceabcacddbbcedebbcaccac";
            string t = "ceadbaa";

            ans = question.NumDistinct(s, t);
        }

        //474
        static void Run_OneAndZero()
        {
            string[] Array = { "10", "0001", "111001", "1", "0" };
            DP.OnesAndZeroes question = new DP.OnesAndZeroes();
            var ans1 = question.FindMaxFormDFS(Array, 5, 3);
            var ans = question.FindMaxForm(Array, 5, 3);
        }

        //566 lint
        static void Run_GFSClient()
        {
            // client maintains chunck id   and master maintains the id to chunkserver lookup
            SystemDesign.GFSClient client = new SystemDesign.GFSClient(5);

            var ans = client.Read("a.txt");
            //>> null
            client.Write("a.txt", "Wor");
            //>> You don't need to return anything, but you need to call writeChunk("a.txt", 0, "World") to write a 5 bytes chunk to GFS.
            ans = client.Read("a.txt");
            //>> "Wor"
            client.Write("b.txt", "111112222233");
            ans = client.Read("b.txt");
            //>> You need to save "11111" at chink 0, "22222" at chunk 1, "33" at chunk 2.
            client.Write("c.txt", "aaaaabbbbb");
            ans = client.Read("c.txt");
            //>> "aaaaabbbbb"
        }

        //565 lint
        static void Run_HeartBeat()
        {
            SystemDesign.HeartBeat server = new SystemDesign.HeartBeat();
            List<string> ips = new List<string>(){ "10.173.0.2", "10.173.0.3" };
            server.initialize(ips, 10);
            server.ping(1, "10.173.0.2");
            var ans = server.getDiedSlaves(20);
            //>> ["10.173.0.3"]
            ans = server.getDiedSlaves(21);
            //>> ["10.173.0.2", "10.173.0.3"]
            server.ping(22, "10.173.0.2");
            server.ping(23, "10.173.0.3");
            ans = server.getDiedSlaves(24);
            //>> []
            ans = server.getDiedSlaves(42);
            //>> ["10.173.0.2"]
        }

        //623
        static void Run_KEditDistance()
        {
            DP.KEditDistance question = new DP.KEditDistance();
            string[] wordList = { "abc", "abd", "abcd", "adc" };
            var ans = question.kDistance(wordList, "ac", 1);
        }
        
        //500 lint
        static void Run_InvertedIndex()
        {
            SystemDesign.Document doc1 = new SystemDesign.Document();
            doc1.id = 1;
            doc1.content = "This is the content of document 1 it is very short";

            SystemDesign.Document doc2 = new SystemDesign.Document();
            doc2.id = 2;
            doc2.content = "This is the content of document 2 it is very long bilabial bilabial heheh hahaha";

            SystemDesign.InvertedIndex question = new SystemDesign.InvertedIndex();
            SystemDesign.Document[] docs = { doc1, doc2 };

            var ans = question.InvertedIndexInjection(new List<SystemDesign.Document>() { doc1, doc2 });
         }

        //231 lint
        static void Run_Typehead()
        {
            var contents = new List<SystemDesign.NodeContent>() { new SystemDesign.NodeContent("Jason Zhang", 4),
                                                                 new SystemDesign.NodeContent("Jason Cheng", 2),
                                                                 new SystemDesign.NodeContent("Jason Lin", 3),
                                                                 new SystemDesign.NodeContent("Jason hua", 5),
                                                                 new SystemDesign.NodeContent("Larry Shi", 4),
                                                                 new SystemDesign.NodeContent("James Yu", 1) };

            SystemDesign.Typehead typehead = new SystemDesign.Typehead(contents);
            var ans = typehead.search("Jason"); //{"Jason hua", "Jason Zhang", "Jason Lin"}
            ans = typehead.search("La");  // {Larry Shi}
            ans = typehead.search("Yu");   // empty
        }

        //44
        static void Run_WildcardMatching()
        {
            DP.WildcardMatching question = new DP.WildcardMatching();
            var ans1 = question.IsMatch_recursive2("aa", "*");
            var ans2 = question.IsMatch("ABx", "A?*");
        }

        //10
        static void Run_RegularExpression()
        {
            DP.RegularExpression question = new DP.RegularExpression();
            var ans = question.IsMatch("ac", "ac*");
        }

        // lint138,  leetcode 325
        static void Run_SubarraySum()
        {
            DataStructure.SubarraySum question = new DataStructure.SubarraySum();
            int[] arr4 = { 1, 2, 3, 4 };
            var ans4 = question.subarraySumII(arr4, 1, 3);


            int[] arr = { -3, 1, 2, -3, 4 , -4};
            var ans = question.SubarraySumSolver(arr);

            int[] arr2 = { 1, -1, 1, 1, -1 };
            var ans2 = question.SubarraySumK(arr2, 0);

            int[] arr3 = { 1, -1, 5, -2, 3 };
            var ans3 = question.MaxSubArrayLen(arr3, 3);

            
        }

        //387
        static void Run_FirstUniqueCharacterinaString()
        {
            DataStructure.FirstUniqueCharacterinaString question = new DataStructure.FirstUniqueCharacterinaString();
            var ans = question.FirstUniqChar("adaccdcda");
        }

        //186
        static void Run_ReverseWordsinaString2()
        {
            DataStructure.ReverseWordsinaString2 question = new DataStructure.ReverseWordsinaString2();
            string str = "s the  sky is blue  e ";
            question.ReverseWords(str.ToCharArray());
        }

        //529
        static void Run_Geohash()
        {
            SystemDesign.Geohash question = new SystemDesign.Geohash();
            var ans = question.Encode(39.92816697, 116.38954991, 12);
            var ans1 = question.Decode("wx4g0s");
        }

        //453
        static void Run_FlaternTreeNodes()
        {
            DataStructure.FlattenBinaryTreeToLL question = new DataStructure.FlattenBinaryTreeToLL();

            TreeNode root = ConstructTeeNodeTest();
            question.flatten(root);
        }

        static TreeNode ConstructTeeNodeTest()
        {
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(5);
            root.right.right = new TreeNode(6);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            return root;
        }
        
        //525
        static void Run_MiniUber()
        {
            SystemDesign.MiniUber uber = new SystemDesign.MiniUber();
            var ans = uber.Report(1, 36.1344, 77.5672); // return null
            ans = uber.Report(2, 45.1344, 76.5672); // return null
            ans = uber.Request(2, 39.1344, 76.5672); // return a trip, LOG(INFO): Trip(rider_id: 2, driver_id: 1, lat: 39.1344, lng: 76.5672)
            ans = uber.Report(1, 38.1344, 75.5672); // return a trip, LOG(INFO): Trip(rider_id: 2, driver_id: 1, lat: 39.1344, lng: 76.5672)
            ans = uber.Report(2, 45.1344, 76.5672); // return null
            uber.TripDone(1);
            ans = uber.Request(2, 45, 76);
            ans = uber.Report(2, 45, 77);
        }

        //509
        static void Run_MiniYelp()
        {
            SystemDesign.MiniYelp yelp = new SystemDesign.MiniYelp();
            var resId1 = yelp.addRestaurant("Lint Cafe", 10.4999999, 11.599999); // return 1
            var resId2 = yelp.addRestaurant("Code Cafe", 11, 12); // return 2
            var ans = yelp.neighbors(10.5, 11.6, 6.7); // return ["Lint Cafe"]
            yelp.removeRestaurant(resId1);
            ans = yelp.neighbors(10.5, 9.6, 6.7); // return []
        }

        //lint 556
        static void Run_StandardBloomFilter()
        {
            /// StandardBloomFilter(3)
            /// add("lint")
            /// add("code")
            /// contains("lint") // return true
            /// contains("world") // return false
            SystemDesign.StandardBloomFilter filter = new SystemDesign.StandardBloomFilter(3);
            filter.add("lint");
            filter.add("code");
            var ans = filter.contains("lint");
            ans = filter.contains("world");
        }

        //lint 486
        static void Run_MergeKSortedArrays()
        {
            List<int[]> arrays = new List<int[]>();
            arrays.Add(new int[] { 0, 0, 5, 7 });
            arrays.Add(new int[] { 0, 4, 6 });
            arrays.Add(new int[] { 0, 8, 9, 10, 11 });
            
            SystemDesign.MergeKSortedArrays question = new SystemDesign.MergeKSortedArrays();
            var ans = question.MergekSortedArraysSolver(arrays);
        }

        //lint 215
        static void Run_RateLimiter()
        {
            SystemDesign.RateLimiter rtLimiter = new SystemDesign.RateLimiter();

            var ans = rtLimiter.isRatelimited(1, "login", "3/m", true); //, return false.
            ans = rtLimiter.isRatelimited(11, "login", "3/m", true); //, return false.
            ans = rtLimiter.isRatelimited(21, "login", "3/m", true); //, return false.
            ans = rtLimiter.isRatelimited(30, "login", "3/m", true); //, return true.
            ans = rtLimiter.isRatelimited(65, "login", "3/m", true); //, return false.
            ans = rtLimiter.isRatelimited(300, "login", "3/m", true);// , return false.
        }

        //lint 505
        static void Run_WebLogger()
        {
            SystemDesign.WebLogger logger = new SystemDesign.WebLogger();
            logger.hit(1);
            logger.hit(2);
            var ans = logger.get_hit_count_in_last_5_minutes(3); // >> 2
            logger.hit(300);
            ans = logger.get_hit_count_in_last_5_minutes(300); // >> 3
            ans = logger.get_hit_count_in_last_5_minutes(301); // >> 2
        }

        //lint 708
        static void Run_ElevatorSystem()
        {
            OOD.ElevatorSystem esystem = new OOD.ElevatorSystem();
            var elevator1 = esystem.HandleRequest(5, OOD.Direction.Down);
            var elevator2 = esystem.HandleRequest(4, OOD.Direction.UP);
            var elevator3 = esystem.HandleRequest(3, OOD.Direction.UP);  // e2 == e3

            // e1 reached level5 and prepare to go down
            elevator1.OpenGate();      // e1 at level5 now
            elevator1.HandleInternalRequest(2);   // set new direciton and to level2
            elevator1.CloseGate();

            var elevator4 = esystem.HandleRequest(6, OOD.Direction.Down);   // null, will be pick up later, because e1 curr down is at level 5 now

            esystem.HandleRequest(3, OOD.Direction.Down);    // e1 at level5 down can pick up this request
            elevator1.OpenGate();   // e1 stop at level3 first
            elevator1.CloseGate();   // e1 set direction to down
            elevator1.OpenGate();  // e1 stop at level2 
            elevator1.CloseGate();  // el is idle

            // make sure worker can pick up
            Thread.Sleep(2000);

            elevator1.OpenGate();   // queue worker pickup level6 down request


            elevator2.OpenGate();  // e2 at level 3
            elevator2.HandleInternalRequest(5);
            elevator2.CloseGate();
            elevator2.OpenGate();  // e2 at level 4
            elevator2.CloseGate();
            elevator2.OpenGate();  // e2 at level 5
        }

        //146
        static void Run_LRUCache()
        {
            OOD.LRUCache cache = new OOD.LRUCache(2 /* capacity */ );

            cache.Put(1, 1);
            cache.Put(2, 2);
            var ans = cache.Get(1);       // returns 1
            cache.Put(3, 3);    // evicts key 2
            ans = cache.Get(2);       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            ans = cache.Get(1);       // returns -1 (not found)
            ans = cache.Get(3);       // returns 3
            ans = cache.Get(4);       // returns 4
        }

        //34
        static void Run_SearchRange()
        {
        ///Input: nums = [5, 7, 7, 8, 8, 10], target = 8
        /// Output: [3,4]
        ///         Example 2:
        /// 
        /// Input: nums = [5,7,7,8,8,10], target = 6
        /// Output: [-1,-1]
            int[] nums = { 5, 7, 7, 8, 8, 10 };
            BinarySearch.SearchforaRange question = new BinarySearch.SearchforaRange();
            var ans = question.SearchRange(nums, 8);   // [3,4]

            ans = question.SearchRange(nums, 5);    // [0,0]


            ans = question.SearchRange(nums, 6);  // [-1,-1]

            ans = question.SearchRange(new int[1] { 6}, 6);  // [-1,-1]
        }

        // lint 405
        static void Run_SubMatrixSum()
        {
            int[,] matrix1 = new int[,] {{ 1, 5, 7 },
                                        { 3 ,7 ,-8},
                                        { 4 ,-8 ,9}
                                       };

            DP.SubmatrixSum question = new DP.SubmatrixSum();
            var ans1 = question.SubmatrixSumSolver(matrix1);

            int[,] matrix2 = new int[,] { { 0 }
                                       };

            
            var ans2 = question.SubmatrixSumSolver(matrix2);

            //  [1 ,5 ,7],
            //  [3 ,7 ,-8],
            //  [4 ,-8 ,9],   ==>   {{1,1}, {2,2}}
            // ]


        }

        //https://www.dotnetperls.com/fisher-yates-shuffle
        static void Run_ShuffleCard()
        {
            Number.ShuffleCard question = new Number.ShuffleCard();
            int[] array = { 1, 2, 3, 4, 5 };

            int count = 10;

            while (count > 0)
            {
                question.Shuffle(array);

                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }

                Console.WriteLine();
                count--;
            }    
        }

        static  void Run_ArrayAverage()
        {
            Number.ArrayAverage question = new Number.ArrayAverage();

            long[] arr = { long.MinValue, long.MinValue+1, long.MinValue+2 };


            var average = question.ComputeAverage(arr);

            double verifyAns = 0;

            foreach(var v in arr)
            {
                verifyAns += v;
            }
            verifyAns /= arr.Length;

        }

        // lint 402
        static void Run_ContinuousSubarraySum()
        {
            DataStructure.ContinuousSubArraySum question = new DataStructure.ContinuousSubArraySum();
            int[] arr = { -3, 1, 3, -3, 4 };
            var ans = question.ContinuousSubarraySumSolver(arr);
        }

        //lint 502, leetcode 28
        static void Run_strstr()
        {
            DataStructure.StrStr question = new DataStructure.StrStr();
            var ans = question.strStr2("abcdef", "bcd");

            //28
            ans = question.StrStr1("abcdef", "bcd");
        }

        //125
        static void Run_ValidPalindrome()
        {
            string test1 = "A man, a plan, a canal: Panama";
            string test2 = "race a car";
            DataStructure.ValidPalindrome question = new DataStructure.ValidPalindrome();
            var ans = question.IsPalindrome(test1);
            ans = question.IsPalindrome(test2);

            ans = question.ValidPalindrome2("abca");
        }

        //lint 128
        static void Run_Hashfunction()
        {
            DataStructure.HashFunction question = new DataStructure.HashFunction();

            var ans = question.HashCode("abcd".ToCharArray(), 100);
        }

        //215
        static void Run_KthLargestInArray()
        {
            int[] arr = { 3,2,1,5,6,4 };
            BinarySearch.KthLargestElementInArray question = new BinarySearch.KthLargestElementInArray();
            var ans = question.FindKthLargest(arr, 2);

            int[] arr2 = { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            question.QuickSort(arr2);

        }

        // lint 382
        static void Run_TriangleCount()
        {
            Number.TriangleCount question = new Number.TriangleCount();
            int[] arr = { 3, 6, 4, 7 };
            var ans = question.TriangleCountSolver(arr);
        }

       

        //425
        static void Run_WordSquares()
        {
            DataStructure.WordSquare question = new DataStructure.WordSquare();
            string[] input = { "area","lead","wall","lady","ball"};
            var ans = question.WordSquares(input);

            string[] input2 = { "momy","oooo","yoyo"};
            ans = question.WordSquares(input2);
        }

        //130
        static void Run_SurroundingRegions()
        {

            DataStructure.SurroundedRegions question = new DataStructure.SurroundedRegions();

            char[,] input = {   { 'X', 'X', 'X', 'X' },
                                { 'X', 'O', 'O', 'X' },
                                { 'X', 'X', 'O', 'X' },
                                { 'X', 'O', 'X', 'X' } };

            char[,] input2 = {{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'O', 'O'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'O'},
{'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'O'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'O', 'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'O', 'O', 'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'O', 'O', 'X', 'X'},
{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'O', 'X', 'O', 'X'}};

            question.Solve(input2);
        }

        //lint 235
        static void Run_PrimeFactorization()
        {
            Number.PrimeFactorization question = new Number.PrimeFactorization();
            var ans1 = question.GetFactors(12);
            var ans = question.primeFactorizationSolver(660);

        }

        //485
        static void Run_LastPositionOfTarget()
        {
            int[] arr = { 1, 2, 2, 4, 5, 5 };
            BinarySearch.LastPositionofTarget question = new BinarySearch.LastPositionofTarget();
            var ans = question.LastPositionSolver(arr, 2);
        }

        static void Run_SearchInRotatedSortedArray()
        {
            int[] arr = { 4, 5, 6, 7, 0, 1, 2 };
            BinarySearch.SearchInRotatedSortedArray question = new BinarySearch.SearchInRotatedSortedArray();
            var ans = question.Search(arr, 0);
        }

        //lint 460
        static  void Run_FindKClosestElements()
        {
            //Given A = [1, 2, 3], target = 2 and k = 3, return [2, 1, 3].
            //Given A = [1, 4, 6, 8], target = 3 and k = 3, return [4, 1, 6].
            int[] arr = { 1, 4, 6, 8 };
            BinarySearch.FindKClosestElements question = new BinarySearch.FindKClosestElements();
            question.FindClosestElements(arr, 3, 3);
            
        }

        //50 
        static void Run_Pow()
        {
            BinarySearch.PowXN power = new BinarySearch.PowXN();
            var ans = power.MyPow(2.000, 10);
            ans = power.MyPow(1.00000, -2147483648);
        }

        //140
        static void Run_FastPower()
        {
            Number.FastPower question = new Number.FastPower();
            var ans = question.fastPowerSolver(2, 3, 31);
        }

        // 57, 59
        static void Run_ThreeSum()
        {
            TwoPointers.ThreeSum question = new TwoPointers.ThreeSum();
            int[] numbers = { -2, -3, -4, -5, -100, 99, 1, 4, 4, 4, 5, 1, 0, -1, 2, 3, 4, 5 };
            var ans = question.ThreeSumsolver(numbers);

            int[] arr = { -1, 2, 1, -4 };
            question.ThreeSumClosest(arr, 3);
        }

        //26
        static void Run_RemoveDuplicate()
        {
            TwoPointers.RemoveDuplicatesFromSortedArray question = new TwoPointers.RemoveDuplicatesFromSortedArray();
            int[] arr = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4, 4 };

            var ans = question.RemoveDuplicates(arr);
             
        }

        //lint 464
        static void Run_SortIntegers()
        {
            TwoPointers.QuickSort question = new TwoPointers.QuickSort();
            int[] arr = { 3, 2, 1, 4, 5 };

            question.sortIntegers2(arr);
        }

        //75
        static void Run_SortColors()
        {
            int[] arr = { 1,2,0 };
            TwoPointers.SortColors question = new TwoPointers.SortColors();
            question.SortColors1(arr);
        }

        // 443
        static void Run_TwoSum()
        {
            TwoPointers.TwoSum question = new TwoPointers.TwoSum();
            int[] arr = { 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99 };
            var ans = question.TwoSumGreater(arr, -64);

            int[] arr2 = { 2, 7, 11, 15 };
            var ans2 = question.TwoSumLE(arr2, 24);
        }

        //102
        static void Run_BinaryTreeLevelOrderTraversal()
        {
            Tree.BinaryTreeLevelTraversal question = new Tree.BinaryTreeLevelTraversal();
            TreeNode root = new TreeNode(3);
            root.left= new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            question.LevelOrder(root);
        }

        // 207
        static void Run_CourceSchedule()
        {
            TopologicalSort.CourseSchedule question = new TopologicalSort.CourseSchedule();

            int[,] prerequsiste = { { 2, 0 }, { 1, 0 }, { 3, 2 }, { 3, 1 } };

            var canfinish = question.CanFinish(4, prerequsiste);

            int[,] prerequsiste2 = { { 1, 0 }, { 0, 1 }};
            canfinish = question.CanFinish(2, prerequsiste2);

            var topsort = question.FindOrder(4, prerequsiste);

        }

        //133 Clone Graph
        static void Run_CloneGraph()
        {
            BFS.UndirectedGraphNode node0 = new BFS.UndirectedGraphNode(0);
            BFS.UndirectedGraphNode node1 = new BFS.UndirectedGraphNode(1);
            BFS.UndirectedGraphNode node2 = new BFS.UndirectedGraphNode(2);

            node0.neighbors.Add(node1);
            node0.neighbors.Add(node2);
            node1.neighbors.Add(node2);
            node2.neighbors.Add(node2);

            BFS.CloneGraph question = new BFS.CloneGraph();
            question.CloneGraphSolver(node0);
        }

        // 127 
        static void Run_WordLadder()
        {
            BFS.WordLadder question = new BFS.WordLadder();

            List<string> wordList = new List<string>() { "hot", "dot", "dog", "lot", "log" };

            var ans2 = question.FindLadders2("hit", "cog", wordList);

            var ans = question.LadderLength("hit", "cog", wordList);

            
        }

        // 611
        static void Run_KnightShortestPath()
        {
            BFS.KnightShortestPath question = new BFS.KnightShortestPath();
            bool[,] grid = new bool[3, 3];
            BFS.Point source = new BFS.Point(2, 0);
            BFS.Point destination = new BFS.Point(2, 2);
            var ans = question.ShortestPath(grid, source, destination);
        }

        // 444 Sequence Reconstruction
        static void Run_SequenceReconstruction()
        {
            TopologicalSort.SequenceReconstruction question = new TopologicalSort.SequenceReconstruction();

            int[] org = { 1, 2, 3 };
            List<List<int>> seqs = new List<List<int>>();
            seqs.Add(new List<int> { 1, 2 });
            seqs.Add(new List<int> { 1, 3 });
            seqs.Add(new List<int> { 2, 3 });

            var ans = question.SequenceReconstructionSolver(org, seqs.ToArray());

            int[] org2 = { 1};
            List<List<int>> seqs2 = new List<List<int>>();
            seqs2.Add(new List<int> { 1 });
            seqs2.Add(new List<int> { 2, 3 });
            seqs2.Add(new List<int> { 3, 2 });

            var ans2 = question.SequenceReconstructionSolver(org2, seqs2.ToArray());

        }

        //297
        static void Run_SerializeDeserializeBinaryTree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(5);

            BFS.SerializeDeserializeBinaryTree question = new BFS.SerializeDeserializeBinaryTree();
            string data = question.serialize(root);

            var newBT = question.deserializePractice(data);
        }

        //103
        static void Run_BinaryTreeZigZag()
        {
            BFS.BinaryTreeZigzagLevelOrderTraversal question = new BFS.BinaryTreeZigzagLevelOrderTraversal();
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            var ans = question.ZigzagLevelOrder(root);
        }

        // lint 624
        static void Run_RemoveSubstrings()
        {
            BFS.RemoveSubstrings question = new BFS.RemoveSubstrings();
            HashSet<string> substrs = new HashSet<string>();
            substrs.Add("ab");
            substrs.Add("abcd");

            var ans = question.MinLengthRecursive("abcabd", substrs);
        }

        // lint 596
        static void Run_MinSubtree()
        {
            DFS.MinimumSubtree question = new DFS.MinimumSubtree();

            ///
            ///      1
            ///    /   \
            ///  -5     2
            ///  / \   /  \
            /// 0   2 - 4 - 5
            ///
            ///

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(-5);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(0);
            root.left.right = new TreeNode(2);

            root.right.left = new TreeNode(-4);
            root.right.right = new TreeNode(-5);

            var ans = question.FindSubtree(root);
        }

        // 110
        static bool Run_BalancedBinaryTree()
        {
            DFS.BalancedBinaryTree question = new DFS.BalancedBinaryTree();

            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.left = new TreeNode(2);
            //root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(3);
            root.left.left = new TreeNode(3);
            //root.left.right = new TreeNode(3);
            root.right.right.right = new TreeNode(4);

            //root.right.left.left = new TreeNode(4);
            //root.right.left.right = new TreeNode(4);

            root.left.left.left = new TreeNode(4);
            //root.left.left.right = new TreeNode(4);
            //root.left.right.left = new TreeNode(4);
            //root.left.right.right = new TreeNode(4);

            //root.left.left.left.left = new TreeNode(5);
            //root.left.left.left.right = new TreeNode(5);

            var ans = question.IsBalanced(root);

            return ans;
        }

        //230
        static void Run_KthSmallestElementInBST()
        {
            DFS.KthSmallestElementInBST question = new DFS.KthSmallestElementInBST();

            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(4);
            root.right = new TreeNode(7);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(8);

            question.KthSmallest(root, 7);
        }

        // 680
        static void Run_SplitString()
        {
            DFS.SplitString question = new DFS.SplitString();
            //var ans = question.SplitStringSolver("123");
            var ans = question.SplitStringSolverPractice("123");
        }

        //lint 570
        static void Run_FindMissingNumbers()
        {
            DFS.FindMissingNumber question = new DFS.FindMissingNumber();
            string testStr = "111098765432";
            var ans = question.FindMissing2(11, testStr);

            

            int[] num = { 3, 1, 0 };
            var ans2 = question.MissingNumber(num);
        }

        //77
        static void Run_Combinations()
        {
            DFS.Combinations question = new DFS.Combinations();
            var ans = question.Combine(4, 2);

        }

        //301
        static void Run_RemoveInvalidParentheses()
        {
            DFS.RemoveInvalidParentheses question = new DFS.RemoveInvalidParentheses();
            var ans = question.RemoveInvalidParenthesesHelper("(a)())())");
        }

        //93
        static void Run_RestporeIPAddress()
        {
            DFS.RestoreIPAddresses question = new DFS.RestoreIPAddresses();
            var ans = question.RestoreIpAddressesSolver("010010");

        }

        //22
        static void Run_GenerateParenthesis()
        {
            DFS.GenerateParentheses question = new DFS.GenerateParentheses();
            var ans = question.GenerateParenthesisSolver(4);
        }

        //681
        static void Run_NextClosestTime()
        {
            DFS.NextClosestTime question = new DFS.NextClosestTime();
            var ans = question.NextClosestTimeSolver2("19:34");
        }

        // lint 10
        static void Run_StringPermutation()
        {
            DFS.StringPermutation question = new DFS.StringPermutation();
            var ans = question.stringPermutation2("aabb");

        }

        // 51
        static void Run_NQueen()
        {
            DFS.NQueens question = new DFS.NQueens();

            //n queen 2
            var ans2 = question.TotalNQueens(4);
            // n queen 1
            var ans1 = question.SolveNQueens(4);

        }

        //17
        static void Run_LetterCombinationsPhoneNumber()
        {
            DFS.LetterCombinationsPhoneNumber question = new DFS.LetterCombinationsPhoneNumber();
            var ans = question.LetterCombinations("23");
        }

        //291
        static void Run_WordPattern()
        {
            DFS.WordPattern question = new DFS.WordPattern();
            var ans = question.WordPatternMatchPractice("ab", "ss");
        }

        //31 
        static void Run_NextPermutation()
        {
            DFS.NextPermutation question = new DFS.NextPermutation();

            int[] nums = { 3,2,1};
            question.NextPermutationSolver(nums);

            int[] nums2 = { 1, 3, 2, 3 };
            var ans = question.previousPermuation(nums2);
        }


        // 380
        static void Run_RandomizedSet()
        {
            DataStructure.RandomizedSet randomSet = new DataStructure.RandomizedSet();

            var boolV = randomSet.Insert(3);
            boolV = randomSet.Insert(3);
            var ansV = randomSet.GetRandom();
            ansV = randomSet.GetRandom();
            boolV = randomSet.Insert(1);
            boolV = randomSet.Remove(3);
            ansV = randomSet.GetRandom();
            ansV = randomSet.GetRandom();
            boolV = randomSet.Insert(0);
            boolV = randomSet.Remove(0);
   
            
            
            // Inserts 1 to the set. Returns true as 1 was inserted successfully.
            var ans = randomSet.Insert(1);
            
            // Returns false as 2 does not exist in the set.
            ans = randomSet.Remove(2);
            
            // Inserts 2 to the set, returns true. Set now contains [1,2].
            ans = randomSet.Insert(2);
            
            // getRandom should return either 1 or 2 randomly.
            int num = randomSet.GetRandom();
            
            // Removes 1 from the set, returns true. Set now contains [2].
            ans = randomSet.Remove(1);
            
            // 2 was already in the set, so return false.
            ans = randomSet.Insert(2);

            // Since 2 is the only number in the set, getRandom always return 2.
            num = randomSet.GetRandom();
        }

        //264
        static void Run_UglyNumber()
        {
            DataStructure.UglyNumber question = new DataStructure.UglyNumber();
            var ans = question.NthUglyNumber(1407);
        }

        //612
        static void Run_KClosestPoints()
        {
            //[4,6],[4,7],[4,4],[2,5],[1,1]
            DataStructure.KClosestPoints question = new DataStructure.KClosestPoints();
            DataStructure.Point[] arr = new DataStructure.Point[6];
            int count = 0;
            arr[count++] = new DataStructure.Point(1, 1);
            arr[count++] = new DataStructure.Point(1, 1);
            arr[count++] = new DataStructure.Point(4, 6);
            arr[count++] = new DataStructure.Point(4, 7);
            arr[count++] = new DataStructure.Point(4, 4);
            arr[count++] = new DataStructure.Point(2, 5);



            question.kClosest(arr, new DataStructure.Point(0,0), 3);
        }

        // lint 544
        static void Run_TopKLargestNumbers()
        {
            DataStructure.TopKLargestNumbers question = new DataStructure.TopKLargestNumbers();

            int[] nums = { 3, 10, 100, -99, 4, 100};
            var ans1 = question.topKQSort(nums, 3);
            var ans2 = question.topkPQ(nums, 3);
        }

        //23
        static void Run_MergeKSortedList()
        {
            DataStructure.ListNode L1 = new DataStructure.ListNode(1);
            L1.next = new DataStructure.ListNode(4);
            L1.next.next = new DataStructure.ListNode(5);

            DataStructure.ListNode L2 = new DataStructure.ListNode(1);
            L2.next = new DataStructure.ListNode(3);
            L2.next.next = new DataStructure.ListNode(4);

            DataStructure.ListNode L3 = new DataStructure.ListNode(2);
            L3.next = new DataStructure.ListNode(6);

            DataStructure.ListNode[] arr = new DataStructure.ListNode[3];
            arr[0] = L1;
            arr[1] = L2;
            arr[2] = L3;

            DataStructure.MergeKSortedLists question = new DataStructure.MergeKSortedLists();
            var ans2 = question.MergeKLists_MergeSort(arr);
            var ans = question.MergeKLists(arr);

        }

        // lint 613
        static void Run_HighFive()
        {
            DataStructure.HighFive question = new DataStructure.HighFive();
            List<DataStructure.Record> records = new List<DataStructure.Record>()
            {
                new DataStructure.Record(1, 92),
                new DataStructure.Record(1, 92),
                new DataStructure.Record(1, 92),
                new DataStructure.Record(2, 93),
                new DataStructure.Record(2, 100),
                new DataStructure.Record(2, 100),
                new DataStructure.Record(2, 98),
                new DataStructure.Record(2, 97),
                new DataStructure.Record(1, 60),
                new DataStructure.Record(1, 58),
                new DataStructure.Record(2, 100),
                new DataStructure.Record(1, 61)
            };
            var ans = question.HighFiveSolver(records);
        }

        // lint 104
        static void Run_MergeKSortedArrays104()
        {
            DataStructure.MergeKSortedArrays question = new DataStructure.MergeKSortedArrays();
            List<List<int>> arrays = new List<List<int>>();
            arrays.Add(new List<int>() { 0, 0, 5, 7 });
            arrays.Add(new List<int>() { 0, 4, 6 });
            arrays.Add(new List<int>() { 0, 8, 9, 10, 11 });
            var ans = question.mergekSortedArrays(arrays);
        }

        // lint 839
        static void Run_MergeTwoSortedIntervalLists()
        {
            DataStructure.MergeTwoSortedIntervalLists question = new DataStructure.MergeTwoSortedIntervalLists();
            List<DataStructure.Interval> list1 = new List<DataStructure.Interval>() { new DataStructure.Interval(1,2), new DataStructure.Interval(3,4) };
            List<DataStructure.Interval> list2 = new List<DataStructure.Interval>() { new DataStructure.Interval(2,3), new DataStructure.Interval(5,6) };

            var ans = question.MergeTwoInterval(list1, list2);
        }

        // 577
        static void Run_MergeKSortedIntervalLists()
        {
            DataStructure.MergeKSortedIntervalLists question = new DataStructure.MergeKSortedIntervalLists();
            List<DataStructure.Interval> list1 = new List<DataStructure.Interval>() { new DataStructure.Interval(1, 3), new DataStructure.Interval(4, 7), new DataStructure.Interval(6, 8) };
            List<DataStructure.Interval> list2 = new List<DataStructure.Interval>() { new DataStructure.Interval(1,2), new DataStructure.Interval(9,10) };
            List<List<DataStructure.Interval>> lists = new List<List<DataStructure.Interval>>() { list1, list2 };

            var ans = question.MergeKSortedIntervalListsSolver(lists);

        }

        // 88
        static void Run_MergeSortedArray()
        {
            DataStructure.MergeSortedArray question = new DataStructure.MergeSortedArray();
            int[] num1 = new int[5];
            num1[0] = 1;
            num1[1] = 3;
            num1[2] = 5;

            int[] num2 = new int[2];
            num2[0] = 2;
            num2[1] = 4;

            question.Merge(num1,3, num2,2);
        }


        // 4
        static void Run_Merge2SortedArrays()
        {
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3,4 };
            var ans = MedianOfTwoSortedArray.FindMedianSortedArrays(nums1, nums2);
        }

        // 944
        static void Run_MaximumSubmatrix()
        {
            DataStructure.MaximumSubmatrix question = new DataStructure.MaximumSubmatrix();

            int[,] matrix =
            {
                {1, 3, -1 },
                { 2,3,-2},
                { -1,-2,-3}
            };
           

            var ans = question.MaxSubmatrixSolver(matrix);
        }

        // 311
        static void Run_SparseMatrixMult()
        {
            DataStructure.SparseMatrixMultiplication question = new DataStructure.SparseMatrixMultiplication();
            int[,] A = { { 1, 0, 0 }, { -1, 0, 3 } };
            int[,] B = { { 7, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } };
            var ans = question.Multiply(A, B);
        }

        // 931
        static void Run_MedianKSortedArrays()
        {
            DataStructure.MedianKSortedArrays question = new DataStructure.MedianKSortedArrays();
            List<List<int>> nums = new List<List<int>>();
            nums.Add(new List<int>() { 15, 41, 43, 52, 53, 56, 73, 87, 93 });
            nums.Add(new List<int>() { 27} );
            nums.Add(new List<int>() { 2, 46, 92 });
            nums.Add(new List<int>() { 9, 12, 25, 58, 63, 72, 84, 92 });
            nums.Add(new List<int>());
            nums.Add(new List<int>());
            nums.Add(new List<int>() { 1 });
            nums.Add(new List<int>() { 3, 29, 31, 55 });
            nums.Add(new List<int>() { 17, 33, 45, 60, 74, 76, 80, 90, 92 });
            nums.Add(new List<int>() { 4, 8, 20, 25, 25, 27, 45, 90, 100 });

            int[] expected = { 15, 41, 43, 52, 53, 56, 73, 87, 93,27, 2, 46, 92, 9, 12, 25, 58, 63, 72, 84, 92,1, 3, 29, 31, 55, 17, 33, 45, 60, 74, 76, 80, 90, 92, 4, 8, 20, 25, 25, 27, 45, 90, 100 };
            Array.Sort(expected);

            foreach(var i in expected)
            {
                Console.Write(i + " " );
            }
            

            var ans = question.FindMedian(nums);
        }

        //307
        static void Run_RangeSumQueryMutable()
        {
            int[] nums = { 1, 3, 5 };
            DataStructure.NumArrayMutable question = new DataStructure.NumArrayMutable(nums);
            var ans = question.SumRange(0, 2);  // 9
            question.Update(1, 2);
            ans = question.SumRange(0, 2);   // 8
        }


        //304
        static void Run_RangeSumQuery2()
        {
            int[,] matrix =
            {
                {3, 0, 1, 4, 2},
                {5, 6, 3, 2, 1},
                {1, 2, 0, 1, 5},
                {4, 1, 0, 1, 7},
                {1, 0, 3, 0, 5 }
            };

            DataStructure.RangeSumQuery2D question = new DataStructure.RangeSumQuery2D(matrix);
            var ans = question.SumRegion(2, 1, 4, 3);  // 8
            ans = question.SumRegion(1, 1, 2, 2); //11
            ans = question.SumRegion(1, 2, 2, 4); //12 


            DataStructure.RangeSumQuery2DMutable question2 = new DataStructure.RangeSumQuery2DMutable(matrix);
            var ans2 = question2.SumRegion(2, 1, 4, 3);  // 8
            question2.Update(3, 2, 2);
            ans2 = question2.SumRegion(2, 1, 4, 3);  // 10

        }

        // 548
        static void Run_InterSectionTwoArrays()
        {
            DataStructure.IntersectionofTwoArrays question = new DataStructure.IntersectionofTwoArrays();
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            var ans = question.IntersectionGetAll(nums1, nums2);

        }

        // lint 139
        static void Run_SubarraySumClosest()
        {
            DataStructure.SubarraySumClosest question = new DataStructure.SubarraySumClosest();
            int[] nums = { -3, 1, 1, -3, 5 };

            var ans = question.SubarraySumClosestSol(nums);

        }

        // lint 793
        static void Run_IntersectionArrays()
        {
            DataStructure.IntersectionOfArrays question = new DataStructure.IntersectionOfArrays();
            List<List<int>> arrs = new List<List<int>>();
            arrs.Add(new List<int> { 1, 2, 3, 4 });
            arrs.Add(new List<int> { 1, 2, 5, 6, 7 });
            arrs.Add(new List<int> { 9, 10, 1, 5, 2, 3 });

            var ans = question.IntersectionOfArraysSolver(arrs);

            
        }

        static void Run_ShortestRangeInKSortedArrays()
        {
            DataStructure.ShortestRangeInKSortedArrays question = new DataStructure.ShortestRangeInKSortedArrays();

            List<List<int>> arrs = new List<List<int>>();
            arrs.Add(new List<int>() { 4, 10, 15, 24 });
            arrs.Add(new List<int>() { 0, 9, 12, 20 });
            arrs.Add(new List<int>() { 5, 18, 22, 30 });

            var ans = question.ShortestRange(arrs);
        }

        //lint 604
        static void Run_WindowSum()
        {
            TwoPointers.WindowSum question = new TwoPointers.WindowSum();
            int[] nums = { 0, 1, 2, 3, 4};
            var ans = question.WinSumPractice(nums, 3);
           // var ans = question.WinSum(nums, 3);
        }


        //1564
        static void Run_IntervalSeaerch()
        {
            BinarySearch.IntervalSearch question = new BinarySearch.IntervalSearch();
            List<List<int>> intervalList = new List<List<int>>();
            intervalList.Add(new List<int>() { 100, 1100 });
            intervalList.Add(new List<int>() { 1000, 2000 });
            intervalList.Add(new List<int>() { 5500, 6500 });

            var ans = question.IsInterval(intervalList, 6000);
        }

        // 1479 Can Reach The Endpoint
        static void Run_CanReachTheEndpoint()
        {
            BFS.CanReachTheEndpoint question = new BFS.CanReachTheEndpoint();
            int[,] map = new int[3,3];  //[1,1,1],
            map[0, 0] = 1;              //[1,1,1],
            map[1, 0] = 1;              //[1,1,9]
            map[2, 0] = 1;
            map[0, 1] = 1;
            map[1, 1] = 1;
            map[2, 1] = 1;
            map[0, 2] = 1;
            map[1, 2] = 1;
            map[2, 2] = 9;
            var ans = question.CanReachEndpoint(map);
        }

        //269
        static void AlienDictionary()
        {
            TopologicalSort.AlienDictionary question = new TopologicalSort.AlienDictionary();
            
            //string[] words = { "wrt", "wrf", "er", "ett", "rftt" };
            string[] words = { "z", "z" };
            var ans = question.AlienOrder(words);
            
        }

        // lint 573
        static void Run_BuildPostOffice()
        {
            BFS.BuildPostOffice question = new BFS.BuildPostOffice();
            int[,] grid = { { 0, 1, 0, 0, 0 },
                            { 1, 0, 0, 2, 1 },
                            { 0, 1, 0, 0, 0}};

            var ans = question.ShortestDistance(grid);
        }

        //597
        static void Run_SubtreewithMaximumAverage()
        {
            TreeNode root = new TreeNode(-1);
            root.left = new TreeNode(-2);
            root.right = new TreeNode(-3);

            root.left.left = new TreeNode(-4);
            root.left.right = new TreeNode(-5);
            root.right.left = new TreeNode(-6);
            root.right.right = new TreeNode(-7);

            root.left.left.left = new TreeNode(-8);
            root.left.left.right = new TreeNode(-9);
            root.left.right.left = new TreeNode(-10);
            root.left.right.right = new TreeNode(-11);

            root.right.left.left = new TreeNode(-12);
            root.right.left.right = new TreeNode(-13);
            root.right.right.left = new TreeNode(-14);
            root.right.right.right = new TreeNode(-15);


            root.left.left.left.left = new TreeNode(-16);


            DFS.SubtreewithMaximumAverage question = new DFS.SubtreewithMaximumAverage();
            var ans = question.FindSubtree2(root);
        }

        static void BitOperation()
        {
            List<char> candidates = new List<char>() { 'a', 'b', 'c', 'a', 'c' };

            int len = candidates.Count;
            char c = candidates[0];

            for(int i = 1; i <len; i++)
            {
                c = (char)(c ^ candidates[i]);
            }

            Console.Write("unique char is :" + c);
        }

        //251
        static void Run_Flattern2DVector()
        {
            List<List<int>> matrix = new List<List<int>>();
            matrix.Add(new List<int>() { 1, 2, 3 });
            matrix.Add(new List<int>() { 4 });
            matrix.Add(new List<int>() { 5,6 });
            DataStructure.Flatten2D_Vector question = new DataStructure.Flatten2D_Vector(matrix.ToArray());
        }

        //57
        static void Run_InsertIntervals()
        {
            DataStructure.InsertInterval question = new DataStructure.InsertInterval();
            DataStructure.Interval i1 = new DataStructure.Interval(1, 3);
            DataStructure.Interval i2 = new DataStructure.Interval(6, 9);
            DataStructure.Interval i3 = new DataStructure.Interval(2, 5);
            List<DataStructure.Interval> intervals = new List<DataStructure.Interval>() { i1, i2 };
            //var ans =  question.Insert(intervals, i3);
            var ans = question.InsertPractice(intervals, i3);

        }

        // 721
        static void Run_AccountMerge()
        {
            List<List<string>> accounts = new List<List<string>>()
            {
                new List<string>() { "John", "johnsmith@mail.com", "john00@mail.com" },
                new List<string>() { "John", "johnnybravo@mail.com" },
                new List<string>() { "John", "johnsmith@mail.com", "john_newyork@mail.com" },
                new List<string>() { "Mary", "mary@mail.com" }
            };

            //List<List<string>> accounts = new List<List<string>>()
            //{
            //    new List<string>() { "David","David0@m.co","David4@m.co","David3@m.co" },
            //    new List<string>() { "David","David5@m.co","David5@m.co","David0@m.co" },
            //    new List<string>() { "David","David1@m.co","David4@m.co","David0@m.co" },
            //    new List<string>() { "David","David0@m.co","David1@m.co","David3@m.co" },
            //    new List<string>() { "David","David4@m.co","David1@m.co","David3@m.co" }
            //};


            DataStructure.AccountsMerge question = new DataStructure.AccountsMerge();
            var ans = question.AccountsMergeSolver(accounts.ToArray());
        }

        // lint 692
        static void Run_MinimumSpanningTree()
        {
            List<Connection> connections = new List<Connection>()
            {
                new Connection("B_City", "C_City", 3),
                new Connection("A_City", "B_City", 1),
                new Connection("A_City", "C_City", 2)
            };

            DataStructure.MinimumSpanningTree question = new DataStructure.MinimumSpanningTree();
            var ans = question.LowestCost(connections);
        }

        // lint 821
        static void Run_TimeIntersection()
        {
            SweepingLine.TimeIntersection question = new SweepingLine.TimeIntersection();
            List<Interval> seqA = new List<Interval>();
            Interval tempA1 = new Interval();
            tempA1.start = 1;
            tempA1.end = 2;

            Interval tempA2 = new Interval();
            tempA2.start = 5;
            tempA2.end = 100;
            seqA.Add(tempA1);
            seqA.Add(tempA2);

            List<Interval> seqB = new List<Interval>();
            Interval tempB1 = new Interval();
            tempB1.start = 1;
            tempB1.end = 6;
            Interval tempB2 = new Interval();
            tempB2.start = 7;
            tempB2.end = 9;
            seqB.Add(tempB1);
            seqB.Add(tempB2);

            var ans = question.TimeIntersectionSolverPractice(seqA, seqB);
            var ans2 = question.TimeIntersectionSolver(seqA, seqB);
        }

        //302
        static void Run_SmallestRectangleEnclosingBlackPixels()
        {
            char[,] image = new char[3, 4];
            image[0, 2] = '1';
            image[1, 1] = '1';
            image[1, 2] = '1';
            image[2, 1] = '1';
            DFS.SmallestRectangleEnclosingBlackPixels question = new DFS.SmallestRectangleEnclosingBlackPixels();
            var ans = question.MinArea(image, 0,2);
        }

        //843
        static void Run_DigitalFlip()
        {
            int[] arr = {1,0,0,1,1,1};
            DP.DigitalFlip question = new DP.DigitalFlip();
            var ans = question.FlipDigit(arr);
        }

        static void Run_MaxSubtree()
        {
            ///
            ///      1
            ///    /   \
            ///  -2     -3
            ///  / \   /  \
            /// -4     5   6
            ///
            ///

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(-2);
            root.right = new TreeNode(-3);
            root.left.left = new TreeNode(-4);

            root.right.left = new TreeNode(5);
            root.right.right = new TreeNode(6);

            DFS.MaxmumSubtree question = new DFS.MaxmumSubtree();
            var ans = question.FindSubtree(root);

        }

        static void Run_ProducerConsumer()
        {
            SystemDesign.ProducerConsumer question = new SystemDesign.ProducerConsumer();
            question.Simulate();
            Console.WriteLine("--------------");
            question.Simulate();
            Console.WriteLine("--------------");
            question.Simulate();
            Console.WriteLine("--------------");
            question.Simulate();
        }

        //460
        static void Run_LFUCache()
        {
            OOD.LFUCache cache = new OOD.LFUCache(2 /* capacity */ );

            cache.Put(1, 1);
            cache.Put(2, 2);
            var ans = cache.Get(1);       // returns 1
            cache.Put(3, 3);    // evicts key 2
            ans = cache.Get(2);       // returns -1 (not found)
            ans = cache.Get(3);       // returns 3.
            cache.Put(4, 4);    // evicts key 1.
            ans = cache.Get(1);       // returns -1 (not found)
            ans = cache.Get(3);       // returns 3
            ans = cache.Get(4);       // returns 4
        }

        //692
        static void Run_TopKFreqent()
        {
            DataStructure.TopKFrequent question = new DataStructure.TopKFrequent();
            var words = new List<string>(){ "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is", "zom" };
            var ans = question.TopKFrequentSolver(words.ToArray(), 4);
        }

        //149
        static void Run_PointsInLine()
        {
            DataStructure.MaxPointsOnLine question = new DataStructure.MaxPointsOnLine();
            List<DataStructure.Point> ps = new List<DataStructure.Point>()
            {
                new DataStructure.Point(84,250),
                new DataStructure.Point(0,0),
                new DataStructure.Point(1,0),
                new DataStructure.Point(0,-70),
                new DataStructure.Point(0,-70),
                new DataStructure.Point(1,-1),
                new DataStructure.Point(21,10),
                new DataStructure.Point(42,90),
                new DataStructure.Point(-42,230),
            };
            var ans = question.MaxPoints(ps.ToArray());
        }

        static void Run_AmazonMock()
        {
            DataStructure.SellersWithMostDupItem question = new DataStructure.SellersWithMostDupItem();
            List<string> input = new List<string>(){ "s1,p1", "s1,p2", "s1,p3", "s2,p2", "s2,p3", "s3,p3", "s4, p4"};
            var ans = question.FindSellers(input);


            BFS.GraphNode n1 = new BFS.GraphNode(1);
            BFS.GraphNode n2 = new BFS.GraphNode(2);
            BFS.GraphNode n3 = new BFS.GraphNode(3);

            //           n1
            //         /       \
            //     n2           n3
            // 
            n1.neighbors.Add(n2);
            n2.neighbors.Add(n1);
            n1.neighbors.Add(n3);
            n3.neighbors.Add(n1);

            BFS.DrawTwoColorToAdjacentNode question2 = new BFS.DrawTwoColorToAdjacentNode();
            var ans2 = question2.CanDrawTowColorInNode(n1);

            //           n1  (r)
            //         /       \
            //     n2 (b)   --     n3 (b)       cannot do it
            // 

            n2.neighbors.Add(n3);
            n3.neighbors.Add(n2);
            ans2 = question2.CanDrawTowColorInNode(n1);
        }


        static void Run_BSTSummary()
        {
            BST.BSTSummary question = new BST.BSTSummary();
            question.RunTest();
        }

        //273
        static void Run_IntegerEnglishWords()
        {
            DataStructure.IntegerEnglishWords question = new DataStructure.IntegerEnglishWords();
            var ans = question.NumberToWords(30);
        }

        //56
        static void Run_MergeIntervals()
        {
            SweepingLine.MergeIntervals question = new SweepingLine.MergeIntervals();
            List<Interval> input = new List<Interval>()
            {
                new Interval() { start = 1, end = 4},
                new Interval() { start = 0, end = 4}

            };
            var ans = question.Merge(input);
        }

        static void Run_NthToLastNode()
        {
            DataStructure.NthToLastNode question = new DataStructure.NthToLastNode();
            DataStructure.ListNode head = new DataStructure.ListNode(1);
            head.next = new DataStructure.ListNode(2);
            head.next.next = new DataStructure.ListNode(3);
            var ans = question.FindNtoLastNode(head, 3);
        }

        //616
        static void Run_AddBoldTag()
        {
            StringRelated.AddBoldTaginString question = new StringRelated.AddBoldTaginString();
            string[] dict = { "aaa", "aab", "bc" };

            var ans = question.AddBoldTag("aaabbcc", dict);
        }

        //138
        static void Run_CopyRandomList()
        {
            LL.CopyRandomList question = new LL.CopyRandomList();
            LL.RandomListNode head = new LL.RandomListNode(1);

            var ans = question.CopyRandomListSolver(head);
        }

        //973
        static void Run_ReorderLogFiles()
        {
            StringRelated.ReorderLogFiles question = new StringRelated.ReorderLogFiles();
            string[] intput = { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo" };
            var res = question.ReorderLogFilesSolverInplace(intput);
        }
        //755
        static void Run_PourWater()
        {
            DataStructure.PourWater question = new DataStructure.PourWater();
            int[] height = { 2, 1, 1, 2, 1, 2, 2};
            var ans = question.PourWaterSolver(height, 4, 5);
        }


        //60
        static void Run_PermutationSequence()
        {
            DP.PermutationSequence question = new DP.PermutationSequence();
            var ans = question.GetPermutation(n:3, k:3);
        }

        //720
        static void Run_LongestWordDictionary()
        {
            DataStructure.LongestWordDictionary question = new DataStructure.LongestWordDictionary();

            string[] input = { "k", "lg", "it", "oidd", "oid", "oiddm", "kfk", "y", "mw", "kf", "l", "o", "mwaqz", "oi", "ych", "m", "mwa" };

            var ans = question.LongestWordPractice(input);

        }

        // 787
        static void Run_FlightCost()
        {
            //[[0, 1, 100], [1,2,100], [0,2,500]]
            int[][] flight = new int[3][];
            flight[0] = new int[3] { 0,1,100};
            flight[1] = new int[3] { 1,2,100};
            flight[2] = new int[3] { 0, 2, 500 };
            DP.CheapestFlightsWithinKStops question = new DP.CheapestFlightsWithinKStops();
            var ans = question.FindCheapestPrice(3, flight, 0, 2, 1);


        }

        static void Main(string[] args)
        {

            //https://neil.fraser.name/writing/sync/ Differential Synchronization
            // TCP面试常见题 https://blog.csdn.net/libaineu2004/article/details/78850227

            //RockMQ  producer consumer https://www.jianshu.com/p/453c6e7ff81c
            //算法大全（3） 二叉树 http://www.cnblogs.com/Jax/archive/2009/12/28/1633691.html
            //https://github.com/yuzhangcmu/LeetCode/blob/master/tree/TreeDemo.java
            //787
            Run_FlightCost();
            //720
            Run_LongestWordDictionary();
            //60
            Run_PermutationSequence();

            //755
            Run_PourWater();
            //973
            Run_ReorderLogFiles();

            //138
            Run_CopyRandomList();

            //616
            Run_AddBoldTag();

            Run_NthToLastNode();

            //821
            Run_TimeIntersection();
            //56
            Run_MergeIntervals();
            //273
            Run_IntegerEnglishWords();
            //347
            Run_TopKFrequent();
            //200
            Run_NumberOfIsland();
            // Amazon
            Run_PointsInLine();
            Run_AmazonMock();

            Run_BSTSummary();
            //269
            AlienDictionary();
            //1479
            Run_CanReachTheEndpoint();
            //1564
            Run_IntervalSeaerch();
            //604
            Run_WindowSum();

            Run_MaxSubtree();

            // http://blog.sina.com.cn/s/blog_eb52001d0102v1si.html
            // C# big o http://c-sharp-snippets.blogspot.com/2010/03/runtime-complexity-of-net-generic.html           
            //692
            Run_TopKFreqent();
            //460
            Run_LFUCache();

            Run_ProducerConsumer();

            

            //340
            Run_LongestSubstringAtMostKDistinctChar();
            //4
            Run_Merge2SortedArrays();

            //57
            Run_InsertIntervals();

            //680
            Run_SplitString();
            //291
            Run_WordPattern();

            //624
            Run_RemoveSubstrings();

            //474
            Run_OneAndZero();
            //132
            Run_Palindrome_Partitioning_II();

            //843
            Run_DigitalFlip();
            //322
            Run_CointChange();
            //674, 300
            Run_LongestContinuousIncreasingSubsequence();

            //302
            Run_SmallestRectangleEnclosingBlackPixels();

            

            //84
            Run_LargestRectangle();
            
            // lint 575
            Run_ExpandExpression();
            // 692
            Run_MinimumSpanningTree();

            //721
            Run_AccountMerge();

            //297
            Run_SerializeDeserializeBinaryTree();
            //53
            Run_MaxSumSubarray();

            
            
            //138,325
            Run_SubarraySum();

            
            //251
            Run_Flattern2DVector();

            BitOperation();


            //681
            Run_NextClosestTime();
            //235
            Run_PrimeFactorization();
            //44
            Run_WildcardMatching();

            //lint 597
            Run_SubtreewithMaximumAverage();

            //230
            Run_KthSmallestElementInBST();

            //596
            Run_MinSubtree();
            // 573
            Run_BuildPostOffice();
            
            //133
            Run_CloneGraph();

            // lint 382
            Run_TriangleCount();

            
            //464
            Run_SortIntegers();

            Run_ShortestRangeInKSortedArrays();

            //186
            Run_ReverseWordsinaString2();

            //793
            Run_IntersectionArrays();

            //139
            Run_SubarraySumClosest();

            //548
            Run_InterSectionTwoArrays();
            //304
            Run_RangeSumQuery2();
            //307
            Run_RangeSumQueryMutable();
            //931
            Run_MedianKSortedArrays();
            //311
            Run_SparseMatrixMult();
            //944
            Run_MaximumSubmatrix();

            
            //577
            Run_MergeKSortedIntervalLists();

            //88
            Run_MergeSortedArray();
            //https://blog.csdn.net/u012289441/article/details/45192775   十道海量数据处理面试题与十个方法大总结

            // 839
            Run_MergeTwoSortedIntervalLists();

            //104
            Run_MergeKSortedArrays104();
            //23
            Run_MergeKSortedList();
            //613
            Run_HighFive();
            

            //544
            Run_TopKLargestNumbers();
            //612
            Run_KClosestPoints();
    
            //264
                Run_UglyNumber();
            //380
            Run_RandomizedSet();
            //387
            Run_FirstUniqueCharacterinaString();
            //31
            Run_NextPermutation();
            //127
            Run_WordLadder();
            
            //17
            Run_LetterCombinationsPhoneNumber();
            //51
            Run_NQueen();
            //10
            Run_StringPermutation();
            //47
            Run_PermuteUnique();
            //46
            Run_permuteIntArray();

            
            //22
            Run_GenerateParenthesis();
            //93
            Run_RestporeIPAddress();
            //139,140
            Run_WordBreak();
            //301
            Run_RemoveInvalidParentheses();
            //77
            Run_Combinations();
            //78
            Run_SubSets();

            //79
            Run_SubSetsWithDup();
            

            // 570
            Run_FindMissingNumbers();
            
            

            // 110
            Run_BalancedBinaryTree();
            
            

            
            //103
            Run_BinaryTreeZigZag();
            
            //444
            Run_SequenceReconstruction();
            //611
            Run_KnightShortestPath();

            
            
            //207
            Run_CourceSchedule();

            //102
            Run_BinaryTreeLevelOrderTraversal();
            //443
            Run_TwoSum();
            //59, 57
            Run_ThreeSum();
            //75
            Run_SortColors();
            //215
            Run_KthLargestInArray();
            
            //26
            Run_RemoveDuplicate();


            //140
            Run_FastPower();
            //50
            Run_Pow();

            //460
            Run_FindKClosestElements();

            // 33
            Run_SearchInRotatedSortedArray();
            // 485
            Run_LastPositionOfTarget();

            

            //130
            Run_SurroundingRegions();

            //425
            Run_WordSquares();

            

            // 76
            Run_Minimum_Window_Substring();

            

            //128
            Run_Hashfunction();

            //502
            Run_strstr();
            //125
            Run_ValidPalindrome();
            
            //402
            Run_ContinuousSubarraySum();

            Run_ArrayAverage();

            


            Run_ShuffleCard();
            //lint 405
            Run_SubMatrixSum();
            //34
            Run_SearchRange();

            //146
            Run_LRUCache();

            //708
            Run_ElevatorSystem();
            //505
            Run_WebLogger();
            //215
            Run_RateLimiter();
            //486
            Run_MergeKSortedArrays();

            //556
            Run_StandardBloomFilter();

            //509
            Run_MiniYelp();
            //525
            Run_MiniUber();
            //453
            Run_FlaternTreeNodes();
    
            //529
                Run_Geohash();
           

            

            
            

            

            //10
            Run_RegularExpression();
            

            //231
            Run_Typehead();

            //500 
            Run_InvertedIndex();
            //623
            Run_KEditDistance();

            //565
            Run_HeartBeat();

            //566
            Run_GFSClient();

            

            //520
            Run_ConsistentHashing2();

            //115
            Run_DistinctSubsequences();

            //476
            Run_StoneGame();

            //232
            Run_TinyUrl();
            //97
            Run_InterleavingString();

            // 14
            Run_LongestCommonPrefix();

            Run_EditDistanceQuestion();

            //lint 77
            Run_LongestCommonSubsequence();

            //502
            Run_MiniCassandra();

            //538
            Run_MemCache();

            // 519
            Run_ConsistentHash();

            

            //5
            Run_LongestPalindromicSubstring();
            //221
            Run_MaxSquare();
            //396 394
            Run_CoinseInALine();

            //87
            Run_ScrambleString();
            //312
            Run_BurstBalloon();
            //355
            Run_DesignTweetter();
            // lint 92 backpack
            Run_Backpack();
            //516
            Run_LongestPalindromeSubseq();

            //218
            Run_SkyLine();
            //287
            Run_FindDuplicateNumber();
            // 142
            Run_LinkedListcycle2();
            //162
            Run_FindPeakElemet();
            //183 lint
            Run_WoodCut();
            
            //29
            Run_Divide2Integer();
            //391 lint 
            Run_NumberOfAirplanesTheSky();
            //643
            Run_MaxAvgSubarray();
            //367
            Run_PerfectSquare();
            //48
            Run_RotateImage();
            //654
            Run_MaxBinaryTree();
            //295
            Run_DataStreamMedian();
            //346
            Run_MovingAverage();
            //480 ,239
            Run_SlidingWindow();
            // 407
            Run_TrapRainWater();
            
            

            Run_MyQueue();
            //437
            Run_CopyBooks();
            

            
            
            
            //121, 151,  309
            Run_BestTimeBuySellStock();

            
            //256  I  265 II
            Run_PaintHouse();

            // 198 and 740
            Run_HouseRobber_DeleteAndEarn();

            //91
            Run_DecodeWays();
            
            //361
            Run_BombEnemy();
            //338
            Run_CountingBits();
            //64
            Run_MinimumPathSum();

            //62,63
            Run_UniquePaths();
            // 79
            Run_WordSearch();

            
            //323
            Run_NumberConnectedComponentsInUG();
            //211
            Run_WordDictionary();
            //261
            Run_GraphValidTree();
            //305
            Run_NumberOfIsland2();

            // lintcode 422
            Run_Trie();
            
            // Lintcode 591
            Run_ConnectingGraph3();

            //Lintcode 589
            Run_ConnectingGraph();

            // Lintcode 590
            Run_ConnectingGraph2();

            

            
            //378
            Run_KthSmallestElementInMatrix();
            // 55
            Run_JumpGame();
            //45
            Run_MinJumpGame();
            //49
            Run_GroupAnagrams();

            //152
            Run_MaxProductArray();
            
            
            
            //3
            Run_LongestSubstringWithoutRepeatingCharacters();
            //209
            Run_MinSuzeSubArraySum();

            
            
    
            
            
            
            //// 746, 70
            Run_MinCostClimbingStairs();

            //35
            Run_SearchInsertPosition();
            //724
            Run_FindPivotIndex();
            //747
            Run_LargestNumberAtLeastTwiceOthers();
            
            //737
            Run_Sentence_Similarity();
            //494
            Run_TargetSum();
            
            

            //377
            Run_CombinationSum4();

            
            //153
            Run_FindMinimumInRotatedSortedArray();

           
            
            
            //216
            Run_CombinationSum3();
    
            //169
            Run_MajorityElement();
            
      
           
            

            

            

            //159   Not run in leetcode
            Run_lengthOfLongestSubstringTwoDistinct();
            

            //438 
            Run_AnagramSubstring();
            //455
            Run_AssignCookies();
            
            
            // 409
            Run_Longest_Palindrome();
            //131
            Run_Palindrome_Partitioning();
            //267
            Run_PalindromePermutation();
            
            
            //39
            Run_CombinationSumAllowDuplicate();
            //40
            Run_CombinationSumNoDuplicate();
            
            
            Run_LowestCommonAncestorINBTree();
            
            Run_KMP_Question();
        }
    }
}
