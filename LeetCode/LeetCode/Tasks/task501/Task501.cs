using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks.task501
{
    /*
     501. Поиск наиболее встречающегося значения в двоичном дереве поиска
    Учитывая root двоичное дерево поиска (BST) с дубликатами, верните все режимы (т. е. Наиболее часто встречающийся элемент) в нем.
    Если у дерева более одного наиболее часто встречающегося элемента, верните их в любом порядке.
    Предположим, что BST определяется следующим образом:
        Левое поддерево узла содержит только узлы с ключами, меньшими или равными ключу узла.
        Правое поддерево узла содержит только узлы с ключами, большими или равными ключу узла.
        И левое, и правое поддеревья также должны быть бинарными деревьями поиска.
     */
    public class Task501 : InfoBasicTask
    {
        public Task501(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(1, null, new TreeNode(2, new TreeNode(2)));
            printArray(findMode(root), "Наиболее часто встречаемые значения в бинарном дереве: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int[] findMode(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            Dictionary<int, int> modes = new Dictionary<int, int>();
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (!visitedNodes.Contains(treeNode))
                {
                    visitedNodes.Add(treeNode);
                    if (modes.ContainsKey(treeNode.val))
                    {
                        modes[treeNode.val]++;
                    }
                    else
                    {
                        modes.Add(treeNode.val, 1);
                    }
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
            List<int> result = new List<int>();
            int maxModes = modes.Values.Max();
            foreach (var pair in modes)
            {
                if (pair.Value == maxModes)
                {
                    result.Add(pair.Key);
                }
            }
            return result.ToArray();
        }
    }
}
