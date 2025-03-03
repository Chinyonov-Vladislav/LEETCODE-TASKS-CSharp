using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2652
{
    /*
     2652. Сумма чисел, кратных 3, 5 или 7
    Учитывая положительное целое число n, найдите сумму всех целых чисел в диапазоне [1, n] включительно, которые делятся на 3, 5 или 7.
    Верните целое число, обозначающее сумму всех чисел в заданном диапазоне, удовлетворяющих условию.
    Ограничения:
        1 <= n <= 10^3
    https://leetcode.com/problems/sum-multiples/description/
     */
    public class Task2652 : InfoBasicTask
    {
        public Task2652(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 10;
            Console.WriteLine($"Диапазон для поиска чисел, которые делятся на 3, 5 или 7: [1, {n}]");
            if (isValid(n))
            {
                int sum = sumOfMultiples(n);
                Console.WriteLine($"Сумма чисел от 1 до {n}, которые делятся нацело на 3, 5 или 7 = {sum}");
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
        private bool isValid(int n)
        {
            int upperLimit = (int)Math.Pow(10, 3);
            if (n < 1 || n > upperLimit)
            {
                return false;
            }
            return true;
        }
        private int sumOfMultiples(int n)
        {
            int sum = 0;
            for (int i = 3; i <= n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
