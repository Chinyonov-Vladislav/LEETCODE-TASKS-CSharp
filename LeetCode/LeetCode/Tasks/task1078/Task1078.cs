using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1078
{
    /*
     1078. Вхождение после биграммы
    Учитывая две строки first и second, рассмотрим вхождения в некоторый текст формы "first second third", где second следует сразу за first, а third следует сразу за second.
    Возвращает массив всех слов third для каждого вхождения "first second third".
    https://leetcode.com/problems/occurrences-after-bigram/description/
     */
    public class Task1078 : InfoBasicTask
    {
        public Task1078(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "alice is a good girl she is a good student";
            Console.WriteLine($"Оригинальная строка = \"{str}\"");
            string firstWord = "a";
            string secondWord = "good";
            Console.WriteLine($"Первое слово в последовательности = \"{firstWord}\"");
            Console.WriteLine($"Второе слово в последовательности = \"{secondWord}\"");
            string[] result = findOcurrences(str, firstWord, secondWord);
            printArray(result, "Массив третьих слов в последовательности: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string[] findOcurrences(string text, string first, string second)
        {
            List<string> result = new List<string>();
            string[] words = text.Split(' ');
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i] == second && words[i - 1] == first && i != words.Length - 1)
                {
                    result.Add(words[i + 1]);
                }
            }
            return result.ToArray();
        }
    }
}
