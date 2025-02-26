using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2239
{
    /*
     2239. Найдите число, ближайшее к нулю
    Учитывая целочисленный массив nums размером n, верните число со значением,ближайшим к 0 в nums. Если ответов несколько, верните число с наибольшим значением.
    https://leetcode.com/problems/find-closest-number-to-zero/description/
     */
    public class Task2239 : InfoBasicTask
    {
        public Task2239(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { -4, -2, 1, 4, 8 };
            printArray(array, "Исходный массив: ");
            if (isValid(array))
            {
                int result = findClosestNumber(array);
                Console.WriteLine($"Самое большое и близкое к нулю число из массива = {result}");
            }
            else
            {
                Console.WriteLine("Исходный массив не валиден, так как он пуст");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            return nums.Length != 0;
        }
        private int findClosestNumber(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                int distance = Math.Abs(nums[i]);
                if (dict.ContainsKey(distance))
                {
                    dict[distance].Add(nums[i]);
                }
                else
                {
                    dict.Add(distance, new List<int>() { nums[i] });
                }
            }
            return dict.OrderBy(x => x.Key).First().Value.Max();
        }
        // скопировано с leetcode
        private int bestSolution(int[] nums)
        {
            var target = int.MinValue;
            var diff = int.MaxValue;
            for (var i = 0; i < nums.Length; i++)
            {
                var x = Math.Abs(nums[i]);
                if (x <= diff)
                {
                    diff = x;
                    if (target != x)
                        target = nums[i];
                }
            }
            return target;
        }
    }
}
