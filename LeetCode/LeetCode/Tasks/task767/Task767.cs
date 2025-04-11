using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task767
{
    /*
     767. Реорганизовать строку
    Дана строка s. Переставьте символы в s, чтобы любые два соседних символа не совпадали.
    Верните любую возможную перестановку s или верните "" , если это невозможно.
    Ограничения:
        1 <= s.length <= 500
        s состоит из строчных английских букв.
    https://leetcode.com/problems/reorganize-string/description/
     */
    public class Task767 : InfoBasicTask
    {
        public Task767(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "aab";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                string res = reorganizeString(s);
                Console.WriteLine(res == String.Empty ? "Невозможно переставить символы в исходной строке так, чтобы любые два соседних символа не совпадали" : $"Возможная перестановка символов в исходной строке так, чтобы любые два соседних символа не совпадали: \"{res}\"");
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
            int lowLimitLengthInitialString = 1;
            int highLimitLengthInitialString = 500;
            if (s.Length < lowLimitLengthInitialString || s.Length > highLimitLengthInitialString)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' || c <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }
        private string reorganizeString(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            StringBuilder sb = new StringBuilder();
            while (sb.Length != s.Length)
            {
                Dictionary<char, int> orderedDict = dict.OrderByDescending(item => item.Value).ToDictionary(item => item.Key, item => item.Value);
                int previousSize = sb.Length;
                foreach (var key in orderedDict.Keys.ToList())
                {
                    if (sb.Length == 0)
                    {
                        if (orderedDict[key] > 0)
                        {
                            sb.Append(key);
                            dict[key]--;
                            break;
                        }
                    }
                    else
                    {
                        if (orderedDict[key] > 0)
                        {
                            if (sb[sb.Length - 1] != key)
                            {
                                sb.Append(key);
                                dict[key]--;
                                break;
                            }
                        }
                    }
                }
                int newSize = sb.Length;
                if (previousSize == newSize)
                {
                    return String.Empty;
                }
            }
            return sb.ToString();
        }
    }
}
