using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3300
{
    /*
     3300. Минимальный элемент после замены на сумму цифр
    Вам предоставляется целочисленный массив nums.
    Вы заменяете каждый элемент в nums на сумму его цифр.
    Верните минимальный элемент в nums после всех замен.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 10^4
    https://leetcode.com/problems/minimum-element-after-replacement-with-digit-sum/description/
     */
    public class Task3300 : InfoBasicTask
    {
        public Task3300(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 999, 19, 199 };
            printArray(nums);
            if (isValid(nums))
            {
                int min = minElement(nums);
                Console.WriteLine($"Минимальный элемент в массиве после суммирования чисел каждого элемента = {min}");
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
            int highLimit = (int)Math.Pow(10, 4);
            foreach (int num in nums) {
                if (num < 1 || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int minElement(int[] nums)
        {
            int min = -1;
            foreach (int num in nums)
            {
                int currentNum = num;
                int sumOfDigits = 0;
                while (currentNum != 0)
                {
                    sumOfDigits += currentNum%10;
                    currentNum/=10;
                }
                if (min == -1)
                {
                    min = sumOfDigits;
                }
                else if(sumOfDigits < min)
                {
                    min = sumOfDigits;
                }
            }
            return min;
        }
    }
}
