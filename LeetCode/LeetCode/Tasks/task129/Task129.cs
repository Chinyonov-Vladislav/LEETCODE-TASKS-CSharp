using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task129
{
    /*
     129. Суммируйте числа от корня к листу
    Вам дано root двоичного дерева, содержащего только цифры от 0 до 9.
    Каждый путь от корня к листу в дереве представляет собой число.
        Например, путь от корня к листу 1 -> 2 -> 3 представляет собой число 123.
    Верните общую сумму всех чисел от корня до листа. Тестовые примеры генерируются таким образом, чтобы ответ помещался в 32-битное целое число.
    Конечный узел - это узел, не имеющий дочерних элементов.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [1, 1000].
        0 <= Node.val <= 9
        Глубина дерева не будет превышать 10.
    https://leetcode.com/problems/sum-root-to-leaf-numbers/description/
     */
    public class Task129 : InfoBasicTask
    {
        public Task129(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(4, new TreeNode(9, new TreeNode(5), new TreeNode(1)), new TreeNode(0));
            printTreeNode(treeNode);
            if (isValid(treeNode))
            {
                int res = sumNumbers(treeNode);
                Console.WriteLine($"Результат = {res}");
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
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = 1000;
            int lowLimitValueNode = 0;
            int highLimitValueNode = 9;
            int lowLimitDepthTreeNode = 1;
            int highLimitDepthTreeNode = 10;
            int countNodes = 0;
            int depth = 0;
            List<TreeNode> nodesOfNextLevel = new List<TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root != null)
            {
                queue.Enqueue(root);
            }
            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();
                countNodes++;
                if (currentNode.val < lowLimitValueNode || currentNode.val > highLimitValueNode)
                {
                    return false;
                }
                if (currentNode.left != null)
                {
                    nodesOfNextLevel.Add(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    nodesOfNextLevel.Add(currentNode.right);
                }
                if (queue.Count == 0)
                {
                    for (int i = 0; i < nodesOfNextLevel.Count; i++)
                    {
                        queue.Enqueue(nodesOfNextLevel[i]);
                    }
                    nodesOfNextLevel.Clear();
                    depth++;
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            if (depth< lowLimitDepthTreeNode || depth > highLimitDepthTreeNode)
            {
                return false;
            }
            return true;
        }
        private int sumNumbers(TreeNode root)
        {
            int totalSum = 0;
            if (root == null)
            {
                return totalSum;
            }
            HashSet<TreeNode> visitedNodes = new HashSet<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            int localSum = 0;
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (!visitedNodes.Contains(treeNode))
                {
                    localSum = localSum * 10 + treeNode.val;
                    visitedNodes.Add(treeNode);
                }
                else
                {
                    localSum /= 10;
                }
                if (treeNode.left == null && treeNode.right == null)
                {
                    totalSum+= localSum;
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
            return totalSum;
        }
        private int recursive(TreeNode root, int previousSum) {

            previousSum = previousSum * 10 + root.val;
            if (root.left != null)
            {
                previousSum+= recursive(root.left, previousSum);
            }
            if (root.right != null)
            {
                return recursive(root.right, previousSum);
            }
            return previousSum;
        }
    }
}
