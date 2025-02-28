using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2413
{
    /*
     2413. Наименьшее положительное целое число, которое кратно 2 и n
    Учитывая положительное целое число n, верните наименьшее положительное целое число, которое кратно и 2 и n.
    Ограничения:
        1 <= n <= 150
    https://leetcode.com/problems/smallest-even-multiple/description/
     */
    public class Task2413 : InfoBasicTask
    {
        public Task2413(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 5;
            if (isValid(number))
            {
                int result = smallestEvenMultiple(number);
                Console.WriteLine($"Наименьшее положительное целое число, которое кратно 2 и {number} = {result}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int number)
        {
            if (number < 1 || number > 150)
            {
                return false;
            }
            return true;
        }
        private int smallestEvenMultiple(int n)
        {
            if (n % 2 == 0)
            {
                return n;
            }
            return n * 2;
        }
    }
}
