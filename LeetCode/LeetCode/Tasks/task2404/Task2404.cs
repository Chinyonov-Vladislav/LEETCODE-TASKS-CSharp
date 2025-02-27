using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2404
{
    /*
     2404. Наиболее частый четный элемент
    Учитывая целочисленный массив nums, верните наиболее частый четный элемент.
    Если есть несколько вариантов, верните наименьший. Если такого элемента нет, верните -1.
    Ограничения:
        1 <= nums.length <= 2000
        0 <= nums[i] <= 10^5
    https://leetcode.com/problems/most-frequent-even-element/description/
     */
    public class Task2404 : InfoBasicTask
    {
        public Task2404(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 4, 4, 4, 9, 2, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int result = mostFrequentEven(nums);
                Console.WriteLine(result == -1 ? "Исходный массив не содержит четных значений!" : $"Наиболее часто встречающееся четное число = {result}");
            }
            else
            {
                Console.WriteLine("Не валидные исходные данные!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 2000)
            {
                return false;
            }
            int upperLimit = (int)Math.Pow(10, 5);
            foreach (var item in nums)
            {
                if (item < 0 || item > upperLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int mostFrequentEven(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    if (dict.ContainsKey(num))
                    {
                        dict[num]++;
                    }
                    else
                    {
                        dict.Add(num, 1);
                    }
                }
            }
            if (dict.Count == 0)
            {
                return -1;
            }
            HashSet<int> set = new HashSet<int>();
            int maxFreq =  dict.OrderByDescending(x => x.Value).First().Value;
            foreach (var pair in dict)
            {
                if (pair.Value == maxFreq)
                {
                    set.Add(pair.Key);
                }
            }
            return set.Min();
        }
    }
}
