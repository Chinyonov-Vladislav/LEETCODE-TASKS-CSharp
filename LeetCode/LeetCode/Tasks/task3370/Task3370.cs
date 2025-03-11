using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3370
{
    /*
     3370. Наименьшее число со всеми установленными битами
    Вам дано положительное число n.
    Возвращает наименьшее число x больше, чем или равный к n, такой, что двоичное представление x содержит только установленные биты
    Ограничения:
        1 <= n <= 1000
    https://leetcode.com/problems/smallest-number-with-all-set-bits/description/
     */
    public class Task3370 : InfoBasicTask
    {
        public Task3370(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 5;
            Console.WriteLine($"Исходное число = {number}");
            if (isValid(number))
            {
                int min = smallestNumber(number);
                Console.WriteLine($"Наименьшее число, которое больше или равно {number}, в котором все биты имеют значение 1 = {min}");
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
            if (n < 1 || n > 1000)
            {
                return false;
            }
            return true;
        }
        private int smallestNumber(int n)
        {
            int countBits = 0;
            while (n != 0)
            {
                countBits++;
                n = n >> 1;
            }
            int res = 0;
            for (int i = 0; i < countBits; i++)
            {
                res += (int)Math.Pow(2, countBits - i - 1);
            }
            return res;
        }
    }
}
