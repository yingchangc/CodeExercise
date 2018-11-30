using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class BSTSummary
    {
        private TreeNode BuildDefaultRoot()
        {
            //    1
            //   /  \  
            //  2    3
            // / \   / \ 
            //4   5  6  7 
            //     \
            //      8
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.left.right.right = new TreeNode(8);

            root.right = new TreeNode(3);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            return root;
        }

        // sequential insert
        private TreeNode SequentialBuildRootFromArray(int[] arr)
        {
            if (arr ==null)
            {
                return null;
            }

            TreeNode root = new TreeNode(arr[0]);
            
            for(int i = 1; i < arr.Length; i ++)
            {
                InsertSequential(root, arr[i]);
            }

            return root;
        }

        private TreeNode InsertSequential(TreeNode node, int val)
        {
            if (node ==null)
            {
                return new TreeNode(val);
            }

            if (val <= node.val)
            {
                node.left = InsertSequential(node.left, val);
            }
            else
            {
                node.right = InsertSequential(node.right, val);
            }

            return node;
        }

        private TreeNode BuildRootFromSortedArray(int[] sortedArr)
        {
            return Insert(sortedArr, 0, sortedArr.Length-1);
        }

        private TreeNode Insert(int[] arr, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            int mid = left + (right - left) / 2;
            var curr = new TreeNode(arr[mid]);

            curr.left = Insert(arr, left, mid - 1);
            curr.right = Insert(arr, mid + 1, right);
            return curr;
        }

        public void RunTest()
        {
            /*
             *                5
             *             4     20 
             *           2     19     21
             *                18
             *               17
             *              16
             *             15
             *            14   
             */
            int[] arrForLongest1 = { 5,4,20,2,19,21,18,17,16,15,14 };
            TreeNode rootForLongest1 = SequentialBuildRootFromArray(arrForLongest1);
            var longgest1 = FindLongest(rootForLongest1);

            int[] arrForLongest = { 10, 2, 14, 1, 9, 12, 18, 8, 19, 7, 6, 5, 4 };
            TreeNode rootForLongest = SequentialBuildRootFromArray(arrForLongest);
            var longgest = FindLongest(rootForLongest);

            int[] arrForComplete = { 4,2,6,1,3,7};
            TreeNode rootForComplete = SequentialBuildRootFromArray(arrForComplete);
            bool isCompleteFalse = IsCompleteBinaryTreeRec(rootForComplete);

            int[] arrForDistance = { 1, 2, 3, 4 };
            TreeNode rootForDistance = BuildRootFromSortedArray(arrForDistance);

            var maxDistance = GetMaxDistanceRec(rootForDistance);


            int[] arrForLCA = { 1, 2 };
            TreeNode rootForLCA = SequentialBuildRootFromArray(arrForLCA);

            var ansLCA = LACRec(rootForLCA, new TreeNode(1), new TreeNode(2));

            /*
             *                  4
             *               2     6
             *              1  3   5  7
             * */
            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7 };
            int[] arr2 = { 1, 2, 3, 4, 5, 6, 7, 8};
            TreeNode root1 = BuildRootFromSortedArray(arr1);
            TreeNode root2 = BuildRootFromSortedArray(arr2);
            bool isame = isSameRec(root1, root2);

            int[] arr3 = { 4, 2,6,1,3,5,7};
            TreeNode root3 = SequentialBuildRootFromArray(arr3);
            isame = isSameRec(root1, root3);
            //    1
            //   /  \  
            //  2    3
            // / \   / \ 
            //4   5  6  7 
            //     \
            //      8
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.left.right.right = new TreeNode(8);

            root.right = new TreeNode(3);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);


            bool isCompleteNo = IsCompleteBinaryTreeRec(root);

            int leafNodeCount = GetNodeNumLeaf(root);
            int KLevelNode = GetNodeNumKthLevel(root, 3);
            var inorder = InorderTraversal(root);
            var postorder = PostorderTraversal(root);
            var preorder = PreorderTraversal(root);

            var depth = GetDepth(root);
        }

        /* 
         * 15. 找出二叉树中最长连续子串(即全部往左的连续节点，或是全部往右的连续节点）findLongest
        * 第一种解法：
        * 返回左边最长，右边最长，及左子树最长，右子树最长。
        * 
        *                 10
        *             2       14  
        *            / \     / \
        *           1   9   12   18
        *               /          19
        *              8            
        *             /
        *            7
        *           6
        *          5 
        *         4     
        *        
        *           
        * */
       public int FindLongest(TreeNode root)
       {
           var res = FindLongestHelper(root);
           return res.maxLengthSofar;
       }

       private ResultLongest FindLongestHelper(TreeNode node)
       {
           if (node == null)
           {
               return new ResultLongest(allLeft: 0, allRight: 0, maxLen: 0);
           }

           var left = FindLongestHelper(node.left);
           var right = FindLongestHelper(node.right);

           int currAllLeft = 1 + left.allNodesToLeft;
           int currAllRight = 1 + right.allNodesToRight;

           int currLevelLongst = currAllLeft >= currAllRight ? currAllLeft : currAllRight;

           currLevelLongst = Math.Max(currLevelLongst, Math.Max(left.maxLengthSofar, right.maxLengthSofar));

           return new ResultLongest(allLeft: currAllLeft, allRight: currAllRight, maxLen: currLevelLongst);

       }

       public class ResultLongest
       {
           public int allNodesToLeft = 0;
           public int allNodesToRight = 0;
           public int maxLengthSofar = 0;

           public ResultLongest(int allLeft, int allRight, int maxLen)
           {
               this.allNodesToLeft = allLeft;
               this.allNodesToRight = allRight;
               this.maxLengthSofar = maxLen;
           }
       }
       /*
   * 14. 判断二叉树是不是完全二叉树：isCompleteBinaryTreeRec
   * 
   * 
   *    我们可以分解为：
   *    CompleteBinary Tree 的条件是：
   *    1. 左右子树均为Perfect binary tree, 并且两者Height相同
   *    2. 左子树为CompleteBinaryTree, 右子树为Perfect binary tree，并且两者Height差1
   *    3. 左子树为Perfect Binary Tree,右子树为CompleteBinaryTree, 并且Height 相同
   *    
   *    Base 条件：
   *    (1) root = null: 为perfect & complete BinaryTree, Height -1;
   *    
   *    而 Perfect Binary Tree的条件：
   *    左右子树均为Perfect Binary Tree,并且Height 相同。
   * */
        public bool IsCompleteBinaryTreeRec(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);

            bool shouldHaveStopped = false;

            while(que.Count > 0)
            {
                int levelCount = que.Count;
                for(int i =0; i <levelCount; i++)
                {
                    var temp = que.Dequeue();
                    if (temp.left != null)
                    {
                        if (shouldHaveStopped == true)
                        {
                            return false;
                        }
                        que.Enqueue(temp.left);
                    }
                    else
                    {
                        // 一旦某元素没有左节点或是右节点，则之后所有的元素都不应有子元素。
                        shouldHaveStopped = true;
                    }

                    if (temp.right != null)
                    {
                        if (shouldHaveStopped == true)
                        {
                            return false;
                        }
                        que.Enqueue(temp.right);
                    }
                    else
                    {
                        shouldHaveStopped = true;
                    }

                }  
            }

            return true;
        }

        //783. Minimum Distance Between BST Nodes
        //https://leetcode.com/problems/minimum-distance-between-bst-nodes/description/
        /// <summary>
        /// Input: root = [4,2,6,1,3,null,null]
        ///Output: 1
        ///Explanation:
        ///Note that root is a TreeNode object, not an array.
        ///
        ///The given tree[4, 2, 6, 1, 3, null, null] is represented by the following diagram:
        ///
        ///          4
        ///        /   \
        ///      2      6
        ///     / \    
        ///    1   3  
        ///
        ///while the minimum difference in this tree is 1, it occurs between node 1 and node 2, also between node 3 and node 2.
        ///
        /// sol:
        /// bescause it is bst,  inorder should be sorted
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDiffInBST(TreeNode root)
        {
            if (root ==null)
            {
                return Int32.MaxValue;
            }

            Stack<TreeNode> stk = new Stack<TreeNode>();
            InsertAllLeft(root, stk);

            TreeNode pre = null;
            int mindiff = Int32.MaxValue;
            while(stk.Count>0)
            {
                var temp = stk.Pop();

                if (pre != null)
                {
                    mindiff = Math.Min(mindiff, (temp.val - pre.val));
                }

                pre = temp;

                InsertAllLeft(temp.right, stk);
            }

            return mindiff;
        }

        
        

        /*
    *  * 12. 求二叉树中节点的最大距离：getMaxDistanceRec
    *  
    *  首先我们来定义这个距离：
    *  距离定义为：两个节点间边的数目.
    *  如：
    *     1
    *    / \
    *   2   3
    *        \
    *         4
    *   这里最大距离定义为2，4的距离，为3.      
    * 求二叉树中节点的最大距离 即二叉树中相距最远的两个节点之间的距离。 (distance / diameter) 
    * 递归解法：
    * 返回值设计：
    * 返回1. 深度， 2. 当前树的最长距离  node count 
    */
        public int GetMaxDistanceRec(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var resut = GetMaxDistanceHelper(root);

            return resut.maxNodeCount-1;  // -1 for distance
        }

        public ResultNode GetMaxDistanceHelper(TreeNode node)
        {
            if (node ==null)
            {
                return new ResultNode();
            }

            var left = GetMaxDistanceHelper(node.left);
            var right = GetMaxDistanceHelper(node.right);

            int currDistance = 1 + left.Depth + right.Depth;
            int currDepth = 1 + Math.Max(left.Depth, right.Depth);

            if (currDistance > left.maxNodeCount && currDistance > right.maxNodeCount)
            {
                return new ResultNode(maxDist: currDistance, depth: currDepth);
            }
            else if (left.maxNodeCount >= right.maxNodeCount)
            {
                return new ResultNode(maxDist: left.maxNodeCount, depth: currDepth);
            }
            else
            {
                return new ResultNode(maxDist: right.maxNodeCount, depth: currDepth);
            }
        }

        public class ResultNode
        {
            public int maxNodeCount = Int32.MinValue;
            public int Depth = 0;
            public ResultNode()
            {
               
            }

            public ResultNode(int maxDist, int depth)
            {
                this.maxNodeCount = maxDist;
                this.Depth = depth;
            }
        }


        bool GlobalFoundLAC = false;

        /* 11. 求二叉树中两个节点的最低公共祖先节点：
     * Recursion Version:
     * LACRec
     * 1. If found in the left tree, return the Ancestor.
     * 2. If found in the right tree, return the Ancestor.
     * 3. If Didn't find any of the node, return null.
     * 4. If found both in the left and the right tree, return the root.
     * */
        public TreeNode LACRec(TreeNode root, TreeNode node1, TreeNode node2)
        {
            if (root == null || node1 == null || node2 == null)
            {
                return null;
            }

            TreeNode ans = LACRecHelper(root, node1, node2);
            if (GlobalFoundLAC == true)
            {
                return ans;
            }
            return null;
        }
        public TreeNode LACRecHelper(TreeNode root, TreeNode node1, TreeNode node2)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode left = null;
            TreeNode right = null;

            if ((root.val == node1.val) && (root.val == node2.val))
            {
                GlobalFoundLAC = true;
                return root;
            }
            else if (root.val == node1.val)
            {
                left = root;
                right = LACRecHelper(root.right, node1, node2);
            }
            else if (root.val == node2.val)
            {
                left  = LACRecHelper(root.left, node1, node2);
                right = root;
            }
            else
            {
                left = LACRecHelper(root.left, node1, node2);
                right = LACRecHelper(root.right, node1, node2);
            }

            if (left != null && right != null)
            {
                GlobalFoundLAC = true;
                return root;
            }
            return left != null ? left : right;
        }


       

        public TreeNode mirrorCopy(TreeNode root)
        {
            if (root ==null)
            {
                return null;
            }

            TreeNode leftCopy = mirrorCopy(root.left);
            TreeNode rightCopy = mirrorCopy(root.right);

            TreeNode curr = new TreeNode(root.val);
            curr.right = leftCopy;
            curr.left = rightCopy;

            return curr;

        }



        bool GlobalIsAVL = true;

        /*
 * 
 *  9. 判断二叉树是不是平衡二叉树：isAVLRec
 *     1. 左子树，右子树的高度差不能超过1
 *     2. 左子树，右子树都是平衡二叉树。 
 *      
 */
        public bool isAVLRec(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            LongestPath(root);

            return GlobalIsAVL;

        }

        private int LongestPath(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftDepth = LongestPath(node.left);
            int rightDepth = LongestPath(node.right);

            if (Math.Abs(leftDepth - rightDepth) > 1)
            {
                GlobalIsAVL = false;
            }

            return 1 + Math.Max(leftDepth, rightDepth);

        }

        /*
     * 8. 判断两棵二叉树是否相同的树。 
     * 递归解法：  
     * （1）如果两棵二叉树都为空，返回真 
     * （2）如果两棵二叉树一棵为空，另一棵不为空，返回假  
     * （3）如果两棵二叉树都不为空，如果对应的左子树和右子树都同构返回真，其他返回假 
     * 
     * 
     * /*
     * 8. 判断两棵二叉树是否相同的树。
     * 迭代解法 
     * 我们直接用中序遍历来比较就好啦 
     * */
        public bool isSameRec(TreeNode r1, TreeNode r2)
        {
            if (r1 == null && r2 == null)
            {
                return true;
            }
            else if (r1 ==null || r2 == null)
            {
                return false;
            }
            else if (r1.val != r2.val)
            {
                return false;
            }

            return isSameRec(r1.left, r2.left) && isSameRec(r1.right, r2.right);
        }

        /*
            * 7. getNodeNumLeaf
         */
        public int GetNodeNumLeaf(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);

            int levelCount = 0;
            while(que.Count > 0)
            {
                levelCount = que.Count;

                for (int i = 0; i <levelCount; i++)
                {
                    var temp = que.Dequeue();
                    if (temp.left != null)
                    {
                        que.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        que.Enqueue(temp.right);
                    }
                }
            }

            return levelCount;
        }
        /*
 *  * 6. 求二叉树第K层的节点个数：getNodeNumKthLevelRec, getNodeNumKthLevel 
 * */
        public int GetNodeNumKthLevel(TreeNode root, int k)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);

            int currLevel = 1;
            while (que.Count > 0)
            {
                int levelSize = que.Count;
                
                if (k == currLevel)
                {
                    return levelSize;
                }

                for(int i = 0; i <levelSize; i++)
                {
                    var temp = que.Dequeue();

                    if (temp.left!= null)
                    {
                        que.Enqueue(temp.left);
                    }

                    if (temp.right != null)
                    {
                        que.Enqueue(temp.right);
                    }
                }
                currLevel++;
            }

            return 0;
        }

        /// <summary>
        /// https://www.lintcode.com/problem/convert-sorted-list-to-binary-search-tree/description
        /// Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
        ///                2
        /// 1->2->3  =>   / \
        ///              1   3
        /// 
        /// O(nlogn)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            return ConvertToBST(head);
        }

        private TreeNode ConvertToBST(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            // yic:  find mid to cut
            ListNode pre = null;
            ListNode slow = head;
            ListNode fast = head;

            while(fast != null && fast.next!=null && fast.next.next!=null)
            {
                //at leaset has three
                pre = slow;
                slow = slow.next;
                fast = fast.next.next;
            }


            TreeNode midTreeN = new TreeNode(slow.val);

            // cut pre - mid
            if (pre != null)
            {
                pre.next = null;
            }

            midTreeN.left = pre == null ? null : ConvertToBST(head);
            midTreeN.right = ConvertToBST(slow.next);

            return midTreeN;
        }

       
        /// <summary>
        ///        1
        ///       2  3
        ///      4 5
        /// Depth First Traversals:
        /// (a) Inorder(Left, Root, Right) : 4 2 5 1 3
        ///    use stack and go all left
        /// 
        /// 
        /// (b) Preorder(Root, Left, Right) : 1 2 4 5 3
        /// (c) Postorder(Left, Right, Root) : 4 5 2 3 1
        /// 
        ///    use stack and insert 
        ///    pre: right, left    | post:  left, right  (done then reverse)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// 
        public List<TreeNode>InorderTraversal(TreeNode root)
        {
            List<TreeNode> ans = new List<TreeNode>();

            if (root ==null)
            {
                return ans;
            }

            Stack<TreeNode> stk = new Stack<TreeNode>();

            InsertAllLeft(root, stk);

            while (stk.Count> 0)
            {
                var temp = stk.Pop();
                ans.Add(temp);

                // insert right's all left as next
                InsertAllLeft(temp.right, stk);
            }

            return ans;
        }

        private void InsertAllLeft(TreeNode node, Stack<TreeNode> stk)
        {
            while(node != null)
            {
                stk.Push(node);
                node = node.left;
            }
        }

        public List<TreeNode> PostorderTraversal(TreeNode root)
        {
            List<TreeNode> ans = new List<TreeNode>();
            if (root == null)
            {
                return ans;
            }

            Stack<TreeNode> stk = new Stack<TreeNode>();

            stk.Push(root);

            while(stk.Count > 0)
            {
                var temp = stk.Pop();
                ans.Add(temp);

                // left first
                if (temp.left != null)
                {
                    stk.Push(temp.left);
                }
                if (temp.right != null)
                {
                    stk.Push(temp.right);
                }
            }

            // reverse
            int left = 0;
            int right = ans.Count-1;

            while(left < right)
            {
                var temp = ans[left];
                ans[left] = ans[right];
                ans[right] = temp;
                left++;
                right--;
            }

            return ans;
            
        }
        public List<TreeNode> PreorderTraversal(TreeNode root)
        {
            List<TreeNode> ans = new List<TreeNode>();
            
            if (root ==null)
            {
                return ans;
            }

            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(root);

            while(stk.Count > 0)
            {
                var temp = stk.Pop();
                ans.Add(temp);

                // right first
                if (temp.right != null)
                {
                    stk.Push(temp.right);
                }

                if (temp.left != null)
                {
                    stk.Push(temp.left);
                }
            }
            return ans;
        }


        //2.1 求二叉树的深度: getDepthRec（递归），getDepth 
        public int GetDepthRec(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftDepth = GetDepthRec(root.left);
            int rightDepth = GetDepthRec(root.right);
            return 1 + Math.Max(leftDepth, rightDepth);
        }

        //2.2 求二叉树的深度: getDepth 
        // 可以用 level LevelOrderTraversal 来实现，我们用一个dummyNode来分隔不同的层，这样即可计算出实际的depth.
        public int GetDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);

            int depth = 0;
            while(que.Count > 0)
            {
                int levelSize = que.Count;
                depth++;
                for (int i = 0; i <levelSize; i++)
                {
                    var temp = que.Dequeue();
                    if (temp.left != null)
                    {
                        que.Enqueue(temp.left);
                    }
                    if (temp.right!=null)
                    {
                        que.Enqueue(temp.right);
                    }
                }
            }
            return depth;
        }

        //1.1 求二叉树中的节点个数: getNodeNumRec（递归），getNodeNum（迭代） 
        public int GetNodeNumRec(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + GetNodeNumRec(root.left) + GetNodeNumRec(root.right);
        }

        /** 
        *  1.2求二叉树中的节点个数迭代解法O(n)：基本思想同LevelOrderTraversal， 
        */
        public int GetNodeNum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);

            int count = 0;

            while (que.Count > 0)
            {
                int size = que.Count;

                for (int i = 0; i < size; i++)
                {
                    var temp = que.Dequeue();
                    count++;

                    if (temp.left != null)
                    {
                        que.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        que.Enqueue(temp.right);
                    }
                }
            }
            return count;

        }
    }
}
