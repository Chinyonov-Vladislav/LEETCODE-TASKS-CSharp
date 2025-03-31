using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task633
{
    /*
     633. Сумма квадратных чисел
    Учитывая неотрицательное целое число c, решите, существует ли два целых числа a и b таких, что a2 + b2 = c.
    Ограничения:
        0 <= c <= 231 - 1
    https://leetcode.com/problems/sum-of-square-numbers/description/
     */
    public class Task633 : InfoBasicTask
    {
        public Task633(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int c = 5;
            Console.WriteLine($"Значение переменной c = {c}");
            if (isValid(c))
            {
                Console.WriteLine(judgeSquareSum(c) ? $"Существует такие два числа a и b, что они меньше, чем {c} и a^2+b^2 = {c}" : $"Несуществует таких двух чисел a и b, что они меньше, чем {c} и a^2+b^2 = {c}");
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
        private bool isValid(int c)
        {
            if (c < 0)
            {
                return false;
            }
            return true;
        }
        private bool judgeSquareSum(int c)
        {
            long left = 0;
            long right = (long)Math.Sqrt(c);
            while(left<=right)
            {
                long sum = left * left + right * right;
                if (sum == c)
                {
                    return true;
                }
                else if (sum > c)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return false;
        }
    }
}
