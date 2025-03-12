using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3411
{
    /*
     3411. Максимальная длина подмассива с равными произведениями
    Вам предоставляется массив положительных целых чисел nums.
    Массив arr называется эквивалентным произведению, если prod(arr) == lcm(arr) * gcd(arr), где:
        prod(arr) является произведением всех элементов arr.
        gcd(arr) является GCD всех элементов arr.
        lcm(arr) является LCM всех элементов arr.
    Верните длину самого длинного эквивалентного произведению подмассива nums.
    Ограничения:
        2 <= nums.length <= 100
        1 <= nums[i] <= 10
    https://leetcode.com/problems/maximum-subarray-with-equal-products/description/
     */
    public class Task3411 : InfoBasicTask
    {
        public Task3411(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 1, 2, 1, 1, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = maxLength(nums);
                Console.WriteLine($"Максимальная длина подмассива, которые элементы которого соблюдают условие: произведение всех элементов равно произведению НОД и НОК = {res}");
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
        private bool isValid(int[] nums)
        {
            if (nums.Length < 2 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 10)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxLength(int[] nums)
        {
            int length = nums.Length;
            while (length != 0)
            {
                bool isFindResult = false;
                for (int i = 0; i <= nums.Length - length; i++)
                {
                    int[] arr = new int[length];
                    int index = 0;
                    for (int j = i; j < i + length; j++)
                    {
                        arr[index] = nums[j];
                        index++;
                    }
                    int product = findProduct(arr);
                    int gcd = findGCD(arr);
                    int lcm = findLCM(arr);
                    if (product == gcd * lcm)
                    {
                        isFindResult = true;
                        break;
                    }
                }
                if (isFindResult)
                {
                    break;
                }
                length--;
            }
            return length;
        }
        private int findProduct(int[] nums)
        {
            int res =1;
            foreach (int num in nums)
            {
                res *= num;
            }
            return res;
        }
        private int findGCD(int[] nums)
        {
            int result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result = GCD(result, nums[i]);
                if (result == 1)
                {
                    break;
                }
            }
            return result;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private int findLCM(int[] array)
        {
            int result = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                result = LCM(result, array[i]);
            }
            return result;
        }
        private int LCM(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            return Math.Abs(a * b) / GCD(a, b);
        }
    }
}
