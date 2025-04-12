using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task103
{
    /*
     103. Обход бинарного дерева по уровням в зигзагообразном стиле
    Учитывая root двоичного дерева, верните зигзагообразный порядок обхода его узлов по уровням. (то есть слева направо, затем справа налево для следующего уровня и чередуя между ними).
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 2000].
        -100 <= Node.val <= 100
    https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
     */
    public class Task103 : InfoBasicTask
    {
        public Task103(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            printBinaryTreeUsingList(root);
            if (isValid(root))
            {
                IList<IList<int>> result = zigzagLevelOrder(root);
                printIListIListInt(result, "Значение узлов дерева по уровням в зигзагообразном виде (четные уровни - слева направо, нечетные уровни - справо налево)");
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
            int lowLimitValueNode = -100;
            int highLimitValueNode = 100;
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
        private IList<IList<int>> zigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            int numberLevel = 0;
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
                    if (numberLevel % 2 != 0)
                    {
                        vals.Reverse();
                    }
                    numberLevel++;
                    result.Add(vals);
                }
            }
            return result;
        }
    }
}
