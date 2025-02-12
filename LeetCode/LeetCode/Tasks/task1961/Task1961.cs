using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1961
{
    /*
     1961. Проверьте, является ли строка префиксом массива
    Даны строка s и массив строк words. Определите, является ли s префиксом words.
    Строка s является префиксом строки words, если s можно получить, объединив первые k строк в words для некоторого положительного k числа, не превышающего words.length.
    Вернуть true если s является префиксной строкой из words, или false иначе.
    https://leetcode.com/problems/check-if-string-is-a-prefix-of-array/description/
     */
    public class Task1961 : InfoBasicTask
    {
        public Task1961(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "i", "love", "leetcode", "apples" };
            printArray(words, "Исходный массив строк: ");
            string s = "iloveleetcode";
            Console.WriteLine($"Строка s: {s}");
            Console.WriteLine(isPrefixString(s, words) ? "Строка s является префиксной строкой из массива строк words" : "Строка s не является префиксной строкой из массива строк words");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isPrefixString(string s, string[] words)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int k = 0; k < words.Length; k++)
            {
                stringBuilder.Append(words[k]);
                if (s == stringBuilder.ToString())
                {
                    return true;
                }
                if (stringBuilder.Length >= s.Length)
                {
                    break;
                }
            }
            return false;
        }
    }
}
