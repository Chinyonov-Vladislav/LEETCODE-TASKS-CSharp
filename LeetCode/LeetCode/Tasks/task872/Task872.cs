using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task872
{
    /*
     872. Деревья со схожими листьями
    Два двоичных дерева считаются похожими по листьям, если последовательность значений их листьев одинакова.
    Вернуть true тогда и только тогда, когда два заданных дерева с головными узлами root1 и root2 являются листово-подобными.
    https://leetcode.com/problems/leaf-similar-trees/description/
     */
    public class Task872 : InfoBasicTask
    {
        public Task872(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root1 = new TreeNode(3, new TreeNode(5,  new TreeNode(6), new TreeNode(2, new TreeNode(7), new TreeNode(4))), new TreeNode(1, new TreeNode(9), new TreeNode(8)));
            TreeNode root2 = new TreeNode(3, new TreeNode(5, new TreeNode(6), new TreeNode(7)), new TreeNode(1, new TreeNode(4), new TreeNode(2, new TreeNode(9), new TreeNode(8))));
            Console.WriteLine("Бинарное дерево №1");
            printTreeNode(root1);
            Console.WriteLine("Бинарное дерево №2");
            printTreeNode(root2);
            Console.WriteLine(leafSimilar(root1, root2) ? "Два бинарных дерева имеют схожую последовательность листьев" : "Два бинарных не дерева имеют схожую последовательность листьев");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool leafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> leafValuesFromTreeNode1 = travelIteratively(root1);
            List<int> leafValuesFromTreeNode2 = travelIteratively(root2);
            if (leafValuesFromTreeNode1.Count != leafValuesFromTreeNode2.Count)
            {
                return false;
            }
            for (int index = 0; index < leafValuesFromTreeNode1.Count; index++)
            {
                if (leafValuesFromTreeNode1[index] != leafValuesFromTreeNode2[index])
                {
                    return false;
                }
            }
            return true;
        }
        private List<int> travelIteratively(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            visitedNodes.Add(root);
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (!visitedNodes.Contains(treeNode))
                {
                    visitedNodes.Add(treeNode);
                }
                if (treeNode.left == null && treeNode.right == null)
                {
                    result.Add(treeNode.val);
                }
                else if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
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
    }
}
