using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            SubSets.FindSubsets(candidates);
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
            int[] nums = { 2, 2, 1, 1 };
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
            string test = "bbcxcbm";

            int res = DP.PalindromePartition.MinCut(test);
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
            string test = "catsanddog";

            // pre test code
            string subleft = test.Substring(0, 0);
            string subRight = test.Substring(test.Length);  // Note will be empty string

            string[] worddict = { "cat", "cats", "and", "sand", "dog" };
            DP.WordBreak question = new DP.WordBreak();
            //139
            bool canBreak = question.CheckWordBreak(test, worddict);

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
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            DP.MaximumSubarray question = new DP.MaximumSubarray();
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
            int[] heights = { 2, 1, 5, 6, 2, 3 };
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
            var ans = question.IsMatch("ABx", "A?*");
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
            int[] arr = { -3, 1, 2, -3, 4 , -4};
            var ans = question.SubarraySumSolver(arr);

            int[] arr2 = { 1, -1, 1, 1, -1 };
            var ans2 = question.SubarraySumK(arr2, 0);

            int[] arr3 = { 1, -1, 5, -2, 3 };
            var ans3 = question.MaxSubArrayLen(arr3, 3);

            int[] arr4 = { 1, 2, 3, 4 };
            var ans4 = question.subarraySumII(arr4, 1, 3);
        }

        //387
        static void Run_FirstUniqueCharacterinaString()
        {
            DataStructure.FirstUniqueCharacterinaString question = new DataStructure.FirstUniqueCharacterinaString();
            var ans = question.FirstUniqChar("loveleetcode");
        }

        //186
        static void Run_ReverseWordsinaString2()
        {
            DataStructure.ReverseWordsinaString2 question = new DataStructure.ReverseWordsinaString2();
            string str = "s the  sky is blue  e ";
            question.ReverseWords(str.ToCharArray());
        }

        static void Main(string[] args)
        {
            // C# big o http://c-sharp-snippets.blogspot.com/2010/03/runtime-complexity-of-net-generic.html
            //138,325
            Run_SubarraySum();

            //186
            Run_ReverseWordsinaString2();

            //387
            Run_FirstUniqueCharacterinaString();
            

            //44
            Run_WildcardMatching();

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

            //474
            Run_OneAndZero();

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

            //674, 300
            Run_LongestContinuousIncreasingSubsequence();

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
            //84
            Run_LargestRectangle();
            // lint 575
            Run_ExpandExpression();

            Run_MyQueue();
            //437
            Run_CopyBooks();
            //132
            Run_Palindrome_Partitioning_II();

            
            
            
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

            

            //200
            Run_NumberOfIsland();
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
            //322
            Run_CointChange();
            
            //340
            Run_LongestSubstringAtMostKDistinctChar();
            //3
            Run_LongestSubstringWithoutRepeatingCharacters();
            //209
            Run_MinSuzeSubArraySum();

            
            
    
            
            //53
            Run_MaxSumSubarray();
            
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
            
      
            //139,140
            Run_WordBreak();
            

            

            // 76
            Run_Minimum_Window_Substring();

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
            //47
            Run_PermuteUnique();
            //79
            Run_SubSetsWithDup();
            //78
            Run_SubSets();
            //39
            Run_CombinationSumAllowDuplicate();
            //40
            Run_CombinationSumNoDuplicate();
            
            
            Run_LowestCommonAncestorINBTree();
            Run_permuteIntArray();
            Run_KMP_Question();
        }
    }
}
