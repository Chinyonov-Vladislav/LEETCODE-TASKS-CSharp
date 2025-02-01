using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task965
{
    /*
     965. Однозначное двоичное дерево
    Двоичное дерево является однозначным, если все узлы в нём имеют одинаковое значение.
    Учитывая root двоичного дерева, верните trueесли заданное дерево является однозначным, или false в противном случае.
     */
    public class Task965 : InfoBasicTask
    {
        public Task965(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(1, new TreeNode(1, new TreeNode(1), new TreeNode(1)), new TreeNode(1, null, new TreeNode(1)));
            Console.WriteLine(isUnivalTree(root) ? "Бинарное дерево является однозначным" : "Бинарное дерево не является однозначным");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isUnivalTree(TreeNode root)
        {
            if (root == null)
            {
                return false;
            }
            List<int> values = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<TreeNode> visitedNodes = new List<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (!visitedNodes.Contains(treeNode))
                {
                    visitedNodes.Add(treeNode);
                }
                if (treeNode.left == null && treeNode.right == null)
                {
                    values.Add(treeNode.val);
                }
                else if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                    values.Add(treeNode.val);
                }
                else if (treeNode.right != null && !visitedNodes.Contains(treeNode.right))
                {

                    stack.Push(treeNode);
                    stack.Push(treeNode.right);
                    values.Add(treeNode.val);
                }
            }
            return new HashSet<int>(values.ToArray()).Count == 1;
        }
    }
}
