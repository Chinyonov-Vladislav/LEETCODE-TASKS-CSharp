using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2255
{
    /*
     2255. Подсчитывать префиксы заданной строки
    Вам дан массив строк words и строка s, где words[i] и s состоят только из строчных букв английского алфавита.
    Возвращает количество строк в words , которые являются префиксом из s.
    Префикс строки — это подстрока, которая находится в начале строки. Подстрока — это непрерывная последовательность символов внутри строки.
    https://leetcode.com/problems/count-prefixes-of-a-given-string/description/
     */
    public class Task2255 : InfoBasicTask
    {
        public Task2255(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "a", "b", "c", "ab", "bc", "abc" };
            printArray(words, "Массив префиксов: ");
            string s = "abc";
            Console.WriteLine($"Строка для проверки префиксов: \"{s}\"");
            int result = countPrefixes(words, s);
            Console.WriteLine($"Количество префиксов из массива для строки \"{s}\" = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countPrefixes(string[] words, string s)
        {
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (s.StartsWith(words[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
