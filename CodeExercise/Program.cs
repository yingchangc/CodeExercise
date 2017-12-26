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

        //121
        static void Run_BestTimeBuySellStock()
        {
            int[] test = { 7, 1, 5, 3, 6, 4 };

            DP.BestTimeBuySellStock question = new DP.BestTimeBuySellStock();
            int profit = question.MaxProfit(test);

            // diff (price(I) = price(I-1)) from test
            int[] diff = { 0, -6, 4, -2, 3, -2 };
            profit = question.MaxProfitFromDiff(diff);
        }

        //746
        static void Run_MinCostClimbingStairs()
        {
            int[] cost = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
            DP.MinCostClimbingStairs question = new DP.MinCostClimbingStairs();
            int ans = question.MinCostClimbingStairsSolver(cost);
        }

        static void Run_MajorityElement()
        {
            int[] nums = { 1, 4, 5, 7, 1, 3, 1, 3, 3, 1, 1,1,1 };
            //int[] nums = { 1,1,1,3,3 };
            DP.MajorityElement question = new DP.MajorityElement();
            int majornum = question.MajorityElementSolver(nums);
        }

        static void Main(string[] args)
        {
            //141
            Run_MajorityElement();
            // 746
            Run_MinCostClimbingStairs();

            //121
            Run_BestTimeBuySellStock();
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
