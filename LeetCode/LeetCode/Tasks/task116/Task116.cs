using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task116
{
    /*
     116. Заполнение следующих указателей вправо в каждом узле
    Вам дано идеальное двоичное дерево, в котором все листья находятся на одном уровне, а у каждого родителя есть два ребёнка. Двоичное дерево определяется следующим образом:
        структура Node {
         int val;
         Node *left;
         Node *right;
         Node *next;
        }
    Заполните каждый следующий указатель, чтобы он указывал на следующий правый узел. Если следующего правого узла нет, следующий указатель должен быть установлен на NULL.
    Изначально всем следующим указателям присваивается значение NULL.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 212 - 1].
        -1000 <= Node.val <= 1000
    https://leetcode.com/problems/populating-next-right-pointers-in-each-node/description/
     */
    public class Task116 : InfoBasicTask
    {
        public Task116(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNodeWithPointerOnRightNode root = new TreeNodeWithPointerOnRightNode(1, new TreeNodeWithPointerOnRightNode(2, new TreeNodeWithPointerOnRightNode(4), new TreeNodeWithPointerOnRightNode(5),null), new TreeNodeWithPointerOnRightNode(3, new TreeNodeWithPointerOnRightNode(6), new TreeNodeWithPointerOnRightNode(7), null), null);
            printTreeNodeWithPointerOnRightNode(root);
            if (isValid(root))
            {
                TreeNodeWithPointerOnRightNode result = connect(root);
                printTreeNodeWithPointerOnRightNode(result, "Результирующее двоичное дерево с указателем на правый узел на одном уровне");
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
        private bool isValid(TreeNodeWithPointerOnRightNode root)
        {
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = (int)Math.Pow(2, 12) - 1;
            int lowLimitValueNode = -1000;
            int highLimitValueNode = 1000;
            int countNodes = 0;
            while (root != null)
            {
                if (root.val < lowLimitValueNode || root.val > highLimitValueNode)
                {
                    return false;
                }
                if ((root.left == null && root.right != null) || (root.left != null && root.right == null))
                {
                    return false;
                }
                countNodes++;
                root = root.left;
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private TreeNodeWithPointerOnRightNode connect(TreeNodeWithPointerOnRightNode root)
        {
            if (root == null)
            {
                return root;
            }
            List<TreeNodeWithPointerOnRightNode> nodesOfCurrentLevel = new List<TreeNodeWithPointerOnRightNode>();
            int currentLevel = 0;
            TreeNodeWithPointerOnRightNode dummyHead = root;
            Queue<TreeNodeWithPointerOnRightNode> queue = new Queue<TreeNodeWithPointerOnRightNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNodeWithPointerOnRightNode currentNode = queue.Dequeue();
                nodesOfCurrentLevel.Add(currentNode);
                if (nodesOfCurrentLevel.Count == Math.Pow(2, currentLevel))
                {
                    for (int i = 0; i < nodesOfCurrentLevel.Count; i++)
                    {
                        if (i == nodesOfCurrentLevel.Count - 1)
                        {
                            nodesOfCurrentLevel[i].next = null;
                        }
                        else
                        {
                            nodesOfCurrentLevel[i].next = nodesOfCurrentLevel[i+1];
                        }
                    }
                    nodesOfCurrentLevel.Clear();
                    currentLevel++;
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
            return dummyHead;
        }
    }
}
