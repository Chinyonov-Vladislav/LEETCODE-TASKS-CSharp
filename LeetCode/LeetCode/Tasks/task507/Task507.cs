using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task507
{
    /*
     507. Идеальное Число
    Совершенное число — это положительное целое число, которое равно сумме своих положительных делителей, исключая само число.Делитель целого числа x — это целое число, которое может разделить x без остатка.
    Учитывая целое число n, верните true если n оно является совершенным числом, в противном случае верните false.
     */
    public class Task507 : InfoBasicTask
    {
        public Task507(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 28;
            Console.WriteLine(checkPerfectNumber(number) ? $"Число {number} является идеальным" : $"Число {number} не является идеальным");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool checkPerfectNumber(int num)
        {
            int resultSum = 0;
            for (int i = 1; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    resultSum += i;
                }
            }
            return resultSum == num;
        }
        private bool bestSolution(int num)
        {
            int result = 0;
            for (int i = 1; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    result += i;

                    if (i * i != num)
                    {
                        result += num / i;
                    }
                }
            }
            return result - num == num;
        }
    }
}
