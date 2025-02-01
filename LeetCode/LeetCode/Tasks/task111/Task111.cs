using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks.task111
{
    public class Task111 : InfoBasicTask
    {
        /*
         111. Минимальная глубина бинарного дерева
        Учитывая бинарное дерево, найдите его минимальную глубину.
        Минимальная глубина — это количество узлов на кратчайшем пути от корневого узла до ближайшего конечного узла.
        https://leetcode.com/problems/minimum-depth-of-binary-tree
         */
        public Task111(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(2, new TreeNode(15), new TreeNode(7)));
            TreeNode root1 = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            Console.WriteLine($"Минимальная глубина бинарного дерева = {minDepth(root1)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int minDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            List<int> depthsOfLeafs = new List<int>();
            travel(root, depthsOfLeafs, 1);
            return depthsOfLeafs.Min();
        }
        private void travel(TreeNode node,List<int> depthsOfLeafs, int currentDepth)
        {
            if (node.left == null && node.right == null)
            {
                depthsOfLeafs.Add(currentDepth);
            }
            if (node.left != null)
            {
                travel(node.left, depthsOfLeafs,++currentDepth);
            }
            if (node.right != null) {
                if (node.left == null)
                {
                    currentDepth++;
                }
                travel(node.right, depthsOfLeafs, currentDepth);
            }
            currentDepth--;
        }
    }
}
