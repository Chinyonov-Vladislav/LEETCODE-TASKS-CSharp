using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3407
{
    /*
     3407. Шаблон сопоставления подстрок
    Вам дана строка s и шаблонная строка p, где p содержит ровно один '*' символ.
    '*' в p можно заменить любой последовательностью из нуля или более символов.
    Вернуть true если p можно сделать подстрокойs, и false в противном случае.
    Ограничения:
        1 <= s.length <= 50
        1 <= p.length <= 50 
        s содержит только строчные английские буквы.
        p содержит только строчные английские буквы и ровно одну '*'
    https://leetcode.com/problems/substring-matching-pattern/description/
     */
    public class Task3407 : InfoBasicTask
    {
        public Task3407(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "luck";
            string p = "u*";
            Console.WriteLine($"Исходная строка: \"{s}\"\nПаттерн: \"{p}\"");
            if (isValid(s, p))
            {
                Console.WriteLine(hasMatch(s, p) ? $"В исходной строке существует подстрока, которая соответствует паттерну \"{p}\"" : $"В исходной строке не существует подстрока, которая соответствует паттерну \"{p}\"");
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
        private bool isValid(string s, string p)
        {
            if (s.Length < 1 || s.Length > 50 || p.Length < 1 || p.Length > 50)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            int countStart = 0;
            foreach (char c in p)
            {
                if (c == '*')
                {
                    countStart++;
                }
                else if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            if (countStart != 1)
            {
                return false;
            }
            return true;
        }
        private bool hasMatch(string s, string p)
        {
            string[] parts = p.Split('*');
            if (parts[0] == String.Empty && parts[1] == String.Empty)
            {
                return true;
            }
            else if (parts[0] != String.Empty && parts[1] == String.Empty)
            {
                int indexFirstPart = s.IndexOf(parts[0]);
                if (indexFirstPart == -1)
                {
                    return false;
                }
                return true;
            }
            else if (parts[0] == String.Empty && parts[1] != String.Empty)
            {
                int indexSecondPart = s.LastIndexOf(parts[1]);
                if (indexSecondPart == -1)
                {
                    return false;
                }
                return true;
            }
            else
            {
                int indexFirstPart = s.IndexOf(parts[0]);
                if (indexFirstPart == -1)
                {
                    return false;
                }
                int indexSecondPart = s.LastIndexOf(parts[1]);
                if (indexSecondPart == -1)
                {
                    return false;
                }
                int indexLastLetterOfFirstPart = indexFirstPart + parts[0].Length - 1;
                if (indexSecondPart - indexLastLetterOfFirstPart >= 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
