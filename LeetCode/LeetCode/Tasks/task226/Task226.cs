using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task226
{
    /*
     226. Инвертировать двоичное дерево
    Учитывая root двоичного дерева, инвертируйте дерево и верните его корень.
     */
    public class Task226 : InfoBasicTask
    {
        public Task226(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7, new TreeNode(6), new TreeNode(9)));
            TreeNode invertedTreeNode = invertTree(root);
            printTreeNode(invertedTreeNode);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private TreeNode invertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0) {
                TreeNode node = queue.Dequeue();
                (node.left, node.right) = (node.right, node.left);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            return root;
        }
    }
}
