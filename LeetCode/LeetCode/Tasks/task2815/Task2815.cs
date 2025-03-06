using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2815
{
    /*
     2815. Максимальная сумма пар в массиве
    Вам дан целочисленный массив nums. Вам нужно найти максимальную сумму пары чисел из nums таких, что наибольшая цифра в обоих числах одинакова.
    Например, число 2373 состоит из трёх разных цифр: 2, 3 и 7, где 7 — самая большая из них.
    Верните максимальную сумму или -1, если такой пары не существует.
    Ограничения:
        2 <= nums.length <= 100
        1 <= nums[i] <= 10^4
    https://leetcode.com/problems/max-pair-sum-in-an-array/description/
     */
    public class Task2815 : InfoBasicTask
    {
        public Task2815(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 31, 25, 72, 79, 74 };
            printArray(nums);
            if (isValid(nums))
            {
                int max = maxSum(nums);
                Console.WriteLine(max == -1 ? "Не существует пары чисел с одинаковой наибольшей цифрой" : $"Сумма пары чисел с одинаковой наибольшей цифрой = {max}");
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
            if (nums.Length < 2 || nums.Length > 100)
            {
                return false;
            }
            int highLimit = (int)Math.Pow(10, 4);
            foreach (int num in nums) {
                if (num < 1 || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxSum(int[] nums)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i=0;i<nums.Length;i++) {
                int currentNumMaxDigit = -1;
                int currentNum = nums[i];
                if (currentNum == 0)
                {
                    currentNumMaxDigit = 0;
                }
                else
                {
                    while (currentNum != 0)
                    {
                        int currentDigit = currentNum % 10;
                        if (currentDigit > currentNumMaxDigit)
                        {
                            currentNumMaxDigit = currentDigit;
                        }
                        currentNum /= 10;
                    }
                }
                if (dict.ContainsKey(currentNumMaxDigit))
                {
                    dict[currentNumMaxDigit].Add(nums[i]);
                }
                else
                {
                    dict.Add(currentNumMaxDigit, new List<int>() { nums[i] });
                }
            }
            Dictionary<int, List<int>> filteredDict = dict.Where(x => x.Value.Count >= 2).ToDictionary(i => i.Key, i => i.Value);
            if (filteredDict.Count == 0)
            {
                return -1;
            }
            List<List<int>> values = new List<List<int>>();
            foreach (var pair in filteredDict)
            {
                values.Add(pair.Value);
            }
            values[0].Sort();
            values[0].Reverse();
            int max = values[0][0] + values[0][1];
            for (int i = 1; i < values.Count; i++)
            {
                values[i].Sort();
                values[i].Reverse();
                int localMax = values[i][0] + values[i][1];
                if (localMax > max)
                {
                    max = localMax;
                }
            }
            return max;
        }
    }
}
