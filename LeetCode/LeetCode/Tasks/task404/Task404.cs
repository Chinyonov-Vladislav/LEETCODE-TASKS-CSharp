using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task404
{
    /*
     404. Сумма оставшихся листьев
    Учитывая root двоичного дерева, верните сумму всех левых листьев.
    Лист — это узел без дочерних узлов.Левый лист — это лист, который является левым дочерним узлом другого узла.
    https://leetcode.com/problems/sum-of-left-leaves/description/
     */
    public class Task404 : InfoBasicTask
    {
        public Task404(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            int result = sumOfLeftLeaves(treeNode);
            Console.WriteLine($"Сумма левых листьев в дереве = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int sumOfLeftLeaves(TreeNode root)
        {
            bool isLeft = false;
            int totalSum = 0;
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {

                TreeNode treeNode = stack.Pop();
                if (treeNode.left == null && treeNode.right == null)
                {
                    visitedNodes.Add(treeNode);
                    if (isLeft)
                    {
                        totalSum += treeNode.val;
                        isLeft = false;
                    }
                }
                else if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                    isLeft = true;
                }
                else if ((treeNode.left != null && visitedNodes.Contains(treeNode.left)) || treeNode.right != null)
                {
                    visitedNodes.Add(treeNode);
                    if (treeNode.right != null)
                    {
                        stack.Push(treeNode.right);
                        isLeft = false;
                    }
                }
            }
            return totalSum;
        }
    }
}
