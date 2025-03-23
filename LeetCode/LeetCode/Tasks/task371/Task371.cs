using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task371
{
    /*
     371. Сумма двух целых чисел
    Даны два целых числа a и b, верните сумму этих двух целых чисел без использования операторов + и -.
    Ограничения:
        -1000 <= a, b <= 1000
    https://leetcode.com/problems/sum-of-two-integers/description/
     */
    public class Task371 : InfoBasicTask
    {
        public Task371(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int a = 2;
            int b = 3;
            Console.WriteLine($"Первое число = {a}\nВторое число = {b}");
            if (isValid(a, b))
            {
                int res = getSum(a, b);
                Console.WriteLine($"Сумма чисел {a} и {b} без использования операторов + и - = {res}");
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
        private bool isValid(int a, int b)
        {
            int lowLimit = -1000;
            int highLimit = 1000;
            if (a < lowLimit || a > highLimit || b < lowLimit || b > highLimit)
            {
                return false;
            }
            return true;
        }
        private int getSum(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            while (b != 0)
            {
                int carry = a & b;
                a ^= b;
                b = carry << 1;
            }
            return a;
        }
    }
}
