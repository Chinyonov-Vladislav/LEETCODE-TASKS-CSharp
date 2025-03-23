using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task343
{
    /*
     343. Разрыв целого числа
    Дано целое число n. Разбейте его на сумму k положительных целых чисел, где k >= 2. Найдите максимальное произведение этих целых чисел.
    Верните максимальное произведение, которое вы можете получить.
    Ограничения:
        2 <= n <= 58
    https://leetcode.com/problems/integer-break/description/
     */
    public class Task343 : InfoBasicTask
    {
        public Task343(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 10;
            Console.WriteLine($"Исходное число = {n}");
            if (isValid(n))
            {
                int res = integerBreak(n);
                Console.WriteLine($"Наибольшее произведение суммы положительных целых чисел (от 2 штук), которые составляют в сумме число {n} = {res}");
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
            int lowLimit = 2;
            int highLimit = 58;
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int integerBreak(int n)
        {
            if (n == 2 || n == 3)
            {
                return n-1;
            }
            int product = 1;
            while (n != 0)
            {
                if (n % 3 == 0)
                {
                    product *= 3;
                    n -= 3;
                }
                else
                {
                    product *= 2;
                    n -= 2;
                }
            }
            return product;
        }
    }
}
