using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1967
{
    /*
     1967. Количество строк, которые встречаются в качестве подстрок в слове
    Учитывая массив строк patterns и строку word, верните количество строк в patterns, которые существуют как подстрока в word.
    Подстрока - это непрерывная последовательность символов внутри строки.
    https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word/description/
     */
    public class Task1967 : InfoBasicTask
    {
        public Task1967(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] patterns = new string[] { "a", "abc", "bc", "d" };
            printArray(patterns, "Массив паттернов: ");
            string word = "abc";
            Console.WriteLine($"Слово для поиска количества паттернов в нём: \"{word}\"");
            int count = numOfStrings(patterns, word);
            Console.WriteLine($"Количество паттернов из массива, которые встречаются в слове = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int numOfStrings(string[] patterns, string word)
        {
            int count = 0;
            for (int i = 0; i < patterns.Length; i++)
            {
                if (word.Contains(patterns[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
