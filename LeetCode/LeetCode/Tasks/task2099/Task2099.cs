using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2099
{
    /*
     2099. Найдите подпоследовательность длины K с наибольшей суммой
    Вам дан целочисленный массив nums и целое число k. Вы хотите найти последовательность nums длины k, которая имеет наибольшую сумму.
    Возвращает любую такую подпоследовательность в виде целочисленного массива длины k.
    Подпоследовательность — это массив, который можно получить из другого массива, удалив некоторые или все элементы без изменения порядка оставшихся элементов.
    https://leetcode.com/problems/find-subsequence-of-length-k-with-the-largest-sum/description/
     */
    public class Task2099 : InfoBasicTask
    {
        public Task2099(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 4, 3, 3 };
            int k = 2;
            printArray(nums, "Исходный массив: ");
            Console.WriteLine($"Длина подпоследовательности = {k}");
            int[] result = maxSubsequence(nums, k);
            printArray(result, "Подпоследовательность с наибольшей суммой: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] maxSubsequence(int[] nums, int k)
        {
            // Создаем список пар (значение, индекс)
            var indexedNums = nums.Select((num, index) => new { Num = num, Index = index }).ToList();

            // Сортируем по убыванию значений
            var sortedByValue = indexedNums.OrderByDescending(x => x.Num).Take(k).ToList();

            // Сортируем по индексам, чтобы сохранить порядок
            var sortedByIndex = sortedByValue.OrderBy(x => x.Index).Select(x => x.Num).ToArray();

            return sortedByIndex;
        }
    }
}
