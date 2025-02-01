using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task543
{
    /*
     543. Диаметр бинарного дерева
    Учитывая root двоичного дерева, верните длину диаметра дерева.
    Диаметр двоичного дерева — это длина самого длинного пути между любыми двумя узлами дерева. Этот путь может проходить или не проходить через root.
    Длина пути между двумя узлами определяется количеством рёбер между ними.
     */
    public class Task543 : InfoBasicTask
    {
        public Task543(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            int diameter = diameterOfBinaryTree(root);
            Console.WriteLine($"Диаметр бинарного дерева равен {diameter}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int diameterOfBinaryTree(TreeNode root)
        {
            int maxDiameter = 0;
            recursiveTravel(root, ref maxDiameter);
            return maxDiameter;
        }
        private int recursiveTravel(TreeNode root, ref int maxDiameter)
        {
            if (root == null)
            {
                return 0;
            }
            int leftHeight = recursiveTravel(root.left, ref maxDiameter);
            Console.WriteLine($"Значение узла = {root.val} | Левая высота = {leftHeight}");
            int rightHeight = recursiveTravel(root.right, ref maxDiameter);
            Console.WriteLine($"Значение узла = {root.val} | Правая высота = {rightHeight}");
            maxDiameter = leftHeight + rightHeight > maxDiameter ? leftHeight+ rightHeight : maxDiameter;
            return 1+ Math.Max(leftHeight,rightHeight);
        }
    }
}
