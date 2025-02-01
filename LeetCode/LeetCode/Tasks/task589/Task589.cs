using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task589
{
    /*
     589. Прямой обход N-арного дерева
    Учитывая root n-арного дерева, верните последовательность обхода его узлов в прямом порядке.
    Сериализация входных данных Nary-Tree представлена в виде обхода по уровням. Каждая группа дочерних элементов разделена нулевым значением
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 104]
        0 <= Node.val <= 104
        Высота n-разрядного дерева меньше или равна 1000.
    https://leetcode.com/problems/n-ary-tree-preorder-traversal/description/
     */
    public class Task589 : InfoBasicTask
    {
        public Task589(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            Node node = new Node(1, new List<Node>() { new Node(3, new List<Node>() { new Node(5), new Node(6) }), new Node(2), new Node(4)  });
            IList<int> result = preorder(node);
            printIListInt(result, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> preorder(Node root)
        {
            IList<int> result = new List<int>();
            travel(root, result);
            return result;
        }
        // рекурсивное решение
        private void travel(Node root, IList<int> result)
        {
            if (root == null)
            {
                return;
            }
            result.Add(root.val);
            if (root.children != null)
            {
                foreach (Node child in root.children) {
                    travel(child, result);
                }
            }
        }
        // итеративное решение -> скопировано с leetcode
        private IList<int> bestSolution(Node root)
        {
            IList<int> list = new List<int>();
            if (root == null)
            {
                return list;
            } 
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                root = stack.Pop();
                list.Add(root.val);
                for (int i = root.children.Count - 1; i > -1; i--)
                {
                    stack.Push(root.children[i]);
                }
            }
            return list;
        }
    }
}
