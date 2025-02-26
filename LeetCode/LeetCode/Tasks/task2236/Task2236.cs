using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2236
{
    /*
     2236. Корень равен сумме дочерних элементов
    Вам дано root двоичного дерева, состоящего ровно из 3 узлов: корня, левого и правого потомков.
    Верните true значение, если значение корня равно сумме значений двух его дочерних элементов, или false иначе.
    https://leetcode.com/problems/root-equals-sum-of-children/description/
     */
    public class Task2236 : InfoBasicTask
    {
        public Task2236(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(10, new TreeNode(4), new TreeNode(6));
            printTreeNode(treeNode);
            if (isValid(treeNode))
            {
                Console.WriteLine(checkTree(treeNode) ? "Сумма дочерних узлов равна корню" : "Сумма дочерних узлов не равна корню");
            }
            else
            {
                Console.WriteLine("Двоичное дерево не валидно!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(TreeNode root)
        {
            if (root == null || root.left == null | root.right == null)
            {
                return false;
            }
            return true;
        }
        private bool checkTree(TreeNode root)
        {
            return root.val == root.left.val + root.right.val;
        }
    }
}
