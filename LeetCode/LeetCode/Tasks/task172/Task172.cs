using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task172
{
    /*
     172. Факториальные конечные нули
    Учитывая целое число n, верните количество завершающих нулей в n!.
    Обратите внимание на это n! = n * (n - 1) * (n - 2) * ... * 3 * 2 * 1.
    Ограничения:
        0 <= n <= 10^4
    https://leetcode.com/problems/factorial-trailing-zeroes/description/
     */
    public class Task172 : InfoBasicTask
    {
        public Task172(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 30;
            Console.WriteLine($"Факториал - {n}");
            if (isValid(n))
            {
                int res = trailingZeroes(n);
                Console.WriteLine($"Количество факториальных конечных нулей = {res}");
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
            int lowLimit = 0;
            int highLimit = (int)Math.Pow(10,4);
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int trailingZeroes(int n)
        {
            int countFive = 0;
            int countTwo = 0;
            if (n == 0)
            {
                return 0;
            }
            for (int i = 1; i <=n; i++)
            {
                int currentNumber = i;
                while (currentNumber % 2 == 0)
                {
                    countTwo++;
                    currentNumber /= 2;
                }
                while (currentNumber % 5 == 0)
                {
                    countFive++;
                    currentNumber /= 5;
                }
            }
            return Math.Min(countTwo, countFive);
        }
    }
}
