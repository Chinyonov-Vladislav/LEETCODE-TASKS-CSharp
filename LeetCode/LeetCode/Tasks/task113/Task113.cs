using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task113
{
    /*
     113. Сумма путей II
     Учитывая корень двоичного дерева и целочисленную целевую сумму, верните все пути от корня к листу, где сумма значений узлов в пути равна targetSum. 
    Каждый путь должен быть возвращен в виде списка значений узлов, а не ссылок на узлы.
    Путь от корня к конечному элементу - это путь, начинающийся от корня и заканчивающийся в любом конечном узле. 
    Конечный элемент - это узел, не имеющий дочерних элементов.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 5000].
        -1000 <= Node.val <= 1000
        -1000 <= targetSum <= 1000
    https://leetcode.com/problems/path-sum-ii/description/
     */
    public class Task113 : InfoBasicTask
    {
        public Task113(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(5, new TreeNode(4, new TreeNode(11, new TreeNode(7), new TreeNode(2))), new TreeNode(8, new TreeNode(13), new TreeNode(4, new TreeNode(5), new TreeNode(1))));
            int targetSum = 22;
            Console.WriteLine("Исходное дерево");
            printTreeNode(root);
            Console.WriteLine($"Целевая сумма = {targetSum}");
            if (isValid(root, targetSum))
            {
                IList<IList<int>> res = pathSum(root, targetSum);
                printIListIListInt(res);
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
        private bool isValid(TreeNode treeNode, int targetSum)
        {
            int lowLimit = -1000;
            int highLimit = 1000;
            if (targetSum < lowLimit || targetSum > highLimit)
            {
                return false;
            }
            int countNodes = 0;
            if (treeNode != null)
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(treeNode);

                while (stack.Count > 0)
                {
                    TreeNode node = stack.Pop();
                    countNodes++;
                    if (node.val < lowLimit || node.val > highLimit)
                    {
                        return false;
                    }
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }

                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                }
            }
            lowLimit = 0;
            highLimit = 5000;
            if (countNodes < lowLimit || countNodes > highLimit)
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> pathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            IList<int> currentPath = new List<int>() { root.val };
            recursive(root, root.val, targetSum, currentPath, result);
            return result;
        }
        private void recursive(TreeNode root, int currentSum, int targetSum, IList<int> currentPath, IList<IList<int>> result)
        {
            if (root.left == null && root.right == null)
            {
                if (targetSum == currentSum)
                {
                    result.Add(new List<int>(currentPath));
                }
                return;
            }
            if (root.left != null)
            {
                currentPath.Add(root.left.val);
                recursive(root.left, currentSum+ root.left.val, targetSum, currentPath, result);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
            if (root.right != null)
            {
                currentPath.Add(root.right.val);
                recursive(root.right, currentSum + root.right.val, targetSum, currentPath, result);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }
}
