using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2535
{
    /*
     2535. Разница между суммой элементов и суммой цифр массива
    Вам предоставлен массив положительных целых чисел nums.
    Сумма элементов - это сумма всех элементов в nums.
    Сумма цифр — это сумма всех цифр (не обязательно разных), которые встречаются в nums.
    Возвращает абсолютную разницу между суммой элементов и суммой цифр из nums.
    Обратите внимание, что абсолютная разница между двумя целыми числами x и y определяется как |x - y|.
    Ограничения:
        1 <= nums.length <= 2000
        1 <= nums[i] <= 2000
    https://leetcode.com/problems/difference-between-element-sum-and-digit-sum-of-an-array/description/
     */
    public class Task2535 : InfoBasicTask
    {
        public Task2535(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 15, 6, 3 };
            printArray(array);
            if (isValid(array))
            {
                int result = differenceOfSum(array);
                Console.WriteLine($"Модуль разницы между суммой чисел в массиве и суммой цифр = {result}");
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
            if (nums.Length < 1 || nums.Length > 2000)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 2000)
                {
                    return false;
                }
            }
            return true;
        }
        private int differenceOfSum(int[] nums)
        {
            int sumOfValues = 0;
            int sumOfDigits = 0;
            foreach (int num in nums)
            {
                sumOfValues += num;
                int currentNumber = num;
                while (currentNumber != 0)
                {
                    int digit = currentNumber % 10;
                    sumOfDigits += digit;
                    currentNumber /= 10;
                }
            }
            return Math.Abs(sumOfValues - sumOfDigits);
        }
    }
}
