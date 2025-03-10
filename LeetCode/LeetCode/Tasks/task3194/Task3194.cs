using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3194
{
    /*
     3194. Минимальное среднее значение наименьшего и наибольшего элементов
    У вас есть массив чисел с плавающей запятой averages, который изначально пуст. Вам дан массив nums целых чисел, n где n — чётное число.
    Вы повторяете следующую процедуру n / 2 раз:
        Удалите самый маленький элемент minElement и самый большой элемент maxElement из nums.
        Добавить (minElement + maxElement) / 2 к averages.
    Верните минимальный элемент в averages.
    Ограничения:
        2 <= n == nums.length <= 50
        n является четным.
        1 <= nums[i] <= 50
    https://leetcode.com/problems/minimum-average-of-smallest-and-largest-elements/description/
     */
    public class Task3194 : InfoBasicTask
    {
        public Task3194(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 7, 8, 3, 4, 15, 13, 4, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                double min = minimumAverage(nums);
                Console.WriteLine($"Минимальное среднее значение наименьшего и наибольшего элемента массива = {min}");
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
        private bool isValid(int[] nums)
        {
            if (nums.Length < 2 || nums.Length > 50)
            {
                return false;
            }
            if (nums.Length % 2 != 0)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            return true;
        }
        private double minimumAverage(int[] nums)
        {
            Array.Sort(nums);
            double min = (nums[0] + nums[nums.Length - 1]) / 2.0;
            int left = 1;
            int right = nums.Length - 2;
            while (left < right) { 
                double currentMin = (nums[left] + nums[right]) / 2.0;
                if (currentMin < min)
                {
                    min = currentMin;
                }
                left++;
                right--;
            }
            return min;
        }
    }
}
