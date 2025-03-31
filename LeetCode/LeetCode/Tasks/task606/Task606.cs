using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task606
{
    /*
     606. Постройте строку из двоичного дерева
    Учитывая узел root двоичного дерева, ваша задача состоит в том, чтобы создать строковое представление дерева в соответствии с определённым набором правил форматирования. Представление должно быть основано на обходе двоичного дерева в прямом порядке и соответствовать следующим рекомендациям:
        Представление узлов: каждый узел в дереве должен быть представлен своим целочисленным значением.
        Скобки для дочерних элементов: если у узла есть хотя бы один дочерний элемент (левый или правый), его дочерние элементы должны быть заключены в скобки. В частности:
            Если у узла есть левый дочерний элемент, значение левого дочернего элемента должно быть заключено в скобки сразу после значения узла.
            Если у узла есть дочерний элемент справа, значение дочернего элемента справа также должно быть заключено в скобки. Скобки для дочернего элемента справа должны следовать за скобками для дочернего элемента слева.
        Опущение пустых скобок: любые пустые пары скобок (т. е. ()) следует опускать в итоговом строковом представлении дерева, за одним исключением: когда у узла есть правый дочерний элемент, но нет левого дочернего элемента. В таких случаях необходимо включить пустую пару скобок, чтобы указать на отсутствие левого дочернего элемента. Это гарантирует, что между строковым представлением и исходной структурой двоичного дерева будет сохраняться взаимно-однозначное соответствие.
    Таким образом, пустые пары скобок следует опускать, если у узла есть только левый дочерний элемент или если дочерних элементов нет. Однако если у узла есть правый дочерний элемент, но нет левого дочернего элемента, пустая пара скобок должна предшествовать представлению правого дочернего элемента, чтобы точно отразить структуру дерева.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [1, 10^4].
        -1000 <= Node.val <= 1000
    https://leetcode.com/problems/construct-string-from-binary-tree/description/
     */
    public class Task606 : InfoBasicTask
    {
        public Task606(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(1, new TreeNode(2, null, new TreeNode(4)), new TreeNode(3));
            Console.WriteLine("Исходное бинарное дерево");
            printTreeNode(treeNode);
            if (isValid(treeNode))
            {
                string res = tree2str(treeNode);
                Console.WriteLine($"Исходное бинарное дерево в формате строки: \"{res}\"");
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
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = (int)Math.Pow(10, 4);
            int lowLimitValueNode = -1000;
            int highLimitValueNode = 1000;
            int countNodes = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            HashSet<TreeNode> visitedNodes = new HashSet<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode currentRoot = stack.Pop();
                if (!visitedNodes.Contains(currentRoot))
                {
                    if (currentRoot.val < lowLimitValueNode || currentRoot.val > highLimitValueNode)
                    {
                        return false;
                    }
                    countNodes++;
                    visitedNodes.Add(currentRoot);
                }
                if (currentRoot.left != null && !visitedNodes.Contains(currentRoot.left))
                {
                    stack.Push(currentRoot);
                    stack.Push(currentRoot.left);
                }
                else if (currentRoot.right != null && !visitedNodes.Contains(currentRoot.right))
                {
                    stack.Push(currentRoot);
                    stack.Push(currentRoot.right);
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private string tree2str(TreeNode root)
        {
            StringBuilder res = new StringBuilder();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            HashSet<TreeNode> visitedNodes = new HashSet<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode currentRoot = stack.Pop();
                if (!visitedNodes.Contains(currentRoot))
                {
                    res.Append(currentRoot != root ? $"({currentRoot.val}" : $"{currentRoot.val}");
                    if (currentRoot.left == null && currentRoot.right != null)
                    {
                        res.Append("()");
                    }
                    visitedNodes.Add(currentRoot);
                }
                if (currentRoot != root)
                {
                    if ((currentRoot.left == null && currentRoot.right == null)
                        || (currentRoot.left == null && visitedNodes.Contains(currentRoot.right))
                        || (currentRoot.right == null && visitedNodes.Contains(currentRoot.left))
                        || (visitedNodes.Contains(currentRoot.left) && visitedNodes.Contains(currentRoot.right)))
                    {
                        res.Append(")");
                    }
                }
                if (currentRoot.left != null && !visitedNodes.Contains(currentRoot.left))
                {
                    stack.Push(currentRoot);
                    stack.Push(currentRoot.left);
                }
                else if (currentRoot.right != null && !visitedNodes.Contains(currentRoot.right))
                {
                    stack.Push(currentRoot);
                    stack.Push(currentRoot.right);
                }
            }
            return res.ToString();
        }
    }
}
