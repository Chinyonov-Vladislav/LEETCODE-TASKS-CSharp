using LeetCode.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3226
{
    /*
     3226. Количество битовых изменений, необходимых для того, чтобы два целых числа стали равны
    Вам даны два натуральных числа n и k.
    Вы можете выбрать любой бит в двоичном представлении n, равный 1, и изменить его на 0.
    Верните количество изменений, необходимых для внесения, n равное k. Если это невозможно, верните значение -1.
    Ограничения:
        1 <= n, k <= 10^6
    https://leetcode.com/problems/number-of-bit-changes-to-make-two-integers-equal/description/
     */
    public class Task3226 : InfoBasicTask
    {
        public Task3226(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 13;
            int k = 4;
            Console.WriteLine($"Первое число = {n}\nВторое число = {k}");
            if (isValid(n, k))
            {
                int count = minChanges(n,k);
                Console.WriteLine(count == -1 ? $"Невозможно изменить бит со значением 1 в числе {n} так, чтобы получить {k}" :
                    count == 0 ? $"Числа {n} и {k} уже равны" : $"Необходимое количество смены бита 1 на 0 для того, чтобы числа {n} и {k} были равны = {count}");
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
        private bool isValid(int n, int k)
        {
            int highLimit = (int)Math.Pow(10, 6);
            if (n < 1 || n > highLimit || k < 1 || k > highLimit)
            {
                return false;
            }
            return true;
        }
        private int minChanges(int n, int k)
        {
            if (n == k)
            {
                return 0;
            }
            if (n < k)
            {
                return -1;
            }
            if (n<k ||(n & k) != k)
            {
                return -1;
            }
            int changes = 0;
            while (n != k)
            {
                if ((n & 1) == 1 && (k & 1) == 0)
                {
                    changes++;
                }
                n >>= 1;
                k >>= 1;
            }
            return changes;
        }
    }
}
