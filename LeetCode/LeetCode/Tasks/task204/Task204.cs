using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task204
{
    /*
     204. Подсчитайте простые числа
    Для заданного целого числа n верните количество простых чисел, которые строго меньше n.
    Ограничения:
        0 <= n <= 5 * 10^6
    https://leetcode.com/problems/count-primes/description/
     */
    public class Task204 : InfoBasicTask
    {
        public Task204(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = askUserValueOfVariable();
            if (isValid(n))
            {
                int resultCountPrimes = countPrimes(n);
                Console.WriteLine($"Количество простых чисел до числа {n} не включительно = {resultCountPrimes}");
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
        private int askUserValueOfVariable()
        {
            while (true)
            {
                Console.Write("Введите целое положительное число, которое будет означать границу, до которой не включительно необходимо найти количество простых чисел: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0)
                    {
                        throw new FormatException();
                    }
                    return choiceUser;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }
        private bool isValid(int n)
        {
            int lowLimit = 0;
            int highLimit = 5*(int)Math.Pow(10,6);
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int countPrimes(int n)
        {
            if (n <= 1)
            {
                return 0;
            }
            bool[] bools = new bool[n];
            
            int index = 2;
            while (Math.Pow(index, 2) < n)
            {
                if (!bools[index])
                {
                    int j = (int)Math.Pow(index, 2);
                    while (j < n)
                    {
                        bools[j] = true;
                        j += index;
                    }
                }
                index++;
            }
            int count = 0;
            for (int i = 2; i < bools.Length; i++)
            {
                if (!bools[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
