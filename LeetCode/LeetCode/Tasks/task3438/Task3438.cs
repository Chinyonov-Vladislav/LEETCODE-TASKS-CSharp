using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3438
{
    /*
     3438. Найдите допустимую пару соседних цифр в строке
    Вам дана строка s, состоящая только из цифр. Допустимая пара определяется как две соседние цифры в s, такие что:
        Первая цифра не равна второй.
        Каждая цифра в паре встречается s ровно столько раз, сколько её цифровое значение.
    Верните первую действительную пару, найденную в строке s при обходе слева направо. Если действительная пара не найдена, верните пустую строку.
    Ограничения:
        2 <= s.length <= 100
        s состоит только из цифр от '1' до '9'.
    https://leetcode.com/problems/find-valid-pair-of-adjacent-digits-in-string/description/
     */
    public class Task3438 : InfoBasicTask
    {
        public Task3438(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "2523533";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                string subStr = findValidPair(s);
                Console.WriteLine(subStr == String.Empty ? "Не найдена валидная пара" : $"Валидная пара: \"{subStr}\"");
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
        private bool isValid(string s)
        {
            if (s.Length < 2 || s.Length > 100)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= '1' && c <= '9'))
                {
                    return false;
                }
            }
            return true;
        }
        private string findValidPair(string s)
        {
            int[] freq = new int[10];
            foreach (char item in s) {
                int digit = item - '0';
                freq[digit]++;
            }
            for(int i=0;i<=s.Length-2;i++)
            {
                string subStr = s.Substring(i, 2);
                int firstDigit = subStr[0] - '0';
                int secondDigit = subStr[1] - '0';
                if (firstDigit == secondDigit)
                {
                    continue;
                }
                if (freq[firstDigit] != firstDigit || freq[secondDigit] != secondDigit)
                {
                    continue;
                }
                return subStr;
            }
            return String.Empty;
        }
    }
}
