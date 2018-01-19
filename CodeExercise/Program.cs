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

        static void Run_permuteIntArray()
        {
            int testlengh = 4;
            int[] arr = new int[testlengh];
            for (int i = 0; i< testlengh; i++)
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
            int[] candidates = { 10, 1, 2, 7, 6, 1, 5};
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
            int[] candidates = { 4,4,1,4 };
            SubSets.SubsetsWithDup(candidates);
        }

        // 47. 
        static void Run_PermuteUnique()
        {
            int[] nums = { 2,2,1,1 };
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
            bool canjump=DP.JumpGame.CanJump(nums1);

            int[] nums2 = { 3,2,1,0,4};
            canjump = DP.JumpGame.CanJump(nums2);
        }

        // 45. min Jump Game
        static void Run_MinJumpGame()
        {
            int[] nums1 = { 2,3,1,1,4 };
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

            string[] worddict = { "cat", "cats", "and", "sand", "dog"};
            DP.WordBreak question = new DP.WordBreak();
            //139
            bool canBreak = question.CheckWordBreak(test,worddict);

            var ans2_1 = question.CheckWordBreakv2(test, worddict);
            string test2 = "aaaaaaa";
            string[] worddict2 = { "aaaa", "aa", "a" };

            //140
            var ans2_2 = question.CheckWordBreakv2(test2, worddict2);
        }

        //121, 309
        static void Run_BestTimeBuySellStock()
        {
            //121
            int[] test = { 7, 1, 5, 3, 6, 4 };

            DP.BestTimeBuySellStock question = new DP.BestTimeBuySellStock();
            int profit = question.MaxProfit(test);

            // diff (price(I) = price(I-1)) from test
            int[] diff = { 0, -6, 4, -2, 3, -2 };
            profit = question.MaxProfitFromDiff(diff);

            // 309
            int[] prices = { 1, 2, 3, 0, 2 };
            profit = question.MaxProfitWithCooldown(prices);
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
            int[] nums = { 1, 4, 5, 7, 1, 3, 1, 3, 3, 1, 1,1,1 };
            //int[] nums = { 1,1,1,3,3 };
            DP.MajorityElement question = new DP.MajorityElement();
            int majornum = question.MajorityElementSolver(nums);
        }

        // 198 & 740
        static void Run_HouseRobber_DeleteAndEarn()
        {
            DP.HouseRobber_DeleteAndEarn question = new DP.HouseRobber_DeleteAndEarn();

            // 198 rob
            int[] nums1 = { 2, 3, 7, 8, 4};
            int ans1 = question.Rob(nums1);   // should be rob 2 +7 +4

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

            //674
            DP.LongestContinuousIncreasingSubsequence question = new DP.LongestContinuousIncreasingSubsequence();
            int ans = question.FindLengthOfLCIS(nums);

            // 673
            int[] num2 = { 1, 2, 4, 3, 5, 4, 7, 2};
            //int[] num2 = {3,4,-1,0,6,2,3 };
            DP.LongestIncreasingSubsequence q2 = new DP.LongestIncreasingSubsequence();
            int ans2 = q2.FindNumberOfLIS(num2);

            // 300   should be 5 [1 2 3 3 4 4 5]
            int ans3 = q2.LengthOfLIS(num2);

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

            ans = question.MinCoinChangeSolver(nums, 11);
            //int[] nums2 = { 3, 7, 405, 436};
            //ans = question.CoinChangeSolverSlow(nums2, 8839);
            //ans = question.MinCoinChangeSolver(nums2, 8839);
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
            int ans = question.NumofUniquePaths(2,2);

            int[,] grid = { {0,0,0},
                            {0,1,0},
                            {0,0,0 } };
            ans = question.UniquePathsWithObstacles(grid);

            int[,] grid2 = { { 1} };
            ans = question.UniquePathsWithObstacles(grid2);
        }

        // 53
        static void Run_MaxSumSubarray()
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            DP.MaximumSubarray question = new DP.MaximumSubarray();
            int ans = question.MaxSubArraySolver(nums);
        }

        static void Main(string[] args)
        {
            //62,63
            Run_UniquePaths();
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
            //91
            Run_DecodeWays();
            //737
            Run_Sentence_Similarity();
            //494
            Run_TargetSum();
            //121, 309
            Run_BestTimeBuySellStock();
            //322
            Run_CointChange();

            //377
            Run_CombinationSum4();

            
            //153
            Run_FindMinimumInRotatedSortedArray();

            //674
            Run_LongestContinuousIncreasingSubsequence();
            //64
            Run_MinimumPathSum();
            // 198 and 740
            Run_HouseRobber_DeleteAndEarn();
            //216
            Run_CombinationSum3();
    
            //169
            Run_MajorityElement();
            

            
            //139,140
            Run_WordBreak();
            //49
            Run_GroupAnagrams();

            // 79
            Run_WordSearch();

            // 76
            Run_Minimum_Window_Substring();

            //159   Not run in leetcode
            Run_lengthOfLongestSubstringTwoDistinct();
            //3
            Run_LongestSubstringWithoutRepeatingCharacters();

            //438 
            Run_AnagramSubstring();
            //455
            Run_AssignCookies();
            //45
            Run_MinJumpGame();
            // 55
            Run_JumpGame();
            //132
            Run_Palindrome_Partitioning_II();
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
            Run_EditDistanceQuestion();
            Run_KMP_Question();
        }
    }
}
