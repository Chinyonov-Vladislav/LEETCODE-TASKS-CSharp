using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task437
{
    /*
     437. Сумма путей III
    Учитывая root двоичного дерева и целое число targetSum, верните количество путей, сумма значений на которых равна targetSum.
    Путь не обязательно должен начинаться или заканчиваться на корневом или листовом узле, но он должен идти вниз (то есть только от родительских узлов к дочерним).
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 1000].
        -10^9 <= Node.val <= 10^9
        -1000 <= targetSum <= 1000
    https://leetcode.com/problems/path-sum-iii/description/
     */
    public class Task437 : InfoBasicTask
    {
        public Task437(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode node = new TreeNode(10, new TreeNode(5, new TreeNode(3, new TreeNode(3), new TreeNode(-2)), new TreeNode(2, null, new TreeNode(1))), new TreeNode(-3, null, new TreeNode(11)));
            printBinaryTreeUsingList(node);
            int targetSum = 8;
            Console.WriteLine($"Целевая сумма = {targetSum}");
            if (isValid(node, targetSum))
            {
                int res = pathSum(node, targetSum);
                Console.WriteLine($"Количество путей, сумма значений на которых равна {targetSum} = {res}");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(TreeNode root, int targetSum)
        {
            int countNodes = 0;
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = 1000;
            int lowLimitValueNode = -1 * (int)Math.Pow(10, 9);
            int highLimitValueNode = (int)Math.Pow(10, 9);
            int lowLimitTargetSum = -1000;
            int highLimitTargetSum = 1000;
            if (root != null)
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0)
                {
                    TreeNode node = stack.Pop();
                    countNodes++;
                    if (node.val < lowLimitValueNode || node.val > highLimitValueNode)
                    {
                        return false;
                    }
                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes || targetSum < lowLimitTargetSum || targetSum > highLimitTargetSum)
            {
                return false;
            }
            return true;
        }
        private int pathSum(TreeNode root, int targetSum)
        {
            int count = 0;
            if (root == null)
            {
                return count;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                count+=recursive(node, 0, targetSum, 0);
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
            }
            return count;
        }
        private int recursive(TreeNode treeNode, long currentSum, int targetSum, int count)
        {
            if (currentSum + treeNode.val == targetSum)
            {
                count++;
            }
            if (treeNode.left != null)
            {
                count = recursive(treeNode.left, currentSum + treeNode.val, targetSum, count);
            }
            if (treeNode.right != null)
            {
                count = recursive(treeNode.right, currentSum + treeNode.val, targetSum, count);
            }
            return count;
        }
    }
}
