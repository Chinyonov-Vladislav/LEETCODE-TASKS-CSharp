using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task655
{
    /*
     655. Вывести двоичное дерево
    Учитывая root двоичное дерево, постройте строковую матрицу с m x nиндексом 0res, которая представляет форматированный макет дерева. 
    Форматированная матрица компоновки должна быть построена с использованием следующих правил:
        Высота дерева составляет height, а количество строк m должно быть равно height + 1.
        Количество столбцов n должно быть равно 2height+1 - 1.
        Поместите корневой узел в середину верхнего ряда (точнее, в место res[0][(n-1)/2]).
        Для каждого узла, помещённого в матрицу в позицию res[r][c], поместите его левого потомка в res[r+1][c-2^(height-r-1)] и правого потомка в res[r+1][c+2^(height-r-1)].
        Продолжайте этот процесс до тех пор, пока не будут размещены все узлы в дереве.
        Любые пустые ячейки должны содержать пустую строку "".
    Возвращает построенную матрицу res.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [1, 2^10].
        -99 <= Node.val <= 99
        Глубина дерева будет находиться в диапазоне [1, 10].
    https://leetcode.com/problems/print-binary-tree/description/
     */
    public class Task655 : InfoBasicTask
    {
        public Task655(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(1, new TreeNode(2, null, new TreeNode(4)), new TreeNode(3));
            Console.WriteLine("Бинарное дерево");
            printTreeNode(treeNode);
            if (isValid(treeNode))
            {
                IList<IList<string>> res = printTree(treeNode);
                printIListIListString(res, false, "Бинарное дерево в виде массива для вывода");
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
            int highLimitCountNodes = (int)Math.Pow(2, 10);
            int lowLimitValueNode = -99;
            int highLimitValueNode = 99;
            int lowLimitHeight = 1;
            int highLimitHeight = 10;
            int countNodes = 0;
            int maxDepth = 0;
            int currentDepth = 0;
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (visitedNodes.Contains(treeNode))
                {
                    currentDepth--;
                }
                else
                {
                    if (treeNode.val < lowLimitValueNode || treeNode.val > highLimitValueNode)
                    {
                        return false;
                    }
                    countNodes++;
                    if (currentDepth > maxDepth)
                    {
                        maxDepth = currentDepth;
                    }
                    visitedNodes.Add(treeNode);
                }
                if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                    currentDepth++;
                }
                else if (treeNode.right != null && !visitedNodes.Contains(treeNode.right))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.right);
                    currentDepth++;
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes || maxDepth < lowLimitHeight || maxDepth>highLimitHeight)
            {
                return false;
            }
            return true;
        }
        private IList<IList<string>> printTree(TreeNode root)
        {
            int height = findHeightOfTreeNode(root);
            int countRows = height + 1;
            int countColumns = (int)Math.Pow(2, height+1) - 1;
            IList<IList<string>> result = new List<IList<string>>();
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                result.Add(new List<string>());
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    result[indexRow].Add("");
                }
            }
            HashSet<TreeNode> visitedNodes = new HashSet<TreeNode>();
            Stack<Tuple<TreeNode, int[]>> stack = new Stack<Tuple<TreeNode, int[]>>();
            stack.Push(new Tuple<TreeNode, int[]>(root, null));
            while (stack.Count > 0)
            {
                Tuple<TreeNode, int[]> currentNodeFromStack = stack.Pop();
                int currentRowPosition = 0;
                int currentColumnPosition = 0;
                if (currentNodeFromStack.Item2 == null)
                {
                    currentRowPosition = 0;
                    currentColumnPosition = (countColumns - 1) / 2;
                }
                else
                {
                    if (currentNodeFromStack.Item2[2] == -1) // левый потомок
                    {
                        currentRowPosition = currentNodeFromStack.Item2[0] + 1;
                        currentColumnPosition = currentNodeFromStack.Item2[1] - (int)Math.Pow(2, height - currentNodeFromStack.Item2[0] - 1);
                    }
                    else // правый потомок
                    {
                        currentRowPosition = currentNodeFromStack.Item2[0] + 1;
                        currentColumnPosition = currentNodeFromStack.Item2[1] + (int)Math.Pow(2, height - currentNodeFromStack.Item2[0] - 1);
                    }
                }
                if (!visitedNodes.Contains(currentNodeFromStack.Item1))
                {
                    result[currentRowPosition][currentColumnPosition] = $"{currentNodeFromStack.Item1.val}";
                    visitedNodes.Add(currentNodeFromStack.Item1);
                }
                if (currentNodeFromStack.Item1.left != null && !visitedNodes.Contains(currentNodeFromStack.Item1.left))
                {
                    stack.Push(currentNodeFromStack);
                    stack.Push(new Tuple<TreeNode, int[]>(currentNodeFromStack.Item1.left, new int[] { currentRowPosition, currentColumnPosition, -1 }));
                }
                else if (currentNodeFromStack.Item1.right != null && !visitedNodes.Contains(currentNodeFromStack.Item1.right))
                {
                    stack.Push(currentNodeFromStack);
                    stack.Push(new Tuple<TreeNode, int[]>(currentNodeFromStack.Item1.right, new int[] { currentRowPosition, currentColumnPosition, 1 }));
                }
            }
            return result;
        }
        private int findHeightOfTreeNode(TreeNode root)
        {
            int max = 0;
            int currentDepth = 0;
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (visitedNodes.Contains(treeNode))
                {
                    currentDepth--;
                }
                else
                {
                    if (currentDepth > max)
                    {
                        max = currentDepth;
                    }
                    visitedNodes.Add(treeNode);
                }
                if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                    currentDepth++;
                }
                else if (treeNode.right != null && !visitedNodes.Contains(treeNode.right))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.right);
                    currentDepth++;
                }
            }
            return max;
        }
    }
}
