using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3345
{
    /*
     3345. Произведение наименьших делимых цифр I
    Вам даны два целых числа n и t. Верните наименьшее число, большее или равное n, такое, что произведение его цифр делится на t.
    Ограничения:
        1 <= n <= 100
        1 <= t <= 10
    https://leetcode.com/problems/smallest-divisible-digit-product-i/description/
     */
    public class Task3345 : InfoBasicTask
    {
        public Task3345(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 15;
            int t = 3;
            Console.WriteLine($"Значение переменной n = {n}\nЗначение переменной t = {t}");
            if (isValid(n, t))
            {
                int min = smallestNumber(n, t);
                Console.WriteLine($"Минимальное число, большее или равное {n}, произведение цифр которого без остатка делится на {t} = {min}");
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
        private bool isValid(int n, int t)
        {
            if (n < 1 || n > 100 || t<1||t>10)
            {
                return false;
            }
            return true;
        }
        private int smallestNumber(int n, int t)
        {
            int min = n + 10;
            for (int number = n; number < n + 10; number++)
            {
                int currentNumber = number;
                int product = 1;
                while (currentNumber != 0)
                {
                    product *= currentNumber % 10;
                    currentNumber /= 10;
                }
                if (product % t == 0 && product < min)
                { 
                    min = number;
                    break;
                }
            }
            return min;
        }
    }
}
