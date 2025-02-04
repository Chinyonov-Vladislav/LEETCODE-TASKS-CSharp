using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1331
{
    /*
     1331. Ранговое преобразование массива
    Учитывая массив целых чисел arr, замените каждый элемент его рангом.
    Ранг показывает, насколько велик элемент. Ранг определяется по следующим правилам:
        Ранг - это целое число, начинающееся с 1.
        Чем больше элемент, тем выше ранг. Если два элемента равны, их ранг должен быть одинаковым.
        Ранг должен быть как можно меньше.
    https://leetcode.com/problems/rank-transform-of-an-array/description/
     */
    public class Task1331 : InfoBasicTask
    {
        public Task1331(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 37, 12, 28, 9, 100, 56, 80, 5, 12 };
            printArray(array, "Исходный массив: ");
            int[] result = arrayRankTransform(array);
            printArray(result, "Массив рангов: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] arrayRankTransform(int[] arr)
        {
            List<int> copyArrRanks = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!copyArrRanks.Contains(arr[i]))
                {
                    copyArrRanks.Add(arr[i]);
                }
            }
            copyArrRanks.Sort();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = copyArrRanks.IndexOf(arr[i])+1;
            }
            return arr;
        }
        // скопировано с leetcode
        private int[] bestSolution(int[] arr)
        {
            if (arr.Length == 0)
            {
                return new int[] { };
            }
            var index = new int[arr.Length][];
            for (var i = 0; i < arr.Length; i++)
            {
                index[i] = new int[] { arr[i], i };
            }
            Array.Sort(index, (a, b) => a[0] - b[0]);
            var result = new int[arr.Length];
            result[index[0][1]] = 1;
            for (var i = 1; i < arr.Length; i++)
            {
                if (index[i][0] == index[i - 1][0]) result[index[i][1]] = result[index[i - 1][1]];
                else result[index[i][1]] = result[index[i - 1][1]] + 1;
            }
            return result;
        }
    }
}
