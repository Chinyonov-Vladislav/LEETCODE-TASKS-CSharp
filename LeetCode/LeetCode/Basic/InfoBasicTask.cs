using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace LeetCode.Basic
{
    public abstract class InfoBasicTask
    {
        private int number;
        private string name;
        private string description;
        private Difficult difficult;
        public InfoBasicTask(int number, string name, string description, Difficult difficult)
        {
            this.number = number;
            this.name = name;
            this.description = description;
            this.difficult = difficult;
        }
        public Difficult getDifficult()
        {
            return difficult;
        }
        public int getNumber()
        {
            return number;
        }
        public string getName()
        {
            return name;
        }
        public string getDescription()
        {
            return description;
        }
        public abstract void execute();
        public abstract void testing();

        protected void printInfoNotValidData()
        {
            Console.WriteLine("Исходные данные не валидны!");
        }
        protected void printValuesFromListNode(ListNode listNode, int numberCurrentNode = 0)
        {
            if (listNode == null && numberCurrentNode == 0)
            {
                Console.WriteLine("Корневой узел отсутствует");
                return;
            }
            HashSet<ListNode> listNodesSet = new HashSet<ListNode>();
            while (listNode != null)
            {
                if (listNodesSet.Contains(listNode))
                {
                    Console.WriteLine($"Информация при выводе: связанный список имеет зацикленность в узле со значением = {listNode.val}");
                    break;
                }
                listNodesSet.Add(listNode);
                Console.WriteLine($"Номер узла = {numberCurrentNode} | Значение = {listNode.val}");
                numberCurrentNode++;
                listNode = listNode.next;
            }
        }
        protected void printArray(char[] chars, string headerStr = "Исходный массив символов: ")
        {
            if (chars == null)
            {
                Console.WriteLine("Отсутствует объект массива");
            }
            else if (chars.Length == 0)
            {
                Console.WriteLine("Массив символов строки пуст");
            }
            else if (chars.Length == 1)
            {
                Console.Write($"{headerStr}[{chars[0]}]\n");
            }
            else
            {
                Console.Write(headerStr);
                for (int i = 0; i < chars.Length; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{chars[i]}, ");
                    }
                    else if (i == chars.Length - 1)
                    {
                        Console.Write($"{chars[i]}]\n");
                    }
                    else
                    {
                        Console.Write($"{chars[i]}, ");
                    }
                }
            }
        }
        protected void printArray(int[] values, string headerStr = "Исходный массив целых чисел: ")
        {
            if (values == null)
            {
                Console.WriteLine("Отсутствует объект массива");
            }
            else if (values.Length == 0)
            {
                Console.WriteLine("Массив целых значений пуст");
            }
            else if (values.Length == 1)
            {
                Console.Write($"{headerStr}[{values[0]}]\n");
            }
            else
            {
                Console.Write(headerStr);
                for (int i = 0; i < values.Length; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{values[i]}, ");
                    }
                    else if (i == values.Length - 1)
                    {
                        Console.Write($"{values[i]}]\n");
                    }
                    else
                    {
                        Console.Write($"{values[i]}, ");
                    }
                }
            }
        }
        protected void printArray(string[] strings, string headerStr = "Исходный массив строк: ", bool inline = true)
        {
            if (strings == null)
            {
                Console.WriteLine("Отсутствует объект массива");
            }
            else if (strings.Length == 0)
            {
                Console.WriteLine("Массив символов строки пуст");
            }
            else if (strings.Length == 1)
            {
                Console.Write($"{headerStr}[{strings[0]}]\n");
            }
            else
            {
                if (inline)
                {
                    Console.Write(headerStr);
                    for (int i = 0; i < strings.Length; i++)
                    {
                        if (i == 0)
                        {
                            Console.Write($"[{strings[i]}, ");
                        }
                        else if (i == strings.Length - 1)
                        {
                            Console.Write($"{strings[i]}]\n");
                        }
                        else
                        {
                            Console.Write($"{strings[i]}, ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(headerStr);
                    for (int i = 0; i < strings.Length; i++)
                    {
                        Console.WriteLine($"[{strings[i]}]");
                    }
                }
            }
        }
        protected void printArray(int[][] nums, string headerStr = "Исходный двумерный массив")
        {
            Console.WriteLine(headerStr);
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[i].Length; j++)
                {
                    Console.Write($"{nums[i][j]} \t");
                }
                Console.WriteLine();
            }
        }
        protected void printIListString(IList<string> list, string header)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Пустой список из строк");
            }
            else if (list.Count == 1)
            {
                Console.WriteLine($"Результат: [{list[0]}]");
            }
            else
            {
                Console.Write($"{header}");
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{list[i]}, ");
                    }
                    else if (i == list.Count - 1)
                    {
                        Console.Write($"{list[i]}]\n");
                    }
                    else
                    {
                        Console.Write($"{list[i]}, ");
                    }
                }
            }
        }
        protected void printIListInt(IList<int> list, string header = "Исходный список чисел: ")
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Пустой список");
            }
            else if (list.Count == 1)
            {
                Console.WriteLine($"{header}: [{list[0]}]");
            }
            else
            {
                Console.Write($"{header}");
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{list[i]}, ");
                    }
                    else if (i == list.Count - 1)
                    {
                        Console.Write($"{list[i]}]\n");
                    }
                    else
                    {
                        Console.Write($"{list[i]}, ");
                    }
                }
            }
        }
        protected void printIListIListInt(IList<IList<int>> list, string header = "Исходный список списков целых чисел")
        {
            if (list.Count == 0)
            {
                Console.WriteLine($"{header}: пустой список");
            }
            else if (list.Count == 1)
            {
                Console.Write($"{header}: [");
                for (int i = 0; i < list[0].Count; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{list[0][i]}, ");
                    }
                    else if (i == list[0].Count - 1)
                    {
                        Console.Write($"{list[0][i]}]");
                    }
                    else
                    {
                        Console.Write($"{list[0][i]}, ");
                    }
                }
                Console.WriteLine($"]");
            }
            else
            {

                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"{header}: [");
                    }
                    if (list[i].Count > 1)
                    {
                        for (int j = 0; j < list[i].Count; j++)
                        {
                            if (j == 0)
                            {
                                Console.Write($"[{list[i][j]}, ");
                            }
                            else if (j == list[i].Count - 1 && i == list.Count - 1)
                            {
                                Console.Write($"{list[i][j]}]");
                            }
                            else if (j == list[i].Count - 1 && i != list.Count - 1)
                            {
                                Console.Write($"{list[i][j]}], ");
                            }
                            else
                            {
                                Console.Write($"{list[i][j]}, ");
                            }
                        }
                    }
                    else if (list[i].Count == 1 && i != list.Count - 1)
                    {
                        Console.Write($"[{list[i][0]}], ");
                    }
                    else if (list[i].Count == 1 && i == list.Count - 1)
                    {
                        Console.Write($"[{list[i][0]}]");
                    }
                    else
                    {
                        Console.Write("[]");
                    }
                    if (i == list.Count - 1)
                    {
                        Console.Write($"]\n");
                    }
                }
            }
        }

        protected void printIListIListString(IList<IList<string>> list, bool inline = true, string header = "Результат")
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Пустой список");
            }
            else if (list.Count == 1)
            {
                Console.WriteLine($"{header}: [");
                for (int i = 0; i < list[0].Count; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{list[0][i]}, ");
                    }
                    else if (i == list[0].Count - 1)
                    {
                        Console.Write($"{list[0][i]}]");
                    }
                    else
                    {
                        Console.Write($"{list[0][i]}, ");
                    }
                }
                Console.WriteLine($"]");
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (!inline)
                    {
                        if (i > 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    if (i == 0)
                    {
                        if (inline)
                        {
                            Console.Write($"{header}: [");
                        }
                        else
                        {
                            Console.Write($"{header}\n[");
                        }
                    }
                    if (list[i].Count > 1)
                    {
                        for (int j = 0; j < list[i].Count; j++)
                        {
                            if (j == 0)
                            {
                                Console.Write($"[{list[i][j]}, ");
                            }
                            else if (j == list[i].Count - 1 && i == list.Count - 1)
                            {
                                Console.Write($"{list[i][j]}]");
                            }
                            else if (j == list[i].Count - 1 && i != list.Count - 1)
                            {
                                Console.Write($"{list[i][j]}],");
                            }
                            else
                            {
                                Console.Write($"{list[i][j]}, ");
                            }
                        }
                    }
                    else if (list[i].Count == 1)
                    {
                        Console.Write($"[{list[i][0]}]");
                    }
                    else
                    {
                        Console.Write("[]");
                    }
                    if (i == list.Count - 1)
                    {
                        Console.Write($"]\n");
                    }
                }
            }
        }

        protected void printIListBool(IList<bool> list, string header)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Пустой список");
            }
            else if (list.Count == 1)
            {
                Console.WriteLine($"Результат: [{list[0]}]");
            }
            else
            {
                Console.Write($"{header}");
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{list[i]}, ");
                    }
                    else if (i == list.Count - 1)
                    {
                        Console.Write($"{list[i]}]\n");
                    }
                    else
                    {
                        Console.Write($"{list[i]}, ");
                    }
                }
            }
        }

        protected void printIListDouble(IList<double> list, string header)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Пустой список");
            }
            else if (list.Count == 1)
            {
                Console.WriteLine($"Результат: [{list[0]}]");
            }
            else
            {
                Console.Write($"{header}");
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{list[i]}, ");
                    }
                    else if (i == list.Count - 1)
                    {
                        Console.Write($"{list[i]}]\n");
                    }
                    else
                    {
                        Console.Write($"{list[i]}, ");
                    }
                }
            }
        }

        protected void printTreeNode(TreeNode root)
        {
            if (root == null)
            {
                Console.WriteLine("Корень дерева отсутствует!");
                return;
            }
            List<string> resultSTR = new List<string>();
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
                    Console.WriteLine($"Значение узла= {treeNode.val} | Уровень = {currentDepth}");
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
        }
        protected void printTwoDimensionalArray(int[][] nums, string header)
        {
            if (nums.LongLength == 0)
            {
                Console.WriteLine("Пустой двумерный массив");
            }
            else
            {
                Console.WriteLine(header);
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i].Length > 0)
                    {
                        for (int j = 0; j < nums[i].Length; j++)
                        {
                            Console.Write(nums[i][j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("[]");
                    }
                }
            }
        }

        protected void printTwoDimensionalArray(string[][] strings, string header)
        {
            if (strings.LongLength == 0)
            {
                Console.WriteLine("Пустой двумерный массив");
            }
            else
            {
                Console.WriteLine(header);
                for (int i = 0; i < strings.Length; i++)
                {
                    if (strings[i].Length > 0)
                    {
                        for (int j = 0; j < strings[i].Length; j++)
                        {
                            Console.Write(strings[i][j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("[]");
                    }
                }
            }
        }

        protected void printTwoDimensionalArray(char[][] nums, string header = "Двумерная матрица символов")
        {
            if (nums.LongLength == 0)
            {
                Console.WriteLine("Пустой двумерный массив");
            }
            else
            {
                Console.WriteLine(header);
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums[i].Length; j++)
                    {
                        Console.Write($"\'{nums[i][j]}\'" + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        protected void printTwoDimensionalListInt(IList<IList<int>> nums, string header)
        {
            int totalItems = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = 0; j < nums[i].Count; j++)
                {
                    totalItems++;
                }
            }
            if (totalItems == 0)
            {
                Console.WriteLine("Пустой двумерный список целых чисел");
            }
            else
            {
                Console.WriteLine(header);
                for (int i = 0; i < nums.Count; i++)
                {
                    for (int j = 0; j < nums[i].Count; j++)
                    {
                        Console.Write(nums[i][j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        protected void printLinkedListWithRandomPointerNode(NodeWithRandomPointer head, string header = "Исходный связанный список со случайным указателем на узел в каждом узле")
        {
            if (head == null)
            {
                Console.WriteLine("Передан пустой связанный список");
                return;
            }
            int numberNode = 0;
            while (head != null)
            {
                Console.WriteLine($"Текущий номер узла = {numberNode} | Значение узла = {head.val} | Значение узла, на который указывает случайный указатель текущего узла = {(head.random == null ? "Отсутсвует" : head.random.val.ToString())}");
                head = head.next;
                numberNode++;
            }
        }
        protected void printTreeNodeWithPointerOnRightNode(TreeNodeWithPointerOnRightNode root, string header = "Исходное двоичное дерево с указателем на правый узел на одном уровне")
        {
            if (root == null)
            {
                Console.WriteLine($"{header}: передан пустой связанный список");
                return;
            }
            Console.WriteLine(header);
            int currentLevel = 0;
            List<TreeNodeWithPointerOnRightNode> nodesOfNextLevel = new List<TreeNodeWithPointerOnRightNode>();
            Queue<TreeNodeWithPointerOnRightNode> queue = new Queue<TreeNodeWithPointerOnRightNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNodeWithPointerOnRightNode currentNode = queue.Dequeue();
                Console.WriteLine($"Текущий уровень в дереве = {currentLevel} | Значение узла = {currentNode.val} | Значение правого узла на текущем уровне = {(currentNode.next == null ? "Отсутствует" : currentNode.next.val.ToString())}");
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
                    for (int i = 0; i < nodesOfNextLevel.Count - 1; i++)
                    {
                        nodesOfNextLevel[i].next = nodesOfNextLevel[i + 1];
                    }

                    for (int i = 0; i < nodesOfNextLevel.Count; i++)
                    {
                        queue.Enqueue(nodesOfNextLevel[i]);
                    }
                    nodesOfNextLevel.Clear();
                    currentLevel++;
                }
            }
        }
        protected void printArrayKeyValuePair(KeyValuePair<string, int?>[] arr, string header = "Массив пар ключ-значение, где ключ - строка, а значение - целое число или null")
        {
            Console.Write($"{header}: ");
            if (arr.Length == 0)
            {
                Console.Write("пустой двумерный массив\n");
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[({arr[i].Key},{arr[i].Value}), ");
                    }
                    else if (i == arr.Length - 1)
                    {
                        Console.Write($"({arr[i].Key},{arr[i].Value})]\n");
                    }
                    else
                    {
                        Console.Write($"({arr[i].Key},{arr[i].Value}), ");
                    }
                }
            }
        }

        // вывод бинарного дерева через списки
        protected void printBinaryTreeUsingList(TreeNode root, string header = "Бинарное дерево")
        {
            IList<IList<string>> res = printTree(root);
            printIListIListString(res, false, header);
        }


        private IList<IList<string>> printTree(TreeNode root)
        {
            int height = findHeightOfTreeNode(root);
            int countRows = height + 1;
            int countColumns = (int)Math.Pow(2, height + 1) - 1;
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

        protected void printN_aryTree(Node node, string header = "Исходное N-арное дерево", bool isFirstCall = true, int depth = 0, string path = "0")
        {
            if (node == null)
            {
                Console.WriteLine("Отсутствует корень N-арного дерева");
            }
            if (isFirstCall)
            {
                Console.WriteLine(header);
            }

            Console.WriteLine($"{new string(' ', depth * 2)}[{path}] {node.val}");

            if (node.children != null)
            {
                for (int i = 0; i < node.children.Count; i++)
                {
                    printN_aryTree(node.children[i], header, false, depth + 1, path + "." + i);
                }
            }
        }

        protected void printTreeNodeWithTwoDirectionalConnection(TwoDirectionalNodeWithChildrens root, string header = "Исходный двунаправленный связанный список")
        {
            List<List<int>> values = new List<List<int>>();
            if (root == null)
            {
                Console.WriteLine("Двунаправленный связанный список отсутствует");
                return;
            }
            Console.WriteLine($"{header}");
            Queue<Tuple<TwoDirectionalNodeWithChildrens, int>> queue = new Queue<Tuple<TwoDirectionalNodeWithChildrens, int>>();
            Stack<Tuple<TwoDirectionalNodeWithChildrens, int>> stack = new Stack<Tuple<TwoDirectionalNodeWithChildrens, int>>();
            int maxLevel = 0;
            stack.Push(new Tuple<TwoDirectionalNodeWithChildrens, int>(root, 0));
            while (stack.Count > 0)
            {
                Tuple<TwoDirectionalNodeWithChildrens, int> current = stack.Pop();
                queue.Enqueue(current);
                if (current.Item2 > maxLevel)
                {
                    maxLevel = current.Item2;
                }
                if (current.Item1.next != null)
                {
                    Tuple<TwoDirectionalNodeWithChildrens, int> next = new Tuple<TwoDirectionalNodeWithChildrens, int>(current.Item1.next, current.Item2);
                    stack.Push(next);
                }
                if (current.Item1.child != null)
                {
                    Tuple<TwoDirectionalNodeWithChildrens, int> child = new Tuple<TwoDirectionalNodeWithChildrens, int>(current.Item1.child, current.Item2+1);
                    stack.Push(child);
                }
            }
            for (int i = 0; i <= maxLevel; i++)
            {
                values.Add(new List<int>());
            }
            while (queue.Count > 0)
            {
                Tuple<TwoDirectionalNodeWithChildrens, int> current = queue.Dequeue();
                values[current.Item2].Add(current.Item1.val);
            }
            for (int i = 0; i < values.Count; i++)
            {
                for (int j = 0; j < values[i].Count; j++)
                {
                    Console.Write($"{values[i][j]}---");
                }
                Console.Write($"NULL\n");
                if (i != values.Count - 1)
                {
                    Console.WriteLine("|");
                }
            }
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
