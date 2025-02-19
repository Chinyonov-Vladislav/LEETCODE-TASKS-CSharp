using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1979
{
    /*
     1979. Найти наибольший общий делитель массива
    Учитывая массив целых чисел nums, верните наибольший общий делитель наименьшего числа и наибольшего числа в nums.
    Наибольший общий делитель двух чисел — это наибольшее положительное целое число, на которое без остатка делятся оба числа.
    https://leetcode.com/problems/find-greatest-common-divisor-of-array/description/
     */
    public class Task1979 : InfoBasicTask
    {
        public Task1979(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 2, 5, 6, 9, 10 };
            printArray(array, "Исходный массив: ");
            if (isValid(array))
            {
                int gcd = findGCD(array);
                Console.WriteLine($"Наибольший общий делитель максимального и минимального элемента в исходном массиве = {gcd}");
            }
            else
            {
                Console.WriteLine("Исходный массив должен содержать как минимум 2 элемента!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            return nums.Length >= 2;
        }
        private int findGCD(int[] nums)
        {
            int minimum = nums[0];
            int maximum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > maximum)
                {
                    maximum = nums[i];
                }
                if (nums[i] < minimum)
                {
                    minimum = nums[i];
                }
            }
            while (maximum != minimum)
            {
                if (maximum > minimum)
                {
                    maximum = maximum - minimum;
                }
                else
                {
                    minimum = minimum - maximum;
                }
            }
            return minimum;
        }
    }
}
