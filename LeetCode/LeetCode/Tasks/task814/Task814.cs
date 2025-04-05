using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.Tasks.task814
{
    /*
     814. Обрезка бинарного дерева
    Учитывая root двоичного дерева, верните то же самое дерево, в котором каждое поддерево (данного дерева), не содержащее 1удалено.
    Поддерево узла node — это node плюс все узлы, которые являются потомками node.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [1, 200].
        Node.val является либо 0, либо 1.
    https://leetcode.com/problems/binary-tree-pruning/description/
     */
    public class Task814 : InfoBasicTask
    {
        public Task814(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(1, new TreeNode(0, new TreeNode(0), new TreeNode(0)), new TreeNode(1, new TreeNode(0), new TreeNode(1)));
            printBinaryTreeUsingList(treeNode, "Исходное бинарное дерево");
            if (isValid(treeNode))
            {
                TreeNode res = pruneTree(treeNode);
                printBinaryTreeUsingList(res, "Результирующее бинарное дерево");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(TreeNode root)
        {
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = 200;
            int countNodes = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            HashSet<TreeNode> visitedNodes = new HashSet<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                if (!visitedNodes.Contains(node))
                {
                    visitedNodes.Add(node);
                    if (node.val < 0 || node.val > 1)
                    {
                        return false;
                    }
                    countNodes++;
                }
                if (node.left != null && !visitedNodes.Contains(node.left))
                {
                    stack.Push(node);
                    stack.Push(node.left);
                }
                else if (node.right != null && !visitedNodes.Contains(node.right))
                {
                    stack.Push(node);
                    stack.Push(node.right);
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private TreeNode pruneTree(TreeNode root)
        {
            TreeNode dummyHead = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            HashSet<TreeNode> visitedNodes = new HashSet<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                if (!visitedNodes.Contains(node))
                {
                    visitedNodes.Add(node);
                    int sumOfLeftSubtree = getSumOfSubTree(node.left);
                    int sumOfRightSubtree = getSumOfSubTree(node.right);
                    if (sumOfLeftSubtree == 0)
                    {
                        node.left = null;
                    }
                    if (sumOfRightSubtree == 0)
                    {
                        node.right = null;
                    }
                }
                if (node.left != null && !visitedNodes.Contains(node.left))
                {
                    stack.Push(node);
                    stack.Push(node.left);
                }
                else if (node.right != null && !visitedNodes.Contains(node.right))
                {
                    stack.Push(node);
                    stack.Push(node.right);
                }
            }
            int sumOfLeftSubtreeOfRoot = getSumOfSubTree(dummyHead.left);
            int sumOfRightSubtreeOfRoot = getSumOfSubTree(dummyHead.right);
            if (sumOfLeftSubtreeOfRoot == 0 && sumOfRightSubtreeOfRoot == 0 && dummyHead.val == 0)
            {
                return null;
            }
            return dummyHead;
        }
        private int getSumOfSubTree(TreeNode root)
        {
            int sum = 0;
            if (root == null)
            {
                return sum;
            }
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop();
                if (!visitedNodes.Contains(currentNode))
                {
                    sum += currentNode.val;
                    visitedNodes.Add(currentNode);
                }
                if (currentNode.left != null && !visitedNodes.Contains(currentNode.left))
                {
                    stack.Push(currentNode);
                    stack.Push(currentNode.left);
                }
                else if (currentNode.right != null && !visitedNodes.Contains(currentNode.right))
                {
                    stack.Push(currentNode);
                    stack.Push(currentNode.right);
                }
            }
            return sum;
        }
    }
}
