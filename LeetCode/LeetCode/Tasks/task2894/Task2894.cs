using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2894
{
    /*
     2894. Различие делимых и неделимых сумм
    Вам даны положительные целые числа n и m.
    Определите два целых числа следующим образом:
        num1: Сумма всех целых чисел в диапазоне [1, n] (оба включительно), которые не делятся на m.
        num2: Сумма всех целых чисел в диапазоне [1, n] (оба включительно), которые делятся на m.
    Возвращает целое число num1 - num2.
    Ограничения:
        1 <= n, m <= 1000
    https://leetcode.com/problems/divisible-and-non-divisible-sums-difference/description/
     */
    public class Task2894 : InfoBasicTask
    {
        public Task2894(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 5;
            int m =6;
            Console.WriteLine($"Диапазон: [{1},{n}]\nДелитель = {m}");
            if (isValid(n, m))
            {
                int res = differenceOfSums(n, m);
                Console.WriteLine($"Результат = {res}");
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
        private bool isValid(int n, int m)
        {
            if (n < 1 || n > 1000 || m < 1 || m > 1000)
            {
                return false;
            }
            return true;
        }
        private int differenceOfSums(int n, int m)
        {
            int totalSum = n * (n + 1) / 2;
            int sumDivisible = 0;
           
            for(int i=m;i<=n;i+=m)
            {
                sumDivisible += i;
            }
            int sumNotDivisible = totalSum - sumDivisible;
            return sumNotDivisible - sumDivisible;
        }
    }
}
