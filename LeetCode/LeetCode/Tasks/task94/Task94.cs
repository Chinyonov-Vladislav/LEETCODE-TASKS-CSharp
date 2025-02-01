using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task94
{
    /*
    94. Обход бинарного дерева по порядку
    Учитывая root двоичного дерева, верните последовательный обход его узлов.
    https://leetcode.com/problems/binary-tree-inorder-traversal
     */
    public class Task94 : InfoBasicTask
    {
        public Task94(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode tree = new TreeNode();
            tree.val = 1;
            tree.left = new TreeNode(2, new TreeNode(4), new TreeNode(5, new TreeNode(6), new TreeNode(7)));
            tree.right = new TreeNode(3, null, new TreeNode(8, new TreeNode(9)));
            IList<int> order = inorderTraversal(tree);
            printIListInt(order, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public IList<int> inorderTraversal(TreeNode root)
        {
            List<int> orderList = new List<int>();
            if (root == null)
            {
                return orderList;
            }
            if (root.left != null)
            {
                travel(root.left, orderList);
            }
            orderList.Add(root.val);
            if (root.right != null)
            {
                travel(root.right, orderList);
            }
            return orderList;
        }
        private void travel(TreeNode node, List<int> orderList)
        {
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(node);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (treeNode.left == null && treeNode.right == null) { 
                    orderList.Add(treeNode.val);
                    visitedNodes.Add(treeNode);
                }
                else if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                }
                else if ((treeNode.left != null && visitedNodes.Contains(treeNode.left)) || treeNode.right!=null)
                {
                    orderList.Add(treeNode.val);
                    visitedNodes.Add(treeNode);
                    if (treeNode.right != null)
                    {
                        stack.Push(treeNode.right);
                    }
                }
            }
        }
    }
}
