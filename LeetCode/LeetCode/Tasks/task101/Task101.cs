using System;
using Xunit;
using Xunit.Sdk;
using LeetCode.Basic;

namespace LeetCode.Tasks.Task101
{
    public class Task101 : InfoBasicTask
    {
        private TreeNode firstRoot;
        private TreeNode secondRoot;
        public Task101(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
            firstRoot = new TreeNode();
            firstRoot.val = 1;
            firstRoot.left = new TreeNode(2, new TreeNode(3), new TreeNode(4));
            firstRoot.right = new TreeNode(2, new TreeNode(4), new TreeNode(3));
            secondRoot = new TreeNode();
            secondRoot.val = 1;
            secondRoot.left = new TreeNode(2, null, new TreeNode(3));
            secondRoot.right = new TreeNode(2, null, new TreeNode(3));
        }

        public override void execute()
        {
            // TODO: Добавить итерационный метод решения
            bool resultCheckSymmetricFirstRoot = IsSymmetricFirstMethod(firstRoot);
            string resultFirstRoot = resultCheckSymmetricFirstRoot ? "Дерево №1 симметрично" : "Дерево №1 не симметрично";
            bool resultCheckSymmetricSecondRoot = IsSymmetricFirstMethod(secondRoot);
            string resultSecondRoot = resultCheckSymmetricSecondRoot ? "Дерево №2 симметрично" : "Дерево №2 не симметрично";
            Console.WriteLine(resultFirstRoot);
            Console.WriteLine(resultSecondRoot);
        }

        public override void testing()
        {
            bool resultCheckSymmetricFirstRoot = IsSymmetricFirstMethod(firstRoot);
            try
            {
                Assert.Equal(true, resultCheckSymmetricFirstRoot);
                Console.WriteLine("Тест пройден");
            }
            catch (EqualException ex)
            {
                Console.WriteLine("Тест не пройден");
                Console.WriteLine(ex.Message);
            }
        }

        // Методы для проверки симметрии бинарного дерева
        private bool IsSymmetricFirstMethod(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            return isMirror(root.left, root.right);
        }

        private bool isMirror(TreeNode leftNode, TreeNode rightNode)
        {
            if (leftNode == null && rightNode == null)
            {
                return true;
            }
            if (leftNode == null || rightNode == null)
            {
                return false;
            }
            return leftNode.val == rightNode.val && isMirror(leftNode.left, rightNode.right) && isMirror(leftNode.right, rightNode.left);
        }
    }
}
