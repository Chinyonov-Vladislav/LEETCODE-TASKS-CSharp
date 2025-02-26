using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2185
{
    /*
     2185. Подсчет слов с заданным префиксом
    Вам будет предоставлен массив строк words и строка pref.
    Верните количество строк в words которые содержат pref в качестве префикса.
    Префикс строки s — это любая начальная непрерывная подстрока s.
    https://leetcode.com/problems/counting-words-with-a-given-prefix/description/
     */
    public class Task2185 : InfoBasicTask
    {
        public Task2185(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "pay", "attention", "practice", "attend" };
            printArray(words, "Массив слов: ");
            string prefix = "at";
            Console.WriteLine($"Префикс: \"{prefix}\"");
            int count = prefixCount(words, prefix);
            Console.WriteLine($"Количество слов в исходном массиве с заданным префиксом = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int prefixCount(string[] words, string pref)
        {
            int count = 0;
            foreach (string word in words)
            {
                if (word.StartsWith(pref))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
