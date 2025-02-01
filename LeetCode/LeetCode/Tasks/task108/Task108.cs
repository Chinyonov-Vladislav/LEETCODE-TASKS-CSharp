using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task108
{
    /*
     108. Преобразуйте Отсортированный массив в двоичное дерево поиска
    Дан целочисленный массив nums, элементы которого отсортированы в порядке возрастания. Преобразуйте его в сбалансированное по высоте бинарное дерево поиска.
     */
    public class Task108 : InfoBasicTask
    {
        public Task108(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { -10, -3, 0, 5, 9 };
            TreeNode treeNode = sortedArrayToBST(array);
            printTreeNode(treeNode);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private TreeNode sortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0)
            {
                return null;
            }
            return setValueToTreeNode(nums, 0, nums.Length-1);
        }
        private TreeNode setValueToTreeNode(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null;
            }
            int mid = (left + right) / 2;
            TreeNode treeNode = new TreeNode(nums[mid]);
            treeNode.left = setValueToTreeNode(nums, left, mid-1);
            treeNode.right = setValueToTreeNode(nums, mid+1, right);
            return treeNode;
        }
    }
}
