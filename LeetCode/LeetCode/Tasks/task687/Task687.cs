using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task687
{
    /*
     687. Самый длинный одномерный путь
    Учитывая root двоичного дерева, верните длину самого длинного пути, в котором каждый узел имеет одинаковое значение. Этот путь может проходить или не проходить через корень.
    Длина пути между двумя узлами определяется количеством рёбер между ними.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 10^4].
        -1000 <= Node.val <= 1000
        Глубина дерева не будет превышать 1000.
    https://leetcode.com/problems/longest-univalue-path/description/
     */
    public class Task687 : InfoBasicTask
    {
        public Task687(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(1, null, new TreeNode(1,  new TreeNode(1, new TreeNode(1), new TreeNode(1)), new TreeNode(1, new TreeNode(1))));
            printTreeNode(treeNode);
            if (isValid(treeNode))
            {
                int res = longestUnivaluePath(treeNode);
                Console.WriteLine($"Длина самого длинного пути, в котором каждый узел имеет одинаковое значение = {res}");
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
        private bool isValid(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = (int)Math.Pow(10, 4);
            int lowLimitValueNode = -1000;
            int highLimitValueNode = 1000;
            int lowLimitDepth = 0;
            int highLimitDepth = 1000;
            int countNodes = 0;
            int currentDepth = 0;
            int depth = 0;
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (currentDepth > depth)
                {
                    depth = currentDepth;
                }
                if (visitedNodes.Contains(treeNode))
                {
                    currentDepth--;
                }
                else
                {
                    if (treeNode.val < lowLimitValueNode || treeNode.val > highLimitValueNode)
                    {
                        return false;
                    }
                    countNodes++;
                    visitedNodes.Add(treeNode);
                }
                if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                    currentDepth++;
                }
                else if (treeNode.right != null && !visitedNodes.Contains(treeNode.right))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.right);
                    currentDepth++;
                }
            }
            if (depth < lowLimitDepth || depth > highLimitDepth || countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private int longestUnivaluePath(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int max = 0;
            HashSet<TreeNode> set = new HashSet<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop();
                if (!set.Contains(currentNode))
                {
                    int leftMax = currentNode.left == null ? 0 : recursive(currentNode.left, currentNode.val, 1);
                    int rightMax = currentNode.right == null ? 0 : recursive(currentNode.right, currentNode.val, 1);
                    int localMax = leftMax + rightMax;
                    if (localMax > max)
                    {
                        max = localMax;
                    }
                    set.Add(currentNode);
                }
                if (currentNode.left != null && !set.Contains(currentNode.left))
                {
                    stack.Push(currentNode);
                    stack.Push(currentNode.left);
                }
                if (currentNode.right != null && !set.Contains(currentNode.right))
                {
                    stack.Push(currentNode);
                    stack.Push(currentNode.right);
                }
            }
            return max;
        }
        private int recursive(TreeNode currentNode, int currentVal, int count)
        {
            if (currentNode == null || currentNode.val != currentVal)
            {
                return count - 1;
            }
            int leftMax = recursive(currentNode.left, currentVal, count+1);
            int rightMax = recursive(currentNode.right, currentVal, count+1);
            return Math.Max(leftMax, rightMax);
        }
    }
}
