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

        protected void printValuesFromListNode(ListNode listNode, int numberCurrentNode=0)
        {
            if (listNode == null && numberCurrentNode == 0)
            {
                Console.WriteLine("Корневой узел отсутствует");
                return;
            }
            Console.WriteLine($"Номер узла = {numberCurrentNode} | Значение = {listNode.val}");
            if (listNode.next != null)
            {
                numberCurrentNode += 1;
                printValuesFromListNode(listNode.next, numberCurrentNode);
            }
        }
        protected void printArray(char[] chars, string headerStr)
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
        protected void printArray(int[] values, string headerStr = "Исходный массив: ")
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
        protected void printArray(string[] chars, string headerStr)
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
        protected void printArray(int[][] nums, string headerStr)
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
        protected void printIListInt(IList<int> list, string header)
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
        protected void printIListIListInt(IList<IList<int>> list)
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
                    else if (i == list.Count - 1)
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
                    else if (i == list.Count - 1)
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
                Console.WriteLine("Корень бинарного дерева отсутствует!");
                return;
            }
            List<string> resultSTR = new List<string>();
            int currentDepth = 0;
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            visitedNodes.Add(root);
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                Console.WriteLine($"Значение узла= {treeNode.val} | Уровень = {currentDepth}");
                if (visitedNodes.Contains(treeNode))
                {
                    currentDepth--;
                }
                else
                {
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
                    for (int j = 0; j < nums[i].Length; j++)
                    {
                        Console.Write(nums[i][j] + "\t");
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
    }
}
