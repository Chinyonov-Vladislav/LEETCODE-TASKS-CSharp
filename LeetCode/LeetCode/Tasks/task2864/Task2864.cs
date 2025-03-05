using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2864
{
    /*
     2864. Максимальное нечетное двоичное число
    Вам дана двоичная строка s, которая содержит хотя бы один '1'.
    Вам нужно переставить биты таким образом, чтобы полученное двоичное число было максимальным нечётным двоичным числом, которое можно составить из этой комбинации.
    Верните строку, представляющую максимальное нечётное двоичное число, которое можно составить из заданной комбинации.
    Обратите внимание, что результирующая строка может содержать начальные нули.
    Ограничения:
        1 <= s.length <= 100
        s состоит только из '0' и '1'.
        s содержит по крайней мере один '1'.
    https://leetcode.com/problems/maximum-odd-binary-number/description/
     */
    public class Task2864 : InfoBasicTask
    {
        public Task2864(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "0101";
            Console.WriteLine($"Исходная бинарная строка: \"{str}\"");
            if (isValid(str))
            {
                string res = maximumOddBinaryNumber(str);
                Console.WriteLine($"Максимальное нечетное двоичное число: \"{res}\"");
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
        private bool isValid(string s)
        {
            if (s.Length < 1 || s.Length > 100)
            {
                return false;
            }
            int countOnes = 0;
            foreach (char c in s) {
                if (c != '1' && c != '0')
                {
                    return false;
                }
                if (c == '1')
                {
                    countOnes++;
                }
            }
            if (countOnes < 1)
            {
                return false;
            }
            return true;
        }
        private string maximumOddBinaryNumber(string s)
        {
            int countZeros = 0;
            int countOnes = 0;
            foreach (char c in s) {
                if (c == '1')
                {
                    countOnes++;
                }
                else
                {
                    countZeros++;
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append('1', countOnes - 1);
            sb.Append('0', countZeros);
            sb.Append('1');
            return sb.ToString();
        }
    }
}
