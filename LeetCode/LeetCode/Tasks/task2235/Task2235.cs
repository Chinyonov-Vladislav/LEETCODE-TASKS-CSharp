using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2235
{
    /*
     2235. Сложите два целых числа
    Учитывая два целых числа num1 и num2, верните сумму этих двух целых чисел.
    https://leetcode.com/problems/add-two-integers/description/
     */
    public class Task2235 : InfoBasicTask
    {
        public Task2235(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int num1 = 12;
            int num2 = 5;
            Console.WriteLine($"Первое число = {num1}\nВторое число = {num2}");
            int result = sum(num1, num2);
            Console.WriteLine($"{num1} + {num2} = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int sum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
