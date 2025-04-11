using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task513
{
    /*
     513. Найдите значение дерева в нижнем левом углу
    Учитывая root двоичного дерева, верните самое левое значение в последнем ряду дерева.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [1, 104].
        -2^31 <= Node.val <= 2^31 - 1
    https://leetcode.com/problems/find-bottom-left-tree-value/description/
     */
    public class Task513 : InfoBasicTask
    {
        public Task513(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4)), new TreeNode(3, new TreeNode(5, new TreeNode(7)), new TreeNode(6, new TreeNode(8))));
            printBinaryTreeUsingList(root);
            if (isValid(root))
            {
                int res = findBottomLeftValue(root);
                Console.WriteLine($"Значение самого левого узла на последнем уровне = {res}");
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
            if (root == null)
            {
                return false;
            }
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = (int)Math.Pow(10,4);
            int countNodes = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            List<TreeNode> nodesOfCurrentLevel = new List<TreeNode>();
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                nodesOfCurrentLevel.Add(node);
                countNodes++;
                if (queue.Count == 0)
                {
                    for (int i = 0; i < nodesOfCurrentLevel.Count; i++)
                    {
                        if (nodesOfCurrentLevel[i].left != null)
                        {
                            queue.Enqueue(nodesOfCurrentLevel[i].left);
                        }
                        if (nodesOfCurrentLevel[i].right != null)
                        {
                            queue.Enqueue(nodesOfCurrentLevel[i].right);
                        }
                    }
                    nodesOfCurrentLevel.Clear();
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private int findBottomLeftValue(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            List<TreeNode> nodesOfCurrentLevel = new List<TreeNode>();
            TreeNode leftNodeOfLastLevel = null;
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                nodesOfCurrentLevel.Add(node);
                if (queue.Count == 0)
                {
                    for (int i = 0; i < nodesOfCurrentLevel.Count; i++)
                    {
                        if (nodesOfCurrentLevel[i].left != null)
                        {
                            queue.Enqueue(nodesOfCurrentLevel[i].left);
                        }
                        if (nodesOfCurrentLevel[i].right != null)
                        {
                            queue.Enqueue(nodesOfCurrentLevel[i].right);
                        }
                    }
                    if (queue.Count == 0)
                    {
                        leftNodeOfLastLevel = nodesOfCurrentLevel[0];
                    }
                    nodesOfCurrentLevel.Clear();
                }
            }
            return leftNodeOfLastLevel.val;
        }
    }
}
