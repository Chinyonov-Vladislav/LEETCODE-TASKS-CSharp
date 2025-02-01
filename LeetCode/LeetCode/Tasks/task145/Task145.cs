using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task145
{
    /*
     145. Постфиксный обход бинарного дерева
    Учитывая root двоичного дерева, верните последовательность обхода его узлов в обратном порядке.
     */
    public class Task145 : InfoBasicTask
    {
        public Task145(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        { 
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5, new TreeNode(6), new TreeNode(7))), new TreeNode(3, null, new TreeNode(8, new TreeNode(9))));
            IList<int> nums = postorderTraversal(root);
            printIListInt(nums, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public IList<int> postorderTraversal(TreeNode root)
        {
            IList<int> nums = new List<int>();
            if (root == null)
            {
                return nums;
            }
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            visitedNodes.Add(root);
            while (stack.Count > 0) {
                TreeNode popedNode = stack.Pop();
                if (!visitedNodes.Contains(popedNode))
                {
                    visitedNodes.Add(popedNode);
                }
                if (popedNode.left == null && popedNode.right == null)
                {
                    nums.Add(popedNode.val);
                }
                else if (popedNode.left == null && popedNode.right != null && visitedNodes.Contains(popedNode.right))
                {
                    nums.Add(popedNode.val);
                }
                else if (popedNode.right == null && popedNode.left != null && visitedNodes.Contains(popedNode.left))
                {
                    nums.Add(popedNode.val);
                }
                else if (popedNode.left != null && popedNode.right != null && visitedNodes.Contains(popedNode.left) && visitedNodes.Contains(popedNode.right))
                {
                    nums.Add(popedNode.val);
                }
                else if (popedNode.left != null && !visitedNodes.Contains(popedNode.left))
                {
                    stack.Push(popedNode);
                    stack.Push(popedNode.left);
                }
                else if (popedNode.right != null && !visitedNodes.Contains(popedNode.right))
                {
                    stack.Push(popedNode);
                    stack.Push(popedNode.right);
                }
            }
            return nums;
        }
    }
}
