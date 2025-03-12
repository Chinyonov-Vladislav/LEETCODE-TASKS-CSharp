using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3452
{
    /*
     3452. Сумма хороших чисел
    Если дан массив целых чисел nums и целое число k, то элемент nums[i] считается хорошим, если он строго больше элементов с индексами i - k и i + k (если эти индексы существуют). 
    Если ни один из этих индексов не существует, nums[i] всё равно считается хорошим.
    Верните сумму всех положительных элементов в массиве.
    Ограничения:
        2 <= nums.length <= 100
        1 <= nums[i] <= 1000
        1 <= k <= floor(nums.length / 2)
    https://leetcode.com/problems/sum-of-good-numbers/description/
     */
    public class Task3452 : InfoBasicTask
    {
        public Task3452(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 3, 2, 1, 5, 4 };
            int k = 2;
            if (isValid(nums,k))
            {
                int res = sumOfGoodNumbers(nums, k);
                Console.WriteLine($"Сумма хороших чисел в массиве = {res}");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums, int k)
        {
            if (nums.Length < 2 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 1000)
                {
                    return false;
                }
            }
            if (k < 1 || k > Math.Floor(nums.Length / 2.0))
            {
                return false;
            }
            return true;
        }
        private int sumOfGoodNumbers(int[] nums, int k)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int firstIndex =i - k;
                int secondIndex = i + k;
                if ((firstIndex < 0 || firstIndex>=nums.Length) && (secondIndex < 0 || secondIndex >= nums.Length)) // не существует оба индекса
                {
                    Console.WriteLine($"Индекс = {i}");
                    sum += nums[i];
                }
                else if (firstIndex >= 0 && firstIndex < nums.Length && (secondIndex < 0 || secondIndex >= nums.Length)) // существует первый, не существует второй
                {
                    if (nums[i] > nums[firstIndex])
                    {
                        Console.WriteLine($"Индекс = {i}");
                        sum += nums[i];
                    }
                }
                else if (secondIndex >= 0 && secondIndex < nums.Length && (firstIndex < 0 || firstIndex >= nums.Length)) // существует второй, не существует первый
                {
                    if (nums[i] > nums[secondIndex])
                    {
                        Console.WriteLine($"Индекс = {i}");
                        sum += nums[i];
                    }
                }
                else if(firstIndex >= 0 && firstIndex < nums.Length && secondIndex >= 0 && secondIndex < nums.Length) // существуют оба
                {
                    if (nums[i] > nums[firstIndex] && nums[i]> nums[secondIndex])
                    {
                        Console.WriteLine($"Индекс = {i}");
                        sum += nums[i];
                    }
                }
            }
            return sum;
        }
    }
}
