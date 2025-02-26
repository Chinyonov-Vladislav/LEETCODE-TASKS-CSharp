using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2269
{
    /*
     2269. Найдите K-красоту числа
     k-красота целого числа num определяется как количество подстрок в num при чтении как строки, которые удовлетворяют следующим условиям:
        Он имеет длину k.
        Это делитель num.
    Учитывая целые числа num и k, верните k-красоту num.
    Примечание:
        Допускаютсяначальные нули.
        0 не является делителем какого-либо значения.
        Подстрока - это непрерывная последовательность символов в строке.
    https://leetcode.com/problems/find-the-k-beauty-of-a-number/description/
     */
    public class Task2269 : InfoBasicTask
    {
        public Task2269(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 240;
            int k = 2;
            Console.WriteLine($"Исходное число = {number}\nДлина = {k}");
            int count = divisorSubstrings(number, k);
            Console.WriteLine($"Количество подстрок длины {k}, которые являются делителем числа {number} = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int divisorSubstrings(int num, int k)
        {
            int count = 0;
            string numberStr = num.ToString();
            for (int i = 0; i <= numberStr.Length-k; i++)
            {
                int divisor = Int32.Parse(numberStr.Substring(i, k));
                if (divisor == 0)
                {
                    continue;
                }
                if (num % divisor == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
