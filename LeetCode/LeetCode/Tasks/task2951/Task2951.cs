using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2951
{
    /*
     2951. Найдите вершины
    Вам предоставляется массив с индексом mountain0. Ваша задача - найти все вершины в mountain массиве.
    Возвращает массив, состоящий из индексов вершин в данном массиве в любом порядке.
    Примечания:
        Пик определяется как элемент, который строго больше, чем соседние с ним элементы.
        Первый и последний элементы массива не являются вершиной.
    Ограничения:
        3 <= mountain.length <= 100
        1 <= mountain[i] <= 100
    https://leetcode.com/problems/find-the-peaks/description/
     */
    public class Task2951 : InfoBasicTask
    {
        public Task2951(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] mountaint = new int[] { 1, 4, 3, 8, 5 };
            printArray(mountaint, "Массив высоты гор: ");
            if (isValid(mountaint))
            {
                IList<int> indexs = findPeaks(mountaint);
                printIListInt(indexs, "Индексы вершин: ");
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
        private bool isValid(int[] mountaint)
        {
            if (mountaint.Length < 3 || mountaint.Length > 100)
            {
                return false;
            }
            foreach (int value in mountaint)
            {
                if (value < 1 || value > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private IList<int> findPeaks(int[] mountain)
        {
            IList<int> result = new List<int>();
            for (int i = 1; i < mountain.Length - 1;)
            {
                if (mountain[i] > mountain[i - 1] && mountain[i] > mountain[i + 1])
                {
                    result.Add(i);
                    i += 2;
                }
                else
                {
                    i++;
                }
            }
            return result;
        }
    }
}
