using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task238
{
    /*
     238. Произведение элементов массива, кроме текущего
    Учитывая целочисленный массив nums, верните массив answer такой, что answer[i] равен произведению всех элементов nums кроме nums[i].
    Произведение любого префикса или суффикса nums гарантированно поместится в 32-битное целое число.
    Вы должны написать алгоритм, который выполняется за O(n) секунд и не использует операцию деления.
    Ограничения:
        2 <= nums.length <= 10^5
        -30 <= nums[i] <= 30
        Входные данные генерируются таким образом, что answer[i] гарантированно поместится в 32-битное целое число.
    https://leetcode.com/problems/product-of-array-except-self/description/
     */
    public class Task238 : InfoBasicTask
    {
        public Task238(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int[] answer = productExceptSelf(nums);
                printArray(answer, "Массив произведения элементов на остальных позициях, кроме текущей: ");
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
        private bool multiplyWithOverflowCheck(int a, int b)
        {
            try
            {
                checked
                {
                    int res = a * b;
                    return true;
                }
            }
            catch (OverflowException)
            {
                return false;
            }
        }
        private bool isValid(int[] nums)
        {
            int lowLimitLengthNums = 2;
            int highLimitLengthNums = (int)Math.Pow(10, 5);
            int lowLimitValueNum = -30;
            int highLimitValueNum = 30;
            if (nums.Length < lowLimitLengthNums || nums.Length > highLimitLengthNums)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < lowLimitValueNum || num > highLimitValueNum)
                {
                    return false;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int product = 1;
                int left = i - 1;
                int right = i+1;
                while (left != 0 && right != nums.Length)
                {
                    if (left >= 0)
                    {
                        int secondMultiplier = nums[left];
                        if (multiplyWithOverflowCheck(product, secondMultiplier))
                        {
                            product *=secondMultiplier;
                            left--;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (right < nums.Length)
                    {
                        int secondMultiplier = nums[right];
                        if (multiplyWithOverflowCheck(product, secondMultiplier))
                        {
                            product *= secondMultiplier;
                            right++;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private int[] productExceptSelf(int[] nums)
        {
            int[] answer = new int[nums.Length];
            int[] prefixProduct = new int[nums.Length];
            int[] suffixProduct = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    prefixProduct[i] = nums[i];
                }
                else
                {
                    prefixProduct[i] = nums[i] * prefixProduct[i - 1];
                }
            }
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i == nums.Length - 1)
                {
                    suffixProduct[i] = nums[i];
                }
                else
                {
                    suffixProduct[i] = nums[i] * suffixProduct[i + 1];
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    answer[i] = suffixProduct[i + 1];
                }
                else if (i == nums.Length - 1)
                {
                    answer[i] = prefixProduct[i - 1];
                }
                else
                {
                    answer[i] = prefixProduct[i - 1] * suffixProduct[i + 1];
                }
            }
            return answer;
        }
    }
}
