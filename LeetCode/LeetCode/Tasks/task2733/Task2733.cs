using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2733
{
    /*
     2733. Ни минимальный, ни максимальный
    Дан целочисленный массив nums, содержащий различные положительные целые числа. 
    Найдите и верните любое число из массива, которое не является минимальным или максимальным значением в массиве, или -1 если такого числа нет.
    Возвращает выбранное целое число.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 100
        Все значения в nums различны
    https://leetcode.com/problems/neither-minimum-nor-maximum/description/
     */
    public class Task2733 : InfoBasicTask
    {
        public Task2733(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 2, 1, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = findNonMinOrMax(nums);
                Console.WriteLine(res == -1 ? "В массиве отсутствует значение, которое бы не являлось мининимальным и максимальным" : $"Значение в массиве, которое не является мининимальным и максимальным = {res}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            HashSet<int> set = new HashSet<int>(nums);
            if (set.Count != nums.Length)
            {
                return false;
            }
            return true;
        }
        private int findNonMinOrMax(int[] nums)
        {
            if (nums.Length <= 2)
            {
                return -1;
            }
            Array.Sort(nums);
            return nums[1];
        }
    }
}
