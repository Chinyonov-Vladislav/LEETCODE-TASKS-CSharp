using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task429
{
    /*
     429. Обход порядка на уровне N-арного дерева
    Для заданного n-арного дерева верните последовательность уровней обхода его узлов.
    Сериализация входных данных Nary-Tree представлена в виде обхода по уровням, каждая группа дочерних элементов отделена нулевым значением
    Ограничения:
        Высота n-арного дерева меньше или равна 1000
        Общее количество узлов находится между [0, 10^4]
    https://leetcode.com/problems/n-ary-tree-level-order-traversal/description/
     */
    public class Task429 : InfoBasicTask
    {
        public Task429(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            Node node = new Node(1, new List<Node>() { new Node(3, new List<Node>() { new Node(5),new Node(6) }), new Node(2), new Node(4) });
            printN_aryTree(node);
            if (isValid(node))
            {
                IList<IList<int>> res = levelOrder(node);
                printIListIListInt(res, "Значения узлов N-арного дерева по уровням: ");
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
        private bool isValid(Node root)
        {
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = (int)Math.Pow(10,4);
            int lowLimitHeight = -1;
            int highLimitHeight = 1000;
            int totalCountNodes = 0;
            int height = -1;
            if (root != null)
            {
                height = 0;
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                List<Node> nodesOfCurrentLevel = new List<Node>();
                while (queue.Count > 0)
                {
                    Node currentNode = queue.Dequeue();
                    totalCountNodes++;
                    nodesOfCurrentLevel.Add(currentNode);
                    if (queue.Count == 0)
                    {
                        foreach (Node node in nodesOfCurrentLevel)
                        {
                            if (node.children != null)
                            {
                                foreach (Node nodeOfNextLevel in node.children)
                                {
                                    queue.Enqueue(nodeOfNextLevel);
                                }
                            }
                        }
                        nodesOfCurrentLevel.Clear();
                        if (queue.Count > 0)
                        {
                            height++;
                        }
                    }
                }
            }
            if (totalCountNodes < lowLimitCountNodes || totalCountNodes > highLimitCountNodes || height < lowLimitHeight || height > highLimitHeight)
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> levelOrder(Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            List<Node> nodesOfCurrentLevel = new List<Node>();
            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();
                nodesOfCurrentLevel.Add(currentNode);
                if (queue.Count == 0)
                {
                    IList<int> valuesOfNodesCurrentLevel = new List<int>();
                    foreach (Node node in nodesOfCurrentLevel)
                    {
                        valuesOfNodesCurrentLevel.Add(node.val);
                        if (node.children != null)
                        {
                            foreach (Node nodeOfNextLevel in node.children)
                            {
                                queue.Enqueue(nodeOfNextLevel);
                            }
                        }
                    }
                    nodesOfCurrentLevel.Clear();
                    result.Add(valuesOfNodesCurrentLevel);
                }
            }
            return result;
        }
    }
}
