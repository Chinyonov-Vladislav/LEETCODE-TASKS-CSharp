using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task236
{
    /*
     236. Наименьший общий предок бинарного дерева
    Для заданного двоичного дерева найдите наименьшего общего предка (НОП) двух заданных узлов в дереве.
    Согласно определению LCA в Википедии: «Самый низкий общий предок определяется между двумя узлами p и q как самый низкий узел в T, у которого есть и p и q в качестве потомков (при этом узел может быть потомком самого себя).
    Ограничения:
        Количество узлов в дереве находится в диапазоне [2, 10^5].
        -10^9 <= Node.val <= 10^9
        Все они Node.val уникальны.
        p != q
        p и q будет существовать в дереве.
    https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
     */
    public class Task236 : InfoBasicTask
    {
        public Task236(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode head3 = new TreeNode(3);
            TreeNode head5 = new TreeNode(5);
            TreeNode head6 = new TreeNode(6);
            TreeNode head2 = new TreeNode(2);
            TreeNode head7 = new TreeNode(7);
            TreeNode head4 = new TreeNode(4);
            TreeNode head1 = new TreeNode(1);
            TreeNode head0 = new TreeNode(0);
            TreeNode head8 = new TreeNode(8);
            head3.left = head5;
            head3.right = head1;
            head5.left = head6;
            head5.right = head2;
            head2.left = head7;
            head2.right = head4;
            head1.left = head0;
            head1.right = head8;
            Console.WriteLine("Исходное бинарное дерево");
            printTreeNode(head3);
            if (isValid(head3, head5, head4))
            {
                TreeNode res = lowestCommonAncestor(head3, head5, head4);
                Console.WriteLine($"Наименьший общий предок (НОП) двух заданных узлов в дереве - узел со значением {res.val}");
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
        private bool isValid(TreeNode root, TreeNode p, TreeNode q)
        {
            bool isFindTreeNodeP = false;
            bool isFindTreeNodeQ = false;
            int lowLimitCountNodes = 2;
            int highLimitCountNodes = (int)Math.Pow(10,5);
            int lowLimitValueNode = -1* (int)Math.Pow(10,9);
            int highLimitValueNode = (int)Math.Pow(10, 9);
            int countNodes = 0;
            HashSet<int> valuesFromTreeNode = new HashSet<int>();
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (treeNode == p)
                {
                    isFindTreeNodeP = true;
                }
                if (treeNode == q)
                {
                    isFindTreeNodeQ = true;
                }
                if (treeNode.val < lowLimitValueNode || treeNode.val > highLimitValueNode)
                {
                    return false;
                }
                if (!visitedNodes.Contains(treeNode))
                {
                    visitedNodes.Add(treeNode);
                    valuesFromTreeNode.Add(treeNode.val);
                    countNodes++;
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
            if ((countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes) || 
                (countNodes != valuesFromTreeNode.Count) ||
                (p == q) ||
                (!(isFindTreeNodeP && isFindTreeNodeQ)))
            {
                return false;
            }
            return true;
        }
        private TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            List<TreeNode> valuesToP = getPathToNode(root, p);
            List<TreeNode> valuesToQ = getPathToNode(root, q);
            TreeNode returnedNode = null;
            int min = Math.Min(valuesToP.Count, valuesToQ.Count);
            for (int i = 0; i < min; i++)
            {
                if (valuesToP[i] == valuesToQ[i])
                {
                    returnedNode = valuesToP[i];
                }
                else
                {
                    break;
                }
            }
            return returnedNode;
        }

        private List<TreeNode> getPathToNode(TreeNode root, TreeNode searchedNode)
        {
            List<TreeNode> list = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<TreeNode> visitedNodes = new List<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                if ((node.left == null || visitedNodes.Contains(node.left)) && (node.right == null || visitedNodes.Contains(node.right)))
                {
                    list.Remove(node);
                }
                if (!visitedNodes.Contains(node))
                {
                    list.Add(node);
                    visitedNodes.Add(node);
                    if (node == searchedNode)
                    {
                        break;
                    }
                }
                if (node.left == null && node.right == null)
                {
                    list.Remove(node);
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
            return list;
        }
    }
}
