using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task451
{
    /*
     451. Сортировка символов по частоте
    Получив строку s, отсортируйте ее в порядке убывания на основе частоты символов. Частота символа - это количество раз, когда он встречается в строке.
    Верните отсортированную строку. Если ответов несколько, верните любой из них.
    Ограничения:
        1 <= s.length <= 5 * 10^5
        s состоит из прописных и строчных английских букв и цифр.
    https://leetcode.com/problems/sort-characters-by-frequency/description/
     */
    public class Task451 : InfoBasicTask
    {
        public Task451(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "tree";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                string res = frequencySort(s);
                Console.WriteLine($"Отсортированная строка по частоте букв (в убывающем порядке): \"{res}\"");
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
            int lowLimit = 1;
            int highLimit = 5 * (int)Math.Pow(10, 5);
            if (s.Length < lowLimit || s.Length > highLimit)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9')))
                {
                    return false;
                }
            }
            return true;
        }
        private string frequencySort(string s)
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
            Dictionary<char, int> orderedDict = dict.OrderByDescending(item => item.Value).ToDictionary(item => item.Key, item => item.Value);
            StringBuilder sb = new StringBuilder();
            foreach (var pair in orderedDict)
            {
                sb.Append(pair.Key, pair.Value);
            }
            return sb.ToString();
        }
    }
}
