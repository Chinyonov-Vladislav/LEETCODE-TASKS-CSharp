using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task556
{
    /*
     556. Следующий Важный Элемент III
    Для заданного положительного целого числа n найдите наименьшее целое число, которое содержит ровно те же цифры, что и заданное целое число, n и больше по значению, чем n. Если такого положительного целого числа не существует, верните -1.
    Обратите внимание, что возвращаемое целое число должно помещаться в 32-разрядное целое число. Если есть правильный ответ, но он не помещается в 32-разрядное целое число, верните -1.
    Ограничения:
        1 <= n <= 2^31 - 1
    https://leetcode.com/problems/next-greater-element-iii/description/
     */
    public class Task556 : InfoBasicTask
    {
        public Task556(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 4321;
            Console.WriteLine($"Исходное число = {n}");
            if (isValid(n))
            {
                int res = nextGreaterElement(n);
                Console.WriteLine(res == -1 ? $"Отсутствует целое число, которое содержит ровно те же цифры, что и заданное целое число ({n}) и больше его по значению" : $"Наименьшее целое число, которое содержит ровно те же цифры, что и заданное целое число ({n}) и больше его по значению = {res}");
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
        private bool isValid(int n)
        {
            int lowLimit = 1;
            if (n < lowLimit)
            {
                return false;
            }
            return true;
        }
        private int nextGreaterElement(int n)
        {
            List<int> digits = new List<int>();
            int copyN = n;
            while (copyN != 0)
            {
                digits.Add(copyN % 10);
                copyN /= 10;
            }
            digits.Reverse();
            nextPermutation(digits);
            int number = 0;
            for (int i = 0; i < digits.Count; i++)
            {
                number += digits[i] * (int)Math.Pow(10, digits.Count - i - 1);
            }
            if (number < 0 || number <= n)
            {
                return -1;
            }
            return number;
        }

        private void nextPermutation(List<int> nums)
        {
            int n = nums.Count;
            int i = n - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i >= 0)
            {
                int j = n - 1;
                while (j >= 0 && nums[j] <= nums[i])
                {
                    j--;
                }
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
            int left = i + 1;
            int right = nums.Count - 1;
            while (left <= right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
        }
    }
}
