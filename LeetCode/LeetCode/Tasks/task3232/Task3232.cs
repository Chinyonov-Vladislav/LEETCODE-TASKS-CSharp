using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3232
{
    /*
     3232. Узнайте, можно ли выиграть в игру с цифрами
    Вам предоставляется массив положительных целых чисел nums.
    Алиса и Боб играют в какую-то игру. В игре Алиса может выбрать либо все однозначные числа, либо все двузначные числа из nums, а остальные числа передаются Бобу. Алиса выигрывает, если сумма ее чисел строго больше суммы чисел Боба.
    Вернитесь, true если Алиса сможет выиграть эту игру, в противном случае вернитесь false.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 99
    https://leetcode.com/problems/find-if-digit-game-can-be-won/description/
     */
    public class Task3232 : InfoBasicTask
    {
        public Task3232(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 5, 5, 5, 25 };
            printArray(nums);
            if (isValid(nums))
            {
                Console.WriteLine(canAliceWin(nums) ? "Алиса может выиграть игру" : "Алиса не может выиграть игру");
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
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 99)
                {
                    return false;
                }
            }
            return true;
        }
        private bool canAliceWin(int[] nums)
        {
            int sumOfDigitsSingleDigitNumbers = 0;
            int sumOfDigitsDoubleDigitNumbers = 0;
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int numFirst = nums[left];
                if (left == right)
                {
                    if (numFirst >= 0 && numFirst <= 9)
                    {
                        sumOfDigitsSingleDigitNumbers += numFirst;
                    }
                    else
                    {
                        sumOfDigitsDoubleDigitNumbers += numFirst;
                    }
                }
                else
                {
                   
                    int numSecond = nums[right];
                    if (numFirst >= 0 && numFirst <= 9)
                    {
                        sumOfDigitsSingleDigitNumbers += numFirst;
                    }
                    else
                    {
                        sumOfDigitsDoubleDigitNumbers += numFirst;
                    }
                    if (numSecond >= 0 && numSecond <= 9)
                    {
                        sumOfDigitsSingleDigitNumbers += numSecond;
                    }
                    else
                    {
                        sumOfDigitsDoubleDigitNumbers += numSecond;
                    }
                }
                left++;
                right--;
            }
            return sumOfDigitsSingleDigitNumbers != sumOfDigitsDoubleDigitNumbers;
        }
    }
}
