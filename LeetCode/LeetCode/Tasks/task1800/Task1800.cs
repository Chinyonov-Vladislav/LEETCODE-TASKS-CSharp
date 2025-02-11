using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1800
{
    /*
     1800. Максимальная cумма возрастающего подмассива
    Учитывая массив положительных целых чисел nums, верните максимально возможную сумму возрастающего подмассива в nums.
    Подмассив определяется как непрерывная последовательность чисел в массиве.
    Подмассив [numsl, numsl+1, ..., numsr-1, numsr] является возрастающим, если для всех i где l <= i < r, nums[i]  < nums[i+1]. 
    Обратите внимание, что подмассив размера 1 является возрастающим.
    https://leetcode.com/problems/maximum-ascending-subarray-sum/description/
     */
    public class Task1800 : InfoBasicTask
    {
        public Task1800(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 10, 20, 30, 5, 10, 50 };
            printArray(array, "Исходный массив: ");
            if (isValid(array))
            {
                int max = maxAscendingSum(array);
                Console.WriteLine($"Максимальная сумма непрерывно возрастающего подмассива = {max}");
            }
            else
            {
                Console.WriteLine("Исходный массив не валиден!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 1 || nums[i] > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxAscendingSum(int[] nums)
        {
            int max = int.MinValue;
            int currentMax = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                currentMax += nums[i - 1];
                if (nums[i - 1] >= nums[i])
                {
                    if (currentMax > max)
                    {
                        max = currentMax;
                    }
                    currentMax = 0;
                }
                if (i == nums.Length - 1)
                {
                    currentMax += nums[i];
                    if (currentMax > max)
                    {
                        max = currentMax;
                    }
                }
            }
            return max;
        }
    }
}
