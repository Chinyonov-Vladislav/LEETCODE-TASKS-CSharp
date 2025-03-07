using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3079
{
    /*
     3079. Найдите сумму зашифрованных целых чисел
    Вам дан целочисленный массив nums с положительными целыми числами. 
    Мы определяем функцию encrypt таким образом, что encrypt(x) заменяет каждую цифру в x на наибольшую цифру в x. 
        Например, encrypt(523) = 555 и encrypt(213) = 333.
    Возвращает сумму зашифрованных элементов.
    Ограничения:
        1 <= nums.length <= 50
        1 <= nums[i] <= 1000
    https://leetcode.com/problems/find-the-sum-of-encrypted-integers/description/
     */
    public class Task3079 : InfoBasicTask
    {
        public Task3079(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 10, 21, 31 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = sumOfEncryptedInt(nums);
                Console.WriteLine($"Сумма = {res}");
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
            if (nums.Length < 1 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private int sumOfEncryptedInt(int[] nums)
        {
            int sum = 0;
            foreach (int num in nums) { 
                int currentNum = num;
                List<int> digits = new List<int> ();
                int maxDigit = -1;
                while (currentNum != 0)
                {
                    int currentDigit = currentNum % 10;
                    digits.Add(currentDigit);
                    if (maxDigit == -1)
                    {
                        maxDigit = currentDigit;
                    }
                    else if (currentDigit > maxDigit)
                    {
                        maxDigit = currentDigit;
                    }
                    currentNum /= 10;
                }
                for (int i = digits.Count - 1; i >= 0; i--)
                {
                    sum += maxDigit * (int)Math.Pow(10,digits.Count - i -1);
                }
            }
            return sum;
        }
    }
}
