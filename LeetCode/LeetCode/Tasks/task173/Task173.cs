using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task173
{
    /*
     173. Итератор бинарного дерева поиска
    Реализуйте класс BSTIterator, представляющий итератор для последовательного обхода двоичного дерева поиска (BST):
        BSTIterator(TreeNode root) Инициализирует объект BSTIterator класса. Значение root BST задается как часть конструктора. Указатель должен быть инициализирован несуществующим числом, меньшим, чем любой элемент в BST.
        boolean hasNext() Возвращает true, если в массиве справа от указателя есть число, в противном случае возвращает false.
        int next() Перемещает указатель вправо, затем возвращает число, указанное в указателе.
    Обратите внимание, что при инициализации указателя несуществующим наименьшим числом первый вызов next() вернёт наименьший элемент в двоичном дереве поиска.
    Вы можете предположить, что вызовы next() всегда будут корректными. То есть при вызове next() будет как минимум следующее число в последовательном обходе.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [1, 10^5].
        0 <= Node.val <= 10^6
        Не более 10^5 звонков будет сделано на hasNext, и next.
     */
    public class Task173 : InfoBasicTask
    {
        public Task173(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(7, new TreeNode(3), new TreeNode(15, new TreeNode(9), new TreeNode(10)));
            string[] operations = new string[] { "next", "next", "hasNext", "next", "hasNext", "next", "hasNext", "next", "hasNext" };
            printBinaryTreeUsingList(root, "Бинарное дерево поиска");
            if (isValid(root, operations))
            {
                BSTIterator iter = new BSTIterator(root);
                foreach (string operation in operations)
                {
                    switch (operation)
                    {
                        case "next":
                            int val = iter.Next();
                            Console.WriteLine($"Значение узла в бинарном дереве поиска = {val}");
                            break;
                        case "hasNext":
                            bool res = iter.HasNext();
                            Console.WriteLine(res ? "Существует следующий элемент в бинарном дереве поиска" : "Отсутствует следующий элемент в бинарном дереве поиска");
                            break;
                    }
                }
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
        private bool isValid(TreeNode root, string[] operations)
        {
            int highLimitCountOperations = (int)Math.Pow(10,5);
            int countOperationNext = 0;
            int countOperationHasNext = 0;
            int lowLimitValueNode = 0;
            int highLimitValueNode = (int)Math.Pow(10,6);
            int lowLimitCountNodesInTreeNode = 1;
            int highLimitCountNodesInTreeNode = (int)Math.Pow(10,5);
            int countNodes = 0;
            foreach (string operation in operations)
            {
                switch (operation)
                {
                    case "next":
                        countOperationNext++;
                        break;
                    case "hasNext":
                        countOperationHasNext++;
                        break;
                }
            }
            if (countOperationNext > highLimitCountOperations || countOperationHasNext > highLimitCountOperations)
            {
                return false;
            }
            if (root != null)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                
                while (queue.Count > 0)
                {
                    TreeNode treeNode = queue.Dequeue();
                    countNodes++;
                    if (treeNode.val < lowLimitValueNode || treeNode.val > highLimitValueNode)
                    {
                        return false;
                    }
                    if (treeNode.left != null)
                    {
                        queue.Enqueue(treeNode.left);
                    }
                    if (treeNode.right != null)
                    {
                        queue.Enqueue(treeNode.right);
                    }
                }
            }
            if (countNodes < lowLimitCountNodesInTreeNode || countNodes > highLimitCountNodesInTreeNode || countOperationNext > countNodes)
            {
                return false;
            }
            return true;
        }
    }
}
