using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2644
{
    /*
     2644. Найдите максимальный балл делимости
    Вам даны два целочисленных массива nums и divisors.
    Показатель делимости divisors[i] — это количество индексов j таких, что nums[j] делится на divisors[i].
    Верните целое число divisors[i] с максимальным показателем делимости. Если несколько целых чисел имеют максимальный показатель, верните наименьшее из них.
    Ограничения:
        1 <= nums.length, divisors.length <= 1000
        1 <= nums[i], divisors[i] <= 10^9
    https://leetcode.com/problems/find-the-maximum-divisibility-score/description/
     */
    public class Task2644 : InfoBasicTask
    {
        public Task2644(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 9, 15, 50 };
            int[] divisors = new int[] { 5, 3, 7, 2 };
            printArray(nums, "Массив чисел: ");
            printArray(divisors, "Массив делителей: ");
            if (isValid(nums, divisors))
            {
                int res = maxDivScore(nums, divisors);
                Console.WriteLine($"Минимальный делитель с максимальным показателем делимости = {res}");
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
        private bool isValid(int[] nums, int[] divisors)
        {
            if (nums.Length < 1 || nums.Length > 1000 || divisors.Length < 1 || divisors.Length > 1000)
            {
                return false;
            }
            int highLimit = (int)Math.Pow(10, 9);
            foreach (int num in nums)
            {
                if (num < 1 || num > highLimit)
                {
                    return false;
                }
            }
            foreach (int divisor in divisors)
            {
                if (divisor < 1 || divisor > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxDivScore(int[] nums, int[] divisors)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var divisor in divisors)
            {
                if (!dict.ContainsKey(divisor))
                {
                    dict.Add(divisor, 0);
                }
                else
                {
                    continue;
                }
                foreach (var num in nums)
                {
                    if (num % divisor == 0)
                    {
                        dict[divisor]++;
                    }
                }
            }
            int max = dict.OrderByDescending(x => x.Value).First().Value;
            List<int> divisorsWithMax = new List<int>();
            foreach (var pair in dict)
            {
                if (pair.Value == max)
                {
                    divisorsWithMax.Add(pair.Key);
                }
            }
            return divisorsWithMax.Min();
        }
    }
}
