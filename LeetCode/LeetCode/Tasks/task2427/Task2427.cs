using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2427
{
    /*
     2427. Количество общих делителей
    Даны два положительных целых числа a и b, верните количество общих делителей a и b.
    Целое число x является общим делителем a и b, если x делит и a и b.
    Ограничения:
        1 <= a, b <= 1000
    https://leetcode.com/problems/number-of-common-factors/description/
     */
    public class Task2427 : InfoBasicTask
    {
        public Task2427(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int a = 12;
            int b = 6;
            Console.WriteLine($"Первое число = {a}. Второе число = {b}");
            if (isValid(a, b))
            {
                int result = commonFactors(a,b);
                Console.WriteLine($"Количество общих делителей чисел {a} и {b} = {result}");
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
        private bool isValid(int a, int b)
        {
            if (a < 1 || a > 1000 || b<1 || b>1000)
            {
                return false;
            }
            return true;
        }

        private int commonFactors(int a, int b)
        {
            int count = 0;
            int min = Math.Min(a, b);
            for (int i = 1; i <= min; i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
