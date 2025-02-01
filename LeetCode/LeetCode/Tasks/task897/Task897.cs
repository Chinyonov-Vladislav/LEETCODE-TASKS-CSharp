using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task897
{
    /*
     897. Дерево поиска по возрастающему порядку
    Учитывая root двоичного дерева поиска, переставьте элементы дерева по порядку так, чтобы самый левый узел в дереве стал его корнем, а у каждого узла не было левого потомка и был только один правый потомок.
    https://leetcode.com/problems/increasing-order-search-tree/description/
     */
    public class Task897 : InfoBasicTask
    {
        public Task897(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(5, new TreeNode(1), new TreeNode(7));
            Console.WriteLine("Исходное бинарное дерево");
            printTreeNode(root);
            TreeNode newTreeNode = increasingBST(root);
            Console.WriteLine("Конечное бинарное дерево");
            printTreeNode(newTreeNode);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private TreeNode increasingBST(TreeNode root)
        {
            List<int> values = travelIteratively(root);
            values.Sort();
            if (values.Count == 0)
            {
                return null;
            }
            TreeNode returnedTreeNode = new TreeNode(values[0]);
            TreeNode current = returnedTreeNode;
            for (int i = 1; i < values.Count; i++)
            {
                current.right = new TreeNode(values[i]);
                current = current.right;
            }
            return returnedTreeNode;

        }
        private List<int> travelIteratively(TreeNode root)
        {
            List<int> result = new List<int>();
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (!visitedNodes.Contains(treeNode))
                {
                    result.Add(treeNode.val);
                    visitedNodes.Add(treeNode);
                }
                if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                }
                else if (treeNode.right != null && !visitedNodes.Contains(treeNode.right))
                {

                    stack.Push(treeNode);
                    stack.Push(treeNode.right);
                }
            }
            return result;
        }
        // скопировано с leetcode
        private TreeNode bestSolution(TreeNode root)
        {
            IList<int> values = new List<int>();
            if (root == null)
            {
                return null;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    TreeNode last = stack.Pop();
                    values.Add(last.val);
                    current = last.right;
                }
            }
            TreeNode newRoot = new TreeNode(values[0]);
            current = newRoot;
            for (int i = 1; i < values.Count; i++)
            {
                TreeNode newNode = new TreeNode(values[i]);
                current.right = newNode;
                current = newNode;
            }
            return newRoot;
        }
    }
}
