using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1394
{
    /*
     1394. Найти Счастливое целое число в массиве
    Если дан массив целых чисел arr, то счастливое целое число — это целое число, частота появления которого в массиве равна его значению.
    Верните наибольшеесчастливое число в массиве. Если счастливого числа нет, верните -1.
    https://leetcode.com/problems/find-lucky-integer-in-an-array/description/
     */
    public class Task1394 : InfoBasicTask
    {
        public Task1394(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 2, 2, 3, 3, 3 };
            printArray(array, "Исходный массив: ");
            int maxLuckyNumber = findLucky(array);
            Console.WriteLine(maxLuckyNumber == -1 ? "Счастливых чисел нет в массиве" : $"Самое большое счастливое число в массиве = {maxLuckyNumber}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findLucky(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                {
                    dict[arr[i]]++;
                }
                else
                {
                    dict.Add(arr[i], 1);
                }
            }
            List<int> luckyNumbers = new List<int>();
            foreach (var pair in dict)
            {
                if (pair.Key == pair.Value)
                {
                    luckyNumbers.Add(pair.Key);
                }
            }
            if (luckyNumbers.Count == 0)
            {
                return -1;
            }
            else if (luckyNumbers.Count == 1)
            {
                return luckyNumbers[0];
            }
            else
            {
                return luckyNumbers.Max();
            }
        }
    }
}
