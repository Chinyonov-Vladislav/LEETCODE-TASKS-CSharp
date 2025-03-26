using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task155
{
    /*
     155. Минимальный стек
    Создайте стек, который поддерживает операции push, pop, top и поиск минимального элемента за постоянное время.
    Реализовать класс MinStack:
        MinStack() инициализирует объект стека.
        void push(int val) помещает элемент val в стек.
        void pop() удаляет элемент, находящийся в верхней части стека.
        int top() возвращает верхний элемент стека.
        int getMin() извлекает минимальный элемент в стеке.
    Вы должны реализовать решение с O(1) временной сложностью для каждой функции.
    Ограничения:
        -2^31 <= val <= 2^31 - 1
        Методы pop, top и getMin операции всегда будут вызываться для непустых стеков.
        Не более 3 * 10^4 звонков будет сделано на push, pop, top и getMin.
    https://leetcode.com/problems/min-stack/description/
     */
    public class Task155 : InfoBasicTask
    {
        public Task155(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] operations = new string[] { "MinStack", "push", "push", "push", "getMin", "pop", "top", "getMin" };
            int[][] data = new int[][] {
                new int[] { },
                new int[] { -2},
                new int[] { 0 },
                new int[] { -3 },
                new int[] { },
                new int[] { },
                new int[] { },
                new int[] { }
            };
            printArray(operations, "Массив операций: ");
            printTwoDimensionalArray(data, "Массив данных для операций");
            if (isValid(operations, data))
            {
                MinStack minStack = new MinStack();
                Console.WriteLine("Объект minStack был создан");
                for (int i = 1; i < operations.Length; i++)
                {
                    switch (operations[i])
                    {
                        case "push":
                            minStack.Push(data[i][0]);
                            Console.WriteLine($"Значение {data[i][0]} было добавлено в стек");
                            break;
                        case "getMin":
                            int min = minStack.GetMin();
                            Console.WriteLine($"Текущее минимальное значение в стеке = {min}");
                            break;
                        case "pop":
                            minStack.Pop();
                            Console.WriteLine($"Значение на вершине стека было удалено");
                            break;
                        case "top":
                            int top = minStack.Top();
                            Console.WriteLine($"Текущее значение на вершине стека = {top}");
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
        private bool isValid(string[] operations, int[][] data)
        {
            if (operations.Length != data.Length)
            {
                return false;
            }
            if (operations.Length == 0)
            {
                return false;
            }
            if (operations[0] != "MinStack")
            {
                return false;
            }
            int lowLimit = 1;
            int highLimit = 3 * (int)Math.Pow(10, 4);
            int countOperationNotMinStack = 0;
            
            List<string> acceptedOperations = new List<string>() { "MinStack", "push", "getMin", "pop", "top"};
            int countData = 0;
            for (int i=0;i<operations.Length;i++)
            {
                if (!acceptedOperations.Contains(operations[i]))
                {
                    return false;
                }
                if (i != 0 && operations[i] == "MinStack")
                {
                    return false;
                }
                if (operations[i] != "MinStack")
                {
                    countOperationNotMinStack++;
                }
                if (operations[i] == "push")
                {
                    if (data[i].Length != 1)
                    {
                        return false;
                    }
                    countData++;
                }
                else
                {
                    if (data[i].Length != 0)
                    {
                        return false;
                    }
                }
                if ((operations[i] == "pop" || operations[i] == "top" || operations[i] == "getMin") && countData <= 0)
                {
                    return false;
                }
                if (operations[i] == "pop")
                {
                    countData--;
                }
            }
            if (countOperationNotMinStack < lowLimit || countOperationNotMinStack > highLimit)
            {
                return false;
            }
            return true;
        }
    }
}
