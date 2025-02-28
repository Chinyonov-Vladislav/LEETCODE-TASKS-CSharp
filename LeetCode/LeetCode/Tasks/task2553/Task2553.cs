using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2553
{
    /*
     2553. Разделите цифры в массиве
    Учитывая массив натуральных чисел nums, верните массив answer, который состоит из цифр каждого целого числа в nums после разделения их в том же порядке, в котором они появляются nums.
    Чтобы разделить цифры целого числа, нужно расположить все его цифры в том же порядке.
        Например, для целого числа 10921 разделение его цифр равно [1,0,9,2,1].
    Ограничения:
        1 <= nums.length <= 1000
        1 <= nums[i] <= 10^5
    https://leetcode.com/problems/separate-the-digits-in-an-array/description/
     */
    public class Task2553 : InfoBasicTask
    {
        public Task2553(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 13, 25, 83, 77 };
            printArray(arr);
            if (isValid(arr))
            {
                int[] result = separateDigits(arr);
                printArray(result, "Результирующий массив: ");
            }
            else
            {
                Console.WriteLine($"Исходные данные не валидны!");
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
            int upperLimit = (int)Math.Pow(10, 5);
            foreach (int num in nums) {
                if (num < 1 || num > upperLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] separateDigits(int[] nums)
        {
            List<int> digits = new List<int>();
            foreach (int num in nums) {
                int currentNum = num;
                List<int> localDigits = new List<int>();
                while (currentNum != 0)
                {
                    localDigits.Add(currentNum % 10);
                    currentNum /= 10;
                }
                localDigits.Reverse();
                foreach (int digit in localDigits)
                {
                    digits.Add(digit);
                }
            }
            return digits.ToArray();
        }
    }
}
