using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task100
{
    /*
    100. То же Самое Дерево
    Учитывая корни двух двоичных деревьев p и q, напишите функцию, которая проверяет, совпадают ли они.
    Два двоичных дерева считаются одинаковыми, если они структурно идентичны и узлы имеют одинаковое значение.
     */
    public class Task100 : InfoBasicTask
    {
        public Task100(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode firstTree = new TreeNode(0, new TreeNode(1));
            TreeNode secondTree = new TreeNode(0, new TreeNode(1));
            Console.WriteLine(isSameTree(firstTree, secondTree) ? "Бинарные деревья симметричны" : "Бинарные деревья несимметричны");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            if ((p != null && q == null) || (p == null && q != null))
            {
                return false;
            }
            Stack<TreeNode> stackForP = new Stack<TreeNode>();
            Stack<TreeNode> stackForQ = new Stack<TreeNode>();
            List<int?> valuesFromFirstTree = new List<int?>();
            List<int?> valuesFromSecondTree = new List<int?>();
            stackForP.Push(p);
            stackForQ.Push(q);
            while (stackForP.Count > 0)
            {
                TreeNode n = stackForP.Pop();
                valuesFromFirstTree.Add(n.val);
                if (n.left != null)
                {
                    stackForP.Push(n.left);
                }
                if (n.right != null)
                { 
                    stackForP.Push(n.right);
                }
                if (n.left == null && n.right != null)
                {
                    valuesFromFirstTree.Add(null);
                }
            }
            while (stackForQ.Count > 0)
            {
                TreeNode n = stackForQ.Pop();
                valuesFromSecondTree.Add(n.val);
                if (n.left != null)
                {
                    stackForQ.Push(n.left);
                }
                if (n.right != null)
                { 
                    stackForQ.Push(n.right);
                }
                if (n.left == null && n.right != null)
                {
                    valuesFromSecondTree.Add(null);
                }
            }
            if (valuesFromFirstTree.Count != valuesFromSecondTree.Count)
            {
                return false;
            }
            for (int i = 0; i < valuesFromFirstTree.Count; i++)
            {
                if (valuesFromFirstTree[i] != valuesFromSecondTree[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
