using System;
using System.Collections.Generic;

namespace LeetCode.Basic
{
    public abstract class InfoBasicTask
    {
        private int number;
        private string name;
        private string description;
        private Difficult difficult;
        public InfoBasicTask(int number,string name, string description, Difficult difficult)
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
        public string getName() {
            return name;
        }
        public string getDescription() {
            return description;
        }
        public abstract void execute();
        public abstract void testing();

        protected void printInfoNotValidData()
        {
            Console.WriteLine("Исходные данные не валидны!");
        }
        protected void printValuesFromListNode(ListNode listNode, int numberCurrentNode=0)
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
        protected void printArray(string[] chars, string headerStr = "Исходный массив строк: ")
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
                    else if (list[i].Count == 1)
                    {
                        Console.Write($"[{list[i][0]}], ");
                    }
                    else
                    {
                        Console.Write("[]");
                    }
                    if (i == list.Count-1)
                    {
                        Console.Write($"]\n");
                    }
                }
            }
        }

        protected void printIListIListString(IList<IList<string>> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Пустой список");
            }
            else if (list.Count == 1)
            {
                Console.WriteLine($"Результат: [");
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
                        Console.Write($"Результат: [");
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
                    visitedNodes.Add(treeNode);
                }
                Console.WriteLine($"Значение узла= {treeNode.val} | Уровень = {currentDepth}");
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
                    for (int j = 0; j < nums[i].Length; j++)
                    {
                        Console.Write(nums[i][j] + "\t");
                    }
                    Console.WriteLine();
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
            int currentNumberNode = 0;
            Queue<TreeNodeWithPointerOnRightNode> queue = new Queue<TreeNodeWithPointerOnRightNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNodeWithPointerOnRightNode currentNode = queue.Dequeue();
                Console.WriteLine($"Текущий уровень = {currentLevel} | Значение узла = {currentNode.val} | Значение правого узла на текущем уровне = {(currentNode.next == null ? "Отсутствует" : currentNode.next.val.ToString())}");
                currentNumberNode++;
                if (currentNumberNode == Math.Pow(2, currentLevel))
                {
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
        }
    }
}
