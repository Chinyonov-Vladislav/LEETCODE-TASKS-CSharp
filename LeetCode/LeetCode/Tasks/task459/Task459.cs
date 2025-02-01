using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task459
{
    /*
     459. Повторяющийся шаблон подстроки
    Дана строка s. Проверьте, можно ли составить её из подстроки, добавив несколько копий этой подстроки.
    https://leetcode.com/problems/repeated-substring-pattern/description/
     */
    public class Task459 : InfoBasicTask
    {
        public Task459(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "aabaaba";
            Console.WriteLine(repeatedSubstringPattern(str) ? $"Строка \"{str}\" имеет повторяющийся паттерн" : $"Строка \"{str}\" не имеет повторяющего паттерна");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool repeatedSubstringPattern(string s)
        {
            if (s.Length == 1)
            {
                return false;
            }
            int length = 1;
            while (length <= s.Length / 2)
            {
                List<string> parts = new List<string>();
                for (int i = 0; i < s.Length; i += length)
                {
                    if (0 <= s.Length - i && s.Length - i < length)
                    {
                        string part = s.Substring(i, s.Length-i);
                        parts.Add(part);
                    }
                    else
                    {
                        string part = s.Substring(i, length);
                        parts.Add(part);
                    }
                }
                bool allPartsAreSame = true;
                string pattern = parts[0];
                for (int i = 1; i < parts.Count; i++)
                {
                    if (parts[i] != pattern)
                    {
                        allPartsAreSame = false;
                        break;
                    }
                }
                if (allPartsAreSame)
                {
                    return true;
                }
                length++;
            }
            return false;
        }
        // TODO: разобрать лучшее решение
        private bool bestSolution(string s)
        {
            string doubled = s + s;
            string trimmed = doubled.Substring(1, doubled.Length - 2);
            return trimmed.Contains(s);
        }
    }
}
