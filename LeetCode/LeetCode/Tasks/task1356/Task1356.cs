using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1356
{
    /*
     1356. Отсортируйте целые числа по количеству единиц в них
    Вам дан целочисленный массив arr. Отсортируйте целые числа в массиве в порядке возрастания по количеству 1 в их двоичном представлении, а если два или более целых числа имеют одинаковое количество 1 в двоичном представлении, отсортируйте их в порядке возрастания.
    Верните массив после его сортировки.
    https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits/description/
     */
    public class Task1356 : InfoBasicTask
    {
        public Task1356(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            printArray(numbers, "Исходный массив: ");
            int[] result = sortByBits(numbers);
            printArray(result, "Исходный массив, отсортированный по количеству установленных битов в значениях: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] sortByBits(int[] arr)
        {
            int[] result = new int[arr.Length];
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];
                int countOneBits = 0;
                while (currentNumber!=0)
                {
                    int currentBit = currentNumber & 1;
                    if (currentBit == 1)
                    {
                        countOneBits++;
                    }
                    currentNumber >>= 1;
                }
                if (dict.ContainsKey(countOneBits))
                {
                    dict[countOneBits].Add(arr[i]);
                }
                else
                {
                    dict.Add(countOneBits, new List<int>() { arr[i] });
                }
            }
            int minCountOneBit = dict.Keys.Min();
            int maxCountOneBit = dict.Keys.Max();
            int index = 0;
            for (int i = minCountOneBit; i <= maxCountOneBit; i++)
            {
                if (dict.ContainsKey(i))
                {
                    List<int> values = dict[i];
                    values.Sort();
                    for (int j = 0; j < values.Count; j++)
                    {
                        result[index] = values[j];
                        index++;
                    }
                }
            }
            return result;
        }
    }
}
