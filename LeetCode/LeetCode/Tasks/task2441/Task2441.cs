using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2441
{
    /*
     2441. Наибольшее положительное целое число, которое существует вместе со своим отрицательным значением
    Учитывая целочисленный массив, nums который не содержит никаких нулей, найдите наибольшее положительное целое число, k такое-k, которое также существует в массиве.
    Верните положительное целое числоk. Если такого целого числа нет, верните -1.
    Ограничения:
        1 <= nums.length <= 1000
        -1000 <= nums[i] <= 1000
        nums[i] != 0
    https://leetcode.com/problems/largest-positive-integer-that-exists-with-its-negative/description/
     */
    public class Task2441 : InfoBasicTask
    {
        public Task2441(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { -1, 10, 6, 7, -7, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = findMaxK(nums);
                Console.WriteLine(res == -1 ? "В исходном массиве нет значения, которое было бы в положительном и отрицательном варианте" : $"Наиболее положительное значение, которое есть в массиве и в отрицательном варианте = {res}");
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
            if (nums.Length < 1 || nums.Length > 1000)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < -1000 || num > 1000)
                {
                    return false;
                }
                if (num == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private int findMaxK(int[] nums)
        {
            int max = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums.Contains(nums[i]*-1) && nums[i]>max)
                {
                    max = nums[i];
                }
            }
            return max;
        }
    }
}
