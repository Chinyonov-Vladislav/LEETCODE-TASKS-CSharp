using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1295
{
    /*
     1295. Найдите числа с четным количеством цифр
    Учитывая массив nums целых чисел, определите, сколько из них содержат чётное количество цифр.
    https://leetcode.com/problems/find-numbers-with-even-number-of-digits/description/
     */
    public class Task1295 : InfoBasicTask
    {
        public Task1295(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 12, 345, 2, 6, 7896 };
            printArray(array, "Исходный массив: ");
            int count = findNumbers(array);
            Console.WriteLine($"Количество чисел, содержащих чётное количество цифр = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findNumbers(int[] nums)
        {
            int countNumbersWithEvenCountOfDigits = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int count = 0;
                int currentValue = nums[i];
                if (currentValue == 0)
                {
                    count++;
                }
                else
                {
                    while (currentValue != 0)
                    {
                        currentValue /= 10;
                        count++;
                    }
                }
                if (count % 2 == 0)
                {
                    countNumbersWithEvenCountOfDigits++;
                }
            }
            return countNumbersWithEvenCountOfDigits;
        }
    }
}
