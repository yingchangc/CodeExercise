using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.BST
{
    class BSTSummary
    {
        public void RunTest()
        {
            //    1
            //   /  \  
            //  2    3
            // / \   / \ 
            //4   5  6  7 
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            int KLevelNode = GetNodeNumKthLevel(root, 3);
            var inorder = InorderTraversal(root);
            var postorder = PostorderTraversal(root);
            var preorder = PreorderTraversal(root);

            var depth = GetDepth(root);
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
