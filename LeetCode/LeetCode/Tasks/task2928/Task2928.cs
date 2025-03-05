using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2928
{
    /*
     2928. Раздайте конфеты детям I
    Вам даны два натуральных числа n и limit.
    Верните общее количество способов распределить n конфеты между 3 детьми так, чтобы ни один ребёнок не получил больше limit конфет.
    Ограничения:
        1 <= n <= 50
        1 <= limit <= 50
    https://leetcode.com/problems/distribute-candies-among-children-i/description/
     */
    public class Task2928 : InfoBasicTask
    {
        public Task2928(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 5;
            int limit = 2;
            Console.WriteLine($"Количество конфет = {n}.Лимит = {limit}");
            if (isValid(n, limit))
            {
                int count = distributeCandies(n,limit);
                Console.WriteLine($"Количество способов распределить {n} конфет среди 3 детей, не превышаю {limit} конфет на одного ребенка = {count}");
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
        private bool isValid(int n, int limit)
        {
            if (n < 1 || n > 50 || limit < 1 || limit > 50)
            {
                return false;
            }
            return true;
        }
        private int distributeCandies(int n, int limit)
        {
            int count = 0;
            for (int i = 0; i <= limit; i++)
            {
                for (int j = 0; j <= limit; j++)
                {
                    for (int k = 0; k <= limit; k++)
                    {
                        if (i + j + k == n)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
