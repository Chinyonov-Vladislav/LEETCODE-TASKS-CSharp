using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task791
{
    /*
     791. Пользовательская cортировка строки
    Вам даны две строки order и s. Все символы orderуникальны и ранее были отсортированы в определённом порядке.
    Переставьте символы s так, чтобы они соответствовали порядку, в котором order была отсортирована. 
    В частности, если символ x встречается перед символом y в order, то x должен встречаться перед y в переставленной строке.
    Возвращает любую перестановку s, удовлетворяющую этому свойству.
    Ограничения:
        1 <= order.length <= 26
        1 <= s.length <= 200
        order и s состоят из строчных английских букв.
        Все персонажи order уникальны.
    https://leetcode.com/problems/custom-sort-string/description/
     */
    public class Task791 : InfoBasicTask
    {
        public Task791(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string order = "bcafg";
            string s = "abcd";
            Console.WriteLine($"Строка с порядком сортировки: \"{order}\"\nСтрока для сортировки: \"{s}\"");
            if (isValid(order, s))
            {
                string res = customSortString(order, s);
                Console.WriteLine($"Отсортированная строка: \"{res}\"");
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
        private bool isValid(string order, string s)
        {
            int lowLimitOrderLength = 1;
            int highLimitOrderLength = 26;
            int lowLimitSLength = 1;
            int highLimitSLength = 200;
            if(order.Length<lowLimitOrderLength || order.Length>highLimitOrderLength || s.Length<lowLimitSLength || s.Length>highLimitSLength)
            {
                return false;
            }
            HashSet<char> uniqueCharsFromOrder = new HashSet<char>();
            foreach (char c in order)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
                uniqueCharsFromOrder.Add(c);
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            if (uniqueCharsFromOrder.Count != order.Length)
            {
                return false;
            }
            return true;
        }
        private string customSortString(string order, string s)
        {
            StringBuilder result = new StringBuilder();
            int[] freqS = new int[26];
            foreach (char c in s)
            {
                freqS[c - 'a']++;
            }
            HashSet<char> usedChar = new HashSet<char>();
            foreach (char c in order)
            {
                int countOfLetter = freqS[c-'a'];
                if (countOfLetter > 0)
                {
                    usedChar.Add(c);
                    result.Append(c, countOfLetter);
                }
            }
            foreach (char c in s)
            {
                if (!usedChar.Contains(c))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
