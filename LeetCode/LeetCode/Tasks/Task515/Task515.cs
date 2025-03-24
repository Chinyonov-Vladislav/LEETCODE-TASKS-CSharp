using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.Task515
{
    /*
     515. Найдите наибольшее значение в каждой строке дерева
    Учитывая root двоичного дерева, верните массив наибольших значений в каждой строке дерева (с индексацией от 0).
    Ограничения:
        Количество узлов в дереве будет находиться в диапазоне [0, 10^4].
        -2^31 <= Node.val <= 2^31 - 1
    https://leetcode.com/problems/find-largest-value-in-each-tree-row/description/
     */
    public class Task515 : InfoBasicTask
    {
        public Task515(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(1, new TreeNode(3, new TreeNode(5), new TreeNode(3)), new TreeNode(2, null, new TreeNode(9)));
            printTreeNode(treeNode);
            if (isValid(treeNode))
            {
                IList<int> res = largestValues(treeNode);
                for (int i = 0; i < res.Count; i++)
                {
                    Console.WriteLine($"Уровень в дереве (индексация с 0) - {i}. Наибольшее значение = {res[i]}");
                }
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(TreeNode root)
        {
            int countNodes = 0;
            if (root != null)
            {
                List<TreeNode> visitedNodes = new List<TreeNode>();
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0)
                {
                    TreeNode treeNode = stack.Pop();
                    if (!visitedNodes.Contains(treeNode))
                    {
                        visitedNodes.Add(treeNode);
                    }
                    else
                    {
                        countNodes = 0;
                    }
                    if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                    {
                        stack.Push(treeNode);
                        stack.Push(treeNode.left);
                    }
                    else if (treeNode.right != null && !visitedNodes.Contains(treeNode.right))
                    {
                        stack.Push(treeNode);
                        stack.Push(treeNode.right);
                    }
                }
            }
            int lowLimit = 0;
            int highLimit = (int)Math.Pow(10,4);
            if (countNodes < lowLimit || countNodes > highLimit)
            {
                return false;
            }
            return true;
        }
        private IList<int> largestValues(TreeNode root)
        {
            IList<int> res = new List<int>();
            if (root == null)
            {
                return res;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0)
            {
                int nodesInCurrentLevel = queue.Count;
                TreeNode treeNode = queue.Dequeue();
                int max = treeNode.val;
                queue.Enqueue(treeNode);
                for (int i = 0; i < nodesInCurrentLevel; i++)
                {
                    TreeNode current = queue.Dequeue();
                    if (current.val > max)
                    {
                        max = current.val;
                    }
                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }
                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }
                res.Add(max);
                level++;
            }
            return res;
        }
    }
}
