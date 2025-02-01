using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task144
{
    /*
     144. Префиксный обход бинарного дерева
    Учитывая rootдвоичное дерево, верните префиксный обход его узлов.
     */
    public class Task144 : InfoBasicTask
    {
        public Task144(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5, new TreeNode(6), new TreeNode(7))), new TreeNode(3, null, new TreeNode(8, new TreeNode(9))));
            IList<int> nums = preorderTraversal(root);
            printIListInt(nums, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> preorderTraversal(TreeNode root)
        {
            IList<int> nums = new List<int>();
            if (root == null)
            {
                return nums;
            }
            travel(root, nums);
            return nums;
        }
        private void travel(TreeNode node, IList<int> nums)
        {
            nums.Add(node.val);
            if (node.left != null)
            {
                travel(node.left, nums);
            }
            if (node.right != null)
            {
                travel(node.right, nums);
            }
        }
    }
}
