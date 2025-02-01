using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task653
{
    /*
     653. Две суммы IV - Входных данных - это BST
    Учитывая root двоичного дерева поиска и целое число k, верните true если в двоичном дереве поиска есть два элемента, сумма которых равна k, то false иначе.
    https://leetcode.com/problems/two-sum-iv-input-is-a-bst/description/
     */
    public class Task653 : InfoBasicTask
    {
        public Task653(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(5, new TreeNode(3, new TreeNode(2), new TreeNode(4)), new TreeNode(6, null, new TreeNode(7)));
            int k = 9;
            Console.WriteLine(findTarget(root, k) ? "Найдено" : "Не найдено");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool findTarget(TreeNode root, int k)
        {
            if (root == null)
            {
                return false;
            }
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            visitedNodes.Add(root);
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                int remain = k - treeNode.val;
                if (!visitedNodes.Contains(treeNode))
                {
                    if ((remain < treeNode.val && findRemainInRoot(root, treeNode, remain))|| (remain > treeNode.val && findRemainInRoot(root, treeNode, remain)))
                    {
                        return true;
                    }
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
            return false;
        }
        private bool findRemainInRoot(TreeNode root, TreeNode currentNode, int remain)
        {
            if (root != null)
            {
                if (root.val == remain && currentNode != root)
                {
                    return true;
                }
                else if (remain > root.val)
                {
                    return findRemainInRoot(root.right, currentNode, remain);
                }
                else
                {
                    return findRemainInRoot(root.left, currentNode, remain);
                }
            }
            return false;
        }
    }
}
