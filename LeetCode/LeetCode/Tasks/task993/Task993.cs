using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks.task993
{
    /*
     993. Двоюродные узлы в двоичном дереве

    Учитывая root двоичного дерева с уникальными значениями и значения двух разных узлов дерева x и y, верните true если узлы, соответствующие значениям x и y в дереве, являются двоюродными, или false в противном случае.
    Два узла двоичного дерева являются двоюродными, если они находятся на одной глубине и имеют разных родителей.
    Обратите внимание, что в двоичном дереве корневой узел находится на глубине 0, а дочерние узлы каждого узла на глубине k находятся на глубине k + 1.

     */
    public class Task993 : InfoBasicTask
    {
        public Task993(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(1, new TreeNode(2, new TreeNode(4)), new TreeNode(3));
            int x = 4;
            int y = 3;
            Console.WriteLine(isCousins(treeNode, x, y) ? $"Значение {x} и {y} были найдены в бинарном дереве на одинаковой глубине в узлах от разных родителей" : $"Значение {x} и {y} не были найдены в бинарном дереве на одинаковой глубине в узлах от разных родителей");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isCousins(TreeNode root, int x, int y)
        {
            if (root == null)
            {
                return false;
            }
            int currentDepth = -1;
            Tuple<TreeNode, int> parentNodeWithX = null;
            Tuple<TreeNode, int> parentNodeWithY = null;
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (visitedNodes.Contains(treeNode))
                {
                    currentDepth--;
                }
                else
                {
                    visitedNodes.Add(treeNode);
                    currentDepth++;
                }
                if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    if (treeNode.left.val == x && parentNodeWithX == null)
                    {
                        parentNodeWithX = Tuple.Create(treeNode, currentDepth);
                    }
                    else if (treeNode.left.val == y && parentNodeWithY == null)
                    {
                        parentNodeWithY = Tuple.Create(treeNode, currentDepth);
                    }
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                }
                else if (treeNode.right != null && !visitedNodes.Contains(treeNode.right))
                {
                    if (treeNode.right.val == x && parentNodeWithX == null)
                    {
                        parentNodeWithX = Tuple.Create(treeNode, currentDepth);
                    }
                    else if (treeNode.right.val == y && parentNodeWithY == null)
                    {
                        parentNodeWithY = Tuple.Create(treeNode, currentDepth);
                    }
                    stack.Push(treeNode);
                    stack.Push(treeNode.right);
                }
            }
            if (parentNodeWithX != null && parentNodeWithY != null && parentNodeWithX.Item2 == parentNodeWithY.Item2 && parentNodeWithX.Item1 != parentNodeWithY.Item1)
            {
                return true;
            }
            return false;
        }
        private bool bestSolution(TreeNode root, int x, int y)
        {
            if (root == null) return false;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count();
                bool isxfound = false, isyfound = false;
                while (count-- > 0)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.left != null && node.right != null && ((node.left.val == x && node.right.val == y) || (node.left.val == y && node.right.val == x)))
                        return false;
                    if (node.val == x) isxfound = true;
                    if (node.val == y) isyfound = true;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                if (isxfound && isyfound) return true;
                if (isxfound || isyfound) return false;
            }
            return false;
        }
    }
}
