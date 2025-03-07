using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.Task3099
{
    /*
     3099. Число Харшада
    Целое число, делящееся на сумму своих цифр, называется харшадским числом. 
    Вам дано целое число x. 
    Верните сумму цифр x если x является харшадским числом, в противном случае верните -1.
    Ограничения:
        1 <= x <= 100
    https://leetcode.com/problems/harshad-number/description/
     */
    public class Task3099 : InfoBasicTask
    {
        public Task3099(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 18;
            Console.WriteLine($"Исходное число = {number}");
            if (isValid(number))
            {
                int sumOfDigits = sumOfTheDigitsOfHarshadNumber(number);
                Console.WriteLine(sumOfDigits == -1 ? $"Число {number} не является числом Харшада" : $"Число {number} является числом Харшада. Сумма цифр = {sumOfDigits}");
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
        private bool isValid(int x)
        {
            if (x < 1 || x > 100)
            {
                return false;
            }
            return true;
        }
        private int sumOfTheDigitsOfHarshadNumber(int x)
        {
            int number = x;
            int sumOfDigits = 0;
            while (number != 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }
            if (x % sumOfDigits == 0)
            {
                return sumOfDigits;
            }
            return -1;
        }
    }
}
