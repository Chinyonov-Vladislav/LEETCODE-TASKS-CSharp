using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2903
{
    /*
     2903. Найдите индексы с помощью разницы индексов и значений
    Вам дан нумерованный от 0 целочисленный массив nums длиной n, целое число indexDifference и целое число valueDifference.
    Ваша задача — найти два индекса i и j в диапазоне [0, n - 1], которые удовлетворяют следующим условиям:
        abs(i - j) >= indexDifference, и
        abs(nums[i] - nums[j]) >= valueDifference
    Верните целый массив answer, где answer = [i, j] если есть два таких индекса, то answer = [-1, -1] иначе. Если есть несколько вариантов для двух индексов, верните любой из них.
    Примечание: i и j могут быть равны.
    Ограничения:
        1 <= n == nums.length <= 100
        0 <= nums[i] <= 50
        0 <= indexDifference <= 100
        0 <= valueDifference <= 50
    https://leetcode.com/problems/find-indices-with-index-and-value-difference-i/description/
     */
    public class Task2903 : InfoBasicTask
    {
        public Task2903(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 5, 1, 4, 1 };
            int indexDifference = 2;
            int valueDifference = 4;
            printArray(nums);
            Console.WriteLine($"Разница в индексах = {indexDifference}\nРазница в значениях = {valueDifference}");
            if (isValid(nums, indexDifference, valueDifference))
            {
                int[] result = findIndices(nums, indexDifference, valueDifference);
                Console.WriteLine(result[0] == -1 && result[1] == -1 ? "Нет индексов, подходящих под заданные условия" : $"Индексы, подходящие под заданные условия: {result[0]} и {result[1]}");
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
        private bool isValid(int[] nums, int indexDifference, int valueDifference)
        {
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 0 || num > 50)
                {
                    return false;
                }
            }
            if (indexDifference < 0 || indexDifference > 100 || valueDifference < 0 || valueDifference > 50)
            {
                return false;
            }
            return true;
        }
        private int[] findIndices(int[] nums, int indexDifference, int valueDifference)
        {
            int[] result = new int[2] { -1, -1 };
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (Math.Abs(i - j) >= indexDifference && Math.Abs(nums[i] - nums[j]) >= valueDifference)
                    {
                        result[0] = i;
                        result[1] = j;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
