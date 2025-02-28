using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2465
{
    /*
     2465. Количество различных средних значений
    Вам дан нумерованный с 0 целочисленный массив nums чётной длины.
    Пока nums не пуст, вы должны повторять:
        Найдите минимальное число в nums и удалите его.
        Найдите максимальное число в nums и удалите его.
        Вычислите среднее значение двух удаленных чисел.
        Среднее из двух чисел a и b равно (a + b) / 2.
    Например, среднее значение для 2 и 3 равно (2 + 3) / 2 = 2.5.
    Верните количестворазличныхсредних значений, рассчитанных с помощью описанного выше процесса.
    Обратите внимание, что при равенстве минимального или максимального значений любое из них может быть удалено.
    https://leetcode.com/problems/number-of-distinct-averages/description/
     */
    public class Task2465 : InfoBasicTask
    {
        public Task2465(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 4, 1, 4, 0, 3, 5 };
            printArray(nums);
            if (isValid(nums))
            {
                int count = distinctAverages(nums);
                Console.WriteLine($"Количество уникальных средних значений максимального и минимального значений = {count}");
            }
            else
            {
                Console.WriteLine("Невалидные исходные данные!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 2 || nums.Length > 100)
            {
                return false;
            }
            if (nums.Length % 2 != 0)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 0 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int distinctAverages(int[] nums)
        {
            Array.Sort(nums);
            int left = 0;
            int right = nums.Length - 1;
            HashSet<double> uniqueAverageValues = new HashSet<double>();
            while (left < right) {
                double average = (nums[left] + nums[right]) / 2.0;
                uniqueAverageValues.Add(average);
                left++;
                right--;
            }
            return uniqueAverageValues.Count;
        }
    }
}
