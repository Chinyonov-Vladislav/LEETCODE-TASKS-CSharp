using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.Tasks.task102
{
    /*
     102. Обход бинарного дерева по уровням
    Учитывая root двоичного дерева, верните последовательность обхода его узлов в порядке уровней. (т. е. слева направо, уровень за уровнем).
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 2000].
        -1000 <= Node.val <= 1000
    https://leetcode.com/problems/binary-tree-level-order-traversal/description/
     */
    public class Task102 : InfoBasicTask
    {
        public Task102(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(3, new TreeNode(8), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            printBinaryTreeUsingList(root);
            if (isValid(root))
            {
                IList<IList<int>> result = levelOrder(root);
                printIListIListInt(result, "Значение узлов дерева по уровням: ");
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
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = 2000;
            int lowLimitValueNode = -1000;
            int highLimitValueNode = 1000;
            int countNodes = 0;
            if (root != null)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    TreeNode currentNode = queue.Dequeue();
                    countNodes++;
                    if (currentNode.val < lowLimitValueNode || currentNode.val > highLimitValueNode)
                    {
                        return false;
                    }
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> levelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            List<TreeNode> nodesOfCurrentLevel = new List<TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();
                nodesOfCurrentLevel.Add(currentNode);
                if (queue.Count == 0)
                {
                    List<int> vals = new List<int>();
                    foreach (TreeNode node in nodesOfCurrentLevel)
                    {
                        vals.Add(node.val);
                        if (node.left != null)
                        {
                            queue.Enqueue(node.left);
                        }
                        if (node.right != null)
                        {
                            queue.Enqueue(node.right);
                        }
                    }
                    nodesOfCurrentLevel.Clear();
                    result.Add(vals);
                }
            }
            return result;
        }
    }
}
