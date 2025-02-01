using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task112
{
    public class Task112 : InfoBasicTask
    {
        /*
         112. Сумма путей
        Учитывая root двоичного дерева и целое число targetSum, верните true, если в дереве есть путь от корня к листу, сумма значений на котором равна targetSum.
        Лист - это узел, не имеющий дочерних элементов.
         */
        public Task112(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(5, new TreeNode(4, new TreeNode(11, new TreeNode(7), new TreeNode(2))), new TreeNode(8, new TreeNode(13), new TreeNode(4, null, new TreeNode(1))));
            int sum = 22;
            Console.WriteLine(hasPathSum(root, sum) ? $"Бинарное дерево имеет сумму пути = {sum} на листе" : $"Бинарное дерево не имеет сумму пути = {sum} на листе");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool hasPathSum(TreeNode root, int targetSum)
        {
            List<int> sums = new List<int>();
            if (root == null)
            {
                return false;
            }
            travel(root, sums, 0);
            return sums.Contains(targetSum);
        }
        private void travel(TreeNode root,List<int> sums, int sum)
        {
            if (root.left == null && root.right == null)
            {
                sum += root.val;
                sums.Add(sum);
                sum -= root.val;
            }
            if (root.left != null)
            {
                sum += root.val;
                travel(root.left, sums, sum);
                sum -= root.val;
            }
            if (root.right != null)
            {
                sum += root.val;
                travel(root.right, sums, sum);
                sum -= root.val;
            }
        }
    }
}
