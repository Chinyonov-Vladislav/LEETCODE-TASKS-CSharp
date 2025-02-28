using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2520
{
    /*
     2520. Подсчитайте количество цифр, на которые делится число
    Учитывая целое число num, верните количество цифр в num которое делится на num.
    Целое число val делится nums, если nums % val == 0.
    Ограничения:
        1 <= num <= 109
        num не содержит 0 в качестве одной из своих цифр.
    https://leetcode.com/problems/count-the-digits-that-divide-a-number/description/
     */
    public class Task2520 : InfoBasicTask
    {
        public Task2520(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 121;
            Console.WriteLine($"Исходное число = {number}");
            if (isValid(number))
            {
                int res = countDigits(number);
                Console.WriteLine($"Количество цифр в числе {number}, на которые делится число нацело = {res}");
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
        private bool isValid(int num)
        {
            int upperLimit = (int)Math.Pow(10, 9);
            if (num < 1 || num > upperLimit)
            {
                return false;
            }
            string str = num.ToString();
            foreach (char c in str)
            {
                if (c == '0')
                {
                    return false;
                }
            }
            return true;
        }
        private int countDigits(int num)
        {
            int count = 0;
            int number = num;
            while (number != 0)
            {
                int digit = number % 10;
                if (num % digit == 0)
                {
                    count++;
                }
                number /= 10;
            }
            return count;
        }
    }
}
