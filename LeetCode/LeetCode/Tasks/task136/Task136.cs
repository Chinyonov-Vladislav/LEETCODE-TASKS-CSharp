using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;
using Xunit;
using LeetCode.Basic;

namespace LeetCode.Tasks.Task136
{
    public class Task136 : InfoBasicTask
    {
        public Task136(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = { 1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6 };
            if (isCorrectArray(nums))
            {
                Console.Write("Исходный массив: ");
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{nums[i]}, ");
                    }
                    else if (i == nums.Length - 1)
                    {
                        Console.Write($"{nums[i]}]\n");
                    }
                    else
                    {
                        Console.Write($"{nums[i]}, ");
                    }
                }
                Console.WriteLine($"Ответ = {singleNumber(nums)}");
            }
            else
            {
                Console.WriteLine("Задан некорректный исходный массив");
            }
            
        }

        public override void testing()
        {
            int[] nums = { 1,1,2,2,3,3,3,3,4,5,5,5,6,6,6 };
            int expected = 4;
            int actual = singleNumber(nums);
            try
            {
                Assert.Equal(expected, actual);
                Console.WriteLine("Тест пройден");
            }
            catch (TrueException ex)
            {
                Console.WriteLine("Тест не пройден");
                Console.WriteLine(ex.Message);
            }
        }
        private int singleNumber(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            return dict.First(valueDict => valueDict.Value == 1).Key;
        }
        private bool isCorrectArray(int[] nums)
        {
            int countElementsByOne = 0;
            int countElementsByTwo = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            foreach (var pair in dict)
            {
                if (pair.Value == 2)
                {
                    countElementsByTwo++;
                }
                else if (pair.Value == 1)
                {
                    countElementsByOne++;
                    if (countElementsByOne != 1)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
            
        }

        private int bestSolution(int[] nums) // взято из решений
        {
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }

            return result;
        }
    }
}
