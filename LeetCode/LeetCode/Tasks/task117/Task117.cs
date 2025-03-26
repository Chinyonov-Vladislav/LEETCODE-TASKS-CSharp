using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task117
{
    /*
     117. Заполнение следующих указателей вправо в каждом узле II
    Дано бинарное дерево
        структура Node {
         int val;
         Node *left;
         Node *right;
         Node *next;
        }
    Заполните каждый следующий указатель, чтобы он указывал на следующий правый узел. Если следующего правого узла нет, следующий указатель должен быть установлен на NULL.
    Изначально всем следующим указателям присваивается значение NULL.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 6000].
        -100 <= Node.val <= 100
    https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/description/
     */
    public class Task117 : InfoBasicTask
    {
        public Task117(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNodeWithPointerOnRightNode root = new TreeNodeWithPointerOnRightNode(1, new TreeNodeWithPointerOnRightNode(2, new TreeNodeWithPointerOnRightNode(4), new TreeNodeWithPointerOnRightNode(5), null), new TreeNodeWithPointerOnRightNode(3, null, new TreeNodeWithPointerOnRightNode(7), null), null);
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
            int highLimitCountNodes = 6000;
            int lowLimitValueNode = -100;
            int highLimitValueNode = 100;
            int countNodes = 0;
            Queue<TreeNodeWithPointerOnRightNode> queue = new Queue<TreeNodeWithPointerOnRightNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNodeWithPointerOnRightNode currentNode = queue.Dequeue();
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
            List<TreeNodeWithPointerOnRightNode> nodesOfNextLevel = new List<TreeNodeWithPointerOnRightNode>();
            TreeNodeWithPointerOnRightNode dummyHead = root;
            Queue<TreeNodeWithPointerOnRightNode> queue = new Queue<TreeNodeWithPointerOnRightNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNodeWithPointerOnRightNode currentNode = queue.Dequeue();
                if (currentNode.left != null)
                {
                    nodesOfNextLevel.Add(currentNode.left);
                }
                if (currentNode.right != null)
                { 
                    nodesOfNextLevel.Add(currentNode.right);
                }
                if (queue.Count == 0)
                {
                    for (int i = 0; i < nodesOfNextLevel.Count-1; i++)
                    {
                        nodesOfNextLevel[i].next = nodesOfNextLevel[i + 1];
                    }
                    for (int i = 0; i < nodesOfNextLevel.Count; i++)
                    {
                        queue.Enqueue(nodesOfNextLevel[i]);
                    }
                    nodesOfNextLevel.Clear();
                }
            }
            return dummyHead;
        }
    }
}
