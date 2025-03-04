using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2873
{
    /*
     2873. Максимальное значение упорядоченного триплета I
    Вам будет предоставлен целочисленный массив с 0-индексом nums.
    Верните максимальное значение среди всех троек индексов (i, j, k) таких, что i < j < k. Если все такие тройки имеют отрицательное значение, верните 0.
    Значение тройки индексов (i, j, k) равно (nums[i] - nums[j]) * nums[k].
    Ограничения:
        3 <= nums.length <= 100
        1 <= nums[i] <= 10^6
    https://leetcode.com/problems/maximum-value-of-an-ordered-triplet-i/description/
     */
    public class Task2873 : InfoBasicTask
    {
        public Task2873(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1000000, 1, 1000000 };
            printArray(nums);
            if (isValid(nums))
            {
                long max = maximumTripletValue(nums);
                Console.WriteLine($"Максимальное число триплета = {max}");
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
            if (nums.Length < 3 || nums.Length > 100)
            {
                return false;
            }
            int upperLimit = (int)Math.Pow(10, 6);
            foreach (int num in nums)
            {
                if (num < 1 || num > upperLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private long maximumTripletValue(int[] nums)
        {
            long result = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i+1; j < nums.Length - 1; j++)
                {
                    long difference = nums[i] - nums[j];
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        long val = difference * nums[k];
                        if (val > result)
                        {
                            result = val;
                        }
                    }
                }
            }
            return result;
        }
    }
}
