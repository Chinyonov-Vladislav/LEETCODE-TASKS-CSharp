using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task671
{
    /*
     671. Второй минимальный узел в двоичном дереве
    Дано непустое специальное двоичное дерево, состоящее из узлов с неотрицательными значениями, где каждый узел этого дерева имеет ровно two или zero подузлов. Если у узла два подузла, то значение этого узла является наименьшим значением среди двух его подузлов. Более формально, свойство root.val = min(root.left.val, root.right.val) всегда выполняется.
    Учитывая такое двоичное дерево, вам нужно вывести второе минимальное значение в наборе, состоящем из значений всех узлов во всём дереве.
    Если такого второго минимального значения не существует, выведите вместо него значение -1.
     */
    public class Task671 : InfoBasicTask
    {
        public Task671(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(2, new TreeNode(2), new TreeNode(5, new TreeNode(5), new TreeNode(7)));
            Console.WriteLine($"Значение второго минимального узла в бинарном дереве = {findSecondMinimumValue(root)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findSecondMinimumValue(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }
            HashSet<int> minValuesRoot = new HashSet<int>();
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                minValuesRoot.Add(treeNode.val);
                if (!visitedNodes.Contains(treeNode))
                {
                    visitedNodes.Add(treeNode);
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
            List<int> minValuesRootList = new List<int>(minValuesRoot);
            minValuesRootList.Sort();
            return minValuesRootList.Count >=2 ? minValuesRootList[1] : -1;
        }
    }
}
