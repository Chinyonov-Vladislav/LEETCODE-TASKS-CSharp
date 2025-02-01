using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task572
{
    /*
     572. Поддерево другого дерева
    Учитывая корни двух двоичных деревьев root и subRoot, верните true если существует поддерево root с той же структурой и значениями узлов  subRoot и false в противном случае.
    Поддерево двоичного дерева tree — это дерево, состоящее из узла tree и всех потомков этого узла. Дерево tree также можно рассматривать как поддерево самого себя.
     https://leetcode.com/problems/subtree-of-another-tree/description/
     */
    public class Task572 : InfoBasicTask
    {
        public Task572(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(3, new TreeNode(4, new TreeNode(1), new TreeNode(2)), new TreeNode(5));
            Console.WriteLine("Основное дерево");
            printTreeNode(root);
            TreeNode subRoot = new TreeNode(4, new TreeNode(1), new TreeNode(2));
            Console.WriteLine("Поддерево");
            printTreeNode(subRoot);
            Console.WriteLine(isSubtree(root, subRoot)? "Поддерево является частью основного дерева": "Поддерево не является частью основного дерева");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isSubtree(TreeNode root, TreeNode subRoot)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            List<TreeNode> visitedNodes = new List<TreeNode>();
            while (stack.Count > 0) { 
                TreeNode node = stack.Pop();
                if (node != null)
                {
                    bool result = isSame(node, subRoot);
                    if (result)
                    {
                        return true;
                    }
                    visitedNodes.Add(node);
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
            return false;
        }
        private bool isSame(TreeNode root, TreeNode subRoot)
        {
            if (checkIsSame(root, subRoot))
            {
                if (root != null && subRoot != null)
                {
                    bool resultCheckLeft = isSame(root.left, subRoot.left);
                    bool resultCheckRight = isSame(root.right, subRoot.right);
                    return resultCheckLeft && resultCheckRight;
                }
                else if (root == null && subRoot == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
            
        }
        private bool checkIsSame(TreeNode root, TreeNode subRoot)
        {
            if ((root == null && subRoot == null) || (root != null && subRoot != null && root.val == subRoot.val))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // скопировано с leetcode - лучшее решение по скорости
        private bool bestSolution(TreeNode root, TreeNode subRoot)
        {
            if (Check(root, subRoot))
                return true;
            if (root.left != null && bestSolution(root.left, subRoot))
                return true;
            if (root.right != null && bestSolution(root.right, subRoot))
                return true;
            return false;
        }
        private bool Check(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null)
                return true;
            if (root == null || subRoot == null)
                return false;
            if (root.val != subRoot.val)
                return false;
            return Check(root.left, subRoot.left) && Check(root.right, subRoot.right);
        }
    }
}
