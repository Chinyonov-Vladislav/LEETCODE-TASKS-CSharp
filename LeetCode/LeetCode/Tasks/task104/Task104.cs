using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task104
{
    public class Task104 : InfoBasicTask
    {
        /*
         104. Максимальная глубина бинарного дерева
        Учитывая root размер двоичного дерева, верните его максимальную глубину.
        Максимальная глубина двоичного дерева — это количество узлов на самом длинном пути от корневого узла до самого удалённого листового узла.
        https://leetcode.com/problems/maximum-depth-of-binary-tree/description/
         */
        public Task104(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode0 = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            TreeNode treeNode1 = new TreeNode(1, new TreeNode(2, new TreeNode(4)), new TreeNode(3, null, new TreeNode(5)));
            TreeNode treeNode2 = new TreeNode(1, new TreeNode(2));
            TreeNode treeNode3 = new TreeNode(0, new TreeNode(2, new TreeNode(1, new TreeNode(5), new TreeNode(1))), new TreeNode(4, new TreeNode(3, null, new TreeNode(6)), new TreeNode(-1, null, new TreeNode(8))));
            Console.WriteLine($"Максимальная глубина бинарного дерева = {maxDepth(treeNode0)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int currentDepth = 2;
            int maxDepth = 1;
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            visitedNodes.Add(root);
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (visitedNodes.Contains(treeNode))
                {
                    currentDepth--;
                }
                else
                {
                    visitedNodes.Add(treeNode);
                }
                if (treeNode.left == null && treeNode.right == null)
                {
                    if (currentDepth > maxDepth)
                    {
                        maxDepth = currentDepth;
                    }
                }
                else if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                    currentDepth++;
                }
                else if (treeNode.right != null && !visitedNodes.Contains(treeNode.right))
                {

                    stack.Push(treeNode);
                    stack.Push(treeNode.right);
                    currentDepth++;
                }
            }
            return maxDepth;
        }
        private int bestSolution(TreeNode root)
        {
            if (root == null) return 0;
            int left = bestSolution(root.left);
            int right = bestSolution(root.right);
            return Math.Max(left, right) + 1;
        }
    }
}
