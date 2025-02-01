using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1022
{
    /*
     1022. Сумма двоичных чисел от корня к листу
     Вам дано root двоичного дерева, в котором каждый узел имеет значение 0 или 1. Каждый путь от корня к листу представляет собой двоичное число, начинающееся с старшего бита.
        Например, если путь — 0 -> 1 -> 1 -> 0 -> 1, то в двоичном виде он может выглядеть как 01101, то есть 13.
    Для всех листьев дерева рассмотрим числа, обозначающие путь от корня до этого листа. Верните сумму этих чисел.
    Тестовые примеры генерируются таким образом, чтобы ответ помещался в 32-битное целое число.
    https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/description/
     */
    public class Task1022 : InfoBasicTask
    {
        public Task1022(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(1, new TreeNode(0 ,new TreeNode(0), new TreeNode(1)), new TreeNode(1, new TreeNode(0), new TreeNode(1)));
            Console.WriteLine("Бинарное дерево со значением 0 или 1 в узлах");
            printTreeNode(root);
            int sum = sumRootToLeaf(root);
            Console.WriteLine($"Сумма двоичных чисел от корня к листу = {sum}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int sumRootToLeaf(TreeNode root)
        {
            return travelRecursive(root, new StringBuilder());
        }
        private int travelRecursive(TreeNode root, StringBuilder sb, int sum = 0)
        {
            if (root == null)
            {
                return sum;
            }
            sb.Append(root.val.ToString());
            if (root.left == null && root.right == null)
            {
                int number = Convert.ToInt32(sb.ToString(), 2);
                sum += number;
                return sum;
            }
            if (root.left != null)
            {
                sum = travelRecursive(root.left, sb, sum);
                sb.Remove(sb.Length - 1, 1);
            }
            if (root.right != null)
            {
                sum = travelRecursive(root.right, sb, sum);
                sb.Remove(sb.Length - 1, 1);
            }
            return sum;
        }
    }
}
