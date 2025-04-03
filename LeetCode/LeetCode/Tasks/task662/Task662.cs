using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task662
{
    /*
     662. Максимальная ширина двоичного дерева
    Учитывая root двоичного дерева, верните значение максимальной ширины данного дерева.
    Максимальная ширина дерева — это максимальная ширинасреди всех уровней.
    Ширина одного уровня определяется как расстояние между конечными узлами (крайними левым и крайним правым ненулевыми узлами), где нулевые узлы между конечными узлами, которые присутствовали бы в полном двоичном дереве, простирающемся до этого уровня, также учитываются при расчёте длины.
    Гарантируется, что ответ будет в диапазоне от 32-разрядный целое число со знаком.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [1, 3000].
        -100 <= Node.val <= 100
    https://leetcode.com/problems/maximum-width-of-binary-tree/description/
     */
    public class Task662 : InfoBasicTask
    {
        public Task662(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode tree = new TreeNode(1, new TreeNode(3, new TreeNode(5), new TreeNode(3)), new TreeNode(2, null, new TreeNode(9)));
            printBinaryTreeUsingList(tree);
            if (isValid(tree))
            {
                int res = widthOfBinaryTree(tree);
                Console.WriteLine($"Максимальная ширина двоичного дерева = {res}");
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
            int lowLimitValueNode = -100;
            int highLimitValueNode = 100;
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = 3000;
            int countNodes = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                countNodes++;
                if (node.val < lowLimitValueNode || node.val > highLimitValueNode)
                {
                    return false;
                }
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private int widthOfBinaryTree(TreeNode root)
        {
            long max = 0;
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(root, 1));
            List<Tuple<TreeNode, int>> nodesOfCurrentLevel = new List<Tuple<TreeNode, int>>();
            while (queue.Count > 0)
            {
                Tuple<TreeNode, int> currentNode = queue.Dequeue();
                nodesOfCurrentLevel.Add(currentNode);
                if (queue.Count == 0)
                {
                    long distance = nodesOfCurrentLevel[nodesOfCurrentLevel.Count - 1].Item2 - nodesOfCurrentLevel[0].Item2 + 1;
                    if (distance > max)
                    {
                        max = distance;
                    }
                    foreach (Tuple<TreeNode, int> node in nodesOfCurrentLevel)
                    {
                        if (node.Item1.left != null)
                        {
                            queue.Enqueue(new Tuple<TreeNode, int>(node.Item1.left, node.Item2 * 2 + 1));
                        }
                        if (node.Item1.right != null)
                        {
                            queue.Enqueue(new Tuple<TreeNode, int>(node.Item1.right, node.Item2 * 2 + 2));
                        }
                    }
                    nodesOfCurrentLevel.Clear();
                }
            }
            return (int)max;
        }
    }
}
