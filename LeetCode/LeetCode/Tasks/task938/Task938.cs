using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task938
{
    /*
     938. Сумма диапазона BST
    Учитывая узел root двоичного дерева поиска и два целых числа low и high, верните сумму значений всех узлов со значением в включительно диапазоне [low, high].
    https://leetcode.com/problems/range-sum-of-bst/description/
     */
    public class Task938 : InfoBasicTask
    {
        public Task938(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(10, new TreeNode(5, new TreeNode(3, new TreeNode(1)), new TreeNode(7, new TreeNode(6))), new TreeNode(15, new TreeNode(13, new TreeNode(18))));
            //Console.WriteLine("Бинарное дерево поиска");
            //printTreeNode(root);
            int low = 6;
            int high = 10;
            int sum = bestSolution(root, low, high);
            Console.WriteLine($"Сумма значений узлов, значения которых находятся в диапазоне от {low} до {high} = {sum}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int rangeSumBST(TreeNode root, int low, int high)
        {
            return travelRecursive(root, low, high);
        }
        private int travelRecursive(TreeNode root, int low, int high, int sum = 0)
        {
            if (root == null)
            {
                return sum;
            }
            if (root.val >= low && root.val <= high)
            {
                sum+=root.val;
            }
            sum = travelRecursive(root.left, low, high, sum);
            sum = travelRecursive(root.right, low, high, sum);
            return sum;
        }
        // скопировано и модифицировано с leetcode
        private int bestSolution(TreeNode root, int low, int high, int sum = 0)
        {
            if (root == null)
            {
                return sum;
            }
            if (root.val >= low && root.val <= high)
            {
                sum += root.val;
            }
            if (root.val > high)
            {
                sum = bestSolution(root.left, low, high, sum);
            }
            else if (root.val < low)
            {
                sum = bestSolution(root.right, low, high, sum);
            }
            else
            {
                sum = bestSolution(root.left, low, root.val, sum);
                sum = bestSolution(root.right, root.val, high, sum);
            }
            return sum;
        }
    }
}
