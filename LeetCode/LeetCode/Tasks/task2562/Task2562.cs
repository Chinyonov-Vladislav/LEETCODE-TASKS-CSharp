using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2562
{
    /*
     2562. Найдите значение конкатенации массива
    Вам будет предоставлен целочисленный массив с 0-индексом nums.
    Сложение двух чисел — это число, образованное путём сложения их цифр.
        Например, конкатенация 15, 49 является 1549.
    Значение конкатенацииnums изначально равно 0. Выполняйте эту операцию до тех пор, пока nums не станет пустым:
        Если в nums содержится более одного числа, выберите первый и последний элементы в nums соответственно и добавьте значение их объединения к объединённому значению nums, затем удалите первый и последний элементы из nums.
        Если существует один элемент, добавьте его значение к объединённому значению nums, а затем удалите его.
    Возвращает значение конкатенации nums.
    Ограничения:
        1 <= nums.length <= 1000
        1 <= nums[i] <= 10^4
    https://leetcode.com/problems/find-the-array-concatenation-value/description/
     */
    public class Task2562 : InfoBasicTask
    {
        public Task2562(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 7, 52, 2, 4 };
            printArray(arr);
            if (isValid(arr))
            {
                long result = findTheArrayConcVal(arr);
                Console.WriteLine($"Результат = {result}");
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
            int upperLimit = (int)Math.Pow(10, 4);
            foreach (int num in nums) {
                if (num < 1 || num > upperLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private long findTheArrayConcVal(int[] nums)
        {
            long result = 0;
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right) {
                if (left == right)
                {
                    result += nums[left];
                }
                else
                {
                    int leftValue = nums[left];
                    int rightValue = nums[right];
                    int countDigits = 0;
                    if (rightValue != 0)
                    {
                        while (rightValue != 0)
                        {
                            countDigits++;
                            rightValue /= 10;
                        }
                    }
                    else
                    {
                        countDigits = 1;
                    }
                    leftValue *= (int)Math.Pow(10, countDigits);
                    long concatenatedValue = leftValue + nums[right];
                    result += concatenatedValue;
                }
                left++;
                right--;
            }
            return result;
        }
    }
}
